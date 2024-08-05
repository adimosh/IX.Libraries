using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

using IX.Math.Extensibility;
using IX.Math.Generators;

namespace IX.Math.Nodes.Function.Nonary;

/// <summary>
///     A node representing the random integer function.
/// </summary>
/// <seealso cref="NonaryFunctionNodeBase" />
[DebuggerDisplay("randomint()")]
[CallableMathematicsFunction("randomint")]
internal sealed class FunctionNodeRandomInt : NonaryFunctionNodeBase
{
    /// <summary>
    ///     Gets the return type of this node.
    /// </summary>
    /// <value>
    ///     The node return type.
    /// </value>
    public override SupportedValueType ReturnType => SupportedValueType.Numeric;

    /// <summary>
    ///     Generates a random number.
    /// </summary>
    /// <returns>A random number.</returns>
    public static long GenerateRandom() => RandomNumberGenerator.GenerateInt();

    /// <summary>
    ///     Simplifies this node, if possible, reflexively returns otherwise.
    /// </summary>
    /// <returns>
    ///     A simplified node, or this instance.
    /// </returns>
    public override NodeBase Simplify() => this;

    /// <summary>
    ///     Creates a deep clone of the source object.
    /// </summary>
    /// <param name="context">The deep cloning context.</param>
    /// <returns>
    ///     A deep clone.
    /// </returns>
    public override NodeBase DeepClone(NodeCloningContext context) => new FunctionNodeRandomInt();

    /// <summary>
    ///     Strongly determines the node's type, if possible.
    /// </summary>
    /// <param name="type">The type to determine to.</param>
    public override void DetermineStrongly(SupportedValueType type)
    {
        if (type != SupportedValueType.Numeric)
        {
            throw new ExpressionNotValidLogicallyException();
        }
    }

    /// <summary>
    ///     Weakly determines the node's type, if possible, and, optionally, strongly determines if there is only one possible
    ///     type left.
    /// </summary>
    /// <param name="type">The type or types to determine to.</param>
    public override void DetermineWeakly(SupportableValueType type)
    {
        if ((type & SupportableValueType.Numeric) == 0)
        {
            throw new ExpressionNotValidLogicallyException();
        }
    }

    /// <summary>
    ///     Generates the expression that will be compiled into code.
    /// </summary>
    /// <returns>
    ///     The expression.
    /// </returns>
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    protected override Expression GenerateExpressionInternal() =>
        GenerateStaticNonaryFunctionCall<FunctionNodeRandomInt>(nameof(GenerateRandom));
}