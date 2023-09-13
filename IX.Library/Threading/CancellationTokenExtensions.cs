using System.Diagnostics.CodeAnalysis;

namespace IX.Core.Threading;

/// <summary>
///     Extensions for <see cref="CancellationToken" />.
/// </summary>
[PublicAPI]
public static class CancellationTokenExtensions
{
    /// <summary>
    ///     Registers a delegate that will be called when this <see cref="CancellationToken" /> is canceled.
    /// </summary>
    /// <typeparam name="TState">The type of the state object to be passed to the callback.</typeparam>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <param name="callback">The delegate to be executed when the <see cref="CancellationToken" /> is canceled.</param>
    /// <param name="state">
    ///     The state to pass to the <paramref name="callback" /> when the delegate is invoked. This may be
    ///     <c>null</c> (<c>Nothing</c> in Visual Basic).
    /// </param>
    /// <returns>The <see cref="CancellationTokenRegistration" /> instance that can be used to un-register the callback.</returns>
    /// <exception cref="ObjectDisposedException">The associated <see cref="CancellationTokenSource" /> has been disposed.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="callback" /> is <c>null</c> (<c>Nothing</c> in Visual Basic).</exception>
    /// <remarks>
    ///     <para>
    ///         If this token is already in the canceled state, the delegate will be run immediately and synchronously. Any
    ///         exception the delegate generates will be propagated out of this method call.
    ///     </para>
    ///     <para>
    ///         The current <see cref="ExecutionContext" /> is captured along with the delegate and will be used when
    ///         executing it.
    ///     </para>
    ///     <para>The current <see cref="SynchronizationContext" /> is not captured.</para>
    /// </remarks>
    [SuppressMessage(
        "Performance",
        "HAA0601:Value type to reference type conversion causing boxing allocation",
        Justification = "Boxing is acceptable in this case, as we're possibly crossing threads.")]
    [SuppressMessage(
        "Performance",
        "HAA0303:Lambda or anonymous method in a generic method allocates a delegate instance",
        Justification = "The lambda is also generic.")]
    public static CancellationTokenRegistration Register<TState>(
        this CancellationToken cancellationToken,
        Action<TState> callback,
        TState state) =>
        cancellationToken.Register(
            objectState =>
            {
                (Action<TState> innerCallback, TState innerState) = ((Action<TState>, TState))objectState!;

                innerCallback(innerState);
            },
            (callback, state));

    /// <summary>
    ///     Registers a delegate that will be called when this <see cref="CancellationToken" /> is canceled.
    /// </summary>
    /// <typeparam name="TState">The type of the state object to be passed to the callback.</typeparam>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <param name="callback">The delegate to be executed when the <see cref="CancellationToken" /> is canceled.</param>
    /// <param name="state">
    ///     The state to pass to the <paramref name="callback" /> when the delegate is invoked. This may be
    ///     <c>null</c> (<c>Nothing</c> in Visual Basic).
    /// </param>
    /// <param name="useSynchronizationContext">
    ///     A Boolean value that indicates whether to capture the current
    ///     <see cref="SynchronizationContext" /> and use it when invoking the <c>callback</c>.
    /// </param>
    /// <returns>The <see cref="CancellationTokenRegistration" /> instance that can be used to un-register the callback.</returns>
    /// <exception cref="ObjectDisposedException">The associated <see cref="CancellationTokenSource" /> has been disposed.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="callback" /> is <c>null</c> (<c>Nothing</c> in Visual Basic).</exception>
    /// <remarks>
    ///     <para>
    ///         If this token is already in the canceled state, the delegate will be run immediately and synchronously. Any
    ///         exception the delegate generates will be propagated out of this method call.
    ///     </para>
    ///     <para>
    ///         The current <see cref="ExecutionContext" /> is captured along with the delegate and will be used when
    ///         executing it.
    ///     </para>
    ///     <para>
    ///         If <paramref name="useSynchronizationContext" /> is <c>true</c>, the current
    ///         <see cref="SynchronizationContext" />, if one exists, is also captured along with the delegate and will be used
    ///         when executing it. Otherwise, <see cref="SynchronizationContext" /> is not captured.
    ///     </para>
    /// </remarks>
    [SuppressMessage(
        "Performance",
        "HAA0601:Value type to reference type conversion causing boxing allocation",
        Justification = "Boxing is acceptable in this case, as we're possibly crossing threads.")]
    [SuppressMessage(
        "Performance",
        "HAA0303:Lambda or anonymous method in a generic method allocates a delegate instance",
        Justification = "The lambda is also generic.")]
    public static CancellationTokenRegistration Register<TState>(
        this CancellationToken cancellationToken,
        Action<TState> callback,
        TState state,
        bool useSynchronizationContext) =>
        cancellationToken.Register(
            objectState =>
            {
                (Action<TState> innerCallback, TState innerState) = ((Action<TState>, TState))objectState!;

                innerCallback(innerState);
            },
            (callback, state),
            useSynchronizationContext);
}