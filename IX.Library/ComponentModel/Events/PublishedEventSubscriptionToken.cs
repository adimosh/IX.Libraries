namespace IX.Library.ComponentModel.Events;

/// <summary>
/// Represents a subscription token for a published event.
/// </summary>
/// <seealso cref="IDisposable" />
public interface IPublishedEventSubscriptionToken : IDisposable
{
    /// <summary>
    /// Gets the identifier of this current subscription.
    /// </summary>
    /// <value>
    /// The identifier.
    /// </value>
    Guid Id { get; init; }
}

internal sealed class PublishedEventSubscriptionToken : IPublishedEventSubscriptionToken
{
    private readonly Action _unsubscribe;

    internal PublishedEventSubscriptionToken(Guid id, Action unsubscribe)
    {
        Id = id;
        _unsubscribe = unsubscribe;
    }

    /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
    public void Dispose() => _unsubscribe();

    public Guid Id { get; init; }
}