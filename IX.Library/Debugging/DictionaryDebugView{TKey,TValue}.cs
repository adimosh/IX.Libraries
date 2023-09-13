using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace IX.Core.Debugging;

/// <summary>
///     A debug view for dictionaries. This class cannot be inherited.
/// </summary>
/// <typeparam name="TKey">The type of the key.</typeparam>
/// <typeparam name="TValue">The type of the value.</typeparam>
[ComVisible(false)]
[PublicAPI]
public sealed class DictionaryDebugView<TKey, TValue>
{
    private readonly IDictionary<TKey, TValue> _dict;

    /// <summary>
    ///     Initializes a new instance of the <see cref="DictionaryDebugView{TKey, TValue}" /> class.
    /// </summary>
    /// <param name="dictionary">The dictionary.</param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="dictionary" />
    ///     is <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public DictionaryDebugView(IDictionary<TKey, TValue> dictionary) =>
        Requires.NotNull(
            out _dict,
            dictionary,
            nameof(dictionary));

    /// <summary>
    ///     Gets the items.
    /// </summary>
    /// <value>The items.</value>
    [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
    [SuppressMessage(
        "Performance",
        "CA1819:Properties should not return arrays",
        Justification = "This is supposed to be like this.")]
    public KyeValuePairDebugView<TKey, TValue>[] Items
    {
        get
        {
            var items = new KeyValuePair<TKey, TValue>[_dict.Count];
            _dict.CopyTo(
                items,
                0);

            return items.Select(
                    p => new KyeValuePairDebugView<TKey, TValue>
                    {
                        Key = p.Key,
                        Value = p.Value
                    })
                .ToArray();
        }
    }
}