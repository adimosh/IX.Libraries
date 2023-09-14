using IX.Library.Contracts;

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

using IX.Math.Extensibility;
using IX.Math.Nodes.Constants;

using GlobalSystem = System;

namespace IX.Math.Nodes.Function.Binary;

/// <summary>
///     A node representing the <see cref="GlobalSystem.Math.Log(double, double)" /> function.
/// </summary>
/// <seealso cref="NumericBinaryFunctionNodeBase" />
[DebuggerDisplay($"log({{{nameof(FirstParameter)}}}, {{{nameof(SecondParameter)}}})")]
[CallableMathematicsFunction(
    "log",
    "logarithm")]
[UsedImplicitly]
internal sealed class FunctionNodeLogarithm : NumericBinaryFunctionNodeBase
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="FunctionNodeLogarithm" /> class.
    /// </summary>
    /// <param name="firstParameter">The first parameter.</param>
    /// <param name="secondParameter">The second parameter.</param>
    public FunctionNodeLogarithm(
        NodeBase firstParameter,
        NodeBase secondParameter)
        : base(
            Requires.NotNull(firstParameter).Simplify(),
            Requires.NotNull(secondParameter).Simplify()) { }

    /// <summary>
    ///     Creates a deep clone of the source object.
    /// </summary>
    /// <param name="context">The deep cloning context.</param>
    /// <returns>
    ///     A deep clone.
    /// </returns>
    public override NodeBase DeepClone(NodeCloningContext context) => new FunctionNodeLogarithm(
        FirstParameter.DeepClone(context),
        SecondParameter.DeepClone(context));

    /// <summary>
    ///     Simplifies this node, if possible, reflexively returns otherwise.
    /// </summary>
    /// <returns>
    ///     A simplified node, or this instance.
    /// </returns>
    public override NodeBase Simplify() =>
        FirstParameter is NumericNode firstParam && SecondParameter is NumericNode secondParam
            ? new NumericNode(
                GlobalSystem.Math.Log(
                    firstParam.ExtractFloat(),
                    secondParam.ExtractFloat()))
            : this;

    /// <summary>
    ///     Generates the expression that will be compiled into code.
    /// </summary>
    /// <returns>
    ///     The expression.
    /// </returns>
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    protected override Expression GenerateExpressionInternal() => GenerateStaticBinaryFunctionCall(
        typeof(GlobalSystem.Math),
        nameof(GlobalSystem.Math.Log));

    /// <summary>
    ///     Generates the expression with tolerance that will be compiled into code.
    /// </summary>
    /// <param name="tolerance">The tolerance.</param>
    /// <returns>The expression.</returns>
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    protected override Expression GenerateExpressionInternal(Tolerance? tolerance) => GenerateStaticBinaryFunctionCall(
        typeof(GlobalSystem.Math),
        nameof(GlobalSystem.Math.Log),
        tolerance);
}