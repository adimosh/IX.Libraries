using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace IX.Library.Collections;

/// <summary>
///     Extension methods for LINQ.
/// </summary>
[SuppressMessage(
    "Performance",
    "HAA0401:Possible allocation of reference type enumerator",
    Justification = "These are enumerator extensions, so this is unavoidable.")]
public static partial class LinqExtensions
{
    #region 1 parameters

    #region Any

    /// <summary>
    ///     Executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a positive result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    /// <returns><c>false</c> if all the predicates have returned a negative result, <c>true</c> otherwise.</returns>
    public static bool Any<TItem, TParam1>(
        this IEnumerable<TItem> source,
        Func<TItem,
        TParam1, bool> predicate,
        TParam1 param1)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (predicate(item, param1))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a positive result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>false</c> if all the predicates have returned a negative result, <c>true</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AnyAsync<TItem, TParam1>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, Task<bool>> predicate,
        TParam1 param1,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await predicate(item, param1))
            {
                return true;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return false;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a positive result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>false</c> if all the predicates have returned a negative result, <c>true</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AnyAsync<TItem, TParam1>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, ValueTask<bool>> predicate,
        TParam1 param1,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await predicate(item, param1))
            {
                return true;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return false;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a positive result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>false</c> if all the predicates have returned a negative result, <c>true</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AnyAsync<TItem, TParam1>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, CancellationToken, Task<bool>> predicate,
        TParam1 param1,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await predicate(item, param1, cancellationToken))
            {
                return true;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return false;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a positive result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>false</c> if all the predicates have returned a negative result, <c>true</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AnyAsync<TItem, TParam1>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, CancellationToken, ValueTask<bool>> predicate,
        TParam1 param1,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await predicate(item, param1, cancellationToken))
            {
                return true;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return false;
    }

    #endregion

    #region All

    /// <summary>
    ///     Executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a negative result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    /// <returns><c>true</c> if all the predicates have returned a positive result, <c>false</c> otherwise.</returns>
    public static bool All<TItem, TParam1>(
        this IEnumerable<TItem> source,
        Func<TItem,
        TParam1, bool> predicate,
        TParam1 param1)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (!predicate(item, param1))
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a negative result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>true</c> if all the predicates have returned a positive result, <c>false</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AllAsync<TItem, TParam1>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, Task<bool>> predicate,
        TParam1 param1,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (!await predicate(item, param1))
            {
                return false;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return true;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a negative result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>true</c> if all the predicates have returned a positive result, <c>false</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AllAsync<TItem, TParam1>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, ValueTask<bool>> predicate,
        TParam1 param1,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (!await predicate(item, param1))
            {
                return false;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return true;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a negative result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>true</c> if all the predicates have returned a positive result, <c>false</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AllAsync<TItem, TParam1>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, CancellationToken, Task<bool>> predicate,
        TParam1 param1,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (!await predicate(item, param1, cancellationToken))
            {
                return false;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return true;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a negative result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>true</c> if all the predicates have returned a positive result, <c>false</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AllAsync<TItem, TParam1>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, CancellationToken, ValueTask<bool>> predicate,
        TParam1 param1,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (!await predicate(item, param1, cancellationToken))
            {
                return false;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return true;
    }

    #endregion

    #region Where

    /// <summary>
    ///     Filters a sequence of values based on a predicate.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to filter.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <returns>The filtered enumerable.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static IEnumerable<TItem> Where<TItem, TParam1>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, bool> action,
        TParam1 param1)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (action(item, param1))
            {
                yield return item;
            }
        }
    }

    /// <summary>
    ///     Asynchronously filters a sequence of values based on a predicate.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to filter.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The filtered enumerable.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async IAsyncEnumerable<TItem> WhereAsync<TItem, TParam1>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, Task<bool>> action,
        TParam1 param1,
        [EnumeratorCancellation]
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1))
            {
                yield return item;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }
    }

    /// <summary>
    ///     Asynchronously filters a sequence of values based on a predicate.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to filter.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The filtered enumerable.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async IAsyncEnumerable<TItem> WhereAsync<TItem, TParam1>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, ValueTask<bool>> action,
        TParam1 param1,
        [EnumeratorCancellation]
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1))
            {
                yield return item;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }
    }

    /// <summary>
    ///     Asynchronously filters a sequence of values based on a predicate.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to filter.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The filtered enumerable.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async IAsyncEnumerable<TItem> WhereAsync<TItem, TParam1>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, CancellationToken, Task<bool>> action,
        TParam1 param1,
        [EnumeratorCancellation]
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, cancellationToken))
            {
                yield return item;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }
    }

    /// <summary>
    ///     Asynchronously filters a sequence of values based on a predicate.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to filter.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The filtered enumerable.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async IAsyncEnumerable<TItem> WhereAsync<TItem, TParam1>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, CancellationToken, ValueTask<bool>> action,
        TParam1 param1,
        [EnumeratorCancellation]
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, cancellationToken))
            {
                yield return item;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }
    }

    #endregion

    #region FirstOrDefault

    /// <summary>
    ///     Returns the first element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <returns>The first filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static TItem FirstOrDefault<TItem, TParam1>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, bool> action,
        TParam1 param1)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (action(item, param1))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the first element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The first filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> FirstOrDefaultAsync<TItem, TParam1>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, Task<bool>> action,
        TParam1 param1,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the first element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The first filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> FirstOrDefaultAsync<TItem, TParam1>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, ValueTask<bool>> action,
        TParam1 param1,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the first element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The first filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> FirstOrDefaultAsync<TItem, TParam1>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, CancellationToken, Task<bool>> action,
        TParam1 param1,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, cancellationToken))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the first element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The first filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> FirstOrDefaultAsync<TItem, TParam1>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, CancellationToken, ValueTask<bool>> action,
        TParam1 param1,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, cancellationToken))
            {
                return item;
            }
        }

        return default!;
    }

    #endregion

    #region LastOrDefault

    /// <summary>
    ///     Returns the last element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <returns>The last filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static TItem LastOrDefault<TItem, TParam1>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, bool> action,
        TParam1 param1)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in (source ?? throw new ArgumentNullException(nameof(source))).Reverse())
        {
            if (action(item, param1))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the last element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The last filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> LastOrDefaultAsync<TItem, TParam1>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, Task<bool>> action,
        TParam1 param1,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in (source ?? throw new ArgumentNullException(nameof(source))).Reverse())
        {
            if (await action(item, param1))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the last element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The last filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> LastOrDefaultAsync<TItem, TParam1>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, ValueTask<bool>> action,
        TParam1 param1,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in (source ?? throw new ArgumentNullException(nameof(source))).Reverse())
        {
            if (await action(item, param1))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the last element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The last filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> LastOrDefaultAsync<TItem, TParam1>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, CancellationToken, Task<bool>> action,
        TParam1 param1,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in (source ?? throw new ArgumentNullException(nameof(source))).Reverse())
        {
            if (await action(item, param1, cancellationToken))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the last element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The last filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> LastOrDefaultAsync<TItem, TParam1>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, CancellationToken, ValueTask<bool>> action,
        TParam1 param1,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in (source ?? throw new ArgumentNullException(nameof(source))).Reverse())
        {
            if (await action(item, param1, cancellationToken))
            {
                return item;
            }
        }

        return default!;
    }

    #endregion

    #endregion

    #region 2 parameters

    #region Any

    /// <summary>
    ///     Executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a positive result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    /// <returns><c>false</c> if all the predicates have returned a negative result, <c>true</c> otherwise.</returns>
    public static bool Any<TItem, TParam1, TParam2>(
        this IEnumerable<TItem> source,
        Func<TItem,
        TParam1, TParam2, bool> predicate,
        TParam1 param1,
        TParam2 param2)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (predicate(item, param1, param2))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a positive result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>false</c> if all the predicates have returned a negative result, <c>true</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AnyAsync<TItem, TParam1, TParam2>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, Task<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await predicate(item, param1, param2))
            {
                return true;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return false;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a positive result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>false</c> if all the predicates have returned a negative result, <c>true</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AnyAsync<TItem, TParam1, TParam2>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, ValueTask<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await predicate(item, param1, param2))
            {
                return true;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return false;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a positive result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>false</c> if all the predicates have returned a negative result, <c>true</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AnyAsync<TItem, TParam1, TParam2>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, CancellationToken, Task<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await predicate(item, param1, param2, cancellationToken))
            {
                return true;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return false;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a positive result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>false</c> if all the predicates have returned a negative result, <c>true</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AnyAsync<TItem, TParam1, TParam2>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, CancellationToken, ValueTask<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await predicate(item, param1, param2, cancellationToken))
            {
                return true;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return false;
    }

    #endregion

    #region All

    /// <summary>
    ///     Executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a negative result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    /// <returns><c>true</c> if all the predicates have returned a positive result, <c>false</c> otherwise.</returns>
    public static bool All<TItem, TParam1, TParam2>(
        this IEnumerable<TItem> source,
        Func<TItem,
        TParam1, TParam2, bool> predicate,
        TParam1 param1,
        TParam2 param2)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (!predicate(item, param1, param2))
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a negative result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>true</c> if all the predicates have returned a positive result, <c>false</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AllAsync<TItem, TParam1, TParam2>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, Task<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (!await predicate(item, param1, param2))
            {
                return false;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return true;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a negative result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>true</c> if all the predicates have returned a positive result, <c>false</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AllAsync<TItem, TParam1, TParam2>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, ValueTask<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (!await predicate(item, param1, param2))
            {
                return false;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return true;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a negative result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>true</c> if all the predicates have returned a positive result, <c>false</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AllAsync<TItem, TParam1, TParam2>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, CancellationToken, Task<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (!await predicate(item, param1, param2, cancellationToken))
            {
                return false;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return true;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a negative result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>true</c> if all the predicates have returned a positive result, <c>false</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AllAsync<TItem, TParam1, TParam2>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, CancellationToken, ValueTask<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (!await predicate(item, param1, param2, cancellationToken))
            {
                return false;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return true;
    }

    #endregion

    #region Where

    /// <summary>
    ///     Filters a sequence of values based on a predicate.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to filter.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <returns>The filtered enumerable.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static IEnumerable<TItem> Where<TItem, TParam1, TParam2>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, bool> action,
        TParam1 param1,
        TParam2 param2)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (action(item, param1, param2))
            {
                yield return item;
            }
        }
    }

    /// <summary>
    ///     Asynchronously filters a sequence of values based on a predicate.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to filter.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The filtered enumerable.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async IAsyncEnumerable<TItem> WhereAsync<TItem, TParam1, TParam2>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, Task<bool>> action,
        TParam1 param1,
        TParam2 param2,
        [EnumeratorCancellation]
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2))
            {
                yield return item;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }
    }

    /// <summary>
    ///     Asynchronously filters a sequence of values based on a predicate.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to filter.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The filtered enumerable.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async IAsyncEnumerable<TItem> WhereAsync<TItem, TParam1, TParam2>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, ValueTask<bool>> action,
        TParam1 param1,
        TParam2 param2,
        [EnumeratorCancellation]
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2))
            {
                yield return item;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }
    }

    /// <summary>
    ///     Asynchronously filters a sequence of values based on a predicate.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to filter.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The filtered enumerable.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async IAsyncEnumerable<TItem> WhereAsync<TItem, TParam1, TParam2>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, CancellationToken, Task<bool>> action,
        TParam1 param1,
        TParam2 param2,
        [EnumeratorCancellation]
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2, cancellationToken))
            {
                yield return item;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }
    }

    /// <summary>
    ///     Asynchronously filters a sequence of values based on a predicate.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to filter.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The filtered enumerable.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async IAsyncEnumerable<TItem> WhereAsync<TItem, TParam1, TParam2>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, CancellationToken, ValueTask<bool>> action,
        TParam1 param1,
        TParam2 param2,
        [EnumeratorCancellation]
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2, cancellationToken))
            {
                yield return item;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }
    }

    #endregion

    #region FirstOrDefault

    /// <summary>
    ///     Returns the first element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <returns>The first filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static TItem FirstOrDefault<TItem, TParam1, TParam2>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, bool> action,
        TParam1 param1,
        TParam2 param2)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (action(item, param1, param2))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the first element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The first filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> FirstOrDefaultAsync<TItem, TParam1, TParam2>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, Task<bool>> action,
        TParam1 param1,
        TParam2 param2,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the first element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The first filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> FirstOrDefaultAsync<TItem, TParam1, TParam2>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, ValueTask<bool>> action,
        TParam1 param1,
        TParam2 param2,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the first element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The first filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> FirstOrDefaultAsync<TItem, TParam1, TParam2>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, CancellationToken, Task<bool>> action,
        TParam1 param1,
        TParam2 param2,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2, cancellationToken))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the first element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The first filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> FirstOrDefaultAsync<TItem, TParam1, TParam2>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, CancellationToken, ValueTask<bool>> action,
        TParam1 param1,
        TParam2 param2,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2, cancellationToken))
            {
                return item;
            }
        }

        return default!;
    }

    #endregion

    #region LastOrDefault

    /// <summary>
    ///     Returns the last element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <returns>The last filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static TItem LastOrDefault<TItem, TParam1, TParam2>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, bool> action,
        TParam1 param1,
        TParam2 param2)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in (source ?? throw new ArgumentNullException(nameof(source))).Reverse())
        {
            if (action(item, param1, param2))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the last element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The last filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> LastOrDefaultAsync<TItem, TParam1, TParam2>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, Task<bool>> action,
        TParam1 param1,
        TParam2 param2,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in (source ?? throw new ArgumentNullException(nameof(source))).Reverse())
        {
            if (await action(item, param1, param2))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the last element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The last filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> LastOrDefaultAsync<TItem, TParam1, TParam2>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, ValueTask<bool>> action,
        TParam1 param1,
        TParam2 param2,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in (source ?? throw new ArgumentNullException(nameof(source))).Reverse())
        {
            if (await action(item, param1, param2))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the last element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The last filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> LastOrDefaultAsync<TItem, TParam1, TParam2>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, CancellationToken, Task<bool>> action,
        TParam1 param1,
        TParam2 param2,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in (source ?? throw new ArgumentNullException(nameof(source))).Reverse())
        {
            if (await action(item, param1, param2, cancellationToken))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the last element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The last filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> LastOrDefaultAsync<TItem, TParam1, TParam2>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, CancellationToken, ValueTask<bool>> action,
        TParam1 param1,
        TParam2 param2,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in (source ?? throw new ArgumentNullException(nameof(source))).Reverse())
        {
            if (await action(item, param1, param2, cancellationToken))
            {
                return item;
            }
        }

        return default!;
    }

    #endregion

    #endregion

    #region 3 parameters

    #region Any

    /// <summary>
    ///     Executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a positive result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    /// <returns><c>false</c> if all the predicates have returned a negative result, <c>true</c> otherwise.</returns>
    public static bool Any<TItem, TParam1, TParam2, TParam3>(
        this IEnumerable<TItem> source,
        Func<TItem,
        TParam1, TParam2, TParam3, bool> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (predicate(item, param1, param2, param3))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a positive result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>false</c> if all the predicates have returned a negative result, <c>true</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AnyAsync<TItem, TParam1, TParam2, TParam3>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, Task<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await predicate(item, param1, param2, param3))
            {
                return true;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return false;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a positive result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>false</c> if all the predicates have returned a negative result, <c>true</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AnyAsync<TItem, TParam1, TParam2, TParam3>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, ValueTask<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await predicate(item, param1, param2, param3))
            {
                return true;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return false;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a positive result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>false</c> if all the predicates have returned a negative result, <c>true</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AnyAsync<TItem, TParam1, TParam2, TParam3>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, CancellationToken, Task<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await predicate(item, param1, param2, param3, cancellationToken))
            {
                return true;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return false;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a positive result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>false</c> if all the predicates have returned a negative result, <c>true</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AnyAsync<TItem, TParam1, TParam2, TParam3>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, CancellationToken, ValueTask<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await predicate(item, param1, param2, param3, cancellationToken))
            {
                return true;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return false;
    }

    #endregion

    #region All

    /// <summary>
    ///     Executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a negative result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    /// <returns><c>true</c> if all the predicates have returned a positive result, <c>false</c> otherwise.</returns>
    public static bool All<TItem, TParam1, TParam2, TParam3>(
        this IEnumerable<TItem> source,
        Func<TItem,
        TParam1, TParam2, TParam3, bool> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (!predicate(item, param1, param2, param3))
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a negative result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>true</c> if all the predicates have returned a positive result, <c>false</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AllAsync<TItem, TParam1, TParam2, TParam3>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, Task<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (!await predicate(item, param1, param2, param3))
            {
                return false;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return true;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a negative result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>true</c> if all the predicates have returned a positive result, <c>false</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AllAsync<TItem, TParam1, TParam2, TParam3>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, ValueTask<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (!await predicate(item, param1, param2, param3))
            {
                return false;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return true;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a negative result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>true</c> if all the predicates have returned a positive result, <c>false</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AllAsync<TItem, TParam1, TParam2, TParam3>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, CancellationToken, Task<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (!await predicate(item, param1, param2, param3, cancellationToken))
            {
                return false;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return true;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a negative result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>true</c> if all the predicates have returned a positive result, <c>false</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AllAsync<TItem, TParam1, TParam2, TParam3>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, CancellationToken, ValueTask<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (!await predicate(item, param1, param2, param3, cancellationToken))
            {
                return false;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return true;
    }

    #endregion

    #region Where

    /// <summary>
    ///     Filters a sequence of values based on a predicate.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to filter.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <returns>The filtered enumerable.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static IEnumerable<TItem> Where<TItem, TParam1, TParam2, TParam3>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, bool> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (action(item, param1, param2, param3))
            {
                yield return item;
            }
        }
    }

    /// <summary>
    ///     Asynchronously filters a sequence of values based on a predicate.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to filter.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The filtered enumerable.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async IAsyncEnumerable<TItem> WhereAsync<TItem, TParam1, TParam2, TParam3>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, Task<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        [EnumeratorCancellation]
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2, param3))
            {
                yield return item;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }
    }

    /// <summary>
    ///     Asynchronously filters a sequence of values based on a predicate.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to filter.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The filtered enumerable.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async IAsyncEnumerable<TItem> WhereAsync<TItem, TParam1, TParam2, TParam3>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, ValueTask<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        [EnumeratorCancellation]
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2, param3))
            {
                yield return item;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }
    }

    /// <summary>
    ///     Asynchronously filters a sequence of values based on a predicate.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to filter.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The filtered enumerable.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async IAsyncEnumerable<TItem> WhereAsync<TItem, TParam1, TParam2, TParam3>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, CancellationToken, Task<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        [EnumeratorCancellation]
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2, param3, cancellationToken))
            {
                yield return item;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }
    }

    /// <summary>
    ///     Asynchronously filters a sequence of values based on a predicate.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to filter.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The filtered enumerable.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async IAsyncEnumerable<TItem> WhereAsync<TItem, TParam1, TParam2, TParam3>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, CancellationToken, ValueTask<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        [EnumeratorCancellation]
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2, param3, cancellationToken))
            {
                yield return item;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }
    }

    #endregion

    #region FirstOrDefault

    /// <summary>
    ///     Returns the first element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <returns>The first filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static TItem FirstOrDefault<TItem, TParam1, TParam2, TParam3>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, bool> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (action(item, param1, param2, param3))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the first element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The first filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> FirstOrDefaultAsync<TItem, TParam1, TParam2, TParam3>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, Task<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2, param3))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the first element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The first filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> FirstOrDefaultAsync<TItem, TParam1, TParam2, TParam3>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, ValueTask<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2, param3))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the first element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The first filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> FirstOrDefaultAsync<TItem, TParam1, TParam2, TParam3>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, CancellationToken, Task<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2, param3, cancellationToken))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the first element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The first filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> FirstOrDefaultAsync<TItem, TParam1, TParam2, TParam3>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, CancellationToken, ValueTask<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2, param3, cancellationToken))
            {
                return item;
            }
        }

        return default!;
    }

    #endregion

    #region LastOrDefault

    /// <summary>
    ///     Returns the last element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <returns>The last filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static TItem LastOrDefault<TItem, TParam1, TParam2, TParam3>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, bool> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in (source ?? throw new ArgumentNullException(nameof(source))).Reverse())
        {
            if (action(item, param1, param2, param3))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the last element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The last filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> LastOrDefaultAsync<TItem, TParam1, TParam2, TParam3>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, Task<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in (source ?? throw new ArgumentNullException(nameof(source))).Reverse())
        {
            if (await action(item, param1, param2, param3))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the last element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The last filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> LastOrDefaultAsync<TItem, TParam1, TParam2, TParam3>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, ValueTask<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in (source ?? throw new ArgumentNullException(nameof(source))).Reverse())
        {
            if (await action(item, param1, param2, param3))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the last element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The last filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> LastOrDefaultAsync<TItem, TParam1, TParam2, TParam3>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, CancellationToken, Task<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in (source ?? throw new ArgumentNullException(nameof(source))).Reverse())
        {
            if (await action(item, param1, param2, param3, cancellationToken))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the last element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The last filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> LastOrDefaultAsync<TItem, TParam1, TParam2, TParam3>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, CancellationToken, ValueTask<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in (source ?? throw new ArgumentNullException(nameof(source))).Reverse())
        {
            if (await action(item, param1, param2, param3, cancellationToken))
            {
                return item;
            }
        }

        return default!;
    }

    #endregion

    #endregion

    #region 4 parameters

    #region Any

    /// <summary>
    ///     Executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a positive result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    /// <returns><c>false</c> if all the predicates have returned a negative result, <c>true</c> otherwise.</returns>
    public static bool Any<TItem, TParam1, TParam2, TParam3, TParam4>(
        this IEnumerable<TItem> source,
        Func<TItem,
        TParam1, TParam2, TParam3, TParam4, bool> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (predicate(item, param1, param2, param3, param4))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a positive result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>false</c> if all the predicates have returned a negative result, <c>true</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AnyAsync<TItem, TParam1, TParam2, TParam3, TParam4>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, Task<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await predicate(item, param1, param2, param3, param4))
            {
                return true;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return false;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a positive result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>false</c> if all the predicates have returned a negative result, <c>true</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AnyAsync<TItem, TParam1, TParam2, TParam3, TParam4>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, ValueTask<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await predicate(item, param1, param2, param3, param4))
            {
                return true;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return false;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a positive result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>false</c> if all the predicates have returned a negative result, <c>true</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AnyAsync<TItem, TParam1, TParam2, TParam3, TParam4>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, CancellationToken, Task<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await predicate(item, param1, param2, param3, param4, cancellationToken))
            {
                return true;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return false;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a positive result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>false</c> if all the predicates have returned a negative result, <c>true</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AnyAsync<TItem, TParam1, TParam2, TParam3, TParam4>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, CancellationToken, ValueTask<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await predicate(item, param1, param2, param3, param4, cancellationToken))
            {
                return true;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return false;
    }

    #endregion

    #region All

    /// <summary>
    ///     Executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a negative result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    /// <returns><c>true</c> if all the predicates have returned a positive result, <c>false</c> otherwise.</returns>
    public static bool All<TItem, TParam1, TParam2, TParam3, TParam4>(
        this IEnumerable<TItem> source,
        Func<TItem,
        TParam1, TParam2, TParam3, TParam4, bool> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (!predicate(item, param1, param2, param3, param4))
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a negative result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>true</c> if all the predicates have returned a positive result, <c>false</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AllAsync<TItem, TParam1, TParam2, TParam3, TParam4>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, Task<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (!await predicate(item, param1, param2, param3, param4))
            {
                return false;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return true;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a negative result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>true</c> if all the predicates have returned a positive result, <c>false</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AllAsync<TItem, TParam1, TParam2, TParam3, TParam4>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, ValueTask<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (!await predicate(item, param1, param2, param3, param4))
            {
                return false;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return true;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a negative result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>true</c> if all the predicates have returned a positive result, <c>false</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AllAsync<TItem, TParam1, TParam2, TParam3, TParam4>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, CancellationToken, Task<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (!await predicate(item, param1, param2, param3, param4, cancellationToken))
            {
                return false;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return true;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a negative result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>true</c> if all the predicates have returned a positive result, <c>false</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AllAsync<TItem, TParam1, TParam2, TParam3, TParam4>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, CancellationToken, ValueTask<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (!await predicate(item, param1, param2, param3, param4, cancellationToken))
            {
                return false;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return true;
    }

    #endregion

    #region Where

    /// <summary>
    ///     Filters a sequence of values based on a predicate.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to filter.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <returns>The filtered enumerable.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static IEnumerable<TItem> Where<TItem, TParam1, TParam2, TParam3, TParam4>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, bool> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (action(item, param1, param2, param3, param4))
            {
                yield return item;
            }
        }
    }

    /// <summary>
    ///     Asynchronously filters a sequence of values based on a predicate.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to filter.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The filtered enumerable.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async IAsyncEnumerable<TItem> WhereAsync<TItem, TParam1, TParam2, TParam3, TParam4>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, Task<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        [EnumeratorCancellation]
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2, param3, param4))
            {
                yield return item;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }
    }

    /// <summary>
    ///     Asynchronously filters a sequence of values based on a predicate.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to filter.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The filtered enumerable.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async IAsyncEnumerable<TItem> WhereAsync<TItem, TParam1, TParam2, TParam3, TParam4>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, ValueTask<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        [EnumeratorCancellation]
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2, param3, param4))
            {
                yield return item;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }
    }

    /// <summary>
    ///     Asynchronously filters a sequence of values based on a predicate.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to filter.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The filtered enumerable.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async IAsyncEnumerable<TItem> WhereAsync<TItem, TParam1, TParam2, TParam3, TParam4>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, CancellationToken, Task<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        [EnumeratorCancellation]
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2, param3, param4, cancellationToken))
            {
                yield return item;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }
    }

    /// <summary>
    ///     Asynchronously filters a sequence of values based on a predicate.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to filter.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The filtered enumerable.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async IAsyncEnumerable<TItem> WhereAsync<TItem, TParam1, TParam2, TParam3, TParam4>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, CancellationToken, ValueTask<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        [EnumeratorCancellation]
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2, param3, param4, cancellationToken))
            {
                yield return item;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }
    }

    #endregion

    #region FirstOrDefault

    /// <summary>
    ///     Returns the first element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <returns>The first filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static TItem FirstOrDefault<TItem, TParam1, TParam2, TParam3, TParam4>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, bool> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (action(item, param1, param2, param3, param4))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the first element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The first filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> FirstOrDefaultAsync<TItem, TParam1, TParam2, TParam3, TParam4>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, Task<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2, param3, param4))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the first element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The first filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> FirstOrDefaultAsync<TItem, TParam1, TParam2, TParam3, TParam4>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, ValueTask<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2, param3, param4))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the first element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The first filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> FirstOrDefaultAsync<TItem, TParam1, TParam2, TParam3, TParam4>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, CancellationToken, Task<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2, param3, param4, cancellationToken))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the first element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The first filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> FirstOrDefaultAsync<TItem, TParam1, TParam2, TParam3, TParam4>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, CancellationToken, ValueTask<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2, param3, param4, cancellationToken))
            {
                return item;
            }
        }

        return default!;
    }

    #endregion

    #region LastOrDefault

    /// <summary>
    ///     Returns the last element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <returns>The last filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static TItem LastOrDefault<TItem, TParam1, TParam2, TParam3, TParam4>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, bool> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in (source ?? throw new ArgumentNullException(nameof(source))).Reverse())
        {
            if (action(item, param1, param2, param3, param4))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the last element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The last filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> LastOrDefaultAsync<TItem, TParam1, TParam2, TParam3, TParam4>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, Task<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in (source ?? throw new ArgumentNullException(nameof(source))).Reverse())
        {
            if (await action(item, param1, param2, param3, param4))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the last element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The last filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> LastOrDefaultAsync<TItem, TParam1, TParam2, TParam3, TParam4>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, ValueTask<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in (source ?? throw new ArgumentNullException(nameof(source))).Reverse())
        {
            if (await action(item, param1, param2, param3, param4))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the last element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The last filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> LastOrDefaultAsync<TItem, TParam1, TParam2, TParam3, TParam4>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, CancellationToken, Task<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in (source ?? throw new ArgumentNullException(nameof(source))).Reverse())
        {
            if (await action(item, param1, param2, param3, param4, cancellationToken))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the last element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The last filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> LastOrDefaultAsync<TItem, TParam1, TParam2, TParam3, TParam4>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, CancellationToken, ValueTask<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in (source ?? throw new ArgumentNullException(nameof(source))).Reverse())
        {
            if (await action(item, param1, param2, param3, param4, cancellationToken))
            {
                return item;
            }
        }

        return default!;
    }

    #endregion

    #endregion

    #region 5 parameters

    #region Any

    /// <summary>
    ///     Executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a positive result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    /// <returns><c>false</c> if all the predicates have returned a negative result, <c>true</c> otherwise.</returns>
    public static bool Any<TItem, TParam1, TParam2, TParam3, TParam4, TParam5>(
        this IEnumerable<TItem> source,
        Func<TItem,
        TParam1, TParam2, TParam3, TParam4, TParam5, bool> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (predicate(item, param1, param2, param3, param4, param5))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a positive result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>false</c> if all the predicates have returned a negative result, <c>true</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AnyAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, Task<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await predicate(item, param1, param2, param3, param4, param5))
            {
                return true;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return false;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a positive result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>false</c> if all the predicates have returned a negative result, <c>true</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AnyAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, ValueTask<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await predicate(item, param1, param2, param3, param4, param5))
            {
                return true;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return false;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a positive result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>false</c> if all the predicates have returned a negative result, <c>true</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AnyAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, CancellationToken, Task<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await predicate(item, param1, param2, param3, param4, param5, cancellationToken))
            {
                return true;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return false;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a positive result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>false</c> if all the predicates have returned a negative result, <c>true</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AnyAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, CancellationToken, ValueTask<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await predicate(item, param1, param2, param3, param4, param5, cancellationToken))
            {
                return true;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return false;
    }

    #endregion

    #region All

    /// <summary>
    ///     Executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a negative result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    /// <returns><c>true</c> if all the predicates have returned a positive result, <c>false</c> otherwise.</returns>
    public static bool All<TItem, TParam1, TParam2, TParam3, TParam4, TParam5>(
        this IEnumerable<TItem> source,
        Func<TItem,
        TParam1, TParam2, TParam3, TParam4, TParam5, bool> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (!predicate(item, param1, param2, param3, param4, param5))
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a negative result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>true</c> if all the predicates have returned a positive result, <c>false</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AllAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, Task<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (!await predicate(item, param1, param2, param3, param4, param5))
            {
                return false;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return true;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a negative result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>true</c> if all the predicates have returned a positive result, <c>false</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AllAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, ValueTask<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (!await predicate(item, param1, param2, param3, param4, param5))
            {
                return false;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return true;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a negative result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>true</c> if all the predicates have returned a positive result, <c>false</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AllAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, CancellationToken, Task<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (!await predicate(item, param1, param2, param3, param4, param5, cancellationToken))
            {
                return false;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return true;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a negative result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>true</c> if all the predicates have returned a positive result, <c>false</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AllAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, CancellationToken, ValueTask<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (!await predicate(item, param1, param2, param3, param4, param5, cancellationToken))
            {
                return false;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return true;
    }

    #endregion

    #region Where

    /// <summary>
    ///     Filters a sequence of values based on a predicate.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to filter.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <returns>The filtered enumerable.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static IEnumerable<TItem> Where<TItem, TParam1, TParam2, TParam3, TParam4, TParam5>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, bool> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (action(item, param1, param2, param3, param4, param5))
            {
                yield return item;
            }
        }
    }

    /// <summary>
    ///     Asynchronously filters a sequence of values based on a predicate.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to filter.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The filtered enumerable.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async IAsyncEnumerable<TItem> WhereAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, Task<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        [EnumeratorCancellation]
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2, param3, param4, param5))
            {
                yield return item;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }
    }

    /// <summary>
    ///     Asynchronously filters a sequence of values based on a predicate.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to filter.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The filtered enumerable.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async IAsyncEnumerable<TItem> WhereAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, ValueTask<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        [EnumeratorCancellation]
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2, param3, param4, param5))
            {
                yield return item;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }
    }

    /// <summary>
    ///     Asynchronously filters a sequence of values based on a predicate.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to filter.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The filtered enumerable.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async IAsyncEnumerable<TItem> WhereAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, CancellationToken, Task<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        [EnumeratorCancellation]
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2, param3, param4, param5, cancellationToken))
            {
                yield return item;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }
    }

    /// <summary>
    ///     Asynchronously filters a sequence of values based on a predicate.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to filter.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The filtered enumerable.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async IAsyncEnumerable<TItem> WhereAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, CancellationToken, ValueTask<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        [EnumeratorCancellation]
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2, param3, param4, param5, cancellationToken))
            {
                yield return item;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }
    }

    #endregion

    #region FirstOrDefault

    /// <summary>
    ///     Returns the first element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <returns>The first filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static TItem FirstOrDefault<TItem, TParam1, TParam2, TParam3, TParam4, TParam5>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, bool> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (action(item, param1, param2, param3, param4, param5))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the first element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The first filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> FirstOrDefaultAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, Task<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2, param3, param4, param5))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the first element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The first filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> FirstOrDefaultAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, ValueTask<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2, param3, param4, param5))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the first element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The first filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> FirstOrDefaultAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, CancellationToken, Task<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2, param3, param4, param5, cancellationToken))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the first element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The first filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> FirstOrDefaultAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, CancellationToken, ValueTask<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2, param3, param4, param5, cancellationToken))
            {
                return item;
            }
        }

        return default!;
    }

    #endregion

    #region LastOrDefault

    /// <summary>
    ///     Returns the last element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <returns>The last filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static TItem LastOrDefault<TItem, TParam1, TParam2, TParam3, TParam4, TParam5>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, bool> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in (source ?? throw new ArgumentNullException(nameof(source))).Reverse())
        {
            if (action(item, param1, param2, param3, param4, param5))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the last element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The last filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> LastOrDefaultAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, Task<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in (source ?? throw new ArgumentNullException(nameof(source))).Reverse())
        {
            if (await action(item, param1, param2, param3, param4, param5))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the last element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The last filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> LastOrDefaultAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, ValueTask<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in (source ?? throw new ArgumentNullException(nameof(source))).Reverse())
        {
            if (await action(item, param1, param2, param3, param4, param5))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the last element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The last filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> LastOrDefaultAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, CancellationToken, Task<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in (source ?? throw new ArgumentNullException(nameof(source))).Reverse())
        {
            if (await action(item, param1, param2, param3, param4, param5, cancellationToken))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the last element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The last filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> LastOrDefaultAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, CancellationToken, ValueTask<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in (source ?? throw new ArgumentNullException(nameof(source))).Reverse())
        {
            if (await action(item, param1, param2, param3, param4, param5, cancellationToken))
            {
                return item;
            }
        }

        return default!;
    }

    #endregion

    #endregion

    #region 6 parameters

    #region Any

    /// <summary>
    ///     Executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a positive result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    /// <returns><c>false</c> if all the predicates have returned a negative result, <c>true</c> otherwise.</returns>
    public static bool Any<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(
        this IEnumerable<TItem> source,
        Func<TItem,
        TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, bool> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (predicate(item, param1, param2, param3, param4, param5, param6))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a positive result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>false</c> if all the predicates have returned a negative result, <c>true</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AnyAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, Task<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await predicate(item, param1, param2, param3, param4, param5, param6))
            {
                return true;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return false;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a positive result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>false</c> if all the predicates have returned a negative result, <c>true</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AnyAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, ValueTask<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await predicate(item, param1, param2, param3, param4, param5, param6))
            {
                return true;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return false;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a positive result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>false</c> if all the predicates have returned a negative result, <c>true</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AnyAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, CancellationToken, Task<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await predicate(item, param1, param2, param3, param4, param5, param6, cancellationToken))
            {
                return true;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return false;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a positive result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>false</c> if all the predicates have returned a negative result, <c>true</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AnyAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, CancellationToken, ValueTask<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await predicate(item, param1, param2, param3, param4, param5, param6, cancellationToken))
            {
                return true;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return false;
    }

    #endregion

    #region All

    /// <summary>
    ///     Executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a negative result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    /// <returns><c>true</c> if all the predicates have returned a positive result, <c>false</c> otherwise.</returns>
    public static bool All<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(
        this IEnumerable<TItem> source,
        Func<TItem,
        TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, bool> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (!predicate(item, param1, param2, param3, param4, param5, param6))
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a negative result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>true</c> if all the predicates have returned a positive result, <c>false</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AllAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, Task<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (!await predicate(item, param1, param2, param3, param4, param5, param6))
            {
                return false;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return true;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a negative result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>true</c> if all the predicates have returned a positive result, <c>false</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AllAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, ValueTask<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (!await predicate(item, param1, param2, param3, param4, param5, param6))
            {
                return false;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return true;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a negative result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>true</c> if all the predicates have returned a positive result, <c>false</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AllAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, CancellationToken, Task<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (!await predicate(item, param1, param2, param3, param4, param5, param6, cancellationToken))
            {
                return false;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return true;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a negative result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>true</c> if all the predicates have returned a positive result, <c>false</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AllAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, CancellationToken, ValueTask<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (!await predicate(item, param1, param2, param3, param4, param5, param6, cancellationToken))
            {
                return false;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return true;
    }

    #endregion

    #region Where

    /// <summary>
    ///     Filters a sequence of values based on a predicate.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked predicate at index 5.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to filter.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked predicate at index 5.</param>
    /// <returns>The filtered enumerable.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static IEnumerable<TItem> Where<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, bool> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (action(item, param1, param2, param3, param4, param5, param6))
            {
                yield return item;
            }
        }
    }

    /// <summary>
    ///     Asynchronously filters a sequence of values based on a predicate.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked predicate at index 5.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to filter.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked predicate at index 5.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The filtered enumerable.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async IAsyncEnumerable<TItem> WhereAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, Task<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        [EnumeratorCancellation]
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2, param3, param4, param5, param6))
            {
                yield return item;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }
    }

    /// <summary>
    ///     Asynchronously filters a sequence of values based on a predicate.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked predicate at index 5.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to filter.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked predicate at index 5.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The filtered enumerable.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async IAsyncEnumerable<TItem> WhereAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, ValueTask<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        [EnumeratorCancellation]
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2, param3, param4, param5, param6))
            {
                yield return item;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }
    }

    /// <summary>
    ///     Asynchronously filters a sequence of values based on a predicate.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked predicate at index 5.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to filter.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked predicate at index 5.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The filtered enumerable.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async IAsyncEnumerable<TItem> WhereAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, CancellationToken, Task<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        [EnumeratorCancellation]
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2, param3, param4, param5, param6, cancellationToken))
            {
                yield return item;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }
    }

    /// <summary>
    ///     Asynchronously filters a sequence of values based on a predicate.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked predicate at index 5.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to filter.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked predicate at index 5.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The filtered enumerable.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async IAsyncEnumerable<TItem> WhereAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, CancellationToken, ValueTask<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        [EnumeratorCancellation]
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2, param3, param4, param5, param6, cancellationToken))
            {
                yield return item;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }
    }

    #endregion

    #region FirstOrDefault

    /// <summary>
    ///     Returns the first element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked predicate at index 5.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked predicate at index 5.</param>
    /// <returns>The first filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static TItem FirstOrDefault<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, bool> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (action(item, param1, param2, param3, param4, param5, param6))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the first element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked predicate at index 5.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked predicate at index 5.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The first filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> FirstOrDefaultAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, Task<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2, param3, param4, param5, param6))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the first element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked predicate at index 5.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked predicate at index 5.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The first filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> FirstOrDefaultAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, ValueTask<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2, param3, param4, param5, param6))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the first element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked predicate at index 5.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked predicate at index 5.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The first filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> FirstOrDefaultAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, CancellationToken, Task<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2, param3, param4, param5, param6, cancellationToken))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the first element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked predicate at index 5.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked predicate at index 5.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The first filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> FirstOrDefaultAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, CancellationToken, ValueTask<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2, param3, param4, param5, param6, cancellationToken))
            {
                return item;
            }
        }

        return default!;
    }

    #endregion

    #region LastOrDefault

    /// <summary>
    ///     Returns the last element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked predicate at index 5.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked predicate at index 5.</param>
    /// <returns>The last filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static TItem LastOrDefault<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, bool> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in (source ?? throw new ArgumentNullException(nameof(source))).Reverse())
        {
            if (action(item, param1, param2, param3, param4, param5, param6))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the last element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked predicate at index 5.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked predicate at index 5.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The last filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> LastOrDefaultAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, Task<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in (source ?? throw new ArgumentNullException(nameof(source))).Reverse())
        {
            if (await action(item, param1, param2, param3, param4, param5, param6))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the last element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked predicate at index 5.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked predicate at index 5.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The last filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> LastOrDefaultAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, ValueTask<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in (source ?? throw new ArgumentNullException(nameof(source))).Reverse())
        {
            if (await action(item, param1, param2, param3, param4, param5, param6))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the last element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked predicate at index 5.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked predicate at index 5.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The last filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> LastOrDefaultAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, CancellationToken, Task<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in (source ?? throw new ArgumentNullException(nameof(source))).Reverse())
        {
            if (await action(item, param1, param2, param3, param4, param5, param6, cancellationToken))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the last element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked predicate at index 5.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked predicate at index 5.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The last filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> LastOrDefaultAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, CancellationToken, ValueTask<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in (source ?? throw new ArgumentNullException(nameof(source))).Reverse())
        {
            if (await action(item, param1, param2, param3, param4, param5, param6, cancellationToken))
            {
                return item;
            }
        }

        return default!;
    }

    #endregion

    #endregion

    #region 7 parameters

    #region Any

    /// <summary>
    ///     Executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a positive result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    /// <returns><c>false</c> if all the predicates have returned a negative result, <c>true</c> otherwise.</returns>
    public static bool Any<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(
        this IEnumerable<TItem> source,
        Func<TItem,
        TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, bool> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (predicate(item, param1, param2, param3, param4, param5, param6, param7))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a positive result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>false</c> if all the predicates have returned a negative result, <c>true</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AnyAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, Task<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await predicate(item, param1, param2, param3, param4, param5, param6, param7))
            {
                return true;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return false;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a positive result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>false</c> if all the predicates have returned a negative result, <c>true</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AnyAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, ValueTask<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await predicate(item, param1, param2, param3, param4, param5, param6, param7))
            {
                return true;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return false;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a positive result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>false</c> if all the predicates have returned a negative result, <c>true</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AnyAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, CancellationToken, Task<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await predicate(item, param1, param2, param3, param4, param5, param6, param7, cancellationToken))
            {
                return true;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return false;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a positive result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>false</c> if all the predicates have returned a negative result, <c>true</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AnyAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, CancellationToken, ValueTask<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await predicate(item, param1, param2, param3, param4, param5, param6, param7, cancellationToken))
            {
                return true;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return false;
    }

    #endregion

    #region All

    /// <summary>
    ///     Executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a negative result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    /// <returns><c>true</c> if all the predicates have returned a positive result, <c>false</c> otherwise.</returns>
    public static bool All<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(
        this IEnumerable<TItem> source,
        Func<TItem,
        TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, bool> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (!predicate(item, param1, param2, param3, param4, param5, param6, param7))
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a negative result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>true</c> if all the predicates have returned a positive result, <c>false</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AllAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, Task<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (!await predicate(item, param1, param2, param3, param4, param5, param6, param7))
            {
                return false;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return true;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a negative result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>true</c> if all the predicates have returned a positive result, <c>false</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AllAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, ValueTask<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (!await predicate(item, param1, param2, param3, param4, param5, param6, param7))
            {
                return false;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return true;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a negative result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>true</c> if all the predicates have returned a positive result, <c>false</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AllAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, CancellationToken, Task<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (!await predicate(item, param1, param2, param3, param4, param5, param6, param7, cancellationToken))
            {
                return false;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return true;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a negative result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>true</c> if all the predicates have returned a positive result, <c>false</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AllAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, CancellationToken, ValueTask<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (!await predicate(item, param1, param2, param3, param4, param5, param6, param7, cancellationToken))
            {
                return false;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return true;
    }

    #endregion

    #region Where

    /// <summary>
    ///     Filters a sequence of values based on a predicate.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked predicate at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked predicate at index 6.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to filter.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked predicate at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked predicate at index 6.</param>
    /// <returns>The filtered enumerable.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static IEnumerable<TItem> Where<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, bool> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (action(item, param1, param2, param3, param4, param5, param6, param7))
            {
                yield return item;
            }
        }
    }

    /// <summary>
    ///     Asynchronously filters a sequence of values based on a predicate.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked predicate at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked predicate at index 6.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to filter.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked predicate at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked predicate at index 6.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The filtered enumerable.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async IAsyncEnumerable<TItem> WhereAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, Task<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7,
        [EnumeratorCancellation]
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2, param3, param4, param5, param6, param7))
            {
                yield return item;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }
    }

    /// <summary>
    ///     Asynchronously filters a sequence of values based on a predicate.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked predicate at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked predicate at index 6.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to filter.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked predicate at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked predicate at index 6.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The filtered enumerable.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async IAsyncEnumerable<TItem> WhereAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, ValueTask<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7,
        [EnumeratorCancellation]
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2, param3, param4, param5, param6, param7))
            {
                yield return item;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }
    }

    /// <summary>
    ///     Asynchronously filters a sequence of values based on a predicate.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked predicate at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked predicate at index 6.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to filter.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked predicate at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked predicate at index 6.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The filtered enumerable.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async IAsyncEnumerable<TItem> WhereAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, CancellationToken, Task<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7,
        [EnumeratorCancellation]
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2, param3, param4, param5, param6, param7, cancellationToken))
            {
                yield return item;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }
    }

    /// <summary>
    ///     Asynchronously filters a sequence of values based on a predicate.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked predicate at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked predicate at index 6.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to filter.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked predicate at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked predicate at index 6.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The filtered enumerable.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async IAsyncEnumerable<TItem> WhereAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, CancellationToken, ValueTask<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7,
        [EnumeratorCancellation]
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2, param3, param4, param5, param6, param7, cancellationToken))
            {
                yield return item;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }
    }

    #endregion

    #region FirstOrDefault

    /// <summary>
    ///     Returns the first element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked predicate at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked predicate at index 6.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked predicate at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked predicate at index 6.</param>
    /// <returns>The first filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static TItem FirstOrDefault<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, bool> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (action(item, param1, param2, param3, param4, param5, param6, param7))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the first element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked predicate at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked predicate at index 6.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked predicate at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked predicate at index 6.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The first filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> FirstOrDefaultAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, Task<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2, param3, param4, param5, param6, param7))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the first element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked predicate at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked predicate at index 6.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked predicate at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked predicate at index 6.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The first filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> FirstOrDefaultAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, ValueTask<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2, param3, param4, param5, param6, param7))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the first element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked predicate at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked predicate at index 6.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked predicate at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked predicate at index 6.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The first filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> FirstOrDefaultAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, CancellationToken, Task<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2, param3, param4, param5, param6, param7, cancellationToken))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the first element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked predicate at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked predicate at index 6.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked predicate at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked predicate at index 6.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The first filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> FirstOrDefaultAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, CancellationToken, ValueTask<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2, param3, param4, param5, param6, param7, cancellationToken))
            {
                return item;
            }
        }

        return default!;
    }

    #endregion

    #region LastOrDefault

    /// <summary>
    ///     Returns the last element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked predicate at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked predicate at index 6.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked predicate at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked predicate at index 6.</param>
    /// <returns>The last filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static TItem LastOrDefault<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, bool> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in (source ?? throw new ArgumentNullException(nameof(source))).Reverse())
        {
            if (action(item, param1, param2, param3, param4, param5, param6, param7))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the last element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked predicate at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked predicate at index 6.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked predicate at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked predicate at index 6.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The last filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> LastOrDefaultAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, Task<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in (source ?? throw new ArgumentNullException(nameof(source))).Reverse())
        {
            if (await action(item, param1, param2, param3, param4, param5, param6, param7))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the last element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked predicate at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked predicate at index 6.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked predicate at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked predicate at index 6.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The last filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> LastOrDefaultAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, ValueTask<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in (source ?? throw new ArgumentNullException(nameof(source))).Reverse())
        {
            if (await action(item, param1, param2, param3, param4, param5, param6, param7))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the last element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked predicate at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked predicate at index 6.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked predicate at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked predicate at index 6.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The last filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> LastOrDefaultAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, CancellationToken, Task<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in (source ?? throw new ArgumentNullException(nameof(source))).Reverse())
        {
            if (await action(item, param1, param2, param3, param4, param5, param6, param7, cancellationToken))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the last element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked predicate at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked predicate at index 6.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked predicate at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked predicate at index 6.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The last filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> LastOrDefaultAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, CancellationToken, ValueTask<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in (source ?? throw new ArgumentNullException(nameof(source))).Reverse())
        {
            if (await action(item, param1, param2, param3, param4, param5, param6, param7, cancellationToken))
            {
                return item;
            }
        }

        return default!;
    }

    #endregion

    #endregion

    #region 8 parameters

    #region Any

    /// <summary>
    ///     Executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a positive result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
    /// <typeparam name="TParam8">The type of parameter to be passed to the invoked method at index 7.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
    /// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the invoked method at index 7.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    /// <returns><c>false</c> if all the predicates have returned a negative result, <c>true</c> otherwise.</returns>
    public static bool Any<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(
        this IEnumerable<TItem> source,
        Func<TItem,
        TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, bool> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7,
        TParam8 param8)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (predicate(item, param1, param2, param3, param4, param5, param6, param7, param8))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a positive result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
    /// <typeparam name="TParam8">The type of parameter to be passed to the invoked method at index 7.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
    /// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the invoked method at index 7.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>false</c> if all the predicates have returned a negative result, <c>true</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AnyAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, Task<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7,
        TParam8 param8,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await predicate(item, param1, param2, param3, param4, param5, param6, param7, param8))
            {
                return true;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return false;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a positive result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
    /// <typeparam name="TParam8">The type of parameter to be passed to the invoked method at index 7.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
    /// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the invoked method at index 7.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>false</c> if all the predicates have returned a negative result, <c>true</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AnyAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, ValueTask<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7,
        TParam8 param8,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await predicate(item, param1, param2, param3, param4, param5, param6, param7, param8))
            {
                return true;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return false;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a positive result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
    /// <typeparam name="TParam8">The type of parameter to be passed to the invoked method at index 7.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
    /// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the invoked method at index 7.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>false</c> if all the predicates have returned a negative result, <c>true</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AnyAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, CancellationToken, Task<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7,
        TParam8 param8,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await predicate(item, param1, param2, param3, param4, param5, param6, param7, param8, cancellationToken))
            {
                return true;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return false;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a positive result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
    /// <typeparam name="TParam8">The type of parameter to be passed to the invoked method at index 7.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
    /// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the invoked method at index 7.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>false</c> if all the predicates have returned a negative result, <c>true</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AnyAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, CancellationToken, ValueTask<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7,
        TParam8 param8,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await predicate(item, param1, param2, param3, param4, param5, param6, param7, param8, cancellationToken))
            {
                return true;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return false;
    }

    #endregion

    #region All

    /// <summary>
    ///     Executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a negative result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
    /// <typeparam name="TParam8">The type of parameter to be passed to the invoked method at index 7.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
    /// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the invoked method at index 7.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    /// <returns><c>true</c> if all the predicates have returned a positive result, <c>false</c> otherwise.</returns>
    public static bool All<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(
        this IEnumerable<TItem> source,
        Func<TItem,
        TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, bool> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7,
        TParam8 param8)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (!predicate(item, param1, param2, param3, param4, param5, param6, param7, param8))
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a negative result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
    /// <typeparam name="TParam8">The type of parameter to be passed to the invoked method at index 7.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
    /// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the invoked method at index 7.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>true</c> if all the predicates have returned a positive result, <c>false</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AllAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, Task<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7,
        TParam8 param8,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (!await predicate(item, param1, param2, param3, param4, param5, param6, param7, param8))
            {
                return false;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return true;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a negative result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
    /// <typeparam name="TParam8">The type of parameter to be passed to the invoked method at index 7.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
    /// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the invoked method at index 7.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>true</c> if all the predicates have returned a positive result, <c>false</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AllAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, ValueTask<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7,
        TParam8 param8,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (!await predicate(item, param1, param2, param3, param4, param5, param6, param7, param8))
            {
                return false;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return true;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a negative result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
    /// <typeparam name="TParam8">The type of parameter to be passed to the invoked method at index 7.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
    /// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the invoked method at index 7.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>true</c> if all the predicates have returned a positive result, <c>false</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AllAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, CancellationToken, Task<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7,
        TParam8 param8,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (!await predicate(item, param1, param2, param3, param4, param5, param6, param7, param8, cancellationToken))
            {
                return false;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return true;
    }

    /// <summary>
    ///     Asynchronously executes a predicate for each one of the elements of an enumerable, returning when the first predicate executing results in a negative result.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
    /// <typeparam name="TParam8">The type of parameter to be passed to the invoked method at index 7.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="predicate">The predicate to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
    /// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the invoked method at index 7.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ValueTask" /> representing the current operation, containing <c>true</c> if all the predicates have returned a positive result, <c>false</c> otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<bool> AllAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, CancellationToken, ValueTask<bool>> predicate,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7,
        TParam8 param8,
        CancellationToken cancellationToken = default)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (!await predicate(item, param1, param2, param3, param4, param5, param6, param7, param8, cancellationToken))
            {
                return false;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        return true;
    }

    #endregion

    #region Where

    /// <summary>
    ///     Filters a sequence of values based on a predicate.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked predicate at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked predicate at index 6.</typeparam>
    /// <typeparam name="TParam8">The type of parameter to be passed to the invoked predicate at index 7.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to filter.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked predicate at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked predicate at index 6.</param>
    /// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the invoked predicate at index 7.</param>
    /// <returns>The filtered enumerable.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static IEnumerable<TItem> Where<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, bool> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7,
        TParam8 param8)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (action(item, param1, param2, param3, param4, param5, param6, param7, param8))
            {
                yield return item;
            }
        }
    }

    /// <summary>
    ///     Asynchronously filters a sequence of values based on a predicate.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked predicate at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked predicate at index 6.</typeparam>
    /// <typeparam name="TParam8">The type of parameter to be passed to the invoked predicate at index 7.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to filter.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked predicate at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked predicate at index 6.</param>
    /// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the invoked predicate at index 7.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The filtered enumerable.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async IAsyncEnumerable<TItem> WhereAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, Task<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7,
        TParam8 param8,
        [EnumeratorCancellation]
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2, param3, param4, param5, param6, param7, param8))
            {
                yield return item;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }
    }

    /// <summary>
    ///     Asynchronously filters a sequence of values based on a predicate.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked predicate at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked predicate at index 6.</typeparam>
    /// <typeparam name="TParam8">The type of parameter to be passed to the invoked predicate at index 7.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to filter.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked predicate at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked predicate at index 6.</param>
    /// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the invoked predicate at index 7.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The filtered enumerable.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async IAsyncEnumerable<TItem> WhereAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, ValueTask<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7,
        TParam8 param8,
        [EnumeratorCancellation]
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2, param3, param4, param5, param6, param7, param8))
            {
                yield return item;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }
    }

    /// <summary>
    ///     Asynchronously filters a sequence of values based on a predicate.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked predicate at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked predicate at index 6.</typeparam>
    /// <typeparam name="TParam8">The type of parameter to be passed to the invoked predicate at index 7.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to filter.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked predicate at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked predicate at index 6.</param>
    /// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the invoked predicate at index 7.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The filtered enumerable.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async IAsyncEnumerable<TItem> WhereAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, CancellationToken, Task<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7,
        TParam8 param8,
        [EnumeratorCancellation]
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2, param3, param4, param5, param6, param7, param8, cancellationToken))
            {
                yield return item;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }
    }

    /// <summary>
    ///     Asynchronously filters a sequence of values based on a predicate.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked predicate at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked predicate at index 6.</typeparam>
    /// <typeparam name="TParam8">The type of parameter to be passed to the invoked predicate at index 7.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to filter.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked predicate at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked predicate at index 6.</param>
    /// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the invoked predicate at index 7.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The filtered enumerable.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async IAsyncEnumerable<TItem> WhereAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, CancellationToken, ValueTask<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7,
        TParam8 param8,
        [EnumeratorCancellation]
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2, param3, param4, param5, param6, param7, param8, cancellationToken))
            {
                yield return item;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }
    }

    #endregion

    #region FirstOrDefault

    /// <summary>
    ///     Returns the first element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked predicate at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked predicate at index 6.</typeparam>
    /// <typeparam name="TParam8">The type of parameter to be passed to the invoked predicate at index 7.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked predicate at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked predicate at index 6.</param>
    /// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the invoked predicate at index 7.</param>
    /// <returns>The first filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static TItem FirstOrDefault<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, bool> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7,
        TParam8 param8)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (action(item, param1, param2, param3, param4, param5, param6, param7, param8))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the first element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked predicate at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked predicate at index 6.</typeparam>
    /// <typeparam name="TParam8">The type of parameter to be passed to the invoked predicate at index 7.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked predicate at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked predicate at index 6.</param>
    /// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the invoked predicate at index 7.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The first filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> FirstOrDefaultAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, Task<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7,
        TParam8 param8,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2, param3, param4, param5, param6, param7, param8))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the first element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked predicate at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked predicate at index 6.</typeparam>
    /// <typeparam name="TParam8">The type of parameter to be passed to the invoked predicate at index 7.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked predicate at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked predicate at index 6.</param>
    /// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the invoked predicate at index 7.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The first filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> FirstOrDefaultAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, ValueTask<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7,
        TParam8 param8,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2, param3, param4, param5, param6, param7, param8))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the first element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked predicate at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked predicate at index 6.</typeparam>
    /// <typeparam name="TParam8">The type of parameter to be passed to the invoked predicate at index 7.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked predicate at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked predicate at index 6.</param>
    /// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the invoked predicate at index 7.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The first filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> FirstOrDefaultAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, CancellationToken, Task<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7,
        TParam8 param8,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2, param3, param4, param5, param6, param7, param8, cancellationToken))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the first element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked predicate at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked predicate at index 6.</typeparam>
    /// <typeparam name="TParam8">The type of parameter to be passed to the invoked predicate at index 7.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked predicate at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked predicate at index 6.</param>
    /// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the invoked predicate at index 7.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The first filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> FirstOrDefaultAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, CancellationToken, ValueTask<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7,
        TParam8 param8,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in source ?? throw new ArgumentNullException(nameof(source)))
        {
            if (await action(item, param1, param2, param3, param4, param5, param6, param7, param8, cancellationToken))
            {
                return item;
            }
        }

        return default!;
    }

    #endregion

    #region LastOrDefault

    /// <summary>
    ///     Returns the last element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked predicate at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked predicate at index 6.</typeparam>
    /// <typeparam name="TParam8">The type of parameter to be passed to the invoked predicate at index 7.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked predicate at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked predicate at index 6.</param>
    /// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the invoked predicate at index 7.</param>
    /// <returns>The last filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static TItem LastOrDefault<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, bool> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7,
        TParam8 param8)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in (source ?? throw new ArgumentNullException(nameof(source))).Reverse())
        {
            if (action(item, param1, param2, param3, param4, param5, param6, param7, param8))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the last element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked predicate at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked predicate at index 6.</typeparam>
    /// <typeparam name="TParam8">The type of parameter to be passed to the invoked predicate at index 7.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked predicate at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked predicate at index 6.</param>
    /// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the invoked predicate at index 7.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The last filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> LastOrDefaultAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, Task<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7,
        TParam8 param8,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in (source ?? throw new ArgumentNullException(nameof(source))).Reverse())
        {
            if (await action(item, param1, param2, param3, param4, param5, param6, param7, param8))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the last element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked predicate at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked predicate at index 6.</typeparam>
    /// <typeparam name="TParam8">The type of parameter to be passed to the invoked predicate at index 7.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked predicate at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked predicate at index 6.</param>
    /// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the invoked predicate at index 7.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The last filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> LastOrDefaultAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, ValueTask<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7,
        TParam8 param8,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in (source ?? throw new ArgumentNullException(nameof(source))).Reverse())
        {
            if (await action(item, param1, param2, param3, param4, param5, param6, param7, param8))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the last element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked predicate at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked predicate at index 6.</typeparam>
    /// <typeparam name="TParam8">The type of parameter to be passed to the invoked predicate at index 7.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked predicate at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked predicate at index 6.</param>
    /// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the invoked predicate at index 7.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The last filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> LastOrDefaultAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, CancellationToken, Task<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7,
        TParam8 param8,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in (source ?? throw new ArgumentNullException(nameof(source))).Reverse())
        {
            if (await action(item, param1, param2, param3, param4, param5, param6, param7, param8, cancellationToken))
            {
                return item;
            }
        }

        return default!;
    }

    /// <summary>
    ///     Asynchronously returns the last element of the sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked predicate at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked predicate at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked predicate at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked predicate at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked predicate at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked predicate at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked predicate at index 6.</typeparam>
    /// <typeparam name="TParam8">The type of parameter to be passed to the invoked predicate at index 7.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <param name="action">The predicate to check items with.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked predicate at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked predicate at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked predicate at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked predicate at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked predicate at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked predicate at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked predicate at index 6.</param>
    /// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the invoked predicate at index 7.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The last filtered item, or a default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> are <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static async ValueTask<TItem> LastOrDefaultAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(
        this IEnumerable<TItem> source,
        Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, CancellationToken, ValueTask<bool>> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7,
        TParam8 param8,
        CancellationToken cancellationToken = default)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (TItem item in (source ?? throw new ArgumentNullException(nameof(source))).Reverse())
        {
            if (await action(item, param1, param2, param3, param4, param5, param6, param7, param8, cancellationToken))
            {
                return item;
            }
        }

        return default!;
    }

    #endregion

    #endregion
}