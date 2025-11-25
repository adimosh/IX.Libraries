namespace IX.Library.Threading;

/// <summary>
///     Extensions for <see cref="WaitHandle" />.
/// </summary>
public static class WaitHandleExtensions
{
    /// <summary>
    ///     Asynchronously waits for the wait handle.
    /// </summary>
    /// <param name="handle">The handle.</param>
    /// <param name="timeout">The timeout.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns><c>true</c> if the timeout has not been reached, <c>false</c> otherwise.</returns>
    public static async ValueTask<bool> WaitOneAsync(
        this WaitHandle handle,
        TimeSpan timeout,
        CancellationToken cancellationToken)
    {
        RegisteredWaitHandle? registeredHandle = null;
        CancellationTokenRegistration tokenRegistration = default;

        try
        {
            var tcs = new TaskCompletionSource<bool>();

            registeredHandle = ThreadPool.RegisterWaitForSingleObject(
                handle,
                (
                    state,
                    timedOut) => ((TaskCompletionSource<bool>)state!).TrySetResult(!timedOut),
                tcs,
                timeout,
                true);

            tokenRegistration = cancellationToken.Register(
                state =>
                {
                    if (state.CompletionSource.TrySetCanceled())
                    {
                        state.RegisteredHandle?.Unregister(null);
                    }
                },
                (CompletionSource: tcs, RegisteredHandle: registeredHandle));

            return await tcs.Task;
        }
        finally
        {
            registeredHandle?.Unregister(null);

            await tokenRegistration.DisposeAsync();
        }
    }

    /// <param name="handle">The handle.</param>
    extension(WaitHandle handle)
    {
        /// <summary>
        ///     Asynchronously waits for the wait handle.
        /// </summary>
        /// <param name="millisecondsTimeout">The timeout, in milliseconds.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns><c>true</c> if the timeout has not been reached, <c>false</c> otherwise.</returns>
        public ValueTask<bool> WaitOneAsync(
            int millisecondsTimeout,
            CancellationToken cancellationToken) =>
            handle.WaitOneAsync(
                TimeSpan.FromMilliseconds(millisecondsTimeout),
                cancellationToken);

        /// <summary>
        ///     Asynchronously waits for the wait handle.
        /// </summary>
        /// <param name="millisecondsTimeout">The timeout, in milliseconds.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns><c>true</c> if the timeout has not been reached, <c>false</c> otherwise.</returns>
        public ValueTask<bool> WaitOneAsync(
            double millisecondsTimeout,
            CancellationToken cancellationToken) =>
            handle.WaitOneAsync(
                TimeSpan.FromMilliseconds(millisecondsTimeout),
                cancellationToken);
    }
}