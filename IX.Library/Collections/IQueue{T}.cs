using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace IX.Library.Collections;

/// <summary>
///     A contract for a queue.
/// </summary>
/// <typeparam name="T">The type of elements in the queue.</typeparam>
/// <seealso cref="IEnumerable{T}" />
/// <seealso cref="ICollection" />
/// <seealso cref="IReadOnlyCollection{T}" />
[PublicAPI]
[SuppressMessage(
    "ReSharper",
    "PossibleInterfaceMemberAmbiguity",
    Justification = "Member ambiguity is unavoidable when implementing ICollection")]
[SuppressMessage(
    "Design",
    "CA1010:Generic interface should also be implemented",
    Justification = "This is not necessary.")]
[SuppressMessage(
    "Naming",
    "CA1710:Identifiers should have correct suffix",
    Justification = "This is not necessary.")]
public interface IQueue<T> : ICollection,
    IReadOnlyCollection<T>
{
    /// <summary>
    ///     Gets a value indicating whether this queue is empty.
    /// </summary>
    /// <value>
    ///     <c>true</c> if this queue is empty; otherwise, <c>false</c>.
    /// </value>
    bool IsEmpty { get; }

    /// <summary>
    ///     Clears the queue of all elements.
    /// </summary>
    void Clear();

    /// <summary>
    ///     Verifies whether or not an item is contained in the queue.
    /// </summary>
    /// <param name="item">The item to verify.</param>
    /// <returns><see langword="true" /> if the item is queued, <see langword="false" /> otherwise.</returns>
    bool Contains(T item);

    /// <summary>
    ///     De-queues an item and removes it from the queue.
    /// </summary>
    /// <returns>The item that has been de-queued.</returns>
    T Dequeue();

    /// <summary>
    ///     Attempts to de-queue an item and to remove it from queue.
    /// </summary>
    /// <param name="item">The item that has been de-queued, default if unsuccessful.</param>
    /// <returns>
    ///     <see langword="true" /> if an item is de-queued successfully, <see langword="false" /> otherwise, or if the
    ///     queue is empty.
    /// </returns>
    bool TryDequeue([MaybeNullWhen(false)] out T item);

    /// <summary>
    ///     Attempts to peek at the current queue and return the item that is next in line to be dequeued.
    /// </summary>
    /// <param name="item">The item, or default if unsuccessful.</param>
    /// <returns><see langword="true" /> if an item is found, <see langword="false" /> otherwise, or if the queue is empty.</returns>
    bool TryPeek([MaybeNullWhen(false)] out T item);

    /// <summary>
    ///     Queues an item, adding it to the queue.
    /// </summary>
    /// <param name="item">The item to enqueue.</param>
    void Enqueue(T item);

    /// <summary>
    ///     Queues a range of elements, adding them to the queue.
    /// </summary>
    /// <param name="items">The item range to push.</param>
    void EnqueueRange(T[] items);

    /// <summary>
    ///     Queues a range of elements, adding them to the queue.
    /// </summary>
    /// <param name="items">The item range to enqueue.</param>
    /// <param name="startIndex">The start index.</param>
    /// <param name="count">The number of items to enqueue.</param>
    void EnqueueRange(
        T[] items,
        int startIndex,
        int count);

    /// <summary>
    ///     Peeks at the topmost element in the queue, without removing it.
    /// </summary>
    /// <returns>The item peeked at, if any.</returns>
    T Peek();

    /// <summary>
    ///     Copies all elements of the queue into a new array.
    /// </summary>
    /// <returns>The created array with all element of the queue.</returns>
    T[] ToArray();

    /// <summary>
    ///     Trims the excess free space from within the queue, reducing the capacity to the actual number of elements.
    /// </summary>
    void TrimExcess();
}