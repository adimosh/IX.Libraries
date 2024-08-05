using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

using IX.Math.Extensibility;
using IX.Math.Nodes.Constants;
using IX.Math.TypeHelpers;

using GlobalSystem = System;

namespace IX.Math.Nodes.Function.Binary;

/// <summary>
///     A node representing the <see cref="GlobalSystem.Math.Max(double, double)" /> function.
/// </summary>
/// <seealso cref="NumericBinaryFunctionNodeBase" />
/// <remarks>
///     Initializes a new instance of the <see cref="FunctionNodeMaximum" /> class.
/// </remarks>
/// <param name="firstParameter">The first parameter.</param>
/// <param name="secondParameter">The second parameter.</param>
[DebuggerDisplay($"max({{{nameof(FirstParameter)}}}, {{{nameof(SecondParameter)}}})")]
[CallableMathematicsFunction(
    "max",
    "maximum")]
internal sealed class FunctionNodeMaximum(
    NodeBase firstParameter,
    NodeBase secondParameter) : NumericBinaryFunctionNodeBase(
        (firstParameter ?? throw new ArgumentNullException(nameof(firstParameter))).Simplify(),
        (secondParameter ?? throw new ArgumentNullException(nameof(secondParameter))).Simplify())
{

    /// <summary>
    ///     Creates a deep clone of the source object.
    /// </summary>
    /// <param name="context">The deep cloning context.</param>
    /// <returns>
    ///     A deep clone.
    /// </returns>
    public override NodeBase DeepClone(NodeCloningContext context) =>
        new FunctionNodeMaximum(
            FirstParameter.DeepClone(context),
            SecondParameter.DeepClone(context));

    /// <summary>
    ///     Simplifies this node, if possible, reflexively returns otherwise.
    /// </summary>
    /// <returns>
    ///     A simplified node, or this instance.
    /// </returns>
    public override NodeBase Simplify()
    {
        if (FirstParameter is not NumericNode firstParam || SecondParameter is not NumericNode secondParam)
        {
            // Cannot be simplified
            return this;
        }

        var (left, right, isInteger) = NumericTypeHelper.DistillLowestCommonType(
            firstParam.Value,
            secondParam.Value);

        if (isInteger)
        {
            // Both are integer
            return new NumericNode(
                GlobalSystem.Math.Max(
                    (long)left,
                    (long)right));
        }

        // At least one is float
        return new NumericNode(
            GlobalSystem.Math.Max(
                (double)left,
                (double)right));
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
        GenerateStaticBinaryFunctionCall(
            typeof(GlobalSystem.Math),
            nameof(GlobalSystem.Math.Max));

    /// <summary>
    ///     Generates the expression with tolerance that will be compiled into code.
    /// </summary>
    /// <param name="tolerance">The tolerance.</param>
    /// <returns>The expression.</returns>
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    protected override Expression GenerateExpressionInternal(Tolerance? tolerance) =>
        GenerateStaticBinaryFunctionCall(
            typeof(GlobalSystem.Math),
            nameof(GlobalSystem.Math.Max),
            tolerance);
}