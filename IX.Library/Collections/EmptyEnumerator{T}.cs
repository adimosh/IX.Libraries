using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace IX.Core.Collections;

#if NETSTANDARD2_1
/// <summary>
///     An empty enumerator.
/// </summary>
/// <typeparam name="T">The type of items in the enumerator.</typeparam>
/// <seealso cref="IEnumerator{T}" />
/// <seealso cref="IEnumerator" />
/// <seealso cref="IAsyncEnumerator{T}" />
#else
/// <summary>
///     An empty enumerator.
/// </summary>
/// <typeparam name="T">The type of items in the enumerator.</typeparam>
/// <seealso cref="IEnumerator{T}" />
/// <seealso cref="IEnumerator" />
#endif
[PublicAPI]
[SuppressMessage(
    "ReSharper",
    "PartialTypeWithSinglePart",
    Justification = "Used in .NET Standard 2.1")]
public sealed partial class EmptyEnumerator<T> : IEnumerator<T>
{
    private static readonly EmptyEnumerator<T> EmptyInstance = new();

    /// <summary>
    ///     Prevents a default instance of the <see cref="EmptyEnumerator{T}" /> class from being created.
    /// </summary>
    private EmptyEnumerator()
    {
        // Nothing to do.
    }

    /// <summary>
    ///     Gets a default value.
    /// </summary>
    [SuppressMessage(
        "Performance",
        "HAA0601:Value type to reference type conversion causing boxing allocation",
        Justification = "We offer a default value, even at the risk of boxing, in order to keep up with the standards that are expected of the interface enumerator.")]
    object IEnumerator.Current => default(T)!;

    /// <summary>
    ///     Gets a default value.
    /// </summary>
    T IEnumerator<T>.Current => default!;

    /// <summary>
    ///     Gets this empty instance.
    /// </summary>
    /// <returns>The empty instance.</returns>
    [SuppressMessage(
        "Design",
        "CA1000:Do not declare static members on generic types",
        Justification = "This is intended.")]
    public static EmptyEnumerator<T> Get() => EmptyInstance;

    /// <summary>
    ///     Does nothing.
    /// </summary>
    [SuppressMessage(
        "Design",
        "CA1063:Implement IDisposable Correctly",
        Justification = "This does nothing and is supposed to do nothing.")]
    void IDisposable.Dispose()
    {
        // Nothing to do.
    }

    /// <summary>
    ///     Does nothing.
    /// </summary>
    /// <returns>
    ///     Always returns <see langword="false" />.
    /// </returns>
    bool IEnumerator.MoveNext() => false;

    /// <summary>
    ///     Does nothing.
    /// </summary>
    void IEnumerator.Reset()
    {
        // Nothing to do.
    }
}