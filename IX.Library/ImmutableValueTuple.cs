namespace IX.Library;

#pragma warning disable SA1402 // File may only contain a single type
/// <summary>
/// An immutable value tuple.
/// </summary>
/// <typeparam name="TItem1">The type of the item at index 1.</typeparam>
public readonly struct ImmutableValueTuple<TItem1> : IEquatable<ImmutableValueTuple<TItem1>>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ImmutableValueTuple{TItem1}"/> struct.
    /// </summary>
    /// <param name="item1">The value of the item at index 1.</param>
    public ImmutableValueTuple(TItem1 item1)
    {
        Item1 = item1;
    }

    /// <summary>
    /// Gets the item at index 1.
    /// </summary>
    public TItem1 Item1
    {
        get;
    }

    /// <summary>
    /// Implements the operator ==.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>
    /// The result of the operator.
    /// </returns>
    public static bool operator ==(ImmutableValueTuple<TItem1> left, ImmutableValueTuple<TItem1> right) => left.Equals(right);

    /// <summary>
    /// Implements the operator !=.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>
    /// The result of the operator.
    /// </returns>
    public static bool operator !=(ImmutableValueTuple<TItem1> left, ImmutableValueTuple<TItem1> right) => !(left == right);

    /// <summary>
    /// Equates this instance to another object.
    /// </summary>
    /// <param name="other">The other object to equate to.</param>
    /// <returns><c>true</c> if the two tuples are equals, <c>false</c> otherwise.</returns>
    public override bool Equals(object? other) =>
        other is ImmutableValueTuple<TItem1> otherTuple && Equals(otherTuple);

    /// <summary>
    /// Equates this tuple to another tuple.
    /// </summary>
    /// <param name="other">The other tuple to equate to.</param>
    /// <returns><c>true</c> if the two tuples are equals, <c>false</c> otherwise.</returns>
    public bool Equals(ImmutableValueTuple<TItem1> other) =>
        EqualityComparer<TItem1>.Default.Equals(Item1, other.Item1);

    /// <summary>
    /// Returns a hash code for this instance.
    /// </summary>
    /// <returns>
    /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
    /// </returns>
    public override int GetHashCode() =>
        Item1?.GetHashCode() ?? 0;
}

/// <summary>
/// An immutable value tuple.
/// </summary>
/// <typeparam name="TItem1">The type of the item at index 1.</typeparam>
/// <typeparam name="TItem2">The type of the item at index 2.</typeparam>
public readonly struct ImmutableValueTuple<TItem1, TItem2> : IEquatable<ImmutableValueTuple<TItem1, TItem2>>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ImmutableValueTuple{TItem1, TItem2}"/> struct.
    /// </summary>
    /// <param name="item1">The value of the item at index 1.</param>
    /// <param name="item2">The value of the item at index 2.</param>
    public ImmutableValueTuple(TItem1 item1, TItem2 item2)
    {
        Item1 = item1;
        Item2 = item2;
    }

    /// <summary>
    /// Gets the item at index 1.
    /// </summary>
    public TItem1 Item1
    {
        get;
    }

    /// <summary>
    /// Gets the item at index 2.
    /// </summary>
    public TItem2 Item2
    {
        get;
    }

    /// <summary>
    /// Implements the operator ==.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>
    /// The result of the operator.
    /// </returns>
    public static bool operator ==(ImmutableValueTuple<TItem1, TItem2> left, ImmutableValueTuple<TItem1, TItem2> right) => left.Equals(right);

    /// <summary>
    /// Implements the operator !=.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>
    /// The result of the operator.
    /// </returns>
    public static bool operator !=(ImmutableValueTuple<TItem1, TItem2> left, ImmutableValueTuple<TItem1, TItem2> right) => !(left == right);

    /// <summary>
    /// Equates this instance to another object.
    /// </summary>
    /// <param name="other">The other object to equate to.</param>
    /// <returns><c>true</c> if the two tuples are equals, <c>false</c> otherwise.</returns>
    public override bool Equals(object? other) =>
        other is ImmutableValueTuple<TItem1, TItem2> otherTuple && Equals(otherTuple);

    /// <summary>
    /// Equates this tuple to another tuple.
    /// </summary>
    /// <param name="other">The other tuple to equate to.</param>
    /// <returns><c>true</c> if the two tuples are equals, <c>false</c> otherwise.</returns>
    public bool Equals(ImmutableValueTuple<TItem1, TItem2> other) =>
        EqualityComparer<TItem1>.Default.Equals(Item1, other.Item1) &&
            EqualityComparer<TItem2>.Default.Equals(Item2, other.Item2);

    /// <summary>
    /// Returns a hash code for this instance.
    /// </summary>
    /// <returns>
    /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
    /// </returns>
    public override int GetHashCode() =>
        (Item1, Item2).GetHashCode();
}

