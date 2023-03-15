using System.Diagnostics.CodeAnalysis;

namespace IX.Core.Entities;

/// <summary>
/// Extensions for <see cref="IEnumerable{T}"/>, <see cref="IQueryable{T}"/> and derived interfaces.
/// </summary>
[PublicAPI]
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
}