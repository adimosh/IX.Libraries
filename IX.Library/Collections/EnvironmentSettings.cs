namespace IX.Library.Collections;

/// <summary>
///     Environment settings for guaranteed collections.
/// </summary>
[PublicAPI]
public static class EnvironmentSettings
{
    /// <summary>
    ///     Gets or sets the persisted collections lock timeout.
    /// </summary>
    /// <value>The persisted collections lock timeout.</value>
    public static TimeSpan PersistedCollectionsLockTimeout
    {
        get;
        set;
    }
        = TimeSpan.FromSeconds(1);
}