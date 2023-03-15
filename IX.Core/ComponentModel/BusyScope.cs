using System.Diagnostics.CodeAnalysis;

namespace IX.Core.ComponentModel;

/// <summary>
///     A scope of operations that can be marked as busy or idle.
/// </summary>
[PublicAPI]
public class BusyScope : SynchronizationContextInvokerBase
{
    private readonly string? _initialDescription;

    private int _busyCount;
    private string? _description;

    /// <summary>
    ///     Initializes a new instance of the <see cref="BusyScope" /> class.
    /// </summary>
    public BusyScope() { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="BusyScope" /> class.
    /// </summary>
    /// <param name="description">The scope description.</param>
    /// <exception cref="ArgumentNullException"><paramref name="description" /> is <see langword="null" />.</exception>
    public BusyScope(string description) =>
        Requires.NotNull<string>(
            out _initialDescription,
            description);

    /// <summary>
    ///     Initializes a new instance of the <see cref="BusyScope" /> class.
    /// </summary>
    /// <param name="initialBusyCount">The initial busy count.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="initialBusyCount" /> is an integer value less than 0.</exception>
    public BusyScope(int initialBusyCount) =>
        Requires.NonNegative(
            out _busyCount,
            in initialBusyCount);

    /// <summary>
    ///     Initializes a new instance of the <see cref="BusyScope" /> class.
    /// </summary>
    /// <param name="initialBusyCount">The initial busy count.</param>
    /// <param name="description">The scope description.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="initialBusyCount" /> is an integer value less than 0.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="description" /> is <see langword="null" />.</exception>
    public BusyScope(
        int initialBusyCount,
        string description)
    {
        Requires.NonNegative(
            out _busyCount,
            in initialBusyCount);
        Requires.NotNull<string>(
            out _initialDescription,
            description);
    }

    /// <summary>
    ///     Occurs when the busy status of the scope has changed.
    /// </summary>
    public event EventHandler? BusyScopeChanged;

    /// <summary>
    ///     Gets the busy count.
    /// </summary>
    /// <value>The busy count.</value>
    public int BusyCount => _busyCount;

    /// <summary>
    ///     Gets the description.
    /// </summary>
    /// <value>The description.</value>
    public string Description => _description ?? _initialDescription ?? string.Empty;

    /// <summary>
    ///     Increments the busy scope.
    /// </summary>
    /// <param name="description">The description for the topmost busy operation.</param>
    [SuppressMessage(
        "ReSharper",
        "ParameterHidesMember",
        Justification = "We know, that's the point.")]
    public void IncrementBusyScope(string? description = null)
    {
        _ = Interlocked.Increment(ref _busyCount);
        _ = Interlocked.Exchange(
            ref _description,
            description);

        if (BusyScopeChanged != null)
        {
            Invoke(
                (
                    sender,
                    @event) => @event.Invoke(
                    sender,
                    EventArgs.Empty),
                this,
                BusyScopeChanged);
        }
    }

    /// <summary>
    ///     Decrements the busy scope.
    /// </summary>
    /// <exception cref="InvalidOperationException">The scope is idle.</exception>
    public void DecrementBusyScope()
    {
        if (BusyCount == 0)
        {
            throw new InvalidOperationException();
        }

        _ = Interlocked.Decrement(ref _busyCount);

        if (BusyScopeChanged != null)
        {
            Invoke(
                (
                    sender,
                    @event) => @event.Invoke(
                    sender,
                    EventArgs.Empty),
                this,
                BusyScopeChanged);
        }
    }
}