namespace IX.Core.Collections;

/// <summary>
///     Extensions for array types.
/// </summary>
public static partial class ArrayExtensions
{
    /// <summary>
    ///     Compares two arrays to one another sequentially.
    /// </summary>
    /// <typeparam name="T">The type of the item in the array.</typeparam>
    /// <param name="left">The left operand array.</param>
    /// <param name="right">The right operand array.</param>
    /// <param name="comparer">The comparer to use when equating items.</param>
    /// <returns>The result of the comparison.</returns>
    public static int SequenceCompare<T>(
        this T[]? left,
        T[]? right,
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

        var i = 0;
        while (true)
        {
            var b1 = i < left.Length;
            var b2 = i < right.Length;

            if (!b1 && !b2)
            {
                // We have reached the end
                return 0;
            }

            T? c1 = b1 ? left[i] : default;
            T? c2 = b2 ? right[i] : default;

            if (c1 == null)
            {
                if (c2 == null)
                {
                    // Both are null, go to next
                    i++;

                    continue;
                }

                // Left is null, right is not
                return int.MinValue;
            }

            if (c2 == null)
            {
                // Right is null, left is not
                return int.MaxValue;
            }

            var cr = localComparer.Compare(
                c1,
                c2);
            if (cr != 0)
            {
                // We have reached the first difference
                return cr;
            }

            // No difference at this level, let's proceed
            i++;
        }
    }

    /// <summary>
    ///     Compares two arrays to one another sequentially.
    /// </summary>
    /// <typeparam name="T">The type of the item in the array.</typeparam>
    /// <param name="left">The left operand array.</param>
    /// <param name="right">The right operand array.</param>
    /// <param name="comparer">The comparer to use when equating items.</param>
    /// <returns>The result of the comparison.</returns>
    public static int SequenceCompare<T>(
        this T[]? left,
        T[]? right,
        InFunc<T, T, int> comparer)
    {
        InFunc<T, T, int> localComparer = Requires.NotNull(comparer);

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

        var i = 0;
        while (true)
        {
            var b1 = i < left.Length;
            var b2 = i < right.Length;

            if (!b1 && !b2)
            {
                // We have reached the end
                return 0;
            }

            T? c1 = b1 ? left[i] : default;
            T? c2 = b2 ? right[i] : default;

            if (c1 == null)
            {
                if (c2 == null)
                {
                    // Both are null, go to next
                    i++;

                    continue;
                }

                // Left is null, right is not
                return int.MinValue;
            }

            if (c2 == null)
            {
                // Right is null, left is not
                return int.MaxValue;
            }

            var cr = localComparer(
                in c1,
                in c2);
            if (cr != 0)
            {
                // We have reached the first difference
                return cr;
            }

            // No difference at this level, let's proceed
            i++;
        }
    }
}