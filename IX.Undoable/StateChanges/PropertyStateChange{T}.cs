namespace IX.Undoable.StateChanges;

/// <summary>
///     A record for an undoable property change.
/// </summary>
/// <typeparam name="T">The type of value the property has.</typeparam>
public record PropertyStateChange<T>(
    string PropertyName,
    T OldValue,
    T NewValue) : PropertyStateChange(PropertyName);