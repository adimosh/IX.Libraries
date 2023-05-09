using IX.Undoable.StateChanges;

namespace IX.Observable.StateChanges;

/// <summary>
///     An undo step for when some items were removed.
/// </summary>
/// <typeparam name="T">The type of items.</typeparam>
/// <seealso cref="StateChangeBase" />
[PublicAPI]
public record RemoveMultipleStateChange<T>(
    int[] Indexes,
    T[] RemovedItems) : StateChangeBase;