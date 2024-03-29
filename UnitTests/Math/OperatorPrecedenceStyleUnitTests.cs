using IX.Math;

namespace UnitTests.Math;

/// <summary>
/// Unit tests for operator precedence styles.
/// </summary>
public class OperatorPrecedenceStyleUnitTests
{
    /// <summary>
    /// Tests mathematical and C-style operator precedence style.
    /// </summary>
    /// <exception cref="InvalidOperationException">
    /// No computed expression was generated.
    /// </exception>
    [Fact(DisplayName = "Operator precedence style test")]
    public void Test1()
    {
        const string expression = "true&true|false&false";

        object result1, result2;

        using (var service = new ExpressionParsingService())
        {
            using (ComputedExpression del = service.Interpret(expression))
            {
                if (del == null)
                {
                    throw new InvalidOperationException("No computed expression was generated!");
                }

                result1 = del.Compute();
            }
        }

        using (var service = new ExpressionParsingService(new()
               {
                   Parentheses = ("(", ")"),
                   SpecialSymbolIndicators = ("[", "]"),
                   StringIndicator = "\"",
                   ParameterSeparator = ",",
                   AddSymbol = "+",
                   AndSymbol = "&",
                   DivideSymbol = "/",
                   NotEqualsSymbol = "!=",
                   EqualsSymbol = "=",
                   MultiplySymbol = "*",
                   NotSymbol = "!",
                   OrSymbol = "|",
                   PowerSymbol = "^",
                   SubtractSymbol = "-",
                   XorSymbol = "#",
                   GreaterThanOrEqualSymbol = ">=",
                   GreaterThanSymbol = ">",
                   LessThanOrEqualSymbol = "<=",
                   LessThanSymbol = "<",
                   RightShiftSymbol = ">>",
                   LeftShiftSymbol = "<<",
                   OperatorPrecedenceStyle = OperatorPrecedenceStyle.CStyle
               }))
        {
            using ComputedExpression del = service.Interpret(expression);

            if (del == null)
            {
                throw new InvalidOperationException("No computed expression was generated!");
            }

            result2 = del.Compute();
        }

        Assert.False((bool)result1);
        Assert.True((bool)result2);
    }
}