using IX.Library.DataGeneration;
using IX.Math;
using Moq;

using UnitTests.Math.Helpers;

namespace UnitTests.Math;

/// <summary>
///     Tests computed expressions.
/// </summary>
public class ToleranceUnitTest : IClassFixture<CachedExpressionProviderFixture>
{
    private readonly CachedExpressionProviderFixture fixture;

    /// <summary>
    ///     Initializes a new instance of the <see cref="ToleranceUnitTest" /> class.
    /// </summary>
    /// <param name="fixture">The fixture.</param>
    public ToleranceUnitTest(CachedExpressionProviderFixture fixture) => this.fixture = fixture;

    /// <summary>
    ///     Provides the data for theory.
    /// </summary>
    /// <returns>Theory data.</returns>
    public static object?[][] ProvideDataForTheory() => new[]
    {
        // Equation
        new object?[]
        {
            "x=y",
            new Dictionary<string, object>
            {
                ["x"] = 1.7D,
                ["y"] = 1.9D,
            },
            true,
            new Tolerance { ToleranceRangeLowerBound = 0.2, ToleranceRangeUpperBound = 0.2 },
        },
        new object?[]
        {
            "1.7=1.9",
            null,
            true,
            new Tolerance { ToleranceRangeLowerBound = 0.2, ToleranceRangeUpperBound = 0.2 },
        },
        new object?[]
        {
            "x=y",
            new Dictionary<string, object>
            {
                ["x"] = 1.7D,
                ["y"] = 1.9D,
            },
            false,
            new Tolerance { ToleranceRangeLowerBound = 0.1, ToleranceRangeUpperBound = 0.1 },
        },
        new object?[]
        {
            "1.7=1.9",
            null,
            false,
            new Tolerance { ToleranceRangeLowerBound = 0.1, ToleranceRangeUpperBound = 0.1 },
        },
        new object?[]
        {
            "x=y",
            new Dictionary<string, object>
            {
                ["x"] = 1.7D,
                ["y"] = 1.9D,
            },
            true,
            new Tolerance { ToleranceRangeLowerBound = 0.2 },
        },
        new object?[]
        {
            "1.7=1.9",
            null,
            true,
            new Tolerance { ToleranceRangeLowerBound = 0.2 },
        },
        new object?[]
        {
            "x=y",
            new Dictionary<string, object>
            {
                ["x"] = 1.7D,
                ["y"] = 1.9D,
            },
            false,
            new Tolerance { ToleranceRangeUpperBound = 0.2 },
        },
        new object?[]
        {
            "1.7=1.9",
            null,
            false,
            new Tolerance { ToleranceRangeUpperBound = 0.2 },
        },
        new object?[]
        {
            "x=y",
            new Dictionary<string, object>
            {
                ["x"] = 1.7D,
                ["y"] = 1.9D,
            },
            true,
            new Tolerance { IntegerToleranceRangeLowerBound = 1, IntegerToleranceRangeUpperBound = 1 },
        },
        new object?[]
        {
            "1.7=1.9",
            null,
            true,
            new Tolerance { IntegerToleranceRangeLowerBound = 1, IntegerToleranceRangeUpperBound = 1 },
        },
        new object?[]
        {
            "x=y",
            new Dictionary<string, object>
            {
                ["x"] = 1.7D,
                ["y"] = 1.9D,
            },
            true,
            new Tolerance { IntegerToleranceRangeLowerBound = 1 },
        },
        new object?[]
        {
            "1.7=1.9",
            null,
            true,
            new Tolerance { IntegerToleranceRangeLowerBound = 1 },
        },
        new object?[]
        {
            "x=y",
            new Dictionary<string, object>
            {
                ["x"] = 1.7D,
                ["y"] = 1.9D,
            },
            false,
            new Tolerance { IntegerToleranceRangeUpperBound = 1 },
        },
        new object?[]
        {
            "1.7=1.9",
            null,
            false,
            new Tolerance { IntegerToleranceRangeUpperBound = 1 },
        },
        new object?[]
        {
            "x=y",
            new Dictionary<string, object>
            {
                ["x"] = 0.7D,
                ["y"] = 1.9D,
            },
            false,
            new Tolerance { IntegerToleranceRangeLowerBound = 1, IntegerToleranceRangeUpperBound = 1 },
        },
        new object?[]
        {
            "0.7=1.9",
            null,
            false,
            new Tolerance { IntegerToleranceRangeLowerBound = 1, IntegerToleranceRangeUpperBound = 1 },
        },
        new object?[]
        {
            "x=y",
            new Dictionary<string, object>
            {
                ["x"] = 1.7D,
                ["y"] = 2.9D,
            },
            false,
            new Tolerance { IntegerToleranceRangeLowerBound = 1, IntegerToleranceRangeUpperBound = 1 },
        },
        new object?[]
        {
            "1.7=2.9",
            null,
            false,
            new Tolerance { IntegerToleranceRangeLowerBound = 1, IntegerToleranceRangeUpperBound = 1 },
        },
        new object?[]
        {
            "x=y",
            new Dictionary<string, object>
            {
                ["x"] = 1D,
                ["y"] = 1.5D,
            },
            false,
            new Tolerance { ProportionalTolerance = 0.1 },
        },
        new object?[]
        {
            "1=1.5",
            null,
            false,
            new Tolerance { ProportionalTolerance = 0.1 },
        },
        new object?[]
        {
            "x=y",
            new Dictionary<string, object>
            {
                ["x"] = 1D,
                ["y"] = 1.5D,
            },
            true,
            new Tolerance { ProportionalTolerance = 0.5 },
        },
        new object?[]
        {
            "1=1.5",
            null,
            true,
            new Tolerance { ProportionalTolerance = 0.5 },
        },
        new object?[]
        {
            "x=y",
            new Dictionary<string, object>
            {
                ["x"] = 1D,
                ["y"] = 1.5D,
            },
            false,
            new Tolerance { ProportionalTolerance = 1.1 },
        },
        new object?[]
        {
            "1=1.5",
            null,
            false,
            new Tolerance { ProportionalTolerance = 1.1 },
        },
        new object?[]
        {
            "x=y",
            new Dictionary<string, object>
            {
                ["x"] = 1D,
                ["y"] = 1.5D,
            },
            true,
            new Tolerance { ProportionalTolerance = 2 },
        },
        new object?[]
        {
            "1=1.5",
            null,
            true,
            new Tolerance { ProportionalTolerance = 2 },
        },

