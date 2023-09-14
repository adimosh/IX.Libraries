namespace IX.Library.Threading;

/// <summary>
///     Environment settings for the standard extensions.
/// </summary>
[PublicAPI]
public static class EnvironmentSettings
{
    /// <summary>
    ///     Gets or sets the lock acquisition timeout.
    /// </summary>
    /// <value>The lock acquisition timeout.</value>
    /// <remarks>
    ///     <para>This timeout is generally applied to synchronization lockers, in absence of a specified value.</para>
    /// </remarks>
    public static TimeSpan LockAcquisitionTimeout { get; set; } =
        TimeSpan.FromMilliseconds(Constants.DefaultLockAcquisitionTimeout);

    /// <summary>
    ///     Environmental settings for delayed disposal.
    /// </summary>
    [PublicAPI]
    public static class DelayedDisposal
    {
        /// <summary>
        ///     Gets or sets the default disposal delay, in milliseconds.
        /// </summary>
        public static int DefaultDisposalDelayInMilliseconds { get; set; } = 10000;
    }
}