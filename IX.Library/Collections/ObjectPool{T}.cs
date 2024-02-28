namespace IX.Library.Collections;

/// <summary>
///     A pool of on-demand objects that keeps growing based on demand.
/// </summary>
/// <typeparam name="T">The class type to hold in the pool.</typeparam>
[PublicAPI]
public class ObjectPool<T>
    where T : class
{
    // Pool collections
    private readonly Queue<T> _availableObjects;

    // Interlocker
    private readonly object _locker;

    // Object factory
    private readonly Func<T> _objectFactory;

    /// <summary>
    ///     Initializes a new instance of the <see cref="IX.Library.Collections.ObjectPool{T}" /> class.
    /// </summary>
    /// <param name="objectFactory">An object factory for when objects need to be created.</param>
    /// <exception cref="ArgumentNullException">
    ///     The <paramref name="objectFactory" /> is <see langword="null" /> (
    ///     <see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public ObjectPool(Func<T> objectFactory)
    {
        Requires.NotNull(
            out _objectFactory,
            objectFactory);

        _locker = new();
        _availableObjects = new();
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="IX.Library.Collections.ObjectPool{T}" /> class.
    /// </summary>
    /// <param name="objectFactory">An object factory for when objects need to be created.</param>
    /// <param name="initialNumberOfObjects">The number of objects to populate the pool with upon creation.</param>
    /// <exception cref="ArgumentException">
    ///     <paramref name="initialNumberOfObjects"/> is not a positive
    ///     integer.
    /// </exception>
    /// <exception cref="ArgumentNullException">
    ///     The <paramref name="objectFactory" /> is <see langword="null" /> (
    ///     <see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public ObjectPool(Func<T> objectFactory, int initialNumberOfObjects)
    {
        Requires.Positive(
            in initialNumberOfObjects);
        Requires.NotNull(
            out _objectFactory,
            objectFactory);

        _locker = new();
        _availableObjects = new();

        for (int i = 0; i < initialNumberOfObjects; i++)
        {
            _availableObjects.Enqueue(objectFactory());
        }
    }

    /// <summary>
    ///     Gets the count of unused objects in the pool.
    /// </summary>
    /// <value>The currently-unused object count.</value>
    /// <remarks>
    ///     <para>
    ///         If this property returns 0, there are no more unused objects in the pool. If one is requested, a new one will
    ///         most likely be created.
    ///     </para>
    /// </remarks>
    public int Count
    {
        get
        {
            lock (_locker)
            {
                return _availableObjects.Count;
            }
        }
    }

    /// <summary>
    ///     Gets an object from the pool.
    /// </summary>
    /// <returns>A pooled object, either new, or unused.</returns>
    public PooledObject<T> Get()
    {
        T @object;

        lock (_locker)
        {
            @object = _availableObjects.Count > 0 ? _availableObjects.Dequeue() : _objectFactory();
        }

        return new(
            this,
            @object);
    }

    internal void Release(T @object)
    {
        lock (_locker)
        {
            _availableObjects.Enqueue(@object);
        }
    }
}