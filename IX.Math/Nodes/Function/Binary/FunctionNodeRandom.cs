using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

using IX.Math.Extensibility;
using IX.Math.Generators;

namespace IX.Math.Nodes.Function.Binary;

/// <summary>
///     A node representing the random function.
/// </summary>
/// <seealso cref="NumericBinaryFunctionNodeBase" />
[DebuggerDisplay($"random({{{nameof(FirstParameter)}}}, {{{nameof(SecondParameter)}}})")]
[CallableMathematicsFunction(
    "rand",
    "random")]
[UsedImplicitly]
internal sealed class FunctionNodeRandom : NumericBinaryFunctionNodeBase
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="FunctionNodeRandom" /> class.
    /// </summary>
    /// <param name="firstParameter">The first parameter.</param>
    /// <param name="secondParameter">The second parameter.</param>
    public FunctionNodeRandom(
        NodeBase firstParameter,
        NodeBase secondParameter)
        : base(
            Requires.NotNull(firstParameter).Simplify(),
            Requires.NotNull(secondParameter).Simplify()) { }

    /// <summary>
    ///     Generates a random value.
    /// </summary>
    /// <param name="min">The minimum.</param>
    /// <param name="max">The maximum.</param>
    /// <returns>The random value.</returns>
    [UsedImplicitly]
    public static double GenerateRandom(
        double min,
        double max) => RandomNumberGenerator.Generate(
        min,
        max);

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
    public override NodeBase DeepClone(NodeCloningContext context) => new FunctionNodeRandom(
        FirstParameter.DeepClone(context),
        SecondParameter.DeepClone(context));

    /// <summary>
    ///     Generates the expression that will be compiled into code.
    /// </summary>
    /// <returns>
    ///     The expression.
    /// </returns>
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    protected override Expression GenerateExpressionInternal() =>
        GenerateStaticBinaryFunctionCall<FunctionNodeRandom>(nameof(GenerateRandom));

    /// <summary>
    ///     Generates the expression with tolerance that will be compiled into code.
    /// </summary>
    /// <param name="tolerance">The tolerance.</param>
    /// <returns>The expression.</returns>
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    protected override Expression GenerateExpressionInternal(Tolerance? tolerance) =>
        GenerateStaticBinaryFunctionCall<FunctionNodeRandom>(
            nameof(GenerateRandom),
            tolerance);
}