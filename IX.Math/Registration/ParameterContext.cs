#if NET462
using IX.Library;
#endif

using System.Globalization;
using System.Linq.Expressions;
using IX.Math.Extensibility;
using IX.Math.Formatters;

namespace IX.Math.Registration;

/// <summary>
/// A data model for a parameter's context of existence.
/// </summary>
public class ParameterContext : IDeepCloneable<ParameterContext>, IEquatable<ParameterContext>
{
    private readonly List<IStringFormatter> _stringFormatters;

    private bool _alreadyCompiled;
    private ParameterExpression? _parameterDefinitionExpression;
    private Expression? _expression;
    private Expression? _stringExpression;

    /// <summary>
    /// Initializes a new instance of the <see cref="ParameterContext" /> class.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="stringFormatters">The string formatters.</param>
    /// <exception cref="ArgumentNullException"><paramref name="name"/> is either <c>null</c>, empty or whitespace-only.</exception>
    public ParameterContext(string name, List<IStringFormatter> stringFormatters)
    {
        _ = Requires.NotNullOrWhiteSpace(name);

        Name = name;
        _stringFormatters = stringFormatters;
        SupportedReturnType = SupportableValueType.All;
    }

    /// <summary>
    /// Gets the name of the parameter.
    /// </summary>
    /// <value>The name of the parameter.</value>
    public string Name { get; }

    /// <summary>
    /// Gets a value indicating whether this parameter is float.
    /// </summary>
    /// <value><see langword="null"/> if the setting is not defined, <see langword="true"/> if this parameter is float; otherwise, <see langword="false"/>.</value>
    /// <remarks>
    /// <para>This setting only has an effect if the parameter is already numeric.</para>
    /// <para>Otherwise, it will determine the parameter to be a float or an integer only if switched to numeric.</para>
    /// <para>This setting is usable independent to the parameter type definition in order to maintain backwards compatibility with the UndefinedParameterNode obsolete class.</para>
    /// </remarks>
    public bool? IsFloat { get; private set; }

    /// <summary>
    /// Gets the return type of the parameter.
    /// </summary>
    /// <value>The return type of the parameter.</value>
    public SupportedValueType ReturnType { get; private set; }

    /// <summary>
    /// Gets the supported return types.
    /// </summary>
    /// <value>
    /// The supported return types.
    /// </value>
    public SupportableValueType SupportedReturnType { get; private set; }

    /// <summary>
    /// Gets a value indicating whether the parameter is a function.
    /// </summary>
    /// <value><see langword="true"/> if the parameter is a function; otherwise, <see langword="false"/>.</value>
    public bool FuncParameter { get; private set; }

    /// <summary>
    /// Gets or sets the order in which this parameter has appeared in the expression.
    /// </summary>
    /// <value>The order.</value>
    public int Order { get; set; }

    /// <summary>
    /// Gets the parameter expression.
    /// </summary>
    /// <value>The parameter expression.</value>
    public ParameterExpression ParameterExpression
    {
        get
        {
            if (!_alreadyCompiled)
            {
                _ = Compile();
            }

            // Null-forgiving: Compile is called before and sets the expression
            return _parameterDefinitionExpression!;
        }
    }

    /// <summary>
    /// Limits the possible types of this parameter.
    /// </summary>
    /// <param name="limit">The limit.</param>
    /// <exception cref="ArgumentException">the limit is invalid.</exception>
    /// <exception cref="ExpressionNotValidLogicallyException">The expression reduces the parameter to no supported type.</exception>
    [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Performance",
        "HAA0601:Value type to reference type conversion causing boxing allocation",
        Justification = "Unavoidable here.")]
    public void LimitPossibleType(SupportableValueType limit)
    {
        if (limit == SupportableValueType.None)
        {
            throw new ArgumentException(
                string.Format(
                    CultureInfo.CurrentCulture,
                    Resources.ParameterTypeNotRecognized,
                    nameof(limit)),
                nameof(limit));
        }

        var newVal = limit & SupportedReturnType;
        if (newVal == SupportableValueType.None)
        {
            throw new ExpressionNotValidLogicallyException();
        }

        SupportedReturnType = newVal;

        int iVal = (int)newVal;

        if (Enum.IsDefined(
                typeof(SupportedValueType),
                iVal))
        {
            DetermineType((SupportedValueType)iVal);
        }
    }

    /// <summary>
    /// Determines the type of the parameter.
    /// </summary>
    /// <param name="newType">The new type.</param>
    /// <exception cref="ArgumentException">The new type is not valid.</exception>
    public void DetermineType(SupportedValueType newType)
    {
        switch (newType)
        {
            case SupportedValueType.Boolean:
                ChangeReturnType(SupportedValueType.Boolean);

                return;

            case SupportedValueType.ByteArray:
                ChangeReturnType(SupportedValueType.ByteArray);

                return;

            case SupportedValueType.String:
                ChangeReturnType(SupportedValueType.String);

                return;

            case SupportedValueType.Numeric:
                ChangeReturnType(SupportedValueType.Numeric);

                return;

            default:
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.ParameterTypeNotRecognized, Name), Name);
        }

        void ChangeReturnType(SupportedValueType newReturnType)
        {
            if (ReturnType == newReturnType)
            {
                return;
            }

            if (ReturnType == SupportedValueType.Unknown)
            {
                if (_alreadyCompiled)
                {
                    throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.ParameterAlreadyCompiled, Name));
                }

                int i1 = (int)newReturnType, i2 = (int)SupportedReturnType;

                if ((i1 & i2) == 0)
                {
                    throw new ExpressionNotValidLogicallyException(string.Format(CultureInfo.CurrentCulture, Resources.ParameterRequiredOfMismatchedTypes, Name));
                }

                ReturnType = newReturnType;
                SupportedReturnType = (SupportableValueType)i1;
            }
            else
            {
                throw new ExpressionNotValidLogicallyException(string.Format(CultureInfo.CurrentCulture, Resources.ParameterRequiredOfMismatchedTypes, Name));
            }
        }
    }

    /// <summary>
    /// Determines that, if this parameter is going to be numeric, it should be a float.
    /// </summary>
    public void DetermineFloat()
    {
        switch (IsFloat)
        {
            case true:
                return;
            case null:
                IsFloat = true;
                break;
            default:
                throw new ExpressionNotValidLogicallyException(string.Format(CultureInfo.CurrentCulture, Resources.ParameterMustBeFloatButAlreadyRequiredToBeInteger, Name));
        }
    }

    /// <summary>
    /// Determines that, if this parameter is going to be numeric, it should be an integer.
    /// </summary>
    public void DetermineInteger()
    {
        switch (IsFloat)
        {
            case false:
                return;
            case null:
                IsFloat = false;
                break;
            default:
                throw new ExpressionNotValidLogicallyException(string.Format(CultureInfo.CurrentCulture, Resources.ParameterMustBeIntegerButAlreadyRequiredToBeFloat, Name));
        }
    }

    /// <summary>
    /// Determines the parameter to be a function.
    /// </summary>
    public void DetermineFunc() => FuncParameter = true;

    /// <summary>
    /// Compiles this instance.
    /// </summary>
    /// <returns>A LINQ expression representing the parameter.</returns>
    /// <exception cref="InvalidOperationException">The parameter was already compiled, but it is <see langword="null"/>.</exception>
    /// <exception cref="ExpressionNotValidLogicallyException">The parameter is still undefined.</exception>
    public Expression Compile()
    {
        if (_alreadyCompiled)
        {
            return _expression ?? throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.ParameterAlreadyCompiledButCompilationIsNull, Name));
        }

        Type type;

        switch (ReturnType)
        {
            case SupportedValueType.Boolean:
                type = FuncParameter ? typeof(Func<bool>) : typeof(bool);
                break;
            case SupportedValueType.ByteArray:
                type = FuncParameter ? typeof(Func<byte[]>) : typeof(byte[]);
                break;
            case SupportedValueType.String:
                type = FuncParameter ? typeof(Func<string>) : typeof(string);
                break;
            case SupportedValueType.Numeric:
                if (IsFloat == false)
                {
                    type = FuncParameter ? typeof(Func<long>) : typeof(long);
                }
                else
                {
                    type = FuncParameter ? typeof(Func<double>) : typeof(double);
                }

                break;
            default:
                throw new ExpressionNotValidLogicallyException();
        }

        ParameterExpression parameterExpression = Expression.Parameter(type, Name);

        _parameterDefinitionExpression = parameterExpression;

        if (FuncParameter)
        {
            _expression = Expression.Invoke(parameterExpression);
        }
        else
        {
            _expression = parameterExpression;
        }

        _stringExpression = (ReturnType == SupportedValueType.String)
            ? _expression
            : StringFormatter.CreateStringConversionExpression(
                _expression,
                _stringFormatters);

        _alreadyCompiled = true;
        return _expression;
    }

    /// <summary>
    /// Compiles this instance as a string result.
    /// </summary>
    /// <returns>A LINQ expression representing the parameter, as a string.</returns>
    public Expression CompileString()
    {
        if (_alreadyCompiled)
        {
            return _stringExpression ??
                   throw new InvalidOperationException(
                       string.Format(
                           CultureInfo.CurrentCulture,
                           Resources.ParameterAlreadyCompiledButCompilationIsNull,
                           Name));
        }

        _ = Compile();

        return _stringExpression ??
               throw new InvalidOperationException(
                   string.Format(
                       CultureInfo.CurrentCulture,
                       Resources.ParameterAlreadyCompiledButCompilationIsNull,
                       Name));
    }

    /// <summary>
    /// Creates a deep clone of the source object.
    /// </summary>
    /// <returns>A deep clone.</returns>
    /// <remarks>
    /// <para>Warning! This method does not copy the compilation result.</para>
    /// <para>When called on a compiled expression, the resulting context will not be itself compiled.</para>
    /// </remarks>
    public ParameterContext DeepClone() => new(Name, _stringFormatters)
    {
        IsFloat = IsFloat,
        ReturnType = ReturnType,
        FuncParameter = FuncParameter,
        Order = Order,
    };

    /// <summary>
    /// Indicates whether the current context is equal to another <see cref="ParameterContext"/>.
    /// </summary>
    /// <param name="other">A parameter context to compare with this context.</param>
    /// <returns>true if the current context is equal to the <paramref name="other" /> parameter; otherwise, false.</returns>
    public bool Equals(ParameterContext? other)
    {
        if (other == null)
        {
            return false;
        }

        return
            other.IsFloat == IsFloat &&
            other.Name == Name &&
            other.FuncParameter == FuncParameter &&
            other.Order == Order &&
            other.ReturnType == ReturnType;
    }
}