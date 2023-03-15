using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace IX.Core.Threading;

/// <summary>
///     Methods and extension methods that aim to simplify working with different threads and thread pools.
/// </summary>
[PublicAPI]
[SuppressMessage(
    "Performance",
    "HAA0603:Delegate allocation from a method group",
    Justification = "This is unavoidable in this case.")]
[SuppressMessage(
    "Performance",
    "HAA0601:Value type to reference type conversion causing boxing allocation",
    Justification = "This is unavoidable because of thread switching.")]
public static partial class Work
{
#region Func with cancellation token, returning task

    /// <summary>
    ///     Executes a method accepting a cancellation token on the thread pool.
    /// </summary>
    /// <param name="methodToInvoke">The method to invoke.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the executed method.</returns>
    public static Task OnThreadPoolAsync(
        this Func<CancellationToken, Task> methodToInvoke,
        CancellationToken cancellationToken = default)
    {
        var taskCompletionSource = new TaskCompletionSource<int>();

        if (cancellationToken.IsCancellationRequested)
        {
            _ = taskCompletionSource.TrySetCanceled(cancellationToken);

            return taskCompletionSource.Task;
        }

        _ = ThreadPool.QueueUserWorkItem(
            WorkItem,
            (MethodToInvoke: methodToInvoke, CultureInfo.CurrentCulture, CultureInfo.CurrentUICulture, TaskCompletionSource: taskCompletionSource, CancellationToken: cancellationToken));

        static void WorkItem(object? rawState)
        {
            var (func, currentCulture, currentUiCulture, tcs, ct) = Requires
                .ArgumentOfType<(Func<CancellationToken, Task>, CultureInfo, CultureInfo, TaskCompletionSource<int>,
                    CancellationToken)>(rawState);

            if (ct.IsCancellationRequested)
            {
                _ = tcs.TrySetCanceled(ct);

                return;
            }

            CultureInfo.CurrentCulture = currentCulture;
            CultureInfo.CurrentUICulture = currentUiCulture;

            try
            {
                _ = func(ct)
                    .ContinueWith(
                        Continuation,
                        default,
                        TaskContinuationOptions.ExecuteSynchronously,
                        TaskScheduler.Current);

                void Continuation(Task completedTask)
                {
                    if (completedTask.IsCanceled)
                    {
                        _ = tcs.TrySetCanceled(ct);
                    }
                    else if (completedTask.IsFaulted)
                    {
                        _ = tcs.TrySetException(
                            completedTask.Exception?.InnerExceptions ??
                            (IEnumerable<Exception>)Array.Empty<Exception>());
                    }
                    else
                    {
                        _ = tcs.TrySetResult(0);
                    }
                }
            }
            catch (OperationCanceledException)
            {
                _ = tcs.TrySetCanceled(ct);
            }
            catch (Exception ex)
            {
                _ = tcs.TrySetException(ex);
            }
        }

        return taskCompletionSource.Task;
    }

#endregion

#region Func with cancellation token, returning task with value

    /// <summary>
    ///     Executes a method accepting a cancellation token on the thread pool.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="methodToInvoke">The method to invoke.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the executed method.</returns>
    public static Task<TResult> OnThreadPoolAsync<TResult>(
        this Func<CancellationToken, Task<TResult>> methodToInvoke,
        CancellationToken cancellationToken = default)
    {
        var taskCompletionSource = new TaskCompletionSource<TResult>();

        if (cancellationToken.IsCancellationRequested)
        {
            _ = taskCompletionSource.TrySetCanceled(cancellationToken);

            return taskCompletionSource.Task;
        }

        _ = ThreadPool.QueueUserWorkItem(
            WorkItem,
            (MethodToInvoke: methodToInvoke, CultureInfo.CurrentCulture, CultureInfo.CurrentUICulture, TaskCompletionSource: taskCompletionSource, CancellationToken: cancellationToken));

        static void WorkItem(object? rawState)
        {
            var (func, currentCulture, currentUiCulture, tcs, ct) = Requires
                .ArgumentOfType<(Func<CancellationToken, Task<TResult>>, CultureInfo, CultureInfo,
                    TaskCompletionSource<TResult>, CancellationToken)>(rawState);

            if (ct.IsCancellationRequested)
            {
                _ = tcs.TrySetCanceled(ct);

                return;
            }

            CultureInfo.CurrentCulture = currentCulture;
            CultureInfo.CurrentUICulture = currentUiCulture;

            try
            {
                _ = func(ct)
                    .ContinueWith(
                        Continuation,
                        default,
                        TaskContinuationOptions.ExecuteSynchronously,
                        TaskScheduler.Current);

                void Continuation(Task<TResult> completedTask)
                {
                    if (completedTask.IsCanceled)
                    {
                        _ = tcs.TrySetCanceled(ct);
                    }
                    else if (completedTask.IsFaulted)
                    {
                        _ = tcs.TrySetException(
                            completedTask.Exception?.InnerExceptions ??
                            (IEnumerable<Exception>)Array.Empty<Exception>());
                    }
                    else
                    {
                        _ = tcs.TrySetResult(completedTask.Result);
                    }
                }
            }
            catch (OperationCanceledException)
            {
                _ = tcs.TrySetCanceled(ct);
            }
            catch (Exception ex)
            {
                _ = tcs.TrySetException(ex);
            }
        }

        return taskCompletionSource.Task;
    }

#endregion

#region Func with payload and cancellation token, returning task

