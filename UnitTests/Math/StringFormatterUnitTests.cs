using IX.Core.DataGeneration;

using System.Globalization;
using IX.Math;
using IX.Math.Extensibility;

using System.Diagnostics.CodeAnalysis;

using UnitTests.Math.Helpers;

namespace UnitTests.Math;

/// <summary>
/// Tests with the string formatter.
/// </summary>
public class StringFormatterUnitTests : IClassFixture<CachedExpressionProviderFixture>
{
    private readonly CachedExpressionProviderFixture _fixture;

    /// <summary>
    ///     Initializes a new instance of the <see cref="StringFormatterUnitTests" /> class.
    /// </summary>
    /// <param name="fixture">The fixture.</param>
    public StringFormatterUnitTests(CachedExpressionProviderFixture fixture)
    {
        _fixture = fixture;

        void Action()
        {
            var sf = new SillyStringFormatter();
            _fixture.CachedService.RegisterTypeFormatter(sf);
            _fixture.Service.RegisterTypeFormatter(sf);
        }

        fixture.AtFirstRun(Action);
    }

    /// <summary>
    /// Tests the string formatter according to the <see cref="FactAttribute" /> of this method.
    /// </summary>
    /// <param name="create">The create method.</param>
    /// <param name="dispose">The dispose method.</param>
    [Theory(DisplayName = "String formatter test with simple expression")]
    [MemberData(nameof(DataExpressions.GetFixturePatternObjects), MemberType = typeof(DataExpressions))]
    public void Test1(
        Func<CachedExpressionProviderFixture, IExpressionParsingService> create,
        Action<IExpressionParsingService>? dispose)
    {
        // Arrange
        using var eps = new FixtureCreateDisposePatternHelper(_fixture, create, dispose);

        if (dispose != null)
        {
            eps.Service.RegisterTypeFormatter(new SillyStringFormatter());
        }

        var comparisonValue = DataGenerator.RandomNonNegativeInteger();
        var expression = $"\"The number is \" + {comparisonValue}";
        var expectedResult = $"The number is 0x{comparisonValue:x8}";

        // Act
        using var computedExpression = eps.Service.Interpret(expression);
        var result = computedExpression.Compute();

        // Assert
        Assert.Equal(
            expectedResult,
            Assert.IsType<string>(result));
    }

    /// <summary>
    /// Tests the string formatter according to the <see cref="FactAttribute"/> of this method.
    /// </summary>
    /// <param name="create">The create method.</param>
    /// <param name="dispose">The dispose method.</param>
    [Theory(DisplayName = "String formatter test with parameter expression")]
    [MemberData(nameof(DataExpressions.GetFixturePatternObjects), MemberType = typeof(DataExpressions))]
    public void Test2(
        Func<CachedExpressionProviderFixture, IExpressionParsingService> create,
        Action<IExpressionParsingService>? dispose)
    {
        // Arrange
        using var eps = new FixtureCreateDisposePatternHelper(_fixture, create, dispose);

        if (dispose != null)
        {
            eps.Service.RegisterTypeFormatter(new SillyStringFormatter());
        }

        var comparisonValue = DataGenerator.RandomNonNegativeInteger();
        var expression = $"\"The number is \" + x";
        var expectedResult = $"The number is 0x{comparisonValue:x8}";

        // Act
        using var computedExpression = eps.Service.Interpret(expression);
        var result = computedExpression.Compute(comparisonValue);

        // Assert
        Assert.Equal(expectedResult, Assert.IsType<string>(result));
    }

    /// <summary>
    /// Tests the string formatter according to the <see cref="FactAttribute"/> of this method.
    /// </summary>
    /// <param name="create">The create method.</param>
    /// <param name="dispose">The dispose method.</param>
    [Theory(DisplayName = "String formatter test with complex expression")]
    [MemberData(nameof(DataExpressions.GetFixturePatternObjects), MemberType = typeof(DataExpressions))]
    public void Test3(
        Func<CachedExpressionProviderFixture, IExpressionParsingService> create,
        Action<IExpressionParsingService>? dispose)
    {
        // Arrange
        using var eps = new FixtureCreateDisposePatternHelper(_fixture, create, dispose);

        if (dispose != null)
        {
            eps.Service.RegisterTypeFormatter(new SillyStringFormatter());
        }

        var comparisonValue1 = DataGenerator.RandomNonNegativeInteger();
        var comparisonValue2 = DataGenerator.RandomNonNegativeInteger();
        var expression = $"\"The number is \" + ({comparisonValue1} + {comparisonValue2})";
        var expectedResult = $"The number is 0x{comparisonValue1 + comparisonValue2:x8}";

        // Act
        using var computedExpression = eps.Service.Interpret(expression);
        var result = computedExpression.Compute();

        // Assert
        Assert.Equal(expectedResult, Assert.IsType<string>(result));
    }