/// <summary>
/// An immutable value tuple.
/// </summary>
/// <typeparam name="TItem1">The type of the item at index 1.</typeparam>
/// <typeparam name="TItem2">The type of the item at index 2.</typeparam>
/// <typeparam name="TItem3">The type of the item at index 3.</typeparam>
public readonly struct ImmutableValueTuple<TItem1, TItem2, TItem3> : IEquatable<ImmutableValueTuple<TItem1, TItem2, TItem3>>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ImmutableValueTuple{TItem1, TItem2, TItem3}"/> struct.
    /// </summary>
    /// <param name="item1">The value of the item at index 1.</param>
    /// <param name="item2">The value of the item at index 2.</param>
    /// <param name="item3">The value of the item at index 3.</param>
    public ImmutableValueTuple(TItem1 item1, TItem2 item2, TItem3 item3)
    {
        Item1 = item1;
        Item2 = item2;
        Item3 = item3;
    }

    /// <summary>
    /// Gets the item at index 1.
    /// </summary>
    public TItem1 Item1
    {
        get;
    }

    /// <summary>
    /// Gets the item at index 2.
    /// </summary>
    public TItem2 Item2
    {
        get;
    }

    /// <summary>
    /// Gets the item at index 3.
    /// </summary>
    public TItem3 Item3
    {
        get;
    }

    /// <summary>
    /// Implements the operator ==.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>
    /// The result of the operator.
    /// </returns>
    public static bool operator ==(ImmutableValueTuple<TItem1, TItem2, TItem3> left, ImmutableValueTuple<TItem1, TItem2, TItem3> right) => left.Equals(right);

    /// <summary>
    /// Implements the operator !=.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>
    /// The result of the operator.
    /// </returns>
    public static bool operator !=(ImmutableValueTuple<TItem1, TItem2, TItem3> left, ImmutableValueTuple<TItem1, TItem2, TItem3> right) => !(left == right);

    /// <summary>
    /// Equates this instance to another object.
    /// </summary>
    /// <param name="other">The other object to equate to.</param>
    /// <returns><c>true</c> if the two tuples are equals, <c>false</c> otherwise.</returns>
    public override bool Equals(object? other) =>
        other is ImmutableValueTuple<TItem1, TItem2, TItem3> otherTuple && Equals(otherTuple);

    /// <summary>
    /// Equates this tuple to another tuple.
    /// </summary>
    /// <param name="other">The other tuple to equate to.</param>
    /// <returns><c>true</c> if the two tuples are equals, <c>false</c> otherwise.</returns>
    public bool Equals(ImmutableValueTuple<TItem1, TItem2, TItem3> other) =>
        EqualityComparer<TItem1>.Default.Equals(Item1, other.Item1) &&
            EqualityComparer<TItem2>.Default.Equals(Item2, other.Item2) &&
            EqualityComparer<TItem3>.Default.Equals(Item3, other.Item3);

    /// <summary>
    /// Returns a hash code for this instance.
    /// </summary>
    /// <returns>
    /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
    /// </returns>
    public override int GetHashCode() =>
        (Item1, Item2, Item3).GetHashCode();
}

