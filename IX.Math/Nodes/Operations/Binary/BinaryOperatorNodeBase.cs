using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

using IX.Math.Extensibility;

namespace IX.Math.Nodes.Operations.Binary;

/// <summary>
///     A node base for binary operations.
/// </summary>
/// <seealso cref="OperationNodeBase" />
internal abstract class BinaryOperatorNodeBase : OperationNodeBase
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="BinaryOperatorNodeBase" /> class.
    /// </summary>
    /// <param name="left">The left operand.</param>
    /// <param name="right">The right operand.</param>
    [SuppressMessage(
        "ReSharper",
        "VirtualMemberCallInConstructor",
        Justification = "We specifically want this to happen.")]
    protected private BinaryOperatorNodeBase(
        NodeBase left,
        NodeBase right)
    {
        _ = Requires.NotNull(left);
        _ = Requires.NotNull(right);

        EnsureCompatibleOperands(
            left,
            right);

        Left = left.Simplify();
        Right = right.Simplify();
    }

    /// <summary>
    ///     Gets a value indicating whether this node supports tolerance.
    /// </summary>
    /// <value>
    ///     <c>true</c> if this instance is tolerant; otherwise, <c>false</c>.
    /// </value>
    public override bool IsTolerant => Left.IsTolerant || Right.IsTolerant;

    /// <summary>
    ///     Gets the left operand.
    /// </summary>
    /// <value>
    ///     The left operand.
    /// </value>
    protected NodeBase Left { get; }

    /// <summary>
    ///     Gets the right operand.
    /// </summary>
    /// <value>
    ///     The right operand.
    /// </value>
    protected NodeBase Right { get; }

    /// <summary>
    ///     Creates a deep clone of the source object.
    /// </summary>
    /// <param name="context">The deep cloning context.</param>
    /// <returns>A deep clone.</returns>
    public new abstract NodeBase DeepClone(NodeCloningContext context);

    /// <summary>
    ///     Creates a deep clone of the source object.
    /// </summary>
    /// <param name="context">The deep cloning context.</param>
    /// <returns>A deep clone.</returns>
    protected override OperationNodeBase DeepCloneNode(NodeCloningContext context) =>
        (OperationNodeBase)DeepClone(context);

    /// <summary>
    ///     Ensures that the operands are compatible.
    /// </summary>
    /// <param name="left">The left operand.</param>
    /// <param name="right">The right operand.</param>
    protected abstract void EnsureCompatibleOperands(
        NodeBase left,
        NodeBase right);

    /// <summary>
    ///     Sets the special object request function for sub objects.
    /// </summary>
    /// <param name="func">The function.</param>
    protected override void SetSpecialObjectRequestFunctionForSubObjects(Func<Type, object> func)
    {
        if (Left is ISpecialRequestNode specialRequestNodeLeft)
        {
            specialRequestNodeLeft.SetRequestSpecialObjectFunction(func);
        }

        if (Right is ISpecialRequestNode specialRequestNodeRight)
        {
            specialRequestNodeRight.SetRequestSpecialObjectFunction(func);
        }
    }

    /// <summary>
    ///     Gets the expressions of same type from operands.
    /// </summary>
    /// <returns>The left and right operand expressions.</returns>
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    protected (Expression Left, Expression Right) GetExpressionsOfSameTypeFromOperands()
    {
        if (Left.ReturnType == SupportedValueType.String || Right.ReturnType == SupportedValueType.String)
        {
            return (Left.GenerateStringExpression(), Right.GenerateStringExpression());
        }

        Expression le = Left.GenerateExpression();
        Expression re = Right.GenerateExpression();

        if (le.Type == typeof(double) && re.Type == typeof(long))
        {
            return (Left: le, Right: Expression.Convert(
                re,
                typeof(double)));
        }

        if (le.Type == typeof(long) && re.Type == typeof(double))
        {
            return (Left: Expression.Convert(
                le,
                typeof(double)), Right: re);
        }

        return (Left: le, Right: re);
    }

    /// <summary>
    ///     Gets the expressions of same type from operands.
    /// </summary>
    /// <param name="tolerance">The tolerance.</param>
    /// <returns>The left and right operand expressions.</returns>
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    protected (Expression Left, Expression Right) GetExpressionsOfSameTypeFromOperands(Tolerance? tolerance)
    {
        if (Left.ReturnType == SupportedValueType.String || Right.ReturnType == SupportedValueType.String)
        {
            return (Left.GenerateStringExpression(tolerance), Right.GenerateStringExpression(tolerance));
        }

        Expression le = Left.GenerateExpression(tolerance);
        Expression re = Right.GenerateExpression(tolerance);

        if (le.Type == typeof(double) && re.Type == typeof(long))
        {
            return (Left: le, Right: Expression.Convert(
                re,
                typeof(double)));
        }

        if (le.Type == typeof(long) && re.Type == typeof(double))
        {
            return (Left: Expression.Convert(
                le,
                typeof(double)), Right: re);
        }

        return (Left: le, Right: re);
    }
}