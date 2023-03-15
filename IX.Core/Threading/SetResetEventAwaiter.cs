namespace IX.Core.Threading;

/// <summary>
///     A class that is used to await on <see cref="ISetResetEvent" /> instances.
/// </summary>
[PublicAPI]
public class SetResetEventAwaiter : IAwaiter
{
    private readonly ISetResetEvent _mre;

    private int _isCompleted;

    internal SetResetEventAwaiter(ISetResetEvent mre) =>
        Requires.NotNull(
            out this._mre,
            mre,
            nameof(mre));

    /// <summary>
    ///     Gets a value indicating whether this awaiter has completed.
    /// </summary>
    /// <value>
    ///     <c>true</c> if this awaiter has completed; otherwise, <c>false</c>.
    /// </value>
    [UsedImplicitly]
    public bool IsCompleted => _isCompleted != 0;

    /// <summary>
    ///     Returns the current awaiter.
    /// </summary>
    /// <returns>The current awaiter.</returns>
    public IAwaiter GetAwaiter() => this;

    /// <summary>
    ///     Gets the result.
    /// </summary>
    [UsedImplicitly]
    public void GetResult() { }

    /// <summary>Schedules the continuation action that's invoked when the instance completes.</summary>
    /// <param name="continuation">The action to invoke when the operation completes.</param>
    /// <exception cref="T:System.ArgumentNullException">
    ///     The <paramref name="continuation" /> argument is null (Nothing in
    ///     Visual Basic).
    /// </exception>
    public void OnCompleted(Action continuation) =>
        _ = Work.OnThreadPoolAsync(
            state =>
            {
                var (internalContinuation, internalThis) = state;

                internalThis._mre.WaitOne();

                internalContinuation?.Invoke();

                _ = Interlocked.Exchange(
                    ref internalThis._isCompleted,
                    1);
            },
            (Continuation: continuation, this));
}