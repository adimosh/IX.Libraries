using IX.Undoable.StateChanges;

namespace IX.Observable.StateChanges;

/// <summary>
///     An undo step for when an item was added.
/// </summary>
/// <typeparam name="T">The type of item.</typeparam>
/// <seealso cref="StateChangeBase" />
[PublicAPI]
public record AddStateChange<T>(
    T AddedItem,
    int Index) : StateChangeBase;