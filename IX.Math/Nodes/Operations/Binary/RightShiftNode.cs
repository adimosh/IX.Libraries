using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

using IX.Math.Nodes.Constants;

namespace IX.Math.Nodes.Operations.Binary;

/// <summary>
///     A node for a bitwise right-shift operation.
/// </summary>
/// <seealso cref="ByteShiftOperationNodeBase" />
[DebuggerDisplay($"{{{nameof(Left)}}} >> {{{nameof(Right)}}}")]
internal sealed class RightShiftNode : ByteShiftOperationNodeBase
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="RightShiftNode" /> class.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    public RightShiftNode(
        NodeBase left,
        NodeBase right)
        : base(
            (left ?? throw new ArgumentNullException(nameof(left))).Simplify(),
            (right ?? throw new ArgumentNullException(nameof(right))).Simplify()) { }

    /// <summary>
    ///     Simplifies this node, if possible, reflexively returns otherwise.
    /// </summary>
    /// <returns>
    ///     A simplified node, or this instance.
    /// </returns>
    public override NodeBase Simplify() =>
        Left switch
        {
            NumericNode nLeft when Right is NumericNode nRight => NumericNode.RightShift(
                nLeft,
                nRight),
            ByteArrayNode baLeft when Right is NumericNode baRight => new ByteArrayNode(
                baLeft.Value.RightShift(baRight.ExtractInt())),
            _ => this
        };

    /// <summary>
    ///     Creates a deep clone of the source object.
    /// </summary>
    /// <param name="context">The deep cloning context.</param>
    /// <returns>A deep clone.</returns>
    public override NodeBase DeepClone(NodeCloningContext context) =>
        new RightShiftNode(
            Left.DeepClone(context),
            Right.DeepClone(context));

    /// <summary>
    ///     Generates the expression that will be compiled into code.
    /// </summary>
    /// <returns>
    ///     The expression.
    /// </returns>
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    protected override Expression GenerateExpressionInternal()
    {
        Expression rightExpression = Expression.Convert(
            Right.GenerateExpression(),
            typeof(int));
        return Left.ReturnType switch
        {
            SupportedValueType.Numeric => Expression.RightShift(
                Left.GenerateExpression(),
                rightExpression),
            SupportedValueType.ByteArray => Expression.Call(
                typeof(BitwiseExtensions).GetMethodWithExactParameters(
                    nameof(BitwiseExtensions.RightShift),
                    typeof(byte[]),
                    typeof(int))!, Left.GenerateExpression(),
                rightExpression),
            _ => throw new ExpressionNotValidLogicallyException()
        };
    }

    /// <summary>
    ///     Generates the expression with tolerance that will be compiled into code.
    /// </summary>
    /// <param name="tolerance">The tolerance.</param>
    /// <returns>The expression.</returns>
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    protected override Expression GenerateExpressionInternal(Tolerance? tolerance)
    {
        Expression rightExpression = Expression.Convert(
            Right.GenerateExpression(tolerance),
            typeof(int));
        return Left.ReturnType switch
        {
            SupportedValueType.Numeric => Expression.RightShift(
                Left.GenerateExpression(tolerance),
                rightExpression),
            SupportedValueType.ByteArray => Expression.Call(
                typeof(BitwiseExtensions).GetMethodWithExactParameters(
                    nameof(BitwiseExtensions.RightShift),
                    typeof(byte[]),
                    typeof(int))!,
                Left.GenerateExpression(tolerance),
                rightExpression),
            _ => throw new ExpressionNotValidLogicallyException()
        };
    }
}