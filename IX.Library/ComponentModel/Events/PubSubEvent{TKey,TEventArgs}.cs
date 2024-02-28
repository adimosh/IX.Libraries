namespace IX.Library.ComponentModel.Events;

/// <summary>
/// A publisher-subscriber event definition.
/// </summary>
/// <typeparam name="TKey">The type of the key.</typeparam>
/// <typeparam name="TEventArgs">The type of the event arguments.</typeparam>
/// <seealso cref="IPubSubEvent{TEventArgs}" />
/// <seealso cref="ReaderWriterSynchronizedBase" />
public sealed class PubSubEvent<TKey, TEventArgs> : ReaderWriterSynchronizedBase, IPubSubEvent<TEventArgs>
    where TKey : notnull
    where TEventArgs : EventArgs
{
    private readonly List<EventSubscription<TEventArgs>> _subscriptions;
    private readonly EventBus<TKey> _containerBus;

    /// <summary>
    /// Initializes a new instance of the <see cref="PubSubEvent{TKey, TEventArgs}"/> class.
    /// </summary>
    /// <param name="containerBus">The container bus.</param>
    public PubSubEvent(EventBus<TKey> containerBus)
    {
        _subscriptions = new();
        _containerBus = containerBus;
    }

    /// <summary>
    /// Subscribes to the event with specified handler with invocation on the background thread.
    /// </summary>
    /// <param name="handler">The handler.</param>
    /// <returns>A subscription token that can later be used to unsubscribe.</returns>
    public IPublishedEventSubscriptionToken Subscribe(EventHandler<TEventArgs> handler) =>
        SubscribeInternal(Requires.NotNull(handler), EventSubscriptionSynchronizationOptions.BackgroundThread, false);

    /// <summary>
    /// Subscribes to the event with specified handler with invocation using the specified synchronization options.
    /// </summary>
    /// <param name="handler">The handler.</param>
    /// <param name="synchronizationOptions">The synchronization options.</param>
    /// <returns>A subscription token that can later be used to unsubscribe.</returns>
    public IPublishedEventSubscriptionToken Subscribe(EventHandler<TEventArgs> handler, EventSubscriptionSynchronizationOptions synchronizationOptions) =>
        SubscribeInternal(Requires.NotNull(handler), synchronizationOptions, false);

    /// <summary>
    /// Subscribes to the event with specified handler with invocation on the background thread, and keeps the reference alive.
    /// </summary>
    /// <param name="handler">The handler.</param>
    /// <returns>A subscription token that can later be used to unsubscribe.</returns>
    public IPublishedEventSubscriptionToken SubscribeAndKeepReference(EventHandler<TEventArgs> handler) =>
        SubscribeInternal(Requires.NotNull(handler), EventSubscriptionSynchronizationOptions.BackgroundThread, true);

    /// <summary>
    /// Subscribes to the event with specified handler with invocation using the specified synchronization options, and keeps the reference alive.
    /// </summary>
    /// <param name="handler">The handler.</param>
    /// <param name="synchronizationOptions">The synchronization options.</param>
    /// <returns>A subscription token that can later be used to unsubscribe.</returns>
    public IPublishedEventSubscriptionToken SubscribeAndKeepReference(EventHandler<TEventArgs> handler, EventSubscriptionSynchronizationOptions synchronizationOptions) =>
        SubscribeInternal(Requires.NotNull(handler), synchronizationOptions, true);

    private IPublishedEventSubscriptionToken SubscribeInternal(
        EventHandler<TEventArgs> eventHandler,
        EventSubscriptionSynchronizationOptions synchronizationOptions,
        bool strongReference)
    {
        EventSubscription<TEventArgs> es = new(
            strongReference
                ? new StrongEventBusDelegateReference<TKey, TEventArgs>(
                    eventHandler,
                    synchronizationOptions,
                    _containerBus)
                : new WeakEventBusDelegateReference<TKey, TEventArgs>(
                    eventHandler,
                    synchronizationOptions,
                    _containerBus));

        using (AcquireWriteLock())
        {
            _subscriptions.Add(es);
        }

        return es.CreateToken();
    }

    /// <summary>
    /// Publishes an event.
    /// </summary>
    /// <param name="publisher">The publisher of the event.</param>
    /// <param name="eventArgs">The event data.</param>
    public void Publish(
        object publisher,
        TEventArgs eventArgs)
    {
        EventSubscription<TEventArgs>[] subscriptions;

        using (AcquireReadLock())
        {
            subscriptions = _subscriptions.ToArray();
        }

        List<EventSubscription<TEventArgs>>? possiblyInvalidSubscriptions = null;

        foreach (EventSubscription<TEventArgs> subscription in subscriptions)
        {
            if (!subscription.InvokeAction(
                    publisher,
                    eventArgs))
            {
                possiblyInvalidSubscriptions ??= new();
                possiblyInvalidSubscriptions.Add(subscription);
            }
        }

        if (possiblyInvalidSubscriptions != null)
        {
            ClearInactiveSubscriptions(possiblyInvalidSubscriptions);

            void ClearInactiveSubscriptions(List<EventSubscription<TEventArgs>> eventSubscriptions)
            {
                void MethodToInvoke(List<EventSubscription<TEventArgs>> subs)
                {
                    using (AcquireWriteLock())
                    {
                        if (_subscriptions.Count == 0) return;

                        _subscriptions.RemoveAll(subs.Contains);
                    }
                }

                Work.OnThreadPoolAsync(MethodToInvoke, eventSubscriptions);
            }
        }
    }
}