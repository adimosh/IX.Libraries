using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace IX.Observable.Adapters;

/// <summary>
///     An adapter class for various collection types.
/// </summary>
/// <typeparam name="TItem">The type of items in the adapter.</typeparam>
/// <typeparam name="TEnumerator">The type of enumerator for this collection adapter.</typeparam>
/// <seealso cref="IX.Observable.Adapters.ICollectionAdapter{T}" />
internal abstract class ModernCollectionAdapter<TItem, TEnumerator> : ModernCollectionAdapter, ICollectionAdapter<TItem>
    where TEnumerator : IEnumerator<TItem>
{
    /// <summary>
    ///     Determines whether the container list contains the specified item.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <returns>
    ///     <see langword="true" /> if the container list contains the specified item; otherwise, <see langword="false" />.
    /// </returns>
    public abstract bool Contains(TItem item);

    /// <summary>
    ///     Copies the contents of the container to an array.
    /// </summary>
    /// <param name="array">The array.</param>
    /// <param name="arrayIndex">Index of the array.</param>
    public abstract void CopyTo(
        TItem[] array,
        int arrayIndex);

    /// <summary>
    ///     Adds the specified item.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <returns>The index of the freshly-added item.</returns>
    public abstract int Add(TItem item);

    /// <summary>
    ///     Removes the specified item.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <returns>The index of the removed item, or <c>-1</c> if removal was not successful.</returns>
    public abstract int Remove(TItem item);

    /// <summary>
    ///     Returns an enumerator that iterates through the collection.
    /// </summary>
    /// <returns>An enumerator that can be used to iterate through the collection.</returns>
    [SuppressMessage(
        "Performance",
        "HAA0401:Possible allocation of reference type enumerator",
        Justification = "Unavoidable due to interface implementation.")]
    [SuppressMessage(
        "Performance",
        "HAA0601:Value type to reference type conversion causing boxing allocation",
        Justification = "Unavoidable due to interface implementation.")]
    IEnumerator<TItem> IEnumerable<TItem>.GetEnumerator() => GetEnumerator();

    /// <summary>Adds an item to the <see cref="ICollection{TItem}" />.</summary>
    /// <param name="item">The object to add to the <see cref="ICollection{TItem}" />.</param>
    /// <exception cref="NotSupportedException">The <see cref="ICollection{TItem}" /> is read-only.</exception>
    void ICollection<TItem>.Add(TItem item) => Add(item);

    /// <summary>Removes the first occurrence of a specific object from the <see cref="ICollection{TItem}" />.</summary>
    /// <param name="item">The object to remove from the <see cref="ICollection{TItem}" />.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="item" /> was successfully removed from the
    ///     <see cref="ICollection{TItem}" />; otherwise, <see langword="false" />. This method also returns
    ///     <see langword="false" /> if <paramref name="item" /> is not found in the original <see cref="ICollection{TItem}" />
    ///     .
    /// </returns>
    /// <exception cref="NotSupportedException">The <see cref="ICollection{TItem}" /> is read-only.</exception>
    bool ICollection<TItem>.Remove(TItem item) => Remove(item) != -1;

    /// <summary>
    ///     Returns an enumerator that iterates through the collection.
    /// </summary>
    /// <returns>An enumerator that can be used to iterate through the collection.</returns>
    [SuppressMessage(
        "Performance",
        "HAA0601:Value type to reference type conversion causing boxing allocation",
        Justification = "Unavoidable due to interface implementation.")]
    [ExcludeFromCodeCoverage]
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    /// <summary>
    ///     Returns an enumerator that iterates through the collection.
    /// </summary>
    /// <returns>An enumerator that can be used to iterate through the collection.</returns>
    [SuppressMessage("ReSharper",
                     "MemberCanBeProtected.Global",
                     Justification = "We need this for foreach cycles.")]
    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "Some of the team members use ReSharper")]
    public abstract TEnumerator GetEnumerator();
}