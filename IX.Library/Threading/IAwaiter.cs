using System.Runtime.CompilerServices;

namespace IX.Library.Threading;

/// <summary>
/// An interface that can be used to create custom awaiters.
/// </summary>
[PublicAPI]
public interface IAwaiter : INotifyCompletion
{
    /// <summary>
    /// Gets a value indicating whether the awaiter has completed.
    /// </summary>
    bool IsCompleted { get; }

    /// <summary>
    /// Gets the final result of the awaited operation, returning no value.
    /// </summary>
    void GetResult();

    /// <summary>
    /// Returns the current awaiter.
    /// </summary>
    /// <returns>The current awaiter.</returns>
    IAwaiter GetAwaiter();
}