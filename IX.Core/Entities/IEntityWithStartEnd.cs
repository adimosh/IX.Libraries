namespace IX.Core.Entities;

/// <summary>
///     A data contract for an entity that starts ar a certain point in time and, optionally, ends at another one.
/// </summary>
[PublicAPI]
public interface IEntityWithStartEnd
{
    /// <summary>
    ///     Gets or sets the moment this entity ended at, or <c>null</c> (<c>Nothing in Visual Basic</c>).
    /// </summary>
    /// <value>
    ///     The end date, if one exists.
    /// </value>
    public DateTime? EndedAt { get; set; }

    /// <summary>
    ///     Gets or sets the moment this entity is started at.
    /// </summary>
    /// <value>
    ///     The start date.
    /// </value>
    public DateTime StartedAt { get; set; }
}