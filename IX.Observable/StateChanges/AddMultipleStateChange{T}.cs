using IX.Undoable.StateChanges;

namespace IX.Observable.StateChanges;

/// <summary>
///     An undo step for when some items were added.
/// </summary>
/// <typeparam name="T">The type of items.</typeparam>
/// <seealso cref="StateChangeBase" />
public record AddMultipleStateChange<T>(
    T[] AddedItems,
    int Index) : StateChangeBase;