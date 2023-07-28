using IX.Core.Collections;
using IX.Core.ComponentModel;

using System.Text.RegularExpressions;
using IX.Math.ExpressionState;
using IX.Math.Extensibility;
using IX.Math.Generators;
using IX.Math.Nodes;
using IX.Math.Nodes.Operations.Binary;
using IX.Math.Nodes.Operations.Unary;
using IX.Math.Registration;

using System.Diagnostics.CodeAnalysis;

using SubtractNode = IX.Math.Nodes.Operations.Binary.SubtractNode;

namespace IX.Math;

internal class WorkingExpressionSet : DisposableBase
{
    private bool _initialized;

    internal WorkingExpressionSet(
        string expression,
        MathDefinition mathDefinition,
        Dictionary<string, Type> nonaryFunctions,
        Dictionary<string, Type> unaryFunctions,
        Dictionary<string, Type> binaryFunctions,
        Dictionary<string, Type> ternaryFunctions,
        LevelDictionary<Type, IConstantsExtractor> extractors,
        LevelDictionary<Type, IConstantInterpreter> interpreters,
        List<IStringFormatter> stringFormatters,
        CancellationToken cancellationToken)
    {
        ParameterRegistry = new StandardParameterRegistry(stringFormatters);
        ConstantsTable = new();
        ReverseConstantsTable = new();
        SymbolTable = new();
        ReverseSymbolTable = new();
        StringFormatters = stringFormatters;

        CancellationToken = cancellationToken;
        Expression = expression;
        Definition = mathDefinition;

        AllOperatorsInOrder = new[]
        {
            mathDefinition.GreaterThanOrEqualSymbol,
            mathDefinition.LessThanOrEqualSymbol,
            mathDefinition.GreaterThanSymbol,
            mathDefinition.LessThanSymbol,
            mathDefinition.NotEqualsSymbol,
            mathDefinition.EqualsSymbol,
            mathDefinition.XorSymbol,
            mathDefinition.OrSymbol,
            mathDefinition.AndSymbol,
            mathDefinition.AddSymbol,
            mathDefinition.SubtractSymbol,
            mathDefinition.DivideSymbol,
            mathDefinition.MultiplySymbol,
            mathDefinition.PowerSymbol,
            mathDefinition.LeftShiftSymbol,
            mathDefinition.RightShiftSymbol,
            mathDefinition.NotSymbol
        };

        NonaryFunctions = nonaryFunctions;
        UnaryFunctions = unaryFunctions;
        BinaryFunctions = binaryFunctions;
        TernaryFunctions = ternaryFunctions;

        Extractors = extractors;
        Interpreters = interpreters;

        FunctionRegex = new(
            $@"(?'functionName'.*?){Regex.Escape(mathDefinition.Parentheses.Left)}(?'expression'.*?){Regex.Escape(mathDefinition.Parentheses.Right)}");
    }

    /// <summary>
    ///     Gets all operators in order.
    /// </summary>
    /// <value>
    ///     All operators in order.
    /// </value>
    internal string[] AllOperatorsInOrder { get; }

    /// <summary>
    ///     Gets the binary functions.
    /// </summary>
    /// <value>
    ///     The binary functions.
    /// </value>
    internal Dictionary<string, Type> BinaryFunctions { get; }

    /// <summary>
    ///     Gets the cancellation token.
    /// </summary>
    /// <value>
    ///     The cancellation token.
    /// </value>
    internal CancellationToken CancellationToken { get; }

    /// <summary>
    ///     Gets the definition.
    /// </summary>
    /// <value>
    ///     The definition.
    /// </value>
    internal MathDefinition Definition { get; }

    /// <summary>
    ///     Gets the constant extractors.
    /// </summary>
    /// <value>
    ///     The constant extractors.
    /// </value>
    internal LevelDictionary<Type, IConstantsExtractor> Extractors { get; }

    /// <summary>
    ///     Gets the function regex.
    /// </summary>
    /// <value>
    ///     The function regex.
    /// </value>
    internal Regex FunctionRegex { get; }

    /// <summary>
    ///     Gets the constant interpreters.
    /// </summary>
    /// <value>
    ///     The constant interpreters.
    /// </value>
    internal LevelDictionary<Type, IConstantInterpreter> Interpreters { get; }

    /// <summary>
    ///     Gets the nonary functions.
    /// </summary>
    /// <value>
    ///     The nonary functions.
    /// </value>
    internal Dictionary<string, Type> NonaryFunctions { get; }

    /// <summary>
    ///     Gets the parameter registry.
    /// </summary>
    /// <value>
    ///     The parameter registry.
    /// </value>
    internal IParameterRegistry ParameterRegistry { get; }

