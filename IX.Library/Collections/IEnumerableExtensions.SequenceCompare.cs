using System.Diagnostics.CodeAnalysis;

namespace IX.Core.Collections;

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
    ///     Compares two enumerable sequences to one another.
    /// </summary>
    /// <typeparam name="T">The type of the enumerable item.</typeparam>
    /// <param name="left">The left operand enumerable.</param>
    /// <param name="right">The right operand enumerable.</param>
    /// <returns>The result of the comparison.</returns>
    public static int SequenceCompare<T>(
        this IEnumerable<IComparable<T>>? left,
        IEnumerable<T>? right)
    {
        if (left == null)
        {
            // Left is null, we return based on whether or not right is null as well
            return right == null ? 0 : int.MinValue;
        }

        if (right == null)
        {
            // Right is null, but not left
            return int.MaxValue;
        }

        using IEnumerator<IComparable<T>> e1 = left.GetEnumerator();
        using IEnumerator<T> e2 = right.GetEnumerator();

        while (true)
        {
            var b1 = e1.MoveNext();
            var b2 = e2.MoveNext();

            if (!b1 && !b2)
            {
                return 0;
            }

            IComparable<T>? c1 = b1 ? e1.Current : default;
            T c2 = b2 ? e2.Current : default!;

            var cr = c1?.CompareTo(c2) ?? (c2 == null ? 0 : 1);
            if (cr != 0)
            {
                return cr;
            }
        }
    }

    /// <summary>
    ///     Compares two enumerable sequences to one another.
    /// </summary>
    /// <param name="left">The left operand enumerable.</param>
    /// <param name="right">The right operand enumerable.</param>
    /// <returns>The result of the comparison.</returns>
    public static int SequenceCompare(
        this IEnumerable<IComparable>? left,
        IEnumerable<object>? right)
    {
        if (left == null)
        {
            // Left is null, we return based on whether or not right is null as well
            return right == null ? 0 : int.MinValue;
        }

        if (right == null)
        {
            // Right is null, but not left
            return int.MaxValue;
        }

        using IEnumerator<IComparable> e1 = left.GetEnumerator();
        using IEnumerator<object> e2 = right.GetEnumerator();

        while (true)
        {
            var b1 = e1.MoveNext();
            var b2 = e2.MoveNext();

            if (!b1 && !b2)
            {
                return 0;
            }

            IComparable? c1 = b1 ? e1.Current : default;
            var c2 = b2 ? e2.Current : default;

            var cr = c1?.CompareTo(c2) ?? (c2 == null ? 0 : 1);
            if (cr != 0)
            {
                return cr;
            }
        }
    }

    /// <summary>
    ///     Compares two enumerable sequences to one another with the aid of a comparer.
    /// </summary>
    /// <typeparam name="T">The type of the enumerable item.</typeparam>
    /// <param name="left">The left operand enumerable.</param>
    /// <param name="right">The right operand enumerable.</param>
    /// <param name="comparer">The comparer to use when equating items.</param>
    /// <returns>The result of the comparison.</returns>
    public static int SequenceCompare<T>(
        this IEnumerable<T>? left,
        IEnumerable<T>? right,
        IComparer<T> comparer)
    {
        IComparer<T> localComparer = Requires.NotNull(comparer);

        if (left == null)
        {
            // Left is null, we return based on whether or not right is null as well
            return right == null ? 0 : int.MinValue;
        }

        if (right == null)
        {
            // Right is null, but not left
            return int.MaxValue;
        }

        using IEnumerator<T> e1 = left.GetEnumerator();
        using IEnumerator<T> e2 = right.GetEnumerator();

        while (true)
        {
            var b1 = e1.MoveNext();
            var b2 = e2.MoveNext();

            if (!b1 && !b2)
            {
                return 0;
            }

            T c1 = b1 ? e1.Current : default!;
            T c2 = b2 ? e2.Current : default!;

            var cr = localComparer.Compare(
                c1,
                c2);
            if (cr != 0)
            {
                return cr;
            }
        }
    }

    /// <summary>
    ///     Compares two enumerable sequences to one another with the aid of a comparer function.
    /// </summary>
    /// <typeparam name="T">The type of the enumerable item.</typeparam>
    /// <param name="left">The left operand enumerable.</param>
    /// <param name="right">The right operand enumerable.</param>
    /// <param name="comparer">The comparer to use when equating items.</param>
    /// <returns>The result of the comparison.</returns>
    public static int SequenceCompare<T>(
        this IEnumerable<T>? left,
        IEnumerable<T>? right,
        Func<T, T, int> comparer)
    {
        Func<T, T, int> localComparer = Requires.NotNull(comparer);

        if (left == null)
        {
            // Left is null, we return based on whether or not right is null as well
            return right == null ? 0 : int.MinValue;
        }

        if (right == null)
        {
            // Right is null, but not left
            return int.MaxValue;
        }

        using IEnumerator<T> e1 = left.GetEnumerator();
        using IEnumerator<T> e2 = right.GetEnumerator();

        while (true)
        {
            var b1 = e1.MoveNext();
            var b2 = e2.MoveNext();

            if (!b1 && !b2)
            {
                return 0;
            }

            T c1 = b1 ? e1.Current : default!;
            T c2 = b2 ? e2.Current : default!;

            var cr = localComparer(
                c1,
                c2);
            if (cr != 0)
            {
                return cr;
            }
        }
    }

    /// <summary>
    ///     Compares two enumerable sequences to one another, by object comparison.
    /// </summary>
    /// <param name="left">The left operand enumerable.</param>
    /// <param name="right">The right operand enumerable.</param>
    /// <returns>The result of the comparison.</returns>
    public static int SequenceCompareByObjectComparison(
        this IEnumerable<object>? left,
        IEnumerable<object>? right)
    {
        if (left == null)
        {
            // Left is null, we return based on whether or not right is null as well
            return right == null ? 0 : int.MinValue;
        }

        if (right == null)
        {
            // Right is null, but not left
            return int.MaxValue;
        }

        using IEnumerator<object> e1 = left.GetEnumerator();
        using IEnumerator<object> e2 = right.GetEnumerator();

        while (true)
        {
            var b1 = e1.MoveNext();
            var b2 = e2.MoveNext();

            if (!b1 && !b2)
            {
                return 0;
            }

            var c1 = b1 ? e1.Current : default;
            var c2 = b2 ? e2.Current : default;

            var cr = c1 == null && c2 != null ? -1 : c1 != null && c2 == null ? 1 : c1?.Equals(c2) ?? true ? 0 : -1;
            if (cr != 0)
            {
                return cr;
            }
        }
    }

    /// <summary>
    ///     Compares two enumerable sequences to one another, by reference.
    /// </summary>
    /// <param name="left">The left operand enumerable.</param>
    /// <param name="right">The right operand enumerable.</param>
    /// <returns>The result of the comparison.</returns>
    public static int SequenceCompareByReference(
        this IEnumerable<object>? left,
        IEnumerable<object>? right)
    {
        if (left == null)
        {
            // Left is null, we return based on whether or not right is null as well
            return right == null ? 0 : int.MinValue;
        }

        if (right == null)
        {
            // Right is null, but not left
            return int.MaxValue;
        }

        using IEnumerator<object> e1 = left.GetEnumerator();
        using IEnumerator<object> e2 = right.GetEnumerator();

        while (true)
        {
            var b1 = e1.MoveNext();
            var b2 = e2.MoveNext();

            if (!b1 && !b2)
            {
                return 0;
            }

            var c1 = b1 ? e1.Current : default;
            var c2 = b2 ? e2.Current : default;

            var cr = c1 == null && c2 != null ? -1 :
            c1 != null && c2 == null ? 1 :
            ReferenceEquals(
                c1,
                c2) ? 0 : -1;
            if (cr != 0)
            {
                return cr;
            }
        }
    }
}