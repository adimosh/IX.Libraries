namespace IX.Library.Threading;

/// <summary>
///     A class that provides methods and extensions to fire events.
/// </summary>
[PublicAPI]
public static class Fire
{
    /// <summary>
    ///     Runs the specified ticker delegate periodically.
    /// </summary>
    /// <param name="tickerDelegate">The ticker delegate.</param>
    /// <param name="milliseconds">The milliseconds.</param>
    /// <returns>An interruptible handle for external control of the ticker.</returns>
    public static IInterruptible Periodically(
        FirePeriodicallyTicker tickerDelegate,
        int milliseconds) =>
        new FirePeriodicallyContext(
            tickerDelegate,
            null,
            milliseconds);

    /// <summary>
    ///     Runs the specified ticker delegate periodically.
    /// </summary>
    /// <param name="tickerDelegate">The ticker delegate.</param>
    /// <param name="timeSpan">The time span.</param>
    /// <returns>An interruptible handle for external control of the ticker.</returns>
    public static IInterruptible Periodically(
        FirePeriodicallyTicker tickerDelegate,
        TimeSpan timeSpan) =>
        new FirePeriodicallyContext(
            tickerDelegate,
            null,
            timeSpan);

    /// <summary>
    ///     Runs the specified ticker delegate periodically.
    /// </summary>
    /// <param name="tickerDelegate">The ticker delegate.</param>
    /// <param name="initialDelay">The initial delay.</param>
    /// <param name="timeSpan">The time span.</param>
    /// <returns>An interruptible handle for external control of the ticker.</returns>
    public static IInterruptible Periodically(
        FirePeriodicallyTicker tickerDelegate,
        TimeSpan initialDelay,
        TimeSpan timeSpan) =>
        new FirePeriodicallyContext(
            tickerDelegate,
            null,
            initialDelay,
            timeSpan);

    /// <summary>
    ///     Runs the specified ticker delegate periodically.
    /// </summary>
    /// <param name="tickerDelegate">The ticker delegate.</param>
    /// <param name="payload">The payload.</param>
    /// <param name="milliseconds">The milliseconds.</param>
    /// <returns>An interruptible handle for external control of the ticker.</returns>
    public static IInterruptible Periodically(
        FirePeriodicallyTicker tickerDelegate,
        object payload,
        int milliseconds) =>
        new FirePeriodicallyContext(
            tickerDelegate,
            payload,
            milliseconds);

    /// <summary>
    ///     Runs the specified ticker delegate periodically.
    /// </summary>
    /// <param name="tickerDelegate">The ticker delegate.</param>
    /// <param name="payload">The payload.</param>
    /// <param name="timeSpan">The time span.</param>
    /// <returns>An interruptible handle for external control of the ticker.</returns>
    public static IInterruptible Periodically(
        FirePeriodicallyTicker tickerDelegate,
        object payload,
        TimeSpan timeSpan) =>
        new FirePeriodicallyContext(
            tickerDelegate,
            payload,
            timeSpan);

    /// <summary>
    ///     Runs the specified ticker delegate periodically.
    /// </summary>
    /// <param name="tickerDelegate">The ticker delegate.</param>
    /// <param name="payload">The payload.</param>
    /// <param name="initialDelay">The initial delay.</param>
    /// <param name="timeSpan">The time span.</param>
    /// <returns>An interruptible handle for external control of the ticker.</returns>
    public static IInterruptible Periodically(
        FirePeriodicallyTicker tickerDelegate,
        object payload,
        TimeSpan initialDelay,
        TimeSpan timeSpan) =>
        new FirePeriodicallyContext(
            tickerDelegate,
            payload,
            initialDelay,
            timeSpan);
}