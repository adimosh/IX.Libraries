namespace IX.Library.ComponentModel.Events;

/// <summary>
/// Enumerable representing the possible options for inter-thread synchronization when publishing events.
/// </summary>
public enum EventSubscriptionSynchronizationOptions
{
    /// <summary>
    /// On a background thread (default behavior).
    /// </summary>
    BackgroundThread,
    /// <summary>
    /// Synchronous with publisher thread.
    /// </summary>
    SynchronousWithPublisherThread,
    /// <summary>
    /// Using the event bus' synchronization context, in a synchronous manner.
    /// </summary>
    SynchronouslyOnSynchronizationContext,
    /// <summary>
    /// Using the event bus' synchronization context, in an asynchronous manner, if available (if not, then synchronously).
    /// </summary>
    AsynchronouslyOnSynchronizationContext
}