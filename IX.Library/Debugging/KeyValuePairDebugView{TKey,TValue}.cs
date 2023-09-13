using System.Diagnostics;
using System.Runtime.InteropServices;

namespace IX.Library.Debugging;

/// <summary>
///     A debug view for a key/value pair. This class cannot be inherited.
/// </summary>
/// <typeparam name="TKey">The type of the key.</typeparam>
/// <typeparam name="TValue">The type of the value.</typeparam>
[ComVisible(false)]
[DebuggerDisplay($"[{{{nameof(Key)}}}] = \"{{{nameof(Value)}}}\"")]
[PublicAPI]
public sealed class KyeValuePairDebugView<TKey, TValue>
{
    /// <summary>
    ///     Gets the key.
    /// </summary>
    /// <value>The key.</value>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public TKey? Key { get; internal set; }

    /// <summary>
    ///     Gets the value.
    /// </summary>
    /// <value>The value.</value>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public TValue? Value { get; internal set; }
}