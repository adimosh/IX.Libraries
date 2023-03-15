using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace IX.Core.Threading;

/// <summary>
/// An awaiter for a synchronization context, which posts the continuation on the context.
/// </summary>
/// <seealso cref="INotifyCompletion" />
[PublicAPI]
public readonly struct SynchronizationContextAwaiter : INotifyCompletion
{
    private readonly SynchronizationContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="SynchronizationContextAwaiter"/> struct.
    /// </summary>
    /// <param name="context">The context.</param>
    public SynchronizationContextAwaiter(SynchronizationContext context)
    {
        Requires.NotNull(
            out _context,
            context);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SynchronizationContextAwaiter"/> struct.
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    public SynchronizationContextAwaiter()
    {
        _context = SynchronizationContext.Current ??
                   throw new InvalidOperationException(
                       Resources.ThereIsNoCurrentSynchronizationContextToAttemptCapturing);
    }

    /// <summary>
    /// Schedules the continuation action that's invoked when the instance completes.
    /// </summary>
    /// <param name="continuation">The action to invoke when the operation completes.</param>
    [SuppressMessage(
        "Performance",
        "HAA0603:Delegate allocation from a method group",
        Justification = "Unavoidable.")]
    public void OnCompleted(Action continuation)
    {
        Requires.NotNull(continuation);

        static void SendOrPostCallback(object state)
        {
            var action = (Action)state;
            action();
        }

        _context.Send(
            SendOrPostCallback,
            continuation);
    }
}