        // Negative equation
        new object?[]
        {
            "x!=y",
            new Dictionary<string, object>
            {
                ["x"] = 1.7D,
                ["y"] = 1.9D,
            },
            false,
            new Tolerance { ToleranceRangeLowerBound = 0.2, ToleranceRangeUpperBound = 0.2 },
        },
        new object?[]
        {
            "1.7!=1.9",
            null,
            false,
            new Tolerance { ToleranceRangeLowerBound = 0.2, ToleranceRangeUpperBound = 0.2 },
        },
        new object?[]
        {
            "x!=y",
            new Dictionary<string, object>
            {
                ["x"] = 1.7D,
                ["y"] = 1.9D,
            },
            true,
            new Tolerance { ToleranceRangeLowerBound = 0.1, ToleranceRangeUpperBound = 0.1 },
        },
        new object?[]
        {
            "1.7!=1.9",
            null,
            true,
            new Tolerance { ToleranceRangeLowerBound = 0.1, ToleranceRangeUpperBound = 0.1 },
        },
        new object?[]
        {
            "x!=y",
            new Dictionary<string, object>
            {
                ["x"] = 1.7D,
                ["y"] = 1.9D,
            },
            false,
            new Tolerance { ToleranceRangeLowerBound = 0.2 },
        },
        new object?[]
        {
            "1.7!=1.9",
            null,
            false,
            new Tolerance { ToleranceRangeLowerBound = 0.2 },
        },
        new object?[]
        {
            "x!=y",
            new Dictionary<string, object>
            {
                ["x"] = 1.7D,
                ["y"] = 1.9D,
            },
            true,
            new Tolerance { ToleranceRangeUpperBound = 0.2 },
        },
        new object?[]
        {
            "1.7!=1.9",
            null,
            true,
            new Tolerance { ToleranceRangeUpperBound = 0.2 },
        },
        new object?[]
        {
            "x!=y",
            new Dictionary<string, object>
            {
                ["x"] = 1.7D,
                ["y"] = 1.9D,
            },
            false,
            new Tolerance { IntegerToleranceRangeLowerBound = 1, IntegerToleranceRangeUpperBound = 1 },
        },
        new object?[]
        {
            "1.7!=1.9",
            null,
            false,
            new Tolerance { IntegerToleranceRangeLowerBound = 1, IntegerToleranceRangeUpperBound = 1 },
        },
        new object?[]
        {
            "x!=y",
            new Dictionary<string, object>
            {
                ["x"] = 1.7D,
                ["y"] = 1.9D,
            },
            false,
            new Tolerance { IntegerToleranceRangeLowerBound = 1 },
        },
        new object?[]
        {
            "1.7!=1.9",
            null,
            false,
            new Tolerance { IntegerToleranceRangeLowerBound = 1 },
        },
        new object?[]
        {
            "x!=y",
            new Dictionary<string, object>
            {
                ["x"] = 1.7D,
                ["y"] = 1.9D,
            },
            true,
            new Tolerance { IntegerToleranceRangeUpperBound = 1 },
        },
        new object?[]
        {
            "1.7!=1.9",
            null,
            true,
            new Tolerance { IntegerToleranceRangeUpperBound = 1 },
        },
        new object?[]
        {
            "x!=y",
            new Dictionary<string, object>
            {
                ["x"] = 0.7D,
                ["y"] = 1.9D,
            },
            true,
            new Tolerance { IntegerToleranceRangeLowerBound = 1, IntegerToleranceRangeUpperBound = 1 },
        },
        new object?[]
        {
            "0.7!=1.9",
            null,
            true,
            new Tolerance { IntegerToleranceRangeLowerBound = 1, IntegerToleranceRangeUpperBound = 1 },
        },
        new object?[]
        {
            "x!=y",
            new Dictionary<string, object>
            {
                ["x"] = 1.7D,
                ["y"] = 2.9D,
            },
            true,
            new Tolerance { IntegerToleranceRangeLowerBound = 1, IntegerToleranceRangeUpperBound = 1 },
        },
        new object?[]
        {
            "1.7!=2.9",
            null,
            true,
            new Tolerance { IntegerToleranceRangeLowerBound = 1, IntegerToleranceRangeUpperBound = 1 },
        },
        new object?[]
        {
            "x!=y",
            new Dictionary<string, object>
            {
                ["x"] = 1D,
                ["y"] = 1.5D,
            },
            true,
            new Tolerance { ProportionalTolerance = 0.1 },
        },
        new object?[]
        {
            "1!=1.5",
            null,
            true,
            new Tolerance { ProportionalTolerance = 0.1 },
        },
        new object?[]
        {
            "x!=y",
            new Dictionary<string, object>
            {
                ["x"] = 1D,
                ["y"] = 1.5D,
            },
            false,
            new Tolerance { ProportionalTolerance = 0.5 },
        },
        new object?[]
        {
            "1!=1.5",
            null,
            false,
            new Tolerance { ProportionalTolerance = 0.5 },
        },
        new object?[]
        {
            "x!=y",
            new Dictionary<string, object>
            {
                ["x"] = 1D,
                ["y"] = 1.5D,
            },
            true,
            new Tolerance { ProportionalTolerance = 1.1 },
        },
        new object?[]
        {
            "1!=1.5",
            null,
            true,
            new Tolerance { ProportionalTolerance = 1.1 },
        },
        new object?[]
        {
            "x!=y",
            new Dictionary<string, object>
            {
                ["x"] = 1D,
                ["y"] = 1.5D,
            },
            false,
            new Tolerance { ProportionalTolerance = 2 },
        },
        new object?[]
        {
            "1!=1.5",
            null,
            false,
            new Tolerance { ProportionalTolerance = 2 },
        },

