using System.Diagnostics.CodeAnalysis;

namespace IX.Library.Collections;

/// <summary>
///     Extensions for array types.
/// </summary>
public static partial class ArrayExtensions
{
    /// <summary>
    ///     Deep clones an array.
    /// </summary>
    /// <typeparam name="T">The type of the items of the array to clone.</typeparam>
    /// <param name="source">The source array.</param>
    /// <returns>An array of deeply-copied elements from the original array.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="source" /> is <see langword="null" /> (
    ///     <see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public static T[] DeepClone<T>(this T[] source)
        where T : IDeepCloneable<T>
    {
        var length = (source ?? throw new ArgumentNullException(nameof(source))).Length;

        var destination = new T[length];

        for (var i = 0; i < length; i++)
        {
            destination[i] = source[i].DeepClone();
        }

        return destination;
    }

    /// <summary>
    ///     Copies an array with shallow clones of its items.
    /// </summary>
    /// <typeparam name="T">The type of the items of the array to clone.</typeparam>
    /// <param name="source">The source array.</param>
    /// <returns>An array of deeply-copied elements from the original array.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="source" /> is <see langword="null" /> (
    ///     <see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public static T[] CopyWithShallowClones<T>(this T[] source)
        where T : IShallowCloneable<T>
    {
        var length = (source ?? throw new ArgumentNullException(nameof(source))).Length;

        var destination = new T[length];

        for (var i = 0; i < length; i++)
        {
            destination[i] = source[i].ShallowClone();
        }

        return destination;
    }

