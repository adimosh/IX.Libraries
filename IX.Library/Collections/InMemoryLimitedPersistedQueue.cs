using IX.Library.ComponentModel;
using IX.Library.IO;

using System.Diagnostics.CodeAnalysis;

namespace IX.Library.Collections;

/// <summary>
///     A queue that guarantees delivery within disaster recovery scenarios.
/// </summary>
/// <typeparam name="T">The type of object in the queue.</typeparam>
/// <seealso cref="DisposableBase" />
/// <seealso cref="IX.Library.Collections.IQueue{T}" />
[PublicAPI]
[SuppressMessage(
    "Design",
    "CA1010:Generic interface should also be implemented",
    Justification = "This is mostly useless.")]
public class InMemoryLimitedPersistedQueue<T> : PersistedQueueBase<T>
{
    private readonly Queue<string> _internalQueue;

    /// <summary>
    ///     Initializes a new instance of the <see cref="IX.Library.Collections.InMemoryLimitedPersistedQueue{T}" /> class.
    /// </summary>
    /// <param name="persistenceFolderPath">The persistence folder path.</param>
    /// <param name="fileShim">The file shim.</param>
    /// <param name="directoryShim">The directory shim.</param>
    /// <param name="pathShim">The path shim.</param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="persistenceFolderPath" />
    ///     or
    ///     <paramref name="fileShim" />
    ///     or
    ///     <paramref name="directoryShim" />
    ///     or
    ///     <paramref name="pathShim" />
    ///     is <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    /// <exception cref="ArgumentInvalidPathException">
    ///     The folder at <paramref name="persistenceFolderPath" /> does not exist,
    ///     or is not accessible.
    /// </exception>
    [SuppressMessage(
        "Performance",
        "HAA0401:Possible allocation of reference type enumerator",
        Justification = "This allocation is not a problem here.")]
    public InMemoryLimitedPersistedQueue(
        string persistenceFolderPath,
        IFile fileShim,
        IDirectory directoryShim,
        IPath pathShim)
        : base(
            persistenceFolderPath,
            fileShim,
            directoryShim,
            pathShim,
            new(typeof(T)),
            EnvironmentSettings.PersistedCollectionsLockTimeout)
    {
        // Internal state
        _internalQueue = new();

        // Initialize objects
        foreach (Tuple<T, string> item in LoadValidItemObjectHandles())
        {
            _internalQueue.Enqueue(item.Item2);
        }

        GC.Collect();
    }

    /// <summary>
    ///     Gets the number of elements contained in the persisted queue.
    /// </summary>
    /// <value>The count.</value>
    /// <remarks>
    ///     <para>
    ///         This property is not synchronized in any way, and therefore might not reflect the true count, should there be
    ///         many threads accessing it in parallel.
    ///     </para>
    /// </remarks>
    public override int Count =>
        InvokeIfNotDisposed(
            reference => reference.ReadLock(
                referenceL2 => referenceL2._internalQueue.Count,
                reference),
            this);

    /// <summary>
    ///     Clears the queue of all elements.
    /// </summary>
    public override void Clear()
    {
        _internalQueue.Clear();
        ClearData();
    }

    /// <summary>
    ///     This method should not be called, as it will always throw an <see cref="InvalidOperationException" />.
    /// </summary>
    /// <param name="item">The item to verify.</param>
    /// <returns><see langword="true" /> if the item is queued, <see langword="false" /> otherwise.</returns>
    public override bool Contains(T item) =>
        throw new InvalidOperationException(Resources.ErrorPersistedQueuesCannotBeCopied);

    /// <summary>
    ///     This method should not be called, as it will always throw an <see cref="InvalidOperationException" />.
    /// </summary>
    /// <param name="array">
    ///     The one-dimensional <see cref="T:System.Array" /> that is the destination of the elements copied
    ///     from <see cref="IX.Library.Collections.PersistedQueue{T}" />. The <see cref="T:System.Array" /> must have zero-based indexing.
    /// </param>
    /// <param name="index">The zero-based index in <paramref name="array" /> at which copying begins.</param>
    public override void CopyTo(
        Array array,
        int index) =>
        throw new InvalidOperationException(Resources.ErrorPersistedQueuesCannotBeCopied);

    /// <summary>
    ///     De-queues an item and removes it from the queue.
    /// </summary>
    /// <returns>The item that has been dequeued.</returns>
    public override T Dequeue()
    {
        var success = true;

        try
        {
            return LoadTopmostItem();
        }
        catch (Exception)
        {
            success = false;

            throw;
        }
        finally
        {
            if (success)
            {
                _ = _internalQueue.Dequeue();
            }
        }
    }