    /// <summary>
    /// Tests the string formatter according to the <see cref="FactAttribute"/> of this method.
    /// </summary>
    /// <param name="create">The create method.</param>
    /// <param name="dispose">The dispose method.</param>
    [Theory(DisplayName = "String formatter test with complex parameter expression")]
    [MemberData(nameof(DataExpressions.GetFixturePatternObjects), MemberType = typeof(DataExpressions))]
    public void Test4(
        Func<CachedExpressionProviderFixture, IExpressionParsingService> create,
        Action<IExpressionParsingService>? dispose)
    {
        // Arrange
        using var eps = new FixtureCreateDisposePatternHelper(_fixture, create, dispose);

        if (dispose != null)
        {
            eps.Service.RegisterTypeFormatter(new SillyStringFormatter());
        }

        long comparisonValue1 = DataGenerator.RandomNonNegativeInteger();
        long comparisonValue2 = DataGenerator.RandomNonNegativeInteger();
        var expression = "\"The number is \" + (x + y)";
        var expectedResult = $"The number is 0x{comparisonValue1 + comparisonValue2:x8}";

        // Act
        using var computedExpression = eps.Service.Interpret(expression);
        var result = computedExpression.Compute(comparisonValue1, comparisonValue2);

        // Assert
        Assert.Equal(expectedResult, Assert.IsType<string>(result));
    }

    /// <summary>
    /// Tests the string formatter according to the <see cref="FactAttribute"/> of this method.
    /// </summary>
    /// <param name="create">The create method.</param>
    /// <param name="dispose">The dispose method.</param>
    [Theory(DisplayName = "String formatter test with coercion expression")]
    [MemberData(nameof(DataExpressions.GetFixturePatternObjects), MemberType = typeof(DataExpressions))]
    public void Test5(
        Func<CachedExpressionProviderFixture, IExpressionParsingService> create,
        Action<IExpressionParsingService>? dispose)
    {
        // Arrange
        using var eps = new FixtureCreateDisposePatternHelper(_fixture, create, dispose);

        if (dispose != null)
        {
            eps.Service.RegisterTypeFormatter(new SillyStringFormatter());
        }

        var comparisonValue = DataGenerator.RandomNonNegativeInteger();
        var expression = $"strlen(\"The number is \" + {comparisonValue})";
        const long expectedResult = 24;

        // Act
        using var computedExpression = eps.Service.Interpret(expression);
        var result = computedExpression.Compute();

        // Assert
        Assert.Equal(expectedResult, Assert.IsType<long>(result));
    }

    /// <summary>
    /// Tests the string formatter according to the <see cref="FactAttribute"/> of this method.
    /// </summary>
    /// <param name="create">The create method.</param>
    /// <param name="dispose">The dispose method.</param>
    [Theory(DisplayName = "String formatter test with complex expression and escape")]
    [MemberData(nameof(DataExpressions.GetFixturePatternObjects), MemberType = typeof(DataExpressions))]
    public void Test6(
        Func<CachedExpressionProviderFixture, IExpressionParsingService> create,
        Action<IExpressionParsingService>? dispose)
    {
        // Arrange
        using var eps = new FixtureCreateDisposePatternHelper(_fixture, create, dispose);

        if (dispose != null)
        {
            eps.Service.RegisterTypeFormatter(new SillyStringFormatter());
        }

        var comparisonValue1 = DataGenerator.RandomNonNegativeInteger();
        var comparisonValue2 = DataGenerator.RandomNonNegativeInteger();
        var expression = $"\"The \\\"alabalaportocala\\\" number is \" + ({comparisonValue1} + {comparisonValue2})";
        var expectedResult = $"The \\\"alabalaportocala\\\" number is 0x{comparisonValue1 + comparisonValue2:x8}";

        // Act
        using var computedExpression = eps.Service.Interpret(expression);
        var result = computedExpression.Compute();

        // Assert
        Assert.Equal(expectedResult, Assert.IsType<string>(result));
    }

    private class SillyStringFormatter : IStringFormatter
    {
        /// <summary>
        /// Parses the input data into string.
        /// </summary>
        /// <typeparam name="T">The type of data to parse.</typeparam>
        /// <param name="data">The data to parse into string.</param>
        /// <param name="parsedData">The parsed data, if the operation was a success.</param>
        /// <returns>
        ///   <c>true</c> if the parsing was successful, along with the parsing result in the out parameter, or <c>false</c> otherwise, along
        ///   with a default value.
        /// </returns>
        /// <remarks>
        /// <para>The input data will always be one of the types supported internally by the library.</para>
        /// <para>As such, you can expect <see cref="long" />, <see cref="double" />, <see cref="bool" /> and array of <see cref="byte" />.</para>
        /// </remarks>
        public bool ParseIntoString<T>(
            T data,
            [NotNullWhen(true)] out string? parsedData)
        {
            switch (data)
            {
                case long integralNumber:
                    parsedData = "0x" + integralNumber.ToString(
                        "x8",
                        CultureInfo.CurrentCulture);
                    return true;
            }

            parsedData = null;
            return false;
        }
    }
}