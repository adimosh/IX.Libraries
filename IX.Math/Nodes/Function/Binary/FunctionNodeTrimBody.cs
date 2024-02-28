using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;

using IX.Math.Extensibility;
using IX.Math.Nodes.Constants;

namespace IX.Math.Nodes.Function.Binary;

/// <summary>
///     A node representing a function.
/// </summary>
/// <seealso cref="BinaryFunctionNodeBase" />
[DebuggerDisplay($"trimbody({{{nameof(FirstParameter)}}}, {{{nameof(SecondParameter)}}})")]
[CallableMathematicsFunction("trimbody")]
[UsedImplicitly]
internal sealed class FunctionNodeTrimBody : BinaryFunctionNodeBase
{
    public FunctionNodeTrimBody(
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
    public override NodeBase DeepClone(NodeCloningContext context) => new FunctionNodeTrimBody(
        FirstParameter.DeepClone(context),
        SecondParameter.DeepClone(context));

    /// <summary>
    ///     Simplifies this node, if possible, reflexively returns otherwise.
    /// </summary>
    /// <returns>
    ///     A simplified node, or this instance.
    /// </returns>
    public override NodeBase Simplify() =>
        FirstParameter is StringNode stringParam && SecondParameter is StringNode charParam
            ? new StringNode(
                stringParam.Value.Replace(
                    charParam.Value,
                    string.Empty))
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
        secondParameter.DetermineStrongly(SupportedValueType.String);

        if (firstParameter.ReturnType != SupportedValueType.String ||
            secondParameter.ReturnType != SupportedValueType.String)
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
        MethodInfo mi = typeof(string).GetMethodWithExactParameters(
            nameof(string.Replace),
            typeof(string),
            typeof(string))!;

        if (mi == null)
        {
            throw new InvalidOperationException(
                string.Format(
                    CultureInfo.CurrentCulture,
                    Resources.FunctionCouldNotBeFound,
                    nameof(string.Replace)));
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

        if (e1.Type != typeof(string))
        {
            e1 = Expression.Convert(
                e1,
                typeof(string));
        }

        if (e2.Type != typeof(string))
        {
            e2 = Expression.Convert(
                e2,
                typeof(string));
        }

        return Expression.Call(
            e1,
            mi,
            e2,
            Expression.Constant(
                string.Empty,
                typeof(string)));
    }
}