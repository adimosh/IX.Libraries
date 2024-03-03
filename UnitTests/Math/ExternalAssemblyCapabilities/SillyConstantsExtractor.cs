using System.Text.RegularExpressions;
using IX.Math;
using IX.Math.Extensibility;
using IX.Math.Nodes;

namespace UnitTests.Math.ExternalAssemblyCapabilities;

/// <summary>
/// A constants extractor used for testing purposes.
/// </summary>
/// <seealso cref="IConstantsExtractor" />
public partial class SillyConstantsExtractor : IConstantsExtractor
{
    private readonly Regex _exponentialNotationRegex = SillyPatternRegex();

    /// <summary>
    /// Extracts all constants, replacing them from the original expression.
    /// </summary>
    /// <param name="originalExpression">The original expression.</param>
    /// <param name="constantsTable">The constants table.</param>
    /// <param name="reverseConstantsTable">The reverse constants table.</param>
    /// <param name="mathDefinition">The math definition.</param>
    /// <returns>The expression, after replacement.</returns>
    public string ExtractAllConstants(string originalExpression, IDictionary<string, ConstantNodeBase> constantsTable, IDictionary<string, string> reverseConstantsTable, MathDefinition mathDefinition) => _exponentialNotationRegex.Replace(originalExpression, "stupid", 1);
    [GeneratedRegex(@"silly")]
    private static partial Regex SillyPatternRegex();
}