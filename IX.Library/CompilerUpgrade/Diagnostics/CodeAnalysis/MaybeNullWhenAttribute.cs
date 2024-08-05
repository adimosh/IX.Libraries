#if !FRAMEWORK_ADVANCED

// ReSharper disable once CheckNamespace - We want this
namespace System.Diagnostics.CodeAnalysis;

/// <summary>
///     Specifies that when a method returns <see cref="ReturnValue" />, the parameter may be null even if the
///     corresponding type disallows it. This type is only provided to stop warnings from unsupported frameworks.
/// </summary>
[AttributeUsage(AttributeTargets.Parameter)]
public sealed class MaybeNullWhenAttribute : Attribute
{
    /// <summary>Initializes a new instance of the <see cref="MaybeNullWhenAttribute"/> class with the specified return value condition.</summary>
    /// <param name="returnValue">
    ///     The return value condition. If the method returns this value, the associated parameter may be null.
    /// </param>
    public MaybeNullWhenAttribute(bool returnValue) => ReturnValue = returnValue;

    /// <summary>Gets the return value condition.</summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1623:Property summary documentation should match accessors",
        Justification = "This is not a switch.")]
    public bool ReturnValue { get; }
}
#endif