using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace IX.Library.Threading;

/// <summary>
///     A base class for a reader/writer synchronized class.
/// </summary>
/// <seealso cref="ComponentModel.DisposableBase" />
[DataContract(Namespace = Constants.DataContractNamespace)]
public abstract partial class ReaderWriterSynchronizedBase : DisposableBase
{
    private readonly bool _lockInherited;

    private IReaderWriterLock _locker;

    [DataMember]
    [SuppressMessage(
        "ReSharper",
        "InconsistentNaming",
        Justification = "This needs to remain like this for backwards compatibility.")]
    private TimeSpan lockerTimeout;

    /// <summary>
    ///     Initializes a new instance of the <see cref="ReaderWriterSynchronizedBase" /> class.
    /// </summary>
    protected ReaderWriterSynchronizedBase()
    {
        _locker = new ReaderWriterLockSlim();
        lockerTimeout = EnvironmentSettings.LockAcquisitionTimeout;
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ReaderWriterSynchronizedBase" /> class.
    /// </summary>
    /// <param name="locker">The locker.</param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="locker" />
    ///     is <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    protected ReaderWriterSynchronizedBase(IReaderWriterLock? locker)
    {
        _locker = locker ?? throw new ArgumentNullException(nameof(locker));
        _lockInherited = true;
        lockerTimeout = EnvironmentSettings.LockAcquisitionTimeout;
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ReaderWriterSynchronizedBase" /> class.
    /// </summary>
    /// <param name="timeout">The lock timeout duration.</param>
    protected ReaderWriterSynchronizedBase(TimeSpan timeout)
    {
        _locker = new ReaderWriterLockSlim();
        lockerTimeout = timeout;
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ReaderWriterSynchronizedBase" /> class.
    /// </summary>
    /// <param name="locker">The locker.</param>
    /// <param name="timeout">The lock timeout duration.</param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="locker" />
    ///     is <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    protected ReaderWriterSynchronizedBase(
        IReaderWriterLock locker,
        TimeSpan timeout)
    {
        _locker = locker ?? throw new ArgumentNullException(nameof(locker));
        _lockInherited = true;
        lockerTimeout = timeout;
    }

    /// <summary>
    ///     Called when the object is being deserialized, in order to set the locker to a new value.
    /// </summary>
    /// <param name="context">The streaming context.</param>
    [OnDeserializing]
    internal void OnDeserializingMethod(StreamingContext context) =>
        Interlocked.Exchange(
            ref _locker,
            new ReaderWriterLockSlim());

    /// <summary>
    ///     Disposes in the managed context.
    /// </summary>
    protected override void DisposeManagedContext()
    {
        if (!_lockInherited) _locker.Dispose();

        base.DisposeManagedContext();
    }

    /// <summary>
    ///     Attempts to acquire a read lock in the configured time span.
    /// </summary>
    /// <returns>A context-specific disposable object representing the lock.</returns>
    protected ValueSynchronizationLockerRead AcquireReadLock()
    {
        ThrowIfCurrentObjectDisposed();

        return new(
            _locker,
            lockerTimeout);
    }

    /// <summary>
    ///     Invokes using a reader lock.
    /// </summary>
    /// <param name="action">An action that is called.</param>
    protected void ReadLock(Action action)
    {
        ThrowIfCurrentObjectDisposed();
        if (action is null) throw new ArgumentNullException(nameof(action));

        using (new ValueSynchronizationLockerRead(
                   _locker,
                   lockerTimeout))
            action();
    }

    /// <summary>
    ///     Gets a result from an invoker using a reader lock.
    /// </summary>
    /// <param name="action">An action that is called to get the result.</param>
    /// <typeparam name="T">The type of the object to return.</typeparam>
    /// <returns>A disposable object representing the lock.</returns>
    protected T ReadLock<T>(Func<T> action)
    {
        ThrowIfCurrentObjectDisposed();
        if (action is null) throw new ArgumentNullException(nameof(action));

        using (new ValueSynchronizationLockerRead(
                   _locker,
                   lockerTimeout))
            return action();
    }

    /// <summary>
    ///     Attempts to acquire a write lock in the configured time span.
    /// </summary>
    /// <returns>A context-specific disposable object representing the lock.</returns>
    protected ValueSynchronizationLockerWrite AcquireWriteLock()
    {
        ThrowIfCurrentObjectDisposed();

        return new(
            _locker,
            lockerTimeout);
    }

    /// <summary>
    ///     Invokes using a writer lock.
    /// </summary>
    /// <param name="action">An action that is called.</param>
    protected void WriteLock(Action action)
    {
        ThrowIfCurrentObjectDisposed();
        Action localAction = Requires.NotNull(action);

        using (new ValueSynchronizationLockerWrite(
                   _locker,
                   lockerTimeout))
            localAction();
    }

    /// <summary>
    ///     Invokes using a writer lock.
    /// </summary>
    /// <typeparam name="T">The type of item to return.</typeparam>
    /// <param name="action">An action that is called.</param>
    /// <returns>The generated item.</returns>
    protected T WriteLock<T>(Func<T> action)
    {
        ThrowIfCurrentObjectDisposed();
        if (action is null) throw new ArgumentNullException(nameof(action));

        using (new ValueSynchronizationLockerWrite(
                   _locker,
                   lockerTimeout))
            return action();
    }

    /// <summary>
    ///     Attempts to acquire a write lock in the configured time span.
    /// </summary>
    /// <returns>A context-specific disposable object representing the lock.</returns>
    protected ValueSynchronizationLockerReadWrite AcquireReadWriteLock()
    {
        ThrowIfCurrentObjectDisposed();

        return new(
            _locker,
            lockerTimeout);
    }
}