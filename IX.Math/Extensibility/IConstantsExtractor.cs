using IX.Math.Nodes;

namespace IX.Math.Extensibility;

/// <summary>
///     A service contract for extractors of constant values from the expression.
/// </summary>
public interface IConstantsExtractor
{
    /// <summary>
    ///     Extracts all constants, replacing them from the original expression.
    /// </summary>
    /// <param name="originalExpression">The original expression.</param>
    /// <param name="constantsTable">The constants table.</param>
    /// <param name="reverseConstantsTable">The reverse constants table.</param>
    /// <param name="mathDefinition">The math definition.</param>
    /// <returns>The expression, after replacement.</returns>
    string ExtractAllConstants(
        string originalExpression,
        IDictionary<string, ConstantNodeBase> constantsTable,
        IDictionary<string, string> reverseConstantsTable,
        MathDefinition mathDefinition);
}