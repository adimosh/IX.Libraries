using IX.Library.Contracts;

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

using IX.Math.Extensibility;
using IX.Math.Formatters;

namespace IX.Math.Nodes.Constants;

/// <summary>
///     A binary value node. This class cannot be inherited.
/// </summary>
/// <seealso cref="ConstantNodeBase" />
[DebuggerDisplay($"{{{nameof(DisplayValue)}}}")]
[PublicAPI]
public class ByteArrayNode : ConstantNodeBase, ISpecialRequestNode
{
    private string? _cachedDistilledStringValue;
    private Func<Type, object>? _specialObjectRequestFunction;

    /// <summary>
    ///     Initializes a new instance of the <see cref="ByteArrayNode" /> class.
    /// </summary>
    /// <param name="value">The value of the constant.</param>
    public ByteArrayNode(byte[] value) => Value = Requires.NotNull(value);

    /// <summary>
    ///     Gets the display value.
    /// </summary>
    public string DisplayValue => GetString();

    /// <summary>
    ///     Gets the return type of this node.
    /// </summary>
    /// <value>Always <see cref="SupportedValueType.ByteArray" />.</value>
    public override SupportedValueType ReturnType => SupportedValueType.ByteArray;

    /// <summary>
    ///     Gets the value of the node.
    /// </summary>
    [SuppressMessage(
        "Performance",
        "CA1819:Properties should not return arrays",
        Justification = "We specifically want this here, as this is a binary representation.")]
    public byte[] Value { get; }

    /// <summary>
    ///     Sets the request special object function.
    /// </summary>
    /// <param name="func">The function to set.</param>
    void ISpecialRequestNode.SetRequestSpecialObjectFunction(Func<Type, object> func) =>
        _specialObjectRequestFunction = func;

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
    public override Expression GenerateCachedExpression() =>
        Expression.Constant(
            Value,
            typeof(byte[]));

    /// <summary>
    ///     Generates the expression that will be compiled into code as a string expression.
    /// </summary>
    /// <returns>The string expression.</returns>
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    public override Expression GenerateCachedStringExpression() => Expression.Constant(
        GetString(),
        typeof(string));

    /// <summary>
    ///     Creates a deep clone of the source object.
    /// </summary>
    /// <param name="context">The deep cloning context.</param>
    /// <returns>A deep clone.</returns>
    public override NodeBase DeepClone(NodeCloningContext context) => new ByteArrayNode(Value);

    private string GetString()
    {
        if (_cachedDistilledStringValue == null)
        {
            var stringFormatters =
                _specialObjectRequestFunction?.Invoke(typeof(IStringFormatter)) as List<IStringFormatter>;

            _cachedDistilledStringValue = StringFormatter.FormatIntoString(
                Value,
                stringFormatters);
        }

        return _cachedDistilledStringValue;
    }
}