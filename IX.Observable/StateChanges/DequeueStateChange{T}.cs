using IX.Undoable.StateChanges;

namespace IX.Observable.StateChanges;

/// <summary>
///     An undo step for when an item was dequeued.
/// </summary>
/// <typeparam name="T">The type of item.</typeparam>
/// <seealso cref="StateChangeBase" />
[PublicAPI]
public record DequeueStateChange<T>(T DequeuedItem) : StateChangeBase;