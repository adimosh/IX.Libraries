namespace IX.Library.Threading;

/// <summary>
///     A class that is used to await on <see cref="ISetResetEvent" /> instances with a specified timeout.
/// </summary>
public class SetResetEventAwaiterWithTimeout : IAwaiter<bool>
{
    private readonly ISetResetEvent _mre;
    private readonly TimeSpan _tsTimeout;

    private int _isCompleted;
    private bool _result;

    internal SetResetEventAwaiterWithTimeout(
        ISetResetEvent mre,
        int timeout)
    {
        Requires.NotNull(
            out _mre,
            mre,
            nameof(mre));

        _tsTimeout = TimeSpan.FromMilliseconds(timeout);
    }

    internal SetResetEventAwaiterWithTimeout(
        ISetResetEvent mre,
        TimeSpan timeout)
    {
        Requires.NotNull(
            out _mre,
            mre,
            nameof(mre));

        _tsTimeout = timeout;
    }

    internal SetResetEventAwaiterWithTimeout(
        ISetResetEvent mre,
        double timeout)
    {
        Requires.NotNull(
            out _mre,
            mre,
            nameof(mre));

        _tsTimeout = TimeSpan.FromMilliseconds(timeout);
    }

    /// <summary>
    ///     Gets a value indicating whether this awaiter has completed.
    /// </summary>
    /// <value>
    ///     <c>true</c> if this awaiter has completed; otherwise, <c>false</c>.
    /// </value>
    public bool IsCompleted => _isCompleted != 0;

    /// <summary>
    ///     Returns the current awaiter.
    /// </summary>
    /// <returns>The current awaiter.</returns>
    public IAwaiter<bool> GetAwaiter() => this;

    /// <summary>
    ///     Gets the result.
    /// </summary>
    /// <returns><c>true</c> if the wait didn't outrun the timeout, <c>false</c> if it did.</returns>
    public bool GetResult() => _result;

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

                internalThis._result = internalThis._mre.WaitOne(internalThis._tsTimeout);

                internalContinuation?.Invoke();

                _ = Interlocked.Exchange(
                    ref internalThis._isCompleted,
                    1);
            },
            (Continuation: continuation, this));
}