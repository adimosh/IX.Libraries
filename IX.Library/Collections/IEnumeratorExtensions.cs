using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace IX.Library.Collections;

/// <summary>
/// Extension methods for IEnumerator.
/// </summary>
[SuppressMessage(
    "ReSharper",
    "InconsistentNaming",
    Justification = "These are extensions for IEnumerable, so we must allow this.")]
[SuppressMessage(
    "CodeQuality",
    "IDE0079:Remove unnecessary suppression",
    Justification = "ReSharper is used in this project.")]
public static class IEnumeratorExtensions
{
    /// <summary>
    /// Executes an action for each one of the elements of an enumerator.
    /// </summary>
    /// <typeparam name="T">The enumerator type.</typeparam>
    /// <param name="source">The enumerator source.</param>
    /// <param name="action">The action to execute.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    [SuppressMessage("Performance", "HAA0401:Possible allocation of reference type enumerator", Justification = "Unavoidable.")]
    public static void ForEach<T>(this IEnumerator<T> source, Action<T> action)
    {
        if (source is null) throw new ArgumentNullException(nameof(source));
        if (action is null) throw new ArgumentNullException(nameof(action));

        while (source.MoveNext())
        {
            action(source.Current);
        }
    }

    /// <summary>
    /// Executes an action for each one of the elements of a non-generic enumerator.
    /// </summary>
    /// <param name="source">The enumerator source.</param>
    /// <param name="action">The action to execute.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static void ForEach(this IEnumerator source, Action<object> action)
    {
        if (source is null) throw new ArgumentNullException(nameof(source));
        if (action is null) throw new ArgumentNullException(nameof(action));

        while (source.MoveNext())
        {
            action(source.Current);
        }
    }
}