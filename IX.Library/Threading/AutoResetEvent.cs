using System.Diagnostics.CodeAnalysis;

using GlobalThreading = System.Threading;

namespace IX.Library.Threading;

/// <summary>
///     A set/reset event class that implements methods to block threads and unblock automatically.
/// </summary>
/// <seealso cref="ISetResetEvent" />
public class AutoResetEvent : DisposableBase,
    ISetResetEvent
{
    private readonly bool _eventLocal;

    /// <summary>
    ///     The auto-reset event.
    /// </summary>
    [SuppressMessage(
        "IDisposableAnalyzers.Correctness",
        "IDISP006:Implement IDisposable.",
        Justification = "IDisposable is correctly implemented in base class.")]
    private readonly GlobalThreading.AutoResetEvent _sre;

    /// <summary>
    ///     Initializes a new instance of the <see cref="AutoResetEvent" /> class.
    /// </summary>
    public AutoResetEvent()
        : this(false) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="AutoResetEvent" /> class.
    /// </summary>
    /// <param name="initialState">The initial signal state.</param>
    public AutoResetEvent(bool initialState)
    {
        _sre = new(initialState);
        _eventLocal = true;
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="AutoResetEvent" /> class.
    /// </summary>
    /// <param name="autoResetEvent">The automatic reset event to wrap around.</param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="autoResetEvent" /> is <see langword="null" /> (
    ///     <see langword="Nothing" /> in Visual Basic).
    /// </exception>
    [SuppressMessage(
        "IDisposableAnalyzers.Correctness",
        "IDISP003:Dispose previous before re-assigning.",
        Justification = "This is a constructor, the analyzer is thrown off.")]
    public AutoResetEvent(GlobalThreading.AutoResetEvent autoResetEvent) =>
        _sre = autoResetEvent ?? throw new ArgumentNullException(nameof(autoResetEvent));

    /// <summary>
    ///     Performs an implicit conversion from <see cref="GlobalThreading.AutoResetEvent" /> to
    ///     <see cref="AutoResetEvent" />.
    /// </summary>
    /// <param name="autoResetEvent">The automatic reset event.</param>
    /// <returns>The result of the conversion.</returns>
    public static implicit operator AutoResetEvent(GlobalThreading.AutoResetEvent autoResetEvent) =>
        new(autoResetEvent);

    /// <summary>
    ///     Performs an implicit conversion from <see cref="AutoResetEvent" /> to
    ///     <see cref="GlobalThreading.AutoResetEvent" />.
    /// </summary>
    /// <param name="autoResetEvent">The automatic reset event.</param>
    /// <returns>The result of the conversion.</returns>
    public static implicit operator GlobalThreading.AutoResetEvent(AutoResetEvent autoResetEvent) =>
        (autoResetEvent ?? throw new ArgumentNullException(nameof(autoResetEvent)))
            ._sre;

    /// <summary>
    ///     Gets the awaiter for this event, so that it can be awaited on using &quot;await mre;&quot;.
    /// </summary>
    /// <returns>An awaiter that works the same as <see cref="WaitOne()" />, continuing on a different thread.</returns>
    public SetResetEventAwaiter GetAwaiter() => new(this);

    /// <summary>
    ///     Sets the state of this event instance to non-signaled. Any thread entering a wait from this point will block.
    /// </summary>
    /// <returns><see langword="true" /> if the signal has been reset, <see langword="false" /> otherwise.</returns>
    public bool Reset() => _sre.Reset();

    /// <summary>
    ///     Sets the state of this event instance to signaled. Any waiting thread will unblock.
    /// </summary>
    /// <returns><see langword="true" /> if the signal has been set, <see langword="false" /> otherwise.</returns>
    public bool Set() => _sre.Set();

    /// <summary>
    ///     Enters a wait period and, should there be no signal set, blocks the thread calling.
    /// </summary>
    public void WaitOne() => _sre.WaitOne();

    /// <summary>
    ///     Enters a wait period and, should there be no signal set, blocks the thread calling.
    /// </summary>
    /// <param name="millisecondsTimeout">The timeout period, in milliseconds.</param>
    /// <returns>
    ///     <see langword="true" /> if the event is set within the timeout period, <see langword="false" /> if the timeout
    ///     is reached.
    /// </returns>
    public bool WaitOne(int millisecondsTimeout) => _sre.WaitOne(TimeSpan.FromMilliseconds(millisecondsTimeout));

    /// <summary>
    ///     Enters a wait period and, should there be no signal set, blocks the thread calling.
    /// </summary>
    /// <param name="millisecondsTimeout">The timeout period, in milliseconds.</param>
    /// <returns>
    ///     <see langword="true" /> if the event is set within the timeout period, <see langword="false" /> if the timeout
    ///     is reached.
    /// </returns>
    public bool WaitOne(double millisecondsTimeout) => _sre.WaitOne(TimeSpan.FromMilliseconds(millisecondsTimeout));

    /// <summary>
    ///     Enters a wait period and, should there be no signal set, blocks the thread calling.
    /// </summary>
    /// <param name="timeout">The timeout period.</param>
    /// <returns>
    ///     <see langword="true" /> if the event is set within the timeout period, <see langword="false" /> if the timeout
    ///     is reached.
    /// </returns>
    public bool WaitOne(TimeSpan timeout) => _sre.WaitOne(timeout);

    /// <summary>
    ///     Enters a wait period and, should there be no signal set, blocks the thread calling.
    /// </summary>
    /// <param name="millisecondsTimeout">The timeout period, in milliseconds.</param>
    /// <param name="exitSynchronizationDomain">
    ///     If set to <see langword="true" />, the synchronization domain is exited before
    ///     the call.
    /// </param>
    /// <returns>
    ///     <see langword="true" /> if the event is set within the timeout period, <see langword="false" /> if the timeout
    ///     is reached.
    /// </returns>
    public bool WaitOne(
        int millisecondsTimeout,
        bool exitSynchronizationDomain) =>
        _sre.WaitOne(
            TimeSpan.FromMilliseconds(millisecondsTimeout),
            exitSynchronizationDomain);

    /// <summary>
    ///     Enters a wait period and, should there be no signal set, blocks the thread calling.
    /// </summary>
    /// <param name="millisecondsTimeout">The timeout period, in milliseconds.</param>
    /// <param name="exitSynchronizationDomain">
    ///     If set to <see langword="true" />, the synchronization domain is exited before
    ///     the call.
    /// </param>
    /// <returns>
    ///     <see langword="true" /> if the event is set within the timeout period, <see langword="false" /> if the timeout
    ///     is reached.
    /// </returns>
    public bool WaitOne(
        double millisecondsTimeout,
        bool exitSynchronizationDomain) =>
        _sre.WaitOne(
            TimeSpan.FromMilliseconds(millisecondsTimeout),
            exitSynchronizationDomain);

    /// <summary>
    ///     Enters a wait period and, should there be no signal set, blocks the thread calling.
    /// </summary>
    /// <param name="timeout">The timeout period.</param>
    /// <param name="exitSynchronizationDomain">
    ///     If set to <see langword="true" />, the synchronization domain is exited before
    ///     the call.
    /// </param>
    /// <returns>
    ///     <see langword="true" /> if the event is set within the timeout period, <see langword="false" /> if the timeout
    ///     is reached.
    /// </returns>
    public bool WaitOne(
        TimeSpan timeout,
        bool exitSynchronizationDomain) =>
        _sre.WaitOne(
            timeout,
            exitSynchronizationDomain);

    /// <summary>
    ///     Enters a wait period and, should there be no signal set, blocks the thread calling.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A potentially awaitable value task.</returns>
    [SuppressMessage(
        "Performance",
        "HAA0603:Delegate allocation from a method group",
        Justification = "Unavoidable.")]
    public async ValueTask WaitOneAsync(CancellationToken cancellationToken = default) =>
        _ = await _sre.WaitOneAsync(
            Timeout.InfiniteTimeSpan,
            cancellationToken);

    /// <summary>
    ///     Enters a wait period and, should there be no signal set, blocks the thread calling.
    /// </summary>
    /// <param name="millisecondsTimeout">The timeout period, in milliseconds.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>
    ///     <see langword="true" /> if the event is set within the timeout period, <see langword="false" /> if the timeout
    ///     is reached.
    /// </returns>
    public ValueTask<bool> WaitOneAsync(
        int millisecondsTimeout,
        CancellationToken cancellationToken = default) =>
        _sre.WaitOneAsync(
            millisecondsTimeout,
            cancellationToken);

    /// <summary>
    ///     Enters a wait period and, should there be no signal set, blocks the thread calling.
    /// </summary>
    /// <param name="millisecondsTimeout">The timeout period, in milliseconds.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>
    ///     <see langword="true" /> if the event is set within the timeout period, <see langword="false" /> if the timeout
    ///     is reached.
    /// </returns>
    public ValueTask<bool> WaitOneAsync(
        double millisecondsTimeout,
        CancellationToken cancellationToken = default) =>
        _sre.WaitOneAsync(
            millisecondsTimeout,
            cancellationToken);

    /// <summary>
    ///     Enters a wait period and, should there be no signal set, blocks the thread calling.
    /// </summary>
    /// <param name="timeout">The timeout period.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>
    ///     <see langword="true" /> if the event is set within the timeout period, <see langword="false" /> if the timeout
    ///     is reached.
    /// </returns>
    public ValueTask<bool> WaitOneAsync(
        TimeSpan timeout,
        CancellationToken cancellationToken = default) =>
        _sre.WaitOneAsync(
            timeout,
            cancellationToken);

    /// <summary>
    ///     Enters a wait period and, should there be no signal set, blocks the thread calling.
    /// </summary>
    /// <param name="millisecondsTimeout">The timeout period, in milliseconds.</param>
    /// <param name="exitSynchronizationDomain">
    ///     If set to <see langword="true" />, the synchronization domain is exited before
    ///     the call.
    /// </param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>
    ///     <see langword="true" /> if the event is set within the timeout period, <see langword="false" /> if the timeout
    ///     is reached.
    /// </returns>
    public ValueTask<bool> WaitOneAsync(
        int millisecondsTimeout,
        bool exitSynchronizationDomain,
        CancellationToken cancellationToken = default) =>
        _sre.WaitOneAsync(
            millisecondsTimeout,
            cancellationToken);

    /// <summary>
    ///     Enters a wait period and, should there be no signal set, blocks the thread calling.
    /// </summary>
    /// <param name="millisecondsTimeout">The timeout period, in milliseconds.</param>
    /// <param name="exitSynchronizationDomain">
    ///     If set to <see langword="true" />, the synchronization domain is exited before
    ///     the call.
    /// </param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>
    ///     <see langword="true" /> if the event is set within the timeout period, <see langword="false" /> if the timeout
    ///     is reached.
    /// </returns>
    public ValueTask<bool> WaitOneAsync(
        double millisecondsTimeout,
        bool exitSynchronizationDomain,
        CancellationToken cancellationToken = default) =>
        _sre.WaitOneAsync(
            millisecondsTimeout,
            cancellationToken);

    /// <summary>
    ///     Enters a wait period and, should there be no signal set, blocks the thread calling.
    /// </summary>
    /// <param name="timeout">The timeout period.</param>
    /// <param name="exitSynchronizationDomain">
    ///     If set to <see langword="true" />, the synchronization domain is exited before
    ///     the call.
    /// </param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>
    ///     <see langword="true" /> if the event is set within the timeout period, <see langword="false" /> if the timeout
    ///     is reached.
    /// </returns>
    public ValueTask<bool> WaitOneAsync(
        TimeSpan timeout,
        bool exitSynchronizationDomain,
        CancellationToken cancellationToken = default) =>
        _sre.WaitOneAsync(
            timeout,
            cancellationToken);

    /// <summary>
    ///     Gets the awaiter for this event, with a timeout.
    /// </summary>
    /// <param name="timeout">The timeout to wait until expiring.</param>
    /// <returns>An awaiter that works the same as <see cref="WaitOne(TimeSpan)" />, continuing on a different thread.</returns>
    public SetResetEventAwaiterWithTimeout WithTimeout(TimeSpan timeout) =>
        new(
            this,
            timeout);

    /// <summary>
    ///     Gets the awaiter for this event, with a timeout.
    /// </summary>
    /// <param name="timeout">The timeout to wait until expiring.</param>
    /// <returns>An awaiter that works the same as <see cref="WaitOne(double)" />, continuing on a different thread.</returns>
    public SetResetEventAwaiterWithTimeout WithTimeout(double timeout) =>
        new(
            this,
            timeout);

    /// <summary>
    ///     Gets the awaiter for this event, with a timeout.
    /// </summary>
    /// <param name="timeout">The timeout to wait until expiring.</param>
    /// <returns>An awaiter that works the same as <see cref="WaitOne(int)" />, continuing on a different thread.</returns>
    public SetResetEventAwaiterWithTimeout WithTimeout(int timeout) =>
        new(
            this,
            timeout);

    /// <summary>
    ///     Converts to a <see cref="GlobalThreading.ManualResetEvent" />.
    /// </summary>
    /// <returns>The <see cref="GlobalThreading.ManualResetEvent" /> that is encapsulated in this instance.</returns>
    public GlobalThreading.AutoResetEvent ToAutoResetEvent() => _sre;

    /// <summary>
    ///     Disposes in the managed context.
    /// </summary>
    protected override void DisposeManagedContext()
    {
        base.DisposeManagedContext();

        if (_eventLocal)
        {
            _sre.Dispose();
        }
    }
}