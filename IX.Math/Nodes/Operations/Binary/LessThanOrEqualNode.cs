using IX.Library.Contracts;
using IX.Library.Globalization;

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;

using IX.Math.Nodes.Constants;

namespace IX.Math.Nodes.Operations.Binary;

/// <summary>
///     A node representing a less than or equal to expression.
/// </summary>
/// <seealso cref="ComparisonOperationNodeBase" />
[DebuggerDisplay($"{{{nameof(Left)}}} <= {{{nameof(Right)}}}")]
internal sealed class LessThanOrEqualNode : ComparisonOperationNodeBase
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="LessThanOrEqualNode" /> class.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    public LessThanOrEqualNode(
        NodeBase left,
        NodeBase right)
        : base(
            Requires.NotNull(left).Simplify(),
            Requires.NotNull(right).Simplify()) { }

    /// <summary>
    ///     Simplifies this node, if possible, reflexively returns otherwise.
    /// </summary>
    /// <returns>
    ///     A simplified node, or this instance.
    /// </returns>
    public override NodeBase Simplify() =>
        Left switch
        {
            // NumericNode nnLeft when this.Right is NumericNode nnRight => new BoolNode(
            //    Convert.ToDouble(nnLeft.Value) <= Convert.ToDouble(nnRight.Value)),
            StringNode snLeft when Right is StringNode snRight => new BoolNode(
                snLeft.Value.CurrentCultureCompareTo(snRight.Value) <= 0),
            BoolNode bnLeft when Right is BoolNode bnRight => new BoolNode(!bnLeft.Value || bnRight.Value),
            ByteArrayNode baLeft when Right is ByteArrayNode baRight => new BoolNode(
                baLeft.Value.SequenceCompareWithMsb(baRight.Value) <= 0),
            _ => this
        };

    /// <summary>
    ///     Creates a deep clone of the source object.
    /// </summary>
    /// <returns>A deep clone.</returns>
    public override NodeBase DeepClone(NodeCloningContext context) =>
        new LessThanOrEqualNode(
            Left.DeepClone(context),
            Right.DeepClone(context));

    /// <summary>
    ///     Generates the expression that will be compiled into code.
    /// </summary>
    /// <returns>
    ///     The expression.
    /// </returns>
    [SuppressMessage(
        "Performance",
        "HAA0601:Value type to reference type conversion causing boxing allocation",
        Justification = "We want this to happen.")]
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    protected override Expression GenerateExpressionInternal()
    {
        (Expression leftExpression, Expression rightExpression) = GetExpressionsOfSameTypeFromOperands();

        if (leftExpression.Type == typeof(string))
        {
            MethodInfo mi = typeof(string).GetMethodWithExactParameters(
                nameof(string.Compare),
                typeof(string),
                typeof(string),
                typeof(bool),
                typeof(CultureInfo))!;
            return Expression.LessThanOrEqual(
                Expression.Call(
                    mi,
                    Left.GenerateStringExpression(),
                    Right.GenerateStringExpression(),
                    Expression.Constant(
                        false,
                        typeof(bool)), Expression.Property(
                        null,
                        typeof(CultureInfo),
                        nameof(CultureInfo.CurrentCulture))),
                Expression.Constant(
                    0,
                    typeof(int)));
        }

        if (Left.ReturnType == SupportedValueType.Boolean || Right.ReturnType == SupportedValueType.Boolean)
        {
            return Expression.Condition(
                Expression.Equal(
                    leftExpression,
                    Expression.Constant(
                        true,
                        typeof(bool))), rightExpression,
                Expression.Constant(
                    true,
                    typeof(bool)));
        }

        if (Left.ReturnType == SupportedValueType.ByteArray || Right.ReturnType == SupportedValueType.ByteArray)
        {
            return Expression.LessThanOrEqual(
                Expression.Call(
                    typeof(ArrayExtensions).GetMethodWithExactParameters(
                        nameof(ArrayExtensions.SequenceCompareWithMsb),
                        typeof(byte[]),
                        typeof(byte[]))!, leftExpression,
                    rightExpression), Expression.Constant(
                    0,
                    typeof(int)));
        }

        return Expression.LessThanOrEqual(
            leftExpression,
            rightExpression);
    }

    /// <summary>
    ///     Generates the expression with tolerance that will be compiled into code.
    /// </summary>
    /// <param name="tolerance">The tolerance.</param>
    /// <returns>The expression.</returns>
    [SuppressMessage(
        "Performance",
        "HAA0601:Value type to reference type conversion causing boxing allocation",
        Justification = "We want this to happen.")]
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    protected override Expression GenerateExpressionInternal(Tolerance? tolerance)
    {
        (Expression leftExpression, Expression rightExpression) = GetExpressionsOfSameTypeFromOperands(tolerance);

        if (leftExpression.Type == typeof(string))
        {
            MethodInfo mi = typeof(string).GetMethodWithExactParameters(
                nameof(string.Compare),
                typeof(string),
                typeof(string))!;
            return Expression.LessThanOrEqual(
                Expression.Call(
                    mi,
                    Left.GenerateStringExpression(),
                    Right.GenerateStringExpression()), Expression.Constant(
                    0,
                    typeof(int)));
        }

        if (Left.ReturnType == SupportedValueType.Boolean || Right.ReturnType == SupportedValueType.Boolean)
        {
            return Expression.Condition(
                Expression.Equal(
                    leftExpression,
                    Expression.Constant(
                        true,
                        typeof(bool))), rightExpression,
                Expression.Constant(
                    true,
                    typeof(bool)));
        }

        if (Left.ReturnType == SupportedValueType.ByteArray || Right.ReturnType == SupportedValueType.ByteArray)
        {
            return Expression.LessThanOrEqual(
                Expression.Call(
                    typeof(ArrayExtensions).GetMethodWithExactParameters(
                        nameof(ArrayExtensions.SequenceCompareWithMsb),
                        typeof(byte[]),
                        typeof(byte[]))!, leftExpression,
                    rightExpression), Expression.Constant(
                    0,
                    typeof(int)));
        }

        if (Left.ReturnType == SupportedValueType.Numeric && Right.ReturnType == SupportedValueType.Numeric)
        {
            Expression? possibleTolerantExpression = PossibleToleranceExpression(
                leftExpression,
                rightExpression,
                tolerance);

            if (possibleTolerantExpression != null)
            {
                // Valid tolerance expression
                return possibleTolerantExpression;
            }
        }

        return Expression.LessThanOrEqual(
            leftExpression,
            rightExpression);
    }

    [SuppressMessage(
        "Performance",
        "HAA0601:Value type to reference type conversion causing boxing allocation",
        Justification = "We want it this way.")]
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    private Expression? PossibleToleranceExpression(
        Expression leftExpression,
        Expression rightExpression,
        Tolerance? tolerance)
    {
        if (tolerance?.IntegerToleranceRangeUpperBound != null)
        {
            // Integer tolerance
            MethodInfo? mi = typeof(ToleranceFunctions).GetMethodWithExactParameters(
                nameof(ToleranceFunctions.LessThanOrEqualRangeTolerant),
                leftExpression.Type,
                rightExpression.Type,
                typeof(long));

            return mi == null
                ? null
                : Expression.Call(
                    mi,
                    leftExpression,
                    rightExpression,
                    Expression.Constant(
                        tolerance.IntegerToleranceRangeUpperBound ?? 0L,
                        typeof(long)));
        }

        if (tolerance?.ToleranceRangeUpperBound != null)
        {
            // Floating-point tolerance
            MethodInfo? mi = typeof(ToleranceFunctions).GetMethodWithExactParameters(
                nameof(ToleranceFunctions.LessThanOrEqualRangeTolerant),
                leftExpression.Type,
                rightExpression.Type,
                typeof(double));

            return mi == null
                ? null
                : Expression.Call(
                    mi,
                    leftExpression,
                    rightExpression,
                    Expression.Constant(
                        tolerance.ToleranceRangeUpperBound ?? 0D,
                        typeof(double)));
        }

        if (tolerance?.ProportionalTolerance != null)
        {
            if (tolerance.ProportionalTolerance.Value > 1D)
            {
                // Proportional tolerance
                MethodInfo? mi = typeof(ToleranceFunctions).GetMethodWithExactParameters(
                    nameof(ToleranceFunctions.LessThanOrEqualProportionTolerant),
                    leftExpression.Type,
                    rightExpression.Type,
                    typeof(double));

                return mi == null
                    ? null
                    : Expression.Call(
                        mi,
                        leftExpression,
                        rightExpression,
                        Expression.Constant(
                            tolerance.ProportionalTolerance ?? 0D,
                            typeof(double)));
            }

            if (tolerance.ProportionalTolerance.Value < 1D && tolerance.ProportionalTolerance.Value > 0D)
            {
                // Percentage tolerance
                MethodInfo? mi = typeof(ToleranceFunctions).GetMethodWithExactParameters(
                    nameof(ToleranceFunctions.LessThanOrEqualPercentageTolerant),
                    leftExpression.Type,
                    rightExpression.Type,
                    typeof(double));

                return mi == null
                    ? null
                    : Expression.Call(
                        mi,
                        leftExpression,
                        rightExpression,
                        Expression.Constant(
                            tolerance.ProportionalTolerance ?? 0D,
                            typeof(double)));
            }
        }

        return null;
    }
}