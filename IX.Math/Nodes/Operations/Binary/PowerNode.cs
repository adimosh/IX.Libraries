using IX.Library.Contracts;

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

using IX.Math.Nodes.Constants;

namespace IX.Math.Nodes.Operations.Binary;

/// <summary>
///     A node for a power operation.
/// </summary>
/// <seealso cref="SimpleMathematicalOperationNodeBase" />
[DebuggerDisplay($"{{{nameof(Left)}}} ^ {{{nameof(Right)}}}")]
internal sealed class PowerNode : SimpleMathematicalOperationNodeBase
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="PowerNode" /> class.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    public PowerNode(
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
    public override NodeBase Simplify()
    {
        if (Left is NumericNode nnLeft && Right is NumericNode nnRight)
        {
            return NumericNode.Power(
                nnLeft,
                nnRight);
        }

        return this;
    }

    /// <summary>
    ///     Creates a deep clone of the source object.
    /// </summary>
    /// <param name="context">The deep cloning context.</param>
    /// <returns>A deep clone.</returns>
    public override NodeBase DeepClone(NodeCloningContext context) =>
        new PowerNode(
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
        Expression.Call(
            typeof(global::System.Math),
            nameof(global::System.Math.Pow),
            null,
            Expression.Convert(
                Left.GenerateExpression(),
                typeof(double)), Expression.Convert(
                Right.GenerateExpression(),
                typeof(double)));

    /// <summary>
    ///     Generates the expression with tolerance that will be compiled into code.
    /// </summary>
    /// <param name="tolerance">The tolerance.</param>
    /// <returns>The expression.</returns>
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    protected override Expression GenerateExpressionInternal(Tolerance? tolerance) =>
        Expression.Call(
            typeof(global::System.Math),
            nameof(global::System.Math.Pow),
            null,
            Expression.Convert(
                Left.GenerateExpression(tolerance),
                typeof(double)), Expression.Convert(
                Right.GenerateExpression(tolerance),
                typeof(double)));
}