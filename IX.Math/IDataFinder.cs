namespace IX.Math;

/// <summary>
///     A contract for an external service that fetches data based on data keys.
/// </summary>
public interface IDataFinder
{
    /// <summary>
    ///     Gets data based on a data key.
    /// </summary>
    /// <param name="dataKey">The data key to search data for.</param>
    /// <param name="data">The data output, if found.</param>
    /// <returns><see langword="true" /> if data was found, <see langword="false" /> otherwise.</returns>
    bool TryGetData(
        string dataKey,
        out object data);
}