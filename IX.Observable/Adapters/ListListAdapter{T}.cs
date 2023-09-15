using System.Runtime.Serialization;

namespace IX.Observable.Adapters;

[CollectionDataContract(
    Namespace = Constants.DataContractNamespace,
    Name = "ListAdapterOf{0}",
    ItemName = "Item")]
internal class ListListAdapter<T> : ModernListAdapter<T, List<T>.Enumerator>
{
    private readonly List<T> _list;

    public ListListAdapter() => _list = new();

    public ListListAdapter(IEnumerable<T> source) => _list = new(source);

    public override int Count => _list.Count;

    public override bool IsReadOnly => false;

    public override T this[int index]
    {
        get => _list[index];
        set => _list[index] = value;
    }

    public override int Add(T item)
    {
        _list.Add(item);

        return _list.Count - 1;
    }

    public override int AddRange(IEnumerable<T> items)
    {
        var index = _list.Count;
        _list.AddRange(items);

        return index;
    }

    public override void Clear() => _list.Clear();

    public override bool Contains(T item) => _list.Contains(item);

    public override void CopyTo(
        T[] array,
        int arrayIndex) =>
        _list.CopyTo(
            array,
            arrayIndex);

    public override List<T>.Enumerator GetEnumerator() => _list.GetEnumerator();

    public override int IndexOf(T item) => _list.IndexOf(item);

    public override void Insert(
        int index,
        T item) =>
        _list.Insert(
            index,
            item);

    public override int Remove(T item)
    {
        var index = _list.IndexOf(item);
        _ = _list.Remove(item);

        return index;
    }

    public override void RemoveAt(int index) => _list.RemoveAt(index);
}