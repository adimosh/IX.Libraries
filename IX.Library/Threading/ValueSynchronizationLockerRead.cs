namespace IX.Library.Threading;

/// <summary>
/// A value-type synchronization locker for reading operations.
/// </summary>
public readonly struct ValueSynchronizationLockerRead : IDisposable
{
    private readonly IReaderWriterLock? _locker;
    private readonly bool _gotLock;

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueSynchronizationLockerRead"/> struct.
    /// </summary>
    /// <param name="locker">The locker to use.</param>
    public ValueSynchronizationLockerRead(IReaderWriterLock? locker)
        : this(
            locker,
            EnvironmentSettings.LockAcquisitionTimeout) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueSynchronizationLockerRead"/> struct.
    /// </summary>
    /// <param name="locker">The locker to use.</param>
    /// <param name="timeout">The timeout for acquiring the lock, in milliseconds.</param>
    public ValueSynchronizationLockerRead(
        IReaderWriterLock? locker,
        double timeout)
        : this(
            locker,
            TimeSpan.FromMilliseconds(timeout)) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueSynchronizationLockerRead"/> struct.
    /// </summary>
    /// <param name="locker">The locker to use.</param>
    /// <param name="timeout">The timeout for acquiring the lock.</param>
    public ValueSynchronizationLockerRead(
        IReaderWriterLock? locker,
        TimeSpan timeout)
    {
        _locker = locker;

        _gotLock = locker?.TryEnterReadLock(timeout) ?? false;
    }

    /// <summary>
    /// Gets a value indicating whether the lock was successfully acquired for its original context.
    /// </summary>
    public bool LockSuccessfullyAcquired => _gotLock;

    /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
    public void Dispose()
    {
        if (_locker is not null && _locker.IsReadLockHeld)
        {
            _locker.ExitReadLock();
        }
    }
}