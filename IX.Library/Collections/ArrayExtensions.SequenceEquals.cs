using System.Diagnostics.CodeAnalysis;

namespace IX.Library.Collections;

/// <summary>
///     Extensions for array types.
/// </summary>
public static partial class ArrayExtensions
{
    /// <summary>
    ///     Determines whether two enumerable objects have all members in sequence equal to one another by using a comparer.
    /// </summary>
    /// <typeparam name="T">The type of the enumerable item.</typeparam>
    /// <param name="left">The left operand enumerable.</param>
    /// <param name="right">The right operand enumerable.</param>
    /// <param name="comparer">The comparer to use when equating items.</param>
    /// <returns>
    ///     <see langword="true" /> if the two enumerable objects have the same length and each element at each position
    ///     in one enumerable is equal to the equivalent in the other, <see langword="false" /> otherwise.
    /// </returns>
    [SuppressMessage(
        "ReSharper",
        "LoopCanBeConvertedToQuery",
        Justification = "A for loop on an array is going to be faster.")]
    [SuppressMessage(
        "CodeQuality",
        "IDE0079:Remove unnecessary suppression",
        Justification = "ReSharper is used for this project.")]
    public static bool SequenceEquals<T>(
        this T[]? left,
        T[]? right,
        IEqualityComparer<T> comparer)
    {
        IEqualityComparer<T> localComparer = Requires.NotNull(comparer);

        if (left == null)
        {
            return right == null;
        }

        if (right == null)
        {
            return false;
        }

        if (left.Length != right.Length)
        {
            return false;
        }

        for (var i = 0; i < left.Length; i++)
        {
            if (!localComparer.Equals(
                    left[i],
                    right[i]))
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    ///     Determines whether two enumerable objects have all members in sequence equal to one another by using a comparer.
    /// </summary>
    /// <typeparam name="T">The type of the enumerable item.</typeparam>
    /// <param name="left">The left operand enumerable.</param>
    /// <param name="right">The right operand enumerable.</param>
    /// <param name="comparer">The comparer to use when equating items.</param>
    /// <returns>
    ///     <see langword="true" /> if the two enumerable objects have the same length and each element at each position
    ///     in one enumerable is equal to the equivalent in the other, <see langword="false" /> otherwise.
    /// </returns>
    [SuppressMessage(
        "ReSharper",
        "LoopCanBeConvertedToQuery",
        Justification = "A for loop on an array is going to be faster.")]
    [SuppressMessage(
        "CodeQuality",
        "IDE0079:Remove unnecessary suppression",
        Justification = "ReSharper is used for this project.")]
    public static bool SequenceEquals<T>(
        this T[]? left,
        T[]? right,
        InFunc<T, T, bool> comparer)
    {
        InFunc<T, T, bool> localComparer = Requires.NotNull(comparer);

        if (left == null)
        {
            return right == null;
        }

        if (right == null)
        {
            return false;
        }

        if (left.Length != right.Length)
        {
            return false;
        }

        for (var i = 0; i < left.Length; i++)
        {
            if (!localComparer(
                    in left[i],
                    in right[i]))
            {
                return false;
            }
        }

        return true;
    }
}