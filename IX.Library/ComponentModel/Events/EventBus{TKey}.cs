using IX.Library.Collections;

namespace IX.Library.ComponentModel.Events;

/// <summary>
/// An event bus for publisher-subscriber events.
/// </summary>
/// <typeparam name="TKey">The type of the key.</typeparam>
/// <seealso cref="DisposableBase" />
[PublicAPI]
public sealed class EventBus<TKey> : DisposableBase, IEventBus<TKey>
    where TKey : notnull
{
    private readonly ConcurrentDictionary<EventKey<TKey>, object> _events;

    internal SynchronizationContext? SynchronizationContext { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="EventBus{TKey}"/> class.
    /// </summary>
    public EventBus()
        : this(null)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="EventBus{TKey}"/> class.
    /// </summary>
    /// <param name="synchronizationContext">The synchronization context.</param>
    /// <remarks>
    /// <para>If null is specified for the <paramref name="synchronizationContext"/>, then the current synchronization context is used.</para>
    /// <para>It is not possible to create an event bus without a synchronization context, unless the current synchronization context can be null.</para>
    /// </remarks>
    public EventBus(SynchronizationContext? synchronizationContext)
    {
        _events = new();
        SynchronizationContext = synchronizationContext ?? SynchronizationContext.Current;
    }

    /// <summary>
    /// Gets an event based on the specified key and argument type.
    /// </summary>
    /// <typeparam name="TEventArgs">The type of the event arguments.</typeparam>
    /// <param name="key">The key.</param>
    /// <returns>An event.</returns>
    /// <exception cref="InvalidOperationException">The event has not been registered correctly.</exception>
    /// <remarks>
    /// <para>If an event has not been created, it will be created at this point.</para>
    /// </remarks>
    public IPubSubEvent<TEventArgs> GetEvent<TEventArgs>(TKey key)
    where TEventArgs : EventArgs
    {
        var eventKey = new EventKey<TKey>(
            key,
            typeof(TEventArgs));

        var @event = _events.GetOrAdd(
            eventKey,
            _ => new PubSubEvent<TKey, TEventArgs>(this));

        if (@event is not IPubSubEvent<TEventArgs> correctEvent) throw new InvalidOperationException();

        return correctEvent;
    }

    /// <summary>
    ///     Disposes in the managed context.
    /// </summary>
    protected override void DisposeManagedContext()
    {
        var events = _events.ClearToArray();

        foreach (var @event in events)
        {
            var disposableEvent = @event.Value as IDisposable;
            disposableEvent?.Dispose();
        }

        base.DisposeManagedContext();
    }
}