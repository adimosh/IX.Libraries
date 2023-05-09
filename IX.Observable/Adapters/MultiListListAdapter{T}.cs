using IX.Core.Collections;

using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;

namespace IX.Observable.Adapters;

#pragma warning disable HAA0401 // Possible allocation of reference type enumerator - Unavoidable right now
internal class MultiListListAdapter<T> : ModernListAdapter<T, IEnumerator<T>>
{
    private readonly List<IEnumerable<T>> _lists;

    internal MultiListListAdapter() => _lists = new();

    public override int Count => _lists.Sum(p => p.Count());

    public override bool IsReadOnly => true;

    public int SlavesCount => _lists.Count;

    public override T this[int index]
    {
        get
        {
            var idx = index;

            foreach (IEnumerable<T> list in _lists)
            {
                var count = list.Count();
                if (count > idx)
                {
                    return list.ElementAt(idx);
                }

                idx -= count;
            }

            throw new IndexOutOfRangeException();
        }

        set => throw new InvalidOperationException();
    }

    public override int Add(T item) => throw new InvalidOperationException();

    public override int AddRange(IEnumerable<T> items) => throw new InvalidOperationException();

    public override void Clear() => throw new InvalidOperationException();

    public override bool Contains(T item) =>
        _lists.Any(
            (
                p,
                itemL1) => p.Contains(itemL1),
            item);

    public override void CopyTo(
        T[] array,
        int arrayIndex)
    {
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

    public override IEnumerator<T> GetEnumerator()
    {
        foreach (IEnumerable<T> lst in _lists)
        {
            foreach (T var in lst)
            {
                yield return var;
            }
        }
    }

    public override int Remove(T item) => throw new InvalidOperationException();

    public override void Insert(
        int index,
        T item) =>
        throw new InvalidOperationException();

    public override int IndexOf(T item)
    {
        var offset = 0;

        foreach (List<T> list in _lists.Select(p => p.ToList()))
        {
            int foundIndex;
            if ((foundIndex = list.IndexOf(item)) != -1)
            {
                return foundIndex + offset;
            }

            offset += list.Count;
        }

        return -1;
    }

    public override void RemoveAt(int index) => throw new InvalidOperationException();

    internal void SetList<TList>(TList list)
        where TList : class, IEnumerable<T>, INotifyCollectionChanged
    {
        _lists.Add(list ?? throw new ArgumentNullException(nameof(list)));
        list.CollectionChanged += List_CollectionChanged;
    }

    [SuppressMessage(
        "ReSharper",
        "EmptyGeneralCatchClause",
        Justification = "This is of no consequence.")]
    internal void RemoveList<TList>(TList list)
        where TList : class, IEnumerable<T>, INotifyCollectionChanged
    {
        try
        {
            list.CollectionChanged -= List_CollectionChanged;
        }
        catch
        {
        }

        _ = _lists.Remove(list ?? throw new ArgumentNullException(nameof(list)));
    }

    private void List_CollectionChanged(
        object? sender,
        NotifyCollectionChangedEventArgs e) =>
        TriggerReset();
}
#pragma warning restore HAA0401 // Possible allocation of reference type enumerator