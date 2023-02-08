namespace IX.Core.Threading;

/// <summary>
///     A read and write synchronization locker.
/// </summary>
/// <seealso cref="SynchronizationLocker" />
[PublicAPI]
[Obsolete("This class has been deemed obsolete in favor of the value-type lockers.")]
public class ReadWriteSynchronizationLocker : SynchronizationLocker
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ReadWriteSynchronizationLocker" /> class.
    /// </summary>
    /// <param name="locker">The locker.</param>
    /// <exception cref="TimeoutException">The lock could not be acquired in time.</exception>
    public ReadWriteSynchronizationLocker(IReaderWriterLock? locker)
        : this(
            locker,
            EnvironmentSettings.LockAcquisitionTimeout) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ReadWriteSynchronizationLocker" /> class.
    /// </summary>
    /// <param name="locker">The locker.</param>
    /// <param name="lockAcquisitionTimeout">The express lock acquisition timeout.</param>
    /// <exception cref="TimeoutException">The lock could not be acquired in time.</exception>
    public ReadWriteSynchronizationLocker(
        IReaderWriterLock? locker,
        int lockAcquisitionTimeout)
        : this(
            locker,
            TimeSpan.FromMilliseconds(lockAcquisitionTimeout)) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ReadWriteSynchronizationLocker" /> class.
    /// </summary>
    /// <param name="locker">The locker.</param>
    /// <param name="lockAcquisitionTimeoutMilliseconds">The express lock acquisition timeout.</param>
    /// <exception cref="TimeoutException">The lock could not be acquired in time.</exception>
    public ReadWriteSynchronizationLocker(
        IReaderWriterLock? locker,
        double lockAcquisitionTimeoutMilliseconds)
        : this(
            locker,
            TimeSpan.FromMilliseconds(lockAcquisitionTimeoutMilliseconds)) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ReadWriteSynchronizationLocker" /> class.
    /// </summary>
    /// <param name="locker">The locker.</param>
    /// <param name="lockAcquisitionTimespan">The lock acquisition timespan.</param>
    /// <exception cref="TimeoutException">The lock could not be acquired in time.</exception>
    public ReadWriteSynchronizationLocker(
        IReaderWriterLock? locker,
        TimeSpan lockAcquisitionTimespan)
        : base(locker)
    {
        if (!locker?.TryEnterUpgradeableReadLock(lockAcquisitionTimespan) ?? false)
        {
            throw new TimeoutException();
        }
    }

    /// <summary>
    ///     Upgrades the lock to a write lock.
    /// </summary>
    /// <exception cref="TimeoutException">The lock could not be acquired in time.</exception>
    public void Upgrade()
    {
        if (!Locker?.TryEnterWriteLock(EnvironmentSettings.LockAcquisitionTimeout) ?? false)
        {
            throw new TimeoutException();
        }
    }

    /// <summary>
    ///     Releases the currently-held lock.
    /// </summary>
    public override void Dispose()
    {
        if (Locker == null)
        {
            return;
        }

        if (Locker.IsWriteLockHeld)
        {
            Locker.ExitWriteLock();
        }

        if (Locker.IsUpgradeableReadLockHeld)
        {
            Locker.ExitUpgradeableReadLock();
        }

        GC.SuppressFinalize(this);
    }
}