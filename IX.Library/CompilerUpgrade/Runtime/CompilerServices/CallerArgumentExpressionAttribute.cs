#if !NET6_0_OR_GREATER

// ReSharper disable once CheckNamespace
namespace System.Runtime.CompilerServices;

/// <summary>
/// Allows capturing of the expressions passed to a method.
/// </summary>
[PublicAPI]
[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
public sealed class CallerArgumentExpressionAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CallerArgumentExpressionAttribute"/> class.
    /// </summary>
    /// <param name="parameterName">The name of the targeted parameter.</param>
    public CallerArgumentExpressionAttribute(string parameterName) => ParameterName = parameterName;

    /// <summary>
    /// Gets the target parameter name of the CallerArgumentExpression.
    /// </summary>
    /// <value>
    /// The name of the targeted parameter of the CallerArgumentExpression.
    /// </value>
    public string ParameterName { get; }
}
#endif