using GlobalThreading = System.Threading;

namespace IX.Library.Threading;

/// <summary>
///     Extension methods for set/reset event classes.
/// </summary>
public static class SetResetEventsExtensions
{
    /// <summary>
    ///     Converts the source <see cref="GlobalThreading.AutoResetEvent" /> to a <see cref="ISetResetEvent" /> abstraction.
    /// </summary>
    /// <param name="source">The source event.</param>
    /// <returns>The abstracted version of the same event.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="source" /> is <see langword="null" /> (
    ///     <see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public static ISetResetEvent AsAbstraction(this GlobalThreading.AutoResetEvent source) =>
        new AutoResetEvent(source ?? throw new ArgumentNullException(nameof(source)));

    /// <summary>
    ///     Converts the source <see cref="GlobalThreading.ManualResetEvent" /> to a <see cref="ISetResetEvent" /> abstraction.
    /// </summary>
    /// <param name="source">The source event.</param>
    /// <returns>The abstracted version of the same event.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="source" /> is <see langword="null" /> (
    ///     <see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public static ISetResetEvent AsAbstraction(this GlobalThreading.ManualResetEvent source) =>
        new ManualResetEvent(source ?? throw new ArgumentNullException(nameof(source)));

    /// <summary>
    ///     Converts the source <see cref="GlobalThreading.ManualResetEventSlim" /> to a <see cref="ISetResetEvent" />
    ///     abstraction.
    /// </summary>
    /// <param name="source">The source event.</param>
    /// <returns>The abstracted version of the same event.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="source" /> is <see langword="null" /> (
    ///     <see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public static ISetResetEvent AsAbstraction(this GlobalThreading.ManualResetEventSlim source) =>
        new ManualResetEventSlim(source ?? throw new ArgumentNullException(nameof(source)));
}