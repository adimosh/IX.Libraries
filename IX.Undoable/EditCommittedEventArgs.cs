using IX.Undoable.StateChanges;

namespace IX.Undoable;

/// <summary>
///     Event arguments for edit committed.
/// </summary>
[PublicAPI]
public class EditCommittedEventArgs : EventArgs
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="EditCommittedEventArgs" /> class.
    /// </summary>
    /// <param name="stateChanges">The state changes that have been committed.</param>
    public EditCommittedEventArgs(StateChangeBase stateChanges) => StateChanges = stateChanges;

    /// <summary>
    ///     Gets the state changes that have been committed.
    /// </summary>
    public StateChangeBase StateChanges { get; }
}