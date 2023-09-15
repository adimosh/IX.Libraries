namespace IX.Library.Threading;

public static partial class Work
{
    /// <summary>
    /// Called when having to do work on the current synchronization context.
    /// </summary>
    /// <returns>A <see cref="SynchronizationContextAwaiter"/> that can be awaited on.</returns>
    public static SynchronizationContextAwaiter OnCurrentSynchronizationContext() =>
        new();
}