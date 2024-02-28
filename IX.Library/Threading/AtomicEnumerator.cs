using IX.Library.Collections;

using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Reflection;

namespace IX.Library.Threading;

/// <summary>
///     An atomic enumerator that can enumerate items one at a time, atomically.
/// </summary>
/// <seealso cref="DisposableBase" />
public abstract class AtomicEnumerator : DisposableBase
{
    protected private static readonly ConcurrentDictionary<Type, Delegate> ConstructionDelegates = new();

    protected private AtomicEnumerator() { }

    /// <summary>
    ///     Creates an atomic enumerator from a collection.
    /// </summary>
    /// <typeparam name="TItem">The type of the item in the collection.</typeparam>
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
        "Performance",
        "HAA0401:Possible allocation of reference type enumerator",
        Justification = "Not an issue, since we're returning a class-based atomic enumerator anyway.")]
    [RequiresUnreferencedCode(
        "The atomic enumerator dynamically generates and invokes code in the AtomicEnumerator<TItem> class.")]
    public static AtomicEnumerator<TItem> FromCollection<TItem, TCollection>(
        TCollection collection,
        Func<ValueSynchronizationLockerRead>
            readLock)
        where TCollection : class, IEnumerable<TItem>
    {
        // Validate arguments
        _ = Requires.NotNull(collection);
        _ = Requires.NotNull(readLock);

        Delegate initializer = ConstructionDelegates.GetOrAdd(
            typeof(TCollection),
            (
                collectionType,
                _) =>
            {
                // Get used types
                MethodInfo getEnumeratorMethodInfo = collectionType.GetMethod(
                        nameof(IEnumerable<TItem>.GetEnumerator),
                        BindingFlags.Public | BindingFlags.Instance)
                    !;

                // ReSharper disable once PossibleNullReferenceException - We know this cannot be null, as we're interrogating the GetEnumerator method if an IEnumerable - there must be at least one
                Type enumeratorType = getEnumeratorMethodInfo.ReturnType;
                Type atomicEnumeratorType = typeof(AtomicEnumerator<,>).MakeGenericType(
                    typeof(TItem),
                    enumeratorType);
                ConstructorInfo atomicEnumeratorConstructorInfo = atomicEnumeratorType.GetConstructors()[0];

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
            }, collection);

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
    ///     Advances the enumerator to the next element of the collection.
    /// </summary>
    /// <returns>
    ///     <see langword="true" /> if the enumerator was successfully advanced to the next element;
    ///     <see langword="false" /> if the enumerator has passed the end of the collection.
    /// </returns>
    public abstract bool MoveNext();

    /// <summary>
    ///     Sets the enumerator to its initial position, which is before the first element in the collection.
    /// </summary>
    public abstract void Reset();
}