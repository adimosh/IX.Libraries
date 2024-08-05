using IX.Library.Collections;
using IX.Undoable.StateChanges;

using System.Diagnostics.CodeAnalysis;

namespace IX.Undoable;

/// <summary>
///     The inner context of an undoable object. This class should not normally be used, instead, use
///     <see cref="EditableItemBase" />.
/// </summary>
public class UndoableInnerContext : NotifyPropertyChangedBase
{
    private int _historyLevels;
    private Lazy<PushDownStack<StateChangeBase>>? _redoStack;
    private Lazy<PushDownStack<StateChangeBase>>? _undoStack;

    /// <summary>
    ///     Gets a value indicating whether the redo stack has data.
    /// </summary>
    public bool RedoStackHasData => (_redoStack?.IsValueCreated ?? false) && _redoStack.Value.Count > 0;

    /// <summary>
    ///     Gets a value indicating whether the undo stack has data.
    /// </summary>
    public bool UndoStackHasData => (_undoStack?.IsValueCreated ?? false) && _undoStack.Value.Count > 0;

    /// <summary>
    ///     Gets or sets the number of levels to keep undo or redo information.
    /// </summary>
    /// <value>The history levels.</value>
    /// <remarks>
    ///     <para>
    ///         If this value is set, for example, to 7, then the implementing object should allow undo methods
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
            if (value < 0)
            {
                value = 0;
            }

            lock (this)
            {
                // This lock is here to ensure that no multiple threads can set different history levels, no mater what.
                // It is a write-only lock, so no need for expensive lockers
                if (_historyLevels == value)
                {
                    return;
                }

                _historyLevels = value;

                ProcessHistoryLevelsChange();
            }

            RaisePropertyChanged(nameof(HistoryLevels));
        }
    }

    /// <summary>
    ///     Clears the redo stack.
    /// </summary>
    public void ClearRedoStack()
    {
        if (_redoStack?.IsValueCreated ?? false)
        {
            _redoStack.Value.Clear();
        }
    }

    /// <summary>
    ///     Clears the undo stack.
    /// </summary>
    public void ClearUndoStack()
    {
        if (_undoStack?.IsValueCreated ?? false)
        {
            _undoStack.Value.Clear();
        }
    }

    /// <summary>
    ///     Pushes one state change on the redo stack.
    /// </summary>
    /// <returns>A state change.</returns>
    public StateChangeBase PopRedo() =>
        (_redoStack?.Value ?? throw new InvalidOperationException(Resources.NoHistoryLevelsException)).Pop();

    /// <summary>
    ///     Pushes one state change on the undo stack.
    /// </summary>
    /// <returns>A state change.</returns>
    public StateChangeBase PopUndo() =>
        (_undoStack?.Value ?? throw new InvalidOperationException(Resources.NoHistoryLevelsException)).Pop();

    /// <summary>
    ///     Pushes one state change on the redo stack.
    /// </summary>
    /// <param name="stateChange">A state change to push.</param>
    public void PushRedo(StateChangeBase stateChange) =>
        (_redoStack?.Value ?? throw new InvalidOperationException(Resources.NoHistoryLevelsException)).Push(
            stateChange);

    /// <summary>
    ///     Pushes one state change on the undo stack.
    /// </summary>
    /// <param name="stateChange">A state change to push.</param>
    public void PushUndo(StateChangeBase stateChange) =>
        (_undoStack?.Value ?? throw new InvalidOperationException(Resources.NoHistoryLevelsException)).Push(
            stateChange);

    /// <summary>Disposes in the managed context.</summary>
    protected override void DisposeManagedContext()
    {
        base.DisposeManagedContext();

        // Setting history levels to 0 will automatically dispose the undo/redo stacks
        HistoryLevels = 0;
    }

    [SuppressMessage(
        "Performance",
        "HAA0603:Delegate allocation from a method group",
        Justification = "Unavoidable.")]
    private void ProcessHistoryLevelsChange()
    {
        // WARNING !!! Always execute this method within a lock
        if (_historyLevels == 0)
        {
            // Undo stack
            Lazy<PushDownStack<StateChangeBase>>? stack = _undoStack;

            if (stack != null)
            {
                _undoStack = null;

                if (stack.IsValueCreated)
                {
                    stack.Value.Clear();
                    stack.Value.Dispose();
                }
            }

            // Redo stack
            stack = _redoStack;
            if (stack != null)
            {
                _redoStack = null;

                if (stack.IsValueCreated)
                {
                    stack.Value.Clear();
                    stack.Value.Dispose();
                }
            }
        }
        else
        {
            if (_undoStack != null && _redoStack != null)
            {
                // Both stacks are not null at this point
                // If any of them is initialized, we should change its size limit
                if (_undoStack.IsValueCreated)
                {
                    _undoStack.Value.Limit = _historyLevels;
                }

                if (_redoStack.IsValueCreated)
                {
                    _redoStack.Value.Limit = _historyLevels;
                }
            }
            else
            {
                // Both stacks are null at this point, or need to be otherwise reinitialized

                // Let's check for whether stacks need to be disposed
                if (_undoStack?.IsValueCreated ?? false)
                {
                    _undoStack.Value.Dispose();
                }

                if (_redoStack?.IsValueCreated ?? false)
                {
                    _redoStack.Value.Dispose();
                }

                // Do proper stack initialization
                _undoStack = new(GenerateStack);
                _redoStack = new(GenerateStack);
            }
        }
    }

    private PushDownStack<StateChangeBase> GenerateStack()
    {
        if (_historyLevels == 0)
        {
            throw new InvalidOperationException(Resources.NoHistoryLevelsException);
        }

        return new(_historyLevels);
    }
}