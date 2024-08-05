namespace IX.Library.Entities;

/// <summary>
///     A data contract for an entity that needs to remain in the database, or to be recoverable.
/// </summary>
public interface IPersistentEntity
{
    /// <summary>
    ///     Gets or sets a value indicating whether this entity is deleted.
    /// </summary>
    /// <value>
    ///     <c>true</c> if deleted and should not appear in queries; otherwise, <c>false</c>.
    /// </value>
    public bool Deleted { get; set; }
}