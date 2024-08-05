using IX.Library.Globalization;
using IX.Math.Extensibility;

namespace UnitTests.Math.ExternalAssemblyCapabilities;

/// <summary>
/// Test pass-through extractor baby.
/// </summary>
[ConstantsPassThroughExtractor]
public class SillyPassThroughConstantsExtractor : IConstantPassThroughExtractor
{
    /// <summary>
    /// Evaluates an expression and decides whether it should be a pass-through constant.
    /// </summary>
    /// <param name="expression">The expression to evaluate.</param>
    /// <returns><c>true</c> if the expression is a pass-through constant, <c>false</c> otherwise.</returns>
    public bool Evaluate(string expression) => expression.InvariantCultureEqualsInsensitive("1+2");
}