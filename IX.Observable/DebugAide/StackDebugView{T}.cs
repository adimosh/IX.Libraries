using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace IX.Observable.DebugAide;

/// <summary>
///     A debug view class for an observable stack.
/// </summary>
/// <typeparam name="T">The type of object in the stack.</typeparam>
[ExcludeFromCodeCoverage]
public sealed class StackDebugView<T>
{
    private readonly ObservableStack<T> _stack;

    /// <summary>
    ///     Initializes a new instance of the <see cref="StackDebugView{T}" /> class.
    /// </summary>
    /// <param name="stack">The stack.</param>
    /// <exception cref="ArgumentNullException">stack is null.</exception>
    public StackDebugView(ObservableStack<T> stack) => Requires.NotNull(out _stack, stack);

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
            var items = new T[_stack.InternalContainer.Count];
            _stack.InternalContainer.CopyTo(
                items,
                0);

            return items;
        }
    }
}