using System.Diagnostics.CodeAnalysis;

namespace IX.Library.Threading;

/// <summary>
///     An abstraction contract for set/reset events.
/// </summary>
/// <seealso cref="IDisposable" />
[PublicAPI]
public interface ISetResetEvent : IDisposable
{
    /// <summary>
    ///     Sets the state of this event instance to signaled. Any waiting thread will unblock.
    /// </summary>
    /// <returns><see langword="true" /> if the signal has been set, <see langword="false" /> otherwise.</returns>
    [SuppressMessage(
        "Naming",
        "CA1716:Identifiers should not match keywords",
        Justification = "This is the proper naming for the method.")]
    bool Set();

    /// <summary>
    ///     Sets the state of this event instance to non-signaled. Any thread entering a wait from this point will block.
    /// </summary>
    /// <returns><see langword="true" /> if the signal has been reset, <see langword="false" /> otherwise.</returns>
    bool Reset();

    /// <summary>
    ///     Enters a wait period and, should there be no signal set, blocks the thread calling.
    /// </summary>
    void WaitOne();

    /// <summary>
    ///     Enters a wait period and, should there be no signal set, blocks the thread calling.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>
    ///     A potentially awaitable value task.
    /// </returns>
    ValueTask WaitOneAsync(CancellationToken cancellationToken = default);

    /// <summary>
    ///     Enters a wait period and, should there be no signal set, blocks the thread calling.
    /// </summary>
    /// <param name="millisecondsTimeout">The timeout period, in milliseconds.</param>
    /// <returns>
    ///     <see langword="true" /> if the event is set within the timeout period, <see langword="false" /> if the timeout
    ///     is reached.
    /// </returns>
    bool WaitOne(int millisecondsTimeout);

    /// <summary>
    ///     Enters a wait period and, should there be no signal set, blocks the thread calling.
    /// </summary>
    /// <param name="millisecondsTimeout">The timeout period, in milliseconds.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>
    ///     <see langword="true" /> if the event is set within the timeout period, <see langword="false" /> if the timeout
    ///     is reached.
    /// </returns>
    ValueTask<bool> WaitOneAsync(
        int millisecondsTimeout,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Enters a wait period and, should there be no signal set, blocks the thread calling.
    /// </summary>
    /// <param name="millisecondsTimeout">The timeout period, in milliseconds.</param>
    /// <returns>
    ///     <see langword="true" /> if the event is set within the timeout period, <see langword="false" /> if the timeout
    ///     is reached.
    /// </returns>
    bool WaitOne(double millisecondsTimeout);

    /// <summary>
    ///     Enters a wait period and, should there be no signal set, blocks the thread calling.
    /// </summary>
    /// <param name="millisecondsTimeout">The timeout period, in milliseconds.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>
    ///     <see langword="true" /> if the event is set within the timeout period, <see langword="false" /> if the timeout
    ///     is reached.
    /// </returns>
    ValueTask<bool> WaitOneAsync(
        double millisecondsTimeout,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Enters a wait period and, should there be no signal set, blocks the thread calling.
    /// </summary>
    /// <param name="timeout">The timeout period.</param>
    /// <returns>
    ///     <see langword="true" /> if the event is set within the timeout period, <see langword="false" /> if the timeout
    ///     is reached.
    /// </returns>
    bool WaitOne(TimeSpan timeout);

    /// <summary>
    ///     Enters a wait period and, should there be no signal set, blocks the thread calling.
    /// </summary>
    /// <param name="timeout">The timeout period.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>
    ///     <see langword="true" /> if the event is set within the timeout period, <see langword="false" /> if the timeout
    ///     is reached.
    /// </returns>
    ValueTask<bool> WaitOneAsync(
        TimeSpan timeout,
        CancellationToken cancellationToken = default);

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
    bool WaitOne(
        int millisecondsTimeout,
        bool exitSynchronizationDomain);

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
    ValueTask<bool> WaitOneAsync(
        int millisecondsTimeout,
        bool exitSynchronizationDomain,
        CancellationToken cancellationToken = default);

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
    bool WaitOne(
        double millisecondsTimeout,
        bool exitSynchronizationDomain);

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
    ValueTask<bool> WaitOneAsync(
        double millisecondsTimeout,
        bool exitSynchronizationDomain,
        CancellationToken cancellationToken = default);

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
    bool WaitOne(
        TimeSpan timeout,
        bool exitSynchronizationDomain);

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
    ValueTask<bool> WaitOneAsync(
        TimeSpan timeout,
        bool exitSynchronizationDomain,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Gets the awaiter for this event, so that it can be awaited on using &quot;await mre;&quot;.
    /// </summary>
    /// <returns>An awaiter that works the same as <see cref="WaitOne()" />, continuing on a different thread.</returns>
    SetResetEventAwaiter GetAwaiter();

    /// <summary>
    ///     Gets the awaiter for this event, with a timeout.
    /// </summary>
    /// <param name="timeout">The timeout to wait until expiring.</param>
    /// <returns>An awaiter that works the same as <see cref="WaitOne(TimeSpan)" />, continuing on a different thread.</returns>
    SetResetEventAwaiterWithTimeout WithTimeout(TimeSpan timeout);

    /// <summary>
    ///     Gets the awaiter for this event, with a timeout.
    /// </summary>
    /// <param name="timeout">The timeout to wait until expiring.</param>
    /// <returns>An awaiter that works the same as <see cref="WaitOne(double)" />, continuing on a different thread.</returns>
    SetResetEventAwaiterWithTimeout WithTimeout(double timeout);

    /// <summary>
    ///     Gets the awaiter for this event, with a timeout.
    /// </summary>
    /// <param name="timeout">The timeout to wait until expiring.</param>
    /// <returns>An awaiter that works the same as <see cref="WaitOne(int)" />, continuing on a different thread.</returns>
    SetResetEventAwaiterWithTimeout WithTimeout(int timeout);
}