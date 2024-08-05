using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace IX.Library.Debugging;

/// <summary>
///     A debugging view for collections. This class cannot be inherited.
/// </summary>
/// <typeparam name="T">The type of the item contained in the collection.</typeparam>
[ComVisible(false)]
public sealed class CollectionDebugView<T>
{
    private readonly ICollection<T> _collection;

    /// <summary>
    ///     Initializes a new instance of the <see cref="CollectionDebugView{T}" /> class.
    /// </summary>
    /// <param name="collection">The collection.</param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="collection" />
    ///     is <see langword="null" /> (<see langword="Nothing" /> in Visual Studio).
    /// </exception>
    public CollectionDebugView(ICollection<T> collection) =>
        _collection = collection ?? throw new ArgumentNullException(nameof(collection));

    /// <summary>
    ///     Gets the items.
    /// </summary>
    /// <value>The items.</value>
    [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
    [SuppressMessage(
        "Performance",
        "CA1819:Properties should not return arrays",
        Justification = "This is supposed to be like this.")]
    public T[] Items
    {
        get
        {
            var items = new T[_collection.Count];
            _collection.CopyTo(
                items,
                0);

            return items;
        }
    }
}