        // Greater than
        new object?[]
        {
            "x>y",
            new Dictionary<string, object>
            {
                ["x"] = 1D,
                ["y"] = 1.5D,
            },
            true,
            new Tolerance { IntegerToleranceRangeLowerBound = 1L },
        },
        new object?[]
        {
            "1>1.5",
            null,
            true,
            new Tolerance { IntegerToleranceRangeLowerBound = 1L },
        },
        new object?[]
        {
            "x>y",
            new Dictionary<string, object>
            {
                ["x"] = 1D,
                ["y"] = 1.5D,
            },
            true,
            new Tolerance { ToleranceRangeLowerBound = 1D },
        },
        new object?[]
        {
            "1>1.5",
            null,
            true,
            new Tolerance { ToleranceRangeLowerBound = 1D },
        },
        new object?[]
        {
            "x>y",
            new Dictionary<string, object>
            {
                ["x"] = 1D,
                ["y"] = 1.5D,
            },
            false,
            new Tolerance { ToleranceRangeLowerBound = 0.5D },
        },
        new object?[]
        {
            "1>1.5",
            null,
            false,
            new Tolerance { ToleranceRangeLowerBound = 0.5D },
        },
        new object?[]
        {
            "x>y",
            new Dictionary<string, object>
            {
                ["x"] = 1D,
                ["y"] = 1.5D,
            },
            false,
            new Tolerance { ProportionalTolerance = 0.2D },
        },
        new object?[]
        {
            "1>1.5",
            null,
            false,
            new Tolerance { ProportionalTolerance = 0.2D },
        },
        new object?[]
        {
            "x>y",
            new Dictionary<string, object>
            {
                ["x"] = 1D,
                ["y"] = 1.5D,
            },
            true,
            new Tolerance { ProportionalTolerance = 0.5D },
        },
        new object?[]
        {
            "1>1.5",
            null,
            true,
            new Tolerance { ProportionalTolerance = 0.5D },
        },
        new object?[]
        {
            "x>y",
            new Dictionary<string, object>
            {
                ["x"] = 1D,
                ["y"] = 1.5D,
            },
            false,
            new Tolerance { ProportionalTolerance = 1.1D },
        },
        new object?[]
        {
            "1>1.5",
            null,
            false,
            new Tolerance { ProportionalTolerance = 1.1D },
        },
        new object?[]
        {
            "x>y",
            new Dictionary<string, object>
            {
                ["x"] = 1D,
                ["y"] = 1.5D,
            },
            true,
            new Tolerance { ProportionalTolerance = 2D },
        },
        new object?[]
        {
            "1>1.5",
            null,
            true,
            new Tolerance { ProportionalTolerance = 2D },
        },

