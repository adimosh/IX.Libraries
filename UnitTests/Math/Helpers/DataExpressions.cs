using IX.Math;

namespace UnitTests.Math.Helpers;

/// <summary>
/// Data expressions helper.
/// </summary>
public static class DataExpressions
{
    /// <summary>
    /// Gets the objects that relate to the fixture pattern.
    /// </summary>
    /// <returns>The data objects.</returns>
    public static object?[][] GetFixturePatternObjects() =>
    [
        [
            new Func<CachedExpressionProviderFixture, IExpressionParsingService>(fix => fix.CachedService),
                null
        ],
        [
            new Func<CachedExpressionProviderFixture, IExpressionParsingService>(fix => fix.Service),
                null
        ],
        [
            new Func<CachedExpressionProviderFixture, IExpressionParsingService>(_ => new ExpressionParsingService()),
                new Action<IExpressionParsingService>(eps => eps.Dispose())
        ],
        [
            new Func<CachedExpressionProviderFixture, IExpressionParsingService>(_ => new CachedExpressionParsingService()),
                new Action<IExpressionParsingService>(eps => eps.Dispose())
        ]
    ];
}