namespace IX.Core.Entities;

/// <summary>
///     A data contract for an entity that tracks when and by whom it is updated.
/// </summary>
/// <typeparam name="TUserKey">The type of the user key.</typeparam>
[PublicAPI]
public interface IEntityWithChangeTracking<TUserKey>
{
    /// <summary>
    ///     Gets or sets the moment this entity was created at.
    /// </summary>
    /// <value>
    ///     The creation moment.
    /// </value>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    ///     Gets or sets the key of the user that this entity was created by.
    /// </summary>
    /// <value>
    ///     The creator key.
    /// </value>
    public TUserKey CreatedBy { get; set; }

    /// <summary>
    ///     Gets or sets the moment this entity was last changed at.
    /// </summary>
    /// <value>
    ///     The last change moment.
    /// </value>
    public DateTime LastChangedAt { get; set; }

    /// <summary>
    ///     Gets or sets the key of the user that this entity was last changed by.
    /// </summary>
    /// <value>
    ///     The last changer key.
    /// </value>
    public TUserKey LastChangedBy { get; set; }
}