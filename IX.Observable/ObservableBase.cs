using IX.Library.Threading;

namespace IX.Observable;

/// <summary>
///     A base class for collections that are observable.
/// </summary>
/// <seealso cref="NotifyCollectionChangedInvokerBase" />
[PublicAPI]
public abstract partial class ObservableBase : NotifyCollectionChangedInvokerBase
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableBase" /> class.
    /// </summary>
    protected ObservableBase() { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableBase" /> class.
    /// </summary>
    /// <param name="context">The synchronization context to use, if any.</param>
    protected ObservableBase(SynchronizationContext context)
        : base(context) { }

    /// <summary>
    ///     Gets a synchronization lock item to be used when trying to synchronize read/write operations between threads.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         On non-concurrent collections, this should be left <see langword="null" /> (<see langword="Nothing" /> in
    ///         Visual Basic).
    ///     </para>
    ///     <para>
    ///         On concurrent collections, this should be overridden to return an instance. All read/write operations on the
    ///         underlying constructs should rely on
    ///         the same instance of <see cref="IReaderWriterLock" /> that is returned here to synchronize.
    ///     </para>
    /// </remarks>
    protected virtual IReaderWriterLock? SynchronizationLock => null;

    /// <summary>
    ///     Produces a reader lock in concurrent collections.
    /// </summary>
    /// <returns>A disposable object representing the lock.</returns>
    protected ValueSynchronizationLockerRead AcquireReadLock() => new(SynchronizationLock);

    /// <summary>
    ///     Invokes using a reader lock.
    /// </summary>
    /// <param name="action">An action that is called.</param>
    protected void ReadLock(Action action)
    {
        using (new ValueSynchronizationLockerRead(SynchronizationLock))
        {
            action();
        }
    }

    /// <summary>
    ///     Gets a result from an invoker using a reader lock.
    /// </summary>
    /// <param name="action">An action that is called to get the result.</param>
    /// <typeparam name="T">The type of the object to return.</typeparam>
    /// <returns>A disposable object representing the lock.</returns>
    protected T ReadLock<T>(Func<T> action)
    {
        using (new ValueSynchronizationLockerRead(SynchronizationLock))
        {
            return action();
        }
    }

    /// <summary>
    ///     Produces a writer lock in concurrent collections.
    /// </summary>
    /// <returns>A disposable object representing the lock.</returns>
    protected ValueSynchronizationLockerWrite AcquireWriteLock() => new(SynchronizationLock);

    /// <summary>
    ///     Invokes using a writer lock.
    /// </summary>
    /// <param name="action">An action that is called.</param>
    protected void WriteLock(Action action)
    {
        using (new ValueSynchronizationLockerWrite(SynchronizationLock))
        {
            action();
        }
    }

    /// <summary>
    ///     Produces an upgradeable reader lock in concurrent collections.
    /// </summary>
    /// <returns>A disposable object representing the lock.</returns>
    protected ValueSynchronizationLockerReadWrite AcquireReadWriteLock() => new(SynchronizationLock);
}