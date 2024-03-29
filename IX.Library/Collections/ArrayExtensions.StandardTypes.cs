namespace IX.Library.Collections;

/// <summary>
///     Extensions for array types.
/// </summary>
public static partial class ArrayExtensions
{
    /// <summary>
    ///     Deep clones an array.
    /// </summary>
    /// <param name="source">The source array to deep clone.</param>
    /// <returns>An array of deeply-copied elements from the original array.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="source" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
    /// </exception>
    public static byte[] DeepClone(this byte[] source)
    {
        var length = (source ?? throw new ArgumentNullException(nameof(source))).Length;

        var destination = new byte[length];

        for (var i = 0; i < length; i++)
        {
            destination[i] = source[i];
        }

        return destination;
    }

    /// <summary>
    ///     Deep clones an array.
    /// </summary>
    /// <param name="source">The source array to deep clone.</param>
    /// <returns>An array of deeply-copied elements from the original array.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="source" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
    /// </exception>
    public static sbyte[] DeepClone(this sbyte[] source)
    {
        var length = (source ?? throw new ArgumentNullException(nameof(source))).Length;

        var destination = new sbyte[length];

        for (var i = 0; i < length; i++)
        {
            destination[i] = source[i];
        }

        return destination;
    }

    /// <summary>
    ///     Deep clones an array.
    /// </summary>
    /// <param name="source">The source array to deep clone.</param>
    /// <returns>An array of deeply-copied elements from the original array.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="source" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
    /// </exception>
    public static short[] DeepClone(this short[] source)
    {
        var length = (source ?? throw new ArgumentNullException(nameof(source))).Length;

        var destination = new short[length];

        for (var i = 0; i < length; i++)
        {
            destination[i] = source[i];
        }

        return destination;
    }

    /// <summary>
    ///     Deep clones an array.
    /// </summary>
    /// <param name="source">The source array to deep clone.</param>
    /// <returns>An array of deeply-copied elements from the original array.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="source" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
    /// </exception>
    public static ushort[] DeepClone(this ushort[] source)
    {
        var length = (source ?? throw new ArgumentNullException(nameof(source))).Length;

        var destination = new ushort[length];

        for (var i = 0; i < length; i++)
        {
            destination[i] = source[i];
        }

        return destination;
    }

    /// <summary>
    ///     Deep clones an array.
    /// </summary>
    /// <param name="source">The source array to deep clone.</param>
    /// <returns>An array of deeply-copied elements from the original array.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="source" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
    /// </exception>
    public static char[] DeepClone(this char[] source)
    {
        var length = (source ?? throw new ArgumentNullException(nameof(source))).Length;

        var destination = new char[length];

        for (var i = 0; i < length; i++)
        {
            destination[i] = source[i];
        }

        return destination;
    }

    /// <summary>
    ///     Deep clones an array.
    /// </summary>
    /// <param name="source">The source array to deep clone.</param>
    /// <returns>An array of deeply-copied elements from the original array.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="source" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
    /// </exception>
    public static int[] DeepClone(this int[] source)
    {
        var length = (source ?? throw new ArgumentNullException(nameof(source))).Length;

        var destination = new int[length];

        for (var i = 0; i < length; i++)
        {
            destination[i] = source[i];
        }

        return destination;
    }

    /// <summary>
    ///     Deep clones an array.
    /// </summary>
    /// <param name="source">The source array to deep clone.</param>
    /// <returns>An array of deeply-copied elements from the original array.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="source" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
    /// </exception>
    public static uint[] DeepClone(this uint[] source)
    {
        var length = (source ?? throw new ArgumentNullException(nameof(source))).Length;

        var destination = new uint[length];

        for (var i = 0; i < length; i++)
        {
            destination[i] = source[i];
        }

        return destination;
    }

    /// <summary>
    ///     Deep clones an array.
    /// </summary>
    /// <param name="source">The source array to deep clone.</param>
    /// <returns>An array of deeply-copied elements from the original array.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="source" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
    /// </exception>
    public static long[] DeepClone(this long[] source)
    {
        var length = (source ?? throw new ArgumentNullException(nameof(source))).Length;

        var destination = new long[length];

        for (var i = 0; i < length; i++)
        {
            destination[i] = source[i];
        }

        return destination;
    }

    /// <summary>
    ///     Deep clones an array.
    /// </summary>
    /// <param name="source">The source array to deep clone.</param>
    /// <returns>An array of deeply-copied elements from the original array.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="source" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
    /// </exception>
    public static ulong[] DeepClone(this ulong[] source)
    {
        var length = (source ?? throw new ArgumentNullException(nameof(source))).Length;

        var destination = new ulong[length];

        for (var i = 0; i < length; i++)
        {
            destination[i] = source[i];
        }

        return destination;
    }

    /// <summary>
    ///     Deep clones an array.
    /// </summary>
    /// <param name="source">The source array to deep clone.</param>
    /// <returns>An array of deeply-copied elements from the original array.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="source" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
    /// </exception>
    public static float[] DeepClone(this float[] source)
    {
        var length = (source ?? throw new ArgumentNullException(nameof(source))).Length;

        var destination = new float[length];

        for (var i = 0; i < length; i++)
        {
            destination[i] = source[i];
        }

        return destination;
    }

    /// <summary>
    ///     Deep clones an array.
    /// </summary>
    /// <param name="source">The source array to deep clone.</param>
    /// <returns>An array of deeply-copied elements from the original array.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="source" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
    /// </exception>
    public static double[] DeepClone(this double[] source)
    {
        var length = (source ?? throw new ArgumentNullException(nameof(source))).Length;

        var destination = new double[length];

        for (var i = 0; i < length; i++)
        {
            destination[i] = source[i];
        }

        return destination;
    }

    /// <summary>
    ///     Deep clones an array.
    /// </summary>
    /// <param name="source">The source array to deep clone.</param>
    /// <returns>An array of deeply-copied elements from the original array.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="source" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
    /// </exception>
    public static decimal[] DeepClone(this decimal[] source)
    {
        var length = (source ?? throw new ArgumentNullException(nameof(source))).Length;

        var destination = new decimal[length];

        for (var i = 0; i < length; i++)
        {
            destination[i] = source[i];
        }

        return destination;
    }

    /// <summary>
    ///     Deep clones an array.
    /// </summary>
    /// <param name="source">The source array to deep clone.</param>
    /// <returns>An array of deeply-copied elements from the original array.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="source" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
    /// </exception>
    public static DateTime[] DeepClone(this DateTime[] source)
    {
        var length = (source ?? throw new ArgumentNullException(nameof(source))).Length;

        var destination = new DateTime[length];

        for (var i = 0; i < length; i++)
        {
            destination[i] = source[i];
        }

        return destination;
    }

    /// <summary>
    ///     Deep clones an array.
    /// </summary>
    /// <param name="source">The source array to deep clone.</param>
    /// <returns>An array of deeply-copied elements from the original array.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="source" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
    /// </exception>
    public static bool[] DeepClone(this bool[] source)
    {
        var length = (source ?? throw new ArgumentNullException(nameof(source))).Length;

        var destination = new bool[length];

        for (var i = 0; i < length; i++)
        {
            destination[i] = source[i];
        }

        return destination;
    }

    /// <summary>
    ///     Deep clones an array.
    /// </summary>
    /// <param name="source">The source array to deep clone.</param>
    /// <returns>An array of deeply-copied elements from the original array.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="source" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
    /// </exception>
    public static TimeSpan[] DeepClone(this TimeSpan[] source)
    {
        var length = (source ?? throw new ArgumentNullException(nameof(source))).Length;

        var destination = new TimeSpan[length];

        for (var i = 0; i < length; i++)
        {
            destination[i] = source[i];
        }

        return destination;
    }

    /// <summary>
    ///     Deep clones an array.
    /// </summary>
    /// <param name="source">The source array to deep clone.</param>
    /// <returns>An array of deeply-copied elements from the original array.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="source" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
    /// </exception>
    public static string[] DeepClone(this string[] source)
    {
        var length = (source ?? throw new ArgumentNullException(nameof(source))).Length;

        var destination = new string[length];

        for (var i = 0; i < length; i++)
        {
            destination[i] = source[i];
        }

        return destination;
    }
}