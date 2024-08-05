using IX.Math.Extensibility;

namespace IX.Math.Nodes.Operations.Unary;

/// <summary>
/// A base node for unary operators.
/// </summary>
/// <seealso cref="IX.Math.Nodes.OperationNodeBase" />
internal abstract class UnaryOperatorNodeBase : OperationNodeBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UnaryOperatorNodeBase"/> class.
    /// </summary>
    /// <param name="operand">The operand.</param>
    /// <exception cref="ArgumentNullException">operand
    /// is <c>null</c> (<c>Nothing</c> in Visual Basic).</exception>
    protected private UnaryOperatorNodeBase(NodeBase operand) => Operand = operand ?? throw new ArgumentNullException(nameof(operand));

    /// <summary>
    ///     Gets a value indicating whether this node supports tolerance.
    /// </summary>
    /// <value>
    ///     <c>true</c> if this instance is tolerant; otherwise, <c>false</c>.
    /// </value>
    public override bool IsTolerant => Operand.IsTolerant;

    /// <summary>
    /// Gets the operand.
    /// </summary>
    /// <value>
    /// The operand.
    /// </value>
    protected NodeBase Operand { get; }

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
    protected override OperationNodeBase DeepCloneNode(NodeCloningContext context) => (OperationNodeBase)DeepClone(context);

    /// <summary>
    /// Sets the special object request function for sub objects.
    /// </summary>
    /// <param name="func">The function.</param>
    protected override void SetSpecialObjectRequestFunctionForSubObjects(Func<Type, object> func)
    {
        if (Operand is ISpecialRequestNode specialRequestNode)
        {
            specialRequestNode.SetRequestSpecialObjectFunction(func);
        }
    }
}