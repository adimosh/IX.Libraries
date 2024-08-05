using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;

using IX.Math.Extensibility;
using IX.Math.Formatters;
using IX.Math.Nodes.Constants;

namespace IX.Math.Nodes.Operations.Binary;

/// <summary>
///     A node representing an addition operation.
/// </summary>
/// <seealso cref="BinaryOperatorNodeBase" />
/// <remarks>
///     Initializes a new instance of the <see cref="AddNode" /> class.
/// </remarks>
/// <param name="left">The left.</param>
/// <param name="right">The right.</param>
[DebuggerDisplay($"{{{nameof(Left)}}} + {{{nameof(Right)}}}")]
internal sealed class AddNode(
    NodeBase left,
    NodeBase right) : BinaryOperatorNodeBase(
        (left ?? throw new ArgumentNullException(nameof(left))).Simplify(),
        (right ?? throw new ArgumentNullException(nameof(right))).Simplify())
{
    /// <summary>
    ///     Gets the return type of this node.
    /// </summary>
    /// <value>
    ///     The node return type.
    /// </value>
    public override SupportedValueType ReturnType
    {
        get
        {
            if (Left.ReturnType == SupportedValueType.String || Right.ReturnType == SupportedValueType.String)
            {
                return SupportedValueType.String;
            }

            return Left.ReturnType switch
            {
                SupportedValueType.ByteArray => Right.ReturnType == SupportedValueType.ByteArray
                    ? SupportedValueType.ByteArray
                    : SupportedValueType.Unknown,
                SupportedValueType.Numeric => Right.ReturnType == SupportedValueType.Numeric
                    ? SupportedValueType.Numeric
                    : SupportedValueType.Unknown,
                _ => SupportedValueType.Unknown
            };
        }
    }

    /// <summary>
    ///     Determines the children in the correct types.
    /// </summary>
    /// <param name="parameter">The parameter.</param>
    /// <param name="other">The other.</param>
    private static void DetermineChildren(
        NodeBase parameter,
        NodeBase other)
    {
        switch (other.ReturnType)
        {
            case SupportedValueType.Boolean:
                parameter.DetermineStrongly(SupportedValueType.String);
                break;
            case SupportedValueType.Numeric:
                parameter.DetermineWeakly(SupportableValueType.Numeric | SupportableValueType.String);
                break;
            case SupportedValueType.ByteArray:
                parameter.DetermineWeakly(SupportableValueType.ByteArray | SupportableValueType.String);
                break;
        }
    }

    /// <summary>
    ///     Stitches the specified byte arrays.
    /// </summary>
    /// <param name="left">The left array operand.</param>
    /// <param name="right">The right array operand.</param>
    /// <returns>A stitched array of bytes.</returns>
    private static byte[] Stitch(
        byte[] left,
        byte[] right)
    {
        var r = new byte[left.Length + right.Length];
        Array.Copy(
            left,
            r,
            left.Length);
        Array.Copy(
            right,
            0,
            r,
            left.Length,
            right.Length);
        return r;
    }

    /// <summary>
    ///     Simplifies this node, if possible, reflexively returns otherwise.
    /// </summary>
    /// <returns>
    ///     A simplified node, or this instance.
    /// </returns>
    public override NodeBase Simplify()
    {
        if (Left.IsConstant != Right.IsConstant)
        {
            return this;
        }

        if (!Left.IsConstant)
        {
            return this;
        }

        switch (Left)
        {
            case NumericNode nn1Left when Right is NumericNode nn1Right:
                return NumericNode.Add(
                    nn1Left,
                    nn1Right);
            case StringNode sn1Left when Right is StringNode sn1Right:
                return new StringNode(sn1Left.Value + sn1Right.Value);
            case NumericNode nn2Left when Right is StringNode sn2Right:
            {
                var stringValue =
                    SpecialObjectRequestFunction?.Invoke(typeof(IStringFormatter)) is not List<IStringFormatter>
                        formatters
                        ? nn2Left.Value.ToString()
                        : StringFormatter.FormatIntoString(
                            nn2Left.Value,
                            formatters);

                return new StringNode($"{stringValue}{sn2Right.Value}");
            }

            case StringNode sn3Left when Right is NumericNode nn3Right:
            {
                var stringValue =
                    SpecialObjectRequestFunction?.Invoke(typeof(IStringFormatter)) is not List<IStringFormatter>
                        formatters
                        ? nn3Right.Value.ToString()
                        : StringFormatter.FormatIntoString(
                            nn3Right.Value,
                            formatters);

                return new StringNode($"{sn3Left.Value}{stringValue}");
            }

            case BoolNode bn4Left when Right is StringNode sn4Right:
            {
                var stringValue =
                    SpecialObjectRequestFunction?.Invoke(typeof(IStringFormatter)) is not List<IStringFormatter>
                        formatters
                        ? bn4Left.Value.ToString(CultureInfo.CurrentCulture)
                        : StringFormatter.FormatIntoString(
                            bn4Left.Value,
                            formatters);

                return new StringNode($"{stringValue}{sn4Right.Value}");
            }

            case StringNode sn5Left when Right is BoolNode bn5Right:
            {
                var stringValue =
                    SpecialObjectRequestFunction?.Invoke(typeof(IStringFormatter)) is not List<IStringFormatter>
                        formatters
                        ? bn5Right.Value.ToString(CultureInfo.CurrentCulture)
                        : StringFormatter.FormatIntoString(
                            bn5Right.Value,
                            formatters);

                return new StringNode($"{sn5Left.Value}{stringValue}");
            }

            case ByteArrayNode ban5Left when Right is ByteArrayNode ban5Right:
                return new ByteArrayNode(
                    Stitch(
                        ban5Left.Value,
                        ban5Right.Value));
            default:
                return this;
        }
    }

    /// <summary>
    ///     Creates a deep clone of the source object.
    /// </summary>
    /// <param name="context">The deep cloning context.</param>
    /// <returns>A deep clone.</returns>
    public override NodeBase DeepClone(NodeCloningContext context) => new AddNode(
        Left.DeepClone(context),
        Right.DeepClone(context));

    /// <summary>
    ///     Strongly determines the node's type, if possible.
    /// </summary>
    /// <param name="type">The type to determine to.</param>
    public override void DetermineStrongly(SupportedValueType type)
    {
        switch (type)
        {
            case SupportedValueType.Boolean:
                throw new ExpressionNotValidLogicallyException();
            case SupportedValueType.ByteArray:
                Left.DetermineStrongly(SupportedValueType.ByteArray);
                Right.DetermineStrongly(SupportedValueType.ByteArray);
                break;

            case SupportedValueType.Numeric:
                Left.DetermineStrongly(SupportedValueType.Numeric);
                Right.DetermineStrongly(SupportedValueType.Numeric);
                break;
        }

        EnsureCompatibleOperands(
            Left,
            Right);
    }

    /// <summary>
    ///     Weakly determines the node's type, if possible, and, optionally, strongly determines if there is only one possible
    ///     type left.
    /// </summary>
    /// <param name="type">The type or types to determine to.</param>
    public override void DetermineWeakly(SupportableValueType type)
    {
        if ((type & SupportableValueType.Boolean) != 0)
        {
            type ^= SupportableValueType.Boolean;
        }

        Left.DetermineWeakly(type);
        Right.DetermineWeakly(type);

        EnsureCompatibleOperands(
            Left,
            Right);
    }

    /// <summary>
    ///     Ensures that the operands are compatible.
    /// </summary>
    /// <param name="left">The left operand.</param>
    /// <param name="right">The right operand.</param>
    protected override void EnsureCompatibleOperands(
        NodeBase left,
        NodeBase right)
    {
        DetermineChildren(
            left,
            right);
        DetermineChildren(
            right,
            left);
        DetermineChildren(
            left,
            right);
        DetermineChildren(
            right,
            left);

        switch (left.ReturnType)
        {
            case SupportedValueType.Numeric:
                if (right.ReturnType is not SupportedValueType.Numeric and not SupportedValueType.String
                    and not SupportedValueType.Unknown)
                {
                    throw new ExpressionNotValidLogicallyException();
                }

                break;

            case SupportedValueType.Boolean:
                if (right.ReturnType != SupportedValueType.String)
                {
                    throw new ExpressionNotValidLogicallyException();
                }

                break;

            case SupportedValueType.ByteArray:
                if (right.ReturnType is not SupportedValueType.ByteArray and not SupportedValueType.String
                    and not SupportedValueType.Unknown)
                {
                    throw new ExpressionNotValidLogicallyException();
                }

                break;

            case SupportedValueType.String:
            case SupportedValueType.Unknown:
                break;
        }

        switch (right.ReturnType)
        {
            case SupportedValueType.Numeric:
                if (left.ReturnType is not SupportedValueType.Numeric and not SupportedValueType.String
                    and not SupportedValueType.Unknown)
                {
                    throw new ExpressionNotValidLogicallyException();
                }

                break;

            case SupportedValueType.Boolean:
                if (left.ReturnType != SupportedValueType.String)
                {
                    throw new ExpressionNotValidLogicallyException();
                }

                break;

            case SupportedValueType.ByteArray:
                if (left.ReturnType is not SupportedValueType.ByteArray and not SupportedValueType.String
                    and not SupportedValueType.Unknown)
                {
                    throw new ExpressionNotValidLogicallyException();
                }

                break;

            case SupportedValueType.String:
            case SupportedValueType.Unknown:
                break;
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
    protected override Expression GenerateExpressionInternal()
    {
        (Expression leftExpression, Expression rightExpression) = GetExpressionsOfSameTypeFromOperands();

        switch (ReturnType)
        {
            case SupportedValueType.String:
                MethodInfo mi1 = typeof(string).GetMethodWithExactParameters(
                    nameof(string.Concat),
                    typeof(string),
                    typeof(string))!;
                return Expression.Call(
                    mi1,
                    leftExpression,
                    rightExpression);
            case SupportedValueType.ByteArray:
                MethodInfo mi2 = typeof(AddNode).GetMethodWithExactParameters(
                    nameof(Stitch),
                    typeof(byte[]),
                    typeof(byte[]))!;
                return Expression.Call(
                    mi2,
                    leftExpression,
                    rightExpression);
            default:
                return Expression.Add(
                    leftExpression,
                    rightExpression);
        }
    }

    /// <summary>
    ///     Generates the expression with tolerance that will be compiled into code.
    /// </summary>
    /// <param name="tolerance">The tolerance.</param>
    /// <returns>The expression.</returns>
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    protected override Expression GenerateExpressionInternal(Tolerance? tolerance)
    {
        (Expression leftExpression, Expression rightExpression) = GetExpressionsOfSameTypeFromOperands(tolerance);

        switch (ReturnType)
        {
            case SupportedValueType.String:
                MethodInfo mi1 = typeof(string).GetMethodWithExactParameters(
                    nameof(string.Concat),
                    typeof(string),
                    typeof(string))!;
                return Expression.Call(
                    mi1,
                    leftExpression,
                    rightExpression);
            case SupportedValueType.ByteArray:
                MethodInfo mi2 = typeof(AddNode).GetMethodWithExactParameters(
                    nameof(Stitch),
                    typeof(byte[]),
                    typeof(byte[]))!;
                return Expression.Call(
                    mi2,
                    leftExpression,
                    rightExpression);
            default:
                return Expression.Add(
                    leftExpression,
                    rightExpression);
        }
    }
}