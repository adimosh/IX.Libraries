using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace IX.Core.Collections;

/// <summary>
/// Extensions for IEnumerable.
/// </summary>
[SuppressMessage(
    "ReSharper",
    "InconsistentNaming",
    Justification = "These are extensions for IEnumerable, so we must allow this.")]
public static partial class IEnumerableExtensions
{
    /// <summary>
    /// Equates two enumerable collections sequentially.
    /// </summary>
    /// <param name="left">The left item of comparison.</param>
    /// <param name="right">The right item of comparison.</param>
    /// <returns>A sequence of comparison results.</returns>
    public static IEnumerable<bool> EquateSequentially(this IEnumerable<byte>? left, IEnumerable<byte>? right)
    {
        if (left == null && right == null)
        {
            yield return true;
            yield break;
        }

        using IEnumerator<byte> leftEnumerator = left?.GetEnumerator() ?? EmptyEnumerator<byte>.Get();
        using IEnumerator<byte> rightEnumerator = right?.GetEnumerator() ?? EmptyEnumerator<byte>.Get();

        var leftBool = leftEnumerator.MoveNext();
        var rightBool = rightEnumerator.MoveNext();

        while (leftBool || rightBool)
        {
            var leftCompare = leftBool ? leftEnumerator.Current : default;
            var rightCompare = rightBool ? rightEnumerator.Current : default;

            yield return leftCompare == rightCompare;

            leftBool = leftEnumerator.MoveNext();
            rightBool = rightEnumerator.MoveNext();
        }
    }

    /// <summary>
    /// Equates two enumerable collections sequentially, skipping items defined as &quot;empty&quot;.
    /// </summary>
    /// <param name="left">The left item of comparison.</param>
    /// <param name="right">The right item of comparison.</param>
    /// <param name="determineEmpty">A function that determines whether an item is &quot;empty&quot; or not.</param>
    /// <returns>A sequence of comparison results.</returns>
    public static IEnumerable<bool> EquateSequentially(this IEnumerable<byte>? left, IEnumerable<byte>? right, Func<byte, bool> determineEmpty)
    {
        var localDetermineEmpty = Requires.NotNull(determineEmpty);

        if (left == null && right == null)
        {
            yield return true;
            yield break;
        }

        using IEnumerator<byte> leftEnumerator = left?.GetEnumerator() ?? EmptyEnumerator<byte>.Get();
        using IEnumerator<byte> rightEnumerator = right?.GetEnumerator() ?? EmptyEnumerator<byte>.Get();

        var leftBool = EquateSequentiallyMoveNext(leftEnumerator);
        var rightBool = EquateSequentiallyMoveNext(rightEnumerator);

        while (leftBool || rightBool)
        {
            var leftCompare = leftBool ? leftEnumerator.Current : default;
            var rightCompare = rightBool ? rightEnumerator.Current : default;

            yield return leftCompare == rightCompare;

            leftBool = EquateSequentiallyMoveNext(leftEnumerator);
            rightBool = EquateSequentiallyMoveNext(rightEnumerator);
        }

        bool EquateSequentiallyMoveNext(IEnumerator<byte> source)
        {
            init:
            var moved = source.MoveNext();

            if (!moved)
            {
                return false;
            }

            if (localDetermineEmpty(source.Current))
            {
                goto init;
            }

            return true;
        }
    }

    /// <summary>
    /// Equates two enumerable collections sequentially.
    /// </summary>
    /// <param name="left">The left item of comparison.</param>
    /// <param name="right">The right item of comparison.</param>
    /// <returns>A sequence of comparison results.</returns>
    public static IEnumerable<bool> EquateSequentially(this IEnumerable<sbyte>? left, IEnumerable<sbyte>? right)
    {
        if (left == null && right == null)
        {
            yield return true;
            yield break;
        }

        using IEnumerator<sbyte> leftEnumerator = left?.GetEnumerator() ?? EmptyEnumerator<sbyte>.Get();
        using IEnumerator<sbyte> rightEnumerator = right?.GetEnumerator() ?? EmptyEnumerator<sbyte>.Get();

        var leftBool = leftEnumerator.MoveNext();
        var rightBool = rightEnumerator.MoveNext();

        while (leftBool || rightBool)
        {
            var leftCompare = leftBool ? leftEnumerator.Current : default;
            var rightCompare = rightBool ? rightEnumerator.Current : default;

            yield return leftCompare == rightCompare;

            leftBool = leftEnumerator.MoveNext();
            rightBool = rightEnumerator.MoveNext();
        }
    }

    /// <summary>
    /// Equates two enumerable collections sequentially, skipping items defined as &quot;empty&quot;.
    /// </summary>
    /// <param name="left">The left item of comparison.</param>
    /// <param name="right">The right item of comparison.</param>
    /// <param name="determineEmpty">A function that determines whether an item is &quot;empty&quot; or not.</param>
    /// <returns>A sequence of comparison results.</returns>
    public static IEnumerable<bool> EquateSequentially(this IEnumerable<sbyte>? left, IEnumerable<sbyte>? right, Func<sbyte, bool> determineEmpty)
    {
        var localDetermineEmpty = Requires.NotNull(determineEmpty);

        if (left == null && right == null)
        {
            yield return true;
            yield break;
        }

        using IEnumerator<sbyte> leftEnumerator = left?.GetEnumerator() ?? EmptyEnumerator<sbyte>.Get();
        using IEnumerator<sbyte> rightEnumerator = right?.GetEnumerator() ?? EmptyEnumerator<sbyte>.Get();

        var leftBool = EquateSequentiallyMoveNext(leftEnumerator);
        var rightBool = EquateSequentiallyMoveNext(rightEnumerator);

        while (leftBool || rightBool)
        {
            var leftCompare = leftBool ? leftEnumerator.Current : default;
            var rightCompare = rightBool ? rightEnumerator.Current : default;

            yield return leftCompare == rightCompare;

            leftBool = EquateSequentiallyMoveNext(leftEnumerator);
            rightBool = EquateSequentiallyMoveNext(rightEnumerator);
        }

        bool EquateSequentiallyMoveNext(IEnumerator<sbyte> source)
        {
            init:
            var moved = source.MoveNext();

            if (!moved)
            {
                return false;
            }

            if (localDetermineEmpty(source.Current))
            {
                goto init;
            }

            return true;
        }
    }

