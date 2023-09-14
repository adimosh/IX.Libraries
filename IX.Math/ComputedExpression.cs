using IX.Library;
using IX.Math.Extensibility;
using IX.Math.Formatters;
using IX.Math.Nodes;
using IX.Math.Registration;

using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq.Expressions;

namespace IX.Math;

/// <summary>
/// A representation of a computed expression, resulting from a string expression.
/// </summary>
[PublicAPI]
public sealed class ComputedExpression : DisposableBase, IDeepCloneable<ComputedExpression>
{
    private readonly IParameterRegistry? _parametersRegistry;
    private readonly List<IStringFormatter> _stringFormatters;
    private readonly Func<Type, object>? _specialObjectRequestFunc;

    private readonly string _initialExpression;
    private NodeBase? _body;

    internal ComputedExpression(
        string initialExpression,
        NodeBase? body,
        bool isRecognized,
        IParameterRegistry? parameterRegistry,
        List<IStringFormatter> stringFormatters,
        Func<Type, object>? specialObjectRequestFunc)
    {
        _parametersRegistry = parameterRegistry;
        _stringFormatters = stringFormatters;
        _specialObjectRequestFunc = specialObjectRequestFunc;

        _initialExpression = initialExpression;
        _body = body;
        RecognizedCorrectly = isRecognized;
        IsConstant = body?.IsConstant ?? false;
        IsTolerant = body?.IsTolerant ?? false;
    }

    /// <summary>
    /// Gets a value indicating whether or not the expression was actually recognized. <see langword="true"/> can possibly return an actual expression or a static value.
    /// </summary>
    /// <value><see langword="true"/> if the expression is recognized correctly, <see langword="false"/> otherwise.</value>
    public bool RecognizedCorrectly { get; }

    /// <summary>
    /// Gets a value indicating whether or not the expression is constant.
    /// </summary>
    /// <value><see langword="true"/> if the expression is constant, <see langword="false"/> otherwise.</value>
    public bool IsConstant { get; }

    /// <summary>
    /// Gets a value indicating whether this computed expression can have tolerance.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this expression is tolerant; otherwise, <c>false</c>.
    /// </value>
    public bool IsTolerant { get; }

    /// <summary>
    /// Gets a value indicating whether this computed expression is compiled.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this expression is compiled; otherwise, <c>false</c>.
    /// </value>
    public bool IsCompiled { get; private set; }

    /// <summary>
    /// Gets a value indicating whether or not the expression has undefined parameters.
    /// </summary>
    /// <value><see langword="true"/> if the expression has undefined parameters, <see langword="false"/> otherwise.</value>
    public bool HasUndefinedParameters =>
        _parametersRegistry?.Dump().Any(p => p.ReturnType == SupportedValueType.Unknown) ?? false;

    /// <summary>
    /// Gets the names of the parameters this expression requires, if any. This property is obsolete and should not be used anymore.
    /// </summary>
    /// <remarks>
    /// <para>This property is obsolete and will be removed in a future version of the library.</para>
    /// <para>The method <see cref="GetParameterNames"/> instead.</para>
    /// </remarks>
    [Obsolete("Please use the GetParameterNames method instead.")]
    public string[] ParameterNames => GetParameterNames();

    /// <summary>
    /// Gets the names of the parameters this expression requires, if any.
    /// </summary>
    /// <returns>An array of required parameter names.</returns>
    public string[] GetParameterNames() =>
        _parametersRegistry?.Dump().Select(p => p.Name).ToArray() ?? Array.Empty<string>();

    /// <summary>
    /// Computes the expression and returns a result.
    /// </summary>
    /// <param name="arguments">The arguments with which to invoke the execution of the expression.</param>
    /// <returns>The computed result, or, if the expression is not recognized correctly, the expression as a <see cref="string"/>.</returns>
    public object Compute(params object[] arguments) =>
        Compute(
            null,
            arguments);

    /// <summary>
    /// Computes the expression and returns a result, with tolerance.
    /// </summary>
    /// <param name="tolerance">The tolerance.</param>
    /// <param name="arguments">The arguments with which to invoke the execution of the expression.</param>
    /// <returns>
    /// The computed result, or, if the expression is not recognized correctly, the expression as a <see cref="string" />.
    /// </returns>
    [SuppressMessage(
        "Performance",
        "HAA0302:Display class allocation to capture closure",
        Justification = "Unavoidable for now.")]
    [SuppressMessage(
        "Performance",
        "HAA0301:Closure Allocation Source",
        Justification = "Unavoidable for now.")]
    public object Compute(
        Tolerance? tolerance,
        params object[] arguments)
    {
        this.RequiresNotDisposed();

        if (!RecognizedCorrectly)
        {
            // Expression was not recognized correctly.
            return _initialExpression;
        }

        var convertedArguments = FormatArgumentsAccordingToParameters(
            arguments,
            _parametersRegistry?.Dump() ?? Array.Empty<ParameterContext>());

        object[]? FormatArgumentsAccordingToParameters(
            object[] parameterValues,
            ParameterContext[] parameters)
        {
            if (parameterValues.Length != parameters.Length)
            {
                return null;
            }

            var finalValues = new object[parameterValues.Length];

            var i = 0;

            object? paramValue = null;

            while (i < finalValues.Length)
            {
                ParameterContext paraContext = parameters[i];

                // If there was no continuation, initialize parameter with value.
                paramValue ??= parameterValues[i];

                // Initial filtration
                switch (paramValue)
                {
                    case byte convertedParam:
                        paramValue = Convert.ToInt64(convertedParam);
                        continue;

                    case sbyte convertedParam:
                        paramValue = Convert.ToInt64(convertedParam);
                        continue;

                    case short convertedParam:
                        paramValue = Convert.ToInt64(convertedParam);
                        continue;

                    case ushort convertedParam:
                        paramValue = Convert.ToInt64(convertedParam);
                        continue;

                    case int convertedParam:
                        paramValue = Convert.ToInt64(convertedParam);
                        continue;

                    case uint convertedParam:
                        paramValue = Convert.ToInt64(convertedParam);
                        continue;

                    case long convertedParam:
                        paramValue = convertedParam;
                        break;

                    case ulong convertedParam:
                        paramValue = Convert.ToDouble(convertedParam);
                        continue;

                    case float convertedParam:
                        paramValue = Convert.ToDouble(convertedParam);
                        continue;

                    case double convertedParam:
                        paramValue = convertedParam;
                        break;

                    case string convertedParam:
                        paramValue = convertedParam;
                        break;

                    case bool convertedParam:
                        paramValue = convertedParam;
                        break;

                    case byte[] convertedParam:
                        paramValue = convertedParam;
                        break;

                    case Func<byte> convertedParam:
                        paramValue = new Func<long>(() => Convert.ToInt64(convertedParam()));
                        continue;

                    case Func<sbyte> convertedParam:
                        paramValue = new Func<long>(() => Convert.ToInt64(convertedParam()));
                        continue;

                    case Func<short> convertedParam:
                        paramValue = new Func<long>(() => Convert.ToInt64(convertedParam()));
                        continue;

                    case Func<ushort> convertedParam:
                        paramValue = new Func<long>(() => Convert.ToInt64(convertedParam()));
                        continue;

                    case Func<int> convertedParam:
                        paramValue = new Func<long>(() => Convert.ToInt64(convertedParam()));
                        continue;

                    case Func<uint> convertedParam:
                        paramValue = new Func<long>(() => Convert.ToInt64(convertedParam()));
                        continue;

                    case Func<long> convertedParam:
                        paramValue = convertedParam;
                        break;

                    case Func<ulong> convertedParam:
                        paramValue = new Func<double>(() => Convert.ToDouble(convertedParam()));
                        continue;

                    case Func<float> convertedParam:
                        paramValue = new Func<double>(() => Convert.ToDouble(convertedParam()));
                        continue;

                    case Func<double> convertedParam:
                        paramValue = convertedParam;
                        break;

                    case Func<string> convertedParam:
                        paramValue = convertedParam;
                        break;

                    case Func<bool> convertedParam:
                        paramValue = convertedParam;
                        break;

                    case Func<byte[]> convertedParam:
                        paramValue = convertedParam;
                        break;

                    default:
                        // Argument type is not (yet) supported
                        return null;
                }

                // Secondary filtration
                switch (paramValue)
                {
                    case long convertedParam:
                        switch (paraContext.ReturnType)
                        {
                            case SupportedValueType.Boolean:
                                paramValue = CreateValue(
                                    paraContext,
                                    convertedParam != 0);
                                break;

                            case SupportedValueType.ByteArray:
                                paramValue = CreateValue(
                                    paraContext,
                                    BitConverter.GetBytes(convertedParam));
                                break;

                            case SupportedValueType.Numeric:
                                switch (paraContext.IsFloat)
                                {
                                    case true:
                                        paramValue = CreateValue(
                                            paraContext,
                                            Convert.ToDouble(convertedParam));
                                        break;
                                    case false:
                                        paramValue = CreateValue(
                                            paraContext,
                                            convertedParam);
                                        break;
                                    default:
                                        paraContext.DetermineInteger();
                                        continue;
                                }

                                break;

                            case SupportedValueType.String:
                                paramValue = CreateValue(
                                    paraContext,
                                    StringFormatter.FormatIntoString(
                                        convertedParam,
                                        _stringFormatters));

                                break;

                            case SupportedValueType.Unknown:
                                paraContext.DetermineType(SupportedValueType.Numeric);
                                continue;
                        }

                        break;

                    case double convertedParam:
                        switch (paraContext.ReturnType)
                        {
                            case SupportedValueType.Boolean:
                                // ReSharper disable once CompareOfFloatsByEqualityOperator - no better idea for now
                                paramValue = CreateValue(
                                    paraContext,
                                    convertedParam != 0D);
                                break;

                            case SupportedValueType.ByteArray:
                                paramValue = CreateValue(
                                    paraContext,
                                    BitConverter.GetBytes(convertedParam));
                                break;

                            case SupportedValueType.Numeric:
                                switch (paraContext.IsFloat)
                                {
                                    case true:
                                        paramValue = CreateValue(
                                            paraContext,
                                            convertedParam);
                                        break;
                                    case false:
                                        paramValue = CreateValue(
                                            paraContext,
                                            Convert.ToInt64(convertedParam));
                                        break;
                                    default:
                                        paraContext.DetermineFloat();
                                        continue;
                                }

                                break;

                            case SupportedValueType.String:
                                paramValue = CreateValue(
                                    paraContext,
                                    StringFormatter.FormatIntoString(
                                        convertedParam,
                                        _stringFormatters));
                                break;

                            case SupportedValueType.Unknown:
                                paraContext.DetermineType(SupportedValueType.Numeric);
                                continue;
                        }

                        break;

                    case bool convertedParam:
                        switch (paraContext.ReturnType)
                        {
                            case SupportedValueType.Boolean:
                                paramValue = CreateValue(
                                    paraContext,
                                    convertedParam);
                                break;

                            case SupportedValueType.ByteArray:
                                paramValue = CreateValue(
                                    paraContext,
                                    BitConverter.GetBytes(convertedParam));
                                break;

                            case SupportedValueType.Numeric:
                                return null;

                            case SupportedValueType.String:
                                paramValue = CreateValue(
                                    paraContext,
                                    StringFormatter.FormatIntoString(
                                        convertedParam,
                                        _stringFormatters));
                                break;

                            case SupportedValueType.Unknown:
                                paraContext.DetermineType(SupportedValueType.Boolean);
                                continue;
                        }

                        break;

                    case string convertedParam:
                        switch (paraContext.ReturnType)
                        {
                            case SupportedValueType.Boolean:
                                paramValue = CreateValue(
                                    paraContext,
                                    bool.Parse(convertedParam));
                                break;

                            case SupportedValueType.ByteArray:
                            {
                                if (ParsingFormatter.ParseByteArray(
                                        convertedParam,
                                        out var byteArrayResult))
                                {
                                    paramValue = CreateValue(
                                        paraContext,
                                        byteArrayResult);
                                }
                                else
                                {
                                    // Cannot parse byte array.
                                    return null;
                                }
                            }

                                break;

                            case SupportedValueType.Numeric:
                            {
                                if (ParsingFormatter.ParseNumeric(
                                        convertedParam,
                                        out var numericResult))
                                {
                                    switch (numericResult)
                                    {
                                        case long integerResult:
                                            paramValue = CreateValue(
                                                paraContext,
                                                integerResult);
                                            break;
                                        case double floatResult:
                                            paramValue = CreateValue(
                                                paraContext,
                                                floatResult);
                                            break;
                                        default:
                                            // Numeric type unknown.
                                            return null;
                                    }
                                }
                                else
                                {
                                    // Cannot parse numeric type.
                                    return null;
                                }
                            }

                                break;

                            case SupportedValueType.String:
                                paramValue = CreateValue(
                                    paraContext,
                                    convertedParam);
                                break;

                            case SupportedValueType.Unknown:
                                paraContext.DetermineType(SupportedValueType.String);
                                continue;
                        }

                        break;

                    case byte[] convertedParam:
                        switch (paraContext.ReturnType)
                        {
                            case SupportedValueType.Boolean:
                                paramValue = CreateValue(
                                    paraContext,
                                    BitConverter.ToBoolean(
                                        convertedParam,
                                        0));
                                break;

                            case SupportedValueType.ByteArray:
                                paramValue = CreateValue(
                                    paraContext,
                                    convertedParam);
                                break;

                            case SupportedValueType.Numeric:
                                switch (paraContext.IsFloat)
                                {
                                    case true:
                                        paramValue = CreateValue(
                                            paraContext,
                                            BitConverter.ToDouble(
                                                convertedParam,
                                                0));
                                        break;
                                    case false:
                                        paramValue = CreateValue(
                                            paraContext,
                                            BitConverter.ToInt64(
                                                convertedParam,
                                                0));
                                        break;
                                    default:
                                        paraContext.DetermineFloat();
                                        continue;
                                }

                                break;

                            case SupportedValueType.String:
                                paramValue = CreateValue(
                                    paraContext,
                                    StringFormatter.FormatIntoString(
                                        convertedParam,
                                        _stringFormatters));
                                break;

                            case SupportedValueType.Unknown:
                                paraContext.DetermineType(SupportedValueType.ByteArray);
                                continue;
                        }

                        break;

                    case Func<long> convertedParam:
                        paraContext.DetermineFunc();

                        switch (paraContext.ReturnType)
                        {
                            case SupportedValueType.Boolean:
                                paramValue = CreateValueFromFunc(
                                    paraContext,
                                    () => convertedParam() == 0);
                                break;

                            case SupportedValueType.ByteArray:
                                paramValue = CreateValueFromFunc(
                                    paraContext,
                                    () => BitConverter.GetBytes(convertedParam()));
                                break;

                            case SupportedValueType.Numeric:
                                switch (paraContext.IsFloat)
                                {
                                    case true:
                                        paramValue = CreateValueFromFunc(
                                            paraContext,
                                            () => Convert.ToDouble(convertedParam()));
                                        break;
                                    case false:
                                        paramValue = CreateValueFromFunc(
                                            paraContext,
                                            convertedParam);
                                        break;
                                    default:
                                        paraContext.DetermineInteger();
                                        continue;
                                }

                                break;

                            case SupportedValueType.String:
                                paramValue = CreateValueFromFunc(
                                    paraContext,
                                    () => StringFormatter.FormatIntoString(
                                        convertedParam(),
                                        _stringFormatters));
                                break;

                            case SupportedValueType.Unknown:
                                paraContext.DetermineType(SupportedValueType.Numeric);
                                continue;
                        }

                        break;

                    case Func<double> convertedParam:
                        paraContext.DetermineFunc();

                        switch (paraContext.ReturnType)
                        {
                            case SupportedValueType.Boolean:
                                // ReSharper disable once CompareOfFloatsByEqualityOperator - no better idea for now
                                paramValue = CreateValueFromFunc(
                                    paraContext,
                                    () => convertedParam() == 0D);
                                break;

                            case SupportedValueType.ByteArray:
                                paramValue = CreateValueFromFunc(
                                    paraContext,
                                    () => BitConverter.GetBytes(convertedParam()));
                                break;

                            case SupportedValueType.Numeric:
                                switch (paraContext.IsFloat)
                                {
                                    case true:
                                        paramValue = CreateValueFromFunc(
                                            paraContext,
                                            convertedParam);
                                        break;
                                    case false:
                                        paramValue = CreateValueFromFunc(
                                            paraContext,
                                            () => Convert.ToInt64(convertedParam()));
                                        break;
                                    default:
                                        paraContext.DetermineFloat();
                                        continue;
                                }

                                break;

                            case SupportedValueType.String:
                                paramValue = CreateValueFromFunc(
                                    paraContext,
                                    () => StringFormatter.FormatIntoString(
                                        convertedParam(),
                                        _stringFormatters));

                                break;

                            case SupportedValueType.Unknown:
                                paraContext.DetermineType(SupportedValueType.Numeric);
                                continue;
                        }

                        break;

                    case Func<bool> convertedParam:
                        paraContext.DetermineFunc();

                        switch (paraContext.ReturnType)
                        {
                            case SupportedValueType.Boolean:
                                paramValue = CreateValueFromFunc(
                                    paraContext,
                                    convertedParam);
                                break;

                            case SupportedValueType.ByteArray:
                                paramValue = CreateValueFromFunc(
                                    paraContext,
                                    () => BitConverter.GetBytes(convertedParam()));
                                break;

                            case SupportedValueType.Numeric:
                                return null;

                            case SupportedValueType.String:
                                paramValue = CreateValueFromFunc(
                                    paraContext,
                                    () => StringFormatter.FormatIntoString(
                                        convertedParam(),
                                        _stringFormatters));
                                break;

                            case SupportedValueType.Unknown:
                                paraContext.DetermineType(SupportedValueType.Boolean);
                                continue;
                        }

                        break;

                    case Func<string> convertedParam:
                        paraContext.DetermineFunc();

                        switch (paraContext.ReturnType)
                        {
                            case SupportedValueType.Boolean:
                                paramValue = CreateValueFromFunc(
                                    paraContext,
                                    () => bool.Parse(convertedParam()));
                                break;

                            case SupportedValueType.ByteArray:
                                paramValue = CreateValueFromFunc(
                                    paraContext,
                                    () => ParsingFormatter.ParseByteArray(
                                        convertedParam(),
                                        out var baResult)
                                        ? baResult
                                        : Array.Empty<byte>());
                                break;

                            case SupportedValueType.Numeric:
                                switch (paraContext.IsFloat)
                                {
                                    case true:
                                        paramValue = CreateValueFromFunc(
                                            paraContext,
                                            () => ParsingFormatter.ParseNumeric(
                                                convertedParam(),
                                                out var numericResult)
                                                ? Convert.ToDouble(
                                                    numericResult,
                                                    CultureInfo.CurrentCulture)
                                                : throw new ArgumentInvalidTypeException(paraContext.Name));
                                        break;
                                    case false:
                                        paramValue = CreateValueFromFunc(
                                            paraContext,
                                            () => ParsingFormatter.ParseNumeric(
                                                convertedParam(),
                                                out var numericResult)
                                                ? Convert.ToInt64(
                                                    numericResult,
                                                    CultureInfo.CurrentCulture)
                                                : throw new ArgumentInvalidTypeException(paraContext.Name));
                                        break;
                                    default:
                                        paraContext.DetermineFloat();
                                        continue;
                                }

                                break;

                            case SupportedValueType.String:
                                paramValue = CreateValueFromFunc(
                                    paraContext,
                                    convertedParam);
                                break;

                            case SupportedValueType.Unknown:
                                paraContext.DetermineType(SupportedValueType.String);
                                continue;
                        }

                        break;

                    case Func<byte[]> convertedParam:
                        paraContext.DetermineFunc();

                        switch (paraContext.ReturnType)
                        {
                            case SupportedValueType.Boolean:
                                paramValue = CreateValueFromFunc(
                                    paraContext,
                                    () => BitConverter.ToBoolean(
                                        convertedParam(),
                                        0));
                                break;

                            case SupportedValueType.ByteArray:
                                paramValue = CreateValueFromFunc(
                                    paraContext,
                                    convertedParam);
                                break;

                            case SupportedValueType.Numeric:
                                switch (paraContext.IsFloat)
                                {
                                    case true:
                                        paramValue = CreateValueFromFunc(
                                            paraContext,
                                            () => BitConverter.ToDouble(
                                                convertedParam(),
                                                0));
                                        break;
                                    case false:
                                        paramValue = CreateValueFromFunc(
                                            paraContext,
                                            () => BitConverter.ToInt64(
                                                convertedParam(),
                                                0));
                                        break;
                                    default:
                                        paraContext.DetermineFloat();
                                        continue;
                                }

                                break;

                            case SupportedValueType.String:
                                paramValue = CreateValueFromFunc(
                                    paraContext,
                                    () => StringFormatter.FormatIntoString(
                                        convertedParam(),
                                        _stringFormatters));
                                break;

                            case SupportedValueType.Unknown:
                                paraContext.DetermineType(SupportedValueType.ByteArray);
                                continue;
                        }

                        break;

                    default:
                        // Argument type is not (yet) supported
                        return null;
                }

#pragma warning disable HAA0601 // Value type to reference type conversion causing boxing allocation - This is unavoidable now
#pragma warning disable HAA0303 // Considering moving this out of the generic method - Not really possible
                object CreateValue<T>(
                    ParameterContext parameterContext,
                    T value)
                    where T : notnull => parameterContext.FuncParameter ? new Func<T>(() => value) : value;

                object CreateValueFromFunc<T>(
                    ParameterContext parameterContext,
                    Func<T> value)
                    where T : notnull => parameterContext.FuncParameter ? value : value();
#pragma warning restore HAA0303 // Considering moving this out of the generic method
#pragma warning restore HAA0601 // Value type to reference type conversion causing boxing allocation

                finalValues[i] = paramValue;

                paramValue = null;

                i++;
            }

            return finalValues;
        }

        if (convertedArguments == null)
        {
            // The arguments could not be correctly converted.
            return _initialExpression;
        }

        Delegate? del;

        if (_body == null)
        {
            del = null;
        }
        else
        {
            try
            {
                del = Expression.Lambda(
                                    tolerance == null ? _body.GenerateExpression() : _body.GenerateExpression(tolerance),
                                    _parametersRegistry?.Dump().Select(p => p.ParameterExpression) ??
                                    Array.Empty<ParameterExpression>())
                                .Compile();
            }
            catch
            {
                // Expression is somehow not valid
                del = null;
            }
        }

        if (del == null)
        {
            // Delegate could not be compiled with the given arguments.
            return _initialExpression;
        }

        try
        {
            return del.DynamicInvoke(convertedArguments) ?? _initialExpression;
        }
        catch (OutOfMemoryException)
        {
            throw;
        }
        catch (DivideByZeroException)
        {
            throw;
        }
        catch
        {
            // Dynamic invocation of generated expression failed.
            return _initialExpression;
        }
    }

    /// <summary>
    /// Computes the expression and returns a result.
    /// </summary>
    /// <param name="dataFinder">The data finder for the arguments with which to invoke execution of the expression.</param>
    /// <returns>The computed result, or, if the expression is not recognized correctly, the expression as a <see cref="string"/>.</returns>
    public object Compute(IDataFinder dataFinder) =>
        Compute(
            null,
            dataFinder);

    /// <summary>
    /// Computes the expression and returns a result.
    /// </summary>
    /// <param name="tolerance">The tolerance.</param>
    /// <param name="dataFinder">The data finder for the arguments with which to invoke execution of the expression.</param>
    /// <returns>
    /// The computed result, or, if the expression is not recognized correctly, the expression as a <see cref="string" />.
    /// </returns>
    public object Compute(
        Tolerance? tolerance,
        IDataFinder dataFinder)
    {
        this.RequiresNotDisposed();

        if (!RecognizedCorrectly)
        {
            return _initialExpression;
        }

        var pars = new List<object?>();

        _ = Requires.NotNull(
            dataFinder,
            nameof(dataFinder));

        foreach (ParameterContext p in _parametersRegistry?.Dump() ?? Array.Empty<ParameterContext>())
        {
            if (!dataFinder.TryGetData(
                    p.Name,
                    out var data))
            {
                return _initialExpression;
            }

            pars.Add(data);
        }

        return pars.Any(p => p == null)
            ? _initialExpression
            : Compute(
                tolerance,
                pars.ToArray()!);
    }

    /// <summary>
    /// Creates a deep clone of the source object.
    /// </summary>
    /// <returns>A deep clone.</returns>
    public ComputedExpression DeepClone()
    {
        var registry = new StandardParameterRegistry(_stringFormatters);
        var context = new NodeCloningContext
            { ParameterRegistry = registry, SpecialRequestFunction = _specialObjectRequestFunc };

        return new(
            _initialExpression,
            _body?.DeepClone(context),
            RecognizedCorrectly,
            registry,
            _stringFormatters,
            _specialObjectRequestFunc);
    }

    /// <summary>
    /// Disposes in the general (managed and unmanaged) context.
    /// </summary>
    protected override void DisposeGeneralContext()
    {
        base.DisposeGeneralContext();

        _ = Interlocked.Exchange(
            ref _body,
            null);
    }
}