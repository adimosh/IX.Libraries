using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;

using IX.Math.Extensibility;

namespace IX.Math.Nodes;

/// <summary>
///     A base class for a unary function (a function with only one parameter).
/// </summary>
/// <seealso cref="FunctionNodeBase" />
[PublicAPI]
public abstract class UnaryFunctionNodeBase : FunctionNodeBase
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UnaryFunctionNodeBase" /> class.
    /// </summary>
    /// <param name="parameter">The parameter.</param>
    /// <exception cref="ArgumentNullException">parameter.</exception>
    [SuppressMessage(
        "ReSharper",
        "VirtualMemberCallInConstructor",
        Justification = "We specifically want this to happen.")]
    protected UnaryFunctionNodeBase(NodeBase parameter)
    {
        NodeBase parameterTemp = Requires.NotNull(parameter);

        EnsureCompatibleParameter(parameterTemp);

        Parameter = parameterTemp.Simplify();
    }

    /// <summary>
    ///     Gets the parameter.
    /// </summary>
    /// <value>The parameter.</value>
    public NodeBase Parameter { get; private set; }

    /// <summary>
    ///     Gets a value indicating whether this node supports tolerance.
    /// </summary>
    /// <value>
    ///     <c>true</c> if this instance is tolerant; otherwise, <c>false</c>.
    /// </value>
    public override bool IsTolerant => Parameter.IsTolerant;

    /// <summary>
    ///     Sets the special object request function for sub objects.
    /// </summary>
    /// <param name="func">The function.</param>
    protected override void SetSpecialObjectRequestFunctionForSubObjects(Func<Type, object> func)
    {
        if (Parameter is ISpecialRequestNode specialRequestNode)
        {
            specialRequestNode.SetRequestSpecialObjectFunction(func);
        }
    }

    /// <summary>
    ///     Ensures that the parameter that is received is compatible with the function, optionally allowing the parameter
    ///     reference to change.
    /// </summary>
    /// <param name="parameter">The parameter.</param>
    protected abstract void EnsureCompatibleParameter(NodeBase parameter);

    /// <summary>
    ///     Generates a static unary function call.
    /// </summary>
    /// <typeparam name="T">The type to call the method from.</typeparam>
    /// <param name="functionName">Name of the function.</param>
    /// <returns>An expression representing the static function call.</returns>
    /// <exception cref="ArgumentException"><paramref name="functionName" /> represents a function that cannot be found.</exception>
    [RequiresUnreferencedCode("This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    protected Expression GenerateStaticUnaryFunctionCall<T>(string functionName) =>
        GenerateStaticUnaryFunctionCall(
            typeof(T),
            functionName,
            null);

    /// <summary>
    ///     Generates a static unary function call.
    /// </summary>
    /// <typeparam name="T">The type to call the method from.</typeparam>
    /// <param name="functionName">Name of the function.</param>
    /// <param name="tolerance">The tolerance for this expression. Can be <c>null</c> (<c>Nothing</c> in Visual Basic).</param>
    /// <returns>An expression representing the static function call.</returns>
    /// <exception cref="ArgumentException"><paramref name="functionName" /> represents a function that cannot be found.</exception>
    [RequiresUnreferencedCode("This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    protected Expression GenerateStaticUnaryFunctionCall<T>(
        string functionName,
        Tolerance? tolerance) =>
        GenerateStaticUnaryFunctionCall(
            typeof(T),
            functionName,
            tolerance);

    /// <summary>
    ///     Generates a static unary function call.
    /// </summary>
    /// <param name="t">The type to call the method from.</param>
    /// <param name="functionName">Name of the function.</param>
    /// <returns>An expression representing the static function call.</returns>
    /// <exception cref="ArgumentException"><paramref name="functionName" /> represents a function that cannot be found.</exception>
    [RequiresUnreferencedCode("This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    protected Expression GenerateStaticUnaryFunctionCall(
        Type t,
        string functionName) =>
        GenerateStaticUnaryFunctionCall(
            t,
            functionName,
            null);

    /// <summary>
    ///     Generates a static unary function call.
    /// </summary>
    /// <param name="t">The type to call the method from.</param>
    /// <param name="functionName">Name of the function.</param>
    /// <param name="tolerance">The tolerance for this expression. Can be <c>null</c> (<c>Nothing</c> in Visual Basic).</param>
    /// <returns>
    ///     An expression representing the static function call.
    /// </returns>
    /// <exception cref="ArgumentException"><paramref name="functionName" /> represents a function that cannot be found.</exception>
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    protected Expression GenerateStaticUnaryFunctionCall(
        Type t,
        string functionName,
        Tolerance? tolerance)
    {
        if (string.IsNullOrWhiteSpace(functionName))
        {
            throw new ArgumentException(
                string.Format(
                    CultureInfo.CurrentCulture,
                    Resources.FunctionCouldNotBeFound,
                    functionName), nameof(functionName));
        }

        Type parameterType = ParameterTypeFromParameter(Parameter);

        MethodInfo? mi = t.GetMethodWithExactParameters(
            functionName,
            parameterType);

        if (mi == null)
        {
            parameterType = typeof(double);

            mi = t.GetMethodWithExactParameters(
                functionName,
                parameterType);

            if (mi == null)
            {
                parameterType = typeof(long);

                mi = t.GetMethodWithExactParameters(
                    functionName,
                    parameterType);

                if (mi == null)
                {
                    parameterType = typeof(int);

                    mi = t.GetMethodWithExactParameters(
                        functionName,
                        parameterType) ?? throw new ArgumentException(
                        string.Format(
                            CultureInfo.CurrentCulture,
                            Resources.FunctionCouldNotBeFound,
                            functionName), nameof(functionName));
                }
            }
        }

        Expression e = tolerance == null ? Parameter.GenerateExpression() : Parameter.GenerateExpression(tolerance);

        if (e.Type != parameterType)
        {
            e = Expression.Convert(
                e,
                parameterType);
        }

        return Expression.Call(
            mi,
            e);
    }

    /// <summary>
    ///     Generates a property call on the parameter.
    /// </summary>
    /// <typeparam name="T">The type to call the property from.</typeparam>
    /// <param name="propertyName">Name of the parameter.</param>
    /// <returns>An expression representing a property call.</returns>
    /// <exception cref="ArgumentException"><paramref name="propertyName" /> represents a property that cannot be found.</exception>
    protected Expression GenerateParameterPropertyCall<T>(string propertyName) =>
        GenerateParameterPropertyCall<T>(
            propertyName,
            null);

    /// <summary>
    ///     Generates a property call on the parameter.
    /// </summary>
    /// <typeparam name="T">The type to call the property from.</typeparam>
    /// <param name="propertyName">Name of the parameter.</param>
    /// <param name="tolerance">The tolerance for this expression. Can be <c>null</c> (<c>Nothing</c> in Visual Basic).</param>
    /// <returns>An expression representing a property call.</returns>
    /// <exception cref="ArgumentException"><paramref name="propertyName" /> represents a property that cannot be found.</exception>
    protected Expression GenerateParameterPropertyCall<T>(
        string propertyName,
        Tolerance? tolerance)
    {
        if (string.IsNullOrWhiteSpace(propertyName))
        {
            throw new ArgumentException(
                string.Format(
                    CultureInfo.CurrentCulture,
                    Resources.FunctionCouldNotBeFound,
                    propertyName), nameof(propertyName));
        }

        PropertyInfo pi = typeof(T).GetRuntimeProperty(propertyName) ?? throw new ArgumentException(
            string.Format(
                CultureInfo.CurrentCulture,
                Resources.FunctionCouldNotBeFound,
                propertyName), nameof(propertyName));

        return Expression.Property(
            tolerance == null ? Parameter.GenerateExpression() : Parameter.GenerateExpression(tolerance),
            pi);
    }

    /// <summary>
    ///     Generates a property call on the parameter.
    /// </summary>
    /// <typeparam name="T">The type to call the property from.</typeparam>
    /// <param name="methodName">Name of the parameter.</param>
    /// <returns>An expression representing a property call.</returns>
    /// <exception cref="ArgumentException"><paramref name="methodName" /> represents a property that cannot be found.</exception>
    protected Expression GenerateParameterMethodCall<T>(string methodName) =>
        GenerateParameterMethodCall<T>(
            methodName,
            null);

    /// <summary>
    ///     Generates a property call on the parameter.
    /// </summary>
    /// <typeparam name="T">The type to call the property from.</typeparam>
    /// <param name="methodName">Name of the parameter.</param>
    /// <param name="tolerance">The tolerance for this expression. Can be <c>null</c> (<c>Nothing</c> in Visual Basic).</param>
    /// <returns>An expression representing a property call.</returns>
    /// <exception cref="ArgumentException"><paramref name="methodName" /> represents a property that cannot be found.</exception>
    protected Expression GenerateParameterMethodCall<T>(
        string methodName,
        Tolerance? tolerance)
    {
        if (string.IsNullOrWhiteSpace(methodName))
        {
            throw new ArgumentException(
                string.Format(
                    CultureInfo.CurrentCulture,
                    Resources.FunctionCouldNotBeFound,
                    methodName), nameof(methodName));
        }

        MethodInfo mi = typeof(T).GetRuntimeMethod(
            methodName,
            Array.Empty<Type>()) ?? throw new ArgumentException(
            string.Format(
                CultureInfo.CurrentCulture,
                Resources.FunctionCouldNotBeFound,
                methodName), nameof(methodName));

        return tolerance == null
            ? Expression.Call(
                Parameter.GenerateExpression(),
                mi)
            : Expression.Call(
                Parameter.GenerateExpression(tolerance),
                mi);
    }
}