/// <summary>
/// An immutable value tuple.
/// </summary>
/// <typeparam name="TItem1">The type of the item at index 1.</typeparam>
/// <typeparam name="TItem2">The type of the item at index 2.</typeparam>
/// <typeparam name="TItem3">The type of the item at index 3.</typeparam>
/// <typeparam name="TItem4">The type of the item at index 4.</typeparam>
public readonly struct ImmutableValueTuple<TItem1, TItem2, TItem3, TItem4> : IEquatable<ImmutableValueTuple<TItem1, TItem2, TItem3, TItem4>>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ImmutableValueTuple{TItem1, TItem2, TItem3, TItem4}"/> struct.
    /// </summary>
    /// <param name="item1">The value of the item at index 1.</param>
    /// <param name="item2">The value of the item at index 2.</param>
    /// <param name="item3">The value of the item at index 3.</param>
    /// <param name="item4">The value of the item at index 4.</param>
    public ImmutableValueTuple(TItem1 item1, TItem2 item2, TItem3 item3, TItem4 item4)
    {
        Item1 = item1;
        Item2 = item2;
        Item3 = item3;
        Item4 = item4;
    }

    /// <summary>
    /// Gets the item at index 1.
    /// </summary>
    public TItem1 Item1
    {
        get;
    }

    /// <summary>
    /// Gets the item at index 2.
    /// </summary>
    public TItem2 Item2
    {
        get;
    }

    /// <summary>
    /// Gets the item at index 3.
    /// </summary>
    public TItem3 Item3
    {
        get;
    }

    /// <summary>
    /// Gets the item at index 4.
    /// </summary>
    public TItem4 Item4
    {
        get;
    }

    /// <summary>
    /// Implements the operator ==.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>
    /// The result of the operator.
    /// </returns>
    public static bool operator ==(ImmutableValueTuple<TItem1, TItem2, TItem3, TItem4> left, ImmutableValueTuple<TItem1, TItem2, TItem3, TItem4> right) => left.Equals(right);

    /// <summary>
    /// Implements the operator !=.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>
    /// The result of the operator.
    /// </returns>
    public static bool operator !=(ImmutableValueTuple<TItem1, TItem2, TItem3, TItem4> left, ImmutableValueTuple<TItem1, TItem2, TItem3, TItem4> right) => !(left == right);

    /// <summary>
    /// Equates this instance to another object.
    /// </summary>
    /// <param name="other">The other object to equate to.</param>
    /// <returns><c>true</c> if the two tuples are equals, <c>false</c> otherwise.</returns>
    public override bool Equals(object? other) =>
        other is ImmutableValueTuple<TItem1, TItem2, TItem3, TItem4> otherTuple && Equals(otherTuple);

    /// <summary>
    /// Equates this tuple to another tuple.
    /// </summary>
    /// <param name="other">The other tuple to equate to.</param>
    /// <returns><c>true</c> if the two tuples are equals, <c>false</c> otherwise.</returns>
    public bool Equals(ImmutableValueTuple<TItem1, TItem2, TItem3, TItem4> other) =>
        EqualityComparer<TItem1>.Default.Equals(Item1, other.Item1) &&
            EqualityComparer<TItem2>.Default.Equals(Item2, other.Item2) &&
            EqualityComparer<TItem3>.Default.Equals(Item3, other.Item3) &&
            EqualityComparer<TItem4>.Default.Equals(Item4, other.Item4);

    /// <summary>
    /// Returns a hash code for this instance.
    /// </summary>
    /// <returns>
    /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
    /// </returns>
    public override int GetHashCode() =>
        (Item1, Item2, Item3, Item4).GetHashCode();
}