    /// <summary>
    ///     Executes a method accepting a cancellation token on the thread pool.
    /// </summary>
    /// <typeparam name="TState">The type of the payload.</typeparam>
    /// <param name="methodToInvoke">The method to invoke.</param>
    /// <param name="state">The state, or payload, of the invoked method.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the executed method.</returns>
    public static Task OnThreadPoolAsync<TState>(
        this Func<TState, CancellationToken, Task> methodToInvoke,
        TState state,
        CancellationToken cancellationToken = default)
    {
        var taskCompletionSource = new TaskCompletionSource<int>();

        if (cancellationToken.IsCancellationRequested)
        {
            _ = taskCompletionSource.TrySetCanceled(cancellationToken);

            return taskCompletionSource.Task;
        }

        _ = ThreadPool.QueueUserWorkItem(
            WorkItem,
            (MethodToInvoke: methodToInvoke, CultureInfo.CurrentCulture, CultureInfo.CurrentUICulture, TaskCompletionSource: taskCompletionSource, State: state, CancellationToken: cancellationToken));

        static void WorkItem(object? rawState)
        {
            var (func, currentCulture, currentUiCulture, tcs, payload, ct) = Requires
                .ArgumentOfType<(Func<TState, CancellationToken, Task>, CultureInfo, CultureInfo,
                    TaskCompletionSource<int>, TState, CancellationToken)>(rawState);

            if (ct.IsCancellationRequested)
            {
                _ = tcs.TrySetCanceled(ct);

                return;
            }

            CultureInfo.CurrentCulture = currentCulture;
            CultureInfo.CurrentUICulture = currentUiCulture;

            try
            {
                _ = func(
                        payload,
                        ct)
                    .ContinueWith(
                        Continuation,
                        default,
                        TaskContinuationOptions.ExecuteSynchronously,
                        TaskScheduler.Current);

                void Continuation(Task completedTask)
                {
                    if (completedTask.IsCanceled)
                    {
                        _ = tcs.TrySetCanceled(ct);
                    }
                    else if (completedTask.IsFaulted)
                    {
                        _ = tcs.TrySetException(
                            completedTask.Exception?.InnerExceptions ??
                            (IEnumerable<Exception>)Array.Empty<Exception>());
                    }
                    else
                    {
                        _ = tcs.TrySetResult(0);
                    }
                }
            }
            catch (OperationCanceledException)
            {
                _ = tcs.TrySetCanceled(ct);
            }
            catch (Exception ex)
            {
                _ = tcs.TrySetException(ex);
            }
        }

        return taskCompletionSource.Task;
    }

#endregion

#region Func with payload and cancellation token, returning task with value

