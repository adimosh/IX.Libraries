using System.Text.RegularExpressions;
using IX.Math.Generators;
using IX.Math.Nodes;

namespace IX.Math.Extraction;

/// <summary>
///     An extractor for scientific notation of numbers. This class cannot be inherited.
/// </summary>
/// <seealso cref="Extensibility.IConstantsExtractor" />
internal sealed class ScientificFormatNumberExtractor : Extensibility.IConstantsExtractor
{
    private readonly Regex _exponentialNotationRegex = new(@"[0-9.,]+(?:e\+|E\+|e\-|E\-|e|E)[0-9]+");

    /// <summary>
    ///     Extracts the scientific notations constants and replaces them with expression placeholders.
    /// </summary>
    /// <param name="originalExpression">The original expression.</param>
    /// <param name="constantsTable">The constants table.</param>
    /// <param name="reverseConstantsTable">The reverse constants table.</param>
    /// <param name="mathDefinition">The math definition.</param>
    /// <returns>The expression, after replacement.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="constantsTable" />
    ///     or
    ///     <paramref name="mathDefinition" />
    ///     or
    ///     <paramref name="originalExpression" />
    ///     or
    ///     <paramref name="reverseConstantsTable" />
    ///     is <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public string ExtractAllConstants(
        string originalExpression,
        IDictionary<string, ConstantNodeBase> constantsTable,
        IDictionary<string, string> reverseConstantsTable,
        MathDefinition mathDefinition)
    {
        var process = originalExpression;
        var location = 0;

        while (process.Length > location)
        {
            Match match = _exponentialNotationRegex.Match(
                process,
                location);

            if (!match.Success)
            {
                break;
            }

            var itemName = ConstantsGenerator.GenerateNumericConstant(
                constantsTable,
                reverseConstantsTable,
                process,
                match.Value);

            if (!string.IsNullOrWhiteSpace(itemName))
            {
                process = _exponentialNotationRegex.Replace(
                    process,
                    itemName,
                    1,
                    location);
            }
            else
            {
                location = match.Index + match.Length;
            }
        }

        return process;
    }
}