/// <summary>
/// An immutable value tuple.
/// </summary>
/// <typeparam name="TItem1">The type of the item at index 1.</typeparam>
/// <typeparam name="TItem2">The type of the item at index 2.</typeparam>
/// <typeparam name="TItem3">The type of the item at index 3.</typeparam>
/// <typeparam name="TItem4">The type of the item at index 4.</typeparam>
/// <typeparam name="TItem5">The type of the item at index 5.</typeparam>
public readonly struct ImmutableValueTuple<TItem1, TItem2, TItem3, TItem4, TItem5> : IEquatable<ImmutableValueTuple<TItem1, TItem2, TItem3, TItem4, TItem5>>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ImmutableValueTuple{TItem1, TItem2, TItem3, TItem4, TItem5}"/> struct.
    /// </summary>
    /// <param name="item1">The value of the item at index 1.</param>
    /// <param name="item2">The value of the item at index 2.</param>
    /// <param name="item3">The value of the item at index 3.</param>
    /// <param name="item4">The value of the item at index 4.</param>
    /// <param name="item5">The value of the item at index 5.</param>
    public ImmutableValueTuple(TItem1 item1, TItem2 item2, TItem3 item3, TItem4 item4, TItem5 item5)
    {
        Item1 = item1;
        Item2 = item2;
        Item3 = item3;
        Item4 = item4;
        Item5 = item5;
    }

    /// <summary>
    /// Gets the item at index 1.
    /// </summary>
    public TItem1 Item1
    {
        get;
    }

    /// <summary>
    /// Gets the item at index 2.
    /// </summary>
    public TItem2 Item2
    {
        get;
    }

    /// <summary>
    /// Gets the item at index 3.
    /// </summary>
    public TItem3 Item3
    {
        get;
    }

    /// <summary>
    /// Gets the item at index 4.
    /// </summary>
    public TItem4 Item4
    {
        get;
    }

    /// <summary>
    /// Gets the item at index 5.
    /// </summary>
    public TItem5 Item5
    {
        get;
    }

    /// <summary>
    /// Implements the operator ==.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>
    /// The result of the operator.
    /// </returns>
    public static bool operator ==(ImmutableValueTuple<TItem1, TItem2, TItem3, TItem4, TItem5> left, ImmutableValueTuple<TItem1, TItem2, TItem3, TItem4, TItem5> right) => left.Equals(right);

    /// <summary>
    /// Implements the operator !=.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>
    /// The result of the operator.
    /// </returns>
    public static bool operator !=(ImmutableValueTuple<TItem1, TItem2, TItem3, TItem4, TItem5> left, ImmutableValueTuple<TItem1, TItem2, TItem3, TItem4, TItem5> right) => !(left == right);

    /// <summary>
    /// Equates this instance to another object.
    /// </summary>
    /// <param name="other">The other object to equate to.</param>
    /// <returns><c>true</c> if the two tuples are equals, <c>false</c> otherwise.</returns>
    public override bool Equals(object? other) =>
        other is ImmutableValueTuple<TItem1, TItem2, TItem3, TItem4, TItem5> otherTuple && Equals(otherTuple);

    /// <summary>
    /// Equates this tuple to another tuple.
    /// </summary>
    /// <param name="other">The other tuple to equate to.</param>
    /// <returns><c>true</c> if the two tuples are equals, <c>false</c> otherwise.</returns>
    public bool Equals(ImmutableValueTuple<TItem1, TItem2, TItem3, TItem4, TItem5> other) =>
        EqualityComparer<TItem1>.Default.Equals(Item1, other.Item1) &&
            EqualityComparer<TItem2>.Default.Equals(Item2, other.Item2) &&
            EqualityComparer<TItem3>.Default.Equals(Item3, other.Item3) &&
            EqualityComparer<TItem4>.Default.Equals(Item4, other.Item4) &&
            EqualityComparer<TItem5>.Default.Equals(Item5, other.Item5);

    /// <summary>
    /// Returns a hash code for this instance.
    /// </summary>
    /// <returns>
    /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
    /// </returns>
    public override int GetHashCode() =>
        (Item1, Item2, Item3, Item4, Item5).GetHashCode();
}