    /// <summary>
    ///     Executes a method accepting a cancellation token on the thread pool.
    /// </summary>
    /// <typeparam name="TState">The type of the payload.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="methodToInvoke">The method to invoke.</param>
    /// <param name="state">The state, or payload, of the invoked method.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the executed method.</returns>
    public static Task<TResult> OnThreadPoolAsync<TState, TResult>(
        this Func<TState, CancellationToken, Task<TResult>> methodToInvoke,
        TState state,
        CancellationToken cancellationToken = default)
    {
        var taskCompletionSource = new TaskCompletionSource<TResult>();

        if (cancellationToken.IsCancellationRequested)
        {
            _ = taskCompletionSource.TrySetCanceled(cancellationToken);

            return taskCompletionSource.Task;
        }

        _ = ThreadPool.QueueUserWorkItem(
            WorkItem,
            (MethodToInvoke: methodToInvoke, CultureInfo.CurrentCulture, CultureInfo.CurrentUICulture, TaskCompletionSource: taskCompletionSource, State: state, CancellationToken: cancellationToken));

        static void WorkItem(object? rawState)
        {
            var (func, currentCulture, currentUiCulture, tcs, payload, ct) =
                Requires.ArgumentOfType<(Func<TState, CancellationToken, Task<TResult>>, CultureInfo,
                    CultureInfo, TaskCompletionSource<TResult>, TState, CancellationToken)>(rawState);

            if (ct.IsCancellationRequested)
            {
                _ = tcs.TrySetCanceled(ct);

                return;
            }

            CultureInfo.CurrentCulture = currentCulture;
            CultureInfo.CurrentUICulture = currentUiCulture;

            try
            {
                _ = func(
                        payload,
                        ct)
                    .ContinueWith(
                        Continuation,
                        default,
                        TaskContinuationOptions.ExecuteSynchronously,
                        TaskScheduler.Current);

                void Continuation(Task<TResult> completedTask)
                {
                    if (completedTask.IsCanceled)
                    {
                        _ = tcs.TrySetCanceled(ct);
                    }
                    else if (completedTask.IsFaulted)
                    {
                        _ = tcs.TrySetException(
                            completedTask.Exception?.InnerExceptions ??
                            (IEnumerable<Exception>)Array.Empty<Exception>());
                    }
                    else
                    {
                        _ = tcs.TrySetResult(completedTask.Result);
                    }
                }
            }
            catch (OperationCanceledException)
            {
                _ = tcs.TrySetCanceled(ct);
            }
            catch (Exception ex)
            {
                _ = tcs.TrySetException(ex);
            }
        }

        return taskCompletionSource.Task;
    }

#endregion

#region Func with cancellation token, returning value

    /// <summary>
    ///     Executes a method accepting a cancellation token on the thread pool.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="methodToInvoke">The method to invoke.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the executed method.</returns>
    public static Task<TResult> OnThreadPoolAsync<TResult>(
        this Func<CancellationToken, TResult> methodToInvoke,
        CancellationToken cancellationToken = default)
    {
        var taskCompletionSource = new TaskCompletionSource<TResult>();

        if (cancellationToken.IsCancellationRequested)
        {
            _ = taskCompletionSource.TrySetCanceled(cancellationToken);

            return taskCompletionSource.Task;
        }

        _ = ThreadPool.QueueUserWorkItem(
            WorkItem,
            (MethodToInvoke: methodToInvoke, CultureInfo.CurrentCulture, CultureInfo.CurrentUICulture, TaskCompletionSource: taskCompletionSource, CancellationToken: cancellationToken));

        static void WorkItem(object? rawState)
        {
            var (func, currentCulture, currentUiCulture, tcs, ct) = Requires
                .ArgumentOfType<(Func<CancellationToken, TResult>, CultureInfo, CultureInfo,
                    TaskCompletionSource<TResult>, CancellationToken)>(rawState);

            if (ct.IsCancellationRequested)
            {
                _ = tcs.TrySetCanceled(ct);

                return;
            }

            CultureInfo.CurrentCulture = currentCulture;
            CultureInfo.CurrentUICulture = currentUiCulture;

            try
            {
                TResult innerResult = func(ct);

                _ = tcs.TrySetResult(innerResult);
            }
            catch (OperationCanceledException)
            {
                _ = tcs.TrySetCanceled(ct);
            }
            catch (Exception ex)
            {
                _ = tcs.TrySetException(ex);
            }
        }

        return taskCompletionSource.Task;
    }

#endregion

#region Func with payload and cancellation token, returning value