        // Greater than or equal
        new object?[]
        {
            "x>=y",
            new Dictionary<string, object>
            {
                ["x"] = 1D,
                ["y"] = 1.5D,
            },
            true,
            new Tolerance { IntegerToleranceRangeLowerBound = 1L },
        },
        new object?[]
        {
            "1>=1.5",
            null,
            true,
            new Tolerance { IntegerToleranceRangeLowerBound = 1L },
        },
        new object?[]
        {
            "x>=y",
            new Dictionary<string, object>
            {
                ["x"] = 1D,
                ["y"] = 1.5D,
            },
            true,
            new Tolerance { ToleranceRangeLowerBound = 1D },
        },
        new object?[]
        {
            "1>=1.5",
            null,
            true,
            new Tolerance { ToleranceRangeLowerBound = 1D },
        },
        new object?[]
        {
            "x>=y",
            new Dictionary<string, object>
            {
                ["x"] = 1D,
                ["y"] = 1.5D,
            },
            true,
            new Tolerance { ToleranceRangeLowerBound = 0.5D },
        },
        new object?[]
        {
            "1>=1.5",
            null,
            true,
            new Tolerance { ToleranceRangeLowerBound = 0.5D },
        },
        new object?[]
        {
            "x>=y",
            new Dictionary<string, object>
            {
                ["x"] = 1D,
                ["y"] = 1.5D,
            },
            false,
            new Tolerance { ProportionalTolerance = 0.2D },
        },
        new object?[]
        {
            "1>=1.5",
            null,
            false,
            new Tolerance { ProportionalTolerance = 0.2D },
        },
        new object?[]
        {
            "x>=y",
            new Dictionary<string, object>
            {
                ["x"] = 1D,
                ["y"] = 1.5D,
            },
            true,
            new Tolerance { ProportionalTolerance = 0.5D },
        },
        new object?[]
        {
            "1>=1.5",
            null,
            true,
            new Tolerance { ProportionalTolerance = 0.5D },
        },
        new object?[]
        {
            "x>=y",
            new Dictionary<string, object>
            {
                ["x"] = 1D,
                ["y"] = 1.5D,
            },
            false,
            new Tolerance { ProportionalTolerance = 1.1D },
        },
        new object?[]
        {
            "1>=1.5",
            null,
            false,
            new Tolerance { ProportionalTolerance = 1.1D },
        },
        new object?[]
        {
            "x>=y",
            new Dictionary<string, object>
            {
                ["x"] = 1D,
                ["y"] = 1.5D,
            },
            true,
            new Tolerance { ProportionalTolerance = 2D },
        },
        new object?[]
        {
            "1>=1.5",
            null,
            true,
            new Tolerance { ProportionalTolerance = 2D },
        },

