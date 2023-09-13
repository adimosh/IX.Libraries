using System.Diagnostics.CodeAnalysis;
using IX.Core.ComponentModel;
using GlobalThreading = System.Threading;

namespace IX.Core.Threading;

/// <summary>
///     A set/reset event class that implements methods to block and unblock threads based on manual signal interaction.
/// </summary>
/// <seealso cref="ISetResetEvent" />
[PublicAPI]
public class ManualResetEventSlim : DisposableBase,
    ISetResetEvent
{
    private readonly bool eventLocal;

    /// <summary>
    ///     The manual reset event.
    /// </summary>
    [SuppressMessage(
        "IDisposableAnalyzers.Correctness",
        "IDISP006:Implement IDisposable.",
        Justification = "This is properly disposed, but the analyzer can't tell.")]
    private readonly GlobalThreading.ManualResetEventSlim internalResetEvent;

    /// <summary>
    ///     Initializes a new instance of the <see cref="ManualResetEventSlim" /> class.
    /// </summary>
    public ManualResetEventSlim()
    {
        internalResetEvent = new();
        eventLocal = true;
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ManualResetEventSlim" /> class.
    /// </summary>
    /// <param name="initialState">The initial signal state.</param>
    public ManualResetEventSlim(bool initialState)
    {
        internalResetEvent = new(initialState);
        eventLocal = true;
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ManualResetEventSlim" /> class.
    /// </summary>
    /// <param name="manualResetEvent">The manual reset event.</param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="manualResetEvent" />
    ///     is <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public ManualResetEventSlim(GlobalThreading.ManualResetEventSlim manualResetEvent) =>
        Requires.NotNull(
            out internalResetEvent,
            manualResetEvent);

    /// <summary>
    ///     Performs an implicit conversion from <see cref="ManualResetEventSlim" /> to
    ///     <see cref="GlobalThreading.ManualResetEventSlim" />.
    /// </summary>
    /// <param name="manualResetEvent">The manual reset event.</param>
    /// <returns>The result of the conversion.</returns>
    public static implicit operator GlobalThreading.ManualResetEventSlim(ManualResetEventSlim manualResetEvent) =>
        Requires.NotNull(manualResetEvent)
            .internalResetEvent;

    /// <summary>
    ///     Performs an implicit conversion from <see cref="ManualResetEventSlim" /> to
    ///     <see cref="GlobalThreading.ManualResetEventSlim" />.
    /// </summary>
    /// <param name="manualResetEvent">The manual reset event.</param>
    /// <returns>The result of the conversion.</returns>
    public static implicit operator ManualResetEventSlim(GlobalThreading.ManualResetEventSlim manualResetEvent) =>
        new(manualResetEvent);

    /// <summary>
    ///     Gets the awaiter for this event, so that it can be awaited on using &quot;await mre;&quot;.
    /// </summary>
    /// <returns>An awaiter that works the same as <see cref="WaitOne()" />, continuing on a different thread.</returns>
    public SetResetEventAwaiter GetAwaiter() => new(this);

    /// <summary>
    ///     Sets the state of this event instance to non-signaled. Any thread entering a wait from this point will block.
    /// </summary>
    /// <returns><see langword="true" /> if the signal has been reset, <see langword="false" /> otherwise.</returns>
    public bool Reset()
    {
        internalResetEvent.Reset();

        return true;
    }

    /// <summary>
    ///     Sets the state of this event instance to signaled. Any waiting thread will unblock.
    /// </summary>
    /// <returns><see langword="true" /> if the signal has been set, <see langword="false" /> otherwise.</returns>
    public bool Set()
    {
        internalResetEvent.Set();

        return true;
    }

    /// <summary>
    ///     Enters a wait period and, should there be no signal set, blocks the thread calling.
    /// </summary>
    public void WaitOne() => internalResetEvent.Wait();

    /// <summary>
    ///     Enters a wait period and, should there be no signal set, blocks the thread calling.
    /// </summary>
    /// <param name="millisecondsTimeout">The timeout period, in milliseconds.</param>
    /// <returns>
    ///     <see langword="true" /> if the event is set within the timeout period, <see langword="false" /> if the timeout
    ///     is reached.
    /// </returns>
    public bool WaitOne(int millisecondsTimeout) =>
        internalResetEvent.Wait(TimeSpan.FromMilliseconds(millisecondsTimeout));

    /// <summary>
    ///     Enters a wait period and, should there be no signal set, blocks the thread calling.
    /// </summary>
    /// <param name="millisecondsTimeout">The timeout period, in milliseconds.</param>
    /// <returns>
    ///     <see langword="true" /> if the event is set within the timeout period, <see langword="false" /> if the timeout
    ///     is reached.
    /// </returns>
    public bool WaitOne(double millisecondsTimeout) =>
        internalResetEvent.Wait(TimeSpan.FromMilliseconds(millisecondsTimeout));

    /// <summary>
    ///     Enters a wait period and, should there be no signal set, blocks the thread calling.
    /// </summary>
    /// <param name="timeout">The timeout period.</param>
    /// <returns>
    ///     <see langword="true" /> if the event is set within the timeout period, <see langword="false" /> if the timeout
    ///     is reached.
    /// </returns>
    public bool WaitOne(TimeSpan timeout) => internalResetEvent.Wait(timeout);

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
        internalResetEvent.Wait(TimeSpan.FromMilliseconds(millisecondsTimeout));

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
        internalResetEvent.Wait(TimeSpan.FromMilliseconds(millisecondsTimeout));

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
        internalResetEvent.Wait(timeout);

    /// <summary>
    ///     Enters a wait period and, should there be no signal set, blocks the thread calling.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>
    ///     A potentially awaitable value task.
    /// </returns>
    public async ValueTask WaitOneAsync(CancellationToken cancellationToken = default) =>
        _ = await internalResetEvent.WaitHandle.WaitOneAsync(
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
        internalResetEvent.WaitHandle.WaitOneAsync(
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
        internalResetEvent.WaitHandle.WaitOneAsync(
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
        internalResetEvent.WaitHandle.WaitOneAsync(
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
        internalResetEvent.WaitHandle.WaitOneAsync(
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
        internalResetEvent.WaitHandle.WaitOneAsync(
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
        internalResetEvent.WaitHandle.WaitOneAsync(
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
    ///     Converts to a <see cref="GlobalThreading.ManualResetEventSlim" />.
    /// </summary>
    /// <returns>The <see cref="GlobalThreading.ManualResetEventSlim" /> that is encapsulated in this instance.</returns>
    public GlobalThreading.ManualResetEventSlim ToManualResetEventSlim() => internalResetEvent;

    /// <summary>
    ///     Disposes in the managed context.
    /// </summary>
    protected override void DisposeManagedContext()
    {
        base.DisposeManagedContext();

        if (eventLocal)
        {
            internalResetEvent.Dispose();
        }
    }
}