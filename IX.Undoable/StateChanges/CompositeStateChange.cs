namespace IX.Undoable.StateChanges;

/// <summary>
///     A record for an entire set of state changes happening all at once.
/// </summary>
public record CompositeStateChange(List<StateChangeBase> StateChanges) : StateChangeBase;