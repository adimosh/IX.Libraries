using IX.Core.Collections;

using System.Diagnostics;
using IX.Observable.Adapters;
using IX.Observable.DebugAide;
using IX.Observable.StateChanges;
using IX.Undoable.StateChanges;

namespace IX.Observable;

/// <summary>
///     A stack that broadcasts its changes.
/// </summary>
/// <typeparam name="T">The type of elements in the stack.</typeparam>
/// <remarks>
///     <para>
///         This class is not serializable. In order to serialize / deserialize content, please use the copying methods
///         and serialize the result.
///     </para>
/// </remarks>
[DebuggerDisplay("ObservableStack, Count = {" + nameof(Count) + "}")]
[DebuggerTypeProxy(typeof(StackDebugView<>))]
[PublicAPI]
public class ObservableStack<T> : ObservableCollectionBase<T>,
    IStack<T>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableStack{T}" /> class.
    /// </summary>
    public ObservableStack()
        : base(new StackCollectionAdapter<T>(new Core.Collections.Stack<T>())) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableStack{T}" /> class.
    /// </summary>
    /// <param name="capacity">The initial capacity of the stack.</param>
    public ObservableStack(int capacity)
        : base(new StackCollectionAdapter<T>(new Core.Collections.Stack<T>(capacity))) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableStack{T}" /> class.
    /// </summary>
    /// <param name="collection">A collection of items to copy into the stack.</param>
    public ObservableStack(IEnumerable<T> collection)
        : base(new StackCollectionAdapter<T>(new Core.Collections.Stack<T>(collection))) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableStack{T}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context top use when posting observable messages.</param>
    public ObservableStack(SynchronizationContext context)
        : base(
            new StackCollectionAdapter<T>(new Core.Collections.Stack<T>()),
            context) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableStack{T}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context top use when posting observable messages.</param>
    /// <param name="capacity">The initial capacity of the stack.</param>
    public ObservableStack(
        SynchronizationContext context,
        int capacity)
        : base(
            new StackCollectionAdapter<T>(new Core.Collections.Stack<T>(capacity)),
            context) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableStack{T}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context top use when posting observable messages.</param>
    /// <param name="collection">A collection of items to copy into the stack.</param>
    public ObservableStack(
        SynchronizationContext context,
        IEnumerable<T> collection)
        : base(
            new StackCollectionAdapter<T>(new Core.Collections.Stack<T>(collection)),
            context) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableStack{T}" /> class.
    /// </summary>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ObservableStack(bool suppressUndoable)
        : base(
            new StackCollectionAdapter<T>(new Core.Collections.Stack<T>()),
            suppressUndoable) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableStack{T}" /> class.
    /// </summary>
    /// <param name="capacity">The initial capacity of the stack.</param>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ObservableStack(
        int capacity,
        bool suppressUndoable)
        : base(
            new StackCollectionAdapter<T>(new Core.Collections.Stack<T>(capacity)),
            suppressUndoable) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableStack{T}" /> class.
    /// </summary>
    /// <param name="collection">A collection of items to copy into the stack.</param>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ObservableStack(
        IEnumerable<T> collection,
        bool suppressUndoable)
        : base(
            new StackCollectionAdapter<T>(new Core.Collections.Stack<T>(collection)),
            suppressUndoable) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableStack{T}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context top use when posting observable messages.</param>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ObservableStack(
        SynchronizationContext context,
        bool suppressUndoable)
        : base(
            new StackCollectionAdapter<T>(new Core.Collections.Stack<T>()),
            context,
            suppressUndoable) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableStack{T}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context top use when posting observable messages.</param>
    /// <param name="capacity">The initial capacity of the stack.</param>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ObservableStack(
        SynchronizationContext context,
        int capacity,
        bool suppressUndoable)
        : base(
            new StackCollectionAdapter<T>(new Core.Collections.Stack<T>(capacity)),
            context,
            suppressUndoable) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableStack{T}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context top use when posting observable messages.</param>
    /// <param name="collection">A collection of items to copy into the stack.</param>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ObservableStack(
        SynchronizationContext context,
        IEnumerable<T> collection,
        bool suppressUndoable)
        : base(
            new StackCollectionAdapter<T>(new Core.Collections.Stack<T>(collection)),
            context,
            suppressUndoable) { }

    /// <summary>
    ///     Gets a value indicating whether this stack is empty.
    /// </summary>
    /// <value>
    ///     <c>true</c> if this stack is empty; otherwise, <c>false</c>.
    /// </value>
    public bool IsEmpty => Count == 0;

    /// <summary>
    ///     Peeks in the stack to view the topmost item, without removing it.
    /// </summary>
    /// <returns>The topmost element in the stack, if any.</returns>
    public T Peek()
    {
        ThrowIfCurrentObjectDisposed();

        using (AcquireReadLock())
        {
            return ((StackCollectionAdapter<T>)InternalContainer).Peek();
        }
    }

    /// <summary>
    ///     Pops the topmost element from the stack, removing it.
    /// </summary>
    /// <returns>The topmost element in the stack, if any.</returns>
    public T Pop()
    {
        ThrowIfCurrentObjectDisposed();

        T item;
        int index;

        using (AcquireWriteLock())
        {
            var container = (StackCollectionAdapter<T>)InternalContainer;
            item = container.Pop();
            index = container.Count;
        }

        RaisePropertyChanged(nameof(Count));
        RaisePropertyChanged(Constants.ItemsName);
        RaiseCollectionChangedRemove(
            item,
            index);

        return item;
    }

    /// <summary>
    ///     Pushes an element to the top of the stack.
    /// </summary>
    /// <param name="item">The item to push.</param>
    public void Push(T item)
    {
        ThrowIfCurrentObjectDisposed();

        int index;

        using (AcquireWriteLock())
        {
            var container = (StackCollectionAdapter<T>)InternalContainer;
            container.Push(item);
            index = container.Count - 1;
        }

        RaisePropertyChanged(nameof(Count));
        RaisePropertyChanged(Constants.ItemsName);
        RaiseCollectionChangedAdd(
            item,
            index);
    }

    /// <summary>
    ///     Pushes a range of elements to the top of the stack.
    /// </summary>
    /// <param name="items">The item range to push.</param>
    public void PushRange(T[] items)
    {
        _ = Requires.NotNull(
            items);

        foreach (T item in items)
        {
            Push(item);
        }
    }

    /// <summary>
    ///     Pushes a range of elements to the top of the stack.
    /// </summary>
    /// <param name="items">The item range to push.</param>
    /// <param name="startIndex">The start index.</param>
    /// <param name="count">The number of items to push.</param>
    public void PushRange(
        T[] items,
        int startIndex,
        int count)
    {
        _ = Requires.NotNull(
            items);
        Requires.ValidArrayRange(
            in startIndex,
            in count,
            items);

        var itemsSpan = new ReadOnlySpan<T>(
            items,
            startIndex,
            count);
        foreach (T item in itemsSpan)
        {
            Push(item);
        }
    }

    /// <summary>
    ///     Copies all elements of the stack to a new array.
    /// </summary>
    /// <returns>An array containing all items in the stack.</returns>
    public T[] ToArray()
    {
        ThrowIfCurrentObjectDisposed();

        using (AcquireReadLock())
        {
            return ((StackCollectionAdapter<T>)InternalContainer).ToArray();
        }
    }

    /// <summary>
    ///     Sets the capacity to the actual number of elements in the stack if that number is less than 90 percent of current
    ///     capacity.
    /// </summary>
    public void TrimExcess()
    {
        ThrowIfCurrentObjectDisposed();

        using (AcquireWriteLock())
        {
            ((StackCollectionAdapter<T>)InternalContainer).TrimExcess();
        }
    }

    /// <summary>
    ///     Attempts to peek at the topmost item from the stack, without removing it.
    /// </summary>
    /// <param name="item">The topmost element in the stack, default if unsuccessful.</param>
    /// <returns>
    ///     <see langword="true" /> if an item is peeked at successfully, <see langword="false" /> otherwise, or if the
    ///     stack is empty.
    /// </returns>
    public bool TryPeek(out T item)
    {
        ThrowIfCurrentObjectDisposed();

        using (AcquireReadLock())
        {
            var container = (StackCollectionAdapter<T>)InternalContainer;

            if (container.Count == 0)
            {
                item = default!;

                return false;
            }

            item = container.Peek();

            return true;
        }
    }

    /// <summary>
    ///     Attempts to pop the topmost item from the stack, and remove it if successful.
    /// </summary>
    /// <param name="item">The topmost element in the stack, default if unsuccessful.</param>
    /// <returns>
    ///     <see langword="true" /> if an item is popped successfully, <see langword="false" /> otherwise, or if the
    ///     stack is empty.
    /// </returns>
    public bool TryPop(out T item)
    {
        ThrowIfCurrentObjectDisposed();

        int index;

        using (var @lock = AcquireReadWriteLock())
        {
            var container = (StackCollectionAdapter<T>)InternalContainer;

            if (container.Count == 0)
            {
                item = default!;

                return false;
            }

            @lock.Upgrade();

            if (container.Count == 0)
            {
                item = default!;

                return false;
            }

            item = container.Pop();
            index = container.Count;
        }

        RaisePropertyChanged(nameof(Count));
        RaisePropertyChanged(Constants.ItemsName);
        RaiseCollectionChangedRemove(
            item,
            index);

        return true;
    }

    /// <summary>
    ///     Interprets the block state changes outside the write lock.
    /// </summary>
    /// <param name="actions">The actions to employ.</param>
    /// <param name="states">The state objects to send to the corresponding actions.</param>
    protected override void InterpretBlockStateChangesOutsideLock(
        Action<object?>?[] actions,
        object?[] states)
    {
        RaisePropertyChanged(nameof(Count));
        RaisePropertyChanged(Constants.ItemsName);
        RaiseCollectionReset();
    }

    /// <summary>
    ///     Has the last undone operation redone.
    /// </summary>
    /// <param name="undoRedoLevel">A level of undo, with contents.</param>
    /// <param name="toInvokeOutsideLock">An action to invoke outside of the lock.</param>
    /// <param name="state">The state object to pass to the invocation.</param>
    /// <returns><see langword="true" /> if the redo was successful, <see langword="false" /> otherwise.</returns>
    protected override bool RedoInternally(
        StateChangeBase undoRedoLevel,
        out Action<object?>? toInvokeOutsideLock,
        out object? state)
    {
        if (base.UndoInternally(
                undoRedoLevel,
                out toInvokeOutsideLock,
                out state))
        {
            return true;
        }

        switch (undoRedoLevel)
        {
            case AddStateChange<T>(var item, var index):
            {
                var container = (StackCollectionAdapter<T>)InternalContainer;

                container.Push(item);

                toInvokeOutsideLock = innerState =>
                {
                    if (innerState == null)
                    {
                        return;
                    }

                    (var observableStack, T itemInternal, var indexInternal) =
                        (Tuple<ObservableStack<T>, T, int>)innerState;

                    observableStack.RaisePropertyChanged(nameof(observableStack.Count));
                    observableStack.RaisePropertyChanged(Constants.ItemsName);
                    observableStack.RaiseCollectionChangedAdd(
                        itemInternal,
                        indexInternal);
                };

                state = new Tuple<ObservableStack<T>, T, int>(
                    this,
                    item,
                    index);

                break;
            }

            case EnqueueStateChange<T>(var enqueuedItem):
            {
                var container = (StackCollectionAdapter<T>)InternalContainer;

                container.Push(enqueuedItem);

                var index = container.Count - 1;
                toInvokeOutsideLock = innerState =>
                {
                    if (innerState == null)
                    {
                        return;
                    }

                    (var observableStack, T itemInternal, var indexInternal) =
                        (Tuple<ObservableStack<T>, T, int>)innerState;

                    observableStack.RaisePropertyChanged(nameof(observableStack.Count));
                    observableStack.RaisePropertyChanged(Constants.ItemsName);
                    observableStack.RaiseCollectionChangedAdd(
                        itemInternal,
                        indexInternal);
                };

                state = new Tuple<ObservableStack<T>, T, int>(
                    this,
                    enqueuedItem,
                    index);

                break;
            }

            case DequeueStateChange<T>:
            {
                var container = (StackCollectionAdapter<T>)InternalContainer;

                T item = container.Pop();
                var index = container.Count;
                toInvokeOutsideLock = innerState =>
                {
                    if (innerState == null)
                    {
                        return;
                    }

                    (var observableStack, T itemInternal, var indexInternal) =
                        (Tuple<ObservableStack<T>, T, int>)innerState;

                    observableStack.RaisePropertyChanged(nameof(observableStack.Count));
                    observableStack.RaisePropertyChanged(Constants.ItemsName);
                    observableStack.RaiseCollectionChangedRemove(
                        itemInternal,
                        indexInternal);
                };

                state = new Tuple<ObservableStack<T>, T, int>(
                    this,
                    item,
                    index);

                break;
            }

            case RemoveStateChange<T>:
            {
                toInvokeOutsideLock = null;
                state = null;

                break;
            }

            case ClearStateChange<T>:
            {
                InternalContainer.Clear();

                toInvokeOutsideLock = innerState =>
                {
                    if (innerState == null)
                    {
                        return;
                    }

                    var convertedState = (ObservableStack<T>)innerState;

                    convertedState.RaisePropertyChanged(nameof(convertedState.Count));
                    convertedState.RaisePropertyChanged(Constants.ItemsName);
                    convertedState.RaiseCollectionReset();
                };

                state = this;

                break;
            }

            default:
            {
                toInvokeOutsideLock = null;
                state = null;

                return false;
            }
        }

        return true;
    }

    /// <summary>
    ///     Has the last operation undone.
    /// </summary>
    /// <param name="undoRedoLevel">A level of undo, with contents.</param>
    /// <param name="toInvokeOutsideLock">An action to invoke outside of the lock.</param>
    /// <param name="state">The state object to pass to the invocation.</param>
    /// <returns><see langword="true" /> if the undo was successful, <see langword="false" /> otherwise.</returns>
    protected override bool UndoInternally(
        StateChangeBase undoRedoLevel,
        out Action<object?>? toInvokeOutsideLock,
        out object? state)
    {
        if (base.RedoInternally(
                undoRedoLevel,
                out toInvokeOutsideLock,
                out state))
        {
            return true;
        }

        switch (undoRedoLevel)
        {
            case AddStateChange<T>:
            {
                var container = (StackCollectionAdapter<T>)InternalContainer;

                T item = container.Pop();
                var index = container.Count;
                toInvokeOutsideLock = innerState =>
                {
                    if (innerState == null)
                    {
                        return;
                    }

                    (var observableStack, T itemInternal, var indexInternal) =
                        (Tuple<ObservableStack<T>, T, int>)innerState;

                    observableStack.RaisePropertyChanged(nameof(observableStack.Count));
                    observableStack.RaisePropertyChanged(Constants.ItemsName);
                    observableStack.RaiseCollectionChangedRemove(
                        itemInternal,
                        indexInternal);
                };

                state = new Tuple<ObservableStack<T>, T, int>(
                    this,
                    item,
                    index);

                break;
            }

            case EnqueueStateChange<T>:
            {
                var container = (StackCollectionAdapter<T>)InternalContainer;

                T item = container.Pop();
                var index = container.Count;
                toInvokeOutsideLock = innerState =>
                {
                    if (innerState == null)
                    {
                        return;
                    }

                    (var observableStack, T itemInternal, var indexInternal) =
                        (Tuple<ObservableStack<T>, T, int>)innerState;

                    observableStack.RaisePropertyChanged(nameof(observableStack.Count));
                    observableStack.RaisePropertyChanged(Constants.ItemsName);
                    observableStack.RaiseCollectionChangedRemove(
                        itemInternal,
                        indexInternal);
                };

                state = new Tuple<ObservableStack<T>, T, int>(
                    this,
                    item,
                    index);

                break;
            }

            case DequeueStateChange<T>(var dequeuedItem):
            {
                var container = (StackCollectionAdapter<T>)InternalContainer;

                container.Push(dequeuedItem);

                var index = container.Count - 1;
                toInvokeOutsideLock = innerState =>
                {
                    if (innerState == null)
                    {
                        return;
                    }

                    (var observableStack, T itemInternal, var indexInternal) =
                        (Tuple<ObservableStack<T>, T, int>)innerState;

                    observableStack.RaisePropertyChanged(nameof(observableStack.Count));
                    observableStack.RaisePropertyChanged(Constants.ItemsName);
                    observableStack.RaiseCollectionChangedAdd(
                        itemInternal,
                        indexInternal);
                };

                state = new Tuple<ObservableStack<T>, T, int>(
                    this,
                    dequeuedItem,
                    index);

                break;
            }

            case RemoveStateChange<T>:
            {
                toInvokeOutsideLock = null;
                state = null;

                break;
            }

            case ClearStateChange<T>(var originalItems):
            {
                var container = (StackCollectionAdapter<T>)InternalContainer;
                for (var i = 0; i < originalItems.Length - 1; i++)
                {
                    container.Push(originalItems[i]);
                }

                toInvokeOutsideLock = innerState =>
                {
                    if (innerState == null)
                    {
                        return;
                    }

                    var convertedState = (ObservableStack<T>)innerState;

                    convertedState.RaisePropertyChanged(nameof(convertedState.Count));
                    convertedState.RaisePropertyChanged(Constants.ItemsName);
                    convertedState.RaiseCollectionReset();
                };

                state = this;

                break;
            }

            default:
            {
                toInvokeOutsideLock = null;
                state = null;

                return false;
            }
        }

        return true;
    }
}