using IX.Library.Contracts;

using System.Diagnostics.CodeAnalysis;

namespace IX.Library.Threading;

/// <summary>
///     A ticker delegate.
/// </summary>
/// <param name="tick">The tick index.</param>
/// <param name="interrupter">
///     The interrupter object, should the periodical firing mechanism be requested to be
///     interrupted.
/// </param>
/// <param name="state">The state.</param>
[PublicAPI]
public delegate void FirePeriodicallyTicker(
    int tick,
    IInterruptible interrupter,
    object? state);

internal sealed class FirePeriodicallyContext : DisposableBase,
    IInterruptible
{
    private readonly object? _state;

    [SuppressMessage(
        "IDisposableAnalyzers.Correctness",
        "IDISP006:Implement IDisposable.",
        Justification = "It is implemented, the analyzer cannot figure it out automatically.")]
    private readonly Timer _timer;

    private readonly TimeSpan _timeSpan;

    private int _iteration;

    internal FirePeriodicallyContext(
        FirePeriodicallyTicker tickerDelegate,
        object? state,
        int milliseconds)
        : this(
            tickerDelegate,
            state,
            TimeSpan.FromMilliseconds(milliseconds)) { }

    internal FirePeriodicallyContext(
        FirePeriodicallyTicker tickerDelegate,
        object? state,
        TimeSpan timeSpan)
        : this(
            tickerDelegate,
            state,
            TimeSpan.Zero,
            timeSpan) { }

    internal FirePeriodicallyContext(
        FirePeriodicallyTicker tickerDelegate,
        object? state,
        TimeSpan initialDelay,
        TimeSpan timeSpan)
    {
        _state = state;
        _timeSpan = timeSpan;
        _timer = new(
            TimerTick!,
            Requires.NotNull(tickerDelegate),
            initialDelay,
            timeSpan);
    }

    /// <summary>
    ///     Interrupts this instance.
    /// </summary>
    public void Interrupt() =>
        _timer.Change(
            Timeout.Infinite,
            Timeout.Infinite);

    /// <summary>
    ///     Resumes this instance.
    /// </summary>
    public void Resume() =>
        _timer.Change(
            TimeSpan.Zero,
            _timeSpan);

    /// <summary>
    ///     Disposes in the general (managed and unmanaged) context.
    /// </summary>
    protected override void DisposeGeneralContext()
    {
        base.DisposeGeneralContext();

        _timer.Dispose();
    }

    private void TimerTick(object stateObject)
    {
        var ticker = (FirePeriodicallyTicker)stateObject;

        _ = Interlocked.Increment(ref _iteration);

        ticker(
            _iteration,
            this,
            _state);
    }
}