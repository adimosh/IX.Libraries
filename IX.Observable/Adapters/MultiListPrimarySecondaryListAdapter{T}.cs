using IX.Library.Collections;

using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;

namespace IX.Observable.Adapters;

internal class MultiListPrimarySecondaryListAdapter<T> : ModernListAdapter<T, IEnumerator<T>>
{
    private readonly List<IEnumerable<T>> _secondaryLists;
    private IList<T>? _primaryList;

    internal MultiListPrimarySecondaryListAdapter() => _secondaryLists = [];

    public override int Count
    {
        get
        {
            _primaryList ??= new ObservableList<T>();

            return _primaryList.Count + _secondaryLists.Sum(p => p.Count());
        }
    }

    public override bool IsReadOnly
    {
        get
        {
            _primaryList ??= new ObservableList<T>();

            return _primaryList.IsReadOnly;
        }
    }

    public int SlavesCount => _secondaryLists.Count;

    internal int MasterCount
    {
        get
        {
            _primaryList ??= new ObservableList<T>();

            return _primaryList.Count;
        }
    }

    [SuppressMessage(
        "ReSharper",
        "PossibleMultipleEnumeration",
        Justification = "Appears unavoidable at this time.")]
    public override T this[int index]
    {
        get
        {
            _primaryList ??= new ObservableList<T>();

            if (index < _primaryList.Count)
            {
                return _primaryList[index];
            }

            var idx = index - _primaryList.Count;

            foreach (IEnumerable<T> slave in _secondaryLists)
            {
                var count = slave.Count();
                if (count > idx)
                {
                    return slave.ElementAt(idx);
                }

                idx -= count;
            }

            throw new IndexOutOfRangeException();
        }

        set
        {
            _primaryList ??= new ObservableList<T>();

            _primaryList[index] = value;
        }
    }

    public override int Add(T item)
    {
        _primaryList ??= new ObservableList<T>();

        _primaryList.Add(item);

        return MasterCount - 1;
    }

    public override int AddRange(IEnumerable<T> items)
    {
        _primaryList ??= new ObservableList<T>();

        var index = _primaryList.Count;
        items.ForEach(
            (
                p,
                masterL1) => masterL1.Add(p),
            _primaryList);

        return index;
    }

    public override void Clear()
    {
        _primaryList ??= new ObservableList<T>();

        _primaryList.Clear();
    }

    public override bool Contains(T item)
    {
        _primaryList ??= new ObservableList<T>();

        return _primaryList.Contains(item) ||
               _secondaryLists.Any(
                   (
                       p,
                       itemL1) => p.Contains(itemL1),
                   item);
    }

    public void MasterCopyTo(
        T[] array,
        int arrayIndex)
    {
        _primaryList ??= new ObservableList<T>();

        _primaryList.CopyTo(
            array,
            arrayIndex);
    }

    [SuppressMessage(
        "Performance",
        "HAA0401:Possible allocation of reference type enumerator",
        Justification = "We can't avoid this here.")]
    public override void CopyTo(
        T[] array,
        int arrayIndex)
    {
        _primaryList ??= new ObservableList<T>();

        var totalCount = Count + arrayIndex;
        using IEnumerator<T> enumerator = GetEnumerator();
        for (var i = arrayIndex; i < totalCount; i++)
        {
            if (!enumerator.MoveNext())
            {
                break;
            }

            array[i] = enumerator.Current;
        }
    }

    [SuppressMessage(
        "Performance",
        "HAA0401:Possible allocation of reference type enumerator",
        Justification = "We can't avoid this here.")]
    public override IEnumerator<T> GetEnumerator()
    {
        _primaryList ??= new ObservableList<T>();

        foreach (T var in _primaryList)
        {
            yield return var;
        }

        foreach (IEnumerable<T> lst in _secondaryLists)
        {
            foreach (T var in lst)
            {
                yield return var;
            }
        }
    }

    public override int Remove(T item)
    {
        _primaryList ??= new ObservableList<T>();

        var index = _primaryList.IndexOf(item);

        _ = _primaryList.Remove(item);

        return index;
    }

    public override void Insert(
        int index,
        T item)
    {
        _primaryList ??= new ObservableList<T>();

        _primaryList.Insert(
            index,
            item);
    }

    [SuppressMessage(
        "Performance",
        "HAA0401:Possible allocation of reference type enumerator",
        Justification = "We can't avoid this here.")]
    public override int IndexOf(T item)
    {
        _primaryList ??= new ObservableList<T>();

        var offset = 0;

        int foundIndex;
        if ((foundIndex = _primaryList.IndexOf(item)) != -1)
        {
            return foundIndex;
        }

        offset += _primaryList.Count;

        foreach (List<T> slave in _secondaryLists.Select(p => p.ToList()))
        {
            if ((foundIndex = slave.IndexOf(item)) != -1)
            {
                return foundIndex + offset;
            }

            offset += slave.Count;
        }

        return -1;
    }

    /// <summary>
    ///     Removes an item at a specific index.
    /// </summary>
    /// <param name="index">The index at which to remove from.</param>
    public override void RemoveAt(int index)
    {
        _primaryList ??= new ObservableList<T>();

        _primaryList.RemoveAt(index);
    }

    internal void SetMaster<TList>(TList masterList)
        where TList : class, IList<T>, INotifyCollectionChanged
    {
        TList newMaster = Requires.NotNull(masterList);
        IList<T>? oldMaster = _primaryList;

        if (oldMaster != null)
        {
            try
            {
                ((INotifyCollectionChanged)oldMaster).CollectionChanged -= List_CollectionChanged;
            }
            catch
            {
                // We need to do nothing here. Inability to remove the event delegate reference is of no consequence.
            }
        }

        _primaryList = newMaster;
        masterList.CollectionChanged += List_CollectionChanged;
    }

    internal void SetSlave<TList>(TList slaveList)
        where TList : class, IEnumerable<T>, INotifyCollectionChanged
    {
        _secondaryLists.Add(Requires.NotNull(slaveList));
        slaveList.CollectionChanged += List_CollectionChanged;
    }

    internal void RemoveSlave<TList>(TList slaveList)
        where TList : class, IEnumerable<T>, INotifyCollectionChanged
    {
        var localSlaveList = Requires.NotNull(
            slaveList);

        try
        {
            localSlaveList.CollectionChanged -= List_CollectionChanged;
        }
        catch
        {
            // We need to do nothing here. Inability to remove the event delegate reference is of no consequence.
        }

        _ = _secondaryLists.Remove(localSlaveList);
    }

    private void List_CollectionChanged(
        object? sender,
        NotifyCollectionChangedEventArgs e) =>
        TriggerReset();
}