using IX.Core.Collections;
using IX.Core.Globalization;

using System.Globalization;
using IX.Math.ExpressionState;
using IX.Math.Extensibility;
using IX.Math.Generators;
using IX.Math.Nodes;
using IX.Math.Registration;

namespace IX.Math.Extraction;

/// <summary>
///     A class to handle function extraction.
/// </summary>
internal static class FunctionsExtractor
{
    /// <summary>
    ///     Replaces functions calls with expression placeholders.
    /// </summary>
    /// <param name="openParenthesis">The symbol of an open parenthesis.</param>
    /// <param name="closeParenthesis">The symbol of a closed parenthesis.</param>
    /// <param name="parameterSeparator">The symbol of a parameter separator.</param>
    /// <param name="constantsTable">The constants table.</param>
    /// <param name="reverseConstantsTable">The reverse-lookup constants table.</param>
    /// <param name="symbolTable">The symbols table.</param>
    /// <param name="reverseSymbolTable">The reverse-lookup symbols table.</param>
    /// <param name="interpreters">The constant interpreters.</param>
    /// <param name="parametersTable">The parameters table.</param>
    /// <param name="expression">The expression before processing.</param>
    /// <param name="allSymbols">All symbols.</param>
    internal static void ReplaceFunctions(
        string openParenthesis,
        string closeParenthesis,
        string parameterSeparator,
        Dictionary<string, ConstantNodeBase> constantsTable,
        Dictionary<string, string> reverseConstantsTable,
        Dictionary<string, ExpressionSymbol> symbolTable,
        Dictionary<string, string> reverseSymbolTable,
        LevelDictionary<Type, IConstantInterpreter> interpreters,
        IParameterRegistry parametersTable,
        string expression,
        string[] allSymbols)
    {
        // Replace the main expression
        ReplaceOneFunction(
            string.Empty,
            openParenthesis,
            closeParenthesis,
            parameterSeparator,
            constantsTable,
            reverseConstantsTable,
            symbolTable,
            reverseSymbolTable,
            interpreters,
            parametersTable,
            expression,
            allSymbols);

        for (var i = 1; i < symbolTable.Count; i++)
        {
            // Replace sub-expressions
            ReplaceOneFunction(
                $"item{i.ToString(CultureInfo.InvariantCulture).PadLeft(4, '0')}",
                openParenthesis,
                closeParenthesis,
                parameterSeparator,
                constantsTable,
                reverseConstantsTable,
                symbolTable,
                reverseSymbolTable,
                interpreters,
                parametersTable,
                expression,
                allSymbols);
        }

        static void ReplaceOneFunction(
            string key,
            string outerOpenParenthesisSymbol,
            string outerCloseParenthesisSymbol,
            string outerParameterSeparatorSymbol,
            Dictionary<string, ConstantNodeBase> outerConstantsTableReference,
            Dictionary<string, string> outerReverseConstantsTableReference,
            Dictionary<string, ExpressionSymbol> outerSymbolTableReference,
            Dictionary<string, string> outerReverseSymbolTableReference,
            LevelDictionary<Type, IConstantInterpreter> interpreters,
            IParameterRegistry outerParametersTableReference,
            string outerExpressionSymbol,
            string[] outerAllSymbolsSymbols)
        {
            ExpressionSymbol symbol = outerSymbolTableReference[key];
            if (symbol.IsFunctionCall)
            {
                return;
            }

            var replaced = symbol.Expression;
            while (replaced != null)
            {
                outerSymbolTableReference[key].Expression = replaced;
                replaced = ReplaceFunctionsLocal(
                    replaced,
                    outerOpenParenthesisSymbol,
                    outerCloseParenthesisSymbol,
                    outerParameterSeparatorSymbol,
                    outerConstantsTableReference,
                    outerReverseConstantsTableReference,
                    outerSymbolTableReference,
                    outerReverseSymbolTableReference,
                    interpreters,
                    outerParametersTableReference,
                    outerExpressionSymbol,
                    outerAllSymbolsSymbols);
            }

            static string? ReplaceFunctionsLocal(
                string source,
                string openParenthesisSymbol,
                string closeParenthesisSymbol,
                string parameterSeparatorSymbol,
                Dictionary<string, ConstantNodeBase> constantsTableReference,
                Dictionary<string, string> reverseConstantsTableReference,
                Dictionary<string, ExpressionSymbol> symbolTableReference,
                Dictionary<string, string> reverseSymbolTableReference,
                LevelDictionary<Type, IConstantInterpreter> interpretersReference,
                IParameterRegistry parametersTableReference,
                string expressionSymbol,
                string[] allSymbolsSymbols)
            {
                var op = -1;
                var opl = openParenthesisSymbol.Length;
                var cpl = closeParenthesisSymbol.Length;

                while (true)
                {
                    op = source.InvariantCultureIndexOf(
                        openParenthesisSymbol,
                        op + opl);

                    if (op == -1)
                    {
                        return null;
                    }

                    if (op == 0)
                    {
                        continue;
                    }

                    var functionHeaderCheck = source.Substring(
                        0,
                        op);

                    if (allSymbolsSymbols.Any(
                            (
                                p,
                                check) => check.InvariantCultureEndsWith(p),
                            functionHeaderCheck))
                    {
                        continue;
                    }

                    var functionHeader = functionHeaderCheck.Split(
                        allSymbolsSymbols,
                        StringSplitOptions.None).Last();

                    var oop = source.InvariantCultureIndexOf(
                        openParenthesisSymbol,
                        op + opl);
                    var cp = source.InvariantCultureIndexOf(
                        closeParenthesisSymbol,
                        op + cpl);

                    while (oop < cp && oop != -1 && cp != -1)
                    {
                        oop = source.InvariantCultureIndexOf(
                            openParenthesisSymbol,
                            oop + opl);
                        cp = source.InvariantCultureIndexOf(
                            closeParenthesisSymbol,
                            cp + cpl);
                    }

                    if (cp == -1)
                    {
                        continue;
                    }

                    var arguments = source.Substring(
                        op + opl,
                        cp - op - opl);
                    var originalArguments = arguments;

                    var q = arguments;
                    while (q != null)
                    {
                        arguments = q;
                        q = ReplaceFunctionsLocal(
                            q,
                            openParenthesisSymbol,
                            closeParenthesisSymbol,
                            parameterSeparatorSymbol,
                            constantsTableReference,
                            reverseConstantsTableReference,
                            symbolTableReference,
                            reverseSymbolTableReference,
                            interpretersReference,
                            parametersTableReference,
                            expressionSymbol,
                            allSymbolsSymbols);
                    }

                    var argPlaceholders = new List<string>();
                    foreach (var s in arguments.Split(
                                 new[] { parameterSeparatorSymbol },
                                 StringSplitOptions.RemoveEmptyEntries))
                    {
                        TablePopulationGenerator.PopulateTables(
                            s,
                            constantsTableReference,
                            reverseConstantsTableReference,
                            symbolTableReference,
                            reverseSymbolTableReference,
                            parametersTableReference,
                            interpretersReference,
                            expressionSymbol,
                            openParenthesisSymbol,
                            allSymbolsSymbols);

                        // We check whether or not this is actually a constant
                        argPlaceholders.Add(
                            ConstantsGenerator.CheckAndAdd(
                                constantsTableReference,
                                reverseConstantsTableReference,
                                interpretersReference,
                                expressionSymbol,
                                s) ?? (!parametersTableReference.Exists(s)
                                ? SymbolExpressionGenerator.GenerateSymbolExpression(
                                    symbolTableReference,
                                    reverseSymbolTableReference,
                                    s,
                                    false)
                                : s));
                    }

                    var functionCallBody =
                        $"{functionHeader}{openParenthesisSymbol}{string.Join(parameterSeparatorSymbol, argPlaceholders)}{closeParenthesisSymbol}";
                    var functionCallToReplace =
                        $"{functionHeader}{openParenthesisSymbol}{originalArguments}{closeParenthesisSymbol}";
                    var functionCallItem = SymbolExpressionGenerator.GenerateSymbolExpression(
                        symbolTableReference,
                        reverseSymbolTableReference,
                        functionCallBody,
                        true);

                    return source.Replace(
                        functionCallToReplace,
                        functionCallItem);
                }
            }
        }
    }
}