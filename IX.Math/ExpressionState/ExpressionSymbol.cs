using System.Diagnostics;

namespace IX.Math.ExpressionState;

/// <summary>
///     An expression symbol.
/// </summary>
[DebuggerDisplay("Expression: {Name} -> {Expression}")]
public class ExpressionSymbol
{
    private string? _expression;

    private ExpressionSymbol()
    {
    }

    /// <summary>
    ///     Gets or sets the expression.
    /// </summary>
    /// <value>The name.</value>
    public string? Expression
    {
        get => _expression;
        set => _expression = string.IsNullOrWhiteSpace(value) ? null : value?.Trim();
    }

    /// <summary>
    ///     Gets a value indicating whether this symbol represents a function call.
    /// </summary>
    /// <value><see langword="true" /> if this symbol is a function call; otherwise, <see langword="false" />.</value>
    public bool IsFunctionCall { get; private set; }

    /// <summary>
    ///     Gets or sets the name of the expression symbol.
    /// </summary>
    /// <value>The name.</value>
    public string Name { get; set; } = string.Empty;

    internal static ExpressionSymbol GenerateSymbol(
        string name,
        string expression) => new()
    {
        Name = name,
        Expression = expression
    };

    internal static ExpressionSymbol GenerateFunctionCall(
        string name,
        string expression)
    {
        ExpressionSymbol generatedExpression = GenerateSymbol(
            name,
            expression);
        generatedExpression.IsFunctionCall = true;
        return generatedExpression;
    }
}