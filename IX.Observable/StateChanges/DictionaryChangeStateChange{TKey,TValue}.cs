using IX.Undoable.StateChanges;

namespace IX.Observable.StateChanges;

/// <summary>
///     An undo level for changing something in a dictionary.
/// </summary>
/// <typeparam name="TKey">The type of the key.</typeparam>
/// <typeparam name="TValue">The type of the value.</typeparam>
/// <seealso cref="StateChangeBase" />
public record DictionaryChangeStateChange<TKey, TValue>(
    TKey Key,
    TValue NewValue,
    TValue OldValue) : StateChangeBase;