using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace IX.Library.Threading;

/// <summary>
///     A class containing extension methods for <see cref="TaskFactory" />, mostly intended for use with
///     <see cref="Task.Factory" />.
/// </summary>
public static partial class TaskFactoryExtensions
{
    /// <summary>
    ///     Starts a long-running task on a new thread.
    /// </summary>
    /// <param name="taskFactory">The task factory to extend.</param>
    /// <param name="action">The action to start on a new thread.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="Task" /> that represents the started long-running task.</returns>
    public static Task StartLongRunningOnDefaultTaskSchedulerAsync(
        this TaskFactory taskFactory,
        Action action,
        CancellationToken cancellationToken = default) =>
        StartWithStateOnDefaultTaskSchedulerAsync(
            taskFactory ?? throw new ArgumentNullException(nameof(taskFactory)),
            rawState => rawState(),
            action ?? throw new ArgumentNullException(nameof(action)),
            true,
            cancellationToken);

    /// <summary>
    ///     Starts a long-running task on a new thread.
    /// </summary>
    /// <typeparam name="TResult">The type of the return value.</typeparam>
    /// <param name="taskFactory">The task factory to extend.</param>
    /// <param name="action">The action to start on a new thread.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="Task" /> that represents the started long-running task.</returns>
    public static Task<TResult> StartLongRunningOnDefaultTaskSchedulerAsync<TResult>(
        this TaskFactory taskFactory,
        Func<TResult> action,
        CancellationToken cancellationToken = default) =>
        StartWithStateOnDefaultTaskSchedulerAsync(
            taskFactory ?? throw new ArgumentNullException(nameof(taskFactory)),
            StateAsAction<TResult>,
            action ?? throw new ArgumentNullException(nameof(action)),
            true,
            cancellationToken);

    /// <summary>
    ///     Starts a task on a new thread.
    /// </summary>
    /// <param name="taskFactory">The task factory to extend.</param>
    /// <param name="action">The action to start on a new thread.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="Task" /> that represents the started task.</returns>
    public static Task StartOnDefaultTaskSchedulerAsync(
        this TaskFactory taskFactory,
        Action action,
        CancellationToken cancellationToken = default) =>
        StartWithStateOnDefaultTaskSchedulerAsync(
            taskFactory ?? throw new ArgumentNullException(nameof(taskFactory)),
            rawState => rawState(),
            action ?? throw new ArgumentNullException(nameof(action)),
            false,
            cancellationToken);

    /// <summary>
    ///     Starts a task on a new thread.
    /// </summary>
    /// <typeparam name="TResult">The type of the return value.</typeparam>
    /// <param name="taskFactory">The task factory to extend.</param>
    /// <param name="action">The action to start on a new thread.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="Task" /> that represents the started task.</returns>
    public static Task<TResult> StartOnDefaultTaskSchedulerAsync<TResult>(
        this TaskFactory taskFactory,
        Func<TResult> action,
        CancellationToken cancellationToken = default) =>
        StartWithStateOnDefaultTaskSchedulerAsync(
            taskFactory ?? throw new ArgumentNullException(nameof(taskFactory)),
            StateAsAction<TResult>,
            action ?? throw new ArgumentNullException(nameof(action)),
            false,
            cancellationToken);

    [SuppressMessage(
        "Performance",
        "HAA0603:Delegate allocation from a method group",
        Justification = "Unavoidable here.")]
    internal static Task StartWithStateOnDefaultTaskSchedulerAsync<TState>(
        TaskFactory taskFactory,
        Action<TState> action,
        TState state,
        bool longRunning,
        CancellationToken cancellationToken = default)
    {
        TaskCreationOptions creationOptions = TaskCreationOptions.HideScheduler |
                                              (longRunning
                                                  ? TaskCreationOptions.LongRunning
                                                  : TaskCreationOptions.PreferFairness);

        return (taskFactory ?? throw new ArgumentNullException(nameof(taskFactory))).StartNew(
            StartAction,
            new Tuple<Action<TState>, CultureInfo, CultureInfo, TState>(
                action ?? throw new ArgumentNullException(nameof(action)),
                CultureInfo.CurrentCulture,
                CultureInfo.CurrentUICulture,
                state),
            cancellationToken,
            creationOptions,
            TaskScheduler.Default);

        static void StartAction(object? rawState)
        {
            var innerState = (Tuple<Action<TState>, CultureInfo, CultureInfo, TState>)rawState!;

            CultureInfo.CurrentCulture = innerState.Item2;
            CultureInfo.CurrentUICulture = innerState.Item3;

            innerState.Item1(innerState.Item4);
        }
    }

    [SuppressMessage(
        "Performance",
        "HAA0603:Delegate allocation from a method group",
        Justification = "Unavoidable here.")]
    internal static Task<TResult> StartWithStateOnDefaultTaskSchedulerAsync<TState, TResult>(
        TaskFactory taskFactory,
        Func<TState, TResult> action,
        TState state,
        bool longRunning,
        CancellationToken cancellationToken = default)
    {
        TaskCreationOptions creationOptions = TaskCreationOptions.HideScheduler |
                                              (longRunning
                                                  ? TaskCreationOptions.LongRunning
                                                  : TaskCreationOptions.PreferFairness);

        return (taskFactory ?? throw new ArgumentNullException(nameof(taskFactory))).StartNew(
            StartAction,
            new Tuple<Func<TState, TResult>, CultureInfo, CultureInfo, TState>(
                action ?? throw new ArgumentNullException(nameof(action)),
                CultureInfo.CurrentCulture,
                CultureInfo.CurrentUICulture,
                state),
            cancellationToken,
            creationOptions,
            TaskScheduler.Default);

        static TResult StartAction(object? rawState)
        {
            var innerState = (Tuple<Func<TState, TResult>, CultureInfo, CultureInfo, TState>)rawState!;

            CultureInfo.CurrentCulture = innerState.Item2;
            CultureInfo.CurrentUICulture = innerState.Item3;

            return innerState.Item1(innerState.Item4);
        }
    }

    private static TResult StateAsAction<TResult>(object state) => ((Func<TResult>)state)();
}