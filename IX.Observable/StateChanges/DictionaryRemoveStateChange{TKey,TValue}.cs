using IX.Undoable.StateChanges;

namespace IX.Observable.StateChanges;

/// <summary>
///     An undo level for removing something from a dictionary.
/// </summary>
/// <typeparam name="TKey">The type of the key.</typeparam>
/// <typeparam name="TValue">The type of the value.</typeparam>
/// <seealso cref="StateChangeBase" />
[PublicAPI]
public record DictionaryRemoveStateChange<TKey, TValue>(
    TKey Key,
    TValue Value) : StateChangeBase;