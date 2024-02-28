using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Reflection;

namespace IX.Library.Threading;

/// <summary>
///     An atomic enumerator that can enumerate items one at a time, atomically.
/// </summary>
/// <typeparam name="TItem">The type of the items to enumerate.</typeparam>
/// <seealso cref="IEnumerator{T}" />
/// <seealso cref="AtomicEnumerator" />
public abstract class AtomicEnumerator<TItem> : AtomicEnumerator, IEnumerator<TItem>
{
    /// <summary>
    ///     Prevents a default instance of the <see cref="AtomicEnumerator{TItem}" /> class from being created.
    /// </summary>
    protected private AtomicEnumerator() { }

    /// <summary>
    ///     Gets the element in the collection at the current position of the enumerator.
    /// </summary>
    /// <value>The current element.</value>
    public abstract TItem Current { get; }

    /// <summary>
    ///     Gets the element in the collection at the current position of the enumerator.
    /// </summary>
    /// <value>The current element.</value>
    [SuppressMessage(
        "Performance",
        "HAA0601:Value type to reference type conversion causing boxing allocation",
        Justification = "Unavoidable with a generic enumerator.")]
    object? IEnumerator.Current => Current;

    /// <summary>
    ///     Creates an atomic enumerator from a collection.
    /// </summary>
    /// <typeparam name="TCollection">The type of the collection.</typeparam>
    /// <param name="collection">The collection.</param>
    /// <param name="readLock">The function to acquire a read lock.</param>
    /// <returns>The created atomic enumerator.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="collection" />
    ///     or
    ///     <paramref name="readLock" />
    ///     is <c>null</c> (<c>Nothing</c> in Visual Basic).
    /// </exception>
    [SuppressMessage(
        "Performance",
        "HAA0303:Lambda or anonymous method in a generic method allocates a delegate instance",
        Justification = "We need this instance allocated.")]
    [SuppressMessage(
        "Design",
        "CA1000:Do not declare static members on generic types",
        Justification = "This is, honestly, a stupid rule.")]
    [SuppressMessage(
        "Performance",
        "HAA0401:Possible allocation of reference type enumerator",
        Justification = "Not an issue, since we're returning a class-based atomic enumerator anyway.")]
    [RequiresUnreferencedCode(
        "The atomic enumerator dynamically generates and invokes code in the AtomicEnumerator<TItem,TEnumerator> class.")]
    public static AtomicEnumerator<TItem> FromCollection<TCollection>(
        TCollection collection,
        Func<ValueSynchronizationLockerRead> readLock)
        where TCollection : class, IEnumerable<TItem>
    {
        // Validate arguments
        _ = Requires.NotNull(collection);
        _ = Requires.NotNull(readLock);

        Delegate initializer = ConstructionDelegates.GetOrAdd(
            collection.GetType(),
            static collectionType =>
            {
                // Get used types
                MethodInfo getEnumeratorMethodInfo = collectionType.GetMethod(
                        "GetEnumerator",
                        BindingFlags.Public | BindingFlags.Instance)
                    !;

                Type enumeratorType = getEnumeratorMethodInfo.ReturnType;
                Type atomicEnumeratorType = typeof(AtomicEnumerator<,>).MakeGenericType(
                    typeof(TItem),
                    enumeratorType);
                ConstructorInfo atomicEnumeratorConstructorInfo = atomicEnumeratorType.GetConstructors().Single(
                    p => p.GetParameters()[1].ParameterType == typeof(Func<ValueSynchronizationLockerRead>));

                // Prepare parameter expressions
                ParameterExpression parameter1 = Expression.Parameter(collectionType);
                ParameterExpression parameter2 = Expression.Parameter(typeof(Func<ValueSynchronizationLockerRead>));

                // Prepare expression
                return Expression.Lambda(
                    Expression.New(
                        atomicEnumeratorConstructorInfo,
                        Expression.Call(
                            parameter1,
                            getEnumeratorMethodInfo), parameter2),
                    parameter1,
                    parameter2).Compile();
            });

        if (initializer is Func<TCollection, Func<ValueSynchronizationLockerRead>, AtomicEnumerator<TItem>>
            typedInitializer)
        {
            return typedInitializer(
                collection,
                readLock);
        }

        return (AtomicEnumerator<TItem>)initializer.DynamicInvoke(
            collection,
            readLock)!;
    }

    /// <summary>
    ///     Creates an atomic enumerator from an already-existing enumerator.
    /// </summary>
    /// <typeparam name="TEnumerator">The type of the enumerator.</typeparam>
    /// <param name="enumerator">The enumerator.</param>
    /// <param name="readLock">The function to acquire a read lock.</param>
    /// <returns>The created atomic enumerator.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="enumerator" />
    ///     or
    ///     <paramref name="readLock" />
    ///     is <c>null</c> (<c>Nothing</c> in Visual Basic).
    /// </exception>
    [SuppressMessage(
        "Design",
        "CA1000:Do not declare static members on generic types",
        Justification = "This is, honestly, a stupid rule.")]
    public static AtomicEnumerator<TItem> FromEnumerator<TEnumerator>(
        TEnumerator enumerator,
        Func<ValueSynchronizationLockerRead> readLock)
        where TEnumerator : IEnumerator<TItem>
    {
        _ = Requires.NotNull(enumerator);
        _ = Requires.NotNull(readLock);

        return new AtomicEnumerator<TItem, TEnumerator>(
            enumerator,
            readLock);
    }
}