    /// <summary>
    /// Equates two enumerable collections sequentially.
    /// </summary>
    /// <param name="left">The left item of comparison.</param>
    /// <param name="right">The right item of comparison.</param>
    /// <returns>A sequence of comparison results.</returns>
    public static IEnumerable<bool> EquateSequentially(this IEnumerable<short>? left, IEnumerable<short>? right)
    {
        if (left == null && right == null)
        {
            yield return true;
            yield break;
        }

        using IEnumerator<short> leftEnumerator = left?.GetEnumerator() ?? EmptyEnumerator<short>.Get();
        using IEnumerator<short> rightEnumerator = right?.GetEnumerator() ?? EmptyEnumerator<short>.Get();

        var leftBool = leftEnumerator.MoveNext();
        var rightBool = rightEnumerator.MoveNext();

        while (leftBool || rightBool)
        {
            var leftCompare = leftBool ? leftEnumerator.Current : default;
            var rightCompare = rightBool ? rightEnumerator.Current : default;

            yield return leftCompare == rightCompare;

            leftBool = leftEnumerator.MoveNext();
            rightBool = rightEnumerator.MoveNext();
        }
    }

    /// <summary>
    /// Equates two enumerable collections sequentially, skipping items defined as &quot;empty&quot;.
    /// </summary>
    /// <param name="left">The left item of comparison.</param>
    /// <param name="right">The right item of comparison.</param>
    /// <param name="determineEmpty">A function that determines whether an item is &quot;empty&quot; or not.</param>
    /// <returns>A sequence of comparison results.</returns>
    public static IEnumerable<bool> EquateSequentially(this IEnumerable<short>? left, IEnumerable<short>? right, Func<short, bool> determineEmpty)
    {
        var localDetermineEmpty = Requires.NotNull(determineEmpty);

        if (left == null && right == null)
        {
            yield return true;
            yield break;
        }

        using IEnumerator<short> leftEnumerator = left?.GetEnumerator() ?? EmptyEnumerator<short>.Get();
        using IEnumerator<short> rightEnumerator = right?.GetEnumerator() ?? EmptyEnumerator<short>.Get();

        var leftBool = EquateSequentiallyMoveNext(leftEnumerator);
        var rightBool = EquateSequentiallyMoveNext(rightEnumerator);

        while (leftBool || rightBool)
        {
            var leftCompare = leftBool ? leftEnumerator.Current : default;
            var rightCompare = rightBool ? rightEnumerator.Current : default;

            yield return leftCompare == rightCompare;

            leftBool = EquateSequentiallyMoveNext(leftEnumerator);
            rightBool = EquateSequentiallyMoveNext(rightEnumerator);
        }

        bool EquateSequentiallyMoveNext(IEnumerator<short> source)
        {
            init:
            var moved = source.MoveNext();

            if (!moved)
            {
                return false;
            }

            if (localDetermineEmpty(source.Current))
            {
                goto init;
            }

            return true;
        }
    }

    /// <summary>
    /// Equates two enumerable collections sequentially.
    /// </summary>
    /// <param name="left">The left item of comparison.</param>
    /// <param name="right">The right item of comparison.</param>
    /// <returns>A sequence of comparison results.</returns>
    public static IEnumerable<bool> EquateSequentially(this IEnumerable<ushort>? left, IEnumerable<ushort>? right)
    {
        if (left == null && right == null)
        {
            yield return true;
            yield break;
        }

        using IEnumerator<ushort> leftEnumerator = left?.GetEnumerator() ?? EmptyEnumerator<ushort>.Get();
        using IEnumerator<ushort> rightEnumerator = right?.GetEnumerator() ?? EmptyEnumerator<ushort>.Get();

        var leftBool = leftEnumerator.MoveNext();
        var rightBool = rightEnumerator.MoveNext();

        while (leftBool || rightBool)
        {
            var leftCompare = leftBool ? leftEnumerator.Current : default;
            var rightCompare = rightBool ? rightEnumerator.Current : default;

            yield return leftCompare == rightCompare;

            leftBool = leftEnumerator.MoveNext();
            rightBool = rightEnumerator.MoveNext();
        }
    }

    /// <summary>
    /// Equates two enumerable collections sequentially, skipping items defined as &quot;empty&quot;.
    /// </summary>
    /// <param name="left">The left item of comparison.</param>
    /// <param name="right">The right item of comparison.</param>
    /// <param name="determineEmpty">A function that determines whether an item is &quot;empty&quot; or not.</param>
    /// <returns>A sequence of comparison results.</returns>
    public static IEnumerable<bool> EquateSequentially(this IEnumerable<ushort>? left, IEnumerable<ushort>? right, Func<ushort, bool> determineEmpty)
    {
        var localDetermineEmpty = Requires.NotNull(determineEmpty);

        if (left == null && right == null)
        {
            yield return true;
            yield break;
        }

        using IEnumerator<ushort> leftEnumerator = left?.GetEnumerator() ?? EmptyEnumerator<ushort>.Get();
        using IEnumerator<ushort> rightEnumerator = right?.GetEnumerator() ?? EmptyEnumerator<ushort>.Get();

        var leftBool = EquateSequentiallyMoveNext(leftEnumerator);
        var rightBool = EquateSequentiallyMoveNext(rightEnumerator);

        while (leftBool || rightBool)
        {
            var leftCompare = leftBool ? leftEnumerator.Current : default;
            var rightCompare = rightBool ? rightEnumerator.Current : default;

            yield return leftCompare == rightCompare;

            leftBool = EquateSequentiallyMoveNext(leftEnumerator);
            rightBool = EquateSequentiallyMoveNext(rightEnumerator);
        }

        bool EquateSequentiallyMoveNext(IEnumerator<ushort> source)
        {
            init:
            var moved = source.MoveNext();

            if (!moved)
            {
                return false;
            }

            if (localDetermineEmpty(source.Current))
            {
                goto init;
            }

            return true;
        }
    }

