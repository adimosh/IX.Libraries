using IX.Undoable.StateChanges;

namespace IX.Observable.StateChanges;

/// <summary>
///     An undo step for when a collection was cleared.
/// </summary>
/// <typeparam name="T">The type of item.</typeparam>
/// <seealso cref="StateChangeBase" />
public record ClearStateChange<T>(T[] OriginalItems) : StateChangeBase;