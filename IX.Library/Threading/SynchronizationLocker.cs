namespace IX.Core.Threading;

/// <summary>
///     A synchronization locker base class.
/// </summary>
/// <seealso cref="IDisposable" />
[PublicAPI]
[Obsolete("This class has been deemed obsolete in favor of the value-type lockers.")]
public abstract class SynchronizationLocker : IDisposable
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="SynchronizationLocker" /> class.
    /// </summary>
    /// <param name="locker">The locker.</param>
    internal SynchronizationLocker(IReaderWriterLock? locker) => Locker = locker;

    /// <summary>
    ///     Gets the reader/writer lock to use. This property can be <see langword="null" /> (<see langword="Nothing" /> in
    ///     Visual Basic).
    /// </summary>
    protected IReaderWriterLock? Locker { get; }

    /// <summary>
    ///     Releases the currently-held lock.
    /// </summary>
    public abstract void Dispose();
}