using IX.Library.OperationModel;
using IX.Undoable.StateChanges;

namespace IX.Observable;

internal class UndoableUnitBlockTransaction<T> : OperationTransaction
{
    private readonly ObservableCollectionBase<T> _collectionBase;

    internal UndoableUnitBlockTransaction(ObservableCollectionBase<T> collectionBase)
    {
        _ = Requires.NotNull(collectionBase);

        _collectionBase = collectionBase;

        AddRevertStep(
            state => { ((ObservableCollectionBase<T>)state).FailExplicitUndoBlockTransaction(); },
            collectionBase);

        StateChanges = new(new());
    }

    internal CompositeStateChange StateChanges { get; }

    protected override void WhenSuccessful() => _collectionBase.FinishExplicitUndoBlockTransaction();
}