        // Less than
        new object?[]
        {
            "y<x",
            new Dictionary<string, object>
            {
                ["y"] = 1.5D,
                ["x"] = 1D,
            },
            true,
            new Tolerance { IntegerToleranceRangeUpperBound = 1L },
        },
        new object?[]
        {
            "1.5<1",
            null,
            true,
            new Tolerance { IntegerToleranceRangeUpperBound = 1L },
        },
        new object?[]
        {
            "y<x",
            new Dictionary<string, object>
            {
                ["y"] = 1.5D,
                ["x"] = 1D,
            },
            true,
            new Tolerance { ToleranceRangeUpperBound = 1D },
        },
        new object?[]
        {
            "1.5<1",
            null,
            true,
            new Tolerance { ToleranceRangeUpperBound = 1D },
        },
        new object?[]
        {
            "y<x",
            new Dictionary<string, object>
            {
                ["y"] = 1.5D,
                ["x"] = 1D,
            },
            false,
            new Tolerance { ToleranceRangeUpperBound = 0.5D },
        },
        new object?[]
        {
            "1.5<1",
            null,
            false,
            new Tolerance { ToleranceRangeUpperBound = 0.5D },
        },
        new object?[]
        {
            "y<x",
            new Dictionary<string, object>
            {
                ["y"] = 1.5D,
                ["x"] = 1D,
            },
            false,
            new Tolerance { ProportionalTolerance = 0.2D },
        },
        new object?[]
        {
            "1.5<1",
            null,
            false,
            new Tolerance { ProportionalTolerance = 0.2D },
        },
        new object?[]
        {
            "y<x",
            new Dictionary<string, object>
            {
                ["y"] = 1.5D,
                ["x"] = 1D,
            },
            false,
            new Tolerance { ProportionalTolerance = 0.5D },
        },
        new object?[]
        {
            "1.5<1",
            null,
            false,
            new Tolerance { ProportionalTolerance = 0.5D },
        },
        new object?[]
        {
            "y<x",
            new Dictionary<string, object>
            {
                ["y"] = 1.5D,
                ["x"] = 1D,
            },
            false,
            new Tolerance { ProportionalTolerance = 1.1D },
        },
        new object?[]
        {
            "1.5<1",
            null,
            false,
            new Tolerance { ProportionalTolerance = 1.1D },
        },
        new object?[]
        {
            "y<x",
            new Dictionary<string, object>
            {
                ["y"] = 1.5D,
                ["x"] = 1D,
            },
            true,
            new Tolerance { ProportionalTolerance = 2D },
        },
        new object?[]
        {
            "1.5<1",
            null,
            true,
            new Tolerance { ProportionalTolerance = 2D },
        },

