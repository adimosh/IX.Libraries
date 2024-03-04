using System.Diagnostics.CodeAnalysis;

using GlobalCollectionsGeneric = System.Collections.Generic;

namespace IX.Library.Collections;

/// <summary>
///     Represents a variable-size last-in first-out (LIFO) collection of instances of the same specified type.
/// </summary>
/// <typeparam name="T">The type of elements in the stack.</typeparam>
/// <seealso cref="GlobalCollectionsGeneric.Stack{T}" />
/// <seealso cref="IX.Library.Collections.IStack{T}" />
[SuppressMessage(
    "Design",
    "CA1010:Generic interface should also be implemented",
    Justification = "This is not necessary.")]
public class Stack<T> : GlobalCollectionsGeneric.Stack<T>,
    IStack<T>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="IX.Library.Collections.Stack{T}" /> class.
    /// </summary>
    public Stack() { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="IX.Library.Collections.Stack{T}" /> class.
    /// </summary>
    /// <param name="capacity">The initial number of elements that the <see cref="IX.Library.Collections.Stack{T}" /> can contain.</param>
    public Stack(int capacity)
        : base(capacity) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="IX.Library.Collections.Stack{T}" /> class.
    /// </summary>
    /// <param name="collection">The collection to copy elements from.</param>
    public Stack(IEnumerable<T> collection)
        : base(collection) { }

    /// <summary>
    ///     Gets a value indicating whether this stack is empty.
    /// </summary>
    /// <value>
    ///     <c>true</c> if this stack is empty; otherwise, <c>false</c>.
    /// </value>
    public bool IsEmpty => Count == 0;

    /// <summary>
    ///     Converts from a standard .NET stack.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <returns>An IX Framework abstracted stack.</returns>
    public static Stack<T> FromStack(GlobalCollectionsGeneric.Stack<T> source) =>
        new((source ?? throw new ArgumentNullException(nameof(source))).ToArray());

    /// <summary>
    ///     Pushes a range of elements to the top of the stack.
    /// </summary>
    /// <param name="items">The item range to push.</param>
    /// <exception cref="ArgumentNullException">
    ///     items
    ///     is <c>null</c> (<c>Nothing</c> in Visual Basic).
    /// </exception>
    public void PushRange(T[] items)
    {
        foreach (T? item in items ?? throw new ArgumentNullException(nameof(items)))
        {
            Push(item);
        }
    }

    /// <summary>
    ///     Pushes a range of elements to the top of the stack.
    /// </summary>
    /// <param name="items">The item range to push.</param>
    /// <param name="startIndex">The start index.</param>
    /// <param name="count">The number of items to push.</param>
    /// <exception cref="ArgumentNullException">
    ///     items
    ///     is <c>null</c> (<c>Nothing</c> in Visual Basic).
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     startIndex
    ///     or
    ///     count
    ///     represent an out-of-range set of arguments relative to the input array.
    /// </exception>
    public void PushRange(
        T[] items,
        int startIndex,
        int count)
    {
        if (items is null) throw new ArgumentNullException(nameof(items));
        Requires.ValidArrayRange(
            in startIndex,
            in count,
            items,
            nameof(items));

        for (var i = startIndex; i < items.Length; i++)
        {
            Push(items[i]);
        }
    }

    #if !FRAMEWORK_ADVANCED
    /// <summary>
    ///     Attempts to peek at the topmost item from the stack, without removing it.
    /// </summary>
    /// <param name="item">The topmost element in the stack, default if unsuccessful.</param>
    /// <returns>
    ///     <see langword="true" /> if an item is peeked at successfully, <see langword="false" /> otherwise, or if the
    ///     stack is empty.
    /// </returns>
    public bool TryPeek([MaybeNullWhen(false)] out T item)
    {
        if (Count == 0)
        {
            item = default;
            return false;
        }

        item = Peek();
        return true;
    }

    /// <summary>
    ///     Attempts to pop the topmost item from the stack, and remove it if successful.
    /// </summary>
    /// <param name="item">The topmost element in the stack, default if unsuccessful.</param>
    /// <returns>
    ///     <see langword="true" /> if an item is popped successfully, <see langword="false" /> otherwise, or if the
    ///     stack is empty.
    /// </returns>
    public bool TryPop([MaybeNullWhen(false)] out T item)
    {
        if (Count == 0)
        {
            item = default;
            return false;
        }

        item = Pop();
        return true;
    }
    #endif
}