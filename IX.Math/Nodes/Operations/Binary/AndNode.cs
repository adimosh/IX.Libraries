using IX.Library.Contracts;

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

using IX.Math.Nodes.Constants;

namespace IX.Math.Nodes.Operations.Binary;

/// <summary>
///     A node representing a logical and operation.
/// </summary>
/// <seealso cref="LogicalOperationNodeBase" />
[DebuggerDisplay($"{{{nameof(Left)}}} & {{{nameof(Right)}}}")]
internal sealed class AndNode : LogicalOperationNodeBase
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="AndNode" /> class.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    public AndNode(
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
            NumericNode nnLeft when Right is NumericNode nnRight => new NumericNode(
                nnLeft.ExtractInteger() & nnRight.ExtractInteger()),
            BoolNode bnLeft when Right is BoolNode bnRight => new BoolNode(bnLeft.Value & bnRight.Value),
            _ => this
        };

    /// <summary>
    ///     Creates a deep clone of the source object.
    /// </summary>
    /// <param name="context">The deep cloning context.</param>
    /// <returns>A deep clone.</returns>
    public override NodeBase DeepClone(NodeCloningContext context) =>
        new AndNode(
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
    protected override Expression GenerateExpressionInternal() =>
        Expression.And(
            Left.GenerateExpression(),
            Right.GenerateExpression());

    /// <summary>
    ///     Generates the expression with tolerance that will be compiled into code.
    /// </summary>
    /// <param name="tolerance">The tolerance.</param>
    /// <returns>The expression.</returns>
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    protected override Expression GenerateExpressionInternal(Tolerance? tolerance) =>
        Expression.And(
            Left.GenerateExpression(tolerance),
            Right.GenerateExpression(tolerance));
}