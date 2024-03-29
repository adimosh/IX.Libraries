namespace IX.Undoable;

/// <summary>
///     Service contract for an object that supports advertising a commit of an edited set of changes.
/// </summary>
public interface IEditCommittableItem
{
    /// <summary>
    ///     Occurs when an edit on this item is committed.
    /// </summary>
    event EventHandler<EditCommittedEventArgs> EditCommitted;
}