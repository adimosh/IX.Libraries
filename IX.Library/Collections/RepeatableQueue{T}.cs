using IX.Library.Contracts;

using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace IX.Library.Collections;

/// <summary>
///     A queue that is able to accurately repeat the sequence of items that has been dequeued from it.
/// </summary>
/// <typeparam name="T">The type of items contained in this queue.</typeparam>
/// <seealso cref="IX.Library.Collections.IQueue{T}" />
[PublicAPI]
[SuppressMessage(
    "Design",
    "CA1010:Generic interface should also be implemented",
    Justification = "This is not necessary.")]
public class RepeatableQueue<T> : IQueue<T>
{
    private readonly IQueue<T> _internalQueue;
    private readonly IQueue<T> _internalRepeatingQueue;

    /// <summary>
    ///     Initializes a new instance of the <see cref="IX.Library.Collections.RepeatableQueue{T}" /> class.
    /// </summary>
    public RepeatableQueue()
    {
        _internalQueue = new Queue<T>();
        _internalRepeatingQueue = new Queue<T>();
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="IX.Library.Collections.RepeatableQueue{T}" /> class.
    /// </summary>
    /// <param name="originalQueue">The original queue.</param>
    public RepeatableQueue(IQueue<T> originalQueue)
    {
        Requires.NotNull(
            out _internalQueue,
            originalQueue,
            nameof(originalQueue));
        _internalRepeatingQueue = new Queue<T>();
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="IX.Library.Collections.RepeatableQueue{T}" /> class.
    /// </summary>
    /// <param name="originalData">The original data.</param>
    public RepeatableQueue(IEnumerable<T> originalData)
    {
        _ = Requires.NotNull(
            originalData,
            nameof(originalData));

        _internalQueue = new Queue<T>(originalData);
        _internalRepeatingQueue = new Queue<T>();
    }

    /// <summary>Gets the number of elements in the collection.</summary>
    /// <returns>The number of elements in the collection. </returns>
    public int Count => ((IReadOnlyCollection<T>)_internalQueue).Count;

    /// <summary>
    ///     Gets a value indicating whether this queue is empty.
    /// </summary>
    /// <value>
    ///     <c>true</c> if this queue is empty; otherwise, <c>false</c>.
    /// </value>
    public bool IsEmpty => Count == 0;

    /// <summary>Gets the number of elements contained in the <see cref="ICollection" />.</summary>
    /// <returns>The number of elements contained in the <see cref="ICollection" />.</returns>
    int ICollection.Count => Count;

    /// <summary>
    ///     Gets a value indicating whether access to the <see cref="ICollection" /> is synchronized
    ///     (thread safe).
    /// </summary>
    /// <returns>
    ///     <see langword="true" /> if access to the <see cref="ICollection" /> is synchronized (thread
    ///     safe); otherwise, <see langword="false" />.
    /// </returns>
    bool ICollection.IsSynchronized => _internalQueue.IsSynchronized;

    /// <summary>Gets an object that can be used to synchronize access to the <see cref="ICollection" />.</summary>
    /// <returns>An object that can be used to synchronize access to the <see cref="ICollection" />.</returns>
    object ICollection.SyncRoot => _internalQueue.SyncRoot;

    /// <summary>
    ///     Copies the elements of the <see cref="IX.Library.Collections.RepeatableQueue{T}" /> to an <see cref="Array" />, starting at
    ///     a particular <see cref="Array" /> index.
    /// </summary>
    /// <param name="array">
    ///     The one-dimensional <see cref="Array" /> that is the destination of the elements copied
    ///     from <see cref="IX.Library.Collections.RepeatableQueue{T}" />. The <see cref="Array" /> must have zero-based indexing.
    /// </param>
    /// <param name="index">The zero-based index in <paramref name="array" /> at which copying begins. </param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="array" /> is <see langword="null" />.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="index" /> is less than zero.
    /// </exception>
    /// <exception cref="ArgumentException">
    ///     <paramref name="array" /> is multidimensional.-or- The number of elements in the source
    ///     <see cref="IX.Library.Collections.RepeatableQueue{T}" /> is greater than the available space from <paramref name="index" /> to the end of
    ///     the destination <paramref name="array" />.-or-The type of the source <see cref="IX.Library.Collections.RepeatableQueue{T}" /> cannot be
    ///     cast automatically to the type of the destination <paramref name="array" />.
    /// </exception>
    public void CopyTo(
        Array array,
        int index) =>
        _internalQueue.CopyTo(
            array,
            index);

    /// <summary>Returns an enumerator that iterates through the collection.</summary>
    /// <returns>An enumerator that can be used to iterate through the collection.</returns>
    [SuppressMessage(
        "Performance",
        "HAA0401:Possible allocation of reference type enumerator",
        Justification = "Unavoidable.")]
    public IEnumerator<T> GetEnumerator() => _internalQueue.GetEnumerator();

    /// <summary>
    ///     Clears the queue of all elements.
    /// </summary>
    public void Clear()
    {
        _internalQueue.Clear();
        _internalRepeatingQueue.Clear();
    }

    /// <summary>
    ///     Verifies whether or not an item is contained in the queue.
    /// </summary>
    /// <param name="item">The item to verify.</param>
    /// <returns><see langword="true" /> if the item is queued, <see langword="false" /> otherwise.</returns>
    public bool Contains(T item) => _internalQueue.Contains(item);

    /// <summary>
    ///     De-queues an item and removes it from the queue.
    /// </summary>
    /// <returns>The item that has been de-queued.</returns>
    public T Dequeue()
    {
        T dequeuedItem = _internalQueue.Dequeue();
        _internalRepeatingQueue.Enqueue(dequeuedItem);

        return dequeuedItem;
    }

    /// <summary>
    ///     Queues an item, adding it to the queue.
    /// </summary>
    /// <param name="item">The item to enqueue.</param>
    public void Enqueue(T item) => _internalQueue.Enqueue(item);

    /// <summary>
    ///     Queues a range of elements, adding them to the queue.
    /// </summary>
    /// <param name="items">The item range to push.</param>
    public void EnqueueRange(T[] items) => _internalQueue.EnqueueRange(items);

    /// <summary>
    ///     Queues a range of elements, adding them to the queue.
    /// </summary>
    /// <param name="items">The item range to enqueue.</param>
    /// <param name="startIndex">The start index.</param>
    /// <param name="count">The number of items to enqueue.</param>
    public void EnqueueRange(
        T[] items,
        int startIndex,
        int count) =>
        _internalQueue.EnqueueRange(
            items,
            startIndex,
            count);

    /// <summary>
    ///     Peeks at the topmost element in the queue, without removing it.
    /// </summary>
    /// <returns>The item peeked at, if any.</returns>
    public T Peek() => _internalQueue.Peek();

    /// <summary>
    ///     Copies all elements of the queue into a new array.
    /// </summary>
    /// <returns>The created array with all element of the queue.</returns>
    public T[] ToArray() => _internalQueue.ToArray();

    /// <summary>
    ///     Trims the excess free space from within the queue, reducing the capacity to the actual number of elements.
    /// </summary>
    public void TrimExcess() => _internalQueue.TrimExcess();

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
        if (!_internalQueue.TryDequeue(out item))
        {
            return false;
        }

        _internalRepeatingQueue.Enqueue(item);

        return true;
    }

    /// <summary>
    ///     Attempts to peek at the current queue and return the item that is next in line to be dequeued.
    /// </summary>
    /// <param name="item">The item, or default if unsuccessful.</param>
    /// <returns>
    ///     <see langword="true" /> if an item is found, <see langword="false" /> otherwise, or if the queue is empty.
    /// </returns>
    public bool TryPeek([MaybeNullWhen(false)] out T item) => _internalQueue.TryPeek(out item);

    /// <summary>Returns an enumerator that iterates through a collection.</summary>
    /// <returns>An <see cref="IEnumerator" /> object that can be used to iterate through the collection.</returns>
    [SuppressMessage(
        "Performance",
        "HAA0401:Possible allocation of reference type enumerator",
        Justification = "Unavoidable.")]
    [ExcludeFromCodeCoverage]
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    /// <summary>
    ///     Gets a repeat of the sequence of elements dequeued from this instance.
    /// </summary>
    /// <returns>A repeating queue.</returns>
    public IQueue<T> Repeat() => new Queue<T>(_internalRepeatingQueue.ToArray());
}