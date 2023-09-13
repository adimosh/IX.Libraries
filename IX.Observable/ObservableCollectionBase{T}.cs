using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

using IX.Library.OperationModel;
using IX.Observable.Adapters;
using IX.Observable.StateChanges;
using IX.Undoable;
using IX.Undoable.StateChanges;

namespace IX.Observable;

/// <summary>
///     A base class for collections that are observable.
/// </summary>
/// <typeparam name="T">The type of the item.</typeparam>
/// <seealso cref="INotifyPropertyChanged" />
/// <seealso cref="INotifyCollectionChanged" />
/// <seealso cref="IEnumerable{T}" />
[PublicAPI]
public abstract class ObservableCollectionBase<T> : ObservableReadOnlyCollectionBase<T>, ICollection<T>, IUndoableItem,
                                                    IEditCommittableItem
{
    private readonly Lazy<UndoableInnerContext> _undoContext;
    private bool _automaticallyCaptureSubItems;
    private UndoableUnitBlockTransaction<T>? _currentUndoBlockTransaction;
    private int _historyLevels;
    private bool _suppressUndoable;

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableCollectionBase{T}" /> class.
    /// </summary>
    /// <param name="internalContainer">The internal container of items.</param>
    protected ObservableCollectionBase(ICollectionAdapter<T> internalContainer)
        : this(
            internalContainer,
            EnvironmentSettings.AlwaysSuppressUndoLevelsByDefault) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableCollectionBase{T}" /> class.
    /// </summary>
    /// <param name="internalContainer">The internal container of items.</param>
    /// <param name="context">The synchronization context to use, if any.</param>
    protected ObservableCollectionBase(
        ICollectionAdapter<T> internalContainer,
        SynchronizationContext context)
        : this(
            internalContainer,
            context,
            EnvironmentSettings.AlwaysSuppressUndoLevelsByDefault) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableCollectionBase{T}" /> class.
    /// </summary>
    /// <param name="internalContainer">The internal container of items.</param>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    protected ObservableCollectionBase(
        ICollectionAdapter<T> internalContainer,
        bool suppressUndoable)
        : base(internalContainer)
    {
        _undoContext = new(InnerContextFactory);
        _suppressUndoable = EnvironmentSettings.DisableUndoable || suppressUndoable;
        _historyLevels = EnvironmentSettings.DefaultUndoRedoLevels;
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableCollectionBase{T}" /> class.
    /// </summary>
    /// <param name="internalContainer">The internal container of items.</param>
    /// <param name="context">The synchronization context to use, if any.</param>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    protected ObservableCollectionBase(
        ICollectionAdapter<T> internalContainer,
        SynchronizationContext context,
        bool suppressUndoable)
        : base(
            internalContainer,
            context)
    {
        _undoContext = new(InnerContextFactory);
        _suppressUndoable = EnvironmentSettings.DisableUndoable || suppressUndoable;
        _historyLevels = EnvironmentSettings.DefaultUndoRedoLevels;
    }

    /// <summary>
    ///     Gets a value indicating whether items are key/value pairs.
    /// </summary>
    /// <value><see langword="true" /> if items are key/value pairs; otherwise, <see langword="false" />.</value>
    public bool ItemsAreKeyValuePairs { get; }

    /// <summary>
    ///     Gets a value indicating whether items are undoable.
    /// </summary>
    /// <value><see langword="true" /> if items are undoable; otherwise, <see langword="false" />.</value>
    public bool ItemsAreUndoable { get; } = typeof(IUndoableItem).GetTypeInfo()
                                                                 .IsAssignableFrom(typeof(T).GetTypeInfo());

    /// <summary>
    ///     Gets or sets a value indicating whether to automatically capture sub items in the current undo/redo context.
    /// </summary>
    /// <value><see langword="true" /> to automatically capture sub items; otherwise, <see langword="false" />.</value>
    /// <remarks>
    ///     <para>This property does nothing if the items of the observable collection are not undoable themselves.</para>
    ///     <para>
    ///         To check whether or not the items are undoable at runtime, please use the <see cref="ItemsAreUndoable" />
    ///         property.
    ///     </para>
    /// </remarks>
    public bool AutomaticallyCaptureSubItems
    {
        get => _automaticallyCaptureSubItems;

        set =>
            SetAutomaticallyCaptureSubItems(
                value,
                false);
    }

    /// <summary>
    ///     Adds an item to the <see cref="ObservableCollectionBase{T}" />.
    /// </summary>
    /// <param name="item">The object to add to the <see cref="ObservableCollectionBase{T}" />.</param>
    /// <remarks>
    ///     <para>On concurrent collections, this method is write-synchronized.</para>
    /// </remarks>
    public virtual void Add(T item)
    {
        // PRECONDITIONS

        // Current object not disposed
        ThrowIfCurrentObjectDisposed();

        // ACTION
        int newIndex;

        // Under write lock
        using (AcquireWriteLock())
        {
            // Using an undo/redo transaction lock
            using OperationTransaction tc = CheckItemAutoCapture(item);

            // Add the item
            newIndex = InternalContainer.Add(item);

            // Push the undo level
            PushUndoLevel(
                new AddStateChange<T>(
                    item,
                    newIndex));

            // Mark the transaction as a success
            tc.Success();
        }

        // NOTIFICATIONS

        // Collection changed
        if (newIndex == -1)
        {
            // If no index could be found for an item (Dictionary add)
            RaiseCollectionReset();
        }
        else
        {
            // If index was added at a specific index
            RaiseCollectionChangedAdd(
                item,
                newIndex);
        }

        // Property changed
        RaisePropertyChanged(nameof(Count));

        // Contents may have changed
        ContentsMayHaveChanged();
    }

    /// <summary>
    ///     Removes all items from the <see cref="ObservableCollectionBase{T}" />.
    /// </summary>
    /// <remarks>
    ///     <para>On concurrent collections, this method is write-synchronized.</para>
    /// </remarks>
    public void Clear() => ClearInternal();

    /// <summary>
    ///     Removes the first occurrence of a specific object from the <see cref="ObservableCollectionBase{T}" />.
    /// </summary>
    /// <param name="item">The object to remove from the <see cref="ObservableCollectionBase{T}" />.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="item" /> was successfully removed from the
    ///     <see cref="ObservableCollectionBase{T}" />; otherwise, <see langword="false" />.
    ///     This method also returns false if <paramref name="item" /> is not found in the original
    ///     <see cref="ObservableCollectionBase{T}" />.
    /// </returns>
    /// <remarks>
    ///     <para>On concurrent collections, this method is write-synchronized.</para>
    /// </remarks>
    public virtual bool Remove(T item)
    {
        // PRECONDITIONS

        // Current object not disposed
        ThrowIfCurrentObjectDisposed();

        // ACTION
        int oldIndex;

        // Under write lock
        using (AcquireWriteLock())
        {
            // Inside an undo/redo transaction
            using OperationTransaction tc = CheckItemAutoRelease(item);

            // Remove the item
            oldIndex = InternalContainer.Remove(item);

            // Push an undo level
            PushUndoLevel(
                new RemoveStateChange<T>(
                    oldIndex,
                    item));

            // Mark the transaction as a success
            tc.Success();
        }

        // NOTIFICATIONS AND RETURN

        // Collection changed
        if (oldIndex >= 0)
        {
            // Collection changed with a specific index
            RaiseCollectionChangedRemove(
                item,
                oldIndex);

            // Property changed
            RaisePropertyChanged(nameof(Count));

            // Contents may have changed
            ContentsMayHaveChanged();

            return true;
        }

        if (oldIndex >= -1)
        {
            // Unsuccessful removal
            return false;
        }

        // Collection changed with no specific index (Dictionary remove)
        RaiseCollectionReset();

        // Property changed
        RaisePropertyChanged(nameof(Count));

        // Contents may have changed
        ContentsMayHaveChanged();

        return true;
    }

    /// <summary>
    ///     Occurs when an edit on this item is committed.
    /// </summary>
    /// <remarks>
    ///     <para>Warning! This event is invoked within the write lock on concurrent collections.</para>
    /// </remarks>
    event EventHandler<EditCommittedEventArgs> IEditCommittableItem.EditCommitted
    {
        add => EditCommittedInternal += value;
        remove => EditCommittedInternal -= value;
    }

    /// <summary>
    ///     Gets a value indicating whether or not the implementer can perform a redo.
    /// </summary>
    /// <value>
    ///     <see langword="true" /> if the call to the <see cref="M:IX.Undoable.IUndoableItem.Redo" /> method would result
    ///     in a state change, <see langword="false" /> otherwise.
    /// </value>
    public bool CanRedo
    {
        get
        {
            if (_suppressUndoable || EnvironmentSettings.DisableUndoable || _historyLevels == 0)
            {
                return false;
            }

            ThrowIfCurrentObjectDisposed();

            return ParentUndoContext?.CanRedo ?? ReadLock(
                thisL1 => thisL1._undoContext.IsValueCreated && thisL1._undoContext.Value.RedoStackHasData,
                this);
        }
    }

    /// <summary>
    ///     Gets a value indicating whether or not the implementer can perform an undo.
    /// </summary>
    /// <value>
    ///     <see langword="true" /> if the call to the <see cref="M:IX.Undoable.IUndoableItem.Undo" /> method would result
    ///     in a state change, <see langword="false" /> otherwise.
    /// </value>
    public bool CanUndo
    {
        get
        {
            if (_suppressUndoable || EnvironmentSettings.DisableUndoable || _historyLevels == 0)
            {
                return false;
            }

            ThrowIfCurrentObjectDisposed();

            return ParentUndoContext?.CanUndo ?? ReadLock(
                thisL1 => thisL1._undoContext.IsValueCreated && thisL1._undoContext.Value.UndoStackHasData,
                this);
        }
    }

    /// <summary>
    ///     Gets a value indicating whether this instance is caught into an undo context.
    /// </summary>
    public bool IsCapturedIntoUndoContext => ParentUndoContext != null;

    /// <summary>
    ///     Gets or sets the number of levels to keep undo or redo information.
    /// </summary>
    /// <value>The history levels.</value>
    /// <remarks>
    ///     <para>
    ///         If this value is set, for example, to 7, then the implementing object should allow the
    ///         <see cref="M:IX.Undoable.IUndoableItem.Undo" /> method
    ///         to be called 7 times to change the state of the object. Upon calling it an 8th time, there should be no change
    ///         in the
    ///         state of the object.
    ///     </para>
    ///     <para>
    ///         Any call beyond the limit imposed here should not fail, but it should also not change the state of the
    ///         object.
    ///     </para>
    ///     <para>
    ///         This member is not serialized, as it interferes with the undo/redo context, which cannot itself be
    ///         serialized.
    ///     </para>
    /// </remarks>
    public int HistoryLevels
    {
        get => _historyLevels;
        set
        {
            if (value == _historyLevels)
            {
                return;
            }

            _undoContext.Value.HistoryLevels = value;

            // We'll let the internal undo context to curate our history levels
            _historyLevels = _undoContext.Value.HistoryLevels;
        }
    }

    /// <summary>
    ///     Gets the parent undo context, if any.
    /// </summary>
    /// <value>The parent undo context.</value>
    /// <remarks>
    ///     <para>This member is not serialized, as it represents the undo/redo context, which cannot itself be serialized.</para>
    ///     <para>
    ///         The concept of the undo/redo context is incompatible with serialization. Any collection that is serialized will
    ///         be free of any original context
    ///         when deserialized.
    ///     </para>
    /// </remarks>
    public IUndoableItem? ParentUndoContext { get; private set; }

    /// <summary>
    ///     Allows the implementer to be captured by a containing undo-/redo-capable object so that undo and redo operations
    ///     can be coordinated across a larger scope.
    /// </summary>
    /// <param name="parent">The parent undo and redo context.</param>
    public void CaptureIntoUndoContext(IUndoableItem parent) =>
        CaptureIntoUndoContext(
            parent,
            false);

    /// <summary>
    ///     Has the last undone operation performed on the implemented instance, presuming that it has not changed, redone.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         If the object is captured, the method will call the capturing parent's Redo method, which can bubble down to
    ///         the last instance of an undo-/redo-capable object.
    ///     </para>
    ///     <para>
    ///         If that is the case, the capturing object is solely responsible for ensuring that the inner state of the whole
    ///         system is correct. Implementing classes should not expect this method to also handle state.
    ///     </para>
    ///     <para>If the object is released, it is expected that this method once again starts ensuring state when called.</para>
    /// </remarks>
    public void Redo()
    {
        if (_suppressUndoable || EnvironmentSettings.DisableUndoable || _historyLevels == 0)
        {
            return;
        }

        ThrowIfCurrentObjectDisposed();

        if (ParentUndoContext != null)
        {
            ParentUndoContext.Redo();

            return;
        }

        if (_currentUndoBlockTransaction != null)
        {
            throw new InvalidOperationException(
                Resources.UndoAndRedoOperationsAreNotSupportedWhileAnExplicitTransactionBlockIsOpen);
        }

        Action<object?>? toInvoke;
        object? state;
        bool internalResult;

        using (ValueSynchronizationLockerReadWrite locker = AcquireReadWriteLock())
        {
            if (!_undoContext.IsValueCreated || !_undoContext.Value.RedoStackHasData)
            {
                return;
            }

            _ = locker.Upgrade();

            UndoableInnerContext uc = _undoContext.Value;

            StateChangeBase level = uc.PopRedo();
            internalResult = RedoInternally(
                level,
                out toInvoke,
                out state);

            if (internalResult)
            {
                uc.PushUndo(level);
            }
        }

        if (internalResult)
        {
            toInvoke?.Invoke(state);
        }

        RaisePropertyChanged(nameof(CanUndo));
        RaisePropertyChanged(nameof(CanRedo));
    }

    /// <summary>
    ///     Has the state changes received redone into the object.
    /// </summary>
    /// <param name="changesToRedo">The state changes to redo.</param>
    /// <exception cref="ItemNotCapturedIntoUndoContextException">There is no capturing context.</exception>
    public void RedoStateChanges(StateChangeBase changesToRedo)
    {
        // PRECONDITIONS
        if (_suppressUndoable || EnvironmentSettings.DisableUndoable || _historyLevels == 0)
        {
            return;
        }

        // Current object not disposed
        ThrowIfCurrentObjectDisposed();

        // Current object captured in an undo/redo context
        if (!IsCapturedIntoUndoContext)
        {
            throw new ItemNotCapturedIntoUndoContextException();
        }

        // ACTION
        switch (changesToRedo)
        {
            case SubItemStateChange subItemStateChange:
            {
                subItemStateChange.SubItem.RedoStateChanges(subItemStateChange.StateChange);

                break;
            }

            case CompositeStateChange compositeStateChange:
            {
                foreach (StateChangeBase stateChangeBase in compositeStateChange.StateChanges)
                {
                    object? state;
                    bool internalResult;
                    Action<object?>? act;

                    using (AcquireWriteLock())
                    {
                        internalResult = RedoInternally(
                            stateChangeBase,
                            out act,
                            out state);
                    }

                    if (internalResult)
                    {
                        act?.Invoke(state);
                    }
                }

                break;
            }

            case { } stateChangeBase:
            {
                Action<object?>? act;
                object? state;
                bool internalResult;

                using (AcquireWriteLock())
                {
                    internalResult = RedoInternally(
                        stateChangeBase,
                        out act,
                        out state);
                }

                if (internalResult)
                {
                    act?.Invoke(state);
                }

                break;
            }
        }
    }

    /// <summary>
    ///     Releases the implementer from being captured into an undo and redo context.
    /// </summary>
    public void ReleaseFromUndoContext()
    {
        ThrowIfCurrentObjectDisposed();

        using (AcquireWriteLock())
        {
            SetAutomaticallyCaptureSubItems(
                false,
                true);
            ParentUndoContext = null;
        }
    }

    /// <summary>
    ///     Has the last operation performed on the implementing instance undone.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         If the object is captured, the method will call the capturing parent's Undo method, which can bubble down to
    ///         the last instance of an undo-/redo-capable object.
    ///     </para>
    ///     <para>
    ///         If that is the case, the capturing object is solely responsible for ensuring that the inner state of the whole
    ///         system is correct. Implementing classes should not expect this method to also handle state.
    ///     </para>
    ///     <para>If the object is released, it is expected that this method once again starts ensuring state when called.</para>
    /// </remarks>
    public void Undo()
    {
        if (_suppressUndoable || EnvironmentSettings.DisableUndoable || _historyLevels == 0)
        {
            return;
        }

        ThrowIfCurrentObjectDisposed();

        if (ParentUndoContext != null)
        {
            ParentUndoContext.Undo();

            return;
        }

        if (_currentUndoBlockTransaction != null)
        {
            throw new InvalidOperationException(
                Resources.UndoAndRedoOperationsAreNotSupportedWhileAnExplicitTransactionBlockIsOpen);
        }

        Action<object?>? toInvoke;
        object? state;
        bool internalResult;

        using (ValueSynchronizationLockerReadWrite locker = AcquireReadWriteLock())
        {
            if (!_undoContext.IsValueCreated || !_undoContext.Value.UndoStackHasData)
            {
                return;
            }

            _ = locker.Upgrade();

            UndoableInnerContext uc = _undoContext.Value;

            StateChangeBase level = uc.PopUndo();
            internalResult = UndoInternally(
                level,
                out toInvoke,
                out state);

            if (internalResult)
            {
                uc.PushRedo(level);
            }
        }

        if (internalResult)
        {
            toInvoke?.Invoke(state);
        }

        RaisePropertyChanged(nameof(CanUndo));
        RaisePropertyChanged(nameof(CanRedo));
    }

    /// <summary>
    ///     Has the state changes received undone from the object.
    /// </summary>
    /// <param name="changesToUndo">The state changes to redo.</param>
    /// <exception cref="ItemNotCapturedIntoUndoContextException">There is no capturing context.</exception>
    public void UndoStateChanges(StateChangeBase changesToUndo)
    {
        // PRECONDITIONS
        if (_suppressUndoable || EnvironmentSettings.DisableUndoable || _historyLevels == 0)
        {
            return;
        }

        // Current object not disposed
        ThrowIfCurrentObjectDisposed();

        // Current object captured in an undo/redo context
        if (!IsCapturedIntoUndoContext)
        {
            throw new ItemNotCapturedIntoUndoContextException();
        }

        // ACTION
        switch (changesToUndo)
        {
            case SubItemStateChange subItemStateChange:
            {
                subItemStateChange.SubItem.UndoStateChanges(subItemStateChange.StateChange);

                break;
            }

            case CompositeStateChange compositeStateChange:
            {
                foreach (StateChangeBase stateChangeBase in compositeStateChange.StateChanges)
                {
                    Action<object?>? act;
                    object? state;
                    bool internalResult;

                    using (AcquireWriteLock())
                    {
                        internalResult = UndoInternally(
                            stateChangeBase,
                            out act,
                            out state);
                    }

                    if (internalResult)
                    {
                        act?.Invoke(state);
                    }
                }

                break;
            }

            case { } stateChangeBase:
            {
                Action<object?>? act;
                object? state;
                bool internalResult;

                using (AcquireWriteLock())
                {
                    internalResult = UndoInternally(
                        stateChangeBase,
                        out act,
                        out state);
                }

                if (internalResult)
                {
                    act?.Invoke(state);
                }

                break;
            }
        }
    }

    /// <summary>
    ///     Occurs when an edit is committed to the collection, whichever that may be.
    /// </summary>
    protected event EventHandler<EditCommittedEventArgs>? EditCommittedInternal;

    /// <summary>
    ///     Starts the undoable operations on this object.
    /// </summary>
    /// <remarks>
    ///     <para>If undoable operations were suppressed, no undo levels will accumulate before calling this method.</para>
    /// </remarks>
    public void StartUndo() => _suppressUndoable = false;

    /// <summary>
    ///     Removes all items from the <see cref="ObservableCollectionBase{T}" /> and returns them as an array.
    /// </summary>
    /// <returns>An array containing the original collection items.</returns>
    /// <remarks>
    ///     <para>On concurrent collections, this method is write-synchronized.</para>
    /// </remarks>
    public T[] ClearAndPersist() => ClearInternal();

    /// <summary>
    ///     Allows the implementer to be captured by a containing undo-/redo-capable object so that undo and redo operations
    ///     can be coordinated across a larger scope.
    /// </summary>
    /// <param name="parent">The parent undo and redo context.</param>
    /// <param name="captureSubItems">
    ///     if set to <see langword="true" />, the collection automatically captures sub-items into
    ///     its undo/redo context.
    /// </param>
    public void CaptureIntoUndoContext(
        IUndoableItem parent,
        bool captureSubItems)
    {
        ThrowIfCurrentObjectDisposed();

        if (parent == null)
        {
            throw new ArgumentNullException(nameof(parent));
        }

        using (AcquireWriteLock())
        {
            SetAutomaticallyCaptureSubItems(
                captureSubItems,
                true);
            ParentUndoContext = parent;
        }
    }

    /// <summary>
    ///     Starts an explicit undo block transaction.
    /// </summary>
    /// <returns>OperationTransaction.</returns>
    public OperationTransaction StartExplicitUndoBlockTransaction()
    {
        if (IsCapturedIntoUndoContext)
        {
            throw new InvalidOperationException(
                Resources.TheCollectionIsCapturedIntoAContextItCannotStartAnExplicitTransaction);
        }

        if (_currentUndoBlockTransaction != null)
        {
            throw new InvalidOperationException(Resources.ThereAlreadyIsAnOpenUndoTransaction);
        }

        var transaction = new UndoableUnitBlockTransaction<T>(this);

        _ = Interlocked.Exchange(
            ref _currentUndoBlockTransaction,
            transaction);

        return transaction;
    }

    /// <summary>
    ///     Finishes the explicit undo block transaction.
    /// </summary>
    internal void FinishExplicitUndoBlockTransaction()
    {
        if (_currentUndoBlockTransaction == null)
        {
            return;
        }

        _undoContext.Value.PushUndo(_currentUndoBlockTransaction.StateChanges);

        _ = Interlocked.Exchange(
            ref _currentUndoBlockTransaction,
            null!);

        _undoContext.Value.ClearRedoStack();

        RaisePropertyChanged(nameof(CanUndo));
        RaisePropertyChanged(nameof(CanRedo));
    }

    /// <summary>
    ///     Fails the explicit undo block transaction.
    /// </summary>
    internal void FailExplicitUndoBlockTransaction() =>
        Interlocked.Exchange(
            ref _currentUndoBlockTransaction,
            null);

    /// <summary>
    ///     Disposes the managed context.
    /// </summary>
    protected override void DisposeManagedContext()
    {
        base.DisposeManagedContext();

        if (_undoContext.IsValueCreated)
        {
            _undoContext.Value.Dispose();
        }
    }

    /// <summary>
    ///     Has the last operation undone.
    /// </summary>
    /// <param name="undoRedoLevel">A level of undo, with contents.</param>
    /// <param name="toInvokeOutsideLock">An action to invoke outside of the lock.</param>
    /// <param name="state">The state object to pass to the invocation.</param>
    /// <returns><see langword="true" /> if the undo was successful, <see langword="false" /> otherwise.</returns>
    [SuppressMessage(
        "Performance",
        "HAA0401:Possible allocation of reference type enumerator",
        Justification = "We're OK with this, the cost of the allocation is too small.")]
    protected virtual bool UndoInternally(
        StateChangeBase undoRedoLevel,
        out Action<object?>? toInvokeOutsideLock,
        out object? state)
    {
        switch (undoRedoLevel)
        {
            case SubItemStateChange subItemStateChange:
                subItemStateChange.SubItem.UndoStateChanges(subItemStateChange.StateChange);

                toInvokeOutsideLock = null;
                state = null;

                return true;
            case CompositeStateChange compositeStateChange:
            {
                var count = compositeStateChange.StateChanges.Count;

                if (count == 0)
                {
                    toInvokeOutsideLock = null;
                    state = null;

                    return true;
                }

                var actionsToInvoke = new Action<object>[count];
                var states = new object[count];
                var counter = 0;
                var result = true;

                foreach (StateChangeBase sc in ((IEnumerable<StateChangeBase>)compositeStateChange.StateChanges)
                         .Reverse())
                {
                    try
                    {
                        var localResult = UndoInternally(
                            sc,
                            out Action<object?>? toInvoke,
                            out var toState);

                        if (!localResult)
                        {
                            result = false;
                        }
                        else
                        {
                            actionsToInvoke[counter] = toInvoke!;
                            states[counter] = toState!;
                        }
                    }
                    finally
                    {
                        counter++;
                    }
                }

                state = new Tuple<Action<object>[], object[], ObservableCollectionBase<T>>(
                    actionsToInvoke,
                    states,
                    this);
                toInvokeOutsideLock = innerState =>
                {
                    if (innerState == null)
                    {
                        return;
                    }

                    (Action<object?>?[]? actions, var objects, ObservableCollectionBase<T>? observableCollectionBase) =
                        (Tuple<Action<object?>?[], object?[], ObservableCollectionBase<T>>)innerState;

                    observableCollectionBase.InterpretBlockStateChangesOutsideLock(
                        actions,
                        objects);
                };

                return result;
            }
        }

        toInvokeOutsideLock = null;
        state = null;

        return false;
    }

    /// <summary>
    ///     Has the last undone operation redone.
    /// </summary>
    /// <param name="undoRedoLevel">A level of undo, with contents.</param>
    /// <param name="toInvokeOutsideLock">An action to invoke outside of the lock.</param>
    /// <param name="state">The state object to pass to the invocation.</param>
    /// <returns><see langword="true" /> if the redo was successful, <see langword="false" /> otherwise.</returns>
    protected virtual bool RedoInternally(
        StateChangeBase undoRedoLevel,
        out Action<object?>? toInvokeOutsideLock,
        out object? state)
    {
        switch (undoRedoLevel)
        {
            case SubItemStateChange(var subItem, var stateChange):
                subItem.RedoStateChanges(stateChange);

                toInvokeOutsideLock = null;
                state = null;

                return true;
            case CompositeStateChange bsc:
            {
                var count = bsc.StateChanges.Count;

                if (count == 0)
                {
                    toInvokeOutsideLock = null;
                    state = null;

                    return true;
                }

                var actionsToInvoke = new Action<object?>[count];
                var states = new object[count];
                var counter = 0;
                var result = true;

                foreach (StateChangeBase sc in bsc.StateChanges)
                {
                    try
                    {
                        var localResult = RedoInternally(
                            sc,
                            out Action<object>? toInvoke,
                            out var toState);

                        if (!localResult)
                        {
                            result = false;
                        }
                        else
                        {
                            actionsToInvoke[counter] = toInvoke!;
                            states[counter] = toState!;
                        }
                    }
                    finally
                    {
                        counter++;
                    }
                }

                state = new Tuple<Action<object?>[], object[], ObservableCollectionBase<T>>(
                    actionsToInvoke,
                    states,
                    this);
                toInvokeOutsideLock = innerState =>
                {
                    if (innerState == null)
                    {
                        return;
                    }

                    (Action<object?>[]? actions, var objects, ObservableCollectionBase<T>? observableCollectionBase) =
                        (Tuple<Action<object?>[], object[], ObservableCollectionBase<T>>)innerState;

                    observableCollectionBase.InterpretBlockStateChangesOutsideLock(
                        actions,
                        objects);
                };

                return result;
            }
        }

        toInvokeOutsideLock = null;
        state = null;

        return false;
    }

    /// <summary>
    ///     Interprets the block state changes outside the write lock.
    /// </summary>
    /// <param name="actions">The actions to employ.</param>
    /// <param name="states">The state objects to send to the corresponding actions.</param>
    protected virtual void InterpretBlockStateChangesOutsideLock(
        Action<object?>?[] actions,
        object?[] states)
    {
        for (var i = 0; i < actions.Length; i++)
        {
            actions[i]?.Invoke(states[i]);
        }
    }

    /// <summary>
    ///     Push an undo level into the stack.
    /// </summary>
    /// <param name="undoRedoLevel">The undo level to push.</param>
    protected void PushUndoLevel(StateChangeBase undoRedoLevel)
    {
        if (_suppressUndoable || EnvironmentSettings.DisableUndoable || _historyLevels == 0)
        {
            return;
        }

        if (IsCapturedIntoUndoContext)
        {
            EditCommittedInternal?.Invoke(
                this,
                new(undoRedoLevel));

            _undoContext.Value.ClearRedoStack();

            RaisePropertyChanged(nameof(CanUndo));
            RaisePropertyChanged(nameof(CanRedo));
        }
        else if (_currentUndoBlockTransaction == null)
        {
            _undoContext.Value.PushUndo(undoRedoLevel);

            _undoContext.Value.ClearRedoStack();

            RaisePropertyChanged(nameof(CanUndo));
            RaisePropertyChanged(nameof(CanRedo));
        }
        else
        {
            _currentUndoBlockTransaction.StateChanges.StateChanges.Add(undoRedoLevel);
        }
    }

    /// <summary>
    ///     Called when an item is added to a collection.
    /// </summary>
    /// <param name="addedItem">The added item.</param>
    /// <param name="index">The index.</param>
    protected virtual void RaiseCollectionChangedAdd(
        T addedItem,
        int index) =>
        RaiseCollectionAdd(
            index,
            addedItem);

    /// <summary>
    ///     Called when an item in a collection is changed.
    /// </summary>
    /// <param name="oldItem">The old item.</param>
    /// <param name="newItem">The new item.</param>
    /// <param name="index">The index.</param>
    protected virtual void RaiseCollectionChangedChanged(
        T oldItem,
        T newItem,
        int index) =>
        RaiseCollectionReplace(
            index,
            oldItem,
            newItem);

    /// <summary>
    ///     Called when an item is removed from a collection.
    /// </summary>
    /// <param name="removedItem">The removed item.</param>
    /// <param name="index">The index.</param>
    protected virtual void RaiseCollectionChangedRemove(
        T removedItem,
        int index) =>
        RaiseCollectionRemove(
            index,
            removedItem);

    /// <summary>
    ///     Checks and automatically captures an item in a capturing transaction.
    /// </summary>
    /// <param name="item">The item to capture.</param>
    /// <returns>An auto-capture transaction context that reverts the capture if things go wrong.</returns>
    protected virtual OperationTransaction CheckItemAutoCapture(T item)
    {
        if (!AutomaticallyCaptureSubItems || !ItemsAreUndoable)
        {
            return new AutoCaptureTransactionContext();
        }

        if (item is IUndoableItem ui)
        {
            return new AutoCaptureTransactionContext(
                ui,
                this,
                Tei_EditCommitted);
        }

        return new AutoCaptureTransactionContext();
    }

    /// <summary>
    ///     Checks and automatically captures items in a capturing transaction.
    /// </summary>
    /// <param name="items">The items to capture.</param>
    /// <returns>An auto-capture transaction context that reverts the capture if things go wrong.</returns>
    protected virtual OperationTransaction CheckItemAutoCapture(IEnumerable<T> items)
    {
        if (AutomaticallyCaptureSubItems && ItemsAreUndoable)
        {
            return new AutoCaptureTransactionContext(
                items.Cast<IUndoableItem>(),
                this,
                Tei_EditCommitted);
        }

        return new AutoCaptureTransactionContext();
    }

    /// <summary>
    ///     Checks and automatically captures an item in a capturing transaction.
    /// </summary>
    /// <param name="item">The item to capture.</param>
    /// <returns>An auto-capture transaction context that reverts the capture if things go wrong.</returns>
    protected virtual OperationTransaction CheckItemAutoRelease(T item)
    {
        if (AutomaticallyCaptureSubItems && ItemsAreUndoable)
        {
            if (item is IUndoableItem ui)
            {
                return new AutoReleaseTransactionContext(
                    ui,
                    this,
                    Tei_EditCommitted);
            }
        }

        return new AutoReleaseTransactionContext();
    }

    /// <summary>
    ///     Checks and automatically captures items in a capturing transaction.
    /// </summary>
    /// <param name="items">The items to capture.</param>
    /// <returns>An auto-capture transaction context that reverts the capture if things go wrong.</returns>
    protected virtual OperationTransaction CheckItemAutoRelease(IEnumerable<T> items)
    {
        if (AutomaticallyCaptureSubItems && ItemsAreUndoable)
        {
            return new AutoReleaseTransactionContext(
                items.Cast<IUndoableItem>(),
                this,
                Tei_EditCommitted);
        }

        return new AutoReleaseTransactionContext();
    }

    /// <summary>
    ///     Removes all items from the <see cref="ObservableCollectionBase{T}" /> and returns them as an array.
    /// </summary>
    /// <returns>An array containing the original collection items.</returns>
    protected virtual T[] ClearInternal()
    {
        // PRECONDITIONS

        // Current object not disposed
        ThrowIfCurrentObjectDisposed();

        // ACTION
        T[] tempArray;

        // Under write lock
        using (AcquireWriteLock())
        {
            // Save existing items
            tempArray = new T[InternalContainer.Count];
            InternalContainer.CopyTo(
                tempArray,
                0);

            // Into an undo/redo transaction context
            using OperationTransaction tc = CheckItemAutoRelease(tempArray);

            // Do the actual clearing
            InternalContainer.Clear();

            // Push an undo level
            PushUndoLevel(new ClearStateChange<T>(tempArray));

            // Mark the transaction as a success
            tc.Success();
        }

        // NOTIFICATIONS

        // Collection changed
        RaiseCollectionReset();

        // Property changed
        RaisePropertyChanged(nameof(Count));

        // Contents may have changed
        ContentsMayHaveChanged();

        return tempArray;
    }

    private void Tei_EditCommitted(
        object? sender,
        EditCommittedEventArgs e) =>
        PushUndoLevel(
            new SubItemStateChange(
                Requires.ArgumentOfType<IUndoableItem>(sender),
                e.StateChanges));

    private UndoableInnerContext InnerContextFactory() =>
        new()
        {
            HistoryLevels = _historyLevels
        };

    [SuppressMessage(
        "Performance",
        "HAA0401:Possible allocation of reference type enumerator",
        Justification = "We're OK with this as we have to cast.")]
    private void SetAutomaticallyCaptureSubItems(
        bool value,
        bool lockAcquired)
    {
        _automaticallyCaptureSubItems = value;

        if (!ItemsAreUndoable)
        {
            return;
        }

        ValueSynchronizationLockerReadWrite? locker = lockAcquired ? null : AcquireReadWriteLock();

        if (value)
        {
            // At this point we start capturing
            try
            {
                if (InternalContainer.Count <= 0)
                {
                    return;
                }

                _ = locker?.Upgrade();

                foreach (T item in InternalContainer)
                {
                    if (item == null)
                    {
                        // Item may be null, let's move on to the next item
                        continue;
                    }

                    ((IUndoableItem)item).CaptureIntoUndoContext(this);
                }
            }
            finally
            {
                locker?.Dispose();
            }
        }
        else
        {
            // At this point we release the captures
            try
            {
                if (InternalContainer.Count <= 0)
                {
                    return;
                }

                _ = locker?.Upgrade();

                foreach (IUndoableItem item in InternalContainer.Cast<IUndoableItem>())
                {
                    item.ReleaseFromUndoContext();
                }
            }
            finally
            {
                locker?.Dispose();
            }
        }
    }
}