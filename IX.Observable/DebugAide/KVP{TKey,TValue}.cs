using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace IX.Observable.DebugAide;

/// <summary>
///     A debug view of a key-value pair in an observable dictionary.
/// </summary>
/// <typeparam name="TKey">The type of the key.</typeparam>
/// <typeparam name="TValue">The type of the value.</typeparam>
[DebuggerDisplay("[{Key}] = \"{Value}\"")]
[ExcludeFromCodeCoverage]
public sealed class Kvp<TKey, TValue>
{
    /// <summary>
    ///     Gets the key.
    /// </summary>
    /// <value>
    ///     The key.
    /// </value>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public TKey Key { get; internal set; } = default!;

    /// <summary>
    ///     Gets the value.
    /// </summary>
    /// <value>
    ///     The value.
    /// </value>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public TValue Value { get; internal set; } = default!;
}