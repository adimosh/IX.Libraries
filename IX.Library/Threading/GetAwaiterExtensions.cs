using System.Runtime.CompilerServices;

namespace IX.Library.Threading;

/// <summary>
///     Asynchronous support extension methods for various objects that would be useful to <see langword="await" /> on.
/// </summary>
[PublicAPI]
public static class GetAwaiterExtensions
{
    /// <summary>
    ///     Gets a delay awaiter.
    /// </summary>
    /// <param name="timeSpan">The time span.</param>
    /// <returns>A <see cref="TaskAwaiter" /> that can be awaited on.</returns>
    public static TaskAwaiter GetAwaiter(this TimeSpan timeSpan) =>
        Task.Delay(timeSpan)
            .GetAwaiter();

    /// <summary>
    ///     Gets a delay awaiter.
    /// </summary>
    /// <param name="duration">The duration, in milliseconds.</param>
    /// <returns>A <see cref="TaskAwaiter" /> that can be awaited on.</returns>
    public static TaskAwaiter GetAwaiter(this int duration) =>
        Task.Delay(duration)
            .GetAwaiter();

    /// <summary>
    ///     Gets a delay awaiter.
    /// </summary>
    /// <param name="dateTimeOffset">The offset.</param>
    /// <returns>A <see cref="TaskAwaiter" /> that can be awaited on.</returns>
    public static TaskAwaiter GetAwaiter(this DateTimeOffset dateTimeOffset) =>
        (dateTimeOffset - DateTimeOffset.UtcNow).GetAwaiter();

    /// <summary>
    /// Gets an awaiter for the synchronization context.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <returns>A <see cref="SynchronizationContextAwaiter"/> that can be awaited on.</returns>
    public static SynchronizationContextAwaiter GetAwaiter(this SynchronizationContext context) =>
        new(context);

    /// <summary>
    ///     Gets a delay awaiter that supports a cancellation token.
    /// </summary>
    /// <param name="timeSpan">The time span.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="TaskAwaiter" /> that can be awaited on.</returns>
    public static TaskAwaiter WithCancellationToken(
        this TimeSpan timeSpan,
        CancellationToken cancellationToken) =>
        Task.Delay(
                timeSpan,
                cancellationToken)
            .GetAwaiter();

    /// <summary>
    ///     Gets a delay awaiter that supports a cancellation token.
    /// </summary>
    /// <param name="duration">The duration, in milliseconds.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="TaskAwaiter" /> that can be awaited on.</returns>
    public static TaskAwaiter WithCancellationToken(
        this int duration,
        CancellationToken cancellationToken) =>
        Task.Delay(
                duration,
                cancellationToken)
            .GetAwaiter();

    /// <summary>
    ///     Gets a delay awaiter that supports a cancellation token.
    /// </summary>
    /// <param name="dateTimeOffset">The offset.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="TaskAwaiter" /> that can be awaited on.</returns>
    public static TaskAwaiter WithCancellationToken(
        this DateTimeOffset dateTimeOffset,
        CancellationToken cancellationToken) =>
        (dateTimeOffset - DateTimeOffset.UtcNow).WithCancellationToken(cancellationToken);
}