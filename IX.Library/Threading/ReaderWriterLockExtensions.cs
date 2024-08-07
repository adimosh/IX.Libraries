using GlobalThreading = System.Threading;

namespace IX.Library.Threading;

/// <summary>
///     Extension methods for reader/writer lock classes.
/// </summary>
public static class ReaderWriterLockExtensions
{
    /// <summary>
    ///     Converts the source <see cref="GlobalThreading.ReaderWriterLockSlim" /> to a <see cref="IReaderWriterLock" />
    ///     abstraction.
    /// </summary>
    /// <param name="source">The source locker.</param>
    /// <returns>The abstracted version of the same event.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="source" /> is <see langword="null" /> (
    ///     <see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public static IReaderWriterLock AsAbstraction(this GlobalThreading.ReaderWriterLockSlim source) =>
        new ReaderWriterLockSlim(source ?? throw new ArgumentNullException(nameof(source)));
}