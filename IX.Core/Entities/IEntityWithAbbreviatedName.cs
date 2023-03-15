namespace IX.Core.Entities;

/// <summary>
///     A data contract for an entity with an abbreviated name.
/// </summary>
[PublicAPI]
public interface IEntityWithAbbreviatedName
{
    /// <summary>
    ///     Gets or sets the abbreviation for this entity.
    /// </summary>
    /// <value>
    ///     The entity abbreviation.
    /// </value>
    public string Abbreviation { get; set; }
}