/// <summary>
/// An immutable value tuple.
/// </summary>
/// <typeparam name="TItem1">The type of the item at index 1.</typeparam>
/// <typeparam name="TItem2">The type of the item at index 2.</typeparam>
/// <typeparam name="TItem3">The type of the item at index 3.</typeparam>
/// <typeparam name="TItem4">The type of the item at index 4.</typeparam>
/// <typeparam name="TItem5">The type of the item at index 5.</typeparam>
/// <typeparam name="TItem6">The type of the item at index 6.</typeparam>
public readonly struct ImmutableValueTuple<TItem1, TItem2, TItem3, TItem4, TItem5, TItem6> : IEquatable<ImmutableValueTuple<TItem1, TItem2, TItem3, TItem4, TItem5, TItem6>>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ImmutableValueTuple{TItem1, TItem2, TItem3, TItem4, TItem5, TItem6}"/> struct.
    /// </summary>
    /// <param name="item1">The value of the item at index 1.</param>
    /// <param name="item2">The value of the item at index 2.</param>
    /// <param name="item3">The value of the item at index 3.</param>
    /// <param name="item4">The value of the item at index 4.</param>
    /// <param name="item5">The value of the item at index 5.</param>
    /// <param name="item6">The value of the item at index 6.</param>
    public ImmutableValueTuple(TItem1 item1, TItem2 item2, TItem3 item3, TItem4 item4, TItem5 item5, TItem6 item6)
    {
        Item1 = item1;
        Item2 = item2;
        Item3 = item3;
        Item4 = item4;
        Item5 = item5;
        Item6 = item6;
    }

    /// <summary>
    /// Gets the item at index 1.
    /// </summary>
    public TItem1 Item1
    {
        get;
    }

    /// <summary>
    /// Gets the item at index 2.
    /// </summary>
    public TItem2 Item2
    {
        get;
    }

    /// <summary>
    /// Gets the item at index 3.
    /// </summary>
    public TItem3 Item3
    {
        get;
    }

    /// <summary>
    /// Gets the item at index 4.
    /// </summary>
    public TItem4 Item4
    {
        get;
    }

    /// <summary>
    /// Gets the item at index 5.
    /// </summary>
    public TItem5 Item5
    {
        get;
    }

    /// <summary>
    /// Gets the item at index 6.
    /// </summary>
    public TItem6 Item6
    {
        get;
    }

    /// <summary>
    /// Implements the operator ==.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>
    /// The result of the operator.
    /// </returns>
    public static bool operator ==(ImmutableValueTuple<TItem1, TItem2, TItem3, TItem4, TItem5, TItem6> left, ImmutableValueTuple<TItem1, TItem2, TItem3, TItem4, TItem5, TItem6> right) => left.Equals(right);

    /// <summary>
    /// Implements the operator !=.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>
    /// The result of the operator.
    /// </returns>
    public static bool operator !=(ImmutableValueTuple<TItem1, TItem2, TItem3, TItem4, TItem5, TItem6> left, ImmutableValueTuple<TItem1, TItem2, TItem3, TItem4, TItem5, TItem6> right) => !(left == right);

    /// <summary>
    /// Equates this instance to another object.
    /// </summary>
    /// <param name="other">The other object to equate to.</param>
    /// <returns><c>true</c> if the two tuples are equals, <c>false</c> otherwise.</returns>
    public override bool Equals(object? other) =>
        other is ImmutableValueTuple<TItem1, TItem2, TItem3, TItem4, TItem5, TItem6> otherTuple && Equals(otherTuple);

    /// <summary>
    /// Equates this tuple to another tuple.
    /// </summary>
    /// <param name="other">The other tuple to equate to.</param>
    /// <returns><c>true</c> if the two tuples are equals, <c>false</c> otherwise.</returns>
    public bool Equals(ImmutableValueTuple<TItem1, TItem2, TItem3, TItem4, TItem5, TItem6> other) =>
        EqualityComparer<TItem1>.Default.Equals(Item1, other.Item1) &&
            EqualityComparer<TItem2>.Default.Equals(Item2, other.Item2) &&
            EqualityComparer<TItem3>.Default.Equals(Item3, other.Item3) &&
            EqualityComparer<TItem4>.Default.Equals(Item4, other.Item4) &&
            EqualityComparer<TItem5>.Default.Equals(Item5, other.Item5) &&
            EqualityComparer<TItem6>.Default.Equals(Item6, other.Item6);

    /// <summary>
    /// Returns a hash code for this instance.
    /// </summary>
    /// <returns>
    /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
    /// </returns>
    public override int GetHashCode() =>
        (Item1, Item2, Item3, Item4, Item5, Item6).GetHashCode();
}

