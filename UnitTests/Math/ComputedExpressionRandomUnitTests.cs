using IX.Math;

namespace UnitTests.Math;

/// <summary>
///     Class ComputedExpressionRandomTests.
/// </summary>
public class ComputedExpressionRandomUnitTests
{
    /// <summary>
    ///     Computes the unary random function call expression, for testing.
    /// </summary>
    /// <exception cref="InvalidOperationException">
    ///     No computed expression was generated.
    /// </exception>
    [Fact(DisplayName = "Tests the binary function \"random\".")]
    public void ComputedBinaryRandomFunctionCallExpression()
    {
        var r = new Random();
        int dingLimit;
        do
        {
            dingLimit = r.Next();
        }
        while (dingLimit <= 5);

        var highLimit = r.Next(
            dingLimit,
            int.MaxValue);
        var lowLimit = r.Next(dingLimit);

        using var service = new ExpressionParsingService();
        using ComputedExpression del = service.Interpret("random(x, y)");

        if (del == null)
        {
            throw new InvalidOperationException("No computed expression was generated!");
        }

        object result;
        try
        {
            result = del.Compute(
                lowLimit,
                highLimit);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException(
                "The method should not have thrown an exception, but it did.",
                ex);
        }

        _ = Assert.IsType<double>(result);

        Assert.True((double)result < highLimit);
        Assert.True((double)result >= lowLimit);
    }

    /// <summary>
    ///     Computes the unary random function call expression, for testing.
    /// </summary>
    /// <exception cref="InvalidOperationException">
    ///     No computed expression was generated.
    /// </exception>
    [Fact(DisplayName = "Tests the unary function \"random\".")]
    public void ComputedUnaryRandomFunctionCallExpression()
    {
        var r = new Random();
        var limit = r.Next();

        using var service = new ExpressionParsingService();
        using ComputedExpression del = service.Interpret("random(x)");

        if (del == null)
        {
            throw new InvalidOperationException("No computed expression was generated!");
        }

        object result;
        try
        {
            result = del.Compute(limit);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException(
                "The method should not have thrown an exception, but it did.",
                ex);
        }

        _ = Assert.IsType<double>(result);

        Assert.True((double)result < limit);
    }

    /// <summary>
    ///     Computes the random nonary function call expression, for testing.
    /// </summary>
    /// <exception cref="InvalidOperationException">
    ///     No computed expression was generated.
    /// </exception>
    [Fact(DisplayName = "Tests the nonary function \"random\".")]
    public void ComputedRandomNonaryFunctionCallExpression()
    {
        using var service = new ExpressionParsingService();
        using ComputedExpression del = service.Interpret("random()");

        if (del == null)
        {
            throw new InvalidOperationException("No computed expression was generated!");
        }

        object result;
        try
        {
            result = del.Compute();
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException(
                "The method should not have thrown an exception, but it did.",
                ex);
        }

        _ = Assert.IsType<double>(result);
    }

    /// <summary>
    ///     Computes the unary random function call expression, for testing.
    /// </summary>
    /// <exception cref="InvalidOperationException">
    ///     No computed expression was generated.
    /// </exception>
    [Fact(DisplayName = "Tests the binary function \"randomint\".")]
    public void ComputedBinaryRandomIntFunctionCallExpression()
    {
        var r = new Random();
        int dingLimit;
        do
        {
            dingLimit = r.Next();
        }
        while (dingLimit <= 5);

        var highLimit = r.Next(
            dingLimit,
            int.MaxValue);
        var lowLimit = r.Next(dingLimit);

        using var service = new ExpressionParsingService();
        using ComputedExpression del = service.Interpret("randomint(x, y)");

        if (del == null)
        {
            throw new InvalidOperationException("No computed expression was generated!");
        }

        object result;
        try
        {
            result = del.Compute(
                lowLimit,
                highLimit);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException(
                "The method should not have thrown an exception, but it did.",
                ex);
        }

        _ = Assert.IsType<long>(result);

        Assert.True((long)result < highLimit);
        Assert.True((long)result >= lowLimit);
    }

    /// <summary>
    ///     Computes the unary random function call expression, for testing.
    /// </summary>
    /// <exception cref="InvalidOperationException">
    ///     No computed expression was generated.
    /// </exception>
    [Fact(DisplayName = "Tests the unary function \"randomint\".")]
    public void ComputedUnaryRandomIntFunctionCallExpression()
    {
        var r = new Random();
        var limit = r.Next();

        using var service = new ExpressionParsingService();
        using ComputedExpression del = service.Interpret("randomint(x)");

        if (del == null)
        {
            throw new InvalidOperationException("No computed expression was generated!");
        }

        object result;
        try
        {
            result = del.Compute(limit);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException(
                "The method should not have thrown an exception, but it did.",
                ex);
        }

        _ = Assert.IsType<long>(result);

        Assert.True((long)result < limit);
    }

    /// <summary>
    ///     Computes the random nonary function call expression, for testing.
    /// </summary>
    /// <exception cref="InvalidOperationException">
    ///     No computed expression was generated.
    /// </exception>
    [Fact(DisplayName = "Tests the nonary function \"randomint\".")]
    public void ComputedRandomIntNonaryFunctionCallExpression()
    {
        using var service = new ExpressionParsingService();
        using ComputedExpression del = service.Interpret("randomint()");

        if (del == null)
        {
            throw new InvalidOperationException("No computed expression was generated!");
        }

        object result;
        try
        {
            result = del.Compute();
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException(
                "The method should not have thrown an exception, but it did.",
                ex);
        }

        _ = Assert.IsType<long>(result);
    }
}