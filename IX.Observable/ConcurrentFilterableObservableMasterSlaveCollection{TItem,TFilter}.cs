using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using IX.Observable.DebugAide;
using ReaderWriterLockSlim = IX.Library.Threading.ReaderWriterLockSlim;

namespace IX.Observable;

/// <summary>
///     An observable collection created from a master collection (to which updates go) and many slave, read-only
///     collections, whose items can also be filtered.
/// </summary>
/// <typeparam name="TItem">The type of the item.</typeparam>
/// <typeparam name="TFilter">The type of the filter.</typeparam>
/// <seealso cref="IX.Observable.ObservableMasterSlaveCollection{T}" />
[DebuggerDisplay("Count = {" + nameof(Count) + "}")]
[DebuggerTypeProxy(typeof(CollectionDebugView<>))]
[PublicAPI]
public class ConcurrentFilterableObservableMasterSlaveCollection<TItem, TFilter> :
    ConcurrentObservableMasterSlaveCollection<TItem>
{
    private IList<TItem>? _cachedFilteredElements;

    private IReaderWriterLock _cacheLocker;

    private TFilter? _filter;

    /// <summary>
    ///     Initializes a new instance of the
    ///     <see cref="ConcurrentFilterableObservableMasterSlaveCollection{TItem, TFilter}" /> class.
    /// </summary>
    /// <param name="filteringPredicate">The filtering predicate.</param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="filteringPredicate" /> is <see langword="null" /> (
    ///     <see langword="Nothing" />) in Visual Basic.
    /// </exception>
    public ConcurrentFilterableObservableMasterSlaveCollection(Func<TItem, TFilter, bool> filteringPredicate)
    {
        FilteringPredicate = Requires.NotNull(filteringPredicate);
        _cacheLocker = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);
    }

    /// <summary>
    ///     Initializes a new instance of the
    ///     <see cref="ConcurrentFilterableObservableMasterSlaveCollection{TItem, TFilter}" /> class.
    /// </summary>
    /// <param name="filteringPredicate">The filtering predicate.</param>
    /// <param name="context">The synchronization context to use, if any.</param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="filteringPredicate" /> is <see langword="null" /> (
    ///     <see langword="Nothing" />) in Visual Basic.
    /// </exception>
    public ConcurrentFilterableObservableMasterSlaveCollection(
        Func<TItem, TFilter, bool> filteringPredicate,
        SynchronizationContext context)
        : base(context)
    {
        FilteringPredicate = Requires.NotNull(filteringPredicate);
        _cacheLocker = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);
    }

    /// <summary>
    ///     Initializes a new instance of the
    ///     <see cref="ConcurrentFilterableObservableMasterSlaveCollection{TItem, TFilter}" /> class.
    /// </summary>
    /// <param name="filteringPredicate">The filtering predicate.</param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="filteringPredicate" /> is <see langword="null" /> (
    ///     <see langword="Nothing" />) in Visual Basic.
    /// </exception>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ConcurrentFilterableObservableMasterSlaveCollection(
        Func<TItem, TFilter, bool> filteringPredicate,
        bool suppressUndoable)
        : base(suppressUndoable)
    {
        FilteringPredicate = Requires.NotNull(filteringPredicate);
        _cacheLocker = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);
    }

    /// <summary>
    ///     Initializes a new instance of the
    ///     <see cref="ConcurrentFilterableObservableMasterSlaveCollection{TItem, TFilter}" /> class.
    /// </summary>
    /// <param name="filteringPredicate">The filtering predicate.</param>
    /// <param name="context">The synchronization context to use, if any.</param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="filteringPredicate" /> is <see langword="null" /> (
    ///     <see langword="Nothing" />) in Visual Basic.
    /// </exception>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ConcurrentFilterableObservableMasterSlaveCollection(
        Func<TItem, TFilter, bool> filteringPredicate,
        SynchronizationContext context,
        bool suppressUndoable)
        : base(
            context,
            suppressUndoable)
    {
        FilteringPredicate = Requires.NotNull(filteringPredicate);
        _cacheLocker = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);
    }

    /// <summary>
    ///     Gets the number of items in the collection.
    /// </summary>
    /// <value>
    ///     The item count.
    /// </value>
    public override int Count =>
        IsFilter()
            ? CheckAndCache()
                .Count
            : base.Count;

    /// <summary>
    ///     Gets the filtering predicate.
    /// </summary>
    /// <value>
    ///     The filtering predicate.
    /// </value>
    public Func<TItem, TFilter, bool> FilteringPredicate { get; }

    /// <summary>
    ///     Gets or sets the filter value.
    /// </summary>
    /// <value>
    ///     The filter value.
    /// </value>
    public TFilter? Filter
    {
        get => _filter;
        set
        {
            _filter = value;

            ClearCachedContents();

            RaiseCollectionReset();
            RaisePropertyChanged(nameof(Count));
            RaisePropertyChanged(Constants.ItemsName);
        }
    }

    /// <summary>
    ///     Returns an enumerator that iterates through the collection.
    /// </summary>
    /// <returns>
    ///     An enumerator that can be used to iterate through the collection.
    /// </returns>
    [SuppressMessage(
        "Performance",
        "HAA0401:Possible allocation of reference type enumerator",
        Justification = "We have to allocate an atomic enumerator.")]
    public override IEnumerator<TItem> GetEnumerator() =>
        IsFilter()
            ? CheckAndCache()
                .GetEnumerator()
            : base.GetEnumerator();

    /// <summary>
    ///     Disposes the managed context.
    /// </summary>
    protected override void DisposeManagedContext()
    {
        base.DisposeManagedContext();

        Interlocked.Exchange(
                ref _cacheLocker,
                null!)
            ?.Dispose();
    }

    /// <summary>
    ///     Called when an item is added to a collection.
    /// </summary>
    /// <param name="addedItem">The added item.</param>
    /// <param name="index">The index.</param>
    protected override void RaiseCollectionChangedAdd(
        TItem addedItem,
        int index)
    {
        if (IsFilter())
        {
            RaiseCollectionReset();
        }
        else
        {
            base.RaiseCollectionChangedAdd(
                addedItem,
                index);
        }
    }

    /// <summary>
    ///     Called when an item in a collection is changed.
    /// </summary>
    /// <param name="oldItem">The old item.</param>
    /// <param name="newItem">The new item.</param>
    /// <param name="index">The index.</param>
    protected override void RaiseCollectionChangedChanged(
        TItem oldItem,
        TItem newItem,
        int index)
    {
        if (IsFilter())
        {
            RaiseCollectionReset();
        }
        else
        {
            base.RaiseCollectionChangedChanged(
                oldItem,
                newItem,
                index);
        }
    }

    /// <summary>
    ///     Called when an item is removed from a collection.
    /// </summary>
    /// <param name="removedItem">The removed item.</param>
    /// <param name="index">The index.</param>
    protected override void RaiseCollectionChangedRemove(
        TItem removedItem,
        int index)
    {
        if (IsFilter())
        {
            RaiseCollectionReset();
        }
        else
        {
            base.RaiseCollectionChangedRemove(
                removedItem,
                index);
        }
    }

    [SuppressMessage(
        "Performance",
        "HAA0401:Possible allocation of reference type enumerator",
        Justification = "We have to allocate an atomic enumerator.")]
    private IEnumerator<TItem> EnumerateFiltered()
    {
        TFilter? internalFilter = Filter;

        using IEnumerator<TItem> enumerator = base.GetEnumerator();

        if (internalFilter is null)
        {
            while (enumerator.MoveNext())
            {
                yield return enumerator.Current;
            }
        }
        else
        {
            while (enumerator.MoveNext())
            {
                TItem current = enumerator.Current;
                if (FilteringPredicate(
                        current,
                        internalFilter))
                {
                    yield return current;
                }
            }
        }
    }

    [SuppressMessage(
        "Performance",
        "HAA0401:Possible allocation of reference type enumerator",
        Justification = "We have to allocate an atomic enumerator.")]
    private IList<TItem> CheckAndCache()
    {
        using var locker = new ValueSynchronizationLockerReadWrite(_cacheLocker);

        if (_cachedFilteredElements != null)
        {
            return _cachedFilteredElements;
        }

        _ = locker.Upgrade();

        _cachedFilteredElements = new List<TItem>(InternalListContainer.Count);

        using IEnumerator<TItem> enumerator = EnumerateFiltered();

        while (enumerator.MoveNext())
        {
            TItem current = enumerator.Current;
            _cachedFilteredElements.Add(current);
        }

        return _cachedFilteredElements;
    }

    private void ClearCachedContents()
    {
        using var synchronizationLocker = new ValueSynchronizationLockerWrite(_cacheLocker);

        if (_cachedFilteredElements == null)
        {
            return;
        }

        IList<TItem> coll = _cachedFilteredElements;
        _cachedFilteredElements = null;
        coll.Clear();
    }

    private bool IsFilter() =>
        Filter is not null &&
        !EqualityComparer<TFilter>.Default.Equals(
            Filter,
            default!);
}