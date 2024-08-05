using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace IX.Observable.DebugAide;

/// <summary>Debug view for an observable dictionary.</summary>
/// <typeparam name="TKey">The type of the key.</typeparam>
/// <typeparam name="TValue">The type of the value.</typeparam>
[ExcludeFromCodeCoverage]
public sealed class DictionaryDebugView<TKey, TValue>
    where TKey : notnull
{
    private readonly ObservableDictionary<TKey, TValue> _dict;

    /// <summary>Initializes a new instance of the <see cref="DictionaryDebugView{TKey, TValue}" /> class.</summary>
    /// <param name="dictionary">The dictionary.</param>
    /// <exception cref="ArgumentNullException">dictionary is null.</exception>
    public DictionaryDebugView(ObservableDictionary<TKey, TValue> dictionary) =>
        _dict = dictionary ?? throw new ArgumentNullException(nameof(dictionary));

    /// <summary>
    ///     Gets the items, in debug view.
    /// </summary>
    /// <value>
    ///     The items.
    /// </value>
    [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
    public Kvp<TKey, TValue>[] Items
    {
        get
        {
            var items = new KeyValuePair<TKey, TValue>[_dict.InternalContainer.Count];
            _dict.InternalContainer.CopyTo(
                items,
                0);

            return items.Select(
                    p => new Kvp<TKey, TValue>
                    {
                        Key = p.Key,
                        Value = p.Value
                    })
                .ToArray();
        }
    }
}