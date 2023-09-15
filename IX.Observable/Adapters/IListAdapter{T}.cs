using System.Collections;

namespace IX.Observable.Adapters;

/// <summary>
///     An adapter interface for non-standard collection types.
/// </summary>
/// <typeparam name="T">The type of item.</typeparam>
/// <seealso cref="ICollectionAdapter{T}" />
/// <seealso cref="IList" />
/// <seealso cref="IList{T}" />
/// <seealso cref="IReadOnlyList{T}" />
public interface IListAdapter<T> : ICollectionAdapter<T>,
    IList<T>
{
    /// <summary>
    ///     Gets a value indicating whether this instance is fixed size.
    /// </summary>
    /// <value>
    ///     <see langword="true" /> if this instance is fixed size; otherwise, <see langword="false" />.
    /// </value>
    /// <remarks>
    ///     <para>Since this is an adapter, this property always returns false.</para>
    /// </remarks>
    bool IsFixedSize { get; }

    /// <summary>
    ///     Adds a range of items to the list.
    /// </summary>
    /// <param name="items">The items.</param>
    /// <returns>The index of the firstly-introduced item.</returns>
    int AddRange(IEnumerable<T> items);
}