using IX.Library.Contracts;
using IX.Library.Threading;

using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace IX.Library.Collections;

/// <summary>
/// An automatically-updated collection of weak references that can be enumerated over.
/// </summary>
/// <typeparam name="T">The type of item to hold weak references to.</typeparam>
[PublicAPI]
public class WeakReferenceCollection<T> : ReaderWriterSynchronizedBase, ICollection<T>
where T : class
{
    private readonly List<WeakReference<T>> _references;
    private readonly bool _longWeakReferenceByDefault;

    /// <summary>
    /// Initializes a new instance of the <see cref="IX.Library.Collections.WeakReferenceCollection{T}"/> class.
    /// </summary>
    /// <remarks><para>By using this constructor, the collection is creating weak references by default.</para></remarks>
    public WeakReferenceCollection()
    : this(false)
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="IX.Library.Collections.WeakReferenceCollection{T}"/> class.
    /// </summary>
    /// <param name="longWeakReferenceByDefault"><c>true</c> to use long weak references, <c>false</c> to use short ones.</param>
    public WeakReferenceCollection(bool longWeakReferenceByDefault)
    {
        _references = new();
        _longWeakReferenceByDefault = longWeakReferenceByDefault;
    }

    /// <summary>Returns an enumerator that iterates through the collection.</summary>
    /// <returns>An enumerator that can be used to iterate through the collection.</returns>
    /// <remarks><para>The collection self-updates as it enumerates.</para>
    /// <para>Because of this, multiple enumerations, as well as the <see cref="Count"/> property, might have different results as to the number of items in this collection.</para></remarks>
    public IEnumerator<T> GetEnumerator()
    {
        for (var i = 0; i < Count; i++)
        {
            WeakReference<T> item;

            using (AcquireReadLock())
            {
                if (i >= _references.Count)
                    yield break;

                item = _references[i];
            }

            if (item.TryGetTarget(out var target))
                yield return target;
            else
            {
                using var locker = AcquireReadWriteLock();

                var newIndex = _references.IndexOf(item);

                if (newIndex >= 0)
                {
                    locker.Upgrade();

                    _references.RemoveAt(newIndex);
                    i = newIndex - 1;
                }
            }
        }
    }

    /// <summary>Returns an enumerator that iterates through a collection.</summary>
    /// <returns>An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.</returns>
    [SuppressMessage("Performance", "HAA0401:Possible allocation of reference type enumerator", Justification = "It's OK, we will be using a reference-type enumerator for this scenario.")]
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    /// <summary>Adds an item to the <see cref="IX.Library.Collections.WeakReferenceCollection{T}" />.</summary>
    /// <param name="item">The object to add to the <see cref="IX.Library.Collections.WeakReferenceCollection{T}" />.</param>
    public void Add(T item) => _ = AddWeakReference(Requires.NotNull(item));

    internal WeakReference<T> AddWeakReference(T item)
    {
        var weakReference = new WeakReference<T>(
            item,
            _longWeakReferenceByDefault);

        using (AcquireWriteLock())
            _references.Add(weakReference);

        return weakReference;
    }

    /// <summary>Removes all items from the <see cref="IX.Library.Collections.WeakReferenceCollection{T}" />.</summary>
    /// <exception cref="T:System.NotSupportedException">The <see cref="IX.Library.Collections.WeakReferenceCollection{T}" /> is read-only. </exception>
    public void Clear()
    {
        using (AcquireWriteLock())
            _references.Clear();
    }

    /// <summary>Determines whether the <see cref="IX.Library.Collections.WeakReferenceCollection{T}" /> contains a specific value.</summary>
    /// <param name="item">The object to locate in the <see cref="IX.Library.Collections.WeakReferenceCollection{T}" />.</param>
    /// <returns>true if <paramref name="item" /> is found in the <see cref="IX.Library.Collections.WeakReferenceCollection{T}" />; otherwise, false.</returns>
    [SuppressMessage("Performance", "HAA0301:Closure Allocation Source", Justification = "Acceptable.")]
    [SuppressMessage("Performance", "HAA0302:Display class allocation to capture closure", Justification = "Acceptable.")]
    public bool Contains(T item) => this.Any(p => p == item);

    /// <summary>Copies the elements of the <see cref="IX.Library.Collections.WeakReferenceCollection{T}" /> to an <see cref="T:System.Array" />, starting at a particular <see cref="T:System.Array" /> index.</summary>
    /// <param name="array">The one-dimensional <see cref="T:System.Array" /> that is the destination of the elements copied from <see cref="IX.Library.Collections.WeakReferenceCollection{T}" />. The <see cref="T:System.Array" /> must have zero-based indexing.</param>
    /// <param name="arrayIndex">The zero-based index in <paramref name="array" /> at which copying begins.</param>
    /// <exception cref="T:System.ArgumentNullException">
    /// <paramref name="array" /> is null.</exception>
    /// <exception cref="T:System.ArgumentOutOfRangeException">
    /// <paramref name="arrayIndex" /> is less than 0.</exception>
    /// <exception cref="T:System.ArgumentException">The number of elements in the source <see cref="IX.Library.Collections.WeakReferenceCollection{T}" /> is greater than the available space from <paramref name="arrayIndex" /> to the end of the destination <paramref name="array" />.</exception>
    public void CopyTo(
        T[] array,
        int arrayIndex)
    {
        Requires.ValidArrayIndex(in arrayIndex, array);

        LinkedList<T> purgedItemsList = new(this);

        Requires.ValidArrayRange(in arrayIndex, purgedItemsList.Count, array);

        purgedItemsList.CopyTo(array, arrayIndex);
    }

    /// <summary>Removes the first occurrence of a specific object from the <see cref="IX.Library.Collections.WeakReferenceCollection{T}" />.</summary>
    /// <param name="item">The object to remove from the <see cref="IX.Library.Collections.WeakReferenceCollection{T}" />.</param>
    /// <returns>true if <paramref name="item" /> was successfully removed from the <see cref="IX.Library.Collections.WeakReferenceCollection{T}" />; otherwise, false. This method also returns false if <paramref name="item" /> is not found in the original <see cref="IX.Library.Collections.WeakReferenceCollection{T}" />.</returns>
    public bool Remove(T item)
    {
        var localItem = Requires.NotNull(item);

        var toReturn = false;

        for (var i = 0; i < Count; i++)
        {
            WeakReference<T> weakReference;

            using (AcquireReadLock())
            {
                if (i >= _references.Count) break;

                weakReference = _references[i];
            }

            var found = false;

            if (weakReference.TryGetTarget(out var target) && !(found = target == localItem)) continue;

            if (found) toReturn = true;
            using var locker = AcquireReadWriteLock();

            var newIndex = _references.IndexOf(weakReference);

            if (newIndex >= 0)
            {
                locker.Upgrade();

                _references.RemoveAt(newIndex);
                i = newIndex - 1;
            }
        }

        return toReturn;
    }

    /// <summary>Gets the number of elements contained in the <see cref="IX.Library.Collections.WeakReferenceCollection{T}" />.</summary>
    /// <returns>The number of elements contained in the <see cref="IX.Library.Collections.WeakReferenceCollection{T}" />.</returns>
    /// <remarks>
    /// <para>This property does not update the collection. No already-broken weak references will be removed, so the count of the actually available items might differ.</para>
    /// <para>Use this property for evaluating the maximum possible </para>
    /// </remarks>
    public int Count =>
        ReadLock(
            weakReferences => weakReferences.Count,
            _references);

    /// <summary>Gets a value indicating whether the <see cref="IX.Library.Collections.WeakReferenceCollection{T}" /> is read-only.</summary>
    /// <returns>Always returns <c>false</c>.</returns>
    public bool IsReadOnly => false;
}