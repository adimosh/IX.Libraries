using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace IX.Observable.DebugAide;

/// <summary>
///     A debug view class for an observable collection.
/// </summary>
/// <typeparam name="T">The type of the collection.</typeparam>
[ExcludeFromCodeCoverage]
public sealed class CollectionDebugView<T>
{
    private readonly ObservableCollectionBase<T> _collection;

    /// <summary>
    ///     Initializes a new instance of the <see cref="CollectionDebugView{T}" /> class.
    /// </summary>
    /// <param name="collection">The collection.</param>
    /// <exception cref="ArgumentNullException">collection is null.</exception>
    public CollectionDebugView(ObservableCollectionBase<T> collection) =>
        _collection = collection ?? throw new ArgumentNullException(nameof(collection));

    /// <summary>
    ///     Gets the items.
    /// </summary>
    /// <value>
    ///     The items.
    /// </value>
    [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
    public T[] Items
    {
        get
        {
            var items = new T[_collection.InternalContainer.Count];
            _collection.InternalContainer.CopyTo(
                items,
                0);

            return items;
        }
    }
}