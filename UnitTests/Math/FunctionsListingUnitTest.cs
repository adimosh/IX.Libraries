using IX.Math;

namespace UnitTests.Math;

/// <summary>
///     Tests for function listings.
/// </summary>
public class FunctionsListingUnitTest
{
    /// <summary>
    ///     Test functionality that gets the available functions test.
    /// </summary>
    [Fact(DisplayName = "Test getting available functions and parameters.")]
    public void GetAvailableFunctionsTest()
    {
        using var service = new ExpressionParsingService();

        var functions = service.GetRegisteredFunctions();

        Assert.True(functions.Length > 0);
    }
}