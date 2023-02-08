namespace IX.Core.Threading;

/// <summary>
///     A read-only synchronization locker.
/// </summary>
/// <seealso cref="SynchronizationLocker" />
[PublicAPI]
[Obsolete("This class has been deemed obsolete in favor of the value-type lockers.")]
public class ReadOnlySynchronizationLocker : SynchronizationLocker
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ReadOnlySynchronizationLocker" /> class.
    /// </summary>
    /// <param name="locker">The locker.</param>
    /// <exception cref="TimeoutException">The lock could not be acquired in time.</exception>
    public ReadOnlySynchronizationLocker(IReaderWriterLock? locker)
        : this(
            locker,
            EnvironmentSettings.LockAcquisitionTimeout) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ReadOnlySynchronizationLocker" /> class.
    /// </summary>
    /// <param name="locker">The locker.</param>
    /// <param name="lockAcquisitionTimeout">The express lock acquisition timeout.</param>
    /// <exception cref="TimeoutException">The lock could not be acquired in time.</exception>
    public ReadOnlySynchronizationLocker(
        IReaderWriterLock? locker,
        int lockAcquisitionTimeout)
        : this(
            locker,
            TimeSpan.FromMilliseconds(lockAcquisitionTimeout)) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ReadOnlySynchronizationLocker" /> class.
    /// </summary>
    /// <param name="locker">The locker.</param>
    /// <param name="lockAcquisitionTimeoutMilliseconds">The express lock acquisition timeout.</param>
    /// <exception cref="TimeoutException">The lock could not be acquired in time.</exception>
    public ReadOnlySynchronizationLocker(
        IReaderWriterLock? locker,
        double lockAcquisitionTimeoutMilliseconds)
        : this(
            locker,
            TimeSpan.FromMilliseconds(lockAcquisitionTimeoutMilliseconds)) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ReadOnlySynchronizationLocker" /> class.
    /// </summary>
    /// <param name="locker">The locker.</param>
    /// <param name="lockAcquisitionTimespan">The lock acquisition timespan.</param>
    /// <exception cref="TimeoutException">The lock could not be acquired in time.</exception>
    public ReadOnlySynchronizationLocker(
        IReaderWriterLock? locker,
        TimeSpan lockAcquisitionTimespan)
        : base(locker)
    {
        if (!locker?.TryEnterReadLock(lockAcquisitionTimespan) ?? false)
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

        if (Locker.IsReadLockHeld)
        {
            Locker.ExitReadLock();
        }

        GC.SuppressFinalize(this);
    }
}