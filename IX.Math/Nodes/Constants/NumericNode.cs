using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

using IX.Math.Extensibility;
using IX.Math.Formatters;
using IX.Math.TypeHelpers;

namespace IX.Math.Nodes.Constants;

/// <summary>
///     A numeric node. This class cannot be inherited.
/// </summary>
/// <seealso cref="ConstantNodeBase" />
[DebuggerDisplay($"{{{nameof(Value)}}}")]
public sealed class NumericNode : ConstantNodeBase, ISpecialRequestNode
{
    /// <summary>
    ///     The float value.
    /// </summary>
    private double _floatValue;

    /// <summary>
    ///     The integer value.
    /// </summary>
    private long _integerValue;

    private Func<Type, object>? _specialObjectRequestFunction;

    /// <summary>
    ///     Initializes a new instance of the <see cref="NumericNode" /> class.
    /// </summary>
    /// <param name="value">The integer value.</param>
    public NumericNode(long value) => Initialize(value);

    /// <summary>
    ///     Initializes a new instance of the <see cref="NumericNode" /> class.
    /// </summary>
    /// <param name="value">The floating-point value.</param>
    public NumericNode(double value) => Initialize(value);

    /// <summary>
    ///     Initializes a new instance of the <see cref="NumericNode" /> class.
    /// </summary>
    /// <param name="value">The undefined value.</param>
    /// <exception cref="ArgumentException">The value is not in an expected format.</exception>
    public NumericNode(object value)
    {
        switch (value)
        {
            case double d:
                Initialize(d);
                break;
            case long l:
                Initialize(l);
                break;
            default:
                throw new ArgumentException(
                    Resources.NumericTypeInvalid,
                    nameof(value));
        }
    }

    private NumericNode() { }

    /// <summary>
    ///     Gets the return type of this node.
    /// </summary>
    /// <value>Always <see cref="SupportedValueType.Numeric" />.</value>
    public override SupportedValueType ReturnType => SupportedValueType.Numeric;

    /// <summary>
    ///     Gets a value indicating whether this instance is a floating point number.
    /// </summary>
    /// <value>
    ///     <c>true</c> if this instance is float; otherwise, <c>false</c>.
    /// </value>
    public bool IsFloat { get; private set; }

    /// <summary>
    ///     Gets the value of this constant numeric node.
    /// </summary>
    /// <value>The value.</value>
    [SuppressMessage(
        "Performance",
        "HAA0601:Value type to reference type conversion causing boxing allocation",
        Justification = "This is desired.")]
    public object Value
    {
        get
        {
            if (IsFloat)
            {
                return _floatValue;
            }

            return _integerValue;
        }
    }

    /// <summary>
    ///     Sets the request special object function.
    /// </summary>
    /// <param name="func">The function to set.</param>
    void ISpecialRequestNode.SetRequestSpecialObjectFunction(Func<Type, object> func) =>
        _specialObjectRequestFunction = func;

    /// <summary>
    ///     Does an addition between two numeric nodes.
    /// </summary>
    /// <param name="left">The left operand.</param>
    /// <param name="right">The right operand.</param>
    /// <returns>The resulting node.</returns>
    public static NumericNode Add(
        NumericNode left,
        NumericNode right)
    {
        if (left.IsFloat && right.IsFloat)
        {
            return new(left._floatValue + right._floatValue);
        }

        if (left.IsFloat && !right.IsFloat)
        {
            return new(left._floatValue + Convert.ToDouble(right._integerValue));
        }

        if (!left.IsFloat && right.IsFloat)
        {
            return new(Convert.ToDouble(left._integerValue) + right._floatValue);
        }

        return new(left._integerValue + right._integerValue);
    }

    /// <summary>
    ///     Does a subtraction between two numeric nodes.
    /// </summary>
    /// <param name="left">The left operand.</param>
    /// <param name="right">The right operand.</param>
    /// <returns>The resulting node.</returns>
    public static NumericNode Subtract(
        NumericNode left,
        NumericNode right)
    {
        if (left.IsFloat && right.IsFloat)
        {
            return new(left._floatValue - right._floatValue);
        }

        if (left.IsFloat && !right.IsFloat)
        {
            return new(left._floatValue - Convert.ToDouble(right._integerValue));
        }

        if (!left.IsFloat && right.IsFloat)
        {
            return new(Convert.ToDouble(left._integerValue) - right._floatValue);
        }

        return new(left._integerValue - right._integerValue);
    }

    /// <summary>
    ///     Does a multiplication between two numeric nodes.
    /// </summary>
    /// <param name="left">The left operand.</param>
    /// <param name="right">The right operand.</param>
    /// <returns>The resulting node.</returns>
    public static NumericNode Multiply(
        NumericNode left,
        NumericNode right)
    {
        if (left.IsFloat && right.IsFloat)
        {
            return new(left._floatValue * right._floatValue);
        }

        if (left.IsFloat && !right.IsFloat)
        {
            return new(left._floatValue * Convert.ToDouble(right._integerValue));
        }

        if (!left.IsFloat && right.IsFloat)
        {
            return new(Convert.ToDouble(left._integerValue) * right._floatValue);
        }

        return new(left._integerValue * right._integerValue);
    }

    /// <summary>
    ///     Does a division between two numeric nodes.
    /// </summary>
    /// <param name="left">The left operand.</param>
    /// <param name="right">The right operand.</param>
    /// <returns>The resulting node.</returns>
    [SuppressMessage(
        "Performance",
        "HAA0601:Value type to reference type conversion causing boxing allocation",
        Justification = "This is of little consequence at this point.")]
    public static NumericNode Divide(
        NumericNode left,
        NumericNode right)
    {
        var (divided, divisor, tryInteger) = NumericTypeHelper.ExtractFloats(
            left.Value,
            right.Value);

        var result = divided / divisor;

        return new(tryInteger ? NumericTypeHelper.DistillIntegerIfPossible(result) : result);
    }

    /// <summary>
    ///     Raises the left node's value to the power specified by the right node's value.
    /// </summary>
    /// <param name="left">The left operand.</param>
    /// <param name="right">The right operand.</param>
    /// <returns>The resulting node.</returns>
    [SuppressMessage(
        "Performance",
        "HAA0601:Value type to reference type conversion causing boxing allocation",
        Justification = "This is of little consequence at this point.")]
    public static NumericNode Power(
        NumericNode left,
        NumericNode right)
    {
        var (@base, pow, tryInteger) = NumericTypeHelper.ExtractFloats(
            left.Value,
            right.Value);

        var result = global::System.Math.Pow(
            @base,
            pow);

        return new(tryInteger ? NumericTypeHelper.DistillIntegerIfPossible(result) : result);
    }

    /// <summary>
    ///     Does a left shift between two numeric nodes.
    /// </summary>
    /// <param name="left">The left operand.</param>
    /// <param name="right">The right operand.</param>
    /// <returns>The resulting node.</returns>
    public static NumericNode LeftShift(
        NumericNode left,
        NumericNode right)
    {
        var by = right.ExtractInt();
        var data = left.ExtractInteger();

        return new(data << by);
    }

    /// <summary>
    ///     Does a right shift between two numeric nodes.
    /// </summary>
    /// <param name="left">The left operand.</param>
    /// <param name="right">The right operand.</param>
    /// <returns>The resulting node.</returns>
    public static NumericNode RightShift(
        NumericNode left,
        NumericNode right)
    {
        var by = right.ExtractInt();
        var data = left.ExtractInteger();

        return new(data >> by);
    }

    /// <summary>
    ///     Generates the expression that will be compiled into code.
    /// </summary>
    /// <returns>The expression.</returns>
    [SuppressMessage(
        "Performance",
        "HAA0601:Value type to reference type conversion causing boxing allocation",
        Justification = "This is desired.")]
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    public override Expression GenerateCachedExpression() => IsFloat
        ? Expression.Constant(
            _floatValue,
            typeof(double))
        : Expression.Constant(
            _integerValue,
            typeof(long));

    /// <summary>
    ///     Generates a floating-point expression.
    /// </summary>
    /// <returns>The expression.</returns>
    [SuppressMessage(
        "Performance",
        "HAA0601:Value type to reference type conversion causing boxing allocation",
        Justification = "This is desired.")]
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    public Expression GenerateFloatExpression() =>
        IsFloat
            ? GenerateExpression()
            : Expression.Constant(
                Convert.ToDouble(_floatValue),
                typeof(double));

    /// <summary>
    ///     Generates an integer expression.
    /// </summary>
    /// <returns>The expression.</returns>
    /// <exception cref="InvalidCastException">The node is floating-point and cannot be transformed.</exception>
    [SuppressMessage(
        "Performance",
        "HAA0601:Value type to reference type conversion causing boxing allocation",
        Justification = "This is desired.")]
    [SuppressMessage(
        "ReSharper",
        "CompareOfFloatsByEqualityOperator",
        Justification =
            "If we're reaching the precision loss boundary, it means we're rounding to an integer anyway, so it's acceptable.")]
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    public Expression GenerateLongExpression()
    {
        if (!IsFloat)
        {
            return GenerateExpression();
        }

        if (global::System.Math.Floor(_floatValue) != _floatValue)
        {
            throw new InvalidCastException();
        }

        return Expression.Constant(
            Convert.ToInt64(_floatValue),
            typeof(long));
    }

    /// <summary>
    ///     Extracts an integer.
    /// </summary>
    /// <returns>An integer value.</returns>
    /// <exception cref="InvalidCastException">The current value is floating-point and cannot be transformed.</exception>
    [SuppressMessage(
        "ReSharper",
        "CompareOfFloatsByEqualityOperator",
        Justification =
            "If we're reaching the precision loss boundary, it means we're rounding to an integer anyway, so it's acceptable.")]
    public long ExtractInteger()
    {
        if (!IsFloat)
        {
            return _integerValue;
        }

        if (global::System.Math.Floor(_floatValue) != _floatValue)
        {
            throw new InvalidCastException();
        }

        return Convert.ToInt64(_floatValue);
    }

    /// <summary>
    ///     Extracts a floating-point value.
    /// </summary>
    /// <returns>A floating-point value.</returns>
    public double ExtractFloat()
    {
        if (IsFloat)
        {
            return _floatValue;
        }

        return Convert.ToDouble(_integerValue);
    }

    /// <summary>
    ///     Extracts a 32-bit integer value.
    /// </summary>
    /// <returns>A 32-bit integer value.</returns>
    /// <exception cref="InvalidCastException">The value is either floating-point or larger than 32-bit.</exception>
    [SuppressMessage(
        "ReSharper",
        "CompareOfFloatsByEqualityOperator",
        Justification =
            "If we're reaching the precision loss boundary, it means we're rounding to an integer anyway, so it's acceptable.")]
    public int ExtractInt()
    {
        if (!IsFloat)
        {
            return Convert.ToInt32(_integerValue);
        }

        if (global::System.Math.Floor(_floatValue) != _floatValue)
        {
            throw new InvalidCastException();
        }

        return Convert.ToInt32(_floatValue);
    }

    /// <summary>
    ///     Distills the value into a usable constant.
    /// </summary>
    /// <returns>A usable constant.</returns>
    public override object DistillValue() => Value;

    /// <summary>
    ///     Generates the expression that will be compiled into code as a string expression.
    /// </summary>
    /// <returns>The string expression.</returns>
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    public override Expression GenerateCachedStringExpression()
    {
        var stringFormatters = _specialObjectRequestFunction?.Invoke(typeof(IStringFormatter)) as List<IStringFormatter>;
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
    public override NodeBase DeepClone(NodeCloningContext context) => new NumericNode
    {
        _integerValue = _integerValue,
        _floatValue = _floatValue,
        IsFloat = IsFloat
    };

    /// <summary>
    ///     Initializes the specified value.
    /// </summary>
    /// <param name="value">The value.</param>
    private void Initialize(long value)
    {
        _integerValue = value;
        IsFloat = false;
    }

    /// <summary>
    ///     Initializes the specified value.
    /// </summary>
    /// <param name="value">The value.</param>
    private void Initialize(double value)
    {
        _floatValue = value;
        IsFloat = true;
    }
}