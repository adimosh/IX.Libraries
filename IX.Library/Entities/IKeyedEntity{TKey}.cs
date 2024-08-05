namespace IX.Library.Entities;

/// <summary>
///     A data contract for an entity with a simple key.
/// </summary>
/// <typeparam name="TKey">The type of the key.</typeparam>
public interface IKeyedEntity<TKey>
{
    /// <summary>
    ///     Gets or sets the key for this entity.
    /// </summary>
    /// <value>
    ///     The entity key.
    /// </value>
    public TKey Id { get; set; }
}