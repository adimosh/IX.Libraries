using IX.Library.Contracts;

using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;

using IX.Math.Extensibility;

namespace IX.Math.Nodes;

/// <summary>
///     A base class for a function that takes two parameters.
/// </summary>
/// <seealso cref="FunctionNodeBase" />
[PublicAPI]
public abstract class BinaryFunctionNodeBase : FunctionNodeBase
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="BinaryFunctionNodeBase" /> class.
    /// </summary>
    /// <param name="firstParameter">The first parameter.</param>
    /// <param name="secondParameter">The second parameter.</param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="firstParameter" />
    ///     or
    ///     <paramref name="secondParameter" />
    ///     is <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    [SuppressMessage(
        "ReSharper",
        "VirtualMemberCallInConstructor",
        Justification = "We specifically want this to happen.")]
    [SuppressMessage(
        "Usage",
        "CA2214:Do not call overridable methods in constructors",
        Justification = "We specifically want this to happen.")]
    protected BinaryFunctionNodeBase(
        NodeBase firstParameter,
        NodeBase secondParameter)
    {
        NodeBase firstParameterTemp = Requires.NotNull(firstParameter);
        NodeBase secondParameterTemp = Requires.NotNull(secondParameter);

        EnsureCompatibleParameters(
            firstParameter,
            secondParameter);

        FirstParameter = firstParameterTemp.Simplify();
        SecondParameter = secondParameterTemp.Simplify();
    }

    /// <summary>
    ///     Gets the first parameter.
    /// </summary>
    /// <value>The first parameter.</value>
    public NodeBase FirstParameter { get; }

    /// <summary>
    ///     Gets the second parameter.
    /// </summary>
    /// <value>The second parameter.</value>
    public NodeBase SecondParameter { get; }

    /// <summary>
    ///     Gets a value indicating whether this node supports tolerance.
    /// </summary>
    /// <value>
    ///     <c>true</c> if this instance is tolerant; otherwise, <c>false</c>.
    /// </value>
    public override bool IsTolerant => FirstParameter.IsTolerant || SecondParameter.IsTolerant;

    /// <summary>
    ///     Sets the special object request function for sub objects.
    /// </summary>
    /// <param name="func">The function.</param>
    protected override void SetSpecialObjectRequestFunctionForSubObjects(Func<Type, object> func)
    {
        if (FirstParameter is ISpecialRequestNode specialRequestNodeLeft)
        {
            specialRequestNodeLeft.SetRequestSpecialObjectFunction(func);
        }

        if (SecondParameter is ISpecialRequestNode specialRequestNodeRight)
        {
            specialRequestNodeRight.SetRequestSpecialObjectFunction(func);
        }
    }

    /// <summary>
    ///     Ensures that the parameters that are received are compatible with the function, optionally allowing the parameter
    ///     references to change.
    /// </summary>
    /// <param name="firstParameter">The first parameter.</param>
    /// <param name="secondParameter">The second parameter.</param>
    protected abstract void EnsureCompatibleParameters(
        NodeBase firstParameter,
        NodeBase secondParameter);

    /// <summary>
    ///     Generates a static binary function call expression.
    /// </summary>
    /// <typeparam name="T">The type to call on.</typeparam>
    /// <param name="functionName">Name of the function.</param>
    /// <returns>An expression representing the call.</returns>
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    protected Expression GenerateStaticBinaryFunctionCall<T>(string functionName) =>
        GenerateStaticBinaryFunctionCall(
            typeof(T),
            functionName,
            null);

    /// <summary>
    ///     Generates a static binary function call expression.
    /// </summary>
    /// <typeparam name="T">The type to call on.</typeparam>
    /// <param name="functionName">Name of the function.</param>
    /// <param name="tolerance">
    ///     The tolerance, should there be any. This argument can be <c>null</c> (<c>Nothing</c> in Visual
    ///     Basic).
    /// </param>
    /// <returns>An expression representing the call.</returns>
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    protected Expression GenerateStaticBinaryFunctionCall<T>(
        string functionName,
        Tolerance? tolerance) => GenerateStaticBinaryFunctionCall(
        typeof(T),
        functionName,
        tolerance);

    /// <summary>
    ///     Generates a static binary function call expression.
    /// </summary>
    /// <param name="t">The type to call on.</param>
    /// <param name="functionName">Name of the function.</param>
    /// <returns>Expression.</returns>
    /// <exception cref="ArgumentException">The function name is invalid.</exception>
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    protected Expression GenerateStaticBinaryFunctionCall(
        Type t,
        string functionName) => GenerateStaticBinaryFunctionCall(
        t,
        functionName,
        null);

    /// <summary>
    ///     Generates a static binary function call expression.
    /// </summary>
    /// <param name="t">The type to call on.</param>
    /// <param name="functionName">Name of the function.</param>
    /// <param name="tolerance">
    ///     The tolerance, should there be any. This argument can be <c>null</c> (<c>Nothing</c> in Visual
    ///     Basic).
    /// </param>
    /// <returns>Expression.</returns>
    /// <exception cref="ArgumentException">The function name is invalid.</exception>
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    protected Expression GenerateStaticBinaryFunctionCall(
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

        Type firstParameterType = ParameterTypeFromParameter(FirstParameter);
        Type secondParameterType = ParameterTypeFromParameter(SecondParameter);

        MethodInfo? mi = t.GetMethodWithExactParameters(
            functionName,
            firstParameterType,
            secondParameterType);

        if (mi == null)
        {
            firstParameterType = typeof(double);
            secondParameterType = typeof(double);

            mi = t.GetMethodWithExactParameters(
                functionName,
                firstParameterType,
                secondParameterType);

            if (mi == null)
            {
                firstParameterType = typeof(long);
                secondParameterType = typeof(long);

                mi = t.GetMethodWithExactParameters(
                    functionName,
                    firstParameterType,
                    secondParameterType);

                if (mi == null)
                {
                    firstParameterType = typeof(int);
                    secondParameterType = typeof(int);

                    mi = t.GetMethodWithExactParameters(
                        functionName,
                        firstParameterType,
                        secondParameterType) ?? throw new ArgumentException(
                        string.Format(
                            CultureInfo.CurrentCulture,
                            Resources.FunctionCouldNotBeFound,
                            functionName), nameof(functionName));
                }
            }
        }

        Expression e1, e2;

        if (tolerance == null)
        {
            e1 = FirstParameter.GenerateExpression();
            e2 = SecondParameter.GenerateExpression();
        }
        else
        {
            e1 = FirstParameter.GenerateExpression(tolerance);
            e2 = SecondParameter.GenerateExpression(tolerance);
        }

        if (e1.Type != firstParameterType)
        {
            e1 = Expression.Convert(
                e1,
                firstParameterType);
        }

        if (e2.Type != secondParameterType)
        {
            e2 = Expression.Convert(
                e2,
                secondParameterType);
        }

        return Expression.Call(
            mi,
            e1,
            e2);
    }

    /// <summary>
    ///     Generates a static binary function call with explicit parameter types.
    /// </summary>
    /// <typeparam name="TParam1">The type of the first parameter.</typeparam>
    /// <typeparam name="TParam2">The type of the second parameter.</typeparam>
    /// <param name="t">The type to call on.</param>
    /// <param name="functionName">Name of the function.</param>
    /// <returns>
    ///     The generated binary method call expression.
    /// </returns>
    /// <exception cref="ArgumentException">The function name is invalid.</exception>
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    protected Expression GenerateStaticBinaryFunctionCall<TParam1, TParam2>(
        Type t,
        string functionName) =>
        GenerateStaticBinaryFunctionCall<TParam1, TParam2>(
            t,
            functionName,
            null);

    /// <summary>
    ///     Generates a static binary function call with explicit parameter types.
    /// </summary>
    /// <typeparam name="TParam1">The type of the first parameter.</typeparam>
    /// <typeparam name="TParam2">The type of the second parameter.</typeparam>
    /// <param name="t">The type to call on.</param>
    /// <param name="functionName">Name of the function.</param>
    /// <param name="tolerance">
    ///     The tolerance, should there be any. This argument can be <c>null</c> (<c>Nothing</c> in Visual
    ///     Basic).
    /// </param>
    /// <returns>
    ///     The generated binary method call expression.
    /// </returns>
    /// <exception cref="ArgumentException">The function name is invalid.</exception>
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    protected Expression GenerateStaticBinaryFunctionCall<TParam1, TParam2>(
        Type t,
        string functionName,
        Tolerance? tolerance)
    {
        if (string.IsNullOrWhiteSpace(functionName))
        {
            throw new ArgumentException(
                string.Format(
                    Resources.FunctionCouldNotBeFound,
                    functionName), nameof(functionName));
        }

        Type firstParameterType = ParameterTypeFromParameter(FirstParameter);
        Type secondParameterType = ParameterTypeFromParameter(SecondParameter);

        MethodInfo mi = t.GetMethodWithExactParameters(
                            functionName,
                            typeof(TParam1),
                            typeof(TParam2)) ??
                        throw new FunctionCallNotValidLogicallyException();

        Expression e1, e2;

        if (tolerance == null)
        {
            e1 = FirstParameter.GenerateExpression();
            e2 = SecondParameter.GenerateExpression();
        }
        else
        {
            e1 = FirstParameter.GenerateExpression(tolerance);
            e2 = SecondParameter.GenerateExpression(tolerance);
        }

        if (e1.Type != firstParameterType)
        {
            e1 = Expression.Convert(
                e1,
                firstParameterType);
        }

        if (e2.Type != secondParameterType)
        {
            e2 = Expression.Convert(
                e2,
                secondParameterType);
        }

        if (e1.Type != typeof(TParam1))
        {
            e1 = Expression.Convert(
                e1,
                typeof(TParam1));
        }

        if (e2.Type != typeof(TParam2))
        {
            e2 = Expression.Convert(
                e2,
                typeof(TParam2));
        }

        return Expression.Call(
            mi,
            e1,
            e2);
    }

    /// <summary>
    ///     Generates a static binary function call expression.
    /// </summary>
    /// <typeparam name="T">The type to call on.</typeparam>
    /// <param name="functionName">Name of the function.</param>
    /// <returns>An expression representing the call.</returns>
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    protected Expression GenerateBinaryFunctionCallFirstParameterInstance<T>(string functionName) =>
        GenerateBinaryFunctionCallFirstParameterInstance(
            typeof(T),
            functionName,
            null);

    /// <summary>
    ///     Generates a static binary function call expression.
    /// </summary>
    /// <param name="t">The type to call on.</param>
    /// <param name="functionName">Name of the function.</param>
    /// <returns>Expression.</returns>
    /// <exception cref="ArgumentException">The function name is invalid.</exception>
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    protected Expression GenerateBinaryFunctionCallFirstParameterInstance(
        Type t,
        string functionName) =>
        GenerateBinaryFunctionCallFirstParameterInstance(
            t,
            functionName,
            null);

    /// <summary>
    ///     Generates a static binary function call expression.
    /// </summary>
    /// <param name="t">The type to call on.</param>
    /// <param name="functionName">Name of the function.</param>
    /// <param name="tolerance">
    ///     The tolerance, should there be any. This argument can be <c>null</c> (<c>Nothing</c> in Visual
    ///     Basic).
    /// </param>
    /// <returns>
    ///     Expression.
    /// </returns>
    /// <exception cref="ArgumentException">The function name is invalid.</exception>
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    protected Expression GenerateBinaryFunctionCallFirstParameterInstance(
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

        Type firstParameterType = ParameterTypeFromParameter(FirstParameter);
        Type secondParameterType = ParameterTypeFromParameter(SecondParameter);

        MethodInfo? mi = t.GetMethodWithExactParameters(
            functionName,
            firstParameterType,
            secondParameterType);

        if (mi == null)
        {
            if (firstParameterType == typeof(long) && secondParameterType == typeof(double) ||
                firstParameterType == typeof(double) && secondParameterType == typeof(long))
            {
                firstParameterType = typeof(double);
                secondParameterType = typeof(double);

                mi = t.GetMethodWithExactParameters(
                    functionName,
                    firstParameterType,
                    secondParameterType);

                if (mi == null)
                {
                    firstParameterType = typeof(long);
                    secondParameterType = typeof(long);

                    mi = t.GetMethodWithExactParameters(
                        functionName,
                        firstParameterType,
                        secondParameterType);

                    if (mi == null)
                    {
                        firstParameterType = typeof(int);
                        secondParameterType = typeof(int);

                        mi = t.GetMethodWithExactParameters(
                            functionName,
                            firstParameterType,
                            secondParameterType) ?? throw new ArgumentException(
                            string.Format(
                                CultureInfo.CurrentCulture,
                                Resources.FunctionCouldNotBeFound,
                                functionName), nameof(functionName));
                    }
                }
            }
            else
            {
                throw new ArgumentException(
                    string.Format(
                        CultureInfo.CurrentCulture,
                        Resources.FunctionCouldNotBeFound,
                        functionName), nameof(functionName));
            }
        }

        Expression e1, e2;

        if (tolerance == null)
        {
            e1 = FirstParameter.GenerateExpression();
            e2 = SecondParameter.GenerateExpression();
        }
        else
        {
            e1 = FirstParameter.GenerateExpression(tolerance);
            e2 = SecondParameter.GenerateExpression(tolerance);
        }

        if (e1.Type != firstParameterType)
        {
            e1 = Expression.Convert(
                e1,
                firstParameterType);
        }

        if (e2.Type != secondParameterType)
        {
            e2 = Expression.Convert(
                e2,
                secondParameterType);
        }

        return Expression.Call(
            e1,
            mi,
            e2);
    }
}