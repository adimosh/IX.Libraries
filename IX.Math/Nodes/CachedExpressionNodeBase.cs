using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace IX.Math.Nodes;

/// <summary>
///     A node base that caches its generated expression.
/// </summary>
/// <seealso cref="NodeBase" />
[PublicAPI]
public abstract class CachedExpressionNodeBase : NodeBase
{
    private Expression? _generatedExpression;
    private Expression? _generatedStringExpression;

    /// <summary>
    ///     Prevents a default instance of the <see cref="CachedExpressionNodeBase" /> class from being created.
    /// </summary>
    protected private CachedExpressionNodeBase() { }

    /// <summary>
    ///     Generates the expression that will be compiled into code.
    /// </summary>
    /// <returns>The generated <see cref="Expression" />.</returns>
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    public sealed override Expression GenerateExpression() =>
        _generatedExpression ??= GenerateCachedExpression();

    /// <summary>
    ///     Generates the expression that will be compiled into code.
    /// </summary>
    /// <param name="tolerance">The tolerance.</param>
    /// <returns>
    ///     The generated <see cref="Expression" />.
    /// </returns>
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    public sealed override Expression GenerateExpression(Tolerance? tolerance) =>
        _generatedExpression ??= GenerateCachedExpression(tolerance);

    /// <summary>
    ///     Generates the expression that will be compiled into code as a string expression.
    /// </summary>
    /// <returns>The generated <see cref="Expression" /> that gives the values as a string.</returns>
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    public sealed override Expression GenerateStringExpression() =>
        _generatedStringExpression ??= GenerateCachedStringExpression();

    /// <summary>
    ///     Generates the expression that will be compiled into code as a string expression.
    /// </summary>
    /// <param name="tolerance">The tolerance.</param>
    /// <returns>The generated <see cref="Expression" /> that gives the values as a string.</returns>
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    public override Expression GenerateStringExpression(Tolerance? tolerance) =>
        _generatedStringExpression ??= GenerateCachedStringExpression(tolerance);

    /// <summary>
    ///     Generates an expression that will be cached before being compiled.
    /// </summary>
    /// <returns>The generated <see cref="Expression" /> to be cached.</returns>
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    public abstract Expression GenerateCachedExpression();

    /// <summary>
    ///     Generates an expression with tolerance that will be cached before being compiled.
    /// </summary>
    /// <param name="tolerance">The tolerance.</param>
    /// <returns>
    ///     The generated <see cref="Expression" /> to be cached.
    /// </returns>
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    public virtual Expression GenerateCachedExpression(Tolerance? tolerance) => GenerateCachedExpression();

    /// <summary>
    ///     Generates a string expression that will be cached before being compiled.
    /// </summary>
    /// <returns>The generated <see cref="Expression" /> to be cached.</returns>
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    public abstract Expression GenerateCachedStringExpression();

    /// <summary>
    ///     Generates a string expression that will be cached before being compiled.
    /// </summary>
    /// <param name="tolerance">The tolerance.</param>
    /// <returns>The generated <see cref="Expression" /> to be cached.</returns>
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    public virtual Expression GenerateCachedStringExpression(Tolerance? tolerance) =>
        GenerateCachedStringExpression();
}