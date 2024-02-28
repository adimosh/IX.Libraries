using System.Diagnostics.CodeAnalysis;

using GlobalThreading = System.Threading;

namespace IX.Library.Threading;

/// <summary>
///     A wrapper over <see cref="GlobalThreading.ReaderWriterLockSlim" />, compatible with
///     <see cref="IReaderWriterLock" />.
/// </summary>
/// <seealso cref="IReaderWriterLock" />
public class ReaderWriterLockSlim : DisposableBase,
    IReaderWriterLock
{
    [SuppressMessage(
        "IDisposableAnalyzers.Correctness",
        "IDISP008:Don't assign member with injected and created disposables.",
        Justification = "We're doing proper management of resources, but the analyzer can't tell.")]
    private readonly GlobalThreading.ReaderWriterLockSlim _locker;

    private readonly bool _lockerLocal;

    /// <summary>
    ///     Initializes a new instance of the <see cref="ReaderWriterLockSlim" /> class.
    /// </summary>
    public ReaderWriterLockSlim()
    {
        _locker = new();
        _lockerLocal = true;
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ReaderWriterLockSlim" /> class.
    /// </summary>
    /// <param name="lockRecursionPolicy">The lock recursion policy.</param>
    public ReaderWriterLockSlim(LockRecursionPolicy lockRecursionPolicy)
    {
        _locker = new(lockRecursionPolicy);
        _lockerLocal = true;
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ReaderWriterLockSlim" /> class.
    /// </summary>
    /// <param name="locker">The existing locker.</param>
    public ReaderWriterLockSlim(GlobalThreading.ReaderWriterLockSlim locker) => _locker = locker;

    /// <summary>
    ///     Gets a value indicating whether the current thread has a read lock held.
    /// </summary>
    /// <value><see langword="true" /> if the current thread has a read lock held; otherwise, <see langword="false" />.</value>
    public bool IsReadLockHeld =>
        InvokeIfNotDisposed(
            lck => lck.IsReadLockHeld,
            _locker);

    /// <summary>
    ///     Gets a value indicating whether the current thread has an upgradeable lock held.
    /// </summary>
    /// <value><see langword="true" /> if the current thread has an upgradeable lock held; otherwise, <see langword="false" />.</value>
    public bool IsUpgradeableReadLockHeld =>
        InvokeIfNotDisposed(
            lck => lck.IsUpgradeableReadLockHeld,
            _locker);

    /// <summary>
    ///     Gets a value indicating whether the current thread has a write lock held.
    /// </summary>
    /// <value><see langword="true" /> if the current thread has a write lock held; otherwise, <see langword="false" />.</value>
    public bool IsWriteLockHeld =>
        InvokeIfNotDisposed(
            lck => lck.IsWriteLockHeld,
            _locker);

    /// <summary>
    ///     Performs an implicit conversion from <see cref="GlobalThreading.ReaderWriterLockSlim" /> to
    ///     <see cref="ReaderWriterLockSlim" />.
    /// </summary>
    /// <param name="lock">The locker.</param>
    /// <returns>The result of the conversion.</returns>
    public static implicit operator ReaderWriterLockSlim(GlobalThreading.ReaderWriterLockSlim @lock) => new(@lock);

    /// <summary>
    ///     Performs an implicit conversion from <see cref="ReaderWriterLockSlim" /> to
    ///     <see cref="GlobalThreading.ReaderWriterLockSlim" />.
    /// </summary>
    /// <param name="lock">The locker.</param>
    /// <returns>The result of the conversion.</returns>
    public static implicit operator GlobalThreading.ReaderWriterLockSlim(ReaderWriterLockSlim @lock) =>
        Requires.NotNull(
                @lock,
                nameof(@lock))
            ._locker;

    /// <summary>
    ///     Enters a read lock.
    /// </summary>
    public void EnterReadLock() =>
        InvokeIfNotDisposed(
            lck => lck.EnterReadLock(),
            _locker);

    /// <summary>
    ///     Enters an upgradeable read lock.
    /// </summary>
    public void EnterUpgradeableReadLock() =>
        InvokeIfNotDisposed(
            lck => lck.EnterUpgradeableReadLock(),
            _locker);

    /// <summary>
    ///     Enters the write lock.
    /// </summary>
    public void EnterWriteLock() =>
        InvokeIfNotDisposed(
            lck => lck.EnterWriteLock(),
            _locker);

    /// <summary>
    ///     Exits a read lock.
    /// </summary>
    public void ExitReadLock() =>
        InvokeIfNotDisposed(
            lck => lck.ExitReadLock(),
            _locker);

    /// <summary>
    ///     Exits an upgradeable read lock.
    /// </summary>
    public void ExitUpgradeableReadLock() =>
        InvokeIfNotDisposed(
            lck => lck.ExitUpgradeableReadLock(),
            _locker);

    /// <summary>
    ///     Exits a write lock.
    /// </summary>
    public void ExitWriteLock() =>
        InvokeIfNotDisposed(
            lck => lck.ExitWriteLock(),
            _locker);

    /// <summary>
    ///     Tries to enter a read lock.
    /// </summary>
    /// <param name="millisecondsTimeout">The timeout, in milliseconds.</param>
    /// <returns>
    ///     <see langword="true" /> if the lock has been acquired for the calling thread, <see langword="false" />
    ///     otherwise.
    /// </returns>
    public bool TryEnterReadLock(int millisecondsTimeout) =>
        InvokeIfNotDisposed(
            (
                lck,
                timeout) => lck.TryEnterReadLock(timeout),
            _locker,
            millisecondsTimeout);

    /// <summary>
    ///     Tries to enter a read lock.
    /// </summary>
    /// <param name="timeout">The timeout.</param>
    /// <returns>
    ///     <see langword="true" /> if the lock has been acquired for the calling thread, <see langword="false" />
    ///     otherwise.
    /// </returns>
    public bool TryEnterReadLock(TimeSpan timeout) =>
        InvokeIfNotDisposed(
            (
                lck,
                timeoutInternal) => lck.TryEnterReadLock(timeoutInternal),
            _locker,
            timeout);

    /// <summary>
    ///     Tries to enter an upgradeable read lock.
    /// </summary>
    /// <param name="millisecondsTimeout">The timeout, in milliseconds.</param>
    /// <returns>
    ///     <see langword="true" /> if the lock has been acquired for the calling thread, <see langword="false" />
    ///     otherwise.
    /// </returns>
    public bool TryEnterUpgradeableReadLock(int millisecondsTimeout) =>
        InvokeIfNotDisposed(
            (
                lck,
                timeout) => lck.TryEnterUpgradeableReadLock(timeout),
            _locker,
            millisecondsTimeout);

    /// <summary>
    ///     Tries to enter an upgradeable read lock.
    /// </summary>
    /// <param name="timeout">The timeout.</param>
    /// <returns>
    ///     <see langword="true" /> if the lock has been acquired for the calling thread, <see langword="false" />
    ///     otherwise.
    /// </returns>
    public bool TryEnterUpgradeableReadLock(TimeSpan timeout) =>
        InvokeIfNotDisposed(
            (
                lck,
                timeoutInternal) => lck.TryEnterUpgradeableReadLock(timeoutInternal),
            _locker,
            timeout);

    /// <summary>
    ///     Tries to enter a write lock.
    /// </summary>
    /// <param name="millisecondsTimeout">The timeout, in milliseconds.</param>
    /// <returns>
    ///     <see langword="true" /> if the lock has been acquired for the calling thread, <see langword="false" />
    ///     otherwise.
    /// </returns>
    public bool TryEnterWriteLock(int millisecondsTimeout) =>
        InvokeIfNotDisposed(
            (
                lck,
                timeout) => lck.TryEnterWriteLock(timeout),
            _locker,
            millisecondsTimeout);

    /// <summary>
    ///     Tries to enter a write lock.
    /// </summary>
    /// <param name="timeout">The timeout.</param>
    /// <returns>
    ///     <see langword="true" /> if the lock has been acquired for the calling thread, <see langword="false" />
    ///     otherwise.
    /// </returns>
    public bool TryEnterWriteLock(TimeSpan timeout) =>
        InvokeIfNotDisposed(
            (
                lck,
                timeoutInternal) => lck.TryEnterWriteLock(timeoutInternal),
            _locker,
            timeout);

    /// <summary>
    ///     Converts to a <see cref="GlobalThreading.ReaderWriterLockSlim" />.
    /// </summary>
    /// <returns>The <see cref="GlobalThreading.ReaderWriterLockSlim" /> that is encapsulated in this instance.</returns>
    public GlobalThreading.ReaderWriterLockSlim ToReaderWriterLockSlim() => _locker;

    /// <summary>
    ///     Disposes in the managed context.
    /// </summary>
    protected override void DisposeManagedContext()
    {
        base.DisposeManagedContext();

        if (_lockerLocal)
        {
            _locker.Dispose();
        }
    }
}