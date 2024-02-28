namespace IX.Library.Entities;

/// <summary>
///     A data contract for an entity with an attached responsible person.
/// </summary>
/// <typeparam name="TUserKey">The type of the user key.</typeparam>
public interface IEntityWithResponsible<TUserKey>
{
    /// <summary>
    ///     Gets or sets the identifier of the user responsible for this entity.
    /// </summary>
    /// <value>
    ///     The responsible user identifier.
    /// </value>
    public TUserKey ResponsibleId { get; set; }
}