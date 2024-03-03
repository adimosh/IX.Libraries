using System.Diagnostics;
using System.Runtime.Serialization;
using IX.Observable.DebugAide;

using ReaderWriterLockSlim = IX.Library.Threading.ReaderWriterLockSlim;

namespace IX.Observable;

/// <summary>
///     A thread-safe stack that broadcasts its changes.
/// </summary>
/// <typeparam name="T">The type of elements in the stack.</typeparam>
/// <remarks>
///     <para>
///         This class is not serializable. In order to serialize / deserialize content, please use the copying methods
///         and serialize the result.
///     </para>
/// </remarks>
[DebuggerDisplay("ConcurrentObservableStack, Count = {" + nameof(Count) + "}")]
[DebuggerTypeProxy(typeof(StackDebugView<>))]
[CollectionDataContract(
    Namespace = Constants.DataContractNamespace,
    Name = "Observable{0}Stack",
    ItemName = "Item")]
public class ConcurrentObservableStack<T> : ObservableStack<T>
{
    private Lazy<ReaderWriterLockSlim> _locker;

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableStack{T}" /> class.
    /// </summary>
    public ConcurrentObservableStack() => _locker = EnvironmentSettings.GenerateDefaultLocker();

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableStack{T}" /> class.
    /// </summary>
    /// <param name="capacity">The initial capacity of the stack.</param>
    public ConcurrentObservableStack(int capacity)
        : base(capacity) =>
        _locker = EnvironmentSettings.GenerateDefaultLocker();

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableStack{T}" /> class.
    /// </summary>
    /// <param name="collection">A collection of items to copy into the stack.</param>
    public ConcurrentObservableStack(IEnumerable<T> collection)
        : base(collection) =>
        _locker = EnvironmentSettings.GenerateDefaultLocker();

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableStack{T}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context top use when posting observable messages.</param>
    public ConcurrentObservableStack(SynchronizationContext context)
        : base(context) =>
        _locker = EnvironmentSettings.GenerateDefaultLocker();

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableStack{T}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context top use when posting observable messages.</param>
    /// <param name="capacity">The initial capacity of the stack.</param>
    public ConcurrentObservableStack(
        SynchronizationContext context,
        int capacity)
        : base(
            context,
            capacity) =>
        _locker = EnvironmentSettings.GenerateDefaultLocker();

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableStack{T}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context top use when posting observable messages.</param>
    /// <param name="collection">A collection of items to copy into the stack.</param>
    public ConcurrentObservableStack(
        SynchronizationContext context,
        IEnumerable<T> collection)
        : base(
            context,
            collection) =>
        _locker = EnvironmentSettings.GenerateDefaultLocker();

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableStack{T}" /> class.
    /// </summary>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ConcurrentObservableStack(bool suppressUndoable)
        : base(suppressUndoable) =>
        _locker = EnvironmentSettings.GenerateDefaultLocker();

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableStack{T}" /> class.
    /// </summary>
    /// <param name="capacity">The initial capacity of the stack.</param>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ConcurrentObservableStack(
        int capacity,
        bool suppressUndoable)
        : base(
            capacity,
            suppressUndoable) =>
        _locker = EnvironmentSettings.GenerateDefaultLocker();

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableStack{T}" /> class.
    /// </summary>
    /// <param name="collection">A collection of items to copy into the stack.</param>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ConcurrentObservableStack(
        IEnumerable<T> collection,
        bool suppressUndoable)
        : base(
            collection,
            suppressUndoable) =>
        _locker = EnvironmentSettings.GenerateDefaultLocker();

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableStack{T}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context top use when posting observable messages.</param>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ConcurrentObservableStack(
        SynchronizationContext context,
        bool suppressUndoable)
        : base(
            context,
            suppressUndoable) =>
        _locker = EnvironmentSettings.GenerateDefaultLocker();

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableStack{T}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context top use when posting observable messages.</param>
    /// <param name="capacity">The initial capacity of the stack.</param>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ConcurrentObservableStack(
        SynchronizationContext context,
        int capacity,
        bool suppressUndoable)
        : base(
            context,
            capacity,
            suppressUndoable) =>
        _locker = EnvironmentSettings.GenerateDefaultLocker();

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableStack{T}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context top use when posting observable messages.</param>
    /// <param name="collection">A collection of items to copy into the stack.</param>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ConcurrentObservableStack(
        SynchronizationContext context,
        IEnumerable<T> collection,
        bool suppressUndoable)
        : base(
            context,
            collection,
            suppressUndoable) =>
        _locker = EnvironmentSettings.GenerateDefaultLocker();

    /// <summary>
    ///     Gets a synchronization lock item to be used when trying to synchronize read/write operations between threads.
    /// </summary>
    protected override IReaderWriterLock SynchronizationLock => _locker.Value;

    /// <summary>
    ///     Called when the object is being deserialized, in order to set the locker to a new value.
    /// </summary>
    /// <param name="context">The streaming context.</param>
    [OnDeserializing]
    internal void OnDeserializingMethod(StreamingContext context) =>
        Interlocked.Exchange(
            ref _locker,
            EnvironmentSettings.GenerateDefaultLocker());

    /// <summary>
    ///     Disposes the managed context.
    /// </summary>
    protected override void DisposeManagedContext()
    {
        var l = Interlocked.Exchange(
            ref _locker,
            null!);
        if (l?.IsValueCreated ?? false)
        {
            l.Value.Dispose();
        }

        base.DisposeManagedContext();
    }

    /// <summary>
    ///     Disposes the general context.
    /// </summary>
    protected override void DisposeGeneralContext()
    {
        _ = Interlocked.Exchange(
            ref _locker,
            null!);

        base.DisposeGeneralContext();
    }
}