    /// <summary>
    ///     Executes a method accepting a payload and cancellation token on the thread pool.
    /// </summary>
    /// <typeparam name="TState">The type of the payload.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="methodToInvoke">The method to invoke.</param>
    /// <param name="state">The state, or payload, of the invoked method.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the executed method.</returns>
    public static Task<TResult> OnThreadPoolAsync<TState, TResult>(
        this Func<TState, CancellationToken, TResult> methodToInvoke,
        TState state,
        CancellationToken cancellationToken = default)
    {
        var taskCompletionSource = new TaskCompletionSource<TResult>();

        if (cancellationToken.IsCancellationRequested)
        {
            _ = taskCompletionSource.TrySetCanceled(cancellationToken);

            return taskCompletionSource.Task;
        }

        _ = ThreadPool.QueueUserWorkItem(
            WorkItem,
            (MethodToInvoke: methodToInvoke, CultureInfo.CurrentCulture, CultureInfo.CurrentUICulture, TaskCompletionSource: taskCompletionSource, State: state, CancellationToken: cancellationToken));

        static void WorkItem(object? rawState)
        {
            var (func, currentCulture, currentUiCulture, tcs, payload, ct) = Requires
                .ArgumentOfType<(Func<TState, CancellationToken, TResult>, CultureInfo, CultureInfo,
                    TaskCompletionSource<TResult>, TState, CancellationToken)>(rawState);

            if (ct.IsCancellationRequested)
            {
                _ = tcs.TrySetCanceled(ct);

                return;
            }

            CultureInfo.CurrentCulture = currentCulture;
            CultureInfo.CurrentUICulture = currentUiCulture;

            try
            {
                TResult innerResult = func(
                    payload,
                    ct);

                _ = tcs.TrySetResult(innerResult);
            }
            catch (OperationCanceledException)
            {
                _ = tcs.TrySetCanceled(ct);
            }
            catch (Exception ex)
            {
                _ = tcs.TrySetException(ex);
            }
        }

        return taskCompletionSource.Task;
    }

#endregion

#region Func, returning task

    /// <summary>
    ///     Executes a method on the thread pool.
    /// </summary>
    /// <param name="methodToInvoke">The method to invoke.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the executed method.</returns>
    public static Task OnThreadPoolAsync(
        this Func<Task> methodToInvoke,
        CancellationToken cancellationToken = default)
    {
        var taskCompletionSource = new TaskCompletionSource<int>();

        if (cancellationToken.IsCancellationRequested)
        {
            _ = taskCompletionSource.TrySetCanceled(cancellationToken);

            return taskCompletionSource.Task;
        }

        _ = ThreadPool.QueueUserWorkItem(
            WorkItem,
            (MethodToInvoke: methodToInvoke, CultureInfo.CurrentCulture, CultureInfo.CurrentUICulture, TaskCompletionSource: taskCompletionSource, CancellationToken: cancellationToken));

        static void WorkItem(object? rawState)
        {
            var (func, currentCulture, currentUiCulture, tcs, ct) =
                Requires.ArgumentOfType<(Func<Task>, CultureInfo,
                    CultureInfo, TaskCompletionSource<int>, CancellationToken)>(rawState);

            if (ct.IsCancellationRequested)
            {
                _ = tcs.TrySetCanceled(ct);

                return;
            }

            CultureInfo.CurrentCulture = currentCulture;
            CultureInfo.CurrentUICulture = currentUiCulture;

            try
            {
                _ = func()
                    .ContinueWith(
                        Continuation,
                        default,
                        TaskContinuationOptions.ExecuteSynchronously,
                        TaskScheduler.Current);

                void Continuation(Task completedTask)
                {
                    if (completedTask.IsCanceled)
                    {
                        _ = tcs.TrySetCanceled(ct);
                    }
                    else if (completedTask.IsFaulted)
                    {
                        _ = tcs.TrySetException(
                            completedTask.Exception?.InnerExceptions ??
                            (IEnumerable<Exception>)Array.Empty<Exception>());
                    }
                    else
                    {
                        _ = tcs.TrySetResult(0);
                    }
                }
            }
            catch (OperationCanceledException)
            {
                _ = tcs.TrySetCanceled(ct);
            }
            catch (Exception ex)
            {
                _ = tcs.TrySetException(ex);
            }
        }

        return taskCompletionSource.Task;
    }

#endregion

#region Func, returning task with value