    /// <summary>
    ///     Gets the string formatters.
    /// </summary>
    /// <value>
    ///     The string formatters.
    /// </value>
    internal List<IStringFormatter> StringFormatters { get; }

    /// <summary>
    ///     Gets the ternary functions.
    /// </summary>
    /// <value>
    ///     The ternary functions.
    /// </value>
    internal Dictionary<string, Type> TernaryFunctions { get; }

    /// <summary>
    ///     Gets the unary functions.
    /// </summary>
    /// <value>
    ///     The unary functions.
    /// </value>
    internal Dictionary<string, Type> UnaryFunctions { get; }

    /// <summary>
    ///     Gets all symbols.
    /// </summary>
    /// <value>
    ///     All symbols.
    /// </value>
    internal string[] AllSymbols { get; private set; }

    /// <summary>
    ///     Gets the binary operators.
    /// </summary>
    /// <value>
    ///     The binary operators.
    /// </value>
    [field: SuppressMessage(
        "IDisposableAnalyzers.Correctness",
        "IDISP006:Implement IDisposable.",
        Justification = "This is correct, but the analyzer can't tell.")]
    internal LevelDictionary<string, Func<MathDefinition, NodeBase, NodeBase, BinaryOperatorNodeBase>> BinaryOperators
    {
        get;
        private set;
    }

    /// <summary>
    ///     Gets the constants table.
    /// </summary>
    /// <value>
    ///     The constants table.
    /// </value>
    internal Dictionary<string, ConstantNodeBase> ConstantsTable { get; private init; }

    /// <summary>
    ///     Gets or sets the expression.
    /// </summary>
    /// <value>
    ///     The expression.
    /// </value>
    internal string Expression { get; set; }

    /// <summary>
    ///     Gets the reverse constants table.
    /// </summary>
    /// <value>
    ///     The reverse constants table.
    /// </value>
    internal Dictionary<string, string> ReverseConstantsTable { get; private init; }

    /// <summary>
    ///     Gets the reverse symbol table.
    /// </summary>
    /// <value>
    ///     The reverse symbol table.
    /// </value>
    internal Dictionary<string, string> ReverseSymbolTable { get; private init; }

    /// <summary>
    ///     Gets or sets a value indicating whether this <see cref="WorkingExpressionSet" /> is success.
    /// </summary>
    /// <value>
    ///     <c>true</c> if success; otherwise, <c>false</c>.
    /// </value>
    internal bool Success { get; set; }

    /// <summary>
    ///     Gets the symbol table.
    /// </summary>
    /// <value>
    ///     The symbol table.
    /// </value>
    internal Dictionary<string, ExpressionSymbol> SymbolTable { get; private init; }

    /// <summary>
    ///     Gets the unary operators.
    /// </summary>
    /// <value>
    ///     The unary operators.
    /// </value>
    [SuppressMessage(
        "IDisposableAnalyzers.Correctness",
        "IDISP002:Dispose member.",
        Justification = "This is correct, but the analyzer can't tell.")]
    [SuppressMessage(
        "IDisposableAnalyzers.Correctness",
        "IDISP006:Implement IDisposable.",
        Justification = "This is correct, but the analyzer can't tell.")]
    [field: SuppressMessage(
        "IDisposableAnalyzers.Correctness",
        "IDISP006:Implement IDisposable.",
        Justification = "This is correct, but the analyzer can't tell.")]
    internal LevelDictionary<string, Func<MathDefinition, NodeBase, UnaryOperatorNodeBase>> UnaryOperators
    {
        get;
        private set;
    }

    /// <summary>
    ///     Offers a reserved object type.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <returns>An instance of a reserved type, if one exists.</returns>
    /// <exception cref="NotSupportedException">The type requested is not supported.</exception>
    internal object OfferReservedType(Type type)
    {
        if (type == typeof(WorkingExpressionSet))
        {
            return this;
        }

        if (type == typeof(IStringFormatter))
        {
            return StringFormatters;
        }

        throw new NotSupportedException();
    }

