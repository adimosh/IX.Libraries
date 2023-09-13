using IX.Library.Contracts;

using System.Diagnostics.CodeAnalysis;

namespace IX.Library.Collections;

/// <summary>
///     Extensions for IList.
/// </summary>
[SuppressMessage(
    "ReSharper",
    "InconsistentNaming",
    Justification = "These are extensions for IList, so we must allow this.")]
public static partial class IListCloneExtensions
{
    /// <summary>
    ///     Deep clones the list.
    /// </summary>
    /// <param name="list">The list to clone.</param>
    /// <returns>
    ///     A cloned list.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static List<byte> DeepClone(this List<byte> list)
    {
        var localList = Requires.NotNull(list);

        return new List<byte>(localList);
    }

    /// <summary>
    ///     Deep clones the list.
    /// </summary>
    /// <param name="list">The list to clone.</param>
    /// <returns>
    ///     A cloned list.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static List<sbyte> DeepClone(this List<sbyte> list)
    {
        var localList = Requires.NotNull(list);

        return new List<sbyte>(localList);
    }

    /// <summary>
    ///     Deep clones the list.
    /// </summary>
    /// <param name="list">The list to clone.</param>
    /// <returns>
    ///     A cloned list.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static List<short> DeepClone(this List<short> list)
    {
        var localList = Requires.NotNull(list);

        return new List<short>(localList);
    }

    /// <summary>
    ///     Deep clones the list.
    /// </summary>
    /// <param name="list">The list to clone.</param>
    /// <returns>
    ///     A cloned list.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static List<ushort> DeepClone(this List<ushort> list)
    {
        var localList = Requires.NotNull(list);

        return new List<ushort>(localList);
    }

    /// <summary>
    ///     Deep clones the list.
    /// </summary>
    /// <param name="list">The list to clone.</param>
    /// <returns>
    ///     A cloned list.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static List<char> DeepClone(this List<char> list)
    {
        var localList = Requires.NotNull(list);

        return new List<char>(localList);
    }

    /// <summary>
    ///     Deep clones the list.
    /// </summary>
    /// <param name="list">The list to clone.</param>
    /// <returns>
    ///     A cloned list.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static List<int> DeepClone(this List<int> list)
    {
        var localList = Requires.NotNull(list);

        return new List<int>(localList);
    }

    /// <summary>
    ///     Deep clones the list.
    /// </summary>
    /// <param name="list">The list to clone.</param>
    /// <returns>
    ///     A cloned list.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static List<uint> DeepClone(this List<uint> list)
    {
        var localList = Requires.NotNull(list);

        return new List<uint>(localList);
    }

    /// <summary>
    ///     Deep clones the list.
    /// </summary>
    /// <param name="list">The list to clone.</param>
    /// <returns>
    ///     A cloned list.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static List<long> DeepClone(this List<long> list)
    {
        var localList = Requires.NotNull(list);

        return new List<long>(localList);
    }

    /// <summary>
    ///     Deep clones the list.
    /// </summary>
    /// <param name="list">The list to clone.</param>
    /// <returns>
    ///     A cloned list.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static List<ulong> DeepClone(this List<ulong> list)
    {
        var localList = Requires.NotNull(list);

        return new List<ulong>(localList);
    }

    /// <summary>
    ///     Deep clones the list.
    /// </summary>
    /// <param name="list">The list to clone.</param>
    /// <returns>
    ///     A cloned list.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static List<float> DeepClone(this List<float> list)
    {
        var localList = Requires.NotNull(list);

        return new List<float>(localList);
    }

    /// <summary>
    ///     Deep clones the list.
    /// </summary>
    /// <param name="list">The list to clone.</param>
    /// <returns>
    ///     A cloned list.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static List<double> DeepClone(this List<double> list)
    {
        var localList = Requires.NotNull(list);

        return new List<double>(localList);
    }

    /// <summary>
    ///     Deep clones the list.
    /// </summary>
    /// <param name="list">The list to clone.</param>
    /// <returns>
    ///     A cloned list.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static List<decimal> DeepClone(this List<decimal> list)
    {
        var localList = Requires.NotNull(list);

        return new List<decimal>(localList);
    }

    /// <summary>
    ///     Deep clones the list.
    /// </summary>
    /// <param name="list">The list to clone.</param>
    /// <returns>
    ///     A cloned list.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static List<DateTime> DeepClone(this List<DateTime> list)
    {
        var localList = Requires.NotNull(list);

        return new List<DateTime>(localList);
    }

    /// <summary>
    ///     Deep clones the list.
    /// </summary>
    /// <param name="list">The list to clone.</param>
    /// <returns>
    ///     A cloned list.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static List<bool> DeepClone(this List<bool> list)
    {
        var localList = Requires.NotNull(list);

        return new List<bool>(localList);
    }

    /// <summary>
    ///     Deep clones the list.
    /// </summary>
    /// <param name="list">The list to clone.</param>
    /// <returns>
    ///     A cloned list.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static List<TimeSpan> DeepClone(this List<TimeSpan> list)
    {
        var localList = Requires.NotNull(list);

        return new List<TimeSpan>(localList);
    }

    /// <summary>
    ///     Deep clones the list.
    /// </summary>
    /// <param name="list">The list to clone.</param>
    /// <returns>
    ///     A cloned list.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static List<string> DeepClone(this List<string> list)
    {
        var localList = Requires.NotNull(list);

        return new List<string>(localList);
    }
}