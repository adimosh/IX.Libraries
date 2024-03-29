namespace IX.Math;

/// <summary>
///     A service that is able to parse strings containing mathematical expressions and solve them in a cached way. This
///     class cannot be inherited.
/// </summary>
/// <remarks>
///     <para>
///         This service also caches expressions so that they can be garbage-collected after a specific time period with
///         no use.
///     </para>
/// </remarks>
/// <seealso cref="ExpressionParsingServiceBase" />
public sealed class CachedExpressionParsingService : ExpressionParsingServiceBase
{
    private ConcurrentDictionary<string, ComputedExpression> _cachedComputedExpressions;

    /// <summary>
    ///     Initializes a new instance of the <see cref="CachedExpressionParsingService" /> class.
    /// </summary>
    public CachedExpressionParsingService()
        : base(MathDefinition.Default) =>
        _cachedComputedExpressions = new();

    /// <summary>
    ///     Initializes a new instance of the <see cref="CachedExpressionParsingService" /> class.
    /// </summary>
    /// <param name="definition">The math definition to use.</param>
    public CachedExpressionParsingService(MathDefinition definition)
        : base(definition) =>
        _cachedComputedExpressions = new();

    /// <summary>
    ///     Interprets the mathematical expression and returns a container that can be invoked for solving using specific
    ///     mathematical types.
    /// </summary>
    /// <param name="expression">The expression to interpret.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ComputedExpression" /> that represents the interpreted expression.</returns>
    /// <remarks>
    ///     <para>
    ///         Due to the specifics of executing multiple expressions, the returned object will always be a clone of the
    ///         originally-interpreted object, unless any of the following conditions are met:
    ///     </para>
    ///     <list type="bullet">
    ///         <item>The expression is constant</item>
    ///         <item>The expression has no parameters</item>
    ///         <item>The expression has not been recognized correctly.</item>
    ///     </list>
    ///     <para>
    ///         This way, a computed expression that has parameters which depend on outside influence will not be subject to
    ///         reinterpretation, but will execute without having to force undefined parameters into specific types.
    ///     </para>
    /// </remarks>
    public override ComputedExpression Interpret(
        string expression,
        CancellationToken cancellationToken = default)
    {
        ComputedExpression expr = _cachedComputedExpressions.GetOrAdd(
            expression,
            static (
                ex,
                st) => st.Reference.InterpretInternal(
                ex,
                st.CancellationToken),
            (Reference: this, CancellationToken: cancellationToken));

        if (!expr.RecognizedCorrectly || expr.IsConstant)
        {
            return expr;
        }

        return expr.DeepClone();
    }

    /// <summary>
    ///     Disposes in the managed context.
    /// </summary>
    protected override void DisposeManagedContext()
    {
        _cachedComputedExpressions.Clear();

        base.DisposeManagedContext();
    }
}