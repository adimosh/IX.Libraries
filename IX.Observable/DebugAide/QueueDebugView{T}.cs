using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace IX.Observable.DebugAide;

/// <summary>
///     A debug view for an observable queue.
/// </summary>
/// <typeparam name="T">The type of object in the queue.</typeparam>
[ExcludeFromCodeCoverage]
public sealed class QueueDebugView<T>
{
    private readonly ObservableQueue<T> _queue;

    /// <summary>
    ///     Initializes a new instance of the <see cref="QueueDebugView{T}" /> class.
    /// </summary>
    /// <param name="queue">The queue.</param>
    /// <exception cref="ArgumentNullException">queue is null.</exception>
    public QueueDebugView(ObservableQueue<T> queue) => Requires.NotNull(out _queue, queue);

    /// <summary>
    ///     Gets the items.
    /// </summary>
    /// <value>
    ///     The items.
    /// </value>
    [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
    public T[] Items
    {
        get
        {
            var items = new T[_queue.InternalContainer.Count];
            _queue.InternalContainer.CopyTo(
                items,
                0);

            return items;
        }
    }
}