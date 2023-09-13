namespace IX.Library.Collections;

/// <summary>
///     Extensions for array types of <see cref="IEquatable{T}" />.
/// </summary>
[PublicAPI]
public static class ArrayOfIEquatableOfTSequenceEqualsExtensions
{
    /// <summary>
    ///     Determines whether two arrays have all members in sequence equal to one another.
    /// </summary>
    /// <typeparam name="T">The type of the item in the array.</typeparam>
    /// <param name="left">The left operand array.</param>
    /// <param name="right">The right operand array.</param>
    /// <returns>
    ///     The result of the comparison.
    /// </returns>
    public static bool SequenceEquals<T>(
        this T[]? left,
        T[]? right)
        where T : IEquatable<T>
    {
        if (left == null)
        {
            // Left is null, we return based on whether or not right is null as well
            return right == null;
        }

        if (right == null)
        {
            // Right is null, but not left
            return false;
        }

        var i = 0;
        while (true)
        {
            var b1 = i < left.Length;
            var b2 = i < right.Length;

            if (!b1 && !b2)
            {
                // We have reached the end
                return true;
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
                return false;
            }

            if (c2 == null)
            {
                // Right is null, left is not
                return false;
            }

            var cr = c1.Equals(c2);
            if (!cr)
            {
                // We have reached the first non-null difference
                return cr;
            }

            // No difference at this level, let's proceed
            i++;
        }
    }
}