/// <summary>
/// An immutable value tuple.
/// </summary>
/// <typeparam name="TItem1">The type of the item at index 1.</typeparam>
/// <typeparam name="TItem2">The type of the item at index 2.</typeparam>
/// <typeparam name="TItem3">The type of the item at index 3.</typeparam>
/// <typeparam name="TItem4">The type of the item at index 4.</typeparam>
/// <typeparam name="TItem5">The type of the item at index 5.</typeparam>
/// <typeparam name="TItem6">The type of the item at index 6.</typeparam>
/// <typeparam name="TItem7">The type of the item at index 7.</typeparam>
public readonly struct ImmutableValueTuple<TItem1, TItem2, TItem3, TItem4, TItem5, TItem6, TItem7> : IEquatable<ImmutableValueTuple<TItem1, TItem2, TItem3, TItem4, TItem5, TItem6, TItem7>>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ImmutableValueTuple{TItem1, TItem2, TItem3, TItem4, TItem5, TItem6, TItem7}"/> struct.
    /// </summary>
    /// <param name="item1">The value of the item at index 1.</param>
    /// <param name="item2">The value of the item at index 2.</param>
    /// <param name="item3">The value of the item at index 3.</param>
    /// <param name="item4">The value of the item at index 4.</param>
    /// <param name="item5">The value of the item at index 5.</param>
    /// <param name="item6">The value of the item at index 6.</param>
    /// <param name="item7">The value of the item at index 7.</param>
    public ImmutableValueTuple(TItem1 item1, TItem2 item2, TItem3 item3, TItem4 item4, TItem5 item5, TItem6 item6, TItem7 item7)
    {
        Item1 = item1;
        Item2 = item2;
        Item3 = item3;
        Item4 = item4;
        Item5 = item5;
        Item6 = item6;
        Item7 = item7;
    }

    /// <summary>
    /// Gets the item at index 1.
    /// </summary>
    public TItem1 Item1
    {
        get;
    }

    /// <summary>
    /// Gets the item at index 2.
    /// </summary>
    public TItem2 Item2
    {
        get;
    }

    /// <summary>
    /// Gets the item at index 3.
    /// </summary>
    public TItem3 Item3
    {
        get;
    }

    /// <summary>
    /// Gets the item at index 4.
    /// </summary>
    public TItem4 Item4
    {
        get;
    }

    /// <summary>
    /// Gets the item at index 5.
    /// </summary>
    public TItem5 Item5
    {
        get;
    }

    /// <summary>
    /// Gets the item at index 6.
    /// </summary>
    public TItem6 Item6
    {
        get;
    }

    /// <summary>
    /// Gets the item at index 7.
    /// </summary>
    public TItem7 Item7
    {
        get;
    }

    /// <summary>
    /// Implements the operator ==.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>
    /// The result of the operator.
    /// </returns>
    public static bool operator ==(ImmutableValueTuple<TItem1, TItem2, TItem3, TItem4, TItem5, TItem6, TItem7> left, ImmutableValueTuple<TItem1, TItem2, TItem3, TItem4, TItem5, TItem6, TItem7> right) => left.Equals(right);

    /// <summary>
    /// Implements the operator !=.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>
    /// The result of the operator.
    /// </returns>
    public static bool operator !=(ImmutableValueTuple<TItem1, TItem2, TItem3, TItem4, TItem5, TItem6, TItem7> left, ImmutableValueTuple<TItem1, TItem2, TItem3, TItem4, TItem5, TItem6, TItem7> right) => !(left == right);

    /// <summary>
    /// Equates this instance to another object.
    /// </summary>
    /// <param name="other">The other object to equate to.</param>
    /// <returns><c>true</c> if the two tuples are equals, <c>false</c> otherwise.</returns>
    public override bool Equals(object? other) =>
        other is ImmutableValueTuple<TItem1, TItem2, TItem3, TItem4, TItem5, TItem6, TItem7> otherTuple && Equals(otherTuple);

    /// <summary>
    /// Equates this tuple to another tuple.
    /// </summary>
    /// <param name="other">The other tuple to equate to.</param>
    /// <returns><c>true</c> if the two tuples are equals, <c>false</c> otherwise.</returns>
    public bool Equals(ImmutableValueTuple<TItem1, TItem2, TItem3, TItem4, TItem5, TItem6, TItem7> other) =>
        EqualityComparer<TItem1>.Default.Equals(Item1, other.Item1) &&
            EqualityComparer<TItem2>.Default.Equals(Item2, other.Item2) &&
            EqualityComparer<TItem3>.Default.Equals(Item3, other.Item3) &&
            EqualityComparer<TItem4>.Default.Equals(Item4, other.Item4) &&
            EqualityComparer<TItem5>.Default.Equals(Item5, other.Item5) &&
            EqualityComparer<TItem6>.Default.Equals(Item6, other.Item6) &&
            EqualityComparer<TItem7>.Default.Equals(Item7, other.Item7);

    /// <summary>
    /// Returns a hash code for this instance.
    /// </summary>
    /// <returns>
    /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
    /// </returns>
    public override int GetHashCode() =>
        (Item1, Item2, Item3, Item4, Item5, Item6, Item7).GetHashCode();
}