    /// <summary>
    ///     Executes a method on the thread pool.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="methodToInvoke">The method to invoke.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the executed method.</returns>
    public static Task<TResult> OnThreadPoolAsync<TResult>(
        this Func<Task<TResult>> methodToInvoke,
        CancellationToken cancellationToken = default)
    {
        var taskCompletionSource = new TaskCompletionSource<TResult>();

        if (cancellationToken.IsCancellationRequested)
        {
            _ = taskCompletionSource.TrySetCanceled(cancellationToken);

            return taskCompletionSource.Task;
        }

        _ = ThreadPool.QueueUserWorkItem(
            WorkItem,
            (MethodToInvoke: methodToInvoke, CultureInfo.CurrentCulture, CultureInfo.CurrentUICulture, TaskCompletionSource: taskCompletionSource, CancellationToken: cancellationToken));

        static void WorkItem(object? rawState)
        {
            var (func, currentCulture, currentUiCulture, tcs, ct) = Requires
                .ArgumentOfType<(Func<Task<TResult>>, CultureInfo, CultureInfo, TaskCompletionSource<TResult>,
                    CancellationToken)>(rawState);

            if (ct.IsCancellationRequested)
            {
                _ = tcs.TrySetCanceled(ct);

                return;
            }

            CultureInfo.CurrentCulture = currentCulture;
            CultureInfo.CurrentUICulture = currentUiCulture;

            try
            {
                _ = func()
                    .ContinueWith(
                        Continuation,
                        default,
                        TaskContinuationOptions.ExecuteSynchronously,
                        TaskScheduler.Current);

                void Continuation(Task<TResult> completedTask)
                {
                    if (completedTask.IsCanceled)
                    {
                        _ = tcs.TrySetCanceled(ct);
                    }
                    else if (completedTask.IsFaulted)
                    {
                        _ = tcs.TrySetException(
                            completedTask.Exception?.InnerExceptions ??
                            (IEnumerable<Exception>)Array.Empty<Exception>());
                    }
                    else
                    {
                        _ = tcs.TrySetResult(completedTask.Result);
                    }
                }
            }
            catch (OperationCanceledException)
            {
                _ = tcs.TrySetCanceled(ct);
            }
            catch (Exception ex)
            {
                _ = tcs.TrySetException(ex);
            }
        }

        return taskCompletionSource.Task;
    }

#endregion

#region Func with payload, returning task

    /// <summary>
    ///     Executes a method accepting a payload on the thread pool.
    /// </summary>
    /// <typeparam name="TState">The type of the payload.</typeparam>
    /// <param name="methodToInvoke">The method to invoke.</param>
    /// <param name="state">The state, or payload, of the invoked method.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the executed method.</returns>
    public static Task OnThreadPoolAsync<TState>(
        this Func<TState, Task> methodToInvoke,
        TState state,
        CancellationToken cancellationToken = default)
    {
        var taskCompletionSource = new TaskCompletionSource<int>();

        if (cancellationToken.IsCancellationRequested)
        {
            _ = taskCompletionSource.TrySetCanceled(cancellationToken);

            return taskCompletionSource.Task;
        }

        _ = ThreadPool.QueueUserWorkItem(
            WorkItem,
            (MethodToInvoke: methodToInvoke, CultureInfo.CurrentCulture, CultureInfo.CurrentUICulture, TaskCompletionSource: taskCompletionSource, State: state, CancellationToken: cancellationToken));

        static void WorkItem(object? rawState)
        {
            var (func, currentCulture, currentUiCulture, tcs, payload, ct) = Requires
                .ArgumentOfType<(Func<TState, Task>, CultureInfo, CultureInfo, TaskCompletionSource<int>, TState,
                    CancellationToken)>(rawState);

            if (ct.IsCancellationRequested)
            {
                _ = tcs.TrySetCanceled(ct);

                return;
            }

            CultureInfo.CurrentCulture = currentCulture;
            CultureInfo.CurrentUICulture = currentUiCulture;

            try
            {
                _ = func(payload)
                    .ContinueWith(
                        Continuation,
                        default,
                        TaskContinuationOptions.ExecuteSynchronously,
                        TaskScheduler.Current);

                void Continuation(Task completedTask)
                {
                    if (completedTask.IsCanceled)
                    {
                        _ = tcs.TrySetCanceled(ct);
                    }
                    else if (completedTask.IsFaulted)
                    {
                        _ = tcs.TrySetException(
                            completedTask.Exception?.InnerExceptions ??
                            (IEnumerable<Exception>)Array.Empty<Exception>());
                    }
                    else
                    {
                        _ = tcs.TrySetResult(0);
                    }
                }
            }
            catch (OperationCanceledException)
            {
                _ = tcs.TrySetCanceled(ct);
            }
            catch (Exception ex)
            {
                _ = tcs.TrySetException(ex);
            }
        }

        return taskCompletionSource.Task;
    }

#endregion

#region Func with payload, returning task with value

