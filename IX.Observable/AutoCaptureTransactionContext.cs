using IX.Library.Collections;
using IX.Library.OperationModel;
using IX.Undoable;

namespace IX.Observable;

/// <summary>
///     An auto-capturing class that captures in a transaction.
/// </summary>
/// <seealso cref="OperationTransaction" />
internal class AutoCaptureTransactionContext : OperationTransaction
{
    private readonly EventHandler<EditCommittedEventArgs>? _editableHandler;
    private readonly IUndoableItem? _item;
    private readonly IUndoableItem[]? _items;

    /// <summary>
    ///     Initializes a new instance of the <see cref="AutoCaptureTransactionContext" /> class.
    /// </summary>
    public AutoCaptureTransactionContext() => Success();

    /// <summary>
    ///     Initializes a new instance of the <see cref="AutoCaptureTransactionContext" /> class.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <param name="parentContext">The parent context.</param>
    /// <param name="editableHandler">The editable handler.</param>
    public AutoCaptureTransactionContext(
        IUndoableItem item,
        IUndoableItem parentContext,
        EventHandler<EditCommittedEventArgs> editableHandler)
    {
        // Contract validation
        _item = item ?? throw new ArgumentNullException(nameof(item));
        _editableHandler = editableHandler ?? throw new ArgumentNullException(nameof(editableHandler));
        if (parentContext is null) throw new ArgumentNullException(nameof(parentContext));

        // Data validation
        if (item.IsCapturedIntoUndoContext && item.ParentUndoContext != parentContext)
        {
            throw new ItemAlreadyCapturedIntoUndoContextException();
        }

        // State
        _items = null;

        item.CaptureIntoUndoContext(parentContext);

        if (item is IEditCommittableItem tei)
        {
            tei.EditCommitted += editableHandler;
        }

        AddFailure();
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="AutoCaptureTransactionContext" /> class.
    /// </summary>
    /// <param name="items">The items.</param>
    /// <param name="parentContext">The parent context.</param>
    /// <param name="editableHandler">The editable handler.</param>
    public AutoCaptureTransactionContext(
        IEnumerable<IUndoableItem> items,
        IUndoableItem parentContext,
        EventHandler<EditCommittedEventArgs> editableHandler)
    {
        // Contract validation
        _editableHandler = editableHandler ?? throw new ArgumentNullException(nameof(editableHandler));
        if (items is null) throw new ArgumentNullException(nameof(items));
        if (parentContext is null) throw new ArgumentNullException(nameof(parentContext));

        // Data validation
        // Multiple enumeration warning: this has to be done, as there is no efficient way to do a transactional capturing otherwise
        IUndoableItem[] itemsArray = items.ToArray();
        if (itemsArray.Any(
                (
                    internalItem,
                    pc) => internalItem.IsCapturedIntoUndoContext && internalItem.ParentUndoContext != pc,
                parentContext))
        {
            throw new ItemAlreadyCapturedIntoUndoContextException();
        }

        // State
        _items = itemsArray;
        _item = null;

        foreach (IUndoableItem undoableItem in itemsArray)
        {
            undoableItem.CaptureIntoUndoContext(parentContext);

            if (undoableItem is IEditCommittableItem tei)
            {
                tei.EditCommitted += editableHandler;
            }
        }

        AddFailure();
    }

    /// <summary>
    ///     Gets invoked when the transaction commits and is successful.
    /// </summary>
    protected override void WhenSuccessful() { }

    private void AddFailure() =>
        AddRevertStep(
            state =>
            {
                var thisL1 = (AutoCaptureTransactionContext)state;
                if (thisL1._item != null)
                {
                    thisL1._item.ReleaseFromUndoContext();

                    if (thisL1._item is IEditCommittableItem tei)
                    {
                        tei.EditCommitted -= thisL1._editableHandler;
                    }
                }

                if (thisL1._items == null)
                {
                    return;
                }

                foreach (IUndoableItem undoableItem in thisL1._items)
                {
                    undoableItem.ReleaseFromUndoContext();

                    if (thisL1._item is IEditCommittableItem tei)
                    {
                        tei.EditCommitted -= thisL1._editableHandler;
                    }
                }
            },
            this);
}