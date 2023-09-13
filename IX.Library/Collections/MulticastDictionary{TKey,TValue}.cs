namespace IX.Library.Collections;

/// <summary>
///     A multicast dictionary that attempts to hold multiple values for the same key, and take them one
///     at a time if the previous one did not yield the correct actionable result.
/// </summary>
/// <typeparam name="TKey">The type of the key.</typeparam>
/// <typeparam name="TValue">The type of the value.</typeparam>
/// <seealso cref="DisposableBase" />
[PublicAPI]
public class MulticastDictionary<TKey, TValue> : DisposableBase
    where TKey : notnull
{
    private readonly ConcurrentDictionary<TKey, List<TValue>> _innerDictionary = new();

    /// <summary>
    ///     Adds the specified key and value pair to the dictionary.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="value">The value.</param>
    [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Performance",
        "HAA0301:Closure Allocation Source",
        Justification = "This is acceptable.")]
    [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Performance",
        "HAA0302:Display class allocation to capture closure",
        Justification = "This is acceptable.")]
    public void Add(
        TKey key,
        TValue value) =>
        _ = _innerDictionary.AddOrUpdate(
            key,
            _ => new()
            {
                value
            },
            (
                _,
                v) =>
            {
                v.Add(value);

                return v;
            });

    /// <summary>
    ///     Removes a specified key entirely from the multicast dictionary.
    /// </summary>
    /// <param name="key">The key.</param>
    public void Remove(TKey key) =>
        _ = _innerDictionary.TryRemove(
            key,
            out _);

    /// <summary>
    ///     Removes a value pertaining to a specified key from the multicast dictionary.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="value">The value.</param>
    public void Remove(
        TKey key,
        TValue value)
    {
        if (!_innerDictionary.TryGetValue(
                key,
                out var list))
        {
            return;
        }

        _ = list.Remove(value);

        if (list.Count == 0)
        {
            Remove(key);
        }
    }

    /// <summary>
    ///     Clears all keys from the multicast dictionary.
    /// </summary>
    public void Clear() => _innerDictionary.Clear();

    /// <summary>
    ///     Tries to act on a specified key, based on its multiple values.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="action">The action to attempt.</param>
    /// <returns>Whether or not any action, if one was found, was successful.</returns>
    public bool TryAct(
        TKey key,
        Func<KeyValuePair<TKey, TValue>, bool> action)
    {
        _ = Requires.NotNull(
            action);

        if (!_innerDictionary.TryGetValue(
                key,
                out var list) ||
            list.Count == 0)
        {
            return false;
        }

        foreach (TValue value in list)
        {
            var mac = new KeyValuePair<TKey, TValue>(
                key,
                value);
            if (action(mac))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    ///     Tries to act on a specified key, based on its multiple values.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="action">The action to attempt.</param>
    /// <returns>Whether or not any action, if one was found, was successful.</returns>
    public bool TryAct(
        TKey key,
        Func<TKey, TValue, bool> action)
    {
        _ = Requires.NotNull(
            action);

        if (!_innerDictionary.TryGetValue(
                key,
                out var list) ||
            list.Count == 0)
        {
            return false;
        }

        foreach (TValue value in list)
        {
            if (action(
                    key,
                    value))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    ///     Tries to act asynchronously on a specified key, based on its multiple values.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="action">The action to attempt.</param>
    /// <returns>Whether or not any action, if one was found, was successful.</returns>
    public async Task<bool> TryActAsync(
        TKey key,
        Func<KeyValuePair<TKey, TValue>, Task<bool>> action)
    {
        _ = Requires.NotNull(
            action);

        if (!_innerDictionary.TryGetValue(
                key,
                out var list) ||
            list.Count == 0)
        {
            return false;
        }

        foreach (TValue value in list)
        {
            var mac = new KeyValuePair<TKey, TValue>(
                key,
                value);
            if (await action(mac)
                    .ConfigureAwait(false))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    ///     Tries to act asynchronously on a specified key, based on its multiple values.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="action">The action to attempt.</param>
    /// <returns>Whether or not any action, if one was found, was successful.</returns>
    public async Task<bool> TryActAsync(
        TKey key,
        Func<TKey, TValue, Task<bool>> action)
    {
        _ = Requires.NotNull(
            action);

        if (!_innerDictionary.TryGetValue(
                key,
                out var list) ||
            list.Count == 0)
        {
            return false;
        }

        foreach (TValue value in list)
        {
            if (await action(
                        key,
                        value)
                    .ConfigureAwait(false))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>Disposes in the managed context.</summary>
    protected override void DisposeManagedContext()
    {
        foreach (KeyValuePair<TKey, List<TValue>> key in _innerDictionary.ClearToArray())
        {
            key.Value?.Clear();
        }

        base.DisposeManagedContext();
    }
}