        // Less than or equal
        new object?[]
        {
            "y<=x",
            new Dictionary<string, object>
            {
                ["y"] = 1.5D,
                ["x"] = 1D,
            },
            true,
            new Tolerance { IntegerToleranceRangeUpperBound = 1L },
        },
        new object?[]
        {
            "1.5<=1",
            null,
            true,
            new Tolerance { IntegerToleranceRangeUpperBound = 1L },
        },
        new object?[]
        {
            "y<=x",
            new Dictionary<string, object>
            {
                ["y"] = 1.5D,
                ["x"] = 1D,
            },
            true,
            new Tolerance { ToleranceRangeUpperBound = 1D },
        },
        new object?[]
        {
            "1.5<=1",
            null,
            true,
            new Tolerance { ToleranceRangeUpperBound = 1D },
        },
        new object?[]
        {
            "y<=x",
            new Dictionary<string, object>
            {
                ["y"] = 1.5D,
                ["x"] = 1D,
            },
            true,
            new Tolerance { ToleranceRangeUpperBound = 0.5D },
        },
        new object?[]
        {
            "1.5<=1",
            null,
            true,
            new Tolerance { ToleranceRangeUpperBound = 0.5D },
        },
        new object?[]
        {
            "y<=x",
            new Dictionary<string, object>
            {
                ["y"] = 1.5D,
                ["x"] = 1D,
            },
            false,
            new Tolerance { ProportionalTolerance = 0.2D },
        },
        new object?[]
        {
            "1.5<=1",
            null,
            false,
            new Tolerance { ProportionalTolerance = 0.2D },
        },
        new object?[]
        {
            "y<=x",
            new Dictionary<string, object>
            {
                ["y"] = 1.5D,
                ["x"] = 1D,
            },
            true,
            new Tolerance { ProportionalTolerance = 0.5D },
        },
        new object?[]
        {
            "1.5<=1",
            null,
            true,
            new Tolerance { ProportionalTolerance = 0.5D },
        },
        new object?[]
        {
            "y<=x",
            new Dictionary<string, object>
            {
                ["y"] = 1.5D,
                ["x"] = 1D,
            },
            false,
            new Tolerance { ProportionalTolerance = 1.1D },
        },
        new object?[]
        {
            "1.5<=1",
            null,
            false,
            new Tolerance { ProportionalTolerance = 1.1D },
        },
        new object?[]
        {
            "y<=x",
            new Dictionary<string, object>
            {
                ["y"] = 1.5D,
                ["x"] = 1D,
            },
            true,
            new Tolerance { ProportionalTolerance = 2D },
        },
        new object?[]
        {
            "1.5<=1",
            null,
            true,
            new Tolerance { ProportionalTolerance = 2D },
        },
    };

    /// <summary>
    /// Tests the computed expression with parameters.
    /// </summary>
    /// <param name="expression">The expression.</param>
    /// <param name="parameters">The parameters.</param>
    /// <param name="expectedResult">The expected result.</param>
    /// <param name="tolerance">The tolerance.</param>
    /// <exception cref="InvalidOperationException">No computed expression was generated.</exception>
    [Theory(DisplayName = "TEPSPara")]
    [MemberData(nameof(ProvideDataForTheory))]
    public void ComputedExpressionWithParameters(
        string expression,
        Dictionary<string, object>? parameters,
        object expectedResult,
        Tolerance tolerance)
    {
        using var service = new ExpressionParsingService();
        using ComputedExpression del = service.Interpret(expression);

        object result = del.Compute(tolerance, parameters?.Values.ToArray() ?? Array.Empty<object>());

        Assert.Equal(
            expectedResult,
            result);
    }

    /// <summary>
    /// Tests a computed expression with finder.
    /// </summary>
    /// <param name="expression">The expression.</param>
    /// <param name="parameters">The parameters.</param>
    /// <param name="expectedResult">The expected result.</param>
    /// <param name="tolerance">The tolerance.</param>
    /// <exception cref="InvalidOperationException">No computed expression was generated.</exception>
    [Theory(DisplayName = "TEPSFindr")]
    [MemberData(nameof(ProvideDataForTheory))]
    public void ComputedExpressionWithFinder(
        string expression,
        Dictionary<string, object>? parameters,
        object expectedResult,
        Tolerance tolerance)
    {
        using var service = new ExpressionParsingService();

        var finder = new Mock<IDataFinder>(MockBehavior.Loose);

        using ComputedExpression del = service.Interpret(expression);

        if (parameters != null)
        {
            foreach (KeyValuePair<string, object> parameter in parameters)
            {
                var key = parameter.Key;
                object value = parameter.Value;
                _ = finder.Setup(
                    p => p.TryGetData(
                        key,
                        out value)).Returns(true);
            }
        }

        object result = del.Compute(tolerance, finder.Object);

        Assert.Equal(
            expectedResult,
            result);
    }

#pragma warning disable IDISP001 // Dispose created. - We specifically do not want these to be disposed

