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
[DebuggerDisplay($"randomint({{{nameof(Parameter)}}})")]
[CallableMathematicsFunction("randomint")]
internal sealed class FunctionNodeRandomInt : NumericUnaryFunctionNodeBase
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="FunctionNodeRandomInt" /> class.
    /// </summary>
    /// <param name="parameter">The parameter.</param>
    public FunctionNodeRandomInt(NodeBase parameter)
        : base(parameter)
    {
        if (parameter is ParameterNode firstParameter)
        {
            _ = firstParameter.DetermineInteger();
        }
    }

    /// <summary>
    ///     Generates a random number.
    /// </summary>
    /// <param name="max">The maximum.</param>
    /// <returns>A random number.</returns>
    public static long GenerateRandom(long max) => RandomNumberGenerator.GenerateInt(max);

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
        new FunctionNodeRandomInt(Parameter.DeepClone(context));

    /// <summary>
    ///     Generates the expression that will be compiled into code.
    /// </summary>
    /// <returns>
    ///     The expression.
    /// </returns>
    protected override Expression GenerateExpressionInternal() =>
        GenerateStaticUnaryFunctionCall<FunctionNodeRandomInt>(nameof(GenerateRandom));

    /// <summary>
    ///     Generates the expression with tolerance that will be compiled into code.
    /// </summary>
    /// <param name="tolerance">The tolerance.</param>
    /// <returns>The expression.</returns>
    protected override Expression GenerateExpressionInternal(Tolerance? tolerance) =>
        GenerateStaticUnaryFunctionCall<FunctionNodeRandomInt>(
            nameof(GenerateRandom),
            tolerance);
}