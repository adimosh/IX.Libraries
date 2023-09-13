using IX.Library.IO;

using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace IX.Library.Collections;

/// <summary>
///     A queue used in situations where a regular in-memory queue would be used, except in disaster conditions, where the
///     queue becomes persisted.
/// </summary>
/// <typeparam name="T">The type of items in the queue.</typeparam>
/// <remarks>
///     <para>
///         Please be advised that the disaster and recovery scenarios that this queue can handle are all
///         application-level error conditions.
///     </para>
///     <para>This queue cannot handle system faults, such as a power outage or a general operating system failure.</para>
///     <para>
///         If you need those types of errors also handled, and you need data persistence across those as well, please
///         use <see cref="IX.Library.Collections.PersistedQueue{T}" /> instead.
///     </para>
/// </remarks>
/// <seealso cref="ReaderWriterSynchronizedBase" />
/// <seealso cref="IX.Library.Collections.IPersistedQueue{T}" />
[PublicAPI]
public class DisasterRecoveryPersistedQueue<T> : ReaderWriterSynchronizedBase,
    IPersistedQueue<T>
{
    private readonly object _syncRoot = new();

    private readonly IDirectory _directoryShim;
    private readonly IFile _fileShim;
    private readonly IPath _pathShim;
    private readonly string _persistenceFolderPath;

    private int _isInDisasterMode;
    private PersistedQueue<T>? _persistedQueue;
    private Queue<T>? _queue;

    /// <summary>
    ///     Initializes a new instance of the <see cref="IX.Library.Collections.DisasterRecoveryPersistedQueue{T}" /> class.
    /// </summary>
    /// <param name="persistenceFolderPath">
    ///     The persistence folder path. The path must evaluate to an existing and accessible path.
    /// </param>
    /// <param name="fileShim">
    ///     The file shim.
    /// </param>
    /// <param name="directoryShim">
    ///     The folder shim.
    /// </param>
    /// <param name="pathShim">
    ///     The path shim.
    /// </param>
    public DisasterRecoveryPersistedQueue(
        string persistenceFolderPath,
        IFile fileShim,
        IDirectory directoryShim,
        IPath pathShim)
        : base(Timeout.InfiniteTimeSpan)
    {
        // External state
        Requires.NotNullOrWhiteSpace(
            out _persistenceFolderPath,
            persistenceFolderPath);

        // Dependencies
        Requires.NotNull(
            out _fileShim,
            fileShim);
        Requires.NotNull(
            out _directoryShim,
            directoryShim);
        Requires.NotNull(
            out _pathShim,
            pathShim);

        // Automatic disaster detection logic
        AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;

        // Initialize queues
        _queue = new();

        using var existingQueue = new PersistedQueue<T>(
            persistenceFolderPath,
            Timeout.InfiniteTimeSpan,
            fileShim,
            directoryShim,
            pathShim);

        while (existingQueue.TryDequeue(out T transferItem))
        {
            _queue.Enqueue(transferItem);
        }
    }

    /// <summary>
    ///     Gets the number of elements contained in the <see cref="ICollection" />.
    /// </summary>
    /// <exception cref="InvalidOperationException">
    ///     The queue is currently in disaster mode, enumeration operations are
    ///     disabled by design.
    /// </exception>
    public int Count
    {
        get
        {
            using (AcquireReadLock())
            {
                if (_isInDisasterMode != 0)
                {
                    throw new InvalidOperationException(Resources.ErrorTheQueueIsCurrentlyInDisasterMode);
                }

                return _queue!.Count;
            }
        }
    }

    /// <summary>
    ///     Gets a value indicating whether this queue is empty.
    /// </summary>
    /// <value>
    ///     <c>true</c> if this queue is empty; otherwise, <c>false</c>.
    /// </value>
    public bool IsEmpty =>
        Count == 0;

    /// <summary>
    ///     Gets the current items count from the queue.
    /// </summary>
    int ICollection.Count =>
        Count;

    /// <summary>
    ///     Gets a value indicating whether this queue is synchronized.
    /// </summary>
    bool ICollection.IsSynchronized =>
        true;

    /// <summary>
    ///     Gets the sync root.
    /// </summary>
    [SuppressMessage(
        "ReSharper",
        "ConvertToAutoProperty",
        Justification = "We're doing this because of an analyzer error.")]
    object ICollection.SyncRoot => _syncRoot;

    /// <summary>
    ///     Copies the elements of the <see cref="ICollection" /> to an <see cref="Array" />,
    ///     starting at a particular <see cref="Array" /> index.
    /// </summary>
    /// <param name="array">
    ///     The one-dimensional <see cref="Array" /> that is the destination of the elements copied
    ///     from <see cref="ICollection" />. The <see cref="Array" /> must have zero-based
    ///     indexing.
    /// </param>
    /// <param name="index">The zero-based index in <paramref name="array" /> at which copying begins.</param>
    /// <exception cref="InvalidOperationException">
    ///     The queue is currently in disaster mode, enumeration operations are
    ///     disabled by design.
    /// </exception>
    public void CopyTo(
        Array array,
        int index)
    {
        _ = Requires.NotNull(
            array);
        Requires.NonNegative(
            index);

        using (AcquireReadLock())
        {
            if (_isInDisasterMode == 0)
            {
                // Not in disaster mode
                ((ICollection)_queue!).CopyTo(
                    array,
                    index);
            }
            else
            {
                // Disaster mode - enumeration disabled
                throw new InvalidOperationException(Resources.ErrorTheQueueIsCurrentlyInDisasterMode);
            }
        }
    }

    /// <summary>
    ///     Returns an enumerator that iterates through the collection.
    /// </summary>
    /// <returns>
    ///     An enumerator that can be used to iterate through the collection.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    ///     The queue is currently in disaster mode, enumeration operations are
    ///     disabled by design.
    /// </exception>
    [SuppressMessage(
        "Performance",
        "HAA0401:Possible allocation of reference type enumerator",
        Justification = "We know it's a reference type, because it's a class enumerator.")]
    [SuppressMessage(
        "Performance",
        "HAA0603:Delegate allocation from a method group",
        Justification = "Atomic enumerator expects a delegate instance.")]
    public IEnumerator<T> GetEnumerator()
    {
        using (AcquireReadLock())
        {
            if (_isInDisasterMode == 0)
            {
                // Not in disaster mode - we can spawn an atomic enumerator
                return AtomicEnumerator<T>.FromCollection(
                    _queue!,
                    AcquireReadLock);
            }

            // Disaster mode - enumeration disabled
            throw new InvalidOperationException(Resources.ErrorTheQueueIsCurrentlyInDisasterMode);
        }
    }

    /// <summary>
    ///     Tries to load the topmost item and execute an action on it, deleting the topmost object data if the operation is
    ///     successful.
    /// </summary>
    /// <typeparam name="TState">The type of the state object to send to the action.</typeparam>
    /// <param name="predicate">The predicate.</param>
    /// <param name="actionToInvoke">The action to invoke.</param>
    /// <param name="state">The state object to pass to the invoked action.</param>
    /// <returns>
    ///     The number of items that have been de-queued.
    /// </returns>
    /// <remarks>
    ///     Warning! This method has the potential of overrunning its read/write lock timeouts. Please ensure that the
    ///     <paramref name="predicate" /> method filters out items in a way that limits the amount of data passing through.
    /// </remarks>
    public int DequeueWhilePredicateWithAction<TState>(
        Func<TState, T, bool> predicate,
        Action<TState, IEnumerable<T>> actionToInvoke,
        TState state)
    {
        _ = Requires.NotNull(
            predicate);
        _ = Requires.NotNull(
            actionToInvoke);

        using (AcquireWriteLock())
        {
            if (_isInDisasterMode != 0)
            {
                // Disaster mode
                return _persistedQueue!.DequeueWhilePredicateWithAction(
                    predicate,
                    actionToInvoke,
                    state);
            }

            // Normal mode
            if (_queue!.Count == 0)
            {
                return 0;
            }

            if (!predicate(
                    state,
                    _queue.Peek()))
            {
                return 0;
            }

            var index = 1;
            T[] items = _queue.ToArray();
            for (; index < items.Length; index++)
            {
                if (!predicate(
                        state,
                        items[index]))
                {
                    break;
                }
            }

            try
            {
                actionToInvoke(
                    state,
                    items.Take(index));
            }
            catch (Exception)
            {
                return 0;
            }

            for (var i = 0; i < index; i++)
            {
                _ = _queue.Dequeue();
            }

            return index;
        }
    }

    /// <summary>
    ///     Tries asynchronously to load the topmost item and execute an action on it, deleting the topmost object data if the
    ///     operation is successful.
    /// </summary>
    /// <typeparam name="TState">The type of the state object to send to the action.</typeparam>
    /// <param name="predicate">The predicate.</param>
    /// <param name="actionToInvoke">The action to invoke.</param>
    /// <param name="state">The state object to pass to the invoked action.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The number of items that have been dequeued.</returns>
    /// <remarks>
    ///     <para>
    ///         Warning! This method has the potential of overrunning its read/write lock timeouts. Please ensure that the
    ///         <paramref name="predicate" /> method
    ///         filters out items in a way that limits the amount of data passing through.
    ///     </para>
    /// </remarks>
    public async ValueTask<int> DequeueWhilePredicateWithActionAsync<TState>(
        Func<TState, T, bool> predicate,
        Action<TState, IEnumerable<T>> actionToInvoke,
        TState state,
        CancellationToken cancellationToken = default)
    {
        _ = Requires.NotNull(
            predicate);
        _ = Requires.NotNull(
            actionToInvoke);

        using (AcquireWriteLock())
        {
            if (_isInDisasterMode != 0)
            {
                // Disaster mode
                return await _persistedQueue!.DequeueWhilePredicateWithActionAsync(
                        predicate,
                        actionToInvoke,
                        state,
                        cancellationToken)
                    .ConfigureAwait(false);
            }

            await Task.Yield();

            // Normal mode
            if (_queue!.Count == 0)
            {
                return 0;
            }

            if (!predicate(
                    state,
                    _queue.Peek()))
            {
                return 0;
            }

            var index = 1;
            T[] items = _queue.ToArray();
            for (; index < items.Length; index++)
            {
                if (!predicate(
                        state,
                        items[index]))
                {
                    break;
                }
            }

            try
            {
                actionToInvoke(
                    state,
                    items.Take(index));
            }
            catch (Exception)
            {
                return 0;
            }

            for (var i = 0; i < index; i++)
            {
                _ = _queue.Dequeue();
            }

            return index;
        }
    }

    /// <summary>
    ///     Tries asynchronously to load the topmost item and execute an action on it, deleting the topmost object data if the
    ///     operation is successful.
    /// </summary>
    /// <typeparam name="TState">The type of the state object to send to the action.</typeparam>
    /// <param name="predicate">The predicate.</param>
    /// <param name="actionToInvoke">The action to invoke.</param>
    /// <param name="state">The state object to pass to the invoked action.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The number of items that have been dequeued.</returns>
    /// <remarks>
    ///     <para>
    ///         Warning! This method has the potential of overrunning its read/write lock timeouts. Please ensure that the
    ///         <paramref name="predicate" /> method
    ///         filters out items in a way that limits the amount of data passing through.
    ///     </para>
    /// </remarks>
    [SuppressMessage(
        "Performance",
        "HAA0603:Delegate allocation from a method group",
        Justification = "Acceptable - we're doing a lot of allocation in the Task method anyway.")]
    public ValueTask<int> DequeueWhilePredicateWithActionAsync<TState>(
        Func<TState, T, Task<bool>> predicate,
        Action<TState, IEnumerable<T>> actionToInvoke,
        TState state,
        CancellationToken cancellationToken = default)
    {
        return DequeueWhilePredicateWithActionAsync(
            InvokePredicateLocal,
            actionToInvoke,
            state,
            cancellationToken);

        async ValueTask<bool> InvokePredicateLocal(
            TState stateInternal,
            T obj) =>
            await predicate(
                stateInternal,
                obj);
    }

    /// <summary>
    ///     Tries asynchronously to load the topmost item and execute an action on it, deleting the topmost object data if the
    ///     operation is successful.
    /// </summary>
    /// <typeparam name="TState">The type of the state object to send to the action.</typeparam>
    /// <param name="predicate">The predicate.</param>
    /// <param name="actionToInvoke">The action to invoke.</param>
    /// <param name="state">The state object to pass to the invoked action.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The number of items that have been dequeued.</returns>
    /// <remarks>
    ///     <para>
    ///         Warning! This method has the potential of overrunning its read/write lock timeouts. Please ensure that the
    ///         <paramref name="predicate" /> method
    ///         filters out items in a way that limits the amount of data passing through.
    ///     </para>
    /// </remarks>
    public async ValueTask<int> DequeueWhilePredicateWithActionAsync<TState>(
        Func<TState, T, ValueTask<bool>> predicate,
        Action<TState, IEnumerable<T>> actionToInvoke,
        TState state,
        CancellationToken cancellationToken = default)
    {
        _ = Requires.NotNull(
            predicate);
        _ = Requires.NotNull(
            actionToInvoke);

        using (AcquireWriteLock())
        {
            if (_isInDisasterMode != 0)
            {
                // Disaster mode
                return await _persistedQueue!.DequeueWhilePredicateWithActionAsync(
                        predicate,
                        actionToInvoke,
                        state,
                        cancellationToken)
                    .ConfigureAwait(false);
            }

            // Normal mode
            if (_queue!.Count == 0)
            {
                return 0;
            }

            if (!await predicate(
                        state,
                        _queue.Peek())
                    .ConfigureAwait(false))
            {
                return 0;
            }

            var index = 1;
            T[] items = _queue.ToArray();
            for (; index < items.Length; index++)
            {
                if (!await predicate(
                            state,
                            items[index])
                        .ConfigureAwait(false))
                {
                    break;
                }
            }

            try
            {
                actionToInvoke(
                    state,
                    items.Take(index));
            }
            catch (Exception)
            {
                return 0;
            }

            for (var i = 0; i < index; i++)
            {
                _ = _queue.Dequeue();
            }

            return index;
        }
    }

    /// <summary>
    ///     Tries asynchronously to load the topmost item and execute an action on it, deleting the topmost object data if the
    ///     operation is successful.
    /// </summary>
    /// <typeparam name="TState">The type of the state object to send to the action.</typeparam>
    /// <param name="predicate">The predicate.</param>
    /// <param name="actionToInvoke">The action to invoke.</param>
    /// <param name="state">The state object to pass to the invoked action.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The number of items that have been dequeued.</returns>
    /// <remarks>
    ///     <para>
    ///         Warning! This method has the potential of overrunning its read/write lock timeouts. Please ensure that the
    ///         <paramref name="predicate" /> method
    ///         filters out items in a way that limits the amount of data passing through.
    ///     </para>
    /// </remarks>
    [SuppressMessage(
        "Performance",
        "HAA0603:Delegate allocation from a method group",
        Justification = "Acceptable - we're doing a lot of allocation in the Task method anyway.")]
    public ValueTask<int> DequeueWhilePredicateWithActionAsync<TState>(
        Func<TState, T, bool> predicate,
        Func<TState, IEnumerable<T>, Task> actionToInvoke,
        TState state,
        CancellationToken cancellationToken = default)
    {
        return DequeueWhilePredicateWithActionAsync(
            predicate,
            InvokeActionLocal,
            state,
            cancellationToken);

        async ValueTask InvokeActionLocal(
            TState stateInternal,
            IEnumerable<T> obj) =>
            await actionToInvoke(
                stateInternal,
                obj);
    }

    /// <summary>
    ///     Tries asynchronously to load the topmost item and execute an action on it, deleting the topmost object data if the
    ///     operation is successful.
    /// </summary>
    /// <typeparam name="TState">The type of the state object to send to the action.</typeparam>
    /// <param name="predicate">The predicate.</param>
    /// <param name="actionToInvoke">The action to invoke.</param>
    /// <param name="state">The state object to pass to the invoked action.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The number of items that have been dequeued.</returns>
    /// <remarks>
    ///     <para>
    ///         Warning! This method has the potential of overrunning its read/write lock timeouts. Please ensure that the
    ///         <paramref name="predicate" /> method
    ///         filters out items in a way that limits the amount of data passing through.
    ///     </para>
    /// </remarks>
    public async ValueTask<int> DequeueWhilePredicateWithActionAsync<TState>(
        Func<TState, T, bool> predicate,
        Func<TState, IEnumerable<T>, ValueTask> actionToInvoke,
        TState state,
        CancellationToken cancellationToken = default)
    {
        _ = Requires.NotNull(
            predicate);
        _ = Requires.NotNull(
            actionToInvoke);

        using (AcquireWriteLock())
        {
            if (_isInDisasterMode != 0)
            {
                // Disaster mode
                return await _persistedQueue!.DequeueWhilePredicateWithActionAsync(
                        predicate,
                        actionToInvoke,
                        state,
                        cancellationToken)
                    .ConfigureAwait(false);
            }

            await Task.Yield();

            // Normal mode
            if (_queue!.Count == 0)
            {
                return 0;
            }

            if (!predicate(
                    state,
                    _queue.Peek()))
            {
                return 0;
            }

            var index = 1;
            T[] items = _queue.ToArray();
            for (; index < items.Length; index++)
            {
                if (!predicate(
                        state,
                        items[index]))
                {
                    break;
                }
            }

            try
            {
                await actionToInvoke(
                        state,
                        items.Take(index))
                    .ConfigureAwait(false);
            }
            catch (Exception)
            {
                return 0;
            }

            for (var i = 0; i < index; i++)
            {
                _ = _queue.Dequeue();
            }

            return index;
        }
    }

    /// <summary>
    ///     Tries asynchronously to load the topmost item and execute an action on it, deleting the topmost object data if the
    ///     operation is successful.
    /// </summary>
    /// <typeparam name="TState">The type of the state object to send to the action.</typeparam>
    /// <param name="predicate">The predicate.</param>
    /// <param name="actionToInvoke">The action to invoke.</param>
    /// <param name="state">The state object to pass to the invoked action.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The number of items that have been dequeued.</returns>
    /// <remarks>
    ///     <para>
    ///         Warning! This method has the potential of overrunning its read/write lock timeouts. Please ensure that the
    ///         <paramref name="predicate" /> method
    ///         filters out items in a way that limits the amount of data passing through.
    ///     </para>
    /// </remarks>
    [SuppressMessage(
        "Performance",
        "HAA0603:Delegate allocation from a method group",
        Justification = "Acceptable - we're doing a lot of allocation in the Task method anyway.")]
    public ValueTask<int> DequeueWhilePredicateWithActionAsync<TState>(
        Func<TState, T, Task<bool>> predicate,
        Func<TState, IEnumerable<T>, Task> actionToInvoke,
        TState state,
        CancellationToken cancellationToken = default)
    {
        return DequeueWhilePredicateWithActionAsync(
            InvokePredicateLocal,
            InvokeActionLocal,
            state,
            cancellationToken);

        async ValueTask<bool> InvokePredicateLocal(
            TState stateInternal,
            T obj) =>
            await predicate(
                stateInternal,
                obj);

        async ValueTask InvokeActionLocal(
            TState stateInternal,
            IEnumerable<T> obj) =>
            await actionToInvoke(
                stateInternal,
                obj);
    }

    /// <summary>
    ///     Tries asynchronously to load the topmost item and execute an action on it, deleting the topmost object data if the
    ///     operation is successful.
    /// </summary>
    /// <typeparam name="TState">The type of the state object to send to the action.</typeparam>
    /// <param name="predicate">The predicate.</param>
    /// <param name="actionToInvoke">The action to invoke.</param>
    /// <param name="state">The state object to pass to the invoked action.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The number of items that have been dequeued.</returns>
    /// <remarks>
    ///     <para>
    ///         Warning! This method has the potential of overrunning its read/write lock timeouts. Please ensure that the
    ///         <paramref name="predicate" /> method
    ///         filters out items in a way that limits the amount of data passing through.
    ///     </para>
    /// </remarks>
    public async ValueTask<int> DequeueWhilePredicateWithActionAsync<TState>(
        Func<TState, T, ValueTask<bool>> predicate,
        Func<TState, IEnumerable<T>, ValueTask> actionToInvoke,
        TState state,
        CancellationToken cancellationToken = default)
    {
        _ = Requires.NotNull(
            predicate);
        _ = Requires.NotNull(
            actionToInvoke);

        using (AcquireWriteLock())
        {
            if (_isInDisasterMode != 0)
            {
                // Disaster mode
                return await _persistedQueue!.DequeueWhilePredicateWithActionAsync(
                        predicate,
                        actionToInvoke,
                        state,
                        cancellationToken)
                    .ConfigureAwait(false);
            }

            // Normal mode
            if (_queue!.Count == 0)
            {
                return 0;
            }

            if (!await predicate(
                        state,
                        _queue.Peek())
                    .ConfigureAwait(false))
            {
                return 0;
            }

            var index = 1;
            T[] items = _queue.ToArray();
            for (; index < items.Length; index++)
            {
                if (!await predicate(
                            state,
                            items[index])
                        .ConfigureAwait(false))
                {
                    break;
                }
            }

            try
            {
                await actionToInvoke(
                        state,
                        items.Take(index))
                    .ConfigureAwait(false);
            }
            catch (Exception)
            {
                return 0;
            }

            for (var i = 0; i < index; i++)
            {
                _ = _queue.Dequeue();
            }

            return index;
        }
    }

    /// <summary>
    ///     De-queues an item from the queue, and executes the specified action on it.
    /// </summary>
    /// <typeparam name="TState">The type of the state object to pass to the action.</typeparam>
    /// <param name="actionToInvoke">The action to invoke.</param>
    /// <param name="state">The state object to pass to the action.</param>
    /// <returns>
    ///     <see langword="true" /> if the de-queuing is successful, and the action performed, <see langword="false" />
    ///     otherwise.
    /// </returns>
    public bool DequeueWithAction<TState>(
        Action<TState, T> actionToInvoke,
        TState state)
    {
        _ = Requires.NotNull(
            actionToInvoke);

        using (AcquireWriteLock())
        {
            if (_isInDisasterMode != 0)
            {
                // Disaster mode
                return _persistedQueue!.DequeueWithAction(
                    actionToInvoke,
                    state);
            }

            // Normal mode
            if (_queue!.Count == 0)
            {
                return false;
            }

            T item = _queue.Peek();

            try
            {
                actionToInvoke(
                    state,
                    item);
            }
            catch (Exception)
            {
                return false;
            }

            _ = _queue.Dequeue();

            return true;
        }
    }

    /// <summary>
    ///     Asynchronously de-queues an item from the queue, and executes the specified action on it.
    /// </summary>
    /// <typeparam name="TState">The type of the state object to pass to the action.</typeparam>
    /// <param name="actionToInvoke">The action to invoke.</param>
    /// <param name="state">The state object to pass to the action.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>
    ///     <see langword="true" /> if the dequeuing is successful, and the action performed, <see langword="false" />
    ///     otherwise.
    /// </returns>
    public async ValueTask<bool> DequeueWithActionAsync<TState>(
        Action<TState, T> actionToInvoke,
        TState state,
        CancellationToken cancellationToken = default)
    {
        _ = Requires.NotNull(
            actionToInvoke);

        using (AcquireWriteLock())
        {
            if (_isInDisasterMode != 0)
            {
                // Disaster mode
                return await _persistedQueue!.DequeueWithActionAsync(
                        actionToInvoke,
                        state,
                        cancellationToken)
                    .ConfigureAwait(false);
            }

            // Normal mode
            if (_queue!.Count == 0)
            {
                return false;
            }

            await Task.Yield();

            T item = _queue.Peek();

            try
            {
                actionToInvoke(
                    state,
                    item);
            }
            catch (Exception)
            {
                return false;
            }

            _ = _queue.Dequeue();

            return true;
        }
    }

    /// <summary>
    ///     Asynchronously de-queues an item from the queue, and executes the specified action on it.
    /// </summary>
    /// <typeparam name="TState">The type of the state object to pass to the action.</typeparam>
    /// <param name="actionToInvoke">The action to invoke.</param>
    /// <param name="state">The state object to pass to the action.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>
    ///     <see langword="true" /> if the dequeuing is successful, and the action performed, <see langword="false" />
    ///     otherwise.
    /// </returns>
    [SuppressMessage(
        "Performance",
        "HAA0603:Delegate allocation from a method group",
        Justification = "Acceptable - we're doing a lot of allocation in the Task method anyway.")]
    public async ValueTask<bool> DequeueWithActionAsync<TState>(
        Func<TState, T, Task> actionToInvoke,
        TState state,
        CancellationToken cancellationToken = default)
    {
        return await DequeueWithActionAsync(
            InvokeActionLocal,
            state,
            cancellationToken);

        async ValueTask InvokeActionLocal(
            TState stateInternal,
            T obj) =>
            await actionToInvoke(
                stateInternal,
                obj);
    }

    /// <summary>
    ///     Asynchronously de-queues an item from the queue, and executes the specified action on it.
    /// </summary>
    /// <typeparam name="TState">The type of the state object to pass to the action.</typeparam>
    /// <param name="actionToInvoke">The action to invoke.</param>
    /// <param name="state">The state object to pass to the action.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>
    ///     <see langword="true" /> if the dequeuing is successful, and the action performed, <see langword="false" />
    ///     otherwise.
    /// </returns>
    public async ValueTask<bool> DequeueWithActionAsync<TState>(
        Func<TState, T, ValueTask> actionToInvoke,
        TState state,
        CancellationToken cancellationToken = default)
    {
        _ = Requires.NotNull(
            actionToInvoke);

        using (AcquireWriteLock())
        {
            if (_isInDisasterMode != 0)
            {
                // Disaster mode
                return await _persistedQueue!.DequeueWithActionAsync(
                        actionToInvoke,
                        state,
                        cancellationToken)
                    .ConfigureAwait(false);
            }

            // Normal mode
            if (_queue!.Count == 0)
            {
                return false;
            }

            T item = _queue.Peek();

            try
            {
                await actionToInvoke(
                        state,
                        item)
                    .ConfigureAwait(false);
            }
            catch (Exception)
            {
                return false;
            }

            _ = _queue.Dequeue();

            return true;
        }
    }

    /// <summary>
    ///     Clears the queue of all elements.
    /// </summary>
    public void Clear()
    {
        using (AcquireWriteLock())
        {
            if (_isInDisasterMode == 0)
            {
                // Not in disaster mode
                _queue!.Clear();
            }
            else
            {
                // Disaster mode
                _persistedQueue!.Clear();
            }
        }
    }

    /// <summary>
    ///     Determines whether this instance contains the object.
    /// </summary>
    /// <param name="item">The item to verify.</param>
    /// <returns>
    ///     <see langword="true" /> if the item is queued, <see langword="false" /> otherwise.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    ///     The queue is currently in disaster mode, enumeration operations are
    ///     disabled by design.
    /// </exception>
    public bool Contains(T item)
    {
        using (AcquireReadLock())
        {
            if (_isInDisasterMode == 0)
            {
                // Not in disaster mode
                return _queue!.Contains(item);
            }
        }

        // Disaster mode
        throw new InvalidOperationException(Resources.ErrorTheQueueIsCurrentlyInDisasterMode);
    }

    /// <summary>
    ///     De-queues an item and removes it from the queue.
    /// </summary>
    /// <returns>
    ///     The item that has been de-queued.
    /// </returns>
    public T Dequeue()
    {
        using (AcquireWriteLock())
        {
            return _isInDisasterMode == 0 ? _queue!.Dequeue() : _persistedQueue!.Dequeue();
        }
    }

    /// <summary>
    ///     Queues an item, adding it to the queue.
    /// </summary>
    /// <param name="item">The item to enqueue.</param>
    public void Enqueue(T item)
    {
        using (AcquireWriteLock())
        {
            if (_isInDisasterMode == 0)
            {
                // Not in disaster mode
                _queue!.Enqueue(item);
            }
            else
            {
                // Disaster mode
                _persistedQueue!.Enqueue(item);
            }
        }
    }

    /// <summary>
    ///     Queues a range of elements, adding them to the queue.
    /// </summary>
    /// <param name="items">The item range to push.</param>
    public void EnqueueRange(T[] items)
    {
        using (AcquireWriteLock())
        {
            if (_isInDisasterMode == 0)
            {
                // Not in disaster mode
                _queue!.EnqueueRange(items);
            }
            else
            {
                // Disaster mode
                _persistedQueue!.EnqueueRange(items);
            }
        }
    }

    /// <summary>
    ///     Queues a range of elements, adding them to the queue.
    /// </summary>
    /// <param name="items">The item range to enqueue.</param>
    /// <param name="startIndex">The start index.</param>
    /// <param name="count">The number of items to enqueue.</param>
    public void EnqueueRange(
        T[] items,
        int startIndex,
        int count)
    {
        using (AcquireWriteLock())
        {
            if (_isInDisasterMode == 0)
            {
                // Not in disaster mode
                _queue!.EnqueueRange(
                    items,
                    startIndex,
                    count);
            }
            else
            {
                // Disaster mode
                _persistedQueue!.EnqueueRange(
                    items,
                    startIndex,
                    count);
            }
        }
    }

    /// <summary>
    ///     Peeks at the topmost element in the queue, without removing it.
    /// </summary>
    /// <returns>
    ///     The item peeked at, if any.
    /// </returns>
    public T Peek()
    {
        using (AcquireReadLock())
        {
            return _isInDisasterMode == 0 ? _queue!.Peek() : _persistedQueue!.Peek();
        }
    }

    /// <summary>
    ///     Converts to array.
    /// </summary>
    /// <returns>
    ///     The created array with all element of the queue.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    ///     The queue is currently in disaster mode, enumeration operations are
    ///     disabled by design.
    /// </exception>
    public T[] ToArray()
    {
        using (AcquireReadLock())
        {
            if (_isInDisasterMode == 0)
            {
                // Not in disaster mode
                return _queue!.ToArray();
            }
        }

        // Disaster mode
        throw new InvalidOperationException(Resources.ErrorTheQueueIsCurrentlyInDisasterMode);
    }

    /// <summary>
    ///     Trims the excess free space from within the queue, reducing the capacity to the actual number of elements.
    /// </summary>
    public void TrimExcess()
    {
        using (AcquireWriteLock())
        {
            if (_isInDisasterMode == 0)
            {
                // Not in disaster mode
                _queue!.TrimExcess();
            }
        }

        // Disaster mode - no trimming!
    }

    /// <summary>
    ///     Attempts to de-queue an item and to remove it from queue.
    /// </summary>
    /// <param name="item">The item that has been de-queued, default if unsuccessful.</param>
    /// <returns>
    ///     <see langword="true" /> if an item is de-queued successfully, <see langword="false" /> otherwise, or if the
    ///     queue is empty.
    /// </returns>
    public bool TryDequeue(out T item)
    {
        using (AcquireWriteLock())
        {
            return _isInDisasterMode == 0
                ? _queue!.TryDequeue(out item!)
                : _persistedQueue!.TryDequeue(out item);
        }
    }

    /// <summary>
    ///     Attempts to peek at the current queue and return the item that is next in line to be dequeued.
    /// </summary>
    /// <param name="item">The item, or default if unsuccessful.</param>
    /// <returns>
    ///     <see langword="true" /> if an item is found, <see langword="false" /> otherwise, or if the queue is empty.
    /// </returns>
    public bool TryPeek(out T item)
    {
        using (AcquireReadLock())
        {
            return _isInDisasterMode == 0
                ? _queue!.TryPeek(out item!)
                : _persistedQueue!.TryPeek(out item);
        }
    }

    /// <summary>
    ///     Returns an enumerator that iterates through a collection.
    /// </summary>
    /// <returns>
    ///     An <see cref="IEnumerator" /> object that can be used to iterate through the collection.
    /// </returns>
    [SuppressMessage(
        "Performance",
        "HAA0401:Possible allocation of reference type enumerator",
        Justification = "Unavoidable.")]
    [ExcludeFromCodeCoverage]
    IEnumerator IEnumerable.GetEnumerator() =>
        GetEnumerator();

    /// <summary>
    ///     Puts the queue in disaster mode, indicating that there is a major fault and that the queue contents need to be
    ///     persisted to disk.
    /// </summary>
    public void Disaster()
    {
        if (Interlocked.CompareExchange(
                ref _isInDisasterMode,
                1,
                0) !=
            0)
        {
            return;
        }

        using (AcquireWriteLock())
        {
            PersistedQueue<T> transferQueue;
            try
            {
                transferQueue = new(
                    _persistenceFolderPath,
                    Timeout.InfiniteTimeSpan,
                    _fileShim,
                    _directoryShim,
                    _pathShim);
            }
            catch (Exception)
            {
                _ = Interlocked.Exchange(
                    ref _isInDisasterMode,
                    0);

                throw;
            }

            Interlocked.Exchange(
                ref _persistedQueue,
                transferQueue)?.Dispose();

            try
            {
                while (_queue!.TryDequeue(out T? transferItem))
                {
                    transferQueue.Enqueue(transferItem);
                }
            }
            catch (Exception)
            {
                transferQueue.Dispose();
                _ = Interlocked.Exchange(
                    ref _isInDisasterMode,
                    0);

                throw;
            }

            _ = Interlocked.Exchange(
                ref _queue,
                null!);
        }
    }

    /// <summary>
    ///     Recovers after the disaster situation.
    /// </summary>
    public void Recovery()
    {
        if (Interlocked.CompareExchange(
                ref _isInDisasterMode,
                0,
                1) !=
            1)
        {
            return;
        }

        using (AcquireWriteLock())
        {
            var transferQueue = new Queue<T>();

            _ = Interlocked.Exchange(
                ref _queue,
                transferQueue);

            try
            {
                while (_persistedQueue!.TryDequeue(out T transferItem))
                {
                    transferQueue.Enqueue(transferItem);
                }
            }
            catch (Exception)
            {
                _persistedQueue!.Dispose();
                _ = Interlocked.Exchange(
                    ref _isInDisasterMode,
                    0);

                throw;
            }

            Interlocked.Exchange(
                ref _persistedQueue,
                null!).Dispose();
        }
    }

    /// <summary>
    ///     Invoked when there is an unhandled exception in the current application domain. Puts the queue in disaster mode.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="UnhandledExceptionEventArgs" /> instance containing the event data.</param>
    private void CurrentDomainOnUnhandledException(
        object sender,
        UnhandledExceptionEventArgs e)
    {
        if (e.IsTerminating)
        {
            Disaster();
        }
    }
}