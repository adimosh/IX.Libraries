using IX.Math;

namespace UnitTests.Math.Helpers;

/// <summary>
/// A helper to implement the fixture service create/dispose pattern.
/// </summary>
/// <seealso cref="IDisposable" />
internal class FixtureCreateDisposePatternHelper : IDisposable
{
    private readonly Action<IExpressionParsingService>? _dispose;

    /// <summary>
    /// Initializes a new instance of the <see cref="FixtureCreateDisposePatternHelper"/> class.
    /// </summary>
    /// <param name="fixture">The fixture.</param>
    /// <param name="create">The create method.</param>
    /// <param name="dispose">The dispose.</param>
    public FixtureCreateDisposePatternHelper(
        CachedExpressionProviderFixture fixture,
        Func<CachedExpressionProviderFixture, IExpressionParsingService> create,
        Action<IExpressionParsingService>? dispose)
    {
        Service = (create ?? throw new ArgumentNullException(nameof(create)))
            .Invoke(fixture ?? throw new ArgumentNullException(nameof(fixture)));

        _dispose = dispose;
    }

    /// <summary>
    /// Gets the service.
    /// </summary>
    /// <value>
    /// The service.
    /// </value>
    public IExpressionParsingService Service { get; }

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public void Dispose() => _dispose?.Invoke(Service);
}