using IX.Math.ExpressionState;
using IX.Math.Extensibility;
using IX.Math.Nodes;
using IX.Math.Registration;

namespace IX.Math.Generators;

/// <summary>
///     A class to handle table population.
/// </summary>
internal static class TablePopulationGenerator
{
    /// <summary>
    /// Populates tables according to the currently-processed expression.
    /// </summary>
    /// <param name="processedExpression">The expression that is being processed.</param>
    /// <param name="constantsTable">The constants table.</param>
    /// <param name="reverseConstantsTable">The reverse-lookup constants table.</param>
    /// <param name="symbolTable">The symbols table.</param>
    /// <param name="reverseSymbolTable">The reverse-lookup symbols table.</param>
    /// <param name="parameterRegistry">The parameters registry.</param>
    /// <param name="interpreters">The constant interpreters.</param>
    /// <param name="originalExpression">The expression before processing.</param>
    /// <param name="openParenthesis">The symbol of an open parenthesis.</param>
    /// <param name="allSymbols">All symbols on which to split, in order.</param>
    internal static void PopulateTables(
        string processedExpression,
        Dictionary<string, ConstantNodeBase> constantsTable,
        Dictionary<string, string> reverseConstantsTable,
        Dictionary<string, ExpressionSymbol> symbolTable,
        Dictionary<string, string> reverseSymbolTable,
        IParameterRegistry parameterRegistry,
        LevelDictionary<Type, IConstantInterpreter> interpreters,
        string originalExpression,
        string openParenthesis,
        string[] allSymbols)
    {
        // Split expression by all symbols
        string[] expressions = processedExpression.Split(
            allSymbols,
            StringSplitOptions.RemoveEmptyEntries);

        foreach (var exp in expressions)
        {
            if (constantsTable.ContainsKey(exp))
            {
                // We have a constant
                continue;
            }

            if (reverseConstantsTable.ContainsKey(exp))
            {
                // We have a constant that has bee evaluated before
                continue;
            }

            if (parameterRegistry.Exists(exp))
            {
                // We have a parameter
                continue;
            }

            if (symbolTable.ContainsKey(exp))
            {
                // We have an already-existing symbol
                continue;
            }

            if (reverseSymbolTable.ContainsKey(exp))
            {
                // We have a symbol value that has been evaluated before
                continue;
            }

            if (exp.Contains(openParenthesis))
            {
                // We have a part of a function
                continue;
            }

            // Let's check whether it is a constant
            if (ConstantsGenerator.CheckAndAdd(
                    constantsTable,
                    reverseConstantsTable,
                    interpreters,
                    originalExpression,
                    exp) != null)
            {
                continue;
            }

            // It's not a constant, nor something ever encountered before
            // Therefore it should be a parameter
            _ = parameterRegistry.AdvertiseParameter(exp);
        }
    }
}