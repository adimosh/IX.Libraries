namespace IX.Library.ComponentModel.Events;

/// <summary>
/// A service contract for a publisher-subscriber event definition.
/// </summary>
/// <typeparam name="TEventArgs">The type of the event arguments.</typeparam>
[PublicAPI]
public interface IPubSubEvent<TEventArgs>
    where TEventArgs : EventArgs
{
    /// <summary>
    /// Subscribes to the event with specified handler with invocation on the background thread.
    /// </summary>
    /// <param name="handler">The handler.</param>
    /// <returns>A subscription token that can later be used to unsubscribe.</returns>
    IPublishedEventSubscriptionToken Subscribe(EventHandler<TEventArgs> handler);

    /// <summary>
    /// Subscribes to the event with specified handler with invocation using the specified synchronization options.
    /// </summary>
    /// <param name="handler">The handler.</param>
    /// <param name="synchronizationOptions">The synchronization options.</param>
    /// <returns>A subscription token that can later be used to unsubscribe.</returns>
    IPublishedEventSubscriptionToken Subscribe(EventHandler<TEventArgs> handler, EventSubscriptionSynchronizationOptions synchronizationOptions);

    /// <summary>
    /// Subscribes to the event with specified handler with invocation on the background thread, and keeps the reference alive.
    /// </summary>
    /// <param name="handler">The handler.</param>
    /// <returns>A subscription token that can later be used to unsubscribe.</returns>
    IPublishedEventSubscriptionToken SubscribeAndKeepReference(EventHandler<TEventArgs> handler);

    /// <summary>
    /// Subscribes to the event with specified handler with invocation using the specified synchronization options, and keeps the reference alive.
    /// </summary>
    /// <param name="handler">The handler.</param>
    /// <param name="synchronizationOptions">The synchronization options.</param>
    /// <returns>A subscription token that can later be used to unsubscribe.</returns>
    IPublishedEventSubscriptionToken SubscribeAndKeepReference(EventHandler<TEventArgs> handler, EventSubscriptionSynchronizationOptions synchronizationOptions);

    /// <summary>
    /// Publishes an event.
    /// </summary>
    /// <param name="publisher">The publisher of the event.</param>
    /// <param name="eventArgs">The event data.</param>
    void Publish(
        object publisher,
        TEventArgs eventArgs);
}