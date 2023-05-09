using System.Diagnostics;
using IX.Observable.DebugAide;

using ReaderWriterLockSlim = IX.Core.Threading.ReaderWriterLockSlim;

namespace IX.Observable;

/// <summary>
///     An observable collection created from a master collection (to which updates go) and many slave, read-only
///     collections.
/// </summary>
/// <typeparam name="T">The type of the item.</typeparam>
/// <seealso cref="IX.Observable.ObservableCollectionBase{TItem}" />
[DebuggerDisplay("Count = {" + nameof(Count) + "}")]
[DebuggerTypeProxy(typeof(CollectionDebugView<>))]
[PublicAPI]
public class ConcurrentObservableMasterSlaveCollection<T> : ObservableMasterSlaveCollection<T>
{
    private Lazy<ReaderWriterLockSlim> locker;

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableMasterSlaveCollection{T}" /> class.
    /// </summary>
    public ConcurrentObservableMasterSlaveCollection() => locker = EnvironmentSettings.GenerateDefaultLocker();

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableMasterSlaveCollection{T}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context to use, if any.</param>
    public ConcurrentObservableMasterSlaveCollection(SynchronizationContext context)
        : base(context) =>
        locker = EnvironmentSettings.GenerateDefaultLocker();

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableMasterSlaveCollection{T}" /> class.
    /// </summary>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ConcurrentObservableMasterSlaveCollection(bool suppressUndoable)
        : base(suppressUndoable) =>
        locker = EnvironmentSettings.GenerateDefaultLocker();

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableMasterSlaveCollection{T}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context to use, if any.</param>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ConcurrentObservableMasterSlaveCollection(
        SynchronizationContext context,
        bool suppressUndoable)
        : base(
            context,
            suppressUndoable) =>
        locker = EnvironmentSettings.GenerateDefaultLocker();

    /// <summary>
    ///     Gets a synchronization lock item to be used when trying to synchronize read/write operations between threads.
    /// </summary>
    protected override IReaderWriterLock SynchronizationLock => locker.Value;

    /// <summary>
    ///     Disposes the managed context.
    /// </summary>
    protected override void DisposeManagedContext()
    {
        var l = Interlocked.Exchange(
            ref locker!,
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
            ref locker!,
            null!);

        base.DisposeGeneralContext();
    }
}