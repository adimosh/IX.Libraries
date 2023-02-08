using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace IX.Core.Collections;

/// <summary>
///     Extensions for IEnumerable.
/// </summary>
[PublicAPI]
[SuppressMessage(
    "Performance",
    "HAA0401:Possible allocation of reference type enumerator",
    Justification = "These are extensions for IEnumerable, so we must allow this.")]
[SuppressMessage(
    "ReSharper",
    "InconsistentNaming",
    Justification = "These are extensions for IEnumerable, so we must allow this.")]
public static partial class IEnumerableExtensions
{
    /// <summary>
    ///     Executes an action in sequence with an iterator.
    /// </summary>
    /// <typeparam name="T">The enumerable type.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="action">The action to execute.</param>
    /// <exception cref="ArgumentNullException">
    ///     Thrown when <paramref name="source" /> or <paramref name="action" /> is
    ///     <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public static void For<T>(
        this IEnumerable<T> source,
        Action<int, T> action)
    {
        _ = Requires.NotNull(source);
        _ = Requires.NotNull(action);

        var i = 0;
        foreach (T item in source)
        {
            action(
                i,
                item);
            i++;
        }
    }

    /// <summary>
    ///     Executes an action in sequence with an iterator.
    /// </summary>
    /// <param name="source">The enumerable source.</param>
    /// <param name="action">The action to execute.</param>
    /// <exception cref="ArgumentNullException">
    ///     Thrown when <paramref name="source" /> or <paramref name="action" /> is
    ///     <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public static void For(
        this IEnumerable source,
        Action<int, object> action)
    {
        _ = Requires.NotNull(source);
        _ = Requires.NotNull(action);

        var i = 0;
        foreach (var item in source)
        {
            action(
                i,
                item);
            i++;
        }
    }

    /// <summary>
    ///     Executes an action for each one of the elements of an enumerable.
    /// </summary>
    /// <typeparam name="T">The enumerable type.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="action">The action to execute.</param>
    /// <exception cref="ArgumentNullException">
    ///     Thrown when <paramref name="source" /> or <paramref name="action" /> is
    ///     <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public static void ForEach<T>(
        this IEnumerable<T> source,
        Action<T> action)
    {
        _ = Requires.NotNull(source);
        _ = Requires.NotNull(action);

        foreach (T item in source)
        {
            action(item);
        }
    }

    /// <summary>
    ///     Executes an action for each one of the elements of an enumerable.
    /// </summary>
    /// <param name="source">The enumerable source.</param>
    /// <param name="action">The action to execute.</param>
    /// <exception cref="ArgumentNullException">
    ///     Thrown when <paramref name="source" /> or <paramref name="action" /> is
    ///     <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public static void ForEach(
        this IEnumerable source,
        Action<object> action)
    {
        _ = Requires.NotNull(source);
        _ = Requires.NotNull(action);

        foreach (var item in source)
        {
            action(item);
        }
    }

    /// <summary>
    ///     Executes an independent action in parallel, with an iterator that respects the original sequence.
    /// </summary>
    /// <typeparam name="T">The enumerable type.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="action">The action to execute.</param>
    /// <exception cref="ArgumentNullException">
    ///     Thrown when <paramref name="source" /> or <paramref name="action" /> is
    ///     <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    [SuppressMessage(
        "Performance",
        "HAA0603:Delegate allocation from a method group",
        Justification = "This is acceptable.")]
    public static void ParallelFor<T>(
        this IEnumerable<T> source,
        Action<int, T> action)
    {
        _ = Requires.NotNull(source);
        _ = Requires.NotNull(action);

        _ = Parallel.ForEach(
            EnumerateWithIndex(
                source,
                action),
            PerformParallelAction);

        static IEnumerable<(int Index, T Item, Action<int, T> Action)> EnumerateWithIndex(
            IEnumerable<T> sourceEnumerable,
            Action<int, T> actionToPerform)
        {
            var i = 0;
            foreach (T item in sourceEnumerable)
            {
                yield return (i, item, actionToPerform);
                i++;
            }
        }

        static void PerformParallelAction((int Index, T Item, Action<int, T> Action) state) =>
            state.Action(
                state.Index,
                state.Item);
    }

    /// <summary>
    ///     Executes an independent action for each one of the elements of an enumerable, in parallel.
    /// </summary>
    /// <typeparam name="T">The enumerable type.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="action">The action to execute.</param>
    /// <exception cref="ArgumentNullException">
    ///     Thrown when <paramref name="source" /> or <paramref name="action" /> is
    ///     <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public static void ParallelForEach<T>(
        this IEnumerable<T> source,
        Action<T> action)
    {
        _ = Requires.NotNull(source);
        _ = Requires.NotNull(action);

        _ = Parallel.ForEach(
            source,
            action);
    }
}