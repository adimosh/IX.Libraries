using IX.Undoable.StateChanges;

using System.Diagnostics.CodeAnalysis;

namespace IX.Undoable;

/// <summary>
///     A base class for editable items that can be edited in a transactional-style pattern.
/// </summary>
/// <seealso cref="ITransactionEditableItem" />
/// <seealso cref="IUndoableItem" />
[PublicAPI]
public abstract class EditableItemBase : ViewModelBase,
    ITransactionEditableItem,
    IUndoableItem
{
    private readonly List<StateChangeBase> _stateChanges;
    private readonly Lazy<UndoableInnerContext> _undoContext;

    private int _historyLevels;

    /// <summary>
    ///     Initializes a new instance of the <see cref="EditableItemBase" /> class.
    /// </summary>
    protected EditableItemBase()
        : this(0) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="EditableItemBase" /> class.
    /// </summary>
    /// <param name="limit">The limit.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="limit" /> is a negative number.</exception>
    [SuppressMessage(
        "Performance",
        "HAA0603:Delegate allocation from a method group",
        Justification = "Unavoidable.")]
    protected EditableItemBase(int limit)
    {
        Requires.NonNegative(
            out _historyLevels,
            in limit,
            nameof(limit));

        _undoContext = new(InnerContextFactory);
        _stateChanges = new();
    }

    /// <summary>
    ///     Occurs when an edit on this item is committed.
    /// </summary>
    public event EventHandler<EditCommittedEventArgs>? EditCommitted;

    /// <summary>
    ///     Gets a value indicating whether or not a redo can be performed on this item.
    /// </summary>
    /// <value>
    ///     <see langword="true" /> if the call to the <see cref="Redo" /> method would result in a state change,
    ///     <see langword="false" /> otherwise.
    /// </value>
    public bool CanRedo =>
        IsCapturedIntoUndoContext || (_undoContext.IsValueCreated && _undoContext.Value.RedoStackHasData);

    /// <summary>
    ///     Gets a value indicating whether or not an undo can be performed on this item.
    /// </summary>
    /// <value>
    ///     <see langword="true" /> if the call to the <see cref="Undo" /> method would result in a state change,
    ///     <see langword="false" /> otherwise.
    /// </value>
    public bool CanUndo =>
        IsCapturedIntoUndoContext || (_undoContext.IsValueCreated && _undoContext.Value.UndoStackHasData);

    /// <summary>
    ///     Gets a value indicating whether this instance is captured in undo context.
    /// </summary>
    /// <value><see langword="true" /> if this instance is captured in undo context; otherwise, <see langword="false" />.</value>
    public bool IsCapturedIntoUndoContext => ParentUndoContext != null;

    /// <summary>
    ///     Gets or sets the number of levels to keep undo or redo information.
    /// </summary>
    /// <value>The history levels.</value>
    /// <remarks>
    ///     <para>
    ///         If this value is set, for example, to 7, then the implementing object should allow the <see cref="Undo" />
    ///         method
    ///         to be called 7 times to change the state of the object. Upon calling it an 8th time, there should be no change
    ///         in the
    ///         state of the object.
    ///     </para>
    ///     <para>
    ///         Any call beyond the limit imposed here should not fail, but it should also not change the state of the
    ///         object.
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
    ///     Gets a value indicating whether this instance is in edit mode.
    /// </summary>
    /// <value><see langword="true" /> if this instance is in edit mode; otherwise, <see langword="false" />.</value>
    public bool IsInEditMode { get; private set; }

    /// <summary>
    ///     Gets the parent undo context.
    /// </summary>
    /// <value>The parent undo context.</value>
    public IUndoableItem? ParentUndoContext { get; private set; }

    /// <summary>
    ///     Begins the editing of an item.
    /// </summary>
    public void BeginEdit()
    {
        if (IsInEditMode)
        {
            return;
        }

        IsInEditMode = true;

        RaisePropertyChanged(nameof(IsInEditMode));
    }

    /// <summary>
    ///     Discards all changes to the item, reloading the state at the last commit or at the beginning of the edit
    ///     transaction, whichever occurred last.
    /// </summary>
    /// <exception cref="IX.Undoable.ItemNotInEditModeException">The item is not in edit mode.</exception>
    public void CancelEdit()
    {
        if (!IsInEditMode)
        {
            throw new ItemNotInEditModeException();
        }

        if (_stateChanges.Count <= 0)
        {
            return;
        }

        RevertChanges(
            _stateChanges.Count == 1 ? _stateChanges[0] : new CompositeStateChange(_stateChanges));

        _stateChanges.Clear();
    }

    /// <summary>
    ///     Commits the changes to the item as they are, without ending the editing.
    /// </summary>
    /// <exception cref="IX.Undoable.ItemNotInEditModeException">The item is not in edit mode.</exception>
    public void CommitEdit()
    {
        if (!IsInEditMode)
        {
            throw new ItemNotInEditModeException();
        }

        if (_stateChanges.Count <= 0)
        {
            return;
        }

        CommitEditInternal(_stateChanges.ToArray());

        _stateChanges.Clear();
    }

    /// <summary>
    ///     Ends the editing of an item.
    /// </summary>
    /// <exception cref="IX.Undoable.ItemNotInEditModeException">The item is not in edit mode.</exception>
    public void EndEdit()
    {
        if (!IsInEditMode)
        {
            throw new ItemNotInEditModeException();
        }

        if (_stateChanges.Count > 0)
        {
            CommitEditInternal(_stateChanges.ToArray());

            _stateChanges.Clear();
        }

        IsInEditMode = false;

        RaisePropertyChanged(nameof(IsInEditMode));
    }

    /// <summary>
    ///     Allows the item to be captured by a containing undo-/redo-capable object so that undo and redo operations
    ///     can be coordinated across a larger scope.
    /// </summary>
    /// <param name="parent">The parent undo and redo context.</param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="parent" /> is <see langword="null" /> (
    ///     <see langword="Nothing" /> in Visual Basic).
    /// </exception>
    /// <exception cref="IX.Undoable.ItemIsInEditModeException">
    ///     The item is in edit mode, and this operation cannot be
    ///     performed at this time.
    /// </exception>
    /// <remarks>This method is meant to be used by containers, and should not be called directly.</remarks>
    public void CaptureIntoUndoContext(IUndoableItem parent)
    {
        _ = Requires.NotNull(
            parent,
            nameof(parent));

        if (parent == ParentUndoContext)
        {
            return;
        }

        if (IsInEditMode)
        {
            throw new ItemIsInEditModeException();
        }

        // Set the parent undo context
        ParentUndoContext = parent;
        if (_undoContext.IsValueCreated)
        {
            // We already have an undo inner context, let's clear it out.
            // If we don't have an undo inner context, no sense in clearing it out just yet.
            _undoContext.Value.HistoryLevels = 0;
        }

        RaisePropertyChanged(nameof(IsCapturedIntoUndoContext));
    }

    /// <summary>
    ///     Has the last undone operation performed on this item, presuming that it has not changed since then, redone.
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
        if (ParentUndoContext != null)
        {
            // We are captured by a parent context, let's invoke that context's Redo.
            ParentUndoContext.Redo();

            return;
        }

        // We are not captured, let's proceed with Undo.

        // Let's check whether or not we have an undo inner context first
        if (!_undoContext.IsValueCreated)
        {
            // Undo inner context not created, there's nothing to undo
            return;
        }

        // Undo context created, let's try to undo
        UndoableInnerContext uc = _undoContext.Value;
        if (!uc.RedoStackHasData)
        {
            // We don't have anything to Redo.
            return;
        }

        StateChangeBase redoData = uc.PopRedo();
        uc.PushUndo(redoData);
        DoChanges(redoData);

        RaisePropertyChanged(nameof(CanUndo));
        RaisePropertyChanged(nameof(CanRedo));
    }

    /// <summary>
    ///     Has the state changes received redone into the object.
    /// </summary>
    /// <param name="changesToRedo">The state changes to redo.</param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="changesToRedo" /> is <see langword="null" /> (
    ///     <see langword="Nothing" /> in Visual Basic).
    /// </exception>
    /// <exception cref="ItemNotCapturedIntoUndoContextException">
    ///     The item is not captured into an undo/redo context, and this
    ///     operation is illegal.
    /// </exception>
    public void RedoStateChanges(StateChangeBase changesToRedo)
    {
        _ = Requires.NotNull(
            changesToRedo,
            nameof(changesToRedo));

        if (!IsCapturedIntoUndoContext)
        {
            throw new ItemNotCapturedIntoUndoContextException();
        }

        DoChanges(changesToRedo);
    }

    /// <summary>
    ///     Releases the item from being captured into an undo and redo context.
    /// </summary>
    /// <remarks>This method is meant to be used by containers, and should not be called directly.</remarks>
    public void ReleaseFromUndoContext()
    {
        if (ParentUndoContext == null)
        {
            return;
        }

        // Set parent undo context as null
        ParentUndoContext = null;

        if (_undoContext.IsValueCreated)
        {
            // We already have an undo inner context, let's set it back.
            // If we don't have an undo inner context, no sense in setting anything.
            _undoContext.Value.HistoryLevels = _historyLevels;
        }

        RaisePropertyChanged(nameof(IsCapturedIntoUndoContext));
    }

    /// <summary>
    ///     Has the last operation performed on the item undone.
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
        if (ParentUndoContext != null)
        {
            // We are captured by a parent context, let's invoke that context's Undo.
            ParentUndoContext.Undo();

            return;
        }

        // We are not captured, let's proceed with Undo.

        // Let's check whether or not we have an undo inner context first
        if (!_undoContext.IsValueCreated)
        {
            // Undo inner context not created, there's nothing to undo
            return;
        }

        // Undo context created, let's try to undo
        UndoableInnerContext uc = _undoContext.Value;
        if (!uc.UndoStackHasData)
        {
            // We don't have anything to Undo.
            return;
        }

        StateChangeBase undoData = uc.PopUndo();
        uc.PushRedo(undoData);
        RevertChanges(undoData);

        RaisePropertyChanged(nameof(CanUndo));
        RaisePropertyChanged(nameof(CanRedo));
    }

    /// <summary>
    ///     Has the state changes received undone from the object.
    /// </summary>
    /// <param name="changesToUndo">The state changes to undo.</param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="changesToUndo" /> is <see langword="null" /> (
    ///     <see langword="Nothing" /> in Visual Basic).
    /// </exception>
    /// <exception cref="ItemNotCapturedIntoUndoContextException">
    ///     The item is not captured into an undo/redo context, and this
    ///     operation is illegal.
    /// </exception>
    public void UndoStateChanges(StateChangeBase changesToUndo)
    {
        _ = Requires.NotNull(
            changesToUndo,
            nameof(changesToUndo));

        if (!IsCapturedIntoUndoContext)
        {
            throw new ItemNotCapturedIntoUndoContextException();
        }

        RevertChanges(changesToUndo);
    }

    /// <summary>
    ///     Disposes in the managed context.
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
    ///     Captures a sub item into the present context.
    /// </summary>
    /// <typeparam name="TSubItem">The type of the sub item.</typeparam>
    /// <param name="item">The item.</param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="item" />
    ///     is <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    /// <remarks>
    ///     This method is intended to capture only objects that are directly sub-objects that can have their own internal
    ///     state and undo/redo
    ///     capabilities and are also transactional in nature when being edited. Using this method on any other object may
    ///     yield unwanted
    ///     commits.
    /// </remarks>
    protected void CaptureSubItemIntoPresentContext<TSubItem>(TSubItem item)
        where TSubItem : IUndoableItem, IEditCommittableItem
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        item.CaptureIntoUndoContext(this);

        item.EditCommitted += Item_EditCommitted;
    }

    /// <summary>
    ///     Releases the sub item from present context.
    /// </summary>
    /// <typeparam name="TSubItem">The type of the sub item.</typeparam>
    /// <param name="item">The item.</param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="item" />
    ///     is <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    protected void ReleaseSubItemFromPresentContext<TSubItem>(TSubItem item)
        where TSubItem : IUndoableItem, IEditCommittableItem
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        item.EditCommitted -= Item_EditCommitted;

        item.ReleaseFromUndoContext();
    }

    /// <summary>
    ///     Can be called to advertise a change of state in an implementing class.
    /// </summary>
    /// <param name="stateChange">The state change to advertise.</param>
    protected void AdvertiseStateChange(StateChangeBase stateChange)
    {
        if (IsInEditMode)
        {
            _stateChanges.Add(stateChange);
        }
        else
        {
            CommitEditInternal(
                new[]
                {
                    stateChange
                });
        }
    }

    /// <summary>
    ///     Advertises a property change.
    /// </summary>
    /// <typeparam name="T">The type of the property.</typeparam>
    /// <param name="propertyName">Name of the property.</param>
    /// <param name="oldValue">The old value.</param>
    /// <param name="newValue">The new value.</param>
    protected void AdvertisePropertyChange<T>(
        string propertyName,
        T oldValue,
        T newValue) =>
        AdvertiseStateChange(
            new PropertyStateChange<T>(
                propertyName,
                oldValue,
                newValue));

    /// <summary>
    ///     Called when a list of state changes are canceled and must be reverted.
    /// </summary>
    /// <param name="stateChanges">The state changes to revert.</param>
    protected abstract void RevertChanges(StateChangeBase stateChanges);

    /// <summary>
    ///     Called when a list of state changes must be executed.
    /// </summary>
    /// <param name="stateChanges">The state changes to execute.</param>
    protected abstract void DoChanges(StateChangeBase stateChanges);

    /// <summary>
    ///     Handles the EditCommitted event of the sub-item.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EditCommittedEventArgs" /> instance containing the event data.</param>
    private void Item_EditCommitted(
        object? sender,
        EditCommittedEventArgs e)
    {
        if (sender is null)
        {
            return;
        }

        _stateChanges.Add(
            new SubItemStateChange(
                (IUndoableItem)sender,
                e.StateChanges));

        CommitEditInternal(_stateChanges.ToArray());
    }

    /// <summary>
    ///     Commits the edit internally.
    /// </summary>
    /// <param name="changesToCommit">The state changes.</param>
    private void CommitEditInternal(StateChangeBase[] changesToCommit)
    {
        if (changesToCommit.Length == 0)
        {
            return;
        }

        StateChangeBase stateChangeBase = changesToCommit.Length == 1
            ? changesToCommit[0]
            : new CompositeStateChange(changesToCommit.ToList());

        if (ParentUndoContext == null && _historyLevels > 0)
        {
            _undoContext.Value.PushUndo(stateChangeBase);
            _undoContext.Value.ClearRedoStack();
        }

        RaisePropertyChanged(nameof(CanUndo));
        RaisePropertyChanged(nameof(CanRedo));

        EditCommitted?.Invoke(
            this,
            new(stateChangeBase));
    }

    private UndoableInnerContext InnerContextFactory() =>
        new()
        {
            HistoryLevels = _historyLevels
        };
}