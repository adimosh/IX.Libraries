using IX.Library.Contracts;

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;

using IX.Math.Extensibility;
using IX.Math.Nodes.Constants;

namespace IX.Math.Nodes.Function.Binary;

/// <summary>
///     A node representing the substring function.
/// </summary>
/// <seealso cref="BinaryFunctionNodeBase" />
[DebuggerDisplay($"substring({{{nameof(FirstParameter)}}}, {{{nameof(SecondParameter)}}})")]
[CallableMathematicsFunction(
    "substr",
    "substring")]
[UsedImplicitly]
internal sealed class FunctionNodeSubstring : BinaryFunctionNodeBase
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="FunctionNodeSubstring" /> class.
    /// </summary>
    /// <param name="stringParameter">The string parameter.</param>
    /// <param name="numericParameter">The numeric parameter.</param>
    public FunctionNodeSubstring(
        NodeBase stringParameter,
        NodeBase numericParameter)
        : base(
            Requires.NotNull(stringParameter).Simplify(),
            Requires.NotNull(numericParameter).Simplify()) { }

    /// <summary>
    ///     Gets the return type of this node.
    /// </summary>
    /// <value>
    ///     The node return type.
    /// </value>
    public override SupportedValueType ReturnType => SupportedValueType.String;

    /// <summary>
    ///     Creates a deep clone of the source object.
    /// </summary>
    /// <param name="context">The deep cloning context.</param>
    /// <returns>
    ///     A deep clone.
    /// </returns>
    public override NodeBase DeepClone(NodeCloningContext context) => new FunctionNodeSubstring(
        FirstParameter.DeepClone(context),
        SecondParameter.DeepClone(context));

    /// <summary>
    ///     Simplifies this node, if possible, reflexively returns otherwise.
    /// </summary>
    /// <returns>
    ///     A simplified node, or this instance.
    /// </returns>
    public override NodeBase Simplify() =>
        FirstParameter is StringNode stringParam && SecondParameter is NumericNode numericParam
            ? new StringNode(stringParam.Value.Substring(numericParam.ExtractInt()))
            : this;

    /// <summary>
    ///     Strongly determines the node's type, if possible.
    /// </summary>
    /// <param name="type">The type to determine to.</param>
    public override void DetermineStrongly(SupportedValueType type)
    {
        if (type != SupportedValueType.String)
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
        if ((type & SupportableValueType.String) == 0)
        {
            throw new ExpressionNotValidLogicallyException();
        }
    }

    /// <summary>
    ///     Ensures that the parameters that are received are compatible with the function, optionally allowing the parameter
    ///     references to change.
    /// </summary>
    /// <param name="firstParameter">The first parameter.</param>
    /// <param name="secondParameter">The second parameter.</param>
    /// <exception cref="ExpressionNotValidLogicallyException">The expression is not valid, as its parameters are not strings.</exception>
    protected override void EnsureCompatibleParameters(
        NodeBase firstParameter,
        NodeBase secondParameter)
    {
        firstParameter.DetermineStrongly(SupportedValueType.String);
        secondParameter.DetermineStrongly(SupportedValueType.Numeric);

        if (firstParameter.ReturnType != SupportedValueType.String ||
            secondParameter.ReturnType != SupportedValueType.Numeric)
        {
            throw new ExpressionNotValidLogicallyException();
        }

        if (secondParameter is ParameterNode pn)
        {
            _ = pn.DetermineInteger();
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
    protected override Expression GenerateExpressionInternal() => GenerateExpressionInternal(null);

    /// <summary>
    ///     Generates the expression with tolerance that will be compiled into code.
    /// </summary>
    /// <param name="tolerance">The tolerance.</param>
    /// <returns>The expression.</returns>
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    protected override Expression GenerateExpressionInternal(Tolerance? tolerance)
    {
        Type firstParameterType = typeof(string);
        Type secondParameterType = typeof(int);
        const string functionName = nameof(string.Substring);

        MethodInfo mi = typeof(string).GetMethodWithExactParameters(
            functionName,
            secondParameterType)!;

        if (mi == null)
        {
            throw new InvalidOperationException(
                string.Format(
                    CultureInfo.CurrentCulture,
                    Resources.FunctionCouldNotBeFound,
                    functionName));
        }

        Expression e1, e2;

        if (tolerance == null)
        {
            e1 = FirstParameter.GenerateExpression();
            e2 = SecondParameter.GenerateExpression();
        }
        else
        {
            e1 = FirstParameter.GenerateExpression(tolerance);
            e2 = SecondParameter.GenerateExpression(tolerance);
        }

        if (e1.Type != firstParameterType)
        {
            e1 = Expression.Convert(
                e1,
                firstParameterType);
        }

        if (e2.Type != secondParameterType)
        {
            e2 = Expression.Convert(
                e2,
                secondParameterType);
        }

        return Expression.Call(
            e1,
            mi,
            e2);
    }
}