    /// <summary>
    ///     Executes a method accepting a payload on the thread pool.
    /// </summary>
    /// <typeparam name="TState">The type of the payload.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="methodToInvoke">The method to invoke.</param>
    /// <param name="state">The state, or payload, of the invoked method.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the executed method.</returns>
    public static Task<TResult> OnThreadPoolAsync<TState, TResult>(
        this Func<TState, Task<TResult>> methodToInvoke,
        TState state,
        CancellationToken cancellationToken = default)
    {
        var taskCompletionSource = new TaskCompletionSource<TResult>();

        if (cancellationToken.IsCancellationRequested)
        {
            _ = taskCompletionSource.TrySetCanceled(cancellationToken);

            return taskCompletionSource.Task;
        }

        _ = ThreadPool.QueueUserWorkItem(
            WorkItem,
            (MethodToInvoke: methodToInvoke, CultureInfo.CurrentCulture, CultureInfo.CurrentUICulture, TaskCompletionSource: taskCompletionSource, State: state, CancellationToken: cancellationToken));

        static void WorkItem(object? rawState)
        {
            var (func, currentCulture, currentUiCulture, tcs, payload, ct) = Requires
                .ArgumentOfType<(Func<TState, Task<TResult>>, CultureInfo, CultureInfo, TaskCompletionSource<TResult>,
                    TState, CancellationToken)>(rawState);

            if (ct.IsCancellationRequested)
            {
                _ = tcs.TrySetCanceled(ct);

                return;
            }

            CultureInfo.CurrentCulture = currentCulture;
            CultureInfo.CurrentUICulture = currentUiCulture;

            try
            {
                _ = func(payload)
                    .ContinueWith(
                        Continuation,
                        default,
                        TaskContinuationOptions.ExecuteSynchronously,
                        TaskScheduler.Current);

                void Continuation(Task<TResult> completedTask)
                {
                    if (completedTask.IsCanceled)
                    {
                        _ = tcs.TrySetCanceled(ct);
                    }
                    else if (completedTask.IsFaulted)
                    {
                        _ = tcs.TrySetException(
                            completedTask.Exception?.InnerExceptions ??
                            (IEnumerable<Exception>)Array.Empty<Exception>());
                    }
                    else
                    {
                        _ = tcs.TrySetResult(completedTask.Result);
                    }
                }
            }
            catch (OperationCanceledException)
            {
                _ = tcs.TrySetCanceled(ct);
            }
            catch (Exception ex)
            {
                _ = tcs.TrySetException(ex);
            }
        }

        return taskCompletionSource.Task;
    }

#endregion

#region Func, returning value

    /// <summary>
    ///     Executes a method on the thread pool.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="methodToInvoke">The method to invoke.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the executed method.</returns>
    public static Task<TResult> OnThreadPoolAsync<TResult>(
        this Func<TResult> methodToInvoke,
        CancellationToken cancellationToken = default)
    {
        var taskCompletionSource = new TaskCompletionSource<TResult>();

        if (cancellationToken.IsCancellationRequested)
        {
            _ = taskCompletionSource.TrySetCanceled(cancellationToken);

            return taskCompletionSource.Task;
        }

        _ = ThreadPool.QueueUserWorkItem(
            WorkItem,
            (MethodToInvoke: methodToInvoke, CultureInfo.CurrentCulture, CultureInfo.CurrentUICulture, TaskCompletionSource: taskCompletionSource, CancellationToken: cancellationToken));

        static void WorkItem(object? rawState)
        {
            var (func, currentCulture, currentUiCulture,
                tcs, ct) = Requires
                .ArgumentOfType<(Func<TResult>, CultureInfo, CultureInfo, TaskCompletionSource<TResult>,
                    CancellationToken)>(rawState);

            if (ct.IsCancellationRequested)
            {
                _ = tcs.TrySetCanceled(ct);

                return;
            }

            CultureInfo.CurrentCulture = currentCulture;
            CultureInfo.CurrentUICulture = currentUiCulture;

            try
            {
                TResult innerResult = func();

                _ = tcs.TrySetResult(innerResult);
            }
            catch (OperationCanceledException)
            {
                _ = tcs.TrySetCanceled(ct);
            }
            catch (Exception ex)
            {
                _ = tcs.TrySetException(ex);
            }
        }

        return taskCompletionSource.Task;
    }

#endregion

#region Func with payload, returning value

