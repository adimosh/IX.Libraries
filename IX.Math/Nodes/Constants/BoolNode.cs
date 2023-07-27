using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

using IX.Math.Extensibility;
using IX.Math.Formatters;

namespace IX.Math.Nodes.Constants;

/// <summary>
///     A boolean node. This class cannot be inherited.
/// </summary>
/// <seealso cref="ConstantNodeBase" />
[DebuggerDisplay($"{{{nameof(Value)}}}")]
[PublicAPI]
public sealed class BoolNode : ConstantNodeBase, ISpecialRequestNode
{
    private Func<Type, object>? _specialObjectRequestFunction;

    /// <summary>
    ///     Initializes a new instance of the <see cref="BoolNode" /> class.
    /// </summary>
    /// <param name="value">The node's boolean value.</param>
    public BoolNode(bool value) => Value = value;

    /// <summary>
    ///     Gets a value indicating this <see cref="BoolNode" />'s value.
    /// </summary>
    /// <value>The node's value.</value>
    public bool Value { get; private set; }

    /// <summary>
    ///     Gets the return type of this node.
    /// </summary>
    /// <value>Always <see cref="SupportedValueType.Boolean" />.</value>
    public override SupportedValueType ReturnType => SupportedValueType.Boolean;

    /// <summary>
    ///     Sets the request special object function.
    /// </summary>
    /// <param name="func">The function to set.</param>
    void ISpecialRequestNode.SetRequestSpecialObjectFunction(Func<Type, object> func) =>
        _specialObjectRequestFunction = func;

    /// <summary>
    ///     Generates the expression that will be compiled into code as a string expression.
    /// </summary>
    /// <returns>The string expression.</returns>
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    public override Expression GenerateCachedStringExpression()
    {
        var stringFormatters =
            _specialObjectRequestFunction?.Invoke(typeof(IStringFormatter)) as List<IStringFormatter>;
        return Expression.Constant(
            StringFormatter.FormatIntoString(
                Value,
                stringFormatters), typeof(string));
    }

    /// <summary>
    ///     Creates a deep clone of the source object.
    /// </summary>
    /// <param name="context">The deep cloning context.</param>
    /// <returns>A deep clone.</returns>
    public override NodeBase DeepClone(NodeCloningContext context) => new BoolNode(Value);

    #pragma warning disable HAA0601 // Value type to reference type conversion causing boxing allocation - This is actually desired
    /// <summary>
    ///     Distills the value into a usable constant.
    /// </summary>
    /// <returns>A usable constant.</returns>
    public override object DistillValue() => Value;

    /// <summary>
    ///     Generates the expression that will be compiled into code.
    /// </summary>
    /// <returns>A <see cref="ConstantExpression" /> with a boolean value.</returns>
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    public override Expression GenerateCachedExpression() => Expression.Constant(
        Value,
        typeof(bool));
    #pragma warning restore HAA0601 // Value type to reference type conversion causing boxing allocation
}