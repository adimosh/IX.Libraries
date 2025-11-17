using System.Diagnostics.CodeAnalysis;

namespace IX.Library.Entities;

/// <summary>
/// Extensions for <see cref="IEnumerable{T}"/>, <see cref="IQueryable{T}"/> and derived interfaces.
/// </summary>
public static class QueryableExtensions
{
    /// <summary>
    /// Filters the <see cref="IEntityWithStartEnd"/>-implementing entities further by a specific snapshot moment.
    /// </summary>
    /// <typeparam name="TEntity">The type of entities in the collection.</typeparam>
    /// <param name="collection">The collection to filter.</param>
    /// <param name="snapshot">The moment of the snapshot to filter by.</param>
    /// <returns>The initial collection, possibly further refined by the snapshot moment.</returns>
    [SuppressMessage(
        "Performance",
        "HAA0302:Display class allocation to capture closure",
        Justification = "Usage across function boundaries in LINQ.")]
    [SuppressMessage(
        "Performance",
        "HAA0301:Closure Allocation Source",
        Justification = "Usage across function boundaries in LINQ.")]
    [SuppressMessage(
        "Performance",
        "HAA0303:Lambda or anonymous method in a generic method allocates a delegate instance",
        Justification = "Usage across function boundaries in LINQ.")]
    public static IEnumerable<TEntity> WithSnapshot<TEntity>(
        this IEnumerable<TEntity> collection,
        DateTime snapshot)
        where TEntity : IEntityWithStartEnd => collection.Where(
        p => p.StartedAt <= snapshot && (p.EndedAt == null || p.EndedAt >= snapshot));

    /// <summary>
    /// Filters the <see cref="IEntityWithStartEnd"/>-implementing entities further by a specific snapshot moment.
    /// </summary>
    /// <typeparam name="TEntity">The type of entities in the query.</typeparam>
    /// <param name="query">The query to filter.</param>
    /// <param name="snapshot">The moment of the snapshot to filter by.</param>
    /// <returns>The query, possibly further refined by the snapshot moment.</returns>
    [SuppressMessage(
        "Performance",
        "HAA0302:Display class allocation to capture closure",
        Justification = "Usage across function boundaries in LINQ.")]
    [SuppressMessage(
        "Performance",
        "HAA0301:Closure Allocation Source",
        Justification = "Usage across function boundaries in LINQ.")]
    [SuppressMessage(
        "Performance",
        "HAA0303:Lambda or anonymous method in a generic method allocates a delegate instance",
        Justification = "Usage across function boundaries in LINQ.")]
    public static IQueryable<TEntity> WithSnapshot<TEntity>(
        this IQueryable<TEntity> query,
        DateTime snapshot)
        where TEntity : IEntityWithStartEnd => query.Where(
        p => p.StartedAt <= snapshot && (p.EndedAt == null || p.EndedAt >= snapshot));
    /// <summary>
    ///     Paginates a query with either page number and size semantics, or skip/take semantics.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity in the queried collection.</typeparam>
    /// <param name="query">The query object.</param>
    /// <param name="pageNumber">The current page number.</param>
    /// <param name="pageSize">The page size.</param>
    /// <param name="skip">The number of items to skip.</param>
    /// <param name="take">The number of items to take.</param>
    /// <returns>A query that is paginated or has skip/take semantics, or the original query if no semantics are defined.</returns>
    /// <remarks>
    ///     <para>The skip/take semantics take precedence over the page number and size semantics.</para>
    ///     <para>
    ///         The page size uses a default value expressed at <see cref="EnvironmentSettings.Pagination.DefaultPageSize" />
    ///         .
    ///     </para>
    ///     <para>If no pagination is specified, the query is returned as-is.</para>
    /// </remarks>
    public static IQueryable<TEntity> Paginate<TEntity>(
        this IQueryable<TEntity> query,
        int? pageNumber = default,
        int? pageSize = default,
        int? skip = default,
        int? take = default)
    {
        ArgumentNullException.ThrowIfNull(query);

        if (skip != null)
        {
            // Skip/take semantics
            return take == null
                ? query.Skip(skip.Value)
                : query.Skip(skip.Value)
                    .Take(take.Value);
        }

        if (take != null)
        {
            return query.Take(take.Value);
        }

        if (pageNumber == null)
        {
            // No skip/take, no page number and size
            return query;
        }

        // Paginated semantics
        var skip2 = (pageNumber.Value - 1) * (pageSize ?? EnvironmentSettings.Pagination.DefaultPageSize);
        var take2 = pageSize ?? EnvironmentSettings.Pagination.DefaultPageSize;

        return query.Skip(skip2)
            .Take(take2);
    }
}