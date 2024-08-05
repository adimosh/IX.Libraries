using System.Diagnostics.CodeAnalysis;

namespace IX.Library.Collections;

/// <summary>
///     Extensions for IEnumerable.
/// </summary>
[SuppressMessage(
    "ReSharper",
    "InconsistentNaming",
    Justification = "These are extensions for IEnumerable, so we must allow this.")]
public static partial class IEnumerableExtensions
{
    /// <summary>
    ///     Determines whether two enumerable objects have all members in sequence equal to one another.
    /// </summary>
    /// <typeparam name="T">The type of the enumerable item.</typeparam>
    /// <param name="left">The left operand enumerable.</param>
    /// <param name="right">The right operand enumerable.</param>
    /// <returns>
    ///     <see langword="true" /> if the two enumerable objects have the same length and each element at each position
    ///     in one enumerable is equal to the equivalent in the other, <see langword="false" /> otherwise.
    /// </returns>
    public static bool SequenceEquals<T>(
        this IEnumerable<IEquatable<T>>? left,
        IEnumerable<T>? right)
    {
        if (left == null)
        {
            return right == null;
        }

        if (right == null)
        {
            return false;
        }

        using IEnumerator<IEquatable<T>> e1 = left.GetEnumerator();
        using IEnumerator<T> e2 = right.GetEnumerator();

        while (true)
        {
            var b1 = e1.MoveNext();
            var b2 = e2.MoveNext();

            if (b1 != b2)
            {
                return false;
            }

            if (b1)
            {
                if (!(e1.Current?.Equals(e2.Current) ?? e2.Current == null))
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
    }

    /// <summary>
    ///     Determines whether two enumerable objects have all members in sequence equal to one another.
    /// </summary>
    /// <typeparam name="T">The type of the enumerable item.</typeparam>
    /// <param name="left">The left operand enumerable.</param>
    /// <param name="right">The right operand enumerable.</param>
    /// <returns>
    ///     <see langword="true" /> if the two enumerable objects have the same length and each element at each position
    ///     in one enumerable is equal to the equivalent in the other, <see langword="false" /> otherwise.
    /// </returns>
    public static bool SequenceEquals<T>(
        this IEnumerable<IComparable<T>>? left,
        IEnumerable<T>? right)
    {
        if (left == null)
        {
            return right == null;
        }

        if (right == null)
        {
            return false;
        }

        using IEnumerator<IComparable<T>> e1 = left.GetEnumerator();
        using IEnumerator<T> e2 = right.GetEnumerator();

        while (true)
        {
            var b1 = e1.MoveNext();
            var b2 = e2.MoveNext();

            if (b1 != b2)
            {
                return false;
            }

            if (b1)
            {
                if ((e1.Current?.CompareTo(e2.Current) ?? (e2.Current == null ? 0 : 1)) != 0)
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
    }

    /// <summary>
    ///     Determines whether two enumerable objects have all members in sequence equal to one another.
    /// </summary>
    /// <param name="left">The left operand enumerable.</param>
    /// <param name="right">The right operand enumerable.</param>
    /// <returns>
    ///     <see langword="true" /> if the two enumerable objects have the same length and each element at each position
    ///     in one enumerable is equal to the equivalent in the other, <see langword="false" /> otherwise.
    /// </returns>
    public static bool SequenceEquals(
        this IEnumerable<IComparable>? left,
        IEnumerable<object>? right)
    {
        if (left == null)
        {
            return right == null;
        }

        if (right == null)
        {
            return false;
        }

        using IEnumerator<IComparable> e1 = left.GetEnumerator();
        using IEnumerator<object> e2 = right.GetEnumerator();

        while (true)
        {
            var b1 = e1.MoveNext();
            var b2 = e2.MoveNext();

            if (b1 != b2)
            {
                return false;
            }

            if (b1)
            {
                if ((e1.Current?.CompareTo(e2.Current) ?? (e2.Current == null ? 0 : 1)) != 0)
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
    }

    /// <summary>
    ///     Determines whether two enumerable objects have all members in sequence equal to one another.
    /// </summary>
    /// <typeparam name="T">The type of the enumerable item.</typeparam>
    /// <param name="left">The left operand enumerable.</param>
    /// <param name="right">The right operand enumerable.</param>
    /// <param name="comparer">The comparer to use when equating items.</param>
    /// <returns>
    ///     <see langword="true" /> if the two enumerable objects have the same length and each element at each position
    ///     in one enumerable is equal to the equivalent in the other, <see langword="false" /> otherwise.
    /// </returns>
    public static bool SequenceEquals<T>(
        this IEnumerable<T>? left,
        IEnumerable<T>? right,
        IEqualityComparer<T> comparer)
    {
        if (left == null)
        {
            return right == null;
        }

        if (right == null)
        {
            return false;
        }

        using IEnumerator<T> e1 = left.GetEnumerator();
        using IEnumerator<T> e2 = right.GetEnumerator();

        while (true)
        {
            var b1 = e1.MoveNext();
            var b2 = e2.MoveNext();

            if (b1 != b2)
            {
                return false;
            }

            if (b1)
            {
                if (!(comparer ?? throw new ArgumentNullException(nameof(comparer))).Equals(
                        e1.Current,
                        e2.Current))
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
    }

    /// <summary>
    ///     Determines whether two enumerable objects have all members in sequence equal to one another.
    /// </summary>
    /// <typeparam name="T">The type of the enumerable item.</typeparam>
    /// <param name="left">The left operand enumerable.</param>
    /// <param name="right">The right operand enumerable.</param>
    /// <param name="comparer">The comparer to use when equating items.</param>
    /// <returns>
    ///     <see langword="true" /> if the two enumerable objects have the same length and each element at each position
    ///     in one enumerable is equal to the equivalent in the other, <see langword="false" /> otherwise.
    /// </returns>
    public static bool SequenceEquals<T>(
        this IEnumerable<T>? left,
        IEnumerable<T>? right,
        IComparer<T> comparer)
    {
        if (left == null)
        {
            return right == null;
        }

        if (right == null)
        {
            return false;
        }

        using IEnumerator<T> e1 = left.GetEnumerator();
        using IEnumerator<T> e2 = right.GetEnumerator();

        while (true)
        {
            var b1 = e1.MoveNext();
            var b2 = e2.MoveNext();

            if (b1 != b2)
            {
                return false;
            }

            if (b1)
            {
                if ((comparer ?? throw new ArgumentNullException(nameof(comparer))).Compare(
                        e1.Current,
                        e2.Current) !=
                    0)
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
    }

    /// <summary>
    ///     Determines whether two enumerable objects have all members in sequence equal to one another.
    /// </summary>
    /// <typeparam name="T">The type of the enumerable item.</typeparam>
    /// <param name="left">The left operand enumerable.</param>
    /// <param name="right">The right operand enumerable.</param>
    /// <param name="comparer">The comparer to use when equating items.</param>
    /// <returns>
    ///     <see langword="true" /> if the two enumerable objects have the same length and each element at each position
    ///     in one enumerable is equal to the equivalent in the other, <see langword="false" /> otherwise.
    /// </returns>
    public static bool SequenceEquals<T>(
        this IEnumerable<T>? left,
        IEnumerable<T>? right,
        Func<T, T, bool> comparer)
    {
        if (left == null)
        {
            return right == null;
        }

        if (right == null)
        {
            return false;
        }

        using IEnumerator<T> e1 = left.GetEnumerator();
        using IEnumerator<T> e2 = right.GetEnumerator();

        while (true)
        {
            var b1 = e1.MoveNext();
            var b2 = e2.MoveNext();

            if (b1 != b2)
            {
                return false;
            }

            if (b1)
            {
                if (!(comparer ?? throw new ArgumentNullException(nameof(comparer)))(
                        e1.Current,
                        e2.Current))
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
    }

    /// <summary>
    ///     Determines whether two enumerable objects have all members in sequence equal to one another.
    /// </summary>
    /// <typeparam name="T">The type of the enumerable item.</typeparam>
    /// <param name="left">The left operand enumerable.</param>
    /// <param name="right">The right operand enumerable.</param>
    /// <param name="comparer">The comparer to use when equating items.</param>
    /// <returns>
    ///     <see langword="true" /> if the two enumerable objects have the same length and each element at each position
    ///     in one enumerable is equal to the equivalent in the other, <see langword="false" /> otherwise.
    /// </returns>
    public static bool SequenceEquals<T>(
        this IEnumerable<T>? left,
        IEnumerable<T>? right,
        Func<T, T, int> comparer)
    {
        if (left == null)
        {
            return right == null;
        }

        if (right == null)
        {
            return false;
        }

        using IEnumerator<T> e1 = left.GetEnumerator();
        using IEnumerator<T> e2 = right.GetEnumerator();

        while (true)
        {
            var b1 = e1.MoveNext();
            var b2 = e2.MoveNext();

            if (b1 != b2)
            {
                return false;
            }

            if (b1)
            {
                if ((comparer ?? throw new ArgumentNullException(nameof(comparer)))(
                        e1.Current,
                        e2.Current) !=
                    0)
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
    }

    /// <summary>
    ///     Determines whether two enumerable objects have all members in sequence equal to one another by object comparison.
    /// </summary>
    /// <param name="left">The left operand enumerable.</param>
    /// <param name="right">The right operand enumerable.</param>
    /// <returns>
    ///     <see langword="true" /> if the two enumerable objects have the same length and each element at each position
    ///     in one enumerable is equal to the equivalent in the other, <see langword="false" /> otherwise.
    /// </returns>
    public static bool SequenceEqualsByObjectComparison(
        this IEnumerable<object>? left,
        IEnumerable<object>? right)
    {
        if (left == null)
        {
            return right == null;
        }

        if (right == null)
        {
            return false;
        }

        using IEnumerator<object> e1 = left.GetEnumerator();
        using IEnumerator<object> e2 = right.GetEnumerator();

        while (true)
        {
            var b1 = e1.MoveNext();
            var b2 = e2.MoveNext();

            if (b1 != b2)
            {
                return false;
            }

            if (b1)
            {
                if (!(e1.Current?.Equals(e2.Current) ?? e2.Current == null))
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
    }

    /// <summary>
    ///     Determines whether two enumerable objects have all members in sequence equal to one another by reference.
    /// </summary>
    /// <param name="left">The left operand enumerable.</param>
    /// <param name="right">The right operand enumerable.</param>
    /// <returns>
    ///     <see langword="true" /> if the two enumerable objects have the same length and each element at each position
    ///     in one enumerable is equal to the equivalent in the other, <see langword="false" /> otherwise.
    /// </returns>
    public static bool SequenceEqualsByReference(
        this IEnumerable<object>? left,
        IEnumerable<object>? right)
    {
        if (left == null)
        {
            return right == null;
        }

        if (right == null)
        {
            return false;
        }

        using IEnumerator<object> e1 = left.GetEnumerator();
        using IEnumerator<object> e2 = right.GetEnumerator();

        while (true)
        {
            var b1 = e1.MoveNext();
            var b2 = e2.MoveNext();

            if (b1 != b2)
            {
                return false;
            }

            if (b1)
            {
                if (!ReferenceEquals(
                        e1.Current,
                        e2.Current))
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
    }
}