namespace IX.Undoable.StateChanges;

/// <summary>
/// A record for a set of state changes in sub-items.
/// </summary>
/// <seealso cref="StateChangeBase" />
public record SubItemStateChange(
    IUndoableItem SubItem,
    StateChangeBase StateChange) : StateChangeBase;