using IX.Library.IO;

using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace IX.Library.Collections;

/// <summary>
///     A base class for persisted queues.
/// </summary>
/// <typeparam name="T">The type of object in the queue.</typeparam>
/// <seealso cref="DisposableBase" />
/// <seealso cref="IX.Library.Collections.IQueue{T}" />
[PublicAPI]
public abstract class PersistedQueueBase<T> : ReaderWriterSynchronizedBase,
    IQueue<T>
{
    private readonly IDirectory _directoryShim;
    private readonly IFile _fileShim;
    private readonly IPath _pathShim;

    /// <summary>
    ///     The poisoned non-removable files list.
    /// </summary>
    private readonly List<string> _poisonedNonRemovableFiles;

    private readonly DataContractSerializer _serializer;

    /// <summary>
    ///     Initializes a new instance of the <see cref="IX.Library.Collections.PersistedQueueBase{T}" /> class.
    /// </summary>
    /// <param name="persistenceFolderPath">
    ///     The persistence folder path.
    /// </param>
    /// <param name="fileShim">
    ///     The file shim.
    /// </param>
    /// <param name="directoryShim">
    ///     The directory shim.
    /// </param>
    /// <param name="pathShim">
    ///     The path shim.
    /// </param>
    /// <param name="serializer">
    ///     The serializer.
    /// </param>
    /// <param name="timeout">
    ///     The timeout.
    /// </param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="persistenceFolderPath" />
    ///     or
    ///     <paramref name="fileShim" />
    ///     or
    ///     <paramref name="directoryShim" />
    ///     or
    ///     <paramref name="pathShim" />
    ///     or
    ///     <paramref name="serializer" />
    ///     is <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    /// <exception cref="ArgumentInvalidPathException">
    ///     The folder at <paramref name="persistenceFolderPath" /> does not exist, or is not accessible.
    /// </exception>
    protected PersistedQueueBase(
        string persistenceFolderPath,
        IFile fileShim,
        IDirectory directoryShim,
        IPath pathShim,
        DataContractSerializer serializer,
        TimeSpan timeout)
        : base(timeout)
    {
        // Dependency validation
        Requires.NotNull(
            out _fileShim,
            fileShim);
        Requires.NotNull(
            out _pathShim,
            pathShim);
        Requires.NotNull(
            out _directoryShim,
            directoryShim);
        Requires.NotNull(
            out _serializer,
            serializer);

        // Parameter validation
        _ = directoryShim.RequiresExists(persistenceFolderPath);

        // Internal state
        _poisonedNonRemovableFiles = new();

        // Persistence folder paths
        var dataFolderPath = pathShim.Combine(
            persistenceFolderPath,
            "Data");
        DataFolderPath = dataFolderPath;
        var poisonFolderPath = pathShim.Combine(
            persistenceFolderPath,
            "Poison");
        PoisonFolderPath = poisonFolderPath;

        // Initialize folder paths
        if (!directoryShim.Exists(dataFolderPath))
        {
            directoryShim.CreateDirectory(dataFolderPath);
        }

        if (!directoryShim.Exists(poisonFolderPath))
        {
            directoryShim.CreateDirectory(poisonFolderPath);
        }
    }

    /// <summary>
    ///     Gets the number of elements contained in the <see cref="IX.Library.Collections.PersistedQueueBase{T}" />.
    /// </summary>
    /// <value>The count.</value>
    public abstract int Count { get; }

    /// <summary>
    ///     Gets a value indicating whether this queue is empty.
    /// </summary>
    /// <value>
    ///     <c>true</c> if this queue is empty; otherwise, <c>false</c>.
    /// </value>
    public bool IsEmpty => Count == 0;

    /// <summary>
    ///     Gets a value indicating whether access to the <see cref="IX.Library.Collections.PersistedQueueBase{T}" /> is synchronized (thread safe).
    /// </summary>
    /// <value>The is synchronized.</value>
    bool ICollection.IsSynchronized => true;

    /// <summary>
    ///     Gets an object that can be used to synchronize access to the <see cref="IX.Library.Collections.PersistedQueueBase{T}" />.
    /// </summary>
    /// <value>The synchronize root.</value>
    object ICollection.SyncRoot { get; } = new();

    /// <summary>
    ///     Gets the data folder path.
    /// </summary>
    /// <value>The data folder path.</value>
    protected string DataFolderPath { get; }

    /// <summary>
    ///     Gets the folder shim.
    /// </summary>
    /// <value>The folder shim.</value>
    protected IDirectory DirectoryShim => _directoryShim;

    /// <summary>
    ///     Gets the file shim.
    /// </summary>
    /// <value>The file shim.</value>
    protected IFile FileShim => _fileShim;

    /// <summary>
    ///     Gets the path shim.
    /// </summary>
    /// <value>The path shim.</value>
    protected IPath PathShim => _pathShim;

    /// <summary>
    ///     Gets the poison folder path.
    /// </summary>
    /// <value>The poison folder path.</value>
    protected string PoisonFolderPath { get; }

    /// <summary>
    ///     Gets the serializer.
    /// </summary>
    /// <value>The serializer.</value>
    protected DataContractSerializer Serializer => _serializer;

    /// <summary>
    ///     Copies the elements of the <see cref="IX.Library.Collections.PersistedQueueBase{T}" /> to an <see cref="Array" />, starting at a
    ///     particular <see cref="Array" /> index.
    /// </summary>
    /// <param name="array">
    ///     The one-dimensional <see cref="Array" /> that is the destination of the elements copied
    ///     from <see cref="IX.Library.Collections.PersistedQueueBase{T}" />. The <see cref="Array" /> must have zero-based indexing.
    /// </param>
    /// <param name="index">The zero-based index in <paramref name="array" /> at which copying begins.</param>
    public abstract void CopyTo(
        Array array,
        int index);

    /// <summary>
    ///     Returns an enumerator that iterates through the queue.
    /// </summary>
    /// <returns>An enumerator that can be used to iterate through the queue.</returns>
    public abstract IEnumerator<T> GetEnumerator();

    /// <summary>
    ///     Clears the queue of all elements.
    /// </summary>
    public abstract void Clear();

    /// <summary>
    ///     Verifies whether or not an item is contained in the queue.
    /// </summary>
    /// <param name="item">The item to verify.</param>
    /// <returns><see langword="true" /> if the item is queued, <see langword="false" /> otherwise.</returns>
    public abstract bool Contains(T item);

    /// <summary>
    ///     De-queues an item and removes it from the queue.
    /// </summary>
    /// <returns>The item that has been de-queued.</returns>
    public abstract T Dequeue();

    /// <summary>
    ///     Queues an item, adding it to the queue.
    /// </summary>
    /// <param name="item">The item to enqueue.</param>
    public abstract void Enqueue(T item);

    /// <summary>
    ///     Queues a range of elements, adding them to the queue.
    /// </summary>
    /// <param name="items">The item range to push.</param>
    public void EnqueueRange(T[] items)
    {
        _ = Requires.NotNull(
            items);

        foreach (T item in items)
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
    public void EnqueueRange(
        T[] items,
        int startIndex,
        int count)
    {
        _ = Requires.NotNull(
            items);
        Requires.ValidArrayRange(
            in startIndex,
            in count,
            items);

        var itemsRange = new ReadOnlySpan<T>(
            items,
            startIndex,
            count);
        foreach (T item in itemsRange)
        {
            Enqueue(item);
        }
    }

    /// <summary>
    ///     Peeks at the topmost element in the queue, without removing it.
    /// </summary>
    /// <returns>The item peeked at, if any.</returns>
    public abstract T Peek();

    /// <summary>
    ///     Copies all elements of the queue into a new array.
    /// </summary>
    /// <returns>The created array with all element of the queue.</returns>
    public abstract T[] ToArray();

    /// <summary>
    ///     Trims the excess free space from within the queue, reducing the capacity to the actual number of elements.
    /// </summary>
    public virtual void TrimExcess() { }

    /// <summary>
    ///     Attempts to de-queue an item and to remove it from queue.
    /// </summary>
    /// <param name="item">The item that has been de-queued, default if unsuccessful.</param>
    /// <returns>
    ///     <see langword="true" /> if an item is de-queued successfully, <see langword="false" /> otherwise, or if the
    ///     queue is empty.
    /// </returns>
    public abstract bool TryDequeue(out T item);

    /// <summary>
    ///     Attempts to peek at the current queue and return the item that is next in line to be dequeued.
    /// </summary>
    /// <param name="item">The item, or default if unsuccessful.</param>
    /// <returns>
    ///     <see langword="true" /> if an item is found, <see langword="false" /> otherwise, or if the queue is empty.
    /// </returns>
    public abstract bool TryPeek(out T item);

    /// <summary>
    ///     Returns an enumerator that iterates through the queue.
    /// </summary>
    /// <returns>An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the queue.</returns>
    [ExcludeFromCodeCoverage]
    [SuppressMessage(
        "Performance",
        "HAA0401:Possible allocation of reference type enumerator",
        Justification = "We can't yet avoid this.")]
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    /// <summary>
    ///     Loads the topmost item from the folder, ensuring its deletion afterwards.
    /// </summary>
    /// <returns>An item, if one exists and can be loaded, a default value otherwise.</returns>
    /// <exception cref="InvalidOperationException">There are no more valid items in the folder.</exception>
    protected T LoadTopmostItem()
    {
        ThrowIfCurrentObjectDisposed();

        using (AcquireWriteLock())
        {
            var files = GetPossibleDataFiles();
            var i = 0;
            string possibleFilePath;
            T obj;

            while (true)
            {
                if (i >= files.Length)
                {
                    throw new InvalidOperationException();
                }

                possibleFilePath = files[i];

                try
                {
                    using Stream stream = FileShim.OpenRead(possibleFilePath);
                    obj = (T)(Serializer.ReadObject(stream) ?? throw new SerializationException());

                    break;
                }
                catch (IOException)
                {
                    HandleFileLoadProblem(possibleFilePath);
                    i++;
                }
                catch (UnauthorizedAccessException)
                {
                    HandleFileLoadProblem(possibleFilePath);
                    i++;
                }
                catch (SerializationException)
                {
                    HandleFileLoadProblem(possibleFilePath);
                    i++;
                }
            }

            try
            {
                FileShim.Delete(possibleFilePath);
            }
            catch (IOException)
            {
                HandleFileLoadProblem(possibleFilePath);
            }
            catch (UnauthorizedAccessException)
            {
                HandleFileLoadProblem(possibleFilePath);
            }
            catch (SerializationException)
            {
                HandleFileLoadProblem(possibleFilePath);
            }

            return obj;
        }
    }

    /// <summary>
    ///     Tries the load topmost item and execute an action on it, deleting the topmost object data if the operation is
    ///     successful.
    /// </summary>
    /// <typeparam name="TState">The type of the state object to send to the action.</typeparam>
    /// <param name="actionToInvoke">The action to invoke.</param>
    /// <param name="state">The state object to pass to the invoked action.</param>
    /// <returns><see langword="true" /> if de-queuing and executing is successful, <see langword="false" /> otherwise.</returns>
    protected bool TryLoadTopmostItemWithAction<TState>(
        Action<TState, T> actionToInvoke,
        TState state)
    {
        _ = Requires.NotNull(
            actionToInvoke);
        ThrowIfCurrentObjectDisposed();

        using var locker = AcquireReadWriteLock();

        var files = GetPossibleDataFiles();
        var i = 0;

        T obj;
        string possibleFilePath;

        while (true)
        {
            if (i >= files.Length)
            {
                return false;
            }

            possibleFilePath = files[i];

            try
            {
                using Stream stream = FileShim.OpenRead(possibleFilePath);

                obj = (T)(Serializer.ReadObject(stream) ?? throw new SerializationException());

                break;
            }
            catch (IOException)
            {
                HandleFileLoadProblem(possibleFilePath);
                i++;
            }
            catch (UnauthorizedAccessException)
            {
                HandleFileLoadProblem(possibleFilePath);
                i++;
            }
            catch (SerializationException)
            {
                HandleFileLoadProblem(possibleFilePath);
                i++;
            }
        }

        try
        {
            actionToInvoke(
                state,
                obj);
        }
        catch (Exception)
        {
            return false;
        }

        _ = locker.Upgrade();

        try
        {
            FileShim.Delete(possibleFilePath);
        }
        catch (IOException)
        {
            HandleFileLoadProblem(possibleFilePath);
        }
        catch (UnauthorizedAccessException)
        {
            HandleFileLoadProblem(possibleFilePath);
        }
        catch (SerializationException)
        {
            HandleFileLoadProblem(possibleFilePath);
        }

        return true;
    }

    /// <summary>
    ///     Asynchronously tries the load topmost item and execute an action on it, deleting the topmost object data if the
    ///     operation is successful.
    /// </summary>
    /// <typeparam name="TState">The type of the state object to send to the action.</typeparam>
    /// <param name="actionToInvoke">The action to invoke.</param>
    /// <param name="state">The state object to pass to the invoked action.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns><see langword="true" /> if de-queuing and executing is successful, <see langword="false" /> otherwise.</returns>
    [SuppressMessage(
        "Performance",
        "HAA0603:Delegate allocation from a method group",
        Justification = "Acceptable - we're doing a lot of allocation in the Task method anyway.")]
    protected ValueTask<bool> TryLoadTopmostItemWithActionAsync<TState>(
        Func<TState, T, Task> actionToInvoke,
        TState state,
        CancellationToken cancellationToken = default)
    {
        return TryLoadTopmostItemWithActionAsync(
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
    ///     Asynchronously tries the load topmost item and execute an action on it, deleting the topmost object data if the
    ///     operation is successful.
    /// </summary>
    /// <typeparam name="TState">The type of the state object to send to the action.</typeparam>
    /// <param name="actionToInvoke">The action to invoke.</param>
    /// <param name="state">The state object to pass to the invoked action.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns><see langword="true" /> if de-queuing and executing is successful, <see langword="false" /> otherwise.</returns>
    protected async ValueTask<bool> TryLoadTopmostItemWithActionAsync<TState>(
        Func<TState, T, ValueTask> actionToInvoke,
        TState state,
        CancellationToken cancellationToken = default)
    {
        Requires.NotNull(actionToInvoke);

        this.RequiresNotDisposed();

        using var locker = AcquireReadWriteLock();

        var files = GetPossibleDataFiles();
        var i = 0;

        T obj;
        string possibleFilePath;

        while (true)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (i >= files.Length)
            {
                return false;
            }

            possibleFilePath = files[i];

            try
            {
#if FRAMEWORK_ADVANCED
                await using Stream stream = FileShim.OpenRead(possibleFilePath);
#else
                using Stream stream = FileShim.OpenRead(possibleFilePath);
#endif

                obj = (T)(Serializer.ReadObject(stream) ?? throw new SerializationException());

                break;
            }
            catch (IOException)
            {
                HandleFileLoadProblem(possibleFilePath);
                i++;
            }
            catch (UnauthorizedAccessException)
            {
                HandleFileLoadProblem(possibleFilePath);
                i++;
            }
            catch (SerializationException)
            {
                HandleFileLoadProblem(possibleFilePath);
                i++;
            }
        }

        try
        {
            await actionToInvoke(
                    state,
                    obj)
                .ConfigureAwait(false);
        }
        catch (Exception)
        {
            return false;
        }

        _ = locker.Upgrade();

        try
        {
            await FileShim.DeleteAsync(
                possibleFilePath,
                cancellationToken);
        }
        catch (IOException)
        {
            HandleFileLoadProblem(possibleFilePath);
        }
        catch (UnauthorizedAccessException)
        {
            HandleFileLoadProblem(possibleFilePath);
        }
        catch (SerializationException)
        {
            HandleFileLoadProblem(possibleFilePath);
        }

        return true;
    }

    /// <summary>
    ///     Tries to load the topmost item and execute an action on it, deleting the topmost object data if the operation is
    ///     successful.
    /// </summary>
    /// <typeparam name="TState">The type of the state object to send to the action.</typeparam>
    /// <param name="predicate">The predicate.</param>
    /// <param name="actionToInvoke">The action to invoke.</param>
    /// <param name="state">The state object to pass to the invoked action.</param>
    /// <returns>The number of items that have been de-queued.</returns>
    /// <remarks>
    ///     <para>
    ///         Warning! This method has the potential of overrunning its read/write lock timeouts. Please ensure that the
    ///         <paramref name="predicate" /> method
    ///         filters out items in a way that limits the amount of data passing through.
    ///     </para>
    /// </remarks>
    protected int TryLoadWhilePredicateWithAction<TState>(
        Func<TState, T, bool> predicate,
        Action<TState, IEnumerable<T>> actionToInvoke,
        TState state)
    {
        _ = Requires.NotNull(
            predicate);
        _ = Requires.NotNull(
            actionToInvoke);

        this.RequiresNotDisposed();

        using var locker = AcquireReadWriteLock();

        var files = GetPossibleDataFiles();
        var i = 0;

        var accumulatedObjects = new List<T>();
        var accumulatedPaths = new List<string>();

        while (i < files.Length)
        {
            var possibleFilePath = files[i];

            try
            {
                T obj;

                using (Stream stream = FileShim.OpenRead(possibleFilePath))
                {
                    obj = (T)(Serializer.ReadObject(stream) ?? throw new SerializationException());
                }

                if (!predicate(
                        state,
                        obj))
                {
                    break;
                }

                accumulatedObjects.Add(obj);
                accumulatedPaths.Add(possibleFilePath);

                i++;
            }
            catch (IOException)
            {
                HandleFileLoadProblem(possibleFilePath);
                i++;
            }
            catch (UnauthorizedAccessException)
            {
                HandleFileLoadProblem(possibleFilePath);
                i++;
            }
            catch (SerializationException)
            {
                HandleFileLoadProblem(possibleFilePath);
                i++;
            }
        }

        if (accumulatedObjects.Count <= 0)
        {
            return accumulatedPaths.Count;
        }

        try
        {
            actionToInvoke(
                state,
                accumulatedObjects);
        }
        catch (Exception)
        {
            return 0;
        }

        _ = locker.Upgrade();

        foreach (var possibleFilePath in accumulatedPaths)
        {
            try
            {
                FileShim.Delete(possibleFilePath);
            }
            catch (IOException)
            {
                HandleFileLoadProblem(possibleFilePath);
            }
            catch (UnauthorizedAccessException)
            {
                HandleFileLoadProblem(possibleFilePath);
            }
            catch (SerializationException)
            {
                HandleFileLoadProblem(possibleFilePath);
            }
        }

        return accumulatedPaths.Count;
    }

    /// <summary>
    ///     Asynchronously tries to load the topmost item and execute an action on it, deleting the topmost object data if the
    ///     operation is successful.
    /// </summary>
    /// <typeparam name="TState">The type of the state object to send to the action.</typeparam>
    /// <param name="predicate">The predicate.</param>
    /// <param name="actionToInvoke">The action to invoke.</param>
    /// <param name="state">The state object to pass to the invoked action.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The number of items that have been de-queued.</returns>
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
    protected ValueTask<int> TryLoadWhilePredicateWithActionAsync<TState>(
        Func<TState, T, Task<bool>> predicate,
        Action<TState, IEnumerable<T>> actionToInvoke,
        TState state,
        CancellationToken cancellationToken = default)
    {
        return TryLoadWhilePredicateWithActionAsync(
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
    ///     Asynchronously tries to load the topmost item and execute an action on it, deleting the topmost object data if the
    ///     operation is successful.
    /// </summary>
    /// <typeparam name="TState">The type of the state object to send to the action.</typeparam>
    /// <param name="predicate">The predicate.</param>
    /// <param name="actionToInvoke">The action to invoke.</param>
    /// <param name="state">The state object to pass to the invoked action.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The number of items that have been de-queued.</returns>
    /// <remarks>
    ///     <para>
    ///         Warning! This method has the potential of overrunning its read/write lock timeouts. Please ensure that the
    ///         <paramref name="predicate" /> method
    ///         filters out items in a way that limits the amount of data passing through.
    ///     </para>
    /// </remarks>
    protected async ValueTask<int> TryLoadWhilePredicateWithActionAsync<TState>(
        Func<TState, T, ValueTask<bool>> predicate,
        Action<TState, IEnumerable<T>> actionToInvoke,
        TState state,
        CancellationToken cancellationToken = default)
    {
        Requires.NotNull(predicate);
        Requires.NotNull(actionToInvoke);

        this.RequiresNotDisposed();

        using var locker = AcquireReadWriteLock();

        var files = GetPossibleDataFiles();
        var i = 0;

        var accumulatedObjects = new List<T>();
        var accumulatedPaths = new List<string>();

        while (i < files.Length)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                break;
            }

            var possibleFilePath = files[i];

            try
            {
                T obj;

#if FRAMEWORK_ADVANCED
                await using (Stream stream = FileShim.OpenRead(possibleFilePath))
#else
                using (Stream stream = FileShim.OpenRead(possibleFilePath))
#endif
                {
                    obj = (T)(Serializer.ReadObject(stream) ?? throw new SerializationException());
                }

                if (!await predicate(
                            state,
                            obj)
                        .ConfigureAwait(false))
                {
                    break;
                }

                accumulatedObjects.Add(obj);
                accumulatedPaths.Add(possibleFilePath);

                i++;
            }
            catch (IOException)
            {
                HandleFileLoadProblem(possibleFilePath);
                i++;
            }
            catch (UnauthorizedAccessException)
            {
                HandleFileLoadProblem(possibleFilePath);
                i++;
            }
            catch (SerializationException)
            {
                HandleFileLoadProblem(possibleFilePath);
                i++;
            }
        }

        if (accumulatedObjects.Count <= 0)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return accumulatedPaths.Count;
        }

        try
        {
            actionToInvoke(
                state,
                accumulatedObjects);
        }
        catch (Exception)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return 0;
        }

        _ = locker.Upgrade();

        foreach (var possibleFilePath in accumulatedPaths)
        {
            try
            {
                await FileShim.DeleteAsync(
                    possibleFilePath,
                    cancellationToken);
            }
            catch (IOException)
            {
                HandleFileLoadProblem(possibleFilePath);
            }
            catch (UnauthorizedAccessException)
            {
                HandleFileLoadProblem(possibleFilePath);
            }
            catch (SerializationException)
            {
                HandleFileLoadProblem(possibleFilePath);
            }
        }

        cancellationToken.ThrowIfCancellationRequested();

        return accumulatedPaths.Count;
    }

    /// <summary>
    ///     Asynchronously tries to load the topmost item and execute an action on it, deleting the topmost object data if the
    ///     operation is successful.
    /// </summary>
    /// <typeparam name="TState">The type of the state object to send to the action.</typeparam>
    /// <param name="predicate">The predicate.</param>
    /// <param name="actionToInvoke">The action to invoke.</param>
    /// <param name="state">The state object to pass to the invoked action.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The number of items that have been de-queued.</returns>
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
    protected ValueTask<int> TryLoadWhilePredicateWithActionAsync<TState>(
        Func<TState, T, bool> predicate,
        Func<TState, IEnumerable<T>, Task> actionToInvoke,
        TState state,
        CancellationToken cancellationToken = default)
    {
        return TryLoadWhilePredicateWithActionAsync(
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
    ///     Asynchronously tries to load the topmost item and execute an action on it, deleting the topmost object data if the
    ///     operation is successful.
    /// </summary>
    /// <typeparam name="TState">The type of the state object to send to the action.</typeparam>
    /// <param name="predicate">The predicate.</param>
    /// <param name="actionToInvoke">The action to invoke.</param>
    /// <param name="state">The state object to pass to the invoked action.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The number of items that have been de-queued.</returns>
    /// <remarks>
    ///     <para>
    ///         Warning! This method has the potential of overrunning its read/write lock timeouts. Please ensure that the
    ///         <paramref name="predicate" /> method
    ///         filters out items in a way that limits the amount of data passing through.
    ///     </para>
    /// </remarks>
    protected async ValueTask<int> TryLoadWhilePredicateWithActionAsync<TState>(
        Func<TState, T, bool> predicate,
        Func<TState, IEnumerable<T>, ValueTask> actionToInvoke,
        TState state,
        CancellationToken cancellationToken = default)
    {
        Requires.NotNull(predicate);
        Requires.NotNull(actionToInvoke);

        this.RequiresNotDisposed();

        using var locker = AcquireReadWriteLock();

        var files = GetPossibleDataFiles();
        var i = 0;

        var accumulatedObjects = new List<T>();
        var accumulatedPaths = new List<string>();

        while (i < files.Length)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                break;
            }

            var possibleFilePath = files[i];

            try
            {
                T obj;

#if FRAMEWORK_ADVANCED
                await using (Stream stream = FileShim.OpenRead(possibleFilePath))
#else
                using (Stream stream = FileShim.OpenRead(possibleFilePath))
#endif
                {
                    obj = (T)(Serializer.ReadObject(stream) ?? throw new SerializationException());
                }

                if (!predicate(
                        state,
                        obj))
                {
                    break;
                }

                accumulatedObjects.Add(obj);
                accumulatedPaths.Add(possibleFilePath);

                i++;
            }
            catch (IOException)
            {
                HandleFileLoadProblem(possibleFilePath);
                i++;
            }
            catch (UnauthorizedAccessException)
            {
                HandleFileLoadProblem(possibleFilePath);
                i++;
            }
            catch (SerializationException)
            {
                HandleFileLoadProblem(possibleFilePath);
                i++;
            }
        }

        if (accumulatedObjects.Count <= 0)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return accumulatedPaths.Count;
        }

        try
        {
            await actionToInvoke(
                    state,
                    accumulatedObjects)
                .ConfigureAwait(false);
        }
        catch (Exception)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return 0;
        }

        _ = locker.Upgrade();

        foreach (var possibleFilePath in accumulatedPaths)
        {
            try
            {
                await FileShim.DeleteAsync(
                    possibleFilePath,
                    cancellationToken);
            }
            catch (IOException)
            {
                HandleFileLoadProblem(possibleFilePath);
            }
            catch (UnauthorizedAccessException)
            {
                HandleFileLoadProblem(possibleFilePath);
            }
            catch (SerializationException)
            {
                HandleFileLoadProblem(possibleFilePath);
            }
        }

        cancellationToken.ThrowIfCancellationRequested();

        return accumulatedPaths.Count;
    }

    /// <summary>
    ///     Asynchronously tries to load the topmost item and execute an action on it, deleting the topmost object data if the
    ///     operation is successful.
    /// </summary>
    /// <typeparam name="TState">The type of the state object to send to the action.</typeparam>
    /// <param name="predicate">The predicate.</param>
    /// <param name="actionToInvoke">The action to invoke.</param>
    /// <param name="state">The state object to pass to the invoked action.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The number of items that have been de-queued.</returns>
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
    protected ValueTask<int> TryLoadWhilePredicateWithActionAsync<TState>(
        Func<TState, T, Task<bool>> predicate,
        Func<TState, IEnumerable<T>, Task> actionToInvoke,
        TState state,
        CancellationToken cancellationToken = default)
    {
        return TryLoadWhilePredicateWithActionAsync(
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
    ///     Asynchronously tries to load the topmost item and execute an action on it, deleting the topmost object data if the
    ///     operation is successful.
    /// </summary>
    /// <typeparam name="TState">The type of the state object to send to the action.</typeparam>
    /// <param name="predicate">The predicate.</param>
    /// <param name="actionToInvoke">The action to invoke.</param>
    /// <param name="state">The state object to pass to the invoked action.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The number of items that have been de-queued.</returns>
    /// <remarks>
    ///     <para>
    ///         Warning! This method has the potential of overrunning its read/write lock timeouts. Please ensure that the
    ///         <paramref name="predicate" /> method
    ///         filters out items in a way that limits the amount of data passing through.
    ///     </para>
    /// </remarks>
    protected async ValueTask<int> TryLoadWhilePredicateWithActionAsync<TState>(
        Func<TState, T, ValueTask<bool>> predicate,
        Func<TState, IEnumerable<T>, ValueTask> actionToInvoke,
        TState state,
        CancellationToken cancellationToken = default)
    {
        Requires.NotNull(predicate);
        Requires.NotNull(actionToInvoke);

        ThrowIfCurrentObjectDisposed();

        using var locker = AcquireReadWriteLock();

        var files = GetPossibleDataFiles();
        var i = 0;

        var accumulatedObjects = new List<T>();
        var accumulatedPaths = new List<string>();

        while (i < files.Length)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                break;
            }

            var possibleFilePath = files[i];

            try
            {
                T obj;

#if FRAMEWORK_ADVANCED
                await using (Stream stream = FileShim.OpenRead(possibleFilePath))
#else
                using (Stream stream = FileShim.OpenRead(possibleFilePath))
#endif
                {
                    obj = (T)(Serializer.ReadObject(stream) ?? throw new SerializationException());
                }

                if (!await predicate(
                            state,
                            obj)
                        .ConfigureAwait(false))
                {
                    break;
                }

                accumulatedObjects.Add(obj);
                accumulatedPaths.Add(possibleFilePath);

                i++;
            }
            catch (IOException)
            {
                HandleFileLoadProblem(possibleFilePath);
                i++;
            }
            catch (UnauthorizedAccessException)
            {
                HandleFileLoadProblem(possibleFilePath);
                i++;
            }
            catch (SerializationException)
            {
                HandleFileLoadProblem(possibleFilePath);
                i++;
            }
        }

        if (accumulatedObjects.Count <= 0)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return accumulatedPaths.Count;
        }

        try
        {
            await actionToInvoke(
                    state,
                    accumulatedObjects)
                .ConfigureAwait(false);
        }
        catch (Exception)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return 0;
        }

        _ = locker.Upgrade();

        foreach (var possibleFilePath in accumulatedPaths)
        {
            try
            {
                await FileShim.DeleteAsync(
                    possibleFilePath,
                    cancellationToken);
            }
            catch (IOException)
            {
                HandleFileLoadProblem(possibleFilePath);
            }
            catch (UnauthorizedAccessException)
            {
                HandleFileLoadProblem(possibleFilePath);
            }
            catch (SerializationException)
            {
                HandleFileLoadProblem(possibleFilePath);
            }
        }

        cancellationToken.ThrowIfCancellationRequested();

        return accumulatedPaths.Count;
    }

    /// <summary>
    ///     Peeks at the topmost item in the folder.
    /// </summary>
    /// <returns>An item, if one exists and can be loaded, or an exception otherwise.</returns>
    /// <exception cref="InvalidOperationException">There are no more valid items in the folder.</exception>
    protected T PeekTopmostItem() => !TryPeekTopmostItem(out T item) ? throw new InvalidOperationException() : item;

    /// <summary>
    ///     Peeks at the topmost item in the folder.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <returns>
    ///     <see langword="true" /> if an item is found, <see langword="false" /> otherwise, or if the queue is empty.
    /// </returns>
    protected bool TryPeekTopmostItem(out T item)
    {
        ThrowIfCurrentObjectDisposed();

        using (AcquireReadLock())
        {
            var files = GetPossibleDataFiles();
            var i = 0;

            while (true)
            {
                if (i >= files.Length)
                {
                    item = default!;

                    return false;
                }

                var possibleFilePath = files[i];

                try
                {
                    using Stream stream = FileShim.OpenRead(possibleFilePath);
                    item = (T)(Serializer.ReadObject(stream) ?? throw new SerializationException());

                    return true;
                }
                catch (IOException)
                {
                    HandleFileLoadProblem(possibleFilePath);
                    i++;
                }
                catch (UnauthorizedAccessException)
                {
                    HandleFileLoadProblem(possibleFilePath);
                    i++;
                }
                catch (SerializationException)
                {
                    HandleFileLoadProblem(possibleFilePath);
                    i++;
                }
            }
        }
    }

    /// <summary>
    ///     Loads the items from the folder.
    /// </summary>
    /// <returns>An item, if one exists and can be loaded, a default value otherwise.</returns>
    /// <remarks>
    ///     <para>Warning! Not synchronized.</para>
    ///     <para>
    ///         This method is not synchronized between threads. Please ensure that you only use this method in a guaranteed
    ///         one-time-access manner (such as a constructor).
    ///     </para>
    /// </remarks>
    /// <exception cref="InvalidOperationException">There are no more valid items in the folder.</exception>
    protected IEnumerable<Tuple<T, string>> LoadValidItemObjectHandles()
    {
        foreach (var possibleFilePath in GetPossibleDataFiles())
        {
            T obj;
            try
            {
                using Stream stream = FileShim.OpenRead(possibleFilePath);
                obj = (T)(Serializer.ReadObject(stream) ?? throw new SerializationException());
            }
            catch (IOException)
            {
                HandleFileLoadProblem(possibleFilePath);

                continue;
            }
            catch (UnauthorizedAccessException)
            {
                HandleFileLoadProblem(possibleFilePath);

                continue;
            }
            catch (SerializationException)
            {
                HandleFileLoadProblem(possibleFilePath);

                continue;
            }

            yield return new(
                obj,
                possibleFilePath);
        }
    }

    /// <summary>
    ///     Saves the new item to the disk.
    /// </summary>
    /// <param name="item">The item to save.</param>
    /// <returns>The path of the newly-saved file.</returns>
    /// <exception cref="InvalidOperationException">
    ///     We have reached the maximum number of items saved in the same femtosecond.
    ///     This is theoretically not possible.
    /// </exception>
    [SuppressMessage(
        "Performance",
        "HAA0601:Value type to reference type conversion causing boxing allocation",
        Justification = "This is unavoidable, considering how the method works.")]
    protected string SaveNewItem(T item)
    {
        ThrowIfCurrentObjectDisposed();

        using (AcquireWriteLock())
        {
            var i = 1;
            string filePath;

            DateTime now = DateTime.UtcNow;

            do
            {
                filePath = PathShim.Combine(
                    DataFolderPath,
                    $"{now:yyyy.MM.dd.HH.mm.ss.fffffff}.{i}.dat");
                i++;

                if (i == int.MaxValue)
                {
                    throw new InvalidOperationException();
                }
            }
            while (FileShim.Exists(filePath));

            using (Stream stream = FileShim.Create(filePath))
            {
                Serializer.WriteObject(
                    stream,
                    item!);
            }

            return filePath;
        }
    }

    /// <summary>
    ///     Clears the data.
    /// </summary>
    protected void ClearData()
    {
        ThrowIfCurrentObjectDisposed();

        using (AcquireWriteLock())
        {
            foreach (var possibleFilePath in DirectoryShim.EnumerateFiles(
                             DataFolderPath,
                             "*.dat")
                         .ToArray())
            {
                HandleImpossibleMoveToPoison(possibleFilePath);
            }
        }

        FixUnmovableReferences();
    }

    /// <summary>
    ///     Gets the possible data files.
    /// </summary>
    /// <returns>An array of data file names.</returns>
    protected string[] GetPossibleDataFiles() =>
        DirectoryShim.EnumerateFiles(
                DataFolderPath,
                "*.dat")
            .Except(_poisonedNonRemovableFiles)
            .ToArray();

    /// <summary>
    ///     Handles the file load problem.
    /// </summary>
    /// <param name="possibleFilePath">The possible file path.</param>
    private void HandleFileLoadProblem(string possibleFilePath)
    {
        var newFilePath = PathShim.Combine(
            PoisonFolderPath,
            PathShim.GetFileName(possibleFilePath));

        // Seemingly-redundant catch code below will be replaced at a later time with an opt-in-based logging solution
        // and a more try/finally general approach

        // If an item by the same name exists in the poison queue, delete it
        try
        {
            if (FileShim.Exists(newFilePath))
            {
                FileShim.Delete(newFilePath);
            }
        }
        catch (IOException)
        {
            HandleImpossibleMoveToPoison(possibleFilePath);

            return;
        }
        catch (UnauthorizedAccessException)
        {
            HandleImpossibleMoveToPoison(possibleFilePath);

            return;
        }

        try
        {
            // Move to poison queue
            FileShim.Move(
                possibleFilePath,
                newFilePath);
        }
        catch (IOException)
        {
            HandleImpossibleMoveToPoison(possibleFilePath);
        }
        catch (UnauthorizedAccessException)
        {
            HandleImpossibleMoveToPoison(possibleFilePath);
        }
    }

    /// <summary>
    ///     Handles the situation where it is impossible to move a file to poison.
    /// </summary>
    /// <param name="possibleFilePath">The possible file path.</param>
    private void HandleImpossibleMoveToPoison(string possibleFilePath)
    {
        try
        {
            // If deletion was not possible, delete the offending item
            FileShim.Delete(possibleFilePath);
        }
        catch (IOException)
        {
            _poisonedNonRemovableFiles.Add(possibleFilePath);
        }
        catch (UnauthorizedAccessException)
        {
            _poisonedNonRemovableFiles.Add(possibleFilePath);
        }
    }

    /// <summary>
    ///     Fixes the unmovable references.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.LayoutRules",
        "SA1501:Statement should not be on a single line",
        Justification = "It's fine.")]
    private void FixUnmovableReferences()
    {
        foreach (var file in _poisonedNonRemovableFiles.ToArray())
        {
            try
            {
                if (!FileShim.Exists(file))
                {
                    _ = _poisonedNonRemovableFiles.Remove(file);
                }
            }
            catch (IOException) { }
            catch (UnauthorizedAccessException) { }
        }
    }
}