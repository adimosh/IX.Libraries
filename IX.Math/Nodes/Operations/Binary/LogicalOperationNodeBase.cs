namespace IX.Math.Nodes.Operations.Binary;

/// <summary>
///     A node base for logical operations.
/// </summary>
/// <seealso cref="BinaryOperatorNodeBase" />
internal abstract class LogicalOperationNodeBase : BinaryOperatorNodeBase
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="LogicalOperationNodeBase" /> class.
    /// </summary>
    /// <param name="left">The left operand.</param>
    /// <param name="right">The right operand.</param>
    protected private LogicalOperationNodeBase(
        NodeBase left,
        NodeBase right)
        : base(
            left,
            right) { }

    /// <summary>
    ///     Gets the return type of this node.
    /// </summary>
    /// <value>
    ///     The node return type.
    /// </value>
    public override SupportedValueType ReturnType => Left.ReturnType;

    /// <summary>
    ///     Determines the children.
    /// </summary>
    /// <param name="parameter">The parameter.</param>
    /// <param name="other">The other.</param>
    /// <exception cref="ExpressionNotValidLogicallyException">Undeterminable children.</exception>
    private static void DetermineChildren(
        NodeBase parameter,
        NodeBase other)
    {
        switch (other.ReturnType)
        {
            case SupportedValueType.Boolean:
                parameter.DetermineStrongly(SupportedValueType.Boolean);
                break;
            case SupportedValueType.Numeric:
                parameter.DetermineStrongly(SupportedValueType.Numeric);
                break;
            case SupportedValueType.Unknown:
                break;
            default:
                throw new ExpressionNotValidLogicallyException();
        }
    }

    /// <summary>
    ///     Strongly determines the node's type, if possible.
    /// </summary>
    /// <param name="type">The type to determine to.</param>
    public override void DetermineStrongly(SupportedValueType type)
    {
        if (type is SupportedValueType.Boolean or SupportedValueType.Numeric)
        {
            Left.DetermineStrongly(type);
            Right.DetermineStrongly(type);

            EnsureCompatibleOperands(
                Left,
                Right);
        }
        else
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
        if ((type & SupportableValueType.Numeric) == 0 && (type & SupportableValueType.Boolean) == 0)
        {
            throw new ExpressionNotValidLogicallyException();
        }

        Left.DetermineWeakly(type);
        Right.DetermineWeakly(type);

        EnsureCompatibleOperands(
            Left,
            Right);
    }

    protected override void EnsureCompatibleOperands(
        NodeBase left,
        NodeBase right)
    {
        left.DetermineWeakly(SupportableValueType.Boolean | SupportableValueType.Numeric);
        right.DetermineWeakly(SupportableValueType.Boolean | SupportableValueType.Numeric);

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
    }
}