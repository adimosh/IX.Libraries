using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace IX.Library.Collections;

/// <summary>
///     A contract for a stack.
/// </summary>
/// <typeparam name="T">The type of elements in the stack.</typeparam>
/// <seealso cref="IEnumerable{T}" />
/// <seealso cref="ICollection" />
/// <seealso cref="IReadOnlyCollection{T}" />
[PublicAPI]
[SuppressMessage(
    "ReSharper",
    "PossibleInterfaceMemberAmbiguity",
    Justification = "Member ambiguity is unavoidable when implementing ICollection")]
[SuppressMessage(
    "Design",
    "CA1010:Generic interface should also be implemented",
    Justification = "This is not necessary.")]
[SuppressMessage(
    "Naming",
    "CA1710:Identifiers should have correct suffix",
    Justification = "This is not necessary.")]
public interface IStack<T> : ICollection,
    IReadOnlyCollection<T>
{
    /// <summary>
    ///     Gets a value indicating whether this stack is empty.
    /// </summary>
    /// <value>
    ///     <c>true</c> if this stack is empty; otherwise, <c>false</c>.
    /// </value>
    bool IsEmpty { get; }

    /// <summary>
    ///     Clears the observable stack.
    /// </summary>
    void Clear();

    /// <summary>
    ///     Checks whether or not a certain item is in the stack.
    /// </summary>
    /// <param name="item">The item to check for.</param>
    /// <returns><see langword="true" /> if the item was found, <see langword="false" /> otherwise.</returns>
    bool Contains(T item);

    /// <summary>
    ///     Peeks in the stack to view the topmost item, without removing it.
    /// </summary>
    /// <returns>The topmost element in the stack, if any.</returns>
    T Peek();

    /// <summary>
    ///     Pops the topmost element from the stack, removing it.
    /// </summary>
    /// <returns>The topmost element in the stack, if any.</returns>
    T Pop();

    /// <summary>
    ///     Attempts to pop the topmost item from the stack, and remove it if successful.
    /// </summary>
    /// <param name="item">The topmost element in the stack, default if unsuccessful.</param>
    /// <returns>
    ///     <see langword="true" /> if an item is popped successfully, <see langword="false" /> otherwise, or if the
    ///     stack is empty.
    /// </returns>
    bool TryPop([MaybeNullWhen(false)] out T item);

    /// <summary>
    ///     Attempts to peek at the topmost item from the stack, without removing it.
    /// </summary>
    /// <param name="item">The topmost element in the stack, default if unsuccessful.</param>
    /// <returns>
    ///     <see langword="true" /> if an item is peeked at successfully, <see langword="false" /> otherwise, or if the
    ///     stack is empty.
    /// </returns>
    bool TryPeek([MaybeNullWhen(false)] out T item);

    /// <summary>
    ///     Pushes an element to the top of the stack.
    /// </summary>
    /// <param name="item">The item to push.</param>
    void Push(T item);

    /// <summary>
    ///     Pushes a range of elements to the top of the stack.
    /// </summary>
    /// <param name="items">The item range to push.</param>
    void PushRange(T[] items);

    /// <summary>
    ///     Pushes a range of elements to the top of the stack.
    /// </summary>
    /// <param name="items">The item range to push.</param>
    /// <param name="startIndex">The start index.</param>
    /// <param name="count">The number of items to push.</param>
    void PushRange(
        T[] items,
        int startIndex,
        int count);

    /// <summary>
    ///     Copies all elements of the stack to a new array.
    /// </summary>
    /// <returns>An array containing all items in the stack.</returns>
    T[] ToArray();

    /// <summary>
    ///     Sets the capacity to the actual number of elements in the stack if that number is less than 90 percent of current
    ///     capacity.
    /// </summary>
    void TrimExcess();
}