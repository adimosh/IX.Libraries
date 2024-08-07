// ReSharper disable once CheckNamespace
namespace IX.Math;

public sealed partial class ComputedExpression
{
    /// <summary>
    /// Gets a value indicating whether this computed expression is compiled.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this expression is compiled; otherwise, <c>false</c>.
    /// </value>
    [Obsolete("This property was never used, and will be removed in the next breaking changes release.")]
    public bool IsCompiled { get; private set; }
}