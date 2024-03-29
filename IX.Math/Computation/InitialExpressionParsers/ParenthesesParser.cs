using IX.Library.Globalization;

using System.Globalization;
using IX.Math.ExpressionState;
using IX.Math.Generators;

namespace IX.Math.Computation.InitialExpressionParsers;

internal static class ParenthesesParser
{
    internal static void FormatParentheses(
        string openParenthesis,
        string closeParenthesis,
        string parameterSeparator,
        string[] allOperatorsInOrder,
        Dictionary<string, ExpressionSymbol> symbolTable,
        Dictionary<string, string> reverseSymbolTable)
    {
        var itemsToProcess = new List<string>();

        KeyValuePair<string, ExpressionSymbol> itemToProcess;

        // Select the first expression that hasn't already been parsed
        while ((itemToProcess = symbolTable.Where(
                   (
                       p,
                       itemsToProcessL1) => !itemsToProcessL1.Contains(p.Key) && !p.Value.IsFunctionCall,
                   itemsToProcess).FirstOrDefault()).Value != null)
        {
            try
            {
                FormatParenthesis(
                    itemToProcess.Key,
                    openParenthesis,
                    closeParenthesis,
                    parameterSeparator,
                    allOperatorsInOrder,
                    symbolTable,
                    reverseSymbolTable);
            }
            finally
            {
                itemsToProcess.Add(itemToProcess.Key);
            }
        }

        void FormatParenthesis(
            string key,
            string openParenthesisL1,
            string closeParenthesisL1,
            string parameterSeparatorL1,
            string[] allOperatorsInOrderL1,
            Dictionary<string, ExpressionSymbol> symbolTableL1,
            Dictionary<string, string> reverseSymbolTableL1)
        {
            ExpressionSymbol symbol = symbolTableL1[key];
            if (symbol.IsFunctionCall)
            {
                return;
            }

            var replacedPreviously = string.Empty;
            var replaced = symbol.Expression;
            while (replaced != replacedPreviously)
            {
                symbolTableL1[key].Expression = replaced;
                replacedPreviously = replaced;
                replaced = ReplaceParenthesis(
                    replaced,
                    openParenthesisL1,
                    closeParenthesisL1,
                    parameterSeparatorL1,
                    allOperatorsInOrderL1,
                    symbolTableL1,
                    reverseSymbolTableL1);
            }

            string ReplaceParenthesis(
                string? source,
                string openParenthesisL2,
                string closeParenthesisL2,
                string parameterSeparatorSymbolL2,
                string[] allOperatorsInOrderSymbolsL2,
                Dictionary<string, ExpressionSymbol> symbolTableL2,
                Dictionary<string, string> reverseSymbolTableL2)
            {
                if (string.IsNullOrWhiteSpace(source))
                {
                    return string.Empty;
                }

                var src = source!;

                var openingParenthesisLocation = src.InvariantCultureIndexOf(
                    openParenthesisL2);
                var closingParenthesisLocation = src.InvariantCultureIndexOf(
                    closeParenthesisL2);

                beginning:
                if (openingParenthesisLocation != -1)
                {
                    if (closingParenthesisLocation == -1)
                    {
                        throw new InvalidOperationException();
                    }

                    if (openingParenthesisLocation < closingParenthesisLocation)
                    {
                        var resultingSubExpression = ReplaceParenthesis(
                            src.Substring(openingParenthesisLocation + openParenthesisL2.Length),
                            openParenthesisL2,
                            closeParenthesisL2,
                            parameterSeparatorSymbolL2,
                            allOperatorsInOrderSymbolsL2,
                            symbolTableL2,
                            reverseSymbolTableL2);

                        if (openingParenthesisLocation == 0)
                        {
                            src = resultingSubExpression;
                        }
                        else
                        {
                            var expr4 = src.Substring(
                                    0,
                                    openingParenthesisLocation);

                            if (!allOperatorsInOrderSymbolsL2.Any(
                                    (
                                        p,
                                        expr4L1) => expr4L1.InvariantCultureEndsWith(p),
                                    expr4))
                            {
                                // We have a function call
#pragma warning disable HAA0603 // Delegate allocation from a method group - Unavoidable
                                var inx = allOperatorsInOrderSymbolsL2.Max(expr4.LastIndexOf);
#pragma warning restore HAA0603 // Delegate allocation from a method group
                                var expr5 = inx == -1 ? expr4 : expr4.Substring(inx);
                                var op1 = allOperatorsInOrderSymbolsL2.OrderByDescending(p => p.Length)
                                    .FirstOrDefault(
                                        (
                                            p,
                                            expr5L1) => expr5L1.InvariantCultureStartsWith(p),
                                        expr5);
                                var expr6 = op1 == null ? expr5 : expr5.Substring(op1.Length);

                                // ReSharper disable once AssignmentIsFullyDiscarded - We're interested only in having the symbol in the table, and nothing more
                                _ = SymbolExpressionGenerator.GenerateSymbolExpression(
                                    symbolTableL2,
                                    reverseSymbolTableL2,
                                    $"{expr6}{openParenthesisL2}item{(symbolTableL2.Count - 1).ToString(CultureInfo.InvariantCulture)}{closeParenthesisL2}",
                                    false);

                                expr4 = expr6 == expr4
                                    ? string.Empty
                                    : expr4.Substring(
                                        0,
                                        expr4.Length - expr6.Length);

                                resultingSubExpression = resultingSubExpression.Replace(
                                    $"item{(symbolTableL2.Count - 1).ToString(CultureInfo.InvariantCulture)}",
                                    $"item{symbolTableL2.Count.ToString(CultureInfo.InvariantCulture)}");
                            }

                            src = $"{expr4}{resultingSubExpression}";
                        }

                        openingParenthesisLocation = src.InvariantCultureIndexOf(
                            openParenthesisL2);
                        closingParenthesisLocation = src.InvariantCultureIndexOf(
                            closeParenthesisL2);

                        goto beginning;
                    }

                    return ProcessSubExpression(
                        closingParenthesisLocation,
                        closeParenthesisL2,
                        src,
                        parameterSeparatorSymbolL2,
                        symbolTableL2,
                        reverseSymbolTableL2);
                }

                if (closingParenthesisLocation == -1)
                {
                    return src;
                }

                return ProcessSubExpression(
                    closingParenthesisLocation,
                    closeParenthesisL2,
                    src,
                    parameterSeparatorSymbolL2,
                    symbolTableL2,
                    reverseSymbolTableL2);

                string ProcessSubExpression(
                    int cp,
                    string closeParenthesisL3,
                    string sourceL3,
                    string parameterSeparatorL3,
                    Dictionary<string, ExpressionSymbol> symbolTableL3,
                    Dictionary<string, string> reverseSymbolTableL3)
                {
                    var expr1 = sourceL3.Substring(
                        0,
                        cp);

                    var parameters = expr1.Split(
                        new[] { parameterSeparatorL3 },
                        StringSplitOptions.None);

                    var parSymbols = new List<string>(parameters.Length);

                    // ReSharper disable once LoopCanBeConvertedToQuery - We are looking for best-performance linearity here
                    foreach (var s in parameters)
                    {
                        parSymbols.Add(
                            SymbolExpressionGenerator.GenerateSymbolExpression(
                                symbolTableL3,
                                reverseSymbolTableL3,
                                s,
                                false));
                    }

                    var k = cp + closeParenthesisL3.Length;
                    return
                        $"{string.Join(parameterSeparatorL3, parSymbols)}{(sourceL3.Length == k ? string.Empty : sourceL3.Substring(k))}";
                }
            }
        }
    }
}