    /// <summary>
    ///     Executes a method accepting a payload on the thread pool.
    /// </summary>
    /// <typeparam name="TState">The type of the payload.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="methodToInvoke">The method to invoke.</param>
    /// <param name="state">The state, or payload, of the invoked method.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the executed method.</returns>
    public static Task<TResult> OnThreadPoolAsync<TState, TResult>(
        this Func<TState, TResult> methodToInvoke,
        TState state,
        CancellationToken cancellationToken = default)
    {
        var taskCompletionSource = new TaskCompletionSource<TResult>();

        if (cancellationToken.IsCancellationRequested)
        {
            _ = taskCompletionSource.TrySetCanceled(cancellationToken);

            return taskCompletionSource.Task;
        }

        _ = ThreadPool.QueueUserWorkItem(
            WorkItem,
            (MethodToInvoke: methodToInvoke, CultureInfo.CurrentCulture, CultureInfo.CurrentUICulture, TaskCompletionSource: taskCompletionSource, State: state, CancellationToken: cancellationToken));

        static void WorkItem(object? rawState)
        {
            var (func, currentCulture, currentUiCulture, tcs, payload, ct) = Requires
                .ArgumentOfType<(Func<TState, TResult>, CultureInfo, CultureInfo, TaskCompletionSource<TResult>, TState,
                    CancellationToken)>(rawState);

            if (ct.IsCancellationRequested)
            {
                _ = tcs.TrySetCanceled(ct);

                return;
            }

            CultureInfo.CurrentCulture = currentCulture;
            CultureInfo.CurrentUICulture = currentUiCulture;

            try
            {
                TResult innerResult = func(payload);

                _ = tcs.TrySetResult(innerResult);
            }
            catch (OperationCanceledException)
            {
                _ = tcs.TrySetCanceled(ct);
            }
            catch (Exception ex)
            {
                _ = tcs.TrySetException(ex);
            }
        }

        return taskCompletionSource.Task;
    }

#endregion

#region Action with payload and cancellation token

    /// <summary>
    ///     Executes a method accepting a payload and cancellation token on the thread pool.
    /// </summary>
    /// <typeparam name="TState">The type of the payload.</typeparam>
    /// <param name="methodToInvoke">The method to invoke.</param>
    /// <param name="state">The state, or payload, of the invoked method.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing representing the executed method.</returns>
    public static Task OnThreadPoolAsync<TState>(
        this Action<TState, CancellationToken> methodToInvoke,
        TState state,
        CancellationToken cancellationToken = default)
    {
        var taskCompletionSource = new TaskCompletionSource<int>();

        if (cancellationToken.IsCancellationRequested)
        {
            _ = taskCompletionSource.TrySetCanceled(cancellationToken);

            return taskCompletionSource.Task;
        }

        _ = ThreadPool.QueueUserWorkItem(
            WorkItem,
            (MethodToInvoke: methodToInvoke, CultureInfo.CurrentCulture, CultureInfo.CurrentUICulture, TaskCompletionSource: taskCompletionSource, State: state, CancellationToken: cancellationToken));

        static void WorkItem(object? rawState)
        {
            var (func, currentCulture, currentUiCulture, tcs, payload, ct) = Requires
                .ArgumentOfType<(Action<TState, CancellationToken>, CultureInfo, CultureInfo, TaskCompletionSource<int>,
                    TState, CancellationToken)>(rawState);

            if (ct.IsCancellationRequested)
            {
                _ = tcs.TrySetCanceled(ct);

                return;
            }

            CultureInfo.CurrentCulture = currentCulture;
            CultureInfo.CurrentUICulture = currentUiCulture;

            try
            {
                func(
                    payload,
                    ct);

                _ = tcs.TrySetResult(0);
            }
            catch (OperationCanceledException)
            {
                _ = tcs.TrySetCanceled(ct);
            }
            catch (Exception ex)
            {
                _ = tcs.TrySetException(ex);
            }
        }

        return taskCompletionSource.Task;
    }

#endregion

#region Action with cancellation token

    /// <summary>
    ///     Executes a method accepting a cancellation token on the thread pool.
    /// </summary>
    /// <param name="methodToInvoke">The method to invoke.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing representing the executed method.</returns>
    public static Task OnThreadPoolAsync(
        this Action<CancellationToken> methodToInvoke,
        CancellationToken cancellationToken = default)
    {
        var taskCompletionSource = new TaskCompletionSource<int>();

        if (cancellationToken.IsCancellationRequested)
        {
            _ = taskCompletionSource.TrySetCanceled(cancellationToken);

            return taskCompletionSource.Task;
        }

        _ = ThreadPool.QueueUserWorkItem(
            WorkItem,
            (MethodToInvoke: methodToInvoke, CultureInfo.CurrentCulture, CultureInfo.CurrentUICulture, TaskCompletionSource: taskCompletionSource, CancellationToken: cancellationToken));

        static void WorkItem(object? rawState)
        {
            var (func, currentCulture, currentUiCulture, tcs, ct) = Requires
                .ArgumentOfType<(Action<CancellationToken>, CultureInfo, CultureInfo, TaskCompletionSource<int>,
                    CancellationToken)>(rawState);

            if (ct.IsCancellationRequested)
            {
                _ = tcs.TrySetCanceled(ct);

                return;
            }

            CultureInfo.CurrentCulture = currentCulture;
            CultureInfo.CurrentUICulture = currentUiCulture;

            try
            {
                func(ct);

                _ = tcs.TrySetResult(0);
            }
            catch (OperationCanceledException)
            {
                _ = tcs.TrySetCanceled(ct);
            }
            catch (Exception ex)
            {
                _ = tcs.TrySetException(ex);
            }
        }

        return taskCompletionSource.Task;
    }

#endregion

#region Action with payload