    /// <summary>
    /// Equates two enumerable collections sequentially.
    /// </summary>
    /// <param name="left">The left item of comparison.</param>
    /// <param name="right">The right item of comparison.</param>
    /// <returns>A sequence of comparison results.</returns>
    public static IEnumerable<bool> EquateSequentially(this IEnumerable<char>? left, IEnumerable<char>? right)
    {
        if (left == null && right == null)
        {
            yield return true;
            yield break;
        }

        using IEnumerator<char> leftEnumerator = left?.GetEnumerator() ?? EmptyEnumerator<char>.Get();
        using IEnumerator<char> rightEnumerator = right?.GetEnumerator() ?? EmptyEnumerator<char>.Get();

        var leftBool = leftEnumerator.MoveNext();
        var rightBool = rightEnumerator.MoveNext();

        while (leftBool || rightBool)
        {
            var leftCompare = leftBool ? leftEnumerator.Current : default;
            var rightCompare = rightBool ? rightEnumerator.Current : default;

            yield return leftCompare == rightCompare;

            leftBool = leftEnumerator.MoveNext();
            rightBool = rightEnumerator.MoveNext();
        }
    }

    /// <summary>
    /// Equates two enumerable collections sequentially, skipping items defined as &quot;empty&quot;.
    /// </summary>
    /// <param name="left">The left item of comparison.</param>
    /// <param name="right">The right item of comparison.</param>
    /// <param name="determineEmpty">A function that determines whether an item is &quot;empty&quot; or not.</param>
    /// <returns>A sequence of comparison results.</returns>
    public static IEnumerable<bool> EquateSequentially(this IEnumerable<char>? left, IEnumerable<char>? right, Func<char, bool> determineEmpty)
    {
        var localDetermineEmpty = Requires.NotNull(determineEmpty);

        if (left == null && right == null)
        {
            yield return true;
            yield break;
        }

        using IEnumerator<char> leftEnumerator = left?.GetEnumerator() ?? EmptyEnumerator<char>.Get();
        using IEnumerator<char> rightEnumerator = right?.GetEnumerator() ?? EmptyEnumerator<char>.Get();

        var leftBool = EquateSequentiallyMoveNext(leftEnumerator);
        var rightBool = EquateSequentiallyMoveNext(rightEnumerator);

        while (leftBool || rightBool)
        {
            var leftCompare = leftBool ? leftEnumerator.Current : default;
            var rightCompare = rightBool ? rightEnumerator.Current : default;

            yield return leftCompare == rightCompare;

            leftBool = EquateSequentiallyMoveNext(leftEnumerator);
            rightBool = EquateSequentiallyMoveNext(rightEnumerator);
        }

        bool EquateSequentiallyMoveNext(IEnumerator<char> source)
        {
            init:
            var moved = source.MoveNext();

            if (!moved)
            {
                return false;
            }

            if (localDetermineEmpty(source.Current))
            {
                goto init;
            }

            return true;
        }
    }

    /// <summary>
    /// Equates two enumerable collections sequentially.
    /// </summary>
    /// <param name="left">The left item of comparison.</param>
    /// <param name="right">The right item of comparison.</param>
    /// <returns>A sequence of comparison results.</returns>
    public static IEnumerable<bool> EquateSequentially(this IEnumerable<int>? left, IEnumerable<int>? right)
    {
        if (left == null && right == null)
        {
            yield return true;
            yield break;
        }

        using IEnumerator<int> leftEnumerator = left?.GetEnumerator() ?? EmptyEnumerator<int>.Get();
        using IEnumerator<int> rightEnumerator = right?.GetEnumerator() ?? EmptyEnumerator<int>.Get();

        var leftBool = leftEnumerator.MoveNext();
        var rightBool = rightEnumerator.MoveNext();

        while (leftBool || rightBool)
        {
            var leftCompare = leftBool ? leftEnumerator.Current : default;
            var rightCompare = rightBool ? rightEnumerator.Current : default;

            yield return leftCompare == rightCompare;

            leftBool = leftEnumerator.MoveNext();
            rightBool = rightEnumerator.MoveNext();
        }
    }

    /// <summary>
    /// Equates two enumerable collections sequentially, skipping items defined as &quot;empty&quot;.
    /// </summary>
    /// <param name="left">The left item of comparison.</param>
    /// <param name="right">The right item of comparison.</param>
    /// <param name="determineEmpty">A function that determines whether an item is &quot;empty&quot; or not.</param>
    /// <returns>A sequence of comparison results.</returns>
    public static IEnumerable<bool> EquateSequentially(this IEnumerable<int>? left, IEnumerable<int>? right, Func<int, bool> determineEmpty)
    {
        var localDetermineEmpty = Requires.NotNull(determineEmpty);

        if (left == null && right == null)
        {
            yield return true;
            yield break;
        }

        using IEnumerator<int> leftEnumerator = left?.GetEnumerator() ?? EmptyEnumerator<int>.Get();
        using IEnumerator<int> rightEnumerator = right?.GetEnumerator() ?? EmptyEnumerator<int>.Get();

        var leftBool = EquateSequentiallyMoveNext(leftEnumerator);
        var rightBool = EquateSequentiallyMoveNext(rightEnumerator);

        while (leftBool || rightBool)
        {
            var leftCompare = leftBool ? leftEnumerator.Current : default;
            var rightCompare = rightBool ? rightEnumerator.Current : default;

            yield return leftCompare == rightCompare;

            leftBool = EquateSequentiallyMoveNext(leftEnumerator);
            rightBool = EquateSequentiallyMoveNext(rightEnumerator);
        }

        bool EquateSequentiallyMoveNext(IEnumerator<int> source)
        {
            init:
            var moved = source.MoveNext();

            if (!moved)
            {
                return false;
            }

            if (localDetermineEmpty(source.Current))
            {
                goto init;
            }

            return true;
        }
    }

