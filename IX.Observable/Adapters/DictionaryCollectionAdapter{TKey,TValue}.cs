#if !NET462 && !NET47 && !NETSTANDARD2_0
using System.Diagnostics.CodeAnalysis;
#endif

using System.Runtime.Serialization;

namespace IX.Observable.Adapters;

/// <summary>
///     A collection adapter for a dictionary.
/// </summary>
/// <typeparam name="TKey">The type of key in the dictionary.</typeparam>
/// <typeparam name="TValue">The type of value in the dictionary.</typeparam>
/// <seealso cref="ModernCollectionAdapter{TItem, TEnumerator}" />
[CollectionDataContract(
    Namespace = Constants.DataContractNamespace,
    Name = "DictionaryCollectionAdapterOf{1}By{0}",
    ItemName = "Item",
    KeyName = "Key",
    ValueName = "Value")]
internal class DictionaryCollectionAdapter<TKey, TValue> : ModernCollectionAdapter<KeyValuePair<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator>,
    IDictionaryCollectionAdapter<TKey, TValue>
    where TKey : notnull
{
    private Dictionary<TKey, TValue> _dictionary;

    public DictionaryCollectionAdapter() => _dictionary = new();

    internal DictionaryCollectionAdapter(IDictionary<TKey, TValue> dictionary) => _dictionary = new(dictionary);

    public override int Count => _dictionary.Count;

    public override bool IsReadOnly => ((ICollection<KeyValuePair<TKey, TValue>>)_dictionary).IsReadOnly;

    public ICollection<TKey> Keys => _dictionary.Keys;

    public ICollection<TValue> Values => _dictionary.Values;

    public TValue this[TKey key]
    {
        get => _dictionary[key];
        set => _dictionary[key] = value;
    }

    public override void Clear()
    {
        Dictionary<TKey, TValue> tempDictionary = _dictionary;
        _dictionary = new();

        _ = Work.OnThreadPoolAsync(
            oldDictionary => oldDictionary.Clear(),
            tempDictionary);
    }

    public override bool Contains(KeyValuePair<TKey, TValue> item) =>
        ((ICollection<KeyValuePair<TKey, TValue>>)_dictionary).Contains(item);

    public override void CopyTo(
        KeyValuePair<TKey, TValue>[] array,
        int arrayIndex) =>
        ((ICollection<KeyValuePair<TKey, TValue>>)_dictionary).CopyTo(
            array,
            arrayIndex);

    public override int Add(KeyValuePair<TKey, TValue> item)
    {
        ((ICollection<KeyValuePair<TKey, TValue>>)_dictionary).Add(item);

        return -1;
    }

    public override int Remove(KeyValuePair<TKey, TValue> item)
    {
        _ = ((ICollection<KeyValuePair<TKey, TValue>>)_dictionary).Remove(item);

        return -1;
    }

    public bool ContainsKey(TKey key) => _dictionary.ContainsKey(key);

    public bool Remove(TKey item) => _dictionary.Remove(item);

    public bool TryGetValue(
        TKey key,
#if !NET462 && !NET47 && !NETSTANDARD2_0
        [MaybeNullWhen(false)]
#endif
        out TValue value) =>
        _dictionary.TryGetValue(
            key,
            out value);

    public int Add(
        TKey key,
        TValue value)
    {
        _dictionary.Add(
            key,
            value);

        return -1;
    }

    void IDictionary<TKey, TValue>.Add(
        TKey key,
        TValue value) =>
        _dictionary.Add(
            key,
            value);

    public override Dictionary<TKey, TValue>.Enumerator GetEnumerator() => _dictionary.GetEnumerator();
}