    /// <summary>
    ///     Attempts to de-queue an item and to remove it from queue.
    /// </summary>
    /// <param name="item">The item that has been de-queued, default if unsuccessful.</param>
    /// <returns>
    ///     <see langword="true" /> if an item is de-queued successfully, <see langword="false" /> otherwise, or if the
    ///     queue is empty.
    /// </returns>
    [SuppressMessage(
        "CodeSmell",
        "ERP022:Unobserved exception in generic exception handler",
        Justification = "There are a number of exceptions that can flow and are uncontrollable.")]
    public override bool TryDequeue(out T item)
    {
        try
        {
            item = LoadTopmostItem();
        }
        catch (Exception)
        {
            item = default!;

            return false;
        }

        _ = _internalQueue.Dequeue();

        return true;
    }

    /// <summary>
    ///     Tries the load topmost item and execute an action on it, deleting the topmost object data if the operation is
    ///     successful.
    /// </summary>
    /// <typeparam name="TState">The type of the state object to send to the action.</typeparam>
    /// <param name="predicate">The predicate.</param>
    /// <param name="actionToInvoke">The action to invoke.</param>
    /// <param name="state">The state object to pass to the invoked action.</param>
    /// <returns>The number of items that have been dequeued.</returns>
    /// <remarks>
    ///     <para>
    ///         Warning! This method has the potential of overrunning its read/write lock timeouts. Please ensure that the
    ///         <paramref name="predicate" /> method
    ///         filters out items in a way that limits the amount of data passing through.
    ///     </para>
    /// </remarks>
    public int DequeueWhilePredicateWithAction<TState>(
        Func<TState, T, bool> predicate,
        Action<TState, IEnumerable<T>> actionToInvoke,
        TState state)
    {
        var success = 0;

        try
        {
            success = TryLoadWhilePredicateWithAction(
                predicate,
                actionToInvoke,
                state);
        }
        catch (Exception)
        {
            success = 0;

            throw;
        }
        finally
        {
            for (var i = 0; i < success; i++)
            {
                _ = _internalQueue.Dequeue();
            }
        }

        return success;
    }

    /// <summary>
    ///     De-queues an item from the queue, and executes the specified action on it.
    /// </summary>
    /// <typeparam name="TState">The type of the state object to pass to the action.</typeparam>
    /// <param name="actionToInvoke">The action to invoke.</param>
    /// <param name="state">The state object to pass to the action.</param>
    /// <returns>
    ///     <see langword="true" /> if the dequeuing is successful, and the action performed, <see langword="false" />
    ///     otherwise.
    /// </returns>
    public bool DequeueWithAction<TState>(
        Action<TState, T> actionToInvoke,
        TState state)
    {
        var success = true;

        try
        {
            success = TryLoadTopmostItemWithAction(
                actionToInvoke,
                state);
        }
        catch (Exception)
        {
            success = false;

            throw;
        }
        finally
        {
            if (success)
            {
                _ = _internalQueue.Dequeue();
            }
        }

        return success;
    }

    /// <summary>
    ///     Enqueues an item, adding it to the queue.
    /// </summary>
    /// <param name="item">The item to enqueue.</param>
    public override void Enqueue(T item)
    {
        var filePath = SaveNewItem(item);

        _internalQueue.Enqueue(filePath);
    }

    /// <summary>
    ///     This method should not be called, as it will always throw an <see cref="InvalidOperationException" />.
    /// </summary>
    /// <returns>An enumerator that can be used to iterate through the collection.</returns>
    public override IEnumerator<T> GetEnumerator() =>
        throw new InvalidOperationException(Resources.ErrorPersistedQueuesCannotBeEnumerated);

    /// <summary>
    ///     Peeks at the topmost element in the queue, without removing it.
    /// </summary>
    /// <returns>The item peeked at, if any.</returns>
    public override T Peek() =>
        PeekTopmostItem();

    /// <summary>
    ///     This method should not be called, as it will always throw an <see cref="InvalidOperationException" />.
    /// </summary>
    /// <returns>The created array with all element of the queue.</returns>
    public override T[] ToArray() =>
        throw new InvalidOperationException(Resources.ErrorPersistedQueuesCannotBeCopied);

    /// <summary>
    ///     Trims the excess free space from within the queue, reducing the capacity to the actual number of elements.
    /// </summary>
    public override void TrimExcess() =>
        _internalQueue.TrimExcess();

    /// <summary>
    ///     Attempts to peek at the current queue and return the item that is next in line to be dequeued.
    /// </summary>
    /// <param name="item">The item, or default if unsuccessful.</param>
    /// <returns>
    ///     <see langword="true" /> if an item is found, <see langword="false" /> otherwise, or if the queue is empty.
    /// </returns>
    public override bool TryPeek(out T item) =>
        TryPeekTopmostItem(out item);
}