    /// <summary>
    ///     Copies all items in the specified source array to a new array.
    /// </summary>
    /// <typeparam name="T">The type of the array items.</typeparam>
    /// <param name="source">The source array.</param>
    /// <returns>A new array with items copied.</returns>
    /// <remarks>
    ///     <para>
    ///         This method copies all items by reference for reference types. Their instance will be the same as the
    ///         original source array.
    ///     </para>
    ///     <para>If deep cloning is required, please use the <see cref="DeepClone{T}(T[])" /> instead of this method.</para>
    ///     <para>Value types are value-copied.</para>
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="source" /> is <see langword="null" /> (
    ///     <see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public static T[] Copy<T>(this T[] source)
    {
        var length = (source ?? throw new ArgumentNullException(nameof(source))).Length;

        var destination = new T[length];

        Array.Copy(
            source,
            destination,
            length);

        return destination;
    }

    /// <summary>
    ///     Copies all items in the specified source array to a new array.
    /// </summary>
    /// <typeparam name="T">The type of the array items.</typeparam>
    /// <param name="source">The source array.</param>
    /// <param name="length">The length of the sub-array to copy.</param>
    /// <returns>A new array with items copied.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="source" /> is <see langword="null" /> (
    ///     <see langword="Nothing" /> in Visual Basic).
    /// </exception>
    /// <exception cref="ArgumentException">
    ///     <paramref name="length" /> is greater than 0
    ///     or
    ///     the length exceeds the bounds of the source array.
    /// </exception>
    /// <remarks>
    ///     <para>
    ///         This method copies all items by reference for reference types. Their instance will be the same as the
    ///         original source array.
    ///     </para>
    ///     <para>If deep cloning is required, please use the <see cref="DeepClone{T}(T[])" /> instead of this method.</para>
    ///     <para>Value types are value-copied.</para>
    /// </remarks>
    public static T[] Copy<T>(
        this T[] source,
        int length)
    {
        Requires.ValidArrayLength(
            in length,
            source ?? throw new ArgumentNullException(nameof(source)),
            nameof(length));

        var destination = new T[length];

        Array.Copy(
            source,
            destination,
            length);

        return destination;
    }

    /// <summary>
    ///     Copies all items in the specified source array to a new array.
    /// </summary>
    /// <typeparam name="T">The type of the array items.</typeparam>
    /// <param name="source">The source array.</param>
    /// <param name="sourceIndex">The index at which to start.</param>
    /// <param name="length">The length of the sub-array to copy.</param>
    /// <returns>A new array with items copied.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="source" /> is <see langword="null" /> (
    ///     <see langword="Nothing" /> in Visual Basic).
    /// </exception>
    /// <exception cref="ArgumentException">
    ///     <paramref name="sourceIndex" /> is less than 0 or greater than the size of the array
    ///     or
    ///     <paramref name="length" /> is greater than 0
    ///     or
    ///     the source index and length exceed the bounds of the source array.
    /// </exception>
    /// <remarks>
    ///     <para>
    ///         This method copies all items by reference for reference types. Their instance will be the same as the
    ///         original source array.
    ///     </para>
    ///     <para>If deep cloning is required, please use the <see cref="DeepClone{T}(T[])" /> instead of this method.</para>
    ///     <para>Value types are value-copied.</para>
    /// </remarks>
    public static T[] Copy<T>(
        this T[] source,
        int sourceIndex,
        int length)
    {
        Requires.ValidArrayRange(
            in sourceIndex,
            in length,
            source ?? throw new ArgumentNullException(nameof(source)),
            nameof(length));

        var destination = new T[length];

        Array.Copy(
            source,
            sourceIndex,
            destination,
            0,
            length);

        return destination;
    }

    /// <summary>
    ///     Executes an action for each one of the elements of an array.
    /// </summary>
    /// <typeparam name="T">The array type.</typeparam>
    /// <param name="source">The array to run on.</param>
    /// <param name="action">The action to execute.</param>
    /// <exception cref="ArgumentNullException">
    ///     Thrown when <paramref name="source" /> or <paramref name="action" /> is
    ///     <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    [SuppressMessage(
        "ReSharper",
        "ForCanBeConvertedToForeach",
        Justification = "Yes, but we don't want that to happen. We're interested in top performance in the loop.")]
    public static void ForEach<T>(
        this T[] source,
        Action<T> action)
    {
        if (source is null) throw new ArgumentNullException(nameof(source));
        if (action is null) throw new ArgumentNullException(nameof(action));

        for (var i = 0; i < source.Length; i++)
        {
            action(source[i]);
        }
    }

    /// <summary>
    ///     Asynchronously executes an action for each one of the elements of an array.
    /// </summary>
    /// <typeparam name="T">The array type.</typeparam>
    /// <param name="source">The array to run on.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation.</returns>
    /// <exception cref="ArgumentNullException">
    ///     Thrown when <paramref name="source" /> or <paramref name="action" /> is
    ///     <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    /// <remarks>
    ///     <para>This method, due to multiple awaits, is considered to be very slow compared to its synchronous version.</para>
    ///     <para>Please make sure to only use this where asynchronicity is required.</para>
    ///     <para>In CPU-intensive operations, only its synchronous counterpart should be used.</para>
    /// </remarks>
    [SuppressMessage(
        "ReSharper",
        "ForCanBeConvertedToForeach",
        Justification = "Yes, but we don't want that to happen. We're interested in top performance in the loop.")]
    public static async ValueTask ForEachAsync<T>(
        this T[] source,
        Func<T, Task> action,
        CancellationToken cancellationToken = default)
    {
        if (source is null) throw new ArgumentNullException(nameof(source));
        if (action is null) throw new ArgumentNullException(nameof(action));

        if (cancellationToken.IsCancellationRequested)
        {
            return;
        }

        for (var i = 0; i < source.Length; i++)
        {
            await action(source[i]);
            cancellationToken.ThrowIfCancellationRequested();
        }
    }

    /// <summary>
    ///     Asynchronously executes an action for each one of the elements of an array.
    /// </summary>
    /// <typeparam name="T">The array type.</typeparam>
    /// <param name="source">The array to run on.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation.</returns>
    /// <exception cref="ArgumentNullException">
    ///     Thrown when <paramref name="source" /> or <paramref name="action" /> is
    ///     <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    /// <remarks>
    ///     <para>This method, due to multiple awaits, is considered to be very slow compared to its synchronous version.</para>
    ///     <para>Please make sure to only use this where asynchronicity is required.</para>
    ///     <para>In CPU-intensive operations, only its synchronous counterpart should be used.</para>
    /// </remarks>
    [SuppressMessage(
        "ReSharper",
        "ForCanBeConvertedToForeach",
        Justification = "Yes, but we don't want that to happen. We're interested in top performance in the loop.")]
    public static async ValueTask ForEachAsync<T>(
        this T[] source,
        Func<T, ValueTask> action,
        CancellationToken cancellationToken = default)
    {
        if (source is null) throw new ArgumentNullException(nameof(source));
        if (action is null) throw new ArgumentNullException(nameof(action));

        if (cancellationToken.IsCancellationRequested)
        {
            return;
        }

        for (var i = 0; i < source.Length; i++)
        {
            await action(source[i]);
            cancellationToken.ThrowIfCancellationRequested();
        }
    }

    /// <summary>
    ///     Asynchronously executes an action for each one of the elements of an array.
    /// </summary>
    /// <typeparam name="T">The array type.</typeparam>
    /// <param name="source">The array to run on.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation.</returns>
    /// <exception cref="ArgumentNullException">
    ///     Thrown when <paramref name="source" /> or <paramref name="action" /> is
    ///     <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    /// <remarks>
    ///     <para>This method, due to multiple awaits, is considered to be very slow compared to its synchronous version.</para>
    ///     <para>Please make sure to only use this where asynchronicity is required.</para>
    ///     <para>In CPU-intensive operations, only its synchronous counterpart should be used.</para>
    /// </remarks>
    [SuppressMessage(
        "ReSharper",
        "ForCanBeConvertedToForeach",
        Justification = "Yes, but we don't want that to happen. We're interested in top performance in the loop.")]
    public static async ValueTask ForEachAsync<T>(
        this T[] source,
        Func<T, CancellationToken, Task> action,
        CancellationToken cancellationToken = default)
    {
        if (source is null) throw new ArgumentNullException(nameof(source));
        if (action is null) throw new ArgumentNullException(nameof(action));

        if (cancellationToken.IsCancellationRequested)
        {
            return;
        }

        for (var i = 0; i < source.Length; i++)
        {
            await action(source[i], cancellationToken);
            cancellationToken.ThrowIfCancellationRequested();
        }
    }

    /// <summary>
    ///     Asynchronously executes an action for each one of the elements of an array.
    /// </summary>
    /// <typeparam name="T">The array type.</typeparam>
    /// <param name="source">The array to run on.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation.</returns>
    /// <exception cref="ArgumentNullException">
    ///     Thrown when <paramref name="source" /> or <paramref name="action" /> is
    ///     <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    /// <remarks>
    ///     <para>This method, due to multiple awaits, is considered to be very slow compared to its synchronous version.</para>
    ///     <para>Please make sure to only use this where asynchronicity is required.</para>
    ///     <para>In CPU-intensive operations, only its synchronous counterpart should be used.</para>
    /// </remarks>
    [SuppressMessage(
        "ReSharper",
        "ForCanBeConvertedToForeach",
        Justification = "Yes, but we don't want that to happen. We're interested in top performance in the loop.")]
    public static async ValueTask ForEachAsync<T>(
        this T[] source,
        Func<T, CancellationToken, ValueTask> action,
        CancellationToken cancellationToken = default)
    {
        if (source is null) throw new ArgumentNullException(nameof(source));
        if (action is null) throw new ArgumentNullException(nameof(action));

        if (cancellationToken.IsCancellationRequested)
        {
            return;
        }

        for (var i = 0; i < source.Length; i++)
        {
            await action(source[i], cancellationToken);
            cancellationToken.ThrowIfCancellationRequested();
        }
    }
}