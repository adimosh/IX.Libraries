using IX.Library.Globalization;

using System.Globalization;
using IX.Math.Extensibility;
using IX.Math.Formatters;
using IX.Math.Nodes;
using IX.Math.Nodes.Constants;

namespace IX.Math.Generators;

/// <summary>
///     A generator for constant values and their like.
/// </summary>
public static class ConstantsGenerator
{
    /// <summary>
    /// Generates a string constant.
    /// </summary>
    /// <param name="constantsTable">The constants table.</param>
    /// <param name="reverseConstantsTable">The reverse constants table.</param>
    /// <param name="originalExpression">The original expression.</param>
    /// <param name="stringIndicator">The string indicator.</param>
    /// <param name="content">The content.</param>
    /// <returns>
    /// The name of the new constant.
    /// </returns>
    public static string GenerateStringConstant(
        IDictionary<string, ConstantNodeBase> constantsTable,
        IDictionary<string, string> reverseConstantsTable,
        string originalExpression,
        string stringIndicator,
        string content)
    {
        // Contract validation
        _ = Requires.NotNullOrWhiteSpace(
            originalExpression,
            nameof(originalExpression));
        if (constantsTable is null) throw new ArgumentNullException(nameof(constantsTable));
        if (reverseConstantsTable is null) throw new ArgumentNullException(nameof(reverseConstantsTable));
        _ = Requires.NotNullOrWhiteSpace(
            stringIndicator,
            nameof(stringIndicator));
        _ = Requires.NotNullOrWhiteSpace(
            content,
            nameof(content));

        // Operation
        if (reverseConstantsTable.TryGetValue(
                content,
                out var key))
        {
            return key;
        }

        var stringIndicatorLength = stringIndicator.Length;

        var name = GenerateName(
            constantsTable.Keys,
            originalExpression);
        constantsTable.Add(
            name,
            new StringNode(
                content.Substring(
                    stringIndicatorLength,
                    content.Length - stringIndicatorLength * 2)));
        reverseConstantsTable.Add(
            content,
            name);
        return name;
    }

    /// <summary>
    ///     Generates a numeric constant out of a string.
    /// </summary>
    /// <param name="constantsTable">The constants table.</param>
    /// <param name="reverseConstantsTable">The reverse constants table.</param>
    /// <param name="originalExpression">The original expression.</param>
    /// <param name="content">The content.</param>
    /// <returns>The name of the new constant.</returns>
    public static string? GenerateNumericConstant(
        IDictionary<string, ConstantNodeBase> constantsTable,
        IDictionary<string, string> reverseConstantsTable,
        string originalExpression,
        string content)
    {
        // Contract validation
        _ = Requires.NotNullOrWhiteSpace(
            originalExpression,
            nameof(originalExpression));
        if (constantsTable is null) throw new ArgumentNullException(nameof(constantsTable));
        if (reverseConstantsTable is null) throw new ArgumentNullException(nameof(reverseConstantsTable));
        _ = Requires.NotNullOrWhiteSpace(
            content,
            nameof(content));

        // Operation
        if (reverseConstantsTable.TryGetValue(
                content,
                out var key))
        {
            return key;
        }

        if (!double.TryParse(
                content,
                out var result))
        {
            return null;
        }

        var name = GenerateName(
            constantsTable.Keys,
            originalExpression);
        constantsTable.Add(
            name,
            new NumericNode(result));
        reverseConstantsTable.Add(
            content,
            name);
        return name;
    }

    /// <summary>
    ///     Generates a named numeric symbol.
    /// </summary>
    /// <param name="constantsTable">The constants table.</param>
    /// <param name="reverseConstantsTable">The reverse constants table.</param>
    /// <param name="name">The name.</param>
    /// <param name="value">The value.</param>
    /// <param name="alternateNames">The alternate names.</param>
    public static void GenerateNamedNumericSymbol(
        IDictionary<string, ConstantNodeBase> constantsTable,
        IDictionary<string, string> reverseConstantsTable,
        string name,
        double value,
        params string[] alternateNames)
    {
        // Contract validation
        _ = Requires.NotNullOrWhiteSpace(
            name,
            nameof(name));
        if (constantsTable is null) throw new ArgumentNullException(nameof(constantsTable));
        if (reverseConstantsTable is null) throw new ArgumentNullException(nameof(reverseConstantsTable));

        // Operation
        if (reverseConstantsTable.TryGetValue(
                name,
                out _))
        {
            return;
        }

        constantsTable.Add(
            name,
            new NumericNode(value));
        reverseConstantsTable.Add(
            value.ToString(CultureInfo.CurrentCulture),
            name);

        foreach (var alternateName in alternateNames)
        {
            reverseConstantsTable.Add(
                alternateName,
                name);
        }
    }

    /// <summary>
    /// Checks the constant to see if there isn't one already, then tries to guess what type it is, finally adding it to
    /// the constants table if one suitable type is found.
    /// </summary>
    /// <param name="constantsTable">The constants table.</param>
    /// <param name="reverseConstantsTable">The reverse constants table.</param>
    /// <param name="interpreters">The constant interpreters.</param>
    /// <param name="originalExpression">The original expression.</param>
    /// <param name="content">The content.</param>
    /// <returns>
    /// The name of the new constant, or <see langword="null" /> (<see langword="Nothing" /> in Visual Basic) if a
    /// suitable type is not found.
    /// </returns>
    [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Performance",
        "HAA0401:Possible allocation of reference type enumerator",
        Justification = "We're cool with this.")]
    internal static string? CheckAndAdd(
        IDictionary<string, ConstantNodeBase> constantsTable,
        IDictionary<string, string> reverseConstantsTable,
        LevelDictionary<Type, IConstantInterpreter> interpreters,
        string originalExpression,
        string content)
    {
        // No content
        if (string.IsNullOrWhiteSpace(content))
        {
            return null;
        }

        // Constant has already been evaluated, let's skip
        if (reverseConstantsTable.TryGetValue(
                content,
                out var key))
        {
            return key;
        }

        ConstantNodeBase? node = null;

        // Go through each interpreter
        foreach (var interpreter in interpreters.KeysByLevel.SelectMany(p => p.Value))
        {
            var (success, result) = interpreters[interpreter].EvaluateIsConstant(content);
            if (success)
            {
                node = result;
                break;
            }
        }

        // Standard formatters
        if (node == null)
        {
            if (ParsingFormatter.ParseNumeric(
                    content,
                    out object? n))
            {
                node = new NumericNode(n);
            }
            else if (ParsingFormatter.ParseByteArray(
                         content,
                         out byte[]? ba))
            {
                node = new ByteArrayNode(ba);
            }
            else if (bool.TryParse(
                         content,
                         out var b))
            {
                node = new BoolNode(b);
            }
        }

        // Node not recognized
        if (node == null)
        {
            return null;
        }

        // Get the constant a new name
        string name = GenerateName(
            constantsTable.Keys,
            originalExpression);

        // Add constant data to tables
        constantsTable.Add(
            name,
            node);
        reverseConstantsTable.Add(
            content,
            name);

        // Return
        return name;
    }

    private static string GenerateName(
        IEnumerable<string> keys,
        string originalExpression)
    {
        var index = int.Parse(
            keys.Where(p => p.InvariantCultureStartsWith("Const") && p.Length > 5).LastOrDefault()?[5..] ?? "0", CultureInfo.CurrentCulture);

        do
        {
            index++;
        }
        while (originalExpression.InvariantCultureContains($"Const{index.ToString(CultureInfo.InvariantCulture)}"));

        return $"Const{index.ToString(CultureInfo.InvariantCulture)}";
    }
}