    /// <summary>
    ///     Initializes this instance. This method should be called after initialization and extraction of major constants.
    /// </summary>
    [SuppressMessage(
        "Performance",
        "HAA0401:Possible allocation of reference type enumerator",
        Justification = "Too much LINQ.")]
    [SuppressMessage(
        "IDisposableAnalyzers.Correctness",
        "IDISP003:Dispose previous before re-assigning.",
        Justification = "It is, but the analyzer cannot tell.")]
    [SuppressMessage(
        "Performance",
        "HAA0603:Delegate allocation from a method group",
        Justification = "We actively want this to keep a reference to this working set.")]
    [SuppressMessage(
        "Performance",
        "HAA0301:Closure Allocation Source",
        Justification = "We actively want this to keep a reference to this working set.")]
    [SuppressMessage(
        "Performance",
        "HAA0302:Display class allocation to capture closure",
        Justification = "We actively want this to keep a reference to this working set.")]
    internal void Initialize()
    {
        if (_initialized)
        {
            return;
        }

        _initialized = true;

        var i = 1;
        var allOperatorsInOrder = AllOperatorsInOrder;
        MathDefinition definition = Definition;

        foreach (var op in allOperatorsInOrder.OrderByDescending(p => p.Length)
                     .Where(
                         (
                             p,
                             allOperatorsInOrderL1) => allOperatorsInOrderL1.Any(
                             (
                                 q,
                                 pL2) => q.Length < pL2.Length && pL2.Contains(q),
                             p),
                         allOperatorsInOrder)
                     .OrderByDescending(p => p.Length))
        {
            var s = $"@op{i}@";

            Expression = Expression.Replace(
                op,
                s);

            var allIndex = Array.IndexOf(
                allOperatorsInOrder,
                op);
            if (allIndex != -1)
            {
                allOperatorsInOrder[allIndex] = s;
            }

            if (definition.AddSymbol == op)
            {
                definition.AddSymbol = s;
            }

            if (definition.AndSymbol == op)
            {
                definition.AndSymbol = s;
            }

            if (definition.DivideSymbol == op)
            {
                definition.DivideSymbol = s;
            }

            if (definition.NotEqualsSymbol == op)
            {
                definition.NotEqualsSymbol = s;
            }

            if (definition.EqualsSymbol == op)
            {
                definition.EqualsSymbol = s;
            }

            if (definition.GreaterThanOrEqualSymbol == op)
            {
                definition.GreaterThanOrEqualSymbol = s;
            }

            if (definition.GreaterThanSymbol == op)
            {
                definition.GreaterThanSymbol = s;
            }

            if (definition.LessThanOrEqualSymbol == op)
            {
                definition.LessThanOrEqualSymbol = s;
            }

            if (definition.LessThanSymbol == op)
            {
                definition.LessThanSymbol = s;
            }

            if (definition.MultiplySymbol == op)
            {
                definition.MultiplySymbol = s;
            }

            if (definition.NotSymbol == op)
            {
                definition.NotSymbol = s;
            }

            if (definition.OrSymbol == op)
            {
                definition.OrSymbol = s;
            }

            if (definition.PowerSymbol == op)
            {
                definition.PowerSymbol = s;
            }

            if (definition.LeftShiftSymbol == op)
            {
                definition.LeftShiftSymbol = s;
            }

            if (definition.RightShiftSymbol == op)
            {
                definition.RightShiftSymbol = s;
            }

            if (definition.SubtractSymbol == op)
            {
                definition.SubtractSymbol = s;
            }

            if (definition.XorSymbol == op)
            {
                definition.XorSymbol = s;
            }

            i++;
        }

        // Operator string interpretation support
        // ======================================

        // Binary operators
        BinaryOperators =
            new()
            {
                // First tier - Comparison and equation operators
                {
                    definition.GreaterThanOrEqualSymbol, (
                        _,
                        leftOperand,
                        rightOperand) => new GreaterThanOrEqualNode(
                        leftOperand,
                        rightOperand),
                    10
                },
                {
                    definition.LessThanOrEqualSymbol, (
                        _,
                        leftOperand,
                        rightOperand) => new LessThanOrEqualNode(
                        leftOperand,
                        rightOperand),
                    10
                },
                {
                    definition.GreaterThanSymbol, (
                        _,
                        leftOperand,
                        rightOperand) => new GreaterThanNode(
                        leftOperand,
                        rightOperand),
                    10
                },
                {
                    definition.LessThanSymbol, (
                        _,
                        leftOperand,
                        rightOperand) => new LessThanNode(
                        leftOperand,
                        rightOperand),
                    10
                },
                {
                    definition.NotEqualsSymbol, (
                        _,
                        leftOperand,
                        rightOperand) => new NotEqualsNode(
                        leftOperand,
                        rightOperand),
                    10
                },
                {
                    definition.EqualsSymbol, (
                        _,
                        leftOperand,
                        rightOperand) => new EqualsNode(
                        leftOperand,
                        rightOperand),
                    10
                },

                // Second tier - Logical operators
                {
                    definition.OrSymbol, (
                        _,
                        leftOperand,
                        rightOperand) => new OrNode(
                        leftOperand,
                        rightOperand),
                    20
                },
                {
                    definition.XorSymbol, (
                        _,
                        leftOperand,
                        rightOperand) => new XorNode(
                        leftOperand,
                        rightOperand),
                    definition.OperatorPrecedenceStyle == OperatorPrecedenceStyle.CStyle ? 21 : 20
                },
                {
                    definition.AndSymbol, (
                        _,
                        leftOperand,
                        rightOperand) => new AndNode(
                        leftOperand,
                        rightOperand),
                    definition.OperatorPrecedenceStyle == OperatorPrecedenceStyle.CStyle ? 22 : 20
                },

                // Third tier - Arithmetic second-rank operators
                {
                    definition.AddSymbol, (
                        _,
                        leftOperand,
                        rightOperand) => new AddNode(
                        leftOperand,
                        rightOperand),
                    30
                },
                {
                    definition.SubtractSymbol, (
                        _,
                        leftOperand,
                        rightOperand) => new SubtractNode(
                        leftOperand,
                        rightOperand),
                    30
                },

                // Fourth tier - Arithmetic first-rank operators
                {
                    definition.DivideSymbol, (
                        _,
                        leftOperand,
                        rightOperand) => new DivideNode(
                        leftOperand,
                        rightOperand),
                    40
                },
                {
                    definition.MultiplySymbol, (
                        _,
                        leftOperand,
                        rightOperand) => new MultiplyNode(
                        leftOperand,
                        rightOperand),
                    40
                },

                // Fifth tier - Power operator
                {
                    definition.PowerSymbol, (
                        _,
                        leftOperand,
                        rightOperand) => new PowerNode(
                        leftOperand,
                        rightOperand),
                    50
                },

                // Sixth tier - Bitwise shift operators
                {
                    definition.LeftShiftSymbol, (
                        _,
                        leftOperand,
                        rightOperand) => new LeftShiftNode(
                        leftOperand,
                        rightOperand),
                    60
                },
                {
                    definition.RightShiftSymbol, (
                        _,
                        leftOperand,
                        rightOperand) => new RightShiftNode(
                        leftOperand,
                        rightOperand),
                    60
                }
            };

        // Unary operators
        UnaryOperators = new()
        {
            // First tier - Negation and inversion
            {
                definition.SubtractSymbol, (
                    _,
                    operand) => new Nodes.Operations.Unary.SubtractNode(operand),
                1
            },
            {
                definition.NotSymbol, (
                    _,
                    operand) => new NotNode(operand),
                1
            }
        };

        // All symbols
        AllSymbols = allOperatorsInOrder.Union(
                new[]
                {
                    definition.ParameterSeparator,
                    definition.Parentheses.Left,
                    definition.Parentheses.Right
                })
            .ToArray();

        // Special symbols

        // Euler-Napier constant (e)
        ConstantsGenerator.GenerateNamedNumericSymbol(
            ConstantsTable,
            ReverseConstantsTable,
            "e",
            global::System.Math.E);

        // Archimedes-Ludolph constant (pi)
        ConstantsGenerator.GenerateNamedNumericSymbol(
            ConstantsTable,
            ReverseConstantsTable,
            "π",
            global::System.Math.PI,
            $"{definition.SpecialSymbolIndicators.Begin}pi{definition.SpecialSymbolIndicators.End}");

        // Golden ratio
        ConstantsGenerator.GenerateNamedNumericSymbol(
            ConstantsTable,
            ReverseConstantsTable,
            "φ",
            1.6180339887498948,
            $"{definition.SpecialSymbolIndicators.Begin}phi{definition.SpecialSymbolIndicators.End}");

        // Bernstein constant
        ConstantsGenerator.GenerateNamedNumericSymbol(
            ConstantsTable,
            ReverseConstantsTable,
            "β",
            0.2801694990238691,
            $"{definition.SpecialSymbolIndicators.Begin}beta{definition.SpecialSymbolIndicators.End}");

        // Euler-Mascheroni constant
        ConstantsGenerator.GenerateNamedNumericSymbol(
            ConstantsTable,
            ReverseConstantsTable,
            "γ",
            0.5772156649015328,
            $"{definition.SpecialSymbolIndicators.Begin}gamma{definition.SpecialSymbolIndicators.End}");

        // Gauss-Kuzmin-Wirsing constant
        ConstantsGenerator.GenerateNamedNumericSymbol(
            ConstantsTable,
            ReverseConstantsTable,
            "λ",
            0.3036630028987326,
            $"{definition.SpecialSymbolIndicators.Begin}lambda{definition.SpecialSymbolIndicators.End}");
    }

    /// <summary>
    ///     Disposes in the managed context.
    /// </summary>
    [SuppressMessage(
        "IDisposableAnalyzers.Correctness",
        "IDISP003:Dispose previous before re-assigning.",
        Justification = "It is, but the analyzer can't tell.")]
    protected override void DisposeManagedContext()
    {
        base.DisposeManagedContext();

        ConstantsTable.Clear();
        ReverseConstantsTable.Clear();
        SymbolTable.Clear();
        ReverseSymbolTable.Clear();
        UnaryOperators.Dispose();
        BinaryOperators.Dispose();
    }
}