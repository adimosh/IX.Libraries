using System.Diagnostics;
using System.Linq.Expressions;
using IX.Math.Extensibility;
using IX.Math.Generators;
using GlobalSystem = System;

namespace IX.Math.Nodes.Function.Unary;

/// <summary>
///     A node representing the <see cref="GlobalSystem.Random.Next(int)" /> function.
/// </summary>
/// <seealso cref="NumericUnaryFunctionNodeBase" />
/// <remarks>
///     Initializes a new instance of the <see cref="FunctionNodeRandom" /> class.
/// </remarks>
/// <param name="parameter">The parameter.</param>
[DebuggerDisplay($"random({{{nameof(Parameter)}}})")]
[CallableMathematicsFunction(
    "rand",
    "random")]
internal sealed class FunctionNodeRandom(NodeBase parameter) : NumericUnaryFunctionNodeBase(parameter)
{

    /// <summary>
    ///     Generates a random number.
    /// </summary>
    /// <param name="max">The maximum.</param>
    /// <returns>A random number.</returns>
    public static double GenerateRandom(double max) => RandomNumberGenerator.Generate(max);

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
    public override NodeBase DeepClone(NodeCloningContext context) =>
        new FunctionNodeRandom(Parameter.DeepClone(context));

    /// <summary>
    ///     Generates the expression that will be compiled into code.
    /// </summary>
    /// <returns>
    ///     The expression.
    /// </returns>
    protected override Expression GenerateExpressionInternal() =>
        GenerateStaticUnaryFunctionCall<FunctionNodeRandom>(nameof(GenerateRandom));

    /// <summary>
    ///     Generates the expression with tolerance that will be compiled into code.
    /// </summary>
    /// <param name="tolerance">The tolerance.</param>
    /// <returns>The expression.</returns>
    protected override Expression GenerateExpressionInternal(Tolerance? tolerance) =>
        GenerateStaticUnaryFunctionCall<FunctionNodeRandom>(
            nameof(GenerateRandom),
            tolerance);
}