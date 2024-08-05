using IX.Library.Collections;
using IX.Library.OperationModel;
using IX.Undoable;

namespace IX.Observable;

/// <summary>
/// An auto-capture-releasing class that captures in a transaction.
/// </summary>
/// <seealso cref="OperationTransaction" />
internal class AutoReleaseTransactionContext : OperationTransaction
{
    private readonly EventHandler<EditCommittedEventArgs>? _editableHandler;
    private readonly IUndoableItem? _item;
    private readonly IUndoableItem[]? _items;
    private readonly IUndoableItem? _parentContext;

    /// <summary>
    ///     Initializes a new instance of the <see cref="AutoReleaseTransactionContext" /> class.
    /// </summary>
    public AutoReleaseTransactionContext() => Success();

    /// <summary>
    ///     Initializes a new instance of the <see cref="AutoReleaseTransactionContext" /> class.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <param name="parentContext">The parent context.</param>
    /// <param name="editableHandler">The editable handler.</param>
    public AutoReleaseTransactionContext(
        IUndoableItem item,
        IUndoableItem parentContext,
        EventHandler<EditCommittedEventArgs> editableHandler)
    {
        // Contract validation
        _item = item ?? throw new ArgumentNullException(nameof(item));
        _parentContext = parentContext ?? throw new ArgumentNullException(nameof(parentContext));
        _editableHandler = editableHandler ?? throw new ArgumentNullException(nameof(editableHandler));

        // Data validation
        if (!item.IsCapturedIntoUndoContext || item.ParentUndoContext != parentContext)
        {
            throw new ItemNotCapturedIntoUndoContextException();
        }

        // State
        _items = null;

        item.ReleaseFromUndoContext();

        if (item is IEditCommittableItem tei)
        {
            tei.EditCommitted -= editableHandler;
        }

        AddFailure();
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="AutoReleaseTransactionContext" /> class.
    /// </summary>
    /// <param name="items">The items.</param>
    /// <param name="parentContext">The parent context.</param>
    /// <param name="editableHandler">The editable handler.</param>
    public AutoReleaseTransactionContext(
        IEnumerable<IUndoableItem> items,
        IUndoableItem parentContext,
        EventHandler<EditCommittedEventArgs> editableHandler)
    {
        // Contract validation
        if (items is null) throw new ArgumentNullException(nameof(items));
        _parentContext = parentContext ?? throw new ArgumentNullException(nameof(parentContext));
        _editableHandler = editableHandler ?? throw new ArgumentNullException(nameof(editableHandler));

        // Data validation
        // Multiple enumeration warning: this has to be done, as there is no efficient way to do a transactional capturing otherwise
        IUndoableItem[] itemsArray = items.ToArray();
        if (itemsArray.Any(
                (
                    undoableItem,
                    pc) => !undoableItem.IsCapturedIntoUndoContext || undoableItem.ParentUndoContext != pc,
                parentContext))
        {
            throw new ItemNotCapturedIntoUndoContextException();
        }

        // State
        _items = itemsArray;
        _item = null;

        foreach (IUndoableItem undoableItem in itemsArray)
        {
            undoableItem.ReleaseFromUndoContext();

            if (undoableItem is IEditCommittableItem tei)
            {
                tei.EditCommitted -= editableHandler;
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
                var thisL1 = (AutoReleaseTransactionContext)state;

                if (thisL1._item != null)
                {
                    if (thisL1._parentContext is not null) thisL1._item.CaptureIntoUndoContext(thisL1._parentContext);

                    if (thisL1._item is IEditCommittableItem tei)
                    {
                        tei.EditCommitted += thisL1._editableHandler;
                    }
                }

                if (thisL1._items == null)
                {
                    return;
                }

                foreach (IUndoableItem undoableItem in thisL1._items)
                {
                    if (thisL1._parentContext is not null) undoableItem.CaptureIntoUndoContext(thisL1._parentContext);

                    if (thisL1._item is IEditCommittableItem tei)
                    {
                        tei.EditCommitted += thisL1._editableHandler;
                    }
                }
            },
            this);
}