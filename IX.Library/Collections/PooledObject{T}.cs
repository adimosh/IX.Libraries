namespace IX.Library.Collections;

/// <summary>
///     A pooled object. This class cannot be inherited.
/// </summary>
/// <typeparam name="T">The type of class instance in the _pool.</typeparam>
/// <seealso cref="IDisposable" />
public sealed class PooledObject<T> : IDisposable
    where T : class
{
    private readonly ObjectPool<T> _pool;

    private bool _abort;

    internal PooledObject(
        ObjectPool<T> pool,
        T value)
    {
        Value = value;
        _pool = pool;
    }

    /// <summary>
    ///     Gets the value contained.
    /// </summary>
    /// <value>The value.</value>
    public T Value
    {
        get;
    }

    /// <summary>
    ///     Performs an implicit conversion from <see cref="IX.Library.Collections.PooledObject{T}" /> to <typeparamref name="T" />.
    /// </summary>
    /// <param name="source">The source pooled object.</param>
    /// <returns>The result of the conversion.</returns>
    public static implicit operator T(PooledObject<T> source) =>
        (source ?? throw new ArgumentNullException(nameof(source))).Value;

    /// <summary>
    ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public void Dispose()
    {
        if (!_abort)
        {
            _pool.Release(Value);
        }
    }

    /// <summary>
    ///     Aborts this pooled object, not returning its value to the pool.
    /// </summary>
    public void Abort() =>
        _abort = true;
}