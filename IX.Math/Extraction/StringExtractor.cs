using System.Text;
using IX.Math.Generators;
using IX.Math.Nodes;

namespace IX.Math.Extraction;

/// <summary>
///     An extractor for strings. This class cannot be inherited.
/// </summary>
internal sealed class StringExtractor : Extensibility.IConstantsExtractor
{
    /// <summary>
    ///     Extracts the string constants and replaces them with expression placeholders.
    /// </summary>
    /// <param name="originalExpression">The original expression.</param>
    /// <param name="constantsTable">The constants table.</param>
    /// <param name="reverseConstantsTable">The reverse constants table.</param>
    /// <param name="mathDefinition">The math definition.</param>
    /// <returns>The expression, after replacement.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="originalExpression" />
    ///     or
    ///     <paramref name="constantsTable" />
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
        var stringIndicatorString = mathDefinition.StringIndicator;
        var stringIndicator = mathDefinition.StringIndicator.AsSpan();
        var stringIndicatorLength = stringIndicator.Length;
        var escapeCharacter = mathDefinition.EscapeCharacter.AsSpan();
        var escapeCharacterLength = escapeCharacter.Length;

        var process = originalExpression.AsSpan();
        StringBuilder? sb = null;

        while (true)
        {
            var openingPosition = process.IndexOf(
                stringIndicator,
                StringComparison.CurrentCulture);

            if (openingPosition == -1)
            {
                // No string opening
                break;
            }

            var header = process[..openingPosition];

            var rest = process[(openingPosition + stringIndicatorLength)..];

            int closingPosition;
            ReadOnlySpan<char> body;

            do
            {
                closingPosition = rest.IndexOf(stringIndicator, StringComparison.CurrentCulture);

                if (closingPosition == -1) continue;

                body = rest[..closingPosition];

                int occurrences = 0;

                while (body.EndsWith(escapeCharacter))
                {
                    occurrences++;
                    body = body[..^escapeCharacterLength];
                }

                rest = rest[(closingPosition + stringIndicatorLength)..];

                if (occurrences % 2 == 0) break;
            }
            while (closingPosition != -1);

            if (closingPosition == -1)
            {
                // No string closing
                break;
            }

            // We have a proper string
            body = process.Slice(
                openingPosition,
                process.Length - header.Length - rest.Length);

            var itemName = ConstantsGenerator.GenerateStringConstant(
                constantsTable,
                reverseConstantsTable,
                originalExpression,
                stringIndicatorString,
                body.ToString());

            sb ??= new(originalExpression.Length);

            #if FRAMEWORK_ADVANCED
            sb.Append(header);
            #else
            sb.Append(header.ToString());
            #endif

            sb.Append(itemName);

            process = rest;
        }

        if (sb == null)
        {
            return originalExpression;
        }

        #if FRAMEWORK_ADVANCED
        sb.Append(process);
        #else
        sb.Append(process.ToString());
        #endif

        return sb.ToString();
    }
}