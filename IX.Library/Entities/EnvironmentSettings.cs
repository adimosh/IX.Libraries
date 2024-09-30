namespace IX.Library.Entities;

/// <summary>
/// Environment settings for entity-related extensions.
/// </summary>
public static class EnvironmentSettings
{
    /// <summary>
    /// Environment settings for pagination extensions.
    /// </summary>
    public static class Pagination
    {
        /// <summary>
        /// Gets or sets a default page size for pagination scenarios.
        /// </summary>
        public static int DefaultPageSize { get; set; } = 10;
    }
}