/// <summary>
/// An immutable value tuple.
/// </summary>
/// <typeparam name="TItem1">The type of the item at index 1.</typeparam>
/// <typeparam name="TItem2">The type of the item at index 2.</typeparam>
/// <typeparam name="TItem3">The type of the item at index 3.</typeparam>
/// <typeparam name="TItem4">The type of the item at index 4.</typeparam>
/// <typeparam name="TItem5">The type of the item at index 5.</typeparam>
/// <typeparam name="TItem6">The type of the item at index 6.</typeparam>
/// <typeparam name="TItem7">The type of the item at index 7.</typeparam>
/// <typeparam name="TItem8">The type of the item at index 8.</typeparam>
public readonly struct ImmutableValueTuple<TItem1, TItem2, TItem3, TItem4, TItem5, TItem6, TItem7, TItem8> : IEquatable<ImmutableValueTuple<TItem1, TItem2, TItem3, TItem4, TItem5, TItem6, TItem7, TItem8>>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ImmutableValueTuple{TItem1, TItem2, TItem3, TItem4, TItem5, TItem6, TItem7, TItem8}"/> struct.
    /// </summary>
    /// <param name="item1">The value of the item at index 1.</param>
    /// <param name="item2">The value of the item at index 2.</param>
    /// <param name="item3">The value of the item at index 3.</param>
    /// <param name="item4">The value of the item at index 4.</param>
    /// <param name="item5">The value of the item at index 5.</param>
    /// <param name="item6">The value of the item at index 6.</param>
    /// <param name="item7">The value of the item at index 7.</param>
    /// <param name="item8">The value of the item at index 8.</param>
    public ImmutableValueTuple(TItem1 item1, TItem2 item2, TItem3 item3, TItem4 item4, TItem5 item5, TItem6 item6, TItem7 item7, TItem8 item8)
    {
        Item1 = item1;
        Item2 = item2;
        Item3 = item3;
        Item4 = item4;
        Item5 = item5;
        Item6 = item6;
        Item7 = item7;
        Item8 = item8;
    }

    /// <summary>
    /// Gets the item at index 1.
    /// </summary>
    public TItem1 Item1
    {
        get;
    }

    /// <summary>
    /// Gets the item at index 2.
    /// </summary>
    public TItem2 Item2
    {
        get;
    }

    /// <summary>
    /// Gets the item at index 3.
    /// </summary>
    public TItem3 Item3
    {
        get;
    }

    /// <summary>
    /// Gets the item at index 4.
    /// </summary>
    public TItem4 Item4
    {
        get;
    }

    /// <summary>
    /// Gets the item at index 5.
    /// </summary>
    public TItem5 Item5
    {
        get;
    }

    /// <summary>
    /// Gets the item at index 6.
    /// </summary>
    public TItem6 Item6
    {
        get;
    }

    /// <summary>
    /// Gets the item at index 7.
    /// </summary>
    public TItem7 Item7
    {
        get;
    }

    /// <summary>
    /// Gets the item at index 8.
    /// </summary>
    public TItem8 Item8
    {
        get;
    }

    /// <summary>
    /// Implements the operator ==.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>
    /// The result of the operator.
    /// </returns>
    public static bool operator ==(ImmutableValueTuple<TItem1, TItem2, TItem3, TItem4, TItem5, TItem6, TItem7, TItem8> left, ImmutableValueTuple<TItem1, TItem2, TItem3, TItem4, TItem5, TItem6, TItem7, TItem8> right) => left.Equals(right);

    /// <summary>
    /// Implements the operator !=.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>
    /// The result of the operator.
    /// </returns>
    public static bool operator !=(ImmutableValueTuple<TItem1, TItem2, TItem3, TItem4, TItem5, TItem6, TItem7, TItem8> left, ImmutableValueTuple<TItem1, TItem2, TItem3, TItem4, TItem5, TItem6, TItem7, TItem8> right) => !(left == right);

    /// <summary>
    /// Equates this instance to another object.
    /// </summary>
    /// <param name="other">The other object to equate to.</param>
    /// <returns><c>true</c> if the two tuples are equals, <c>false</c> otherwise.</returns>
    public override bool Equals(object? other) =>
        other is ImmutableValueTuple<TItem1, TItem2, TItem3, TItem4, TItem5, TItem6, TItem7, TItem8> otherTuple && Equals(otherTuple);

    /// <summary>
    /// Equates this tuple to another tuple.
    /// </summary>
    /// <param name="other">The other tuple to equate to.</param>
    /// <returns><c>true</c> if the two tuples are equals, <c>false</c> otherwise.</returns>
    public bool Equals(ImmutableValueTuple<TItem1, TItem2, TItem3, TItem4, TItem5, TItem6, TItem7, TItem8> other) =>
        EqualityComparer<TItem1>.Default.Equals(Item1, other.Item1) &&
            EqualityComparer<TItem2>.Default.Equals(Item2, other.Item2) &&
            EqualityComparer<TItem3>.Default.Equals(Item3, other.Item3) &&
            EqualityComparer<TItem4>.Default.Equals(Item4, other.Item4) &&
            EqualityComparer<TItem5>.Default.Equals(Item5, other.Item5) &&
            EqualityComparer<TItem6>.Default.Equals(Item6, other.Item6) &&
            EqualityComparer<TItem7>.Default.Equals(Item7, other.Item7) &&
            EqualityComparer<TItem8>.Default.Equals(Item8, other.Item8);

    /// <summary>
    /// Returns a hash code for this instance.
    /// </summary>
    /// <returns>
    /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
    /// </returns>
    public override int GetHashCode() =>
        (Item1, Item2, Item3, Item4, Item5, Item6, Item7, Item8).GetHashCode();
}
#pragma warning restore SA1402 // File may only contain a single type