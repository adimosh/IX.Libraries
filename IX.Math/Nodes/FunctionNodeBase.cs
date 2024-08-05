using IX.Math.Nodes.Constants;

namespace IX.Math.Nodes;

/// <summary>
///     A base class for a function node.
/// </summary>
/// <seealso cref="OperationNodeBase" />
public abstract class FunctionNodeBase : OperationNodeBase
{
    /// <summary>
    ///     Prevents a default instance of the <see cref="FunctionNodeBase" /> class from being created.
    /// </summary>
    protected private FunctionNodeBase() { }

    /// <summary>
    ///     Gets the concrete type of parameter.
    /// </summary>
    /// <param name="parameter">The parameter.</param>
    /// <returns>The parameter type.</returns>
    /// <exception cref="InvalidOperationException">The parameter could not be correctly recognized, or is undefined.</exception>
    protected static Type ParameterTypeFromParameter(NodeBase parameter) => parameter.ReturnType switch
    {
        SupportedValueType.Boolean => typeof(bool),
        SupportedValueType.ByteArray => typeof(byte[]),
        SupportedValueType.String => typeof(string),
        SupportedValueType.Numeric => parameter switch
        {
            ParameterNode nn => nn.IsFloat == false ? typeof(long) : typeof(double),
            NumericNode cn => cn.IsFloat == false ? typeof(long) : typeof(double),
            _ => typeof(double)
        },
        _ => throw new InvalidOperationException()
    };

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
}