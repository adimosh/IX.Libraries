using IX.Library.Contracts;

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

using IX.Math.Nodes.Constants;

namespace IX.Math.Nodes.Operations.Binary;

/// <summary>
///     A node representing a bitwise left shift operation.
/// </summary>
/// <seealso cref="ByteShiftOperationNodeBase" />
[DebuggerDisplay($"{{{nameof(Left)}}} << {{{nameof(Right)}}}")]
internal sealed class LeftShiftNode : ByteShiftOperationNodeBase
{
    public LeftShiftNode(
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
            NumericNode nLeft when Right is NumericNode nRight => NumericNode.LeftShift(
                nLeft,
                nRight),
            ByteArrayNode baLeft when Right is NumericNode baRight => new ByteArrayNode(
                baLeft.Value.LeftShift(baRight.ExtractInt())),
            _ => this
        };

    /// <summary>
    ///     Creates a deep clone of the source object.
    /// </summary>
    /// <returns>A deep clone.</returns>
    public override NodeBase DeepClone(NodeCloningContext context) =>
        new LeftShiftNode(
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
            SupportedValueType.Numeric => Expression.LeftShift(
                Left.GenerateExpression(),
                rightExpression),
            SupportedValueType.ByteArray => Expression.Call(
                typeof(BitwiseExtensions).GetMethodWithExactParameters(
                    nameof(BitwiseExtensions.LeftShift),
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
            SupportedValueType.Numeric => Expression.LeftShift(
                Left.GenerateExpression(tolerance),
                rightExpression),
            SupportedValueType.ByteArray => Expression.Call(
                typeof(BitwiseExtensions).GetMethodWithExactParameters(
                    nameof(BitwiseExtensions.LeftShift),
                    typeof(byte[]),
                    typeof(int))!,
                Left.GenerateExpression(tolerance),
                rightExpression),
            _ => throw new ExpressionNotValidLogicallyException()
        };
    }
}