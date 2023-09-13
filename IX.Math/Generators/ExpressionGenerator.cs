using IX.Library.Globalization;

using System.Text.RegularExpressions;
using IX.Math.Computation;
using IX.Math.Computation.InitialExpressionParsers;
using IX.Math.ExpressionState;
using IX.Math.Extensibility;
using IX.Math.Extraction;
using IX.Math.Nodes;
using IX.Math.Nodes.Operations.Binary;
using IX.Math.Nodes.Operations.Unary;
using IX.Math.Registration;

using System.Diagnostics.CodeAnalysis;

namespace IX.Math.Generators;

internal static class ExpressionGenerator
{
    [SuppressMessage(
        "Performance",
        "HAA0401:Possible allocation of reference type enumerator",
        Justification = "Not avoidable for now.")]
    internal static ComputationBody CreateBody(WorkingExpressionSet workingSet)
    {
        if (workingSet.CancellationToken.IsCancellationRequested)
        {
            return ComputationBody.Empty;
        }

        foreach (Type extractorType in workingSet.Extractors.KeysByLevel.OrderBy(p => p.Key)
                     .SelectMany(p => p.Value).ToArray())
        {
            workingSet.Expression = workingSet.Extractors[extractorType].ExtractAllConstants(
                workingSet.Expression,
                workingSet.ConstantsTable,
                workingSet.ReverseConstantsTable,
                workingSet.Definition);

            if (workingSet.CancellationToken.IsCancellationRequested)
            {
                return ComputationBody.Empty;
            }
        }

        workingSet.Expression = workingSet.Expression.Trim().Replace(
            " ",
            string.Empty);

        // Start preparing expression
        workingSet.SymbolTable.Add(
            string.Empty,
            ExpressionSymbol.GenerateSymbol(
                string.Empty,
                workingSet.Expression));

        // Prepares expression and takes care of operators to ensure that they are all OK and usable
        workingSet.Initialize();

        workingSet.SymbolTable[string.Empty].Expression = workingSet.Expression;

        if (workingSet.CancellationToken.IsCancellationRequested)
        {
            return ComputationBody.Empty;
        }

        var expressionToBreak = workingSet.SymbolTable[string.Empty].Expression;

        if (expressionToBreak is null)
        {
            // Fast exit condition: our initial expression had a processing problem
            return ComputationBody.Empty;
        }

        // Break expression based on function calls
        FunctionsExtractor.ReplaceFunctions(
            workingSet.Definition.Parentheses.Left,
            workingSet.Definition.Parentheses.Right,
            workingSet.Definition.ParameterSeparator,
            workingSet.ConstantsTable,
            workingSet.ReverseConstantsTable,
            workingSet.SymbolTable,
            workingSet.ReverseSymbolTable,
            workingSet.Interpreters,
            workingSet.ParameterRegistry,
            expressionToBreak,
            workingSet.AllSymbols);

        if (workingSet.CancellationToken.IsCancellationRequested)
        {
            return ComputationBody.Empty;
        }

        // We save a split expression for determining parameter order
        var splitExpression = workingSet.Expression.Split(
            workingSet.AllSymbols.ToArray(),
            StringSplitOptions.RemoveEmptyEntries);

        // Break by parentheses
        ParenthesesParser.FormatParentheses(
            workingSet.Definition.Parentheses.Left,
            workingSet.Definition.Parentheses.Right,
            workingSet.Definition.ParameterSeparator,
            workingSet.AllOperatorsInOrder,
            workingSet.SymbolTable,
            workingSet.ReverseSymbolTable);

        if (workingSet.CancellationToken.IsCancellationRequested)
        {
            return ComputationBody.Empty;
        }

        // Populating symbol tables
        foreach (var p in workingSet.SymbolTable.Where(p => !p.Value.IsFunctionCall)
                     .Select(p => p.Value.Expression))
        {
            if (p is null)
            {
                // Fast exit condition: we have a symbol that is null
                return ComputationBody.Empty;
            }

            TablePopulationGenerator.PopulateTables(
                p,
                workingSet.ConstantsTable,
                workingSet.ReverseConstantsTable,
                workingSet.SymbolTable,
                workingSet.ReverseSymbolTable,
                workingSet.ParameterRegistry,
                workingSet.Interpreters,
                workingSet.Expression,
                workingSet.Definition.Parentheses.Left,
                workingSet.AllSymbols);
        }

        // For each parameter from the table we've just populated, see where it's first used, and fill in that index as the order
        foreach (ParameterContext paramForOrdering in workingSet.ParameterRegistry.Dump())
        {
            paramForOrdering.Order = Array.IndexOf(
                splitExpression,
                paramForOrdering.Name);
        }

        if (workingSet.CancellationToken.IsCancellationRequested)
        {
            return ComputationBody.Empty;
        }

        // Generate expressions
        NodeBase? body;
        try
        {
            body = GenerateExpression(
                workingSet.SymbolTable[string.Empty].Expression,
                workingSet);
        }
        catch
        {
            body = null;
        }

        if (body == null)
        {
            // Fast exit condition: we have a symbol that is null
            return ComputationBody.Empty;
        }

        if (body is ConstantNodeBase && workingSet.ParameterRegistry.Populated)
        {
            return ComputationBody.Empty;
        }

        workingSet.Success = true;

        return new(
            body,
            workingSet.ParameterRegistry);
    }

