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
    public static List<byte> DeepClone(this List<byte> list) =>
        [..list ?? throw new ArgumentNullException(nameof(list))];

    /// <summary>
    ///     Deep clones the list.
    /// </summary>
    /// <param name="list">The list to clone.</param>
    /// <returns>
    ///     A cloned list.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static List<sbyte> DeepClone(this List<sbyte> list) =>
        [..list ?? throw new ArgumentNullException(nameof(list))];

    /// <summary>
    ///     Deep clones the list.
    /// </summary>
    /// <param name="list">The list to clone.</param>
    /// <returns>
    ///     A cloned list.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static List<short> DeepClone(this List<short> list) =>
        [..list ?? throw new ArgumentNullException(nameof(list))];

    /// <summary>
    ///     Deep clones the list.
    /// </summary>
    /// <param name="list">The list to clone.</param>
    /// <returns>
    ///     A cloned list.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static List<ushort> DeepClone(this List<ushort> list) =>
        [..list ?? throw new ArgumentNullException(nameof(list))];

    /// <summary>
    ///     Deep clones the list.
    /// </summary>
    /// <param name="list">The list to clone.</param>
    /// <returns>
    ///     A cloned list.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static List<char> DeepClone(this List<char> list) =>
        [..list ?? throw new ArgumentNullException(nameof(list))];

    /// <summary>
    ///     Deep clones the list.
    /// </summary>
    /// <param name="list">The list to clone.</param>
    /// <returns>
    ///     A cloned list.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static List<int> DeepClone(this List<int> list) =>
        [..list ?? throw new ArgumentNullException(nameof(list))];

    /// <summary>
    ///     Deep clones the list.
    /// </summary>
    /// <param name="list">The list to clone.</param>
    /// <returns>
    ///     A cloned list.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static List<uint> DeepClone(this List<uint> list) =>
        [..list ?? throw new ArgumentNullException(nameof(list))];

    /// <summary>
    ///     Deep clones the list.
    /// </summary>
    /// <param name="list">The list to clone.</param>
    /// <returns>
    ///     A cloned list.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static List<long> DeepClone(this List<long> list) =>
        [..list ?? throw new ArgumentNullException(nameof(list))];

    /// <summary>
    ///     Deep clones the list.
    /// </summary>
    /// <param name="list">The list to clone.</param>
    /// <returns>
    ///     A cloned list.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static List<ulong> DeepClone(this List<ulong> list) =>
        [..list ?? throw new ArgumentNullException(nameof(list))];

    /// <summary>
    ///     Deep clones the list.
    /// </summary>
    /// <param name="list">The list to clone.</param>
    /// <returns>
    ///     A cloned list.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static List<float> DeepClone(this List<float> list) =>
        [..list ?? throw new ArgumentNullException(nameof(list))];

    /// <summary>
    ///     Deep clones the list.
    /// </summary>
    /// <param name="list">The list to clone.</param>
    /// <returns>
    ///     A cloned list.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static List<double> DeepClone(this List<double> list) =>
        [..list ?? throw new ArgumentNullException(nameof(list))];

    /// <summary>
    ///     Deep clones the list.
    /// </summary>
    /// <param name="list">The list to clone.</param>
    /// <returns>
    ///     A cloned list.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static List<decimal> DeepClone(this List<decimal> list) =>
        [..list ?? throw new ArgumentNullException(nameof(list))];

    /// <summary>
    ///     Deep clones the list.
    /// </summary>
    /// <param name="list">The list to clone.</param>
    /// <returns>
    ///     A cloned list.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static List<DateTime> DeepClone(this List<DateTime> list) =>
        [..list ?? throw new ArgumentNullException(nameof(list))];

    /// <summary>
    ///     Deep clones the list.
    /// </summary>
    /// <param name="list">The list to clone.</param>
    /// <returns>
    ///     A cloned list.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static List<bool> DeepClone(this List<bool> list) =>
        [..list ?? throw new ArgumentNullException(nameof(list))];

    /// <summary>
    ///     Deep clones the list.
    /// </summary>
    /// <param name="list">The list to clone.</param>
    /// <returns>
    ///     A cloned list.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static List<TimeSpan> DeepClone(this List<TimeSpan> list) =>
        [..list ?? throw new ArgumentNullException(nameof(list))];

    /// <summary>
    ///     Deep clones the list.
    /// </summary>
    /// <param name="list">The list to clone.</param>
    /// <returns>
    ///     A cloned list.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static List<string> DeepClone(this List<string> list) =>
        [..list ?? throw new ArgumentNullException(nameof(list))];
}