using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using IX.Observable.Adapters;
using IX.Observable.DebugAide;
using IX.Observable.StateChanges;
using IX.Undoable.StateChanges;

namespace IX.Observable;

/// <summary>
///     A dictionary that broadcasts its changes.
/// </summary>
/// <typeparam name="TKey">The data key type.</typeparam>
/// <typeparam name="TValue">The data value type.</typeparam>
[DebuggerDisplay("ObservableDictionary, Count = {" + nameof(Count) + "}")]
[DebuggerTypeProxy(typeof(DictionaryDebugView<,>))]
[CollectionDataContract(
    Namespace = Constants.DataContractNamespace,
    Name = "Observable{1}DictionaryBy{0}",
    ItemName = "Entry",
    KeyName = "Key",
    ValueName = "Value")]
[PublicAPI]
public class ObservableDictionary<TKey, TValue> : ObservableCollectionBase<KeyValuePair<TKey, TValue>>,
    IDictionary<TKey, TValue>,
    IReadOnlyDictionary<TKey, TValue>
    where TKey : notnull
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableDictionary{TKey, TValue}" /> class.
    /// </summary>
    public ObservableDictionary()
        : base(new DictionaryCollectionAdapter<TKey, TValue>()) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableDictionary{TKey, TValue}" /> class.
    /// </summary>
    /// <param name="capacity">The initial capacity of the dictionary.</param>
    public ObservableDictionary(int capacity)
        : base(new DictionaryCollectionAdapter<TKey, TValue>(new Dictionary<TKey, TValue>(capacity))) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableDictionary{TKey, TValue}" /> class.
    /// </summary>
    /// <param name="equalityComparer">A comparer object to use for equality comparison.</param>
    public ObservableDictionary(IEqualityComparer<TKey> equalityComparer)
        : base(new DictionaryCollectionAdapter<TKey, TValue>(new Dictionary<TKey, TValue>(equalityComparer))) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableDictionary{TKey, TValue}" /> class.
    /// </summary>
    /// <param name="capacity">The initial capacity of the dictionary.</param>
    /// <param name="equalityComparer">A comparer object to use for equality comparison.</param>
    public ObservableDictionary(
        int capacity,
        IEqualityComparer<TKey> equalityComparer)
        : base(
            new DictionaryCollectionAdapter<TKey, TValue>(
                new Dictionary<TKey, TValue>(
                    capacity,
                    equalityComparer))) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableDictionary{TKey, TValue}" /> class.
    /// </summary>
    /// <param name="dictionary">A dictionary of items to copy from.</param>
    public ObservableDictionary(IDictionary<TKey, TValue> dictionary)
        : base(new DictionaryCollectionAdapter<TKey, TValue>(new Dictionary<TKey, TValue>(dictionary))) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableDictionary{TKey, TValue}" /> class.
    /// </summary>
    /// <param name="dictionary">A dictionary of items to copy from.</param>
    /// <param name="comparer">A comparer object to use for equality comparison.</param>
    public ObservableDictionary(
        IDictionary<TKey, TValue> dictionary,
        IEqualityComparer<TKey> comparer)
        : base(
            new DictionaryCollectionAdapter<TKey, TValue>(
                new Dictionary<TKey, TValue>(
                    dictionary,
                    comparer))) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableDictionary{TKey, TValue}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context top use when posting observable messages.</param>
    public ObservableDictionary(SynchronizationContext context)
        : base(
            new DictionaryCollectionAdapter<TKey, TValue>(),
            context) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableDictionary{TKey, TValue}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context top use when posting observable messages.</param>
    /// <param name="capacity">The initial capacity of the dictionary.</param>
    public ObservableDictionary(
        SynchronizationContext context,
        int capacity)
        : base(
            new DictionaryCollectionAdapter<TKey, TValue>(new Dictionary<TKey, TValue>(capacity)),
            context) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableDictionary{TKey, TValue}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context top use when posting observable messages.</param>
    /// <param name="equalityComparer">A comparer object to use for equality comparison.</param>
    public ObservableDictionary(
        SynchronizationContext context,
        IEqualityComparer<TKey> equalityComparer)
        : base(
            new DictionaryCollectionAdapter<TKey, TValue>(new Dictionary<TKey, TValue>(equalityComparer)),
            context) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableDictionary{TKey, TValue}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context top use when posting observable messages.</param>
    /// <param name="capacity">The initial capacity of the dictionary.</param>
    /// <param name="equalityComparer">A comparer object to use for equality comparison.</param>
    public ObservableDictionary(
        SynchronizationContext context,
        int capacity,
        IEqualityComparer<TKey> equalityComparer)
        : base(
            new DictionaryCollectionAdapter<TKey, TValue>(
                new Dictionary<TKey, TValue>(
                    capacity,
                    equalityComparer)),
            context) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableDictionary{TKey, TValue}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context top use when posting observable messages.</param>
    /// <param name="dictionary">A dictionary of items to copy from.</param>
    public ObservableDictionary(
        SynchronizationContext context,
        IDictionary<TKey, TValue> dictionary)
        : base(
            new DictionaryCollectionAdapter<TKey, TValue>(new Dictionary<TKey, TValue>(dictionary)),
            context) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableDictionary{TKey, TValue}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context top use when posting observable messages.</param>
    /// <param name="dictionary">A dictionary of items to copy from.</param>
    /// <param name="comparer">A comparer object to use for equality comparison.</param>
    public ObservableDictionary(
        SynchronizationContext context,
        IDictionary<TKey, TValue> dictionary,
        IEqualityComparer<TKey> comparer)
        : base(
            new DictionaryCollectionAdapter<TKey, TValue>(
                new Dictionary<TKey, TValue>(
                    dictionary,
                    comparer)),
            context) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableDictionary{TKey, TValue}" /> class.
    /// </summary>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ObservableDictionary(bool suppressUndoable)
        : base(
            new DictionaryCollectionAdapter<TKey, TValue>(),
            suppressUndoable) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableDictionary{TKey, TValue}" /> class.
    /// </summary>
    /// <param name="capacity">The initial capacity of the dictionary.</param>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ObservableDictionary(
        int capacity,
        bool suppressUndoable)
        : base(
            new DictionaryCollectionAdapter<TKey, TValue>(new Dictionary<TKey, TValue>(capacity)),
            suppressUndoable) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableDictionary{TKey, TValue}" /> class.
    /// </summary>
    /// <param name="equalityComparer">A comparer object to use for equality comparison.</param>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ObservableDictionary(
        IEqualityComparer<TKey> equalityComparer,
        bool suppressUndoable)
        : base(
            new DictionaryCollectionAdapter<TKey, TValue>(new Dictionary<TKey, TValue>(equalityComparer)),
            suppressUndoable) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableDictionary{TKey, TValue}" /> class.
    /// </summary>
    /// <param name="capacity">The initial capacity of the dictionary.</param>
    /// <param name="equalityComparer">A comparer object to use for equality comparison.</param>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ObservableDictionary(
        int capacity,
        IEqualityComparer<TKey> equalityComparer,
        bool suppressUndoable)
        : base(
            new DictionaryCollectionAdapter<TKey, TValue>(
                new Dictionary<TKey, TValue>(
                    capacity,
                    equalityComparer)),
            suppressUndoable) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableDictionary{TKey, TValue}" /> class.
    /// </summary>
    /// <param name="dictionary">A dictionary of items to copy from.</param>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ObservableDictionary(
        IDictionary<TKey, TValue> dictionary,
        bool suppressUndoable)
        : base(
            new DictionaryCollectionAdapter<TKey, TValue>(new Dictionary<TKey, TValue>(dictionary)),
            suppressUndoable) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableDictionary{TKey, TValue}" /> class.
    /// </summary>
    /// <param name="dictionary">A dictionary of items to copy from.</param>
    /// <param name="comparer">A comparer object to use for equality comparison.</param>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ObservableDictionary(
        IDictionary<TKey, TValue> dictionary,
        IEqualityComparer<TKey> comparer,
        bool suppressUndoable)
        : base(
            new DictionaryCollectionAdapter<TKey, TValue>(
                new Dictionary<TKey, TValue>(
                    dictionary,
                    comparer)),
            suppressUndoable) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableDictionary{TKey, TValue}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context top use when posting observable messages.</param>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ObservableDictionary(
        SynchronizationContext context,
        bool suppressUndoable)
        : base(
            new DictionaryCollectionAdapter<TKey, TValue>(),
            context,
            suppressUndoable) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableDictionary{TKey, TValue}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context top use when posting observable messages.</param>
    /// <param name="capacity">The initial capacity of the dictionary.</param>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ObservableDictionary(
        SynchronizationContext context,
        int capacity,
        bool suppressUndoable)
        : base(
            new DictionaryCollectionAdapter<TKey, TValue>(new Dictionary<TKey, TValue>(capacity)),
            context,
            suppressUndoable) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableDictionary{TKey, TValue}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context top use when posting observable messages.</param>
    /// <param name="equalityComparer">A comparer object to use for equality comparison.</param>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ObservableDictionary(
        SynchronizationContext context,
        IEqualityComparer<TKey> equalityComparer,
        bool suppressUndoable)
        : base(
            new DictionaryCollectionAdapter<TKey, TValue>(new Dictionary<TKey, TValue>(equalityComparer)),
            context,
            suppressUndoable) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableDictionary{TKey, TValue}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context top use when posting observable messages.</param>
    /// <param name="capacity">The initial capacity of the dictionary.</param>
    /// <param name="equalityComparer">A comparer object to use for equality comparison.</param>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ObservableDictionary(
        SynchronizationContext context,
        int capacity,
        IEqualityComparer<TKey> equalityComparer,
        bool suppressUndoable)
        : base(
            new DictionaryCollectionAdapter<TKey, TValue>(
                new Dictionary<TKey, TValue>(
                    capacity,
                    equalityComparer)),
            context,
            suppressUndoable) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableDictionary{TKey, TValue}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context top use when posting observable messages.</param>
    /// <param name="dictionary">A dictionary of items to copy from.</param>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ObservableDictionary(
        SynchronizationContext context,
        IDictionary<TKey, TValue> dictionary,
        bool suppressUndoable)
        : base(
            new DictionaryCollectionAdapter<TKey, TValue>(new Dictionary<TKey, TValue>(dictionary)),
            context,
            suppressUndoable) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableDictionary{TKey, TValue}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context top use when posting observable messages.</param>
    /// <param name="dictionary">A dictionary of items to copy from.</param>
    /// <param name="comparer">A comparer object to use for equality comparison.</param>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ObservableDictionary(
        SynchronizationContext context,
        IDictionary<TKey, TValue> dictionary,
        IEqualityComparer<TKey> comparer,
        bool suppressUndoable)
        : base(
            new DictionaryCollectionAdapter<TKey, TValue>(
                new Dictionary<TKey, TValue>(
                    dictionary,
                    comparer)),
            context,
            suppressUndoable) { }

    /// <summary>
    ///     Gets the collection of keys in this dictionary.
    /// </summary>
    public ICollection<TKey> Keys
    {
        get
        {
            this.RequiresNotDisposed();

            using (AcquireReadLock())
            {
                return InternalContainer.Keys;
            }
        }
    }

    /// <summary>
    ///     Gets the collection of values in this dictionary.
    /// </summary>
    public ICollection<TValue> Values
    {
        get
        {
            this.RequiresNotDisposed();

            using (AcquireReadLock())
            {
                return InternalContainer.Values;
            }
        }
    }

    /// <summary>
    ///     Gets the collection of keys in this dictionary.
    /// </summary>
    IEnumerable<TKey> IReadOnlyDictionary<TKey, TValue>.Keys => Keys;

    /// <summary>
    ///     Gets the collection of values in this dictionary.
    /// </summary>
    IEnumerable<TValue> IReadOnlyDictionary<TKey, TValue>.Values => Values;

    /// <summary>
    ///     Gets the internal object container.
    /// </summary>
    /// <value>The internal container.</value>
    protected internal new IDictionaryCollectionAdapter<TKey, TValue> InternalContainer =>
        (DictionaryCollectionAdapter<TKey, TValue>)base.InternalContainer;

    /// <summary>
    ///     Gets or sets the value associated with a specific key.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <returns>The value associated with the specified key.</returns>
    public TValue this[TKey key]
    {
        get
        {
            this.RequiresNotDisposed();

            using (AcquireReadLock())
            {
                return InternalContainer[key];
            }
        }

        set
        {
            // PRECONDITIONS

            // Current object not disposed
            this.RequiresNotDisposed();

            // ACTION
            IDictionary<TKey, TValue> dictionary = InternalContainer;

            // Within a write lock
            using (AcquireWriteLock())
            {
                if (dictionary.TryGetValue(
                        key,
                        out TValue? val))
                {
                    // Set the new item
                    dictionary[key] = value;

                    // Push a change undo level
                    PushUndoLevel(
                        new DictionaryChangeStateChange<TKey, TValue>(
                            key,
                            value,
                            val));
                }
                else
                {
                    // Add the new item
                    dictionary.Add(
                        key,
                        value);

                    // Push an add undo level
                    PushUndoLevel(
                        new DictionaryAddStateChange<TKey, TValue>(
                            key,
                            value));
                }
            }

            // NOTIFICATION
            BroadcastChange();
        }
    }

    /// <summary>
    ///     Adds an item to the dictionary.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="value">The value.</param>
    public void Add(
        TKey key,
        TValue value)
    {
        // PRECONDITIONS

        // Current object not disposed
        this.RequiresNotDisposed();

        // ACTION

        // Under write lock
        using (AcquireWriteLock())
        {
            // Add the item
            var newIndex = InternalContainer.Add(
                key,
                value);

            // Push the undo level
            PushUndoLevel(
                new AddStateChange<KeyValuePair<TKey, TValue>>(
                    new(
                        key,
                        value),
                    newIndex));
        }

        // NOTIFICATIONS
        BroadcastChange();
    }

    /// <summary>
    ///     Determines whether the dictionary contains a specific key.
    /// </summary>
    /// <param name="key">The key to look for.</param>
    /// <returns><see langword="true" /> whether a key has been found, <see langword="false" /> otherwise.</returns>
    public bool ContainsKey(TKey key)
    {
        this.RequiresNotDisposed();

        using (AcquireReadLock())
        {
            return InternalContainer.ContainsKey(key);
        }
    }

    /// <summary>
    ///     Attempts to remove all info related to a key from the dictionary.
    /// </summary>
    /// <param name="key">The key to remove data from.</param>
    /// <returns><see langword="true" /> if the removal was successful, <see langword="false" /> otherwise.</returns>
    public bool Remove(TKey key)
    {
        // PRECONDITIONS

        // Current object not disposed
        this.RequiresNotDisposed();

        // ACTION
        bool result;
        IDictionaryCollectionAdapter<TKey, TValue> container = InternalContainer;

        // Within a read/write lock
        using (var locker = AcquireReadWriteLock())
        {
            // Find out if there's anything to remove
            if (!container.TryGetValue(
                    key,
                    out TValue? value))
            {
                return false;
            }

            // Upgrade the locker to a write lock
            _ = locker.Upgrade();

            // Do the actual removal
            result = container.Remove(key);

            // Push undo level
            if (result)
            {
                PushUndoLevel(
                    new DictionaryRemoveStateChange<TKey, TValue>(
                        key,
                        value));
            }
        }

        // NOTIFICATION AND RETURN
        if (result)
        {
            BroadcastChange();
        }

        return result;
    }

