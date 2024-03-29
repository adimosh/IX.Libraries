using IX.Library.DataGeneration;
using IX.Math;
using Moq;

using UnitTests.Math.Helpers;

namespace UnitTests.Math;

/// <summary>
///     Tests computed expressions.
/// </summary>
public class OneDataSetComputedExpressionUnitTest : IClassFixture<CachedExpressionProviderFixture>
{
    private readonly CachedExpressionProviderFixture _fixture;

    /// <summary>
    ///     Initializes a new instance of the <see cref="OneDataSetComputedExpressionUnitTest" /> class.
    /// </summary>
    /// <param name="fixture">The fixture.</param>
    public OneDataSetComputedExpressionUnitTest(CachedExpressionProviderFixture fixture) => _fixture = fixture;

    /// <summary>
    ///     Provides the data for theory.
    /// </summary>
    /// <returns>Theory data.</returns>
    // ReSharper disable once MemberCanBePrivate.Global - It really cannot
    public static object?[][] ProvideDataForTheory() => new[]
    {
        new object?[]
        {
            "min(2,17)",
            null,
            2L,
        },
    };

    private static object GenerateFuncOutOfParameterValue(object tempParameter) => tempParameter switch
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
        _ => throw new InvalidOperationException(),
    };

    /// <summary>
    ///     Tests the computed expression with parameters.
    /// </summary>
    /// <param name="expression">The expression.</param>
    /// <param name="parameters">The parameters.</param>
    /// <param name="expectedResult">The expected result.</param>
    /// <exception cref="InvalidOperationException">
    ///     No computed expression was generated.
    /// </exception>
    [Theory(DisplayName = "EPSPara")]
    [MemberData(nameof(ProvideDataForTheory))]
    public void ComputedExpressionWithParameters(
        string expression,
        Dictionary<string, object>? parameters,
        object expectedResult)
    {
        using var service = new ExpressionParsingService();
        using ComputedExpression del = service.Interpret(expression);

        object result = del.Compute(parameters?.Values.ToArray() ?? new object[0]);

        Assert.Equal(
            expectedResult,
            result);
    }

    /// <summary>
    ///     Tests a computed expression with finder.
    /// </summary>
    /// <param name="expression">The expression.</param>
    /// <param name="parameters">The parameters.</param>
    /// <param name="expectedResult">The expected result.</param>
    /// <exception cref="InvalidOperationException">
    ///     No computed expression was generated.
    /// </exception>
    [Theory(DisplayName = "EPSFindr")]
    [MemberData(nameof(ProvideDataForTheory))]
    public void ComputedExpressionWithFinder(
        string expression,
        Dictionary<string, object>? parameters,
        object expectedResult)
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

        object result = del.Compute(finder.Object);

        Assert.Equal(
            expectedResult,
            result);
    }

    /// <summary>
    ///     Tests the cached computed expression with parameters.
    /// </summary>
    /// <param name="expression">The expression.</param>
    /// <param name="parameters">The parameters.</param>
    /// <param name="expectedResult">The expected result.</param>
    /// <exception cref="InvalidOperationException">
    ///     No computed expression was generated.
    /// </exception>
    [Theory(DisplayName = "CEPSPara")]
    [MemberData(nameof(ProvideDataForTheory))]
    public void CachedComputedExpressionWithParameters(
        string expression,
        Dictionary<string, object>? parameters,
        object expectedResult)
    {
        ComputedExpression del = _fixture.CachedService.Interpret(expression);
        if (del == null)
        {
            throw new InvalidOperationException("No computed expression was generated!");
        }

        object result = del.Compute(parameters?.Values.ToArray() ?? new object[0]);

        Assert.Equal(
            expectedResult,
            result);
    }

    /// <summary>
    ///     Tests a cached computed expression with finder.
    /// </summary>
    /// <param name="expression">The expression.</param>
    /// <param name="parameters">The parameters.</param>
    /// <param name="expectedResult">The expected result.</param>
    /// <exception cref="InvalidOperationException">
    ///     No computed expression was generated.
    /// </exception>
    [Theory(DisplayName = "CEPSFindr")]
    [MemberData(nameof(ProvideDataForTheory))]
    public void CachedComputedExpressionWithFinder(
        string expression,
        Dictionary<string, object>? parameters,
        object expectedResult)
    {
        var finder = new Mock<IDataFinder>(MockBehavior.Loose);

        ComputedExpression del = _fixture.CachedService.Interpret(expression);
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

        object result = del.Compute(finder.Object);

        Assert.Equal(
            expectedResult,
            result);
    }

    /// <summary>
    ///     Tests a computed expression with finder.
    /// </summary>
    /// <param name="expression">The expression.</param>
    /// <param name="parameters">The parameters.</param>
    /// <param name="expectedResult">The expected result.</param>
    /// <exception cref="InvalidOperationException">
    ///     No computed expression was generated.
    /// </exception>
    [Theory(DisplayName = "EPSFindrFunc")]
    [MemberData(nameof(ProvideDataForTheory))]
    public void ComputedExpressionWithFunctionFinder(
        string expression,
        Dictionary<string, object>? parameters,
        object expectedResult)
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

        object result = del.Compute(finder.Object);

        Assert.Equal(
            expectedResult,
            result);
    }

    /// <summary>
    ///     Tests a cached computed expression with finder.
    /// </summary>
    /// <param name="expression">The expression.</param>
    /// <param name="parameters">The parameters.</param>
    /// <param name="expectedResult">The expected result.</param>
    /// <exception cref="InvalidOperationException">
    ///     No computed expression was generated.
    /// </exception>
    [Theory(DisplayName = "CEPSFindrFunc")]
    [MemberData(nameof(ProvideDataForTheory))]
    public void CachedComputedExpressionWithFunctionFinder(
        string expression,
        Dictionary<string, object>? parameters,
        object expectedResult)
    {
        var finder = new Mock<IDataFinder>(MockBehavior.Loose);

        ComputedExpression del = _fixture.CachedService.Interpret(expression);
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

        object result = del.Compute(finder.Object);

        Assert.Equal(
            expectedResult,
            result);
    }

    /// <summary>
    ///     Tests a cached computed expression with finder returning functions repeatedly.
    /// </summary>
    /// <param name="expression">The expression.</param>
    /// <param name="parameters">The parameters.</param>
    /// <param name="expectedResult">The expected result.</param>
    /// <exception cref="InvalidOperationException">
    ///     No computed expression was generated.
    /// </exception>
    [Theory(DisplayName = "CEPSFindrFuncRepeated")]
    [MemberData(nameof(ProvideDataForTheory))]
    public void CachedComputedExpressionWithFunctionFinderRepeated(
        string expression,
        Dictionary<string, object>? parameters,
        object expectedResult)
    {
        var indexLimit = DataGenerator.RandomInteger(
            3,
            5);
        for (var index = 0; index < indexLimit; index++)
        {
            var finder = new Mock<IDataFinder>(MockBehavior.Loose);

            ComputedExpression del = _fixture.CachedService.Interpret(expression);

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

            object result = del.Compute(finder.Object);

            Assert.Equal(
                expectedResult,
                result);
        }
    }
}