    [SuppressMessage(
        "CodeSmell",
        "ERP022:Unobserved exception in generic exception handler",
        Justification = "We want that.")]
    private static NodeBase? GenerateExpression(
        string? expression,
        WorkingExpressionSet workingSet)
    {
        if (expression == null)
        {
            // Expression could most likely not be computed
            return null;
        }

        if (workingSet.CancellationToken.IsCancellationRequested)
        {
            // Cancellation requested, let's exit gracefully
            return null;
        }

        // Expression might be an already-defined constant
        if (workingSet.ConstantsTable.TryGetValue(
                expression,
                out var c1))
        {
            return c1;
        }

        if (workingSet.ReverseConstantsTable.TryGetValue(
                expression,
                out var c2))
        {
            if (workingSet.ConstantsTable.TryGetValue(
                    c2,
                    out var c3))
            {
                return c3;
            }
        }

        // Check whether expression is an external parameter
        if (workingSet.ParameterRegistry.Exists(expression))
        {
            return new ParameterNode(
                expression,
                workingSet.ParameterRegistry);
        }

        // Check whether the expression already exists in the symbols table
        if (workingSet.SymbolTable.TryGetValue(
                expression,
                out var e1))
        {
            return GenerateExpression(
                e1.Expression,
                workingSet);
        }

        if (workingSet.ReverseSymbolTable.TryGetValue(
                expression,
                out var e2))
        {
            if (workingSet.SymbolTable.TryGetValue(
                    e2,
                    out var e3))
            {
                if (e3.Expression != expression)
                {
                    return GenerateExpression(
                        e3.Expression,
                        workingSet);
                }
            }
        }

        // Check whether the expression is a function call
        if (expression.InvariantCultureContains(workingSet.Definition.Parentheses.Left) &&
            expression.InvariantCultureContains(workingSet.Definition.Parentheses.Right))
        {
            return GenerateFunctionCallExpression(
                expression,
                workingSet);
        }

        // Check whether the expression is a binary operator
        foreach (var (_, operatorPosition, @operator) in OperatorSequenceGenerator
                     .GetOperatorsInOrderInExpression(
                         expression,
                         workingSet.BinaryOperators.KeysByLevel).OrderBy(p => p.Item1).ThenByDescending(p => p.Item2).ToArray())
        {
            NodeBase? exp = ExpressionByBinaryOperator(
                workingSet,
                expression,
                operatorPosition,
                @operator);

            static NodeBase? ExpressionByBinaryOperator(
                WorkingExpressionSet innerWorkingSet,
                string s,
                int position,
                string op)
            {
                if (position == 0)
                {
                    // We certainly have an unary operator if the operator is at the beginning of the expression. We therefore cannot continue with binary
                    return null;
                }

                if (innerWorkingSet.CancellationToken.IsCancellationRequested)
                {
                    // Cancellation requested, let's exit gracefully
                    return null;
                }

                if (!innerWorkingSet.BinaryOperators.TryGetValue(
                        op,
                        out Func<MathDefinition, NodeBase, NodeBase, BinaryOperatorNodeBase> t))
                {
                    // Binary operator not actually found.
                    return null;
                }

                // We have a normal, regular binary
                var eee = s[..position];
                if (string.IsNullOrWhiteSpace(eee))
                {
                    // Empty space before operator. Normally, this should never be hit.
                    return null;
                }

                NodeBase? left = GenerateExpression(
                    eee,
                    innerWorkingSet);
                if (left == null)
                {
                    // Left expression is invalid.
                    return null;
                }

                eee = s[(position + op.Length)..];
                if (string.IsNullOrWhiteSpace(eee))
                {
                    // Empty space after operator. Normally, this should never be hit.
                    return null;
                }

                NodeBase? right = GenerateExpression(
                    eee,
                    innerWorkingSet);
                if (right == null)
                {
                    // Right expression is invalid.
                    return null;
                }

                var resultingNode = t(
                    innerWorkingSet.Definition,
                    left,
                    right);
#pragma warning disable HAA0603 // Delegate allocation from a method group - Unavoidable
                ((ISpecialRequestNode)resultingNode).SetRequestSpecialObjectFunction(innerWorkingSet.OfferReservedType);
#pragma warning restore HAA0603 // Delegate allocation from a method group
                return resultingNode.Simplify();
            }

            if (exp != null)
            {
                // We have found a valid binary operator expression
                return exp;
            }
        }

        // Check whether the expression is a unary operator
        foreach (Tuple<int, int, string> operatorPosition in OperatorSequenceGenerator
                     .GetOperatorsInOrderInExpression(
                         expression,
                         workingSet.UnaryOperators.KeysByLevel).OrderBy(p => p.Item1).ThenByDescending(p => p.Item2).ToArray())
        {
            NodeBase? exp = ExpressionByUnaryOperator(
                workingSet,
                expression,
                operatorPosition.Item3);

            static NodeBase? ExpressionByUnaryOperator(
                WorkingExpressionSet innerWorkingSet,
                string s,
                string op)
            {
                if (innerWorkingSet.CancellationToken.IsCancellationRequested)
                {
                    // Cancellation requested, let's stop
                    return null;
                }

                if (!s.CurrentCultureStartsWith(op) || !innerWorkingSet.UnaryOperators.TryGetValue(
                        op,
                        out Func<MathDefinition, NodeBase, UnaryOperatorNodeBase> t))
                {
                    // The unary operator is not valid.
                    return null;
                }

                var eee = s[op.Length..];
                if (string.IsNullOrWhiteSpace(eee))
                {
                    // We might have a valid unary operator but attached to nothing - the expression cannot be evaluated any further on this branch
                    return null;
                }

                // We have a valid unary operator and the expression starts with it.
                NodeBase? expr = GenerateExpression(
                    eee,
                    innerWorkingSet);
                if (expr == null)
                {
                    // The operand expression was not valid, or cancellation was requested.
                    return null;
                }

                var resultingNode = t(
                    innerWorkingSet.Definition,
                    expr);
#pragma warning disable HAA0603 // Delegate allocation from a method group - Unavoidable
                ((ISpecialRequestNode)resultingNode).SetRequestSpecialObjectFunction(innerWorkingSet.OfferReservedType);
#pragma warning restore HAA0603 // Delegate allocation from a method group
                return resultingNode.Simplify();
            }

            if (exp != null)
            {
                // We have found a valid unary operator expression.
                return exp;
            }
        }

        return null;

        [RequiresUnreferencedCode("This method uses Activator.CreateInstance.")]
        static NodeBase? GenerateFunctionCallExpression(
            string possibleFunctionCallExpression,
            WorkingExpressionSet innerWorkingSet)
        {
            if (innerWorkingSet.CancellationToken.IsCancellationRequested)
            {
                // Cancellation requested, let's exit gracefully
                return null;
            }

            Match match = innerWorkingSet.FunctionRegex.Match(possibleFunctionCallExpression);

            try
            {
                if (match.Success)
                {
                    var functionName = match.Groups["functionName"].Value;
                    var expressionValue = match.Groups["expression"].Value;

                    var parameterExpressions = string.IsNullOrWhiteSpace(expressionValue)
                        ? Array.Empty<string>()
                        : match.Groups["expression"].Value
                               .Split(
                                   new[] { innerWorkingSet.Definition.ParameterSeparator },
                                   StringSplitOptions.None).Select(p => string.IsNullOrWhiteSpace(p) ? null : p)
                               .ToArray();

                    NodeBase? returnValue = parameterExpressions.Length switch
                    {
                        0 => innerWorkingSet.NonaryFunctions.TryGetValue(
                            functionName,
                            out Type? t)
                            ? (Activator.CreateInstance(t) as NonaryFunctionNodeBase)?.Simplify()
                            : null,
                        1 => innerWorkingSet.UnaryFunctions.TryGetValue(
                            functionName,
                            out Type? t1)
                            ? (Activator.CreateInstance(
                                t1,
                                GenerateExpression(
                                    parameterExpressions[0],
                                    innerWorkingSet)) as UnaryFunctionNodeBase)?.Simplify()
                            : null,
                        2 => innerWorkingSet.BinaryFunctions.TryGetValue(
                            functionName,
                            out Type? t2)
                            ? (Activator.CreateInstance(
                                t2,
                                GenerateExpression(
                                    parameterExpressions[0],
                                    innerWorkingSet), GenerateExpression(
                                    parameterExpressions[1],
                                    innerWorkingSet)) as BinaryFunctionNodeBase)?.Simplify()
                            : null,
                        3 => innerWorkingSet.TernaryFunctions.TryGetValue(
                            functionName,
                            out Type? t3)
                            ? (Activator.CreateInstance(
                                t3,
                                GenerateExpression(
                                    parameterExpressions[0],
                                    innerWorkingSet), GenerateExpression(
                                    parameterExpressions[1],
                                    innerWorkingSet), GenerateExpression(
                                    parameterExpressions[2],
                                    innerWorkingSet)) as TernaryFunctionNodeBase)?.Simplify()
                            : null,
                        _ => null
                    };

                    if (returnValue is ISpecialRequestNode srn)
                    {
#pragma warning disable HAA0603 // Delegate allocation from a method group - Unavoidable
                        srn.SetRequestSpecialObjectFunction(innerWorkingSet.OfferReservedType);
#pragma warning restore HAA0603 // Delegate allocation from a method group
                    }

                    return returnValue;
                }
            }
            catch (Exception)
            {
                return null;
            }

            return null;
        }
    }
}