#pragma warning disable CS8767 // Nullability of reference types in type of parameter doesn't match implicitly implemented member (possibly because of nullability attributes).
    /// <summary>
    ///     Attempts to fetch a value for a specific key, indicating whether it has been found or not.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="value">The value.</param>
    /// <returns><see langword="true" /> if the value was successfully fetched, <see langword="false" /> otherwise.</returns>
    public bool TryGetValue(
        TKey key,
        [MaybeNullWhen(false)] out TValue value)
    {
        this.RequiresNotDisposed();

        using (AcquireReadLock())
        {
            return InternalContainer.TryGetValue(
                key,
                out value);
        }
    }
#pragma warning restore CS8767 // Nullability of reference types in type of parameter doesn't match implicitly implemented member (possibly because of nullability attributes).

    /// <summary>
    ///     Called when contents of this dictionary may have changed.
    /// </summary>
    protected override void ContentsMayHaveChanged()
    {
        RaisePropertyChanged(nameof(Keys));
        RaisePropertyChanged(nameof(Values));
        RaisePropertyChanged(Constants.ItemsName);
    }

    /// <summary>
    ///     Interprets the block state changes outside the write lock.
    /// </summary>
    /// <param name="actions">The actions to employ.</param>
    /// <param name="states">The state objects to send to the corresponding actions.</param>
    protected override void InterpretBlockStateChangesOutsideLock(
        Action<object?>?[] actions,
        object?[] states) =>
        BroadcastChange();

    /// <summary>
    ///     Has the last operation undone.
    /// </summary>
    /// <param name="undoRedoLevel">A level of undo, with contents.</param>
    /// <param name="toInvokeOutsideLock">An action to invoke outside of the lock.</param>
    /// <param name="state">The state object to pass to the invocation.</param>
    /// <returns><see langword="true" /> if the undo was successful, <see langword="false" /> otherwise.</returns>
    protected override bool UndoInternally(
        StateChangeBase undoRedoLevel,
        out Action<object?>? toInvokeOutsideLock,
        out object? state)
    {
        if (base.UndoInternally(
                undoRedoLevel,
                out toInvokeOutsideLock,
                out state))
        {
            return true;
        }

        switch (undoRedoLevel)
        {
            case AddStateChange<KeyValuePair<TKey, TValue>>(var keyValuePair, _):
            {
                IDictionaryCollectionAdapter<TKey, TValue> container = InternalContainer;

                    _ = container.Remove(keyValuePair.Key);

                toInvokeOutsideLock = innerState =>
                {
                    if (innerState == null)
                    {
                        return;
                    }

                    ((ObservableDictionary<TKey, TValue>)innerState).BroadcastChange();
                };
                state = this;

                break;
            }

            case RemoveStateChange<KeyValuePair<TKey, TValue>>(_, var (key, value)):
            {
                IDictionaryCollectionAdapter<TKey, TValue> container = InternalContainer;

                    _ = container.Add(
                        key,
                        value);

                toInvokeOutsideLock = innerState =>
                {
                    if (innerState == null)
                    {
                        return;
                    }

                    ((ObservableDictionary<TKey, TValue>)innerState).BroadcastChange();
                };
                state = this;

                break;
            }

            case ClearStateChange<KeyValuePair<TKey, TValue>>(var keyValuePairs):
            {
                IDictionaryCollectionAdapter<TKey, TValue> container = InternalContainer;

                foreach ((TKey key, TValue value) in keyValuePairs)
                {
                        _ = container.Add(
                            key,
                            value);
                }

                toInvokeOutsideLock = innerState =>
                {
                    if (innerState == null)
                    {
                        return;
                    }

                    ((ObservableDictionary<TKey, TValue>)innerState).BroadcastChange();
                };
                state = this;

                break;
            }

            case DictionaryAddStateChange<TKey, TValue>(var key, _):
            {
                IDictionaryCollectionAdapter<TKey, TValue> container = InternalContainer;

                    _ = container.Remove(key);

                toInvokeOutsideLock = innerState =>
                {
                    if (innerState == null)
                    {
                        return;
                    }

                    ((ObservableDictionary<TKey, TValue>)innerState).BroadcastChange();
                };
                state = this;

                break;
            }

            case DictionaryRemoveStateChange<TKey, TValue>(var key, var value):
            {
                IDictionaryCollectionAdapter<TKey, TValue> container = InternalContainer;

                    _ = container.Add(
                        key,
                        value);

                toInvokeOutsideLock = innerState =>
                {
                    if (innerState == null)
                    {
                        return;
                    }

                    ((ObservableDictionary<TKey, TValue>)innerState).BroadcastChange();
                };
                state = this;

                break;
            }

            case DictionaryChangeStateChange<TKey, TValue>(var key, _, var oldValue):
            {
                IDictionaryCollectionAdapter<TKey, TValue> container = InternalContainer;

                container[key] = oldValue;

                toInvokeOutsideLock = innerState =>
                {
                    if (innerState == null)
                    {
                        return;
                    }

                    ((ObservableDictionary<TKey, TValue>)innerState).BroadcastChange();
                };
                state = this;

                break;
            }

            default:
            {
                toInvokeOutsideLock = null;
                state = null;

                return false;
            }
        }

        return true;
    }

    /// <summary>
    ///     Has the last undone operation redone.
    /// </summary>
    /// <param name="undoRedoLevel">A level of undo, with contents.</param>
    /// <param name="toInvokeOutsideLock">An action to invoke outside of the lock.</param>
    /// <param name="state">The state object to pass to the invocation.</param>
    /// <returns><see langword="true" /> if the redo was successful, <see langword="false" /> otherwise.</returns>
    protected override bool RedoInternally(
        StateChangeBase undoRedoLevel,
        out Action<object?>? toInvokeOutsideLock,
        out object? state)
    {
        if (base.RedoInternally(
                undoRedoLevel,
                out toInvokeOutsideLock,
                out state))
        {
            return true;
        }

        switch (undoRedoLevel)
        {
            case AddStateChange<KeyValuePair<TKey, TValue>>(var (key, value), _):
            {
                IDictionaryCollectionAdapter<TKey, TValue> container = InternalContainer;

                    _ = container.Add(
                        key,
                        value);

                toInvokeOutsideLock = innerState =>
                {
                    if (innerState == null)
                    {
                        return;
                    }

                    ((ObservableDictionary<TKey, TValue>)innerState).BroadcastChange();
                };
                state = this;

                break;
            }

            case RemoveStateChange<KeyValuePair<TKey, TValue>>(_, var keyValuePair):
            {
                IDictionaryCollectionAdapter<TKey, TValue> container = InternalContainer;

                    _ = container.Remove(keyValuePair.Key);

                toInvokeOutsideLock = innerState =>
                {
                    if (innerState == null)
                    {
                        return;
                    }

                    ((ObservableDictionary<TKey, TValue>)innerState).BroadcastChange();
                };
                state = this;

                break;
            }

            case ClearStateChange<KeyValuePair<TKey, TValue>>:
            {
                InternalContainer.Clear();

                toInvokeOutsideLock = innerState =>
                {
                    if (innerState == null)
                    {
                        return;
                    }

                    ((ObservableDictionary<TKey, TValue>)innerState).BroadcastChange();
                };
                state = this;

                break;
            }

            case DictionaryAddStateChange<TKey, TValue>(var key, var value):
            {
                IDictionaryCollectionAdapter<TKey, TValue> container = InternalContainer;

                    _ = container.Add(
                        key,
                        value);

                toInvokeOutsideLock = innerState =>
                {
                    if (innerState == null)
                    {
                        return;
                    }

                    ((ObservableDictionary<TKey, TValue>)innerState).BroadcastChange();
                };
                state = this;

                break;
            }

            case DictionaryRemoveStateChange<TKey, TValue>(var key, _):
            {
                IDictionaryCollectionAdapter<TKey, TValue> container = InternalContainer;

                    _ = container.Remove(key);

                toInvokeOutsideLock = innerState =>
                {
                    if (innerState == null)
                    {
                        return;
                    }

                    ((ObservableDictionary<TKey, TValue>)innerState).BroadcastChange();
                };
                state = this;

                break;
            }

            case DictionaryChangeStateChange<TKey, TValue>(var key, var newValue, _):
            {
                IDictionaryCollectionAdapter<TKey, TValue> container = InternalContainer;

                container[key] = newValue;

                toInvokeOutsideLock = innerState =>
                {
                    if (innerState == null)
                    {
                        return;
                    }

                    ((ObservableDictionary<TKey, TValue>)innerState).BroadcastChange();
                };
                state = this;

                break;
            }

            default:
            {
                toInvokeOutsideLock = null;
                state = null;

                return false;
            }
        }

        return true;
    }

    private void BroadcastChange()
    {
        RaiseCollectionReset();
        RaisePropertyChanged(nameof(Keys));
        RaisePropertyChanged(nameof(Values));
        RaisePropertyChanged(nameof(Count));
        RaisePropertyChanged(Constants.ItemsName);
    }
}