    /// <summary>
    ///     Executes a method accepting a payload on the thread pool.
    /// </summary>
    /// <typeparam name="TState">The type of the payload.</typeparam>
    /// <param name="methodToInvoke">The method to invoke.</param>
    /// <param name="state">The state, or payload, of the invoked method.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing representing the executed method.</returns>
    public static Task OnThreadPoolAsync<TState>(
        this Action<TState> methodToInvoke,
        TState state,
        CancellationToken cancellationToken = default)
    {
        var taskCompletionSource = new TaskCompletionSource<int>();

        if (cancellationToken.IsCancellationRequested)
        {
            _ = taskCompletionSource.TrySetCanceled(cancellationToken);

            return taskCompletionSource.Task;
        }

        _ = ThreadPool.QueueUserWorkItem(
            WorkItem,
            (MethodToInvoke: methodToInvoke, CultureInfo.CurrentCulture, CultureInfo.CurrentUICulture, TaskCompletionSource: taskCompletionSource, State: state, CancellationToken: cancellationToken));

        static void WorkItem(object? rawState)
        {
            var (func, currentCulture, currentUiCulture, tcs, payload, ct) = Requires
                .ArgumentOfType<(Action<TState>, CultureInfo, CultureInfo, TaskCompletionSource<int>, TState,
                    CancellationToken)>(rawState);

            if (ct.IsCancellationRequested)
            {
                _ = tcs.TrySetCanceled(ct);

                return;
            }

            CultureInfo.CurrentCulture = currentCulture;
            CultureInfo.CurrentUICulture = currentUiCulture;

            try
            {
                func(payload);

                _ = tcs.TrySetResult(0);
            }
            catch (OperationCanceledException)
            {
                _ = tcs.TrySetCanceled(ct);
            }
            catch (Exception ex)
            {
                _ = tcs.TrySetException(ex);
            }
        }

        return taskCompletionSource.Task;
    }

#endregion

#region Action

    /// <summary>
    ///     Executes a method on the thread pool.
    /// </summary>
    /// <param name="methodToInvoke">The method to invoke.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing representing the executed method.</returns>
    public static Task OnThreadPoolAsync(
        this Action methodToInvoke,
        CancellationToken cancellationToken = default)
    {
        var taskCompletionSource = new TaskCompletionSource<int>();

        if (cancellationToken.IsCancellationRequested)
        {
            _ = taskCompletionSource.TrySetCanceled(cancellationToken);

            return taskCompletionSource.Task;
        }

        _ = ThreadPool.QueueUserWorkItem(
            WorkItem,
            (MethodToInvoke: methodToInvoke, CultureInfo.CurrentCulture, CultureInfo.CurrentUICulture, TaskCompletionSource: taskCompletionSource, CancellationToken: cancellationToken));

        static void WorkItem(object? rawState)
        {
            var (func, currentCulture, currentUiCulture, tcs, ct) =
                Requires.ArgumentOfType<(Action, CultureInfo, CultureInfo,
                    TaskCompletionSource<int>, CancellationToken)>(
                    rawState);

            if (ct.IsCancellationRequested)
            {
                _ = tcs.TrySetCanceled(ct);

                return;
            }

            CultureInfo.CurrentCulture = currentCulture;
            CultureInfo.CurrentUICulture = currentUiCulture;

            try
            {
                func();

                _ = tcs.TrySetResult(0);
            }
            catch (OperationCanceledException)
            {
                _ = tcs.TrySetCanceled(ct);
            }
            catch (Exception ex)
            {
                _ = tcs.TrySetException(ex);
            }
        }

        return taskCompletionSource.Task;
    }

#endregion
}