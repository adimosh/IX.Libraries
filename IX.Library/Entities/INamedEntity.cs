namespace IX.Library.Entities;

/// <summary>
///     A data contract for a named entity.
/// </summary>
[PublicAPI]
public interface INamedEntity
{
    /// <summary>
    ///     Gets or sets a name for this entity.
    /// </summary>
    /// <value>
    ///     The entity name.
    /// </value>
    public string Name { get; set; }
}