    /// <summary>
    /// Equates two enumerable collections sequentially.
    /// </summary>
    /// <param name="left">The left item of comparison.</param>
    /// <param name="right">The right item of comparison.</param>
    /// <returns>A sequence of comparison results.</returns>
    public static IEnumerable<bool> EquateSequentially(this IEnumerable<uint>? left, IEnumerable<uint>? right)
    {
        if (left == null && right == null)
        {
            yield return true;
            yield break;
        }

        using IEnumerator<uint> leftEnumerator = left?.GetEnumerator() ?? EmptyEnumerator<uint>.Get();
        using IEnumerator<uint> rightEnumerator = right?.GetEnumerator() ?? EmptyEnumerator<uint>.Get();

        var leftBool = leftEnumerator.MoveNext();
        var rightBool = rightEnumerator.MoveNext();

        while (leftBool || rightBool)
        {
            var leftCompare = leftBool ? leftEnumerator.Current : default;
            var rightCompare = rightBool ? rightEnumerator.Current : default;

            yield return leftCompare == rightCompare;

            leftBool = leftEnumerator.MoveNext();
            rightBool = rightEnumerator.MoveNext();
        }
    }

    /// <summary>
    /// Equates two enumerable collections sequentially, skipping items defined as &quot;empty&quot;.
    /// </summary>
    /// <param name="left">The left item of comparison.</param>
    /// <param name="right">The right item of comparison.</param>
    /// <param name="determineEmpty">A function that determines whether an item is &quot;empty&quot; or not.</param>
    /// <returns>A sequence of comparison results.</returns>
    public static IEnumerable<bool> EquateSequentially(this IEnumerable<uint>? left, IEnumerable<uint>? right, Func<uint, bool> determineEmpty)
    {
        var localDetermineEmpty = Requires.NotNull(determineEmpty);

        if (left == null && right == null)
        {
            yield return true;
            yield break;
        }

        using IEnumerator<uint> leftEnumerator = left?.GetEnumerator() ?? EmptyEnumerator<uint>.Get();
        using IEnumerator<uint> rightEnumerator = right?.GetEnumerator() ?? EmptyEnumerator<uint>.Get();

        var leftBool = EquateSequentiallyMoveNext(leftEnumerator);
        var rightBool = EquateSequentiallyMoveNext(rightEnumerator);

        while (leftBool || rightBool)
        {
            var leftCompare = leftBool ? leftEnumerator.Current : default;
            var rightCompare = rightBool ? rightEnumerator.Current : default;

            yield return leftCompare == rightCompare;

            leftBool = EquateSequentiallyMoveNext(leftEnumerator);
            rightBool = EquateSequentiallyMoveNext(rightEnumerator);
        }

        bool EquateSequentiallyMoveNext(IEnumerator<uint> source)
        {
            init:
            var moved = source.MoveNext();

            if (!moved)
            {
                return false;
            }

            if (localDetermineEmpty(source.Current))
            {
                goto init;
            }

            return true;
        }
    }

    /// <summary>
    /// Equates two enumerable collections sequentially.
    /// </summary>
    /// <param name="left">The left item of comparison.</param>
    /// <param name="right">The right item of comparison.</param>
    /// <returns>A sequence of comparison results.</returns>
    public static IEnumerable<bool> EquateSequentially(this IEnumerable<long>? left, IEnumerable<long>? right)
    {
        if (left == null && right == null)
        {
            yield return true;
            yield break;
        }

        using IEnumerator<long> leftEnumerator = left?.GetEnumerator() ?? EmptyEnumerator<long>.Get();
        using IEnumerator<long> rightEnumerator = right?.GetEnumerator() ?? EmptyEnumerator<long>.Get();

        var leftBool = leftEnumerator.MoveNext();
        var rightBool = rightEnumerator.MoveNext();

        while (leftBool || rightBool)
        {
            var leftCompare = leftBool ? leftEnumerator.Current : default;
            var rightCompare = rightBool ? rightEnumerator.Current : default;

            yield return leftCompare == rightCompare;

            leftBool = leftEnumerator.MoveNext();
            rightBool = rightEnumerator.MoveNext();
        }
    }

    /// <summary>
    /// Equates two enumerable collections sequentially, skipping items defined as &quot;empty&quot;.
    /// </summary>
    /// <param name="left">The left item of comparison.</param>
    /// <param name="right">The right item of comparison.</param>
    /// <param name="determineEmpty">A function that determines whether an item is &quot;empty&quot; or not.</param>
    /// <returns>A sequence of comparison results.</returns>
    public static IEnumerable<bool> EquateSequentially(this IEnumerable<long>? left, IEnumerable<long>? right, Func<long, bool> determineEmpty)
    {
        var localDetermineEmpty = Requires.NotNull(determineEmpty);

        if (left == null && right == null)
        {
            yield return true;
            yield break;
        }

        using IEnumerator<long> leftEnumerator = left?.GetEnumerator() ?? EmptyEnumerator<long>.Get();
        using IEnumerator<long> rightEnumerator = right?.GetEnumerator() ?? EmptyEnumerator<long>.Get();

        var leftBool = EquateSequentiallyMoveNext(leftEnumerator);
        var rightBool = EquateSequentiallyMoveNext(rightEnumerator);

        while (leftBool || rightBool)
        {
            var leftCompare = leftBool ? leftEnumerator.Current : default;
            var rightCompare = rightBool ? rightEnumerator.Current : default;

            yield return leftCompare == rightCompare;

            leftBool = EquateSequentiallyMoveNext(leftEnumerator);
            rightBool = EquateSequentiallyMoveNext(rightEnumerator);
        }

        bool EquateSequentiallyMoveNext(IEnumerator<long> source)
        {
            init:
            var moved = source.MoveNext();

            if (!moved)
            {
                return false;
            }

            if (localDetermineEmpty(source.Current))
            {
                goto init;
            }

            return true;
        }
    }

