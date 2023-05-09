namespace IX.Undoable.StateChanges;

/// <summary>
///     A record for a state change of a property.
/// </summary>
public abstract record PropertyStateChange(string PropertyName) : StateChangeBase;