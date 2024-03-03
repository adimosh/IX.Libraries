namespace UnitTests.Math;

/// <summary>
///     Test data for IX.Math tests.
/// </summary>
public static partial class TestData
{
    /// <summary>
    ///     Provides templated text data.
    /// </summary>
    /// <returns>Test data.</returns>
    public static object?[][] GenerateDataObjects() => BasicOperatorsWithRandomNumbers().Union(SpecialCases()).ToArray();
}