    /// <summary>
    /// Tests the cached computed expression with parameters.
    /// </summary>
    /// <param name="expression">The expression.</param>
    /// <param name="parameters">The parameters.</param>
    /// <param name="expectedResult">The expected result.</param>
    /// <param name="tolerance">The tolerance.</param>
    /// <exception cref="InvalidOperationException">No computed expression was generated.</exception>
    [Theory(DisplayName = "TCEPSPara")]
    [MemberData(nameof(ProvideDataForTheory))]
    public void CachedComputedExpressionWithParameters(
        string expression,
        Dictionary<string, object>? parameters,
        object expectedResult,
        Tolerance tolerance)
    {
        ComputedExpression del = fixture.CachedService.Interpret(expression);
        if (del == null)
        {
            throw new InvalidOperationException("No computed expression was generated!");
        }

        object result = del.Compute(tolerance, parameters?.Values.ToArray() ?? new object[0]);

        Assert.Equal(
            expectedResult,
            result);
    }

    /// <summary>
    /// Tests a cached computed expression with finder.
    /// </summary>
    /// <param name="expression">The expression.</param>
    /// <param name="parameters">The parameters.</param>
    /// <param name="expectedResult">The expected result.</param>
    /// <param name="tolerance">The tolerance.</param>
    /// <exception cref="InvalidOperationException">No computed expression was generated.</exception>
    [Theory(DisplayName = "TCEPSFindr")]
    [MemberData(nameof(ProvideDataForTheory))]
    public void CachedComputedExpressionWithFinder(
        string expression,
        Dictionary<string, object>? parameters,
        object expectedResult,
        Tolerance tolerance)
    {
        var finder = new Mock<IDataFinder>(MockBehavior.Loose);

        ComputedExpression del = fixture.CachedService.Interpret(expression);
        if (del == null)
        {
            throw new InvalidOperationException("No computed expression was generated!");
        }

        if (parameters != null)
        {
            foreach (KeyValuePair<string, object> parameter in parameters)
            {
                var key = parameter.Key;
                object value = parameter.Value;
                _ = finder.Setup(
                    p => p.TryGetData(
                        key,
                        out value)).Returns(true);
            }
        }

        object result = del.Compute(tolerance, finder.Object);

        Assert.Equal(
            expectedResult,
            result);
    }
#pragma warning restore IDISP001 // Dispose created.

    /// <summary>
    /// Tests a computed expression with finder.
    /// </summary>
    /// <param name="expression">The expression.</param>
    /// <param name="parameters">The parameters.</param>
    /// <param name="expectedResult">The expected result.</param>
    /// <param name="tolerance">The tolerance.</param>
    /// <exception cref="InvalidOperationException">No computed expression was generated.</exception>
    [Theory(DisplayName = "TEPSFindrFunc")]
    [MemberData(nameof(ProvideDataForTheory))]
    public void ComputedExpressionWithFunctionFinder(
        string expression,
        Dictionary<string, object>? parameters,
        object expectedResult,
        Tolerance tolerance)
    {
        using var service = new ExpressionParsingService();

        var finder = new Mock<IDataFinder>(MockBehavior.Loose);

        using ComputedExpression del = service.Interpret(expression);

        if (parameters != null)
        {
            foreach (KeyValuePair<string, object> parameter in parameters)
            {
                var key = parameter.Key;
                object value = GenerateFuncOutOfParameterValue(parameter.Value);
                _ = finder.Setup(
                    p => p.TryGetData(
                        key,
                        out value)).Returns(true);
            }
        }

        object result = del.Compute(tolerance, finder.Object);

        Assert.Equal(
            expectedResult,
            result);
    }

#pragma warning disable IDISP001 // Dispose created. - We specifically do not want these to be disposed

