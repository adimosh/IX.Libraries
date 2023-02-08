using System.Diagnostics.CodeAnalysis;

namespace IX.Core.Collections;

/// <summary>
///     Extensions for array types.
/// </summary>
public static partial class ArrayExtensions
{
    /// <summary>
    ///     Determines whether two arrays have all members in sequence equal to one another.
    /// </summary>
    /// <param name="left">The left operand array.</param>
    /// <param name="right">The right operand array.</param>
    /// <returns>
    ///     <see langword="true"/> if the two arrays have the same length and each element at each position
    ///     in one array is equal to the equivalent in the other, <see langword="false"/> otherwise.
    /// </returns>
    [SuppressMessage(
        "CodeQuality",
        "IDE0079:Remove unnecessary suppression",
        Justification = "Some developers use ReSharper.")]
    [SuppressMessage(
        "ReSharper",
        "LoopCanBeConvertedToQuery",
        Justification = "We don't want this. Instead, we want maximum performance out of the array.")]
    public static bool SequenceEquals(
        this byte[]? left,
        byte[]? right)
    {
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
            if (left[i] != right[i])
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    ///     Determines whether two arrays have all members in sequence equal to one another.
    /// </summary>
    /// <param name="left">The left operand array.</param>
    /// <param name="right">The right operand array.</param>
    /// <returns>
    ///     <see langword="true"/> if the two arrays have the same length and each element at each position
    ///     in one array is equal to the equivalent in the other, <see langword="false"/> otherwise.
    /// </returns>
    [SuppressMessage(
        "CodeQuality",
        "IDE0079:Remove unnecessary suppression",
        Justification = "Some developers use ReSharper.")]
    [SuppressMessage(
        "ReSharper",
        "LoopCanBeConvertedToQuery",
        Justification = "We don't want this. Instead, we want maximum performance out of the array.")]
    public static bool SequenceEquals(
        this sbyte[]? left,
        sbyte[]? right)
    {
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
            if (left[i] != right[i])
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    ///     Determines whether two arrays have all members in sequence equal to one another.
    /// </summary>
    /// <param name="left">The left operand array.</param>
    /// <param name="right">The right operand array.</param>
    /// <returns>
    ///     <see langword="true"/> if the two arrays have the same length and each element at each position
    ///     in one array is equal to the equivalent in the other, <see langword="false"/> otherwise.
    /// </returns>
    [SuppressMessage(
        "CodeQuality",
        "IDE0079:Remove unnecessary suppression",
        Justification = "Some developers use ReSharper.")]
    [SuppressMessage(
        "ReSharper",
        "LoopCanBeConvertedToQuery",
        Justification = "We don't want this. Instead, we want maximum performance out of the array.")]
    public static bool SequenceEquals(
        this short[]? left,
        short[]? right)
    {
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
            if (left[i] != right[i])
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    ///     Determines whether two arrays have all members in sequence equal to one another.
    /// </summary>
    /// <param name="left">The left operand array.</param>
    /// <param name="right">The right operand array.</param>
    /// <returns>
    ///     <see langword="true"/> if the two arrays have the same length and each element at each position
    ///     in one array is equal to the equivalent in the other, <see langword="false"/> otherwise.
    /// </returns>
    [SuppressMessage(
        "CodeQuality",
        "IDE0079:Remove unnecessary suppression",
        Justification = "Some developers use ReSharper.")]
    [SuppressMessage(
        "ReSharper",
        "LoopCanBeConvertedToQuery",
        Justification = "We don't want this. Instead, we want maximum performance out of the array.")]
    public static bool SequenceEquals(
        this ushort[]? left,
        ushort[]? right)
    {
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
            if (left[i] != right[i])
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    ///     Determines whether two arrays have all members in sequence equal to one another.
    /// </summary>
    /// <param name="left">The left operand array.</param>
    /// <param name="right">The right operand array.</param>
    /// <returns>
    ///     <see langword="true"/> if the two arrays have the same length and each element at each position
    ///     in one array is equal to the equivalent in the other, <see langword="false"/> otherwise.
    /// </returns>
    [SuppressMessage(
        "CodeQuality",
        "IDE0079:Remove unnecessary suppression",
        Justification = "Some developers use ReSharper.")]
    [SuppressMessage(
        "ReSharper",
        "LoopCanBeConvertedToQuery",
        Justification = "We don't want this. Instead, we want maximum performance out of the array.")]
    public static bool SequenceEquals(
        this char[]? left,
        char[]? right)
    {
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
            if (left[i] != right[i])
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    ///     Determines whether two arrays have all members in sequence equal to one another.
    /// </summary>
    /// <param name="left">The left operand array.</param>
    /// <param name="right">The right operand array.</param>
    /// <returns>
    ///     <see langword="true"/> if the two arrays have the same length and each element at each position
    ///     in one array is equal to the equivalent in the other, <see langword="false"/> otherwise.
    /// </returns>
    [SuppressMessage(
        "CodeQuality",
        "IDE0079:Remove unnecessary suppression",
        Justification = "Some developers use ReSharper.")]
    [SuppressMessage(
        "ReSharper",
        "LoopCanBeConvertedToQuery",
        Justification = "We don't want this. Instead, we want maximum performance out of the array.")]
    public static bool SequenceEquals(
        this int[]? left,
        int[]? right)
    {
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
            if (left[i] != right[i])
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    ///     Determines whether two arrays have all members in sequence equal to one another.
    /// </summary>
    /// <param name="left">The left operand array.</param>
    /// <param name="right">The right operand array.</param>
    /// <returns>
    ///     <see langword="true"/> if the two arrays have the same length and each element at each position
    ///     in one array is equal to the equivalent in the other, <see langword="false"/> otherwise.
    /// </returns>
    [SuppressMessage(
        "CodeQuality",
        "IDE0079:Remove unnecessary suppression",
        Justification = "Some developers use ReSharper.")]
    [SuppressMessage(
        "ReSharper",
        "LoopCanBeConvertedToQuery",
        Justification = "We don't want this. Instead, we want maximum performance out of the array.")]
    public static bool SequenceEquals(
        this uint[]? left,
        uint[]? right)
    {
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
            if (left[i] != right[i])
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    ///     Determines whether two arrays have all members in sequence equal to one another.
    /// </summary>
    /// <param name="left">The left operand array.</param>
    /// <param name="right">The right operand array.</param>
    /// <returns>
    ///     <see langword="true"/> if the two arrays have the same length and each element at each position
    ///     in one array is equal to the equivalent in the other, <see langword="false"/> otherwise.
    /// </returns>
    [SuppressMessage(
        "CodeQuality",
        "IDE0079:Remove unnecessary suppression",
        Justification = "Some developers use ReSharper.")]
    [SuppressMessage(
        "ReSharper",
        "LoopCanBeConvertedToQuery",
        Justification = "We don't want this. Instead, we want maximum performance out of the array.")]
    public static bool SequenceEquals(
        this long[]? left,
        long[]? right)
    {
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
            if (left[i] != right[i])
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    ///     Determines whether two arrays have all members in sequence equal to one another.
    /// </summary>
    /// <param name="left">The left operand array.</param>
    /// <param name="right">The right operand array.</param>
    /// <returns>
    ///     <see langword="true"/> if the two arrays have the same length and each element at each position
    ///     in one array is equal to the equivalent in the other, <see langword="false"/> otherwise.
    /// </returns>
    [SuppressMessage(
        "CodeQuality",
        "IDE0079:Remove unnecessary suppression",
        Justification = "Some developers use ReSharper.")]
    [SuppressMessage(
        "ReSharper",
        "LoopCanBeConvertedToQuery",
        Justification = "We don't want this. Instead, we want maximum performance out of the array.")]
    public static bool SequenceEquals(
        this ulong[]? left,
        ulong[]? right)
    {
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
            if (left[i] != right[i])
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    ///     Determines whether two arrays have all members in sequence equal to one another.
    /// </summary>
    /// <param name="left">The left operand array.</param>
    /// <param name="right">The right operand array.</param>
    /// <returns>
    ///     <see langword="true"/> if the two arrays have the same length and each element at each position
    ///     in one array is equal to the equivalent in the other, <see langword="false"/> otherwise.
    /// </returns>
    [SuppressMessage(
        "CodeQuality",
        "IDE0079:Remove unnecessary suppression",
        Justification = "Some developers use ReSharper.")]
    [SuppressMessage(
        "ReSharper",
        "LoopCanBeConvertedToQuery",
        Justification = "We don't want this. Instead, we want maximum performance out of the array.")]
    [SuppressMessage(
        "ReSharper",
        "CompareOfFloatsByEqualityOperator",
        Justification = "This is raw comparison and equation, we're not interested in the results of possible tolerance.")]
    public static bool SequenceEquals(
        this float[]? left,
        float[]? right)
    {
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
            if (left[i] != right[i])
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    ///     Determines whether two arrays have all members in sequence equal to one another.
    /// </summary>
    /// <param name="left">The left operand array.</param>
    /// <param name="right">The right operand array.</param>
    /// <param name="tolerance">The tolerance under which to consider values equal.</param>
    /// <returns>
    ///     <see langword="true"/> if the two arrays have the same length and each element at each position
    ///     in one array is within tolerance to the equivalent in the other, <see langword="false"/> otherwise.
    /// </returns>
    [SuppressMessage(
        "CodeQuality",
        "IDE0079:Remove unnecessary suppression",
        Justification = "Some developers use ReSharper.")]
    [SuppressMessage(
        "ReSharper",
        "LoopCanBeConvertedToQuery",
        Justification = "We don't want this. Instead, we want maximum performance out of the array.")]
    public static bool SequenceEquals(
        this float[]? left,
        float[]? right,
        float tolerance)
    {
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

        tolerance = Math.Abs(tolerance);

        for (var i = 0; i < left.Length; i++)
        {
            if (Math.Abs(left[i] - right[i]) > tolerance)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    ///     Determines whether two arrays have all members in sequence equal to one another.
    /// </summary>
    /// <param name="left">The left operand array.</param>
    /// <param name="right">The right operand array.</param>
    /// <returns>
    ///     <see langword="true"/> if the two arrays have the same length and each element at each position
    ///     in one array is equal to the equivalent in the other, <see langword="false"/> otherwise.
    /// </returns>
    [SuppressMessage(
        "CodeQuality",
        "IDE0079:Remove unnecessary suppression",
        Justification = "Some developers use ReSharper.")]
    [SuppressMessage(
        "ReSharper",
        "LoopCanBeConvertedToQuery",
        Justification = "We don't want this. Instead, we want maximum performance out of the array.")]
    [SuppressMessage(
        "ReSharper",
        "CompareOfFloatsByEqualityOperator",
        Justification = "This is raw comparison and equation, we're not interested in the results of possible tolerance.")]
    public static bool SequenceEquals(
        this double[]? left,
        double[]? right)
    {
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
            if (left[i] != right[i])
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    ///     Determines whether two arrays have all members in sequence equal to one another.
    /// </summary>
    /// <param name="left">The left operand array.</param>
    /// <param name="right">The right operand array.</param>
    /// <param name="tolerance">The tolerance under which to consider values equal.</param>
    /// <returns>
    ///     <see langword="true"/> if the two arrays have the same length and each element at each position
    ///     in one array is within tolerance to the equivalent in the other, <see langword="false"/> otherwise.
    /// </returns>
    [SuppressMessage(
        "CodeQuality",
        "IDE0079:Remove unnecessary suppression",
        Justification = "Some developers use ReSharper.")]
    [SuppressMessage(
        "ReSharper",
        "LoopCanBeConvertedToQuery",
        Justification = "We don't want this. Instead, we want maximum performance out of the array.")]
    public static bool SequenceEquals(
        this double[]? left,
        double[]? right,
        double tolerance)
    {
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

        tolerance = Math.Abs(tolerance);

        for (var i = 0; i < left.Length; i++)
        {
            if (Math.Abs(left[i] - right[i]) > tolerance)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    ///     Determines whether two arrays have all members in sequence equal to one another.
    /// </summary>
    /// <param name="left">The left operand array.</param>
    /// <param name="right">The right operand array.</param>
    /// <returns>
    ///     <see langword="true"/> if the two arrays have the same length and each element at each position
    ///     in one array is equal to the equivalent in the other, <see langword="false"/> otherwise.
    /// </returns>
    [SuppressMessage(
        "CodeQuality",
        "IDE0079:Remove unnecessary suppression",
        Justification = "Some developers use ReSharper.")]
    [SuppressMessage(
        "ReSharper",
        "LoopCanBeConvertedToQuery",
        Justification = "We don't want this. Instead, we want maximum performance out of the array.")]
    public static bool SequenceEquals(
        this decimal[]? left,
        decimal[]? right)
    {
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
            if (left[i] != right[i])
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    ///     Determines whether two arrays have all members in sequence equal to one another.
    /// </summary>
    /// <param name="left">The left operand array.</param>
    /// <param name="right">The right operand array.</param>
    /// <returns>
    ///     <see langword="true"/> if the two arrays have the same length and each element at each position
    ///     in one array is equal to the equivalent in the other, <see langword="false"/> otherwise.
    /// </returns>
    [SuppressMessage(
        "CodeQuality",
        "IDE0079:Remove unnecessary suppression",
        Justification = "Some developers use ReSharper.")]
    [SuppressMessage(
        "ReSharper",
        "LoopCanBeConvertedToQuery",
        Justification = "We don't want this. Instead, we want maximum performance out of the array.")]
    public static bool SequenceEquals(
        this DateTime[]? left,
        DateTime[]? right)
    {
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
            if (left[i] != right[i])
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    ///     Determines whether two arrays have all members in sequence equal to one another.
    /// </summary>
    /// <param name="left">The left operand array.</param>
    /// <param name="right">The right operand array.</param>
    /// <returns>
    ///     <see langword="true"/> if the two arrays have the same length and each element at each position
    ///     in one array is equal to the equivalent in the other, <see langword="false"/> otherwise.
    /// </returns>
    [SuppressMessage(
        "CodeQuality",
        "IDE0079:Remove unnecessary suppression",
        Justification = "Some developers use ReSharper.")]
    [SuppressMessage(
        "ReSharper",
        "LoopCanBeConvertedToQuery",
        Justification = "We don't want this. Instead, we want maximum performance out of the array.")]
    public static bool SequenceEquals(
        this bool[]? left,
        bool[]? right)
    {
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
            if (left[i] != right[i])
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    ///     Determines whether two arrays have all members in sequence equal to one another.
    /// </summary>
    /// <param name="left">The left operand array.</param>
    /// <param name="right">The right operand array.</param>
    /// <returns>
    ///     <see langword="true"/> if the two arrays have the same length and each element at each position
    ///     in one array is equal to the equivalent in the other, <see langword="false"/> otherwise.
    /// </returns>
    [SuppressMessage(
        "CodeQuality",
        "IDE0079:Remove unnecessary suppression",
        Justification = "Some developers use ReSharper.")]
    [SuppressMessage(
        "ReSharper",
        "LoopCanBeConvertedToQuery",
        Justification = "We don't want this. Instead, we want maximum performance out of the array.")]
    public static bool SequenceEquals(
        this TimeSpan[]? left,
        TimeSpan[]? right)
    {
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
            if (left[i] != right[i])
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    ///     Determines whether two arrays have all members in sequence equal to one another.
    /// </summary>
    /// <param name="left">The left operand array.</param>
    /// <param name="right">The right operand array.</param>
    /// <returns>
    ///     <see langword="true"/> if the two arrays have the same length and each element at each position
    ///     in one array is equal to the equivalent in the other, <see langword="false"/> otherwise.
    /// </returns>
    [SuppressMessage(
        "CodeQuality",
        "IDE0079:Remove unnecessary suppression",
        Justification = "Some developers use ReSharper.")]
    [SuppressMessage(
        "ReSharper",
        "LoopCanBeConvertedToQuery",
        Justification = "We don't want this. Instead, we want maximum performance out of the array.")]
    public static bool SequenceEquals(
        this string[]? left,
        string[]? right)
    {
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
            if (left[i] != right[i])
            {
                return false;
            }
        }

        return true;
    }
}