using System.Diagnostics.CodeAnalysis;

namespace IX.Library;

/// <summary>
///     A lazy initializing class that also offers the possibility to invalidate the value stored in it.
/// </summary>
/// <typeparam name="T">The type of item instance initialized by the invalidating lazy.</typeparam>
/// <seealso cref="Lazy{T}" />
public class InvalidatingLazy<T>
{

    private readonly Func<Lazy<T>> _lazyCreator;
    private Lazy<T> _internalLazy;

    /// <summary>
    ///     Initializes a new instance of the <see cref="InvalidatingLazy{T}" /> class.
    /// </summary>
    public InvalidatingLazy()
    {
        _internalLazy = new();
        _lazyCreator = () => new();
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="InvalidatingLazy{T}" /> class.
    /// </summary>
    /// <param name="valueFactory">The delegate that is invoked to produce the lazily initialized value when it is needed.</param>
    [SuppressMessage(
        "Performance",
        "HAA0302:Display class allocation to capture closure",
        Justification = "Unavoidable.")]
    [SuppressMessage(
        "Performance",
        "HAA0301:Closure Allocation Source",
        Justification = "Unavoidable.")]
    public InvalidatingLazy(Func<T> valueFactory)
    {
        _internalLazy = new(valueFactory);
        _lazyCreator = () => new(valueFactory);
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="InvalidatingLazy{T}" /> class.
    /// </summary>
    /// <param name="isThreadSafe">
    ///     <see langword="true" /> to make this instance usable concurrently by multiple threads;
    ///     <see langword="false" /> to make the instance usable by only one thread at a time.
    /// </param>
    [SuppressMessage(
        "Performance",
        "HAA0302:Display class allocation to capture closure",
        Justification = "Unavoidable.")]
    [SuppressMessage(
        "Performance",
        "HAA0301:Closure Allocation Source",
        Justification = "Unavoidable.")]
    public InvalidatingLazy(bool isThreadSafe)
    {
        _internalLazy = new(isThreadSafe);
        _lazyCreator = () => new(isThreadSafe);
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="InvalidatingLazy{T}" /> class.
    /// </summary>
    /// <param name="mode">One of the enumeration values that specifies the thread safety mode.</param>
    [SuppressMessage(
        "Performance",
        "HAA0302:Display class allocation to capture closure",
        Justification = "Unavoidable.")]
    [SuppressMessage(
        "Performance",
        "HAA0301:Closure Allocation Source",
        Justification = "Unavoidable.")]
    public InvalidatingLazy(LazyThreadSafetyMode mode)
    {
        _internalLazy = new(mode);
        _lazyCreator = () => new(mode);
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="InvalidatingLazy{T}" /> class.
    /// </summary>
    /// <param name="valueFactory">The delegate that is invoked to produce the lazily initialized value when it is needed.</param>
    /// <param name="isThreadSafe">
    ///     <see langword="true" /> to make this instance usable concurrently by multiple threads;
    ///     <see langword="false" /> to make this instance usable by only one thread at a time.
    /// </param>
    [SuppressMessage(
        "Performance",
        "HAA0302:Display class allocation to capture closure",
        Justification = "Unavoidable.")]
    [SuppressMessage(
        "Performance",
        "HAA0301:Closure Allocation Source",
        Justification = "Unavoidable.")]
    public InvalidatingLazy(
        Func<T> valueFactory,
        bool isThreadSafe)
    {
        _internalLazy = new(
            valueFactory,
            isThreadSafe);
        _lazyCreator = () => new(
            valueFactory,
            isThreadSafe);
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="InvalidatingLazy{T}" /> class.
    /// </summary>
    /// <param name="valueFactory">The delegate that is invoked to produce the lazily initialized value when it is needed.</param>
    /// <param name="mode">One of the enumeration values that specifies the thread safety mode.</param>
    [SuppressMessage(
        "Performance",
        "HAA0302:Display class allocation to capture closure",
        Justification = "Unavoidable.")]
    [SuppressMessage(
        "Performance",
        "HAA0301:Closure Allocation Source",
        Justification = "Unavoidable.")]
    public InvalidatingLazy(
        Func<T> valueFactory,
        LazyThreadSafetyMode mode)
    {
        _internalLazy = new(
            valueFactory,
            mode);
        _lazyCreator = () => new(
            valueFactory,
            mode);
    }

    /// <summary>
    ///     Gets a value indicating whether a value has been created for this <see cref="InvalidatingLazy{T}"></see>
    ///     instance.
    /// </summary>
    /// <returns>true if a value has been created for this <see cref="InvalidatingLazy{T}"></see> instance; otherwise, false.</returns>
    public bool IsValueCreated => _internalLazy.IsValueCreated;

    /// <summary>Gets the lazily initialized value of the current <see cref="InvalidatingLazy{T}"></see> instance.</summary>
    /// <returns>The lazily initialized value of the current <see cref="InvalidatingLazy{T}"></see> instance.</returns>
    /// <exception cref="MemberAccessException">
    ///     The <see cref="InvalidatingLazy{T}"></see> instance is initialized to use
    ///     the default constructor of the type that is being lazily initialized, and permissions to access the constructor are
    ///     missing.
    /// </exception>
    /// <exception cref="MissingMemberException">
    ///     The <see cref="InvalidatingLazy{T}"></see> instance is initialized to use
    ///     the default constructor of the type that is being lazily initialized, and that type does not have a public,
    ///     parameter-less constructor.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    ///     The initialization function tries to access
    ///     <see cref="InvalidatingLazy{T}.Value"></see> on this instance.
    /// </exception>
    public T Value => _internalLazy.Value;

    /// <summary>
    ///     Creates and returns a string representation of the <see cref="InvalidatingLazy{T}.Value"></see> property for this
    ///     instance.
    /// </summary>
    /// <returns>
    ///     The result of calling the <see cref="object.ToString"></see> method on the
    ///     <see cref="InvalidatingLazy{T}.Value"></see> property for this instance, if the value has been created (that is, if
    ///     the
    ///     <see cref="InvalidatingLazy{T}.IsValueCreated"></see> property returns true). Otherwise, a string indicating that
    ///     the
    ///     value has not been created.
    /// </returns>
    /// <exception cref="NullReferenceException">The <see cref="InvalidatingLazy{T}.Value"></see> property is null.</exception>
    public override string? ToString() => _internalLazy.ToString();

    /// <summary>
    ///     Invalidates the instance stored into this lazy initializer, and allows a new one to be created.
    /// </summary>
    /// <returns>
    ///     The initial instance stored into this invalidating lazy initializer, if one exists, or a default value
    ///     otherwise.
    /// </returns>
    public T Invalidate()
    {
        Lazy<T> existingLazy = Interlocked.Exchange(
            ref _internalLazy,
            _lazyCreator());

        return existingLazy.IsValueCreated ? existingLazy.Value : default!;
    }
}