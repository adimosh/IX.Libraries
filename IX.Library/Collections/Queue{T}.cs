using IX.Library.Contracts;

using System.Diagnostics.CodeAnalysis;

using GlobalCollectionsGeneric = System.Collections.Generic;

namespace IX.Library.Collections;

/// <summary>
///     Represents a variable-size first-in first-out (FIFO) collection of instances of the same specified type.
/// </summary>
/// <typeparam name="T">The type of elements in the queue.</typeparam>
/// <seealso cref="GlobalCollectionsGeneric.Queue{T}" />
/// <seealso cref="IX.Library.Collections.IQueue{T}" />
[PublicAPI]
[SuppressMessage(
    "Design",
    "CA1010:Generic interface should also be implemented",
    Justification = "This is not necessary.")]
public class Queue<T> : GlobalCollectionsGeneric.Queue<T>,
    IQueue<T>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="IX.Library.Collections.Queue{T}" /> class.
    /// </summary>
    public Queue() { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="IX.Library.Collections.Queue{T}" /> class.
    /// </summary>
    /// <param name="capacity">The initial number of elements that the <see cref="IX.Library.Collections.Queue{T}" /> can contain.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="capacity" /> is less than zero.</exception>
    public Queue(int capacity)
        : base(capacity) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="IX.Library.Collections.Queue{T}" /> class.
    /// </summary>
    /// <param name="collection">The collection to copy elements from.</param>
    /// <exception cref="ArgumentNullException"><paramref name="collection" /> is <see langword="null" />.</exception>
    public Queue(IEnumerable<T> collection)
        : base(collection) { }

    /// <summary>
    ///     Gets a value indicating whether this queue is empty.
    /// </summary>
    /// <value>
    ///     <c>true</c> if this queue is empty; otherwise, <c>false</c>.
    /// </value>
    public bool IsEmpty => Count == 0;

    /// <summary>
    ///     Converts from a standard .NET queue.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <returns>An IX Framework abstracted queue.</returns>
    public static Queue<T> FromQueue(GlobalCollectionsGeneric.Queue<T> source) =>
        new(
            Requires.NotNull(
                    source,
                    nameof(source))
                .ToArray());

    /// <summary>
    ///     Queues a range of elements, adding them to the queue.
    /// </summary>
    /// <param name="items">The item range to push.</param>
    /// <exception cref="ArgumentNullException">
    ///     items
    ///     is <c>null</c> (<c>Nothing</c> in Visual Basic).
    /// </exception>
    public void EnqueueRange(T[] items)
    {
        foreach (T item in Requires.NotNull(
                     items,
                     nameof(items)))
        {
            Enqueue(item);
        }
    }

    /// <summary>
    ///     Queues a range of elements, adding them to the queue.
    /// </summary>
    /// <param name="items">The item range to enqueue.</param>
    /// <param name="startIndex">The start index.</param>
    /// <param name="count">The number of items to enqueue.</param>
    /// <exception cref="ArgumentNullException">
    ///     items
    ///     is <c>null</c> (<c>Nothing</c> in Visual Basic).
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="startIndex" />
    ///     or
    ///     <paramref name="count" />
    ///     represent an out-of-range set of arguments relative to the input array.
    /// </exception>
    public void EnqueueRange(
        T[] items,
        int startIndex,
        int count)
    {
        Requires.ValidArrayRange(
            in startIndex,
            in count,
            items,
            nameof(startIndex));

        var innerArray = new T[count];
        Array.Copy(
            items,
            startIndex,
            innerArray,
            0,
            count);

        foreach (T item in items)
        {
            Enqueue(item);
        }
    }

    #if !FRAMEWORK_ADVANCED
    /// <summary>
    ///     Attempts to de-queue an item and to remove it from queue.
    /// </summary>
    /// <param name="item">The item that has been de-queued, default if unsuccessful.</param>
    /// <returns>
    ///     <see langword="true" /> if an item is de-queued successfully, <see langword="false" /> otherwise, or if the
    ///     queue is empty.
    /// </returns>
    public bool TryDequeue([MaybeNullWhen(false)] out T item)
    {
        if (Count == 0)
        {
            item = default;
            return false;
        }

        item = Dequeue();
        return true;
    }

    /// <summary>
    ///     Attempts to peek at the current queue and return the item that is next in line to be dequeued.
    /// </summary>
    /// <param name="item">The item, or default if unsuccessful.</param>
    /// <returns><see langword="true" /> if an item is found, <see langword="false" /> otherwise, or if the queue is empty.</returns>
    public bool TryPeek([MaybeNullWhen(false)] out T item)
    {
        if (Count == 0)
        {
            item = default;
            return false;
        }

        item = Peek();
        return true;
    }
    #endif
}