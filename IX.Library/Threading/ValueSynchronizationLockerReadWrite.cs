namespace IX.Library.Threading;

/// <summary>
/// A value-type synchronization locker for reading operations.
/// </summary>
public readonly struct ValueSynchronizationLockerReadWrite : IDisposable
{
    private readonly IReaderWriterLock? _locker;
    private readonly TimeSpan _timeout;
    private readonly bool _gotLock;

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueSynchronizationLockerReadWrite"/> struct.
    /// </summary>
    /// <param name="locker">The locker to use.</param>
    public ValueSynchronizationLockerReadWrite(IReaderWriterLock? locker)
        : this(
            locker,
            EnvironmentSettings.LockAcquisitionTimeout) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueSynchronizationLockerReadWrite"/> struct.
    /// </summary>
    /// <param name="locker">The locker to use.</param>
    /// <param name="timeout">The timeout for acquiring the lock, in milliseconds.</param>
    public ValueSynchronizationLockerReadWrite(
        IReaderWriterLock? locker,
        double timeout)
        : this(
            locker,
            TimeSpan.FromMilliseconds(timeout)) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueSynchronizationLockerReadWrite"/> struct.
    /// </summary>
    /// <param name="locker">The locker to use.</param>
    /// <param name="timeout">The timeout for acquiring the lock.</param>
    public ValueSynchronizationLockerReadWrite(
        IReaderWriterLock? locker,
        TimeSpan timeout)
    {
        _locker = locker;
        _timeout = timeout;

        _gotLock = locker?.TryEnterUpgradeableReadLock(timeout) ?? false;
    }

    /// <summary>
    /// Gets a value indicating whether the lock was successfully acquired for its original context.
    /// </summary>
    public bool LockSuccessfullyAcquired => _gotLock;

    /// <summary>
    /// Upgrades this upgradeable read lock to a write lock, within the configured timeout period.
    /// </summary>
    /// <returns></returns>
    public bool Upgrade()
    {
        if (_locker is null) return false;

        return _locker.TryEnterWriteLock(_timeout);
    }

    /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
    public void Dispose()
    {
        if (_locker is null) return;

        if (_locker.IsUpgradeableReadLockHeld)
        {
            _locker.ExitUpgradeableReadLock();
        }

        if (_locker.IsWriteLockHeld)
        {
            _locker.ExitWriteLock();
        }
    }
}