    /// <summary>
    /// Tests a cached computed expression with finder.
    /// </summary>
    /// <param name="expression">The expression.</param>
    /// <param name="parameters">The parameters.</param>
    /// <param name="expectedResult">The expected result.</param>
    /// <param name="tolerance">The tolerance.</param>
    /// <exception cref="InvalidOperationException">No computed expression was generated.</exception>
    [Theory(DisplayName = "TCEPSFindrFunc")]
    [MemberData(nameof(ProvideDataForTheory))]
    public void CachedComputedExpressionWithFunctionFinder(
        string expression,
        Dictionary<string, object>? parameters,
        object expectedResult,
        Tolerance tolerance)
    {
        var finder = new Mock<IDataFinder>(MockBehavior.Loose);

        ComputedExpression del = fixture.CachedService.Interpret(expression);
        if (del == null)
        {
            throw new InvalidOperationException("No computed expression was generated!");
        }

        if (parameters != null)
        {
            foreach (KeyValuePair<string, object> parameter in parameters)
            {
                var key = parameter.Key;
                object value = GenerateFuncOutOfParameterValue(parameter.Value);
                _ = finder.Setup(
                    p => p.TryGetData(
                        key,
                        out value)).Returns(true);
            }
        }

        object result = del.Compute(tolerance, finder.Object);

        Assert.Equal(
            expectedResult,
            result);
    }

    /// <summary>
    /// Tests a cached computed expression with finder returning functions repeatedly.
    /// </summary>
    /// <param name="expression">The expression.</param>
    /// <param name="parameters">The parameters.</param>
    /// <param name="expectedResult">The expected result.</param>
    /// <param name="tolerance">The tolerance.</param>
    /// <exception cref="InvalidOperationException">No computed expression was generated.</exception>
    [Theory(DisplayName = "TCEPSFindrFuncRepeated")]
    [MemberData(nameof(ProvideDataForTheory))]
    public void CachedComputedExpressionWithFunctionFinderRepeated(
        string expression,
        Dictionary<string, object>? parameters,
        object expectedResult,
        Tolerance tolerance)
    {
        var indexLimit = DataGenerator.RandomInteger(
            3,
            5);
        for (var index = 0; index < indexLimit; index++)
        {
            var finder = new Mock<IDataFinder>(MockBehavior.Loose);

            ComputedExpression del = fixture.CachedService.Interpret(expression);

            if (parameters != null)
            {
                foreach (KeyValuePair<string, object> parameter in parameters)
                {
                    var key = parameter.Key;
                    object value = GenerateFuncOutOfParameterValue(parameter.Value);
                    _ = finder.Setup(
                        p => p.TryGetData(
                            key,
                            out value)).Returns(true);
                }
            }

            object result = del.Compute(tolerance, finder.Object);

            Assert.Equal(
                expectedResult,
                result);
        }
    }
#pragma warning restore IDISP001 // Dispose created.

    private object GenerateFuncOutOfParameterValue(object tempParameter) =>
        tempParameter switch
        {
            byte convertedValue => new Func<byte>(() => convertedValue),
            sbyte convertedValue => new Func<sbyte>(() => convertedValue),
            short convertedValue => new Func<short>(() => convertedValue),
            ushort convertedValue => new Func<ushort>(() => convertedValue),
            int convertedValue => new Func<int>(() => convertedValue),
            uint convertedValue => new Func<uint>(() => convertedValue),
            long convertedValue => new Func<long>(() => convertedValue),
            ulong convertedValue => new Func<ulong>(() => convertedValue),
            float convertedValue => new Func<float>(() => convertedValue),
            double convertedValue => new Func<double>(() => convertedValue),
            byte[] convertedValue => new Func<byte[]>(() => convertedValue),
            string convertedValue => new Func<string>(() => convertedValue),
            bool convertedValue => new Func<bool>(() => convertedValue),
            _ => throw new InvalidOperationException()
        };
}