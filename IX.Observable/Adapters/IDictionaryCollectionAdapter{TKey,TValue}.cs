namespace IX.Observable.Adapters;

/// <summary>
///     A collection adapter contract for a dictionary collection adapter.
/// </summary>
/// <typeparam name="TKey">The type of the t key.</typeparam>
/// <typeparam name="TValue">The type of the t value.</typeparam>
/// <seealso cref="ICollectionAdapter{T}" />
/// <seealso cref="IDictionary{TKey,TValue}" />
public interface IDictionaryCollectionAdapter<TKey, TValue> : ICollectionAdapter<KeyValuePair<TKey, TValue>>,
    IDictionary<TKey, TValue>
{
    /// <summary>
    ///     Adds the specified key.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="value">The value.</param>
    /// <returns>The index where the item has been added.</returns>
    new int Add(
        TKey key,
        TValue value);
}