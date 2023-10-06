namespace IX.Library.ComponentModel.Events;

/// <summary>
/// An event key.
/// </summary>
/// <typeparam name="TKey">The type of the key.</typeparam>
/// <seealso cref="IEquatable{T}" />
[PublicAPI]
public readonly struct EventKey<TKey> : IEquatable<EventKey<TKey>>
    where TKey : notnull
{
    private readonly int _hashCode;

    /// <summary>
    /// Initializes a new instance of the <see cref="EventKey{TKey}"/> struct.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="type">The type.</param>
    public EventKey(TKey key, Type type)
    {
        Key = key;
        Type = type;
        #if FRAMEWORK_ADVANCED
        _hashCode = HashCode.Combine(
            key,
            type);
        #else
        _hashCode = key.GetHashCode();
        #endif
    }

    /// <summary>
    /// Gets the key.
    /// </summary>
    /// <value>
    /// The key.
    /// </value>
    public TKey Key { get; }

    /// <summary>
    /// Gets the type.
    /// </summary>
    /// <value>
    /// The type.
    /// </value>
    public Type Type { get; }

    /// <summary>Returns the hash code for this instance.</summary>
    /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
    public override int GetHashCode() =>
        _hashCode;

    /// <summary>Indicates whether this instance and a specified object are equal.</summary>
    /// <param name="obj">The object to compare with the current instance.</param>
    /// <returns>
    /// <see langword="true" /> if <paramref name="obj" /> and this instance are the same type and represent the same value; otherwise, <see langword="false" />.</returns>
    public override bool Equals(object? obj) => obj is EventKey<TKey> other && Equals(other);

    /// <summary>
    /// Implements the operator ==.
    /// </summary>
    /// <param name="left">The left operand.</param>
    /// <param name="right">The right operand.</param>
    /// <returns>
    /// The result of the operator.
    /// </returns>
    public static bool operator ==(EventKey<TKey> left, EventKey<TKey> right) => left.Equals(right);

    /// <summary>
    /// Implements the operator !=.
    /// </summary>
    /// <param name="left">The left operand.</param>
    /// <param name="right">The right operand.</param>
    /// <returns>
    /// The result of the operator.
    /// </returns>
    public static bool operator !=(EventKey<TKey> left, EventKey<TKey> right) => !(left == right);

    /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
    /// <param name="other">An object to compare with this object.</param>
    /// <returns>
    /// <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.</returns>
    public bool Equals(EventKey<TKey> other) =>
        _hashCode == other._hashCode && EqualityComparer<TKey>.Default.Equals(
            Key,
            other.Key) && Type == other.Type;
}