    /// <summary>
    /// Equates two enumerable collections sequentially.
    /// </summary>
    /// <param name="left">The left item of comparison.</param>
    /// <param name="right">The right item of comparison.</param>
    /// <returns>A sequence of comparison results.</returns>
    public static IEnumerable<bool> EquateSequentially(this IEnumerable<ulong>? left, IEnumerable<ulong>? right)
    {
        if (left == null && right == null)
        {
            yield return true;
            yield break;
        }

        using IEnumerator<ulong> leftEnumerator = left?.GetEnumerator() ?? EmptyEnumerator<ulong>.Get();
        using IEnumerator<ulong> rightEnumerator = right?.GetEnumerator() ?? EmptyEnumerator<ulong>.Get();

        var leftBool = leftEnumerator.MoveNext();
        var rightBool = rightEnumerator.MoveNext();

        while (leftBool || rightBool)
        {
            var leftCompare = leftBool ? leftEnumerator.Current : default;
            var rightCompare = rightBool ? rightEnumerator.Current : default;

            yield return leftCompare == rightCompare;

            leftBool = leftEnumerator.MoveNext();
            rightBool = rightEnumerator.MoveNext();
        }
    }

    /// <summary>
    /// Equates two enumerable collections sequentially, skipping items defined as &quot;empty&quot;.
    /// </summary>
    /// <param name="left">The left item of comparison.</param>
    /// <param name="right">The right item of comparison.</param>
    /// <param name="determineEmpty">A function that determines whether an item is &quot;empty&quot; or not.</param>
    /// <returns>A sequence of comparison results.</returns>
    public static IEnumerable<bool> EquateSequentially(this IEnumerable<ulong>? left, IEnumerable<ulong>? right, Func<ulong, bool> determineEmpty)
    {
        var localDetermineEmpty = Requires.NotNull(determineEmpty);

        if (left == null && right == null)
        {
            yield return true;
            yield break;
        }

        using IEnumerator<ulong> leftEnumerator = left?.GetEnumerator() ?? EmptyEnumerator<ulong>.Get();
        using IEnumerator<ulong> rightEnumerator = right?.GetEnumerator() ?? EmptyEnumerator<ulong>.Get();

        var leftBool = EquateSequentiallyMoveNext(leftEnumerator);
        var rightBool = EquateSequentiallyMoveNext(rightEnumerator);

        while (leftBool || rightBool)
        {
            var leftCompare = leftBool ? leftEnumerator.Current : default;
            var rightCompare = rightBool ? rightEnumerator.Current : default;

            yield return leftCompare == rightCompare;

            leftBool = EquateSequentiallyMoveNext(leftEnumerator);
            rightBool = EquateSequentiallyMoveNext(rightEnumerator);
        }

        bool EquateSequentiallyMoveNext(IEnumerator<ulong> source)
        {
            init:
            var moved = source.MoveNext();

            if (!moved)
            {
                return false;
            }

            if (localDetermineEmpty(source.Current))
            {
                goto init;
            }

            return true;
        }
    }

    /// <summary>
    /// Equates two enumerable collections sequentially.
    /// </summary>
    /// <param name="left">The left item of comparison.</param>
    /// <param name="right">The right item of comparison.</param>
    /// <returns>A sequence of comparison results.</returns>
    public static IEnumerable<bool> EquateSequentially(this IEnumerable<float>? left, IEnumerable<float>? right)
    {
        if (left == null && right == null)
        {
            yield return true;
            yield break;
        }

        using IEnumerator<float> leftEnumerator = left?.GetEnumerator() ?? EmptyEnumerator<float>.Get();
        using IEnumerator<float> rightEnumerator = right?.GetEnumerator() ?? EmptyEnumerator<float>.Get();

        var leftBool = leftEnumerator.MoveNext();
        var rightBool = rightEnumerator.MoveNext();

        while (leftBool || rightBool)
        {
            var leftCompare = leftBool ? leftEnumerator.Current : default;
            var rightCompare = rightBool ? rightEnumerator.Current : default;

            yield return leftCompare == rightCompare;

            leftBool = leftEnumerator.MoveNext();
            rightBool = rightEnumerator.MoveNext();
        }
    }

    /// <summary>
    /// Equates two enumerable collections sequentially, skipping items defined as &quot;empty&quot;.
    /// </summary>
    /// <param name="left">The left item of comparison.</param>
    /// <param name="right">The right item of comparison.</param>
    /// <param name="determineEmpty">A function that determines whether an item is &quot;empty&quot; or not.</param>
    /// <returns>A sequence of comparison results.</returns>
    public static IEnumerable<bool> EquateSequentially(this IEnumerable<float>? left, IEnumerable<float>? right, Func<float, bool> determineEmpty)
    {
        var localDetermineEmpty = Requires.NotNull(determineEmpty);

        if (left == null && right == null)
        {
            yield return true;
            yield break;
        }

        using IEnumerator<float> leftEnumerator = left?.GetEnumerator() ?? EmptyEnumerator<float>.Get();
        using IEnumerator<float> rightEnumerator = right?.GetEnumerator() ?? EmptyEnumerator<float>.Get();

        var leftBool = EquateSequentiallyMoveNext(leftEnumerator);
        var rightBool = EquateSequentiallyMoveNext(rightEnumerator);

        while (leftBool || rightBool)
        {
            var leftCompare = leftBool ? leftEnumerator.Current : default;
            var rightCompare = rightBool ? rightEnumerator.Current : default;

            yield return leftCompare == rightCompare;

            leftBool = EquateSequentiallyMoveNext(leftEnumerator);
            rightBool = EquateSequentiallyMoveNext(rightEnumerator);
        }

        bool EquateSequentiallyMoveNext(IEnumerator<float> source)
        {
            init:
            var moved = source.MoveNext();

            if (!moved)
            {
                return false;
            }

            if (localDetermineEmpty(source.Current))
            {
                goto init;
            }

            return true;
        }
    }

    /// <summary>
    /// Equates two enumerable collections sequentially.
    /// </summary>
    /// <param name="left">The left item of comparison.</param>
    /// <param name="right">The right item of comparison.</param>
    /// <returns>A sequence of comparison results.</returns>
    public static IEnumerable<bool> EquateSequentially(this IEnumerable<double>? left, IEnumerable<double>? right)
    {
        if (left == null && right == null)
        {
            yield return true;
            yield break;
        }

        using IEnumerator<double> leftEnumerator = left?.GetEnumerator() ?? EmptyEnumerator<double>.Get();
        using IEnumerator<double> rightEnumerator = right?.GetEnumerator() ?? EmptyEnumerator<double>.Get();

        var leftBool = leftEnumerator.MoveNext();
        var rightBool = rightEnumerator.MoveNext();

        while (leftBool || rightBool)
        {
            var leftCompare = leftBool ? leftEnumerator.Current : default;
            var rightCompare = rightBool ? rightEnumerator.Current : default;

            yield return leftCompare == rightCompare;

            leftBool = leftEnumerator.MoveNext();
            rightBool = rightEnumerator.MoveNext();
        }
    }

    /// <summary>
    /// Equates two enumerable collections sequentially, skipping items defined as &quot;empty&quot;.
    /// </summary>
    /// <param name="left">The left item of comparison.</param>
    /// <param name="right">The right item of comparison.</param>
    /// <param name="determineEmpty">A function that determines whether an item is &quot;empty&quot; or not.</param>
    /// <returns>A sequence of comparison results.</returns>
    public static IEnumerable<bool> EquateSequentially(this IEnumerable<double>? left, IEnumerable<double>? right, Func<double, bool> determineEmpty)
    {
        var localDetermineEmpty = Requires.NotNull(determineEmpty);

        if (left == null && right == null)
        {
            yield return true;
            yield break;
        }

        using IEnumerator<double> leftEnumerator = left?.GetEnumerator() ?? EmptyEnumerator<double>.Get();
        using IEnumerator<double> rightEnumerator = right?.GetEnumerator() ?? EmptyEnumerator<double>.Get();

        var leftBool = EquateSequentiallyMoveNext(leftEnumerator);
        var rightBool = EquateSequentiallyMoveNext(rightEnumerator);

        while (leftBool || rightBool)
        {
            var leftCompare = leftBool ? leftEnumerator.Current : default;
            var rightCompare = rightBool ? rightEnumerator.Current : default;

            yield return leftCompare == rightCompare;

            leftBool = EquateSequentiallyMoveNext(leftEnumerator);
            rightBool = EquateSequentiallyMoveNext(rightEnumerator);
        }

        bool EquateSequentiallyMoveNext(IEnumerator<double> source)
        {
            init:
            var moved = source.MoveNext();

            if (!moved)
            {
                return false;
            }

            if (localDetermineEmpty(source.Current))
            {
                goto init;
            }

            return true;
        }
    }

    /// <summary>
    /// Equates two enumerable collections sequentially.
    /// </summary>
    /// <param name="left">The left item of comparison.</param>
    /// <param name="right">The right item of comparison.</param>
    /// <returns>A sequence of comparison results.</returns>
    public static IEnumerable<bool> EquateSequentially(this IEnumerable<decimal>? left, IEnumerable<decimal>? right)
    {
        if (left == null && right == null)
        {
            yield return true;
            yield break;
        }

        using IEnumerator<decimal> leftEnumerator = left?.GetEnumerator() ?? EmptyEnumerator<decimal>.Get();
        using IEnumerator<decimal> rightEnumerator = right?.GetEnumerator() ?? EmptyEnumerator<decimal>.Get();

        var leftBool = leftEnumerator.MoveNext();
        var rightBool = rightEnumerator.MoveNext();

        while (leftBool || rightBool)
        {
            var leftCompare = leftBool ? leftEnumerator.Current : default;
            var rightCompare = rightBool ? rightEnumerator.Current : default;

            yield return leftCompare == rightCompare;

            leftBool = leftEnumerator.MoveNext();
            rightBool = rightEnumerator.MoveNext();
        }
    }

    /// <summary>
    /// Equates two enumerable collections sequentially, skipping items defined as &quot;empty&quot;.
    /// </summary>
    /// <param name="left">The left item of comparison.</param>
    /// <param name="right">The right item of comparison.</param>
    /// <param name="determineEmpty">A function that determines whether an item is &quot;empty&quot; or not.</param>
    /// <returns>A sequence of comparison results.</returns>
    public static IEnumerable<bool> EquateSequentially(this IEnumerable<decimal>? left, IEnumerable<decimal>? right, Func<decimal, bool> determineEmpty)
    {
        var localDetermineEmpty = Requires.NotNull(determineEmpty);

        if (left == null && right == null)
        {
            yield return true;
            yield break;
        }

        using IEnumerator<decimal> leftEnumerator = left?.GetEnumerator() ?? EmptyEnumerator<decimal>.Get();
        using IEnumerator<decimal> rightEnumerator = right?.GetEnumerator() ?? EmptyEnumerator<decimal>.Get();

        var leftBool = EquateSequentiallyMoveNext(leftEnumerator);
        var rightBool = EquateSequentiallyMoveNext(rightEnumerator);

        while (leftBool || rightBool)
        {
            var leftCompare = leftBool ? leftEnumerator.Current : default;
            var rightCompare = rightBool ? rightEnumerator.Current : default;

            yield return leftCompare == rightCompare;

            leftBool = EquateSequentiallyMoveNext(leftEnumerator);
            rightBool = EquateSequentiallyMoveNext(rightEnumerator);
        }

        bool EquateSequentiallyMoveNext(IEnumerator<decimal> source)
        {
            init:
            var moved = source.MoveNext();

            if (!moved)
            {
                return false;
            }

            if (localDetermineEmpty(source.Current))
            {
                goto init;
            }

            return true;
        }
    }

    /// <summary>
    /// Equates two enumerable collections sequentially.
    /// </summary>
    /// <param name="left">The left item of comparison.</param>
    /// <param name="right">The right item of comparison.</param>
    /// <returns>A sequence of comparison results.</returns>
    public static IEnumerable<bool> EquateSequentially(this IEnumerable<DateTime>? left, IEnumerable<DateTime>? right)
    {
        if (left == null && right == null)
        {
            yield return true;
            yield break;
        }

        using IEnumerator<DateTime> leftEnumerator = left?.GetEnumerator() ?? EmptyEnumerator<DateTime>.Get();
        using IEnumerator<DateTime> rightEnumerator = right?.GetEnumerator() ?? EmptyEnumerator<DateTime>.Get();

        var leftBool = leftEnumerator.MoveNext();
        var rightBool = rightEnumerator.MoveNext();

        while (leftBool || rightBool)
        {
            var leftCompare = leftBool ? leftEnumerator.Current : default;
            var rightCompare = rightBool ? rightEnumerator.Current : default;

            yield return leftCompare == rightCompare;

            leftBool = leftEnumerator.MoveNext();
            rightBool = rightEnumerator.MoveNext();
        }
    }

    /// <summary>
    /// Equates two enumerable collections sequentially, skipping items defined as &quot;empty&quot;.
    /// </summary>
    /// <param name="left">The left item of comparison.</param>
    /// <param name="right">The right item of comparison.</param>
    /// <param name="determineEmpty">A function that determines whether an item is &quot;empty&quot; or not.</param>
    /// <returns>A sequence of comparison results.</returns>
    public static IEnumerable<bool> EquateSequentially(this IEnumerable<DateTime>? left, IEnumerable<DateTime>? right, Func<DateTime, bool> determineEmpty)
    {
        var localDetermineEmpty = Requires.NotNull(determineEmpty);

        if (left == null && right == null)
        {
            yield return true;
            yield break;
        }

        using IEnumerator<DateTime> leftEnumerator = left?.GetEnumerator() ?? EmptyEnumerator<DateTime>.Get();
        using IEnumerator<DateTime> rightEnumerator = right?.GetEnumerator() ?? EmptyEnumerator<DateTime>.Get();

        var leftBool = EquateSequentiallyMoveNext(leftEnumerator);
        var rightBool = EquateSequentiallyMoveNext(rightEnumerator);

        while (leftBool || rightBool)
        {
            var leftCompare = leftBool ? leftEnumerator.Current : default;
            var rightCompare = rightBool ? rightEnumerator.Current : default;

            yield return leftCompare == rightCompare;

            leftBool = EquateSequentiallyMoveNext(leftEnumerator);
            rightBool = EquateSequentiallyMoveNext(rightEnumerator);
        }

        bool EquateSequentiallyMoveNext(IEnumerator<DateTime> source)
        {
            init:
            var moved = source.MoveNext();

            if (!moved)
            {
                return false;
            }

            if (localDetermineEmpty(source.Current))
            {
                goto init;
            }

            return true;
        }
    }

    /// <summary>
    /// Equates two enumerable collections sequentially.
    /// </summary>
    /// <param name="left">The left item of comparison.</param>
    /// <param name="right">The right item of comparison.</param>
    /// <returns>A sequence of comparison results.</returns>
    public static IEnumerable<bool> EquateSequentially(this IEnumerable<bool>? left, IEnumerable<bool>? right)
    {
        if (left == null && right == null)
        {
            yield return true;
            yield break;
        }

        using IEnumerator<bool> leftEnumerator = left?.GetEnumerator() ?? EmptyEnumerator<bool>.Get();
        using IEnumerator<bool> rightEnumerator = right?.GetEnumerator() ?? EmptyEnumerator<bool>.Get();

        var leftBool = leftEnumerator.MoveNext();
        var rightBool = rightEnumerator.MoveNext();

        while (leftBool || rightBool)
        {
            var leftCompare = leftBool ? leftEnumerator.Current : default;
            var rightCompare = rightBool ? rightEnumerator.Current : default;

            yield return leftCompare == rightCompare;

            leftBool = leftEnumerator.MoveNext();
            rightBool = rightEnumerator.MoveNext();
        }
    }

    /// <summary>
    /// Equates two enumerable collections sequentially, skipping items defined as &quot;empty&quot;.
    /// </summary>
    /// <param name="left">The left item of comparison.</param>
    /// <param name="right">The right item of comparison.</param>
    /// <param name="determineEmpty">A function that determines whether an item is &quot;empty&quot; or not.</param>
    /// <returns>A sequence of comparison results.</returns>
    public static IEnumerable<bool> EquateSequentially(this IEnumerable<bool>? left, IEnumerable<bool>? right, Func<bool, bool> determineEmpty)
    {
        var localDetermineEmpty = Requires.NotNull(determineEmpty);

        if (left == null && right == null)
        {
            yield return true;
            yield break;
        }

        using IEnumerator<bool> leftEnumerator = left?.GetEnumerator() ?? EmptyEnumerator<bool>.Get();
        using IEnumerator<bool> rightEnumerator = right?.GetEnumerator() ?? EmptyEnumerator<bool>.Get();

        var leftBool = EquateSequentiallyMoveNext(leftEnumerator);
        var rightBool = EquateSequentiallyMoveNext(rightEnumerator);

        while (leftBool || rightBool)
        {
            var leftCompare = leftBool ? leftEnumerator.Current : default;
            var rightCompare = rightBool ? rightEnumerator.Current : default;

            yield return leftCompare == rightCompare;

            leftBool = EquateSequentiallyMoveNext(leftEnumerator);
            rightBool = EquateSequentiallyMoveNext(rightEnumerator);
        }

        bool EquateSequentiallyMoveNext(IEnumerator<bool> source)
        {
            init:
            var moved = source.MoveNext();

            if (!moved)
            {
                return false;
            }

            if (localDetermineEmpty(source.Current))
            {
                goto init;
            }

            return true;
        }
    }

    /// <summary>
    /// Equates two enumerable collections sequentially.
    /// </summary>
    /// <param name="left">The left item of comparison.</param>
    /// <param name="right">The right item of comparison.</param>
    /// <returns>A sequence of comparison results.</returns>
    public static IEnumerable<bool> EquateSequentially(this IEnumerable<TimeSpan>? left, IEnumerable<TimeSpan>? right)
    {
        if (left == null && right == null)
        {
            yield return true;
            yield break;
        }

        using IEnumerator<TimeSpan> leftEnumerator = left?.GetEnumerator() ?? EmptyEnumerator<TimeSpan>.Get();
        using IEnumerator<TimeSpan> rightEnumerator = right?.GetEnumerator() ?? EmptyEnumerator<TimeSpan>.Get();

        var leftBool = leftEnumerator.MoveNext();
        var rightBool = rightEnumerator.MoveNext();

        while (leftBool || rightBool)
        {
            var leftCompare = leftBool ? leftEnumerator.Current : default;
            var rightCompare = rightBool ? rightEnumerator.Current : default;

            yield return leftCompare == rightCompare;

            leftBool = leftEnumerator.MoveNext();
            rightBool = rightEnumerator.MoveNext();
        }
    }

    /// <summary>
    /// Equates two enumerable collections sequentially, skipping items defined as &quot;empty&quot;.
    /// </summary>
    /// <param name="left">The left item of comparison.</param>
    /// <param name="right">The right item of comparison.</param>
    /// <param name="determineEmpty">A function that determines whether an item is &quot;empty&quot; or not.</param>
    /// <returns>A sequence of comparison results.</returns>
    public static IEnumerable<bool> EquateSequentially(this IEnumerable<TimeSpan>? left, IEnumerable<TimeSpan>? right, Func<TimeSpan, bool> determineEmpty)
    {
        var localDetermineEmpty = Requires.NotNull(determineEmpty);

        if (left == null && right == null)
        {
            yield return true;
            yield break;
        }

        using IEnumerator<TimeSpan> leftEnumerator = left?.GetEnumerator() ?? EmptyEnumerator<TimeSpan>.Get();
        using IEnumerator<TimeSpan> rightEnumerator = right?.GetEnumerator() ?? EmptyEnumerator<TimeSpan>.Get();

        var leftBool = EquateSequentiallyMoveNext(leftEnumerator);
        var rightBool = EquateSequentiallyMoveNext(rightEnumerator);

        while (leftBool || rightBool)
        {
            var leftCompare = leftBool ? leftEnumerator.Current : default;
            var rightCompare = rightBool ? rightEnumerator.Current : default;

            yield return leftCompare == rightCompare;

            leftBool = EquateSequentiallyMoveNext(leftEnumerator);
            rightBool = EquateSequentiallyMoveNext(rightEnumerator);
        }

        bool EquateSequentiallyMoveNext(IEnumerator<TimeSpan> source)
        {
            init:
            var moved = source.MoveNext();

            if (!moved)
            {
                return false;
            }

            if (localDetermineEmpty(source.Current))
            {
                goto init;
            }

            return true;
        }
    }

    /// <summary>
    /// Equates two enumerable collections sequentially.
    /// </summary>
    /// <param name="left">The left item of comparison.</param>
    /// <param name="right">The right item of comparison.</param>
    /// <returns>A sequence of comparison results.</returns>
    public static IEnumerable<bool> EquateSequentially(this IEnumerable<string>? left, IEnumerable<string>? right)
    {
        if (left == null && right == null)
        {
            yield return true;
            yield break;
        }

        using IEnumerator<string> leftEnumerator = left?.GetEnumerator() ?? EmptyEnumerator<string>.Get();
        using IEnumerator<string> rightEnumerator = right?.GetEnumerator() ?? EmptyEnumerator<string>.Get();

        var leftBool = leftEnumerator.MoveNext();
        var rightBool = rightEnumerator.MoveNext();

        while (leftBool || rightBool)
        {
            var leftCompare = leftBool ? leftEnumerator.Current : default;
            var rightCompare = rightBool ? rightEnumerator.Current : default;

            yield return string.Compare(leftCompare, rightCompare, CultureInfo.CurrentCulture, CompareOptions.None) == 0;

            leftBool = leftEnumerator.MoveNext();
            rightBool = rightEnumerator.MoveNext();
        }
    }

    /// <summary>
    /// Equates two enumerable collections sequentially, skipping items defined as &quot;empty&quot;.
    /// </summary>
    /// <param name="left">The left item of comparison.</param>
    /// <param name="right">The right item of comparison.</param>
    /// <param name="determineEmpty">A function that determines whether an item is &quot;empty&quot; or not.</param>
    /// <returns>A sequence of comparison results.</returns>
    public static IEnumerable<bool> EquateSequentially(this IEnumerable<string>? left, IEnumerable<string>? right, Func<string, bool> determineEmpty)
    {
        var localDetermineEmpty = Requires.NotNull(determineEmpty);

        if (left == null && right == null)
        {
            yield return true;
            yield break;
        }

        using IEnumerator<string> leftEnumerator = left?.GetEnumerator() ?? EmptyEnumerator<string>.Get();
        using IEnumerator<string> rightEnumerator = right?.GetEnumerator() ?? EmptyEnumerator<string>.Get();

        var leftBool = EquateSequentiallyMoveNext(leftEnumerator);
        var rightBool = EquateSequentiallyMoveNext(rightEnumerator);

        while (leftBool || rightBool)
        {
            var leftCompare = leftBool ? leftEnumerator.Current : default;
            var rightCompare = rightBool ? rightEnumerator.Current : default;

            yield return leftCompare == rightCompare;

            leftBool = EquateSequentiallyMoveNext(leftEnumerator);
            rightBool = EquateSequentiallyMoveNext(rightEnumerator);
        }

        bool EquateSequentiallyMoveNext(IEnumerator<string> source)
        {
            init:
            var moved = source.MoveNext();

            if (!moved)
            {
                return false;
            }

            if (localDetermineEmpty(source.Current))
            {
                goto init;
            }

            return true;
        }
    }
}