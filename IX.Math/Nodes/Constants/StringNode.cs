using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace IX.Math.Nodes.Constants;

/// <summary>
///     A string node. This class cannot be inherited.
/// </summary>
/// <seealso cref="ConstantNodeBase" />
/// <remarks>
///     Initializes a new instance of the <see cref="StringNode" /> class.
/// </remarks>
/// <param name="value">The value.</param>
[DebuggerDisplay($"{{{nameof(Value)}}}")]
public sealed class StringNode(string value) : ConstantNodeBase
{

    /// <summary>
    ///     Gets the value.
    /// </summary>
    /// <value>The value.</value>
    public string Value { get; } = value;

    /// <summary>
    ///     Gets the return type of this node.
    /// </summary>
    /// <value>Always <see cref="SupportedValueType.String" />.</value>
    public override SupportedValueType ReturnType => SupportedValueType.String;

    /// <summary>
    ///     Generates the expression that will be compiled into code.
    /// </summary>
    /// <returns>The expression.</returns>
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    public override Expression GenerateCachedExpression() => Expression.Constant(
        Value,
        typeof(string));

    /// <summary>
    ///     Generates the expression that will be compiled into code as a string expression.
    /// </summary>
    /// <returns>The string expression.</returns>
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    public override Expression GenerateCachedStringExpression() => GenerateExpression();

    /// <summary>
    ///     Distills the value into a usable constant.
    /// </summary>
    /// <returns>A usable constant.</returns>
    public override object DistillValue() => Value;

    /// <summary>
    ///     Creates a deep clone of the source object.
    /// </summary>
    /// <param name="context">The deep cloning context.</param>
    /// <returns>A deep clone.</returns>
    public override NodeBase DeepClone(NodeCloningContext context) => new StringNode(Value);
}