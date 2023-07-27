using IX.Core;

using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;

namespace IX.Math.Nodes;

/// <summary>
///     A base class for functions that take no parameters.
/// </summary>
/// <seealso cref="FunctionNodeBase" />
[PublicAPI]
public abstract class NonaryFunctionNodeBase : FunctionNodeBase
{
    /// <summary>
    ///     Gets a value indicating whether this node supports tolerance.
    /// </summary>
    /// <value>
    ///     <c>true</c> if this instance is tolerant; otherwise, <c>false</c>.
    /// </value>
    public override bool IsTolerant => false;

    /// <summary>
    ///     Sets the special object request function for sub objects.
    /// </summary>
    /// <param name="func">The function.</param>
    protected override void SetSpecialObjectRequestFunctionForSubObjects(Func<Type, object> func) { }

    /// <summary>
    ///     Generates a static function call for a function with no parameters.
    /// </summary>
    /// <typeparam name="T">The type to call the function on.</typeparam>
    /// <param name="functionName">Name of the function.</param>
    /// <returns>An expression representing the function call.</returns>
    /// <exception cref="ArgumentException">The function name is invalid.</exception>
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    protected Expression GenerateStaticNonaryFunctionCall<T>(string functionName) =>
        GenerateStaticNonaryFunctionCall(
            typeof(T),
            functionName);

    /// <summary>
    ///     Generates a static function call for a function with no parameters.
    /// </summary>
    /// <param name="t">The type to call the function on.</param>
    /// <param name="functionName">Name of the function.</param>
    /// <returns>An expression representing the function call.</returns>
    /// <exception cref="ArgumentException">The function name is invalid.</exception>
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    protected Expression GenerateStaticNonaryFunctionCall(
        Type t,
        string functionName)
    {
        if (string.IsNullOrWhiteSpace(functionName))
        {
            throw new ArgumentException(
                string.Format(
                    CultureInfo.CurrentCulture,
                    Resources.FunctionCouldNotBeFound,
                    functionName), nameof(functionName));
        }

        MethodInfo mi = t.GetMethodWithExactParameters(
            functionName,
            Type.EmptyTypes) ?? throw new ArgumentException(
            string.Format(
                CultureInfo.CurrentCulture,
                Resources.FunctionCouldNotBeFound,
                functionName), nameof(functionName));

        return Expression.Call(mi);
    }
}