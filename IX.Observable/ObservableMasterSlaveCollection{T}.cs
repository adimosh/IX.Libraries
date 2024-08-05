using System.Collections;
using System.Collections.Specialized;
using System.Diagnostics;
using IX.Observable.Adapters;
using IX.Observable.DebugAide;
using IX.Observable.StateChanges;

namespace IX.Observable;

/// <summary>
///     An observable collection created from a master collection (to which updates go) and many slave, read-only
///     collections.
/// </summary>
/// <typeparam name="T">The type of the item.</typeparam>
/// <seealso cref="IX.Observable.ObservableListBase{T}" />
/// <seealso cref="IList{T}" />
/// <seealso cref="IReadOnlyCollection{T}" />
/// <seealso cref="ICollection{T}" />
/// <seealso cref="ICollection" />
/// <seealso cref="IList" />
/// <seealso cref="Observable.ObservableCollectionBase{TItem}" />
[DebuggerDisplay("ObservableMasterSlaveCollection, Count = {" + nameof(Count) + "}")]
[DebuggerTypeProxy(typeof(CollectionDebugView<>))]
public class ObservableMasterSlaveCollection<T> : ObservableListBase<T>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableMasterSlaveCollection{T}" /> class.
    /// </summary>
    public ObservableMasterSlaveCollection()
        : base(new MultiListPrimarySecondaryListAdapter<T>()) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableMasterSlaveCollection{T}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context to use, if any.</param>
    public ObservableMasterSlaveCollection(SynchronizationContext context)
        : base(
            new MultiListPrimarySecondaryListAdapter<T>(),
            context) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableMasterSlaveCollection{T}" /> class.
    /// </summary>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ObservableMasterSlaveCollection(bool suppressUndoable)
        : base(
            new MultiListPrimarySecondaryListAdapter<T>(),
            suppressUndoable) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableMasterSlaveCollection{T}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context to use, if any.</param>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ObservableMasterSlaveCollection(
        SynchronizationContext context,
        bool suppressUndoable)
        : base(
            new MultiListPrimarySecondaryListAdapter<T>(),
            context,
            suppressUndoable) { }

    /// <summary>
    ///     Gets the count after an add operation. Used internally.
    /// </summary>
    /// <value>
    ///     The count after add.
    /// </value>
    protected override int CountAfterAdd =>
        ((MultiListPrimarySecondaryListAdapter<T>)InternalListContainer).MasterCount;

    /// <summary>
    ///     Sets the master list.
    /// </summary>
    /// <typeparam name="TList">The type of the list.</typeparam>
    /// <param name="list">The list.</param>
    public void SetMasterList<TList>(TList list)
        where TList : class, IList<T>, INotifyCollectionChanged
    {
        ThrowIfCurrentObjectDisposed();

        using (AcquireWriteLock())
        {
            ((MultiListPrimarySecondaryListAdapter<T>)InternalListContainer).SetMaster(list);
        }

        RaiseCollectionReset();
        RaisePropertyChanged(nameof(Count));
        RaisePropertyChanged(Constants.ItemsName);
    }

    /// <summary>
    ///     Sets a slave list.
    /// </summary>
    /// <typeparam name="TList">The type of the list.</typeparam>
    /// <param name="list">The list.</param>
    public void SetSlaveList<TList>(TList list)
        where TList : class, IEnumerable<T>, INotifyCollectionChanged
    {
        ThrowIfCurrentObjectDisposed();

        using (AcquireWriteLock())
        {
            ((MultiListPrimarySecondaryListAdapter<T>)InternalListContainer).SetSlave(list);
        }

        RaiseCollectionReset();
        RaisePropertyChanged(nameof(Count));
        RaisePropertyChanged(Constants.ItemsName);
    }

    /// <summary>
    ///     Removes a slave list.
    /// </summary>
    /// <typeparam name="TList">The type of the list.</typeparam>
    /// <param name="list">The list.</param>
    public void RemoveSlaveList<TList>(TList list)
        where TList : class, IEnumerable<T>, INotifyCollectionChanged
    {
        ThrowIfCurrentObjectDisposed();

        using (AcquireWriteLock())
        {
            ((MultiListPrimarySecondaryListAdapter<T>)InternalListContainer).RemoveSlave(list);
        }

        RaiseCollectionReset();
        RaisePropertyChanged(nameof(Count));
        RaisePropertyChanged(Constants.ItemsName);
    }

    /// <summary>
    ///     Adds an item to the <see cref="T:IX.Observable.ObservableCollectionBase`1" />.
    /// </summary>
    /// <param name="item">The object to add to the <see cref="T:IX.Observable.ObservableCollectionBase`1" />.</param>
    /// <remarks>On concurrent collections, this method is write-synchronized.</remarks>
    public override void Add(T item)
    {
        IncreaseIgnoreMustResetCounter();
        base.Add(item);
    }

    /// <summary>
    ///     Inserts an item at the specified index.
    /// </summary>
    /// <param name="index">The index at which to insert.</param>
    /// <param name="item">The item.</param>
    public override void Insert(
        int index,
        T item)
    {
        IncreaseIgnoreMustResetCounter();
        base.Insert(
            index,
            item);
    }

    /// <summary>
    ///     Removes the first occurrence of a specific object from the
    ///     <see cref="T:IX.Observable.ObservableCollectionBase`1" />.
    /// </summary>
    /// <param name="item">The object to remove from the <see cref="T:IX.Observable.ObservableCollectionBase`1" />.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="item" /> was successfully removed from the
    ///     <see cref="T:IX.Observable.ObservableCollectionBase`1" />; otherwise, <see langword="false" />.
    ///     This method also returns false if <paramref name="item" /> is not found in the original
    ///     <see cref="T:IX.Observable.ObservableCollectionBase`1" />.
    /// </returns>
    /// <remarks>On concurrent collections, this method is write-synchronized.</remarks>
    public override bool Remove(T item)
    {
        IncreaseIgnoreMustResetCounter();
        if (base.Remove(item))
        {
            return true;
        }

        IncreaseIgnoreMustResetCounter(-1);

        return false;
    }

    /// <summary>
    ///     Removes an item at the specified index.
    /// </summary>
    /// <param name="index">The index at which to remove an item from.</param>
    public override void RemoveAt(int index)
    {
        ThrowIfCurrentObjectDisposed();

        T item;

        using (var lockContext = AcquireReadWriteLock())
        {
            if (index >= InternalListContainer.Count)
            {
                return;
            }

            lockContext.Upgrade();

            item = InternalListContainer[index];
            IncreaseIgnoreMustResetCounter();
            InternalListContainer.RemoveAt(index);

            PushUndoLevel(
                new RemoveStateChange<T>(
                    index,
                    item));
        }

        RaiseCollectionChangedRemove(
            item,
            index);
        RaisePropertyChanged(nameof(Count));
        ContentsMayHaveChanged();
    }

    /// <summary>
    ///     Removes all items from the <see cref="ObservableMasterSlaveCollection{T}" />.
    /// </summary>
    /// <returns>An array containing the original collection items.</returns>
    /// <remarks>On concurrent collections, this method is write-synchronized.</remarks>
    protected override T[] ClearInternal()
    {
        ThrowIfCurrentObjectDisposed();

        T[] originalArray;

        using (AcquireWriteLock())
        {
            var container = (MultiListPrimarySecondaryListAdapter<T>)InternalListContainer;

            IncreaseIgnoreMustResetCounter(container.SlavesCount + 1);

            originalArray = new T[container.MasterCount];
            container.MasterCopyTo(
                originalArray,
                0);

            InternalListContainer.Clear();

            PushUndoLevel(new ClearStateChange<T>(originalArray));
        }

        RaiseCollectionReset();
        RaisePropertyChanged(nameof(Count));
        ContentsMayHaveChanged();

        return originalArray;
    }

    /// <summary>
    ///     Called when the contents may have changed so that proper notifications can happen.
    /// </summary>
    protected override void ContentsMayHaveChanged() => RaisePropertyChanged(Constants.ItemsName);
}