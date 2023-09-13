using IX.Library.Contracts;

using System.Diagnostics.CodeAnalysis;

namespace IX.Library.Collections;

/// <summary>
/// Extensions for IDictionary.
/// </summary>
[SuppressMessage(
    "ReSharper",
    "InconsistentNaming",
    Justification = "We're just doing IDictionary extensions.")]
public static partial class IDictionaryExtensions
{
    /// <summary>
    /// Creates a deep clone of a dictionary, with deep clones of its values.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <param name="source">The source.</param>
    /// <returns>A deeply-cloned dictionary.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static Dictionary<TKey, byte> DeepClone<TKey>(this Dictionary<TKey, byte> source)
        where TKey : notnull
    {
        var localSource = Requires.NotNull(source);

        var destination = new Dictionary<TKey, byte>();

        foreach (KeyValuePair<TKey, byte> p in localSource)
        {
            destination.Add(p.Key, p.Value);
        }

        return destination;
    }

    /// <summary>
    /// Creates a deep clone of a dictionary, with deep clones of its values.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <param name="source">The source.</param>
    /// <returns>A deeply-cloned dictionary.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static Dictionary<TKey, sbyte> DeepClone<TKey>(this Dictionary<TKey, sbyte> source)
        where TKey : notnull
    {
        var localSource = Requires.NotNull(source);

        var destination = new Dictionary<TKey, sbyte>();

        foreach (KeyValuePair<TKey, sbyte> p in localSource)
        {
            destination.Add(p.Key, p.Value);
        }

        return destination;
    }

    /// <summary>
    /// Creates a deep clone of a dictionary, with deep clones of its values.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <param name="source">The source.</param>
    /// <returns>A deeply-cloned dictionary.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static Dictionary<TKey, short> DeepClone<TKey>(this Dictionary<TKey, short> source)
        where TKey : notnull
    {
        var localSource = Requires.NotNull(source);

        var destination = new Dictionary<TKey, short>();

        foreach (KeyValuePair<TKey, short> p in localSource)
        {
            destination.Add(p.Key, p.Value);
        }

        return destination;
    }

    /// <summary>
    /// Creates a deep clone of a dictionary, with deep clones of its values.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <param name="source">The source.</param>
    /// <returns>A deeply-cloned dictionary.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static Dictionary<TKey, ushort> DeepClone<TKey>(this Dictionary<TKey, ushort> source)
        where TKey : notnull
    {
        var localSource = Requires.NotNull(source);

        var destination = new Dictionary<TKey, ushort>();

        foreach (KeyValuePair<TKey, ushort> p in localSource)
        {
            destination.Add(p.Key, p.Value);
        }

        return destination;
    }

    /// <summary>
    /// Creates a deep clone of a dictionary, with deep clones of its values.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <param name="source">The source.</param>
    /// <returns>A deeply-cloned dictionary.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static Dictionary<TKey, char> DeepClone<TKey>(this Dictionary<TKey, char> source)
        where TKey : notnull
    {
        var localSource = Requires.NotNull(source);

        var destination = new Dictionary<TKey, char>();

        foreach (KeyValuePair<TKey, char> p in localSource)
        {
            destination.Add(p.Key, p.Value);
        }

        return destination;
    }

    /// <summary>
    /// Creates a deep clone of a dictionary, with deep clones of its values.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <param name="source">The source.</param>
    /// <returns>A deeply-cloned dictionary.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static Dictionary<TKey, int> DeepClone<TKey>(this Dictionary<TKey, int> source)
        where TKey : notnull
    {
        var localSource = Requires.NotNull(source);

        var destination = new Dictionary<TKey, int>();

        foreach (KeyValuePair<TKey, int> p in localSource)
        {
            destination.Add(p.Key, p.Value);
        }

        return destination;
    }

    /// <summary>
    /// Creates a deep clone of a dictionary, with deep clones of its values.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <param name="source">The source.</param>
    /// <returns>A deeply-cloned dictionary.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static Dictionary<TKey, uint> DeepClone<TKey>(this Dictionary<TKey, uint> source)
        where TKey : notnull
    {
        var localSource = Requires.NotNull(source);

        var destination = new Dictionary<TKey, uint>();

        foreach (KeyValuePair<TKey, uint> p in localSource)
        {
            destination.Add(p.Key, p.Value);
        }

        return destination;
    }

    /// <summary>
    /// Creates a deep clone of a dictionary, with deep clones of its values.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <param name="source">The source.</param>
    /// <returns>A deeply-cloned dictionary.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static Dictionary<TKey, long> DeepClone<TKey>(this Dictionary<TKey, long> source)
        where TKey : notnull
    {
        var localSource = Requires.NotNull(source);

        var destination = new Dictionary<TKey, long>();

        foreach (KeyValuePair<TKey, long> p in localSource)
        {
            destination.Add(p.Key, p.Value);
        }

        return destination;
    }

    /// <summary>
    /// Creates a deep clone of a dictionary, with deep clones of its values.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <param name="source">The source.</param>
    /// <returns>A deeply-cloned dictionary.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static Dictionary<TKey, ulong> DeepClone<TKey>(this Dictionary<TKey, ulong> source)
        where TKey : notnull
    {
        var localSource = Requires.NotNull(source);

        var destination = new Dictionary<TKey, ulong>();

        foreach (KeyValuePair<TKey, ulong> p in localSource)
        {
            destination.Add(p.Key, p.Value);
        }

        return destination;
    }

    /// <summary>
    /// Creates a deep clone of a dictionary, with deep clones of its values.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <param name="source">The source.</param>
    /// <returns>A deeply-cloned dictionary.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static Dictionary<TKey, float> DeepClone<TKey>(this Dictionary<TKey, float> source)
        where TKey : notnull
    {
        var localSource = Requires.NotNull(source);

        var destination = new Dictionary<TKey, float>();

        foreach (KeyValuePair<TKey, float> p in localSource)
        {
            destination.Add(p.Key, p.Value);
        }

        return destination;
    }

    /// <summary>
    /// Creates a deep clone of a dictionary, with deep clones of its values.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <param name="source">The source.</param>
    /// <returns>A deeply-cloned dictionary.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static Dictionary<TKey, double> DeepClone<TKey>(this Dictionary<TKey, double> source)
        where TKey : notnull
    {
        var localSource = Requires.NotNull(source);

        var destination = new Dictionary<TKey, double>();

        foreach (KeyValuePair<TKey, double> p in localSource)
        {
            destination.Add(p.Key, p.Value);
        }

        return destination;
    }

    /// <summary>
    /// Creates a deep clone of a dictionary, with deep clones of its values.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <param name="source">The source.</param>
    /// <returns>A deeply-cloned dictionary.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static Dictionary<TKey, decimal> DeepClone<TKey>(this Dictionary<TKey, decimal> source)
        where TKey : notnull
    {
        var localSource = Requires.NotNull(source);

        var destination = new Dictionary<TKey, decimal>();

        foreach (KeyValuePair<TKey, decimal> p in localSource)
        {
            destination.Add(p.Key, p.Value);
        }

        return destination;
    }

    /// <summary>
    /// Creates a deep clone of a dictionary, with deep clones of its values.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <param name="source">The source.</param>
    /// <returns>A deeply-cloned dictionary.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static Dictionary<TKey, DateTime> DeepClone<TKey>(this Dictionary<TKey, DateTime> source)
        where TKey : notnull
    {
        var localSource = Requires.NotNull(source);

        var destination = new Dictionary<TKey, DateTime>();

        foreach (KeyValuePair<TKey, DateTime> p in localSource)
        {
            destination.Add(p.Key, p.Value);
        }

        return destination;
    }

    /// <summary>
    /// Creates a deep clone of a dictionary, with deep clones of its values.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <param name="source">The source.</param>
    /// <returns>A deeply-cloned dictionary.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static Dictionary<TKey, bool> DeepClone<TKey>(this Dictionary<TKey, bool> source)
        where TKey : notnull
    {
        var localSource = Requires.NotNull(source);

        var destination = new Dictionary<TKey, bool>();

        foreach (KeyValuePair<TKey, bool> p in localSource)
        {
            destination.Add(p.Key, p.Value);
        }

        return destination;
    }

    /// <summary>
    /// Creates a deep clone of a dictionary, with deep clones of its values.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <param name="source">The source.</param>
    /// <returns>A deeply-cloned dictionary.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static Dictionary<TKey, TimeSpan> DeepClone<TKey>(this Dictionary<TKey, TimeSpan> source)
        where TKey : notnull
    {
        var localSource = Requires.NotNull(source);

        var destination = new Dictionary<TKey, TimeSpan>();

        foreach (KeyValuePair<TKey, TimeSpan> p in localSource)
        {
            destination.Add(p.Key, p.Value);
        }

        return destination;
    }

    /// <summary>
    /// Creates a deep clone of a dictionary, with deep clones of its values.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <param name="source">The source.</param>
    /// <returns>A deeply-cloned dictionary.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static Dictionary<TKey, string> DeepClone<TKey>(this Dictionary<TKey, string> source)
        where TKey : notnull
    {
        var localSource = Requires.NotNull(source);

        var destination = new Dictionary<TKey, string>();

        foreach (KeyValuePair<TKey, string> p in localSource)
        {
            destination.Add(p.Key, p.Value);
        }

        return destination;
    }
}