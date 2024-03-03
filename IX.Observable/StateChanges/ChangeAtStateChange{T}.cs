using IX.Undoable.StateChanges;

namespace IX.Observable.StateChanges;

/// <summary>
///     A change at a specified index.
/// </summary>
/// <typeparam name="T">The type of the item changed.</typeparam>
/// <seealso cref="StateChangeBase" />
public record ChangeAtStateChange<T>(
    int Index,
    T NewValue,
    T OldValue) : StateChangeBase;