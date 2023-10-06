namespace IX.Library.ComponentModel.Events;

/// <summary>
/// A service contract for an event bus for publisher-subscriber events.
/// </summary>
/// <typeparam name="TKey">The type of the key.</typeparam>
[PublicAPI]
public interface IEventBus<in TKey>
    where TKey : notnull
{
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
    IPubSubEvent<TEventArgs> GetEvent<TEventArgs>(TKey key)
        where TEventArgs : EventArgs;
}