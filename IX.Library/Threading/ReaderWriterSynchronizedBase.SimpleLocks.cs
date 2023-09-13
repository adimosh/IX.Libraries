namespace IX.Library.Threading;

/// <summary>
///     A base class for a reader/writer synchronized class.
/// </summary>
public abstract partial class ReaderWriterSynchronizedBase
{
    /// <summary>
    ///     Enters a read lock.
    /// </summary>
    /// <returns><see langword="true" /> if the lock is entered, <see langword="false" /> otherwise.</returns>
    protected bool EnterReadLock()
    {
        _ = _locker.TryEnterReadLock(EnvironmentSettings.LockAcquisitionTimeout);

        return true;
    }

    /// <summary>
    ///     Enters a read lock.
    /// </summary>
    /// <param name="millisecondsTimeout">The timeout, in milliseconds.</param>
    /// <returns><see langword="true" /> if the lock is entered, <see langword="false" /> otherwise.</returns>
    protected bool EnterReadLock(int millisecondsTimeout)
    {
        _ = _locker.TryEnterReadLock(millisecondsTimeout);

        return true;
    }

    /// <summary>
    ///     Enters a read lock.
    /// </summary>
    /// <param name="timeout">The timeout.</param>
    /// <returns><see langword="true" /> if the lock is entered, <see langword="false" /> otherwise.</returns>
    protected bool EnterReadLock(TimeSpan timeout)
    {
        _ = _locker.TryEnterReadLock(timeout);

        return true;
    }

    /// <summary>
    ///     Exits a read lock.
    /// </summary>
    protected void ExitReadLock() => _locker.ExitReadLock();

    /// <summary>
    ///     Enters a read lock.
    /// </summary>
    /// <returns><see langword="true" /> if the lock is entered, <see langword="false" /> otherwise.</returns>
    protected bool EnterWriteLock()
    {
        _ = _locker.TryEnterWriteLock(EnvironmentSettings.LockAcquisitionTimeout);

        return true;
    }

    /// <summary>
    ///     Enters a read lock.
    /// </summary>
    /// <param name="millisecondsTimeout">The timeout, in milliseconds.</param>
    /// <returns><see langword="true" /> if the lock is entered, <see langword="false" /> otherwise.</returns>
    protected bool EnterWriteLock(int millisecondsTimeout)
    {
        _ = _locker.TryEnterWriteLock(millisecondsTimeout);

        return true;
    }

    /// <summary>
    ///     Enters a read lock.
    /// </summary>
    /// <param name="timeout">The timeout.</param>
    /// <returns><see langword="true" /> if the lock is entered, <see langword="false" /> otherwise.</returns>
    protected bool EnterWriteLock(TimeSpan timeout)
    {
        _ = _locker.TryEnterWriteLock(timeout);

        return true;
    }

    /// <summary>
    ///     Exits a write lock.
    /// </summary>
    protected void ExitWriteLock() => _locker.ExitWriteLock();

    /// <summary>
    ///     Enters an upgradeable read lock.
    /// </summary>
    /// <returns><see langword="true" /> if the lock is entered, <see langword="false" /> otherwise.</returns>
    protected bool EnterUpgradeableReadLock()
    {
        _ = _locker.TryEnterUpgradeableReadLock(EnvironmentSettings.LockAcquisitionTimeout);

        return true;
    }

    /// <summary>
    ///     Enters an upgradeable read lock.
    /// </summary>
    /// <param name="millisecondsTimeout">The timeout, in milliseconds.</param>
    /// <returns><see langword="true" /> if the lock is entered, <see langword="false" /> otherwise.</returns>
    protected bool EnterUpgradeableReadLock(int millisecondsTimeout)
    {
        _ = _locker.TryEnterUpgradeableReadLock(millisecondsTimeout);

        return true;
    }

    /// <summary>
    ///     Enters an upgradeable read lock.
    /// </summary>
    /// <param name="timeout">The timeout.</param>
    /// <returns><see langword="true" /> if the lock is entered, <see langword="false" /> otherwise.</returns>
    protected bool EnterUpgradeableReadLock(TimeSpan timeout)
    {
        _ = _locker.TryEnterUpgradeableReadLock(timeout);

        return true;
    }

    /// <summary>
    ///     Exits an upgradeable read lock.
    /// </summary>
    protected void ExitUpgradeableReadLock() => _locker.ExitUpgradeableReadLock();
}