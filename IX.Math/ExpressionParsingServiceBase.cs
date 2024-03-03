using IX.Library.System;

using System.Reflection;
using IX.Math.Extensibility;
using IX.Math.Extraction;
using IX.Math.Generators;
using IX.Math.Nodes;
using IX.Math.Nodes.Constants;
using IX.Math.Registration;

using System.Diagnostics.CodeAnalysis;

namespace IX.Math;

/// <summary>
///     A base class for an expression parsing service.
/// </summary>
/// <seealso cref="DisposableBase" />
/// <seealso cref="IExpressionParsingService" />
public abstract class ExpressionParsingServiceBase : ReaderWriterSynchronizedBase,
    IExpressionParsingService
{
    private readonly List<Assembly> _assembliesToRegister;
    private readonly Dictionary<string, Type> _binaryFunctions;

    private readonly LevelDictionary<Type, IConstantsExtractor> _constantExtractors;
    private readonly LevelDictionary<Type, IConstantInterpreter> _constantInterpreters;
    private readonly LevelDictionary<Type, IConstantPassThroughExtractor> _constantPassThroughExtractors;

    private readonly Dictionary<string, Type> _nonaryFunctions;
    private readonly List<IStringFormatter> _stringFormatters;
    private readonly Dictionary<string, Type> _ternaryFunctions;
    private readonly Dictionary<string, Type> _unaryFunctions;

    private readonly MathDefinition _workingDefinition;

    private int _interpretationDone;

    private bool _isInitialized;

    /// <summary>
    ///     Initializes a new instance of the <see cref="ExpressionParsingServiceBase" /> class with a specified math
    ///     definition
    ///     object.
    /// </summary>
    /// <param name="definition">The math definition to use.</param>
    protected private ExpressionParsingServiceBase(MathDefinition definition)
    {
        // Preconditions
        Requires.NotNull(
            out _workingDefinition,
            definition,
            nameof(definition));

        // Initialized internal state
        _constantExtractors = [];
        _constantInterpreters = [];
        _constantPassThroughExtractors = [];
        _stringFormatters = [];

        _nonaryFunctions = [];
        _unaryFunctions = [];
        _binaryFunctions = [];
        _ternaryFunctions = [];

        _assembliesToRegister =
        [
            typeof(ExpressionParsingService).GetTypeInfo().Assembly
        ];
    }

    /// <summary>
    ///     Returns the prototypes of all registered functions.
    /// </summary>
    /// <returns>All function names, with all possible combinations of input and output data.</returns>
    public string[] GetRegisteredFunctions()
    {
        ThrowIfCurrentObjectDisposed();

        using var innerLock = EnsureInitialization();

        // Capacity is sum of all, times 3; the "3" number was chosen as a good-enough average of how many overloads are defined, on average
        var bldr = new List<string>(
            (_nonaryFunctions.Count +
             _unaryFunctions.Count +
             _binaryFunctions.Count +
             _ternaryFunctions.Count) *
            3);

        bldr.AddRange(_nonaryFunctions.Select(function => $"{function.Key}()"));

        (
            from KeyValuePair<string, Type> function in _unaryFunctions
            from ConstructorInfo constructor in function.Value.GetTypeInfo()
                .DeclaredConstructors
            let parameters = constructor.GetParameters()
            where parameters.Length == 1
            let parameterName = parameters[0]
                .Name
            where parameterName != null
            let functionName = function.Key
            select (FunctionName: functionName, ParameterName: parameterName)).ForEach(
            (
                parameter,
                bldrL1) => bldrL1.Add($"{parameter.FunctionName}({parameter.ParameterName})"),
            bldr);

        (
            from KeyValuePair<string, Type> function in _binaryFunctions
            from ConstructorInfo constructor in function.Value.GetTypeInfo()
                .DeclaredConstructors
            let parameters = constructor.GetParameters()
            where parameters.Length == 2
            let parameterNameLeft = parameters[0]
                .Name
            let parameterNameRight = parameters[1]
                .Name
            where parameterNameLeft != null && parameterNameRight != null
            let functionName = function.Key
            select (FunctionName: functionName, ParameterNameLeft: parameterNameLeft,
                ParameterNameRight: parameterNameRight)).ForEach(
            (
                parameter,
                bldrL1) => bldrL1.Add(
                $"{parameter.FunctionName}({parameter.ParameterNameLeft}, {parameter.ParameterNameRight})"),
            bldr);

        (
            from KeyValuePair<string, Type> function in _ternaryFunctions
            from ConstructorInfo constructor in function.Value.GetTypeInfo()
                .DeclaredConstructors
            let parameters = constructor.GetParameters()
            where parameters.Length == 3
            let parameterNameLeft = parameters[0]
                .Name
            let parameterNameMiddle = parameters[1]
                .Name
            let parameterNameRight = parameters[2]
                .Name
            where parameterNameLeft != null && parameterNameMiddle != null && parameterNameRight != null
            let functionName = function.Key
            select (FunctionName: functionName, ParameterNameLeft: parameterNameLeft,
                ParameterNameMiddle: parameterNameMiddle, ParameterNameRight: parameterNameRight)).ForEach(
            (
                parameter,
                bldrL1) => bldrL1.Add(
                $"{parameter.FunctionName}({parameter.ParameterNameLeft}, {parameter.ParameterNameMiddle}, {parameter.ParameterNameRight})"),
            bldr);

        return bldr.ToArray();
    }

    /// <summary>
    ///     Interprets the mathematical expression and returns a container that can be invoked for solving using specific
    ///     mathematical types.
    /// </summary>
    /// <param name="expression">The expression to interpret.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ComputedExpression" /> that represents the interpreted expression.</returns>
    public abstract ComputedExpression Interpret(
        string expression,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Registers an assembly to extract compatible functions from.
    /// </summary>
    /// <param name="assembly">The assembly to register.</param>
    public void RegisterFunctionsAssembly(Assembly assembly)
    {
        _ = Requires.NotNull(
            assembly,
            nameof(assembly));

        ThrowIfCurrentObjectDisposed();

        using var innerLocker = AcquireReadWriteLock();

        if (_isInitialized)
        {
            throw new InvalidOperationException(
                "Initialization has already completed, so you cannot register any more assemblies for this service.");
        }

        if (_assembliesToRegister.Contains(assembly))
        {
            return;
        }

        innerLocker.Upgrade();

        _assembliesToRegister.Add(assembly);
    }

    /// <summary>
    ///     Registers type formatters.
    /// </summary>
    /// <param name="formatter">The formatter to register.</param>
    /// <exception cref="InvalidOperationException">
    ///     This method was called after having called <see cref="Interpret" />
    ///     successfully for the first time.
    /// </exception>
    public void RegisterTypeFormatter(IStringFormatter formatter)
    {
        _ = Requires.NotNull(
            formatter,
            nameof(formatter));

        if (_interpretationDone != 0)
        {
            throw new InvalidOperationException(
                Resources
                    .TheExpressionParsingServiceHasAlreadyDoneInterpretationAndCannotHaveAnyMoreFormattersRegistered);
        }

        _stringFormatters.Add(formatter);
    }

    /// <summary>
    ///     Disposes in the managed context.
    /// </summary>
    protected override void DisposeManagedContext()
    {
        _nonaryFunctions.Clear();
        _unaryFunctions.Clear();
        _binaryFunctions.Clear();
        _ternaryFunctions.Clear();

        _stringFormatters.Clear();
        _constantExtractors.Clear();
        _constantInterpreters.Clear();
        _constantPassThroughExtractors.Clear();

        _assembliesToRegister.Clear();

        base.DisposeManagedContext();
    }

    /// <summary>
    ///     Interprets the mathematical expression and returns a container that can be invoked for solving using specific
    ///     mathematical types.
    /// </summary>
    /// <param name="expression">The expression to interpret.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>
    ///     A <see cref="ComputedExpression" /> that represents a compilable form of the original expression, if the
    ///     expression itself makes sense.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="expression" /> is either null, empty or whitespace-only.</exception>
    [SuppressMessage(
        "Performance",
        "HAA0603:Delegate allocation from a method group",
        Justification = "We're OK with this.")]
    protected ComputedExpression InterpretInternal(
        string expression,
        CancellationToken cancellationToken = default)
    {
        _ = Requires.NotNullOrWhiteSpace(
            expression,
            nameof(expression));

        ThrowIfCurrentObjectDisposed();

        using var innerLock = EnsureInitialization();

        // Check expression through pass-through extractors
        if (_constantPassThroughExtractors.KeysByLevel.SelectMany(p => p.Value)
            .Any(
                ConstantPassThroughExtractorPredicate,
                expression,
                this))
        {
            return new(
                expression,
                new StringNode(expression),
                true,
                new StandardParameterRegistry(_stringFormatters),
                _stringFormatters,
                null);
        }

        static bool ConstantPassThroughExtractorPredicate(
            Type cpteKey,
            string innerExpression,
            ExpressionParsingServiceBase innerThis) =>
            innerThis._constantPassThroughExtractors[cpteKey]
                     .Evaluate(innerExpression);

        ComputedExpression result;
        using (var workingSet = new WorkingExpressionSet(
                   expression,
                   _workingDefinition.DeepClone(),
                   _nonaryFunctions,
                   _unaryFunctions,
                   _binaryFunctions,
                   _ternaryFunctions,
                   _constantExtractors,
                   _constantInterpreters,
                   _stringFormatters,
                   cancellationToken))
        {
            (NodeBase? node, IParameterRegistry? parameterRegistry) = ExpressionGenerator.CreateBody(workingSet);

            result = !workingSet.Success
                ? new(
                    expression,
                    null,
                    false,
                    null,
                    _stringFormatters,
                    null)
                : new ComputedExpression(
                    expression,
                    node,
                    true,
                    parameterRegistry,
                    _stringFormatters,
                    workingSet.OfferReservedType);

            Interlocked.MemoryBarrier();
        }

        _ = Interlocked.Exchange(
            ref _interpretationDone,
            1);

        return result;
    }

    [SuppressMessage(
        "IDisposableAnalyzers.Correctness",
        "IDISP017:Prefer using.",
        Justification = "This is required.")]
    [SuppressMessage(
        "Performance",
        "HAA0601:Value type to reference type conversion causing boxing allocation",
        Justification = "Unavoidable in this case.")]
    private IDisposable EnsureInitialization()
    {
        var innerLock = AcquireReadLock();

        if (_isInitialized)
        {
            return innerLock;
        }

        innerLock.Dispose();

        var innerWriteLock = AcquireReadWriteLock();

        if (_isInitialized)
        {
            return innerWriteLock;
        }

        try
        {
            innerWriteLock.Upgrade();

            // Initializing functions dictionaries
            _assembliesToRegister.GenerateInternalNonaryFunctionsDictionary(_nonaryFunctions);
            _assembliesToRegister.GenerateInternalUnaryFunctionsDictionary(_unaryFunctions);
            _assembliesToRegister.GenerateInternalBinaryFunctionsDictionary(_binaryFunctions);
            _assembliesToRegister.GenerateInternalTernaryFunctionsDictionary(_ternaryFunctions);

            // Extractors
            InitializePassThroughExtractorsDictionary();
            InitializeExtractorsDictionary();
            InitializeInterpretersDictionary();

            _isInitialized = true;
        }
        finally
        {
            innerWriteLock.Dispose();
        }

        return AcquireReadLock();
    }

    private void InitializeExtractorsDictionary()
    {
        _constantExtractors.Add(
            typeof(StringExtractor),
            new StringExtractor(),
            1000);
        _constantExtractors.Add(
            typeof(ScientificFormatNumberExtractor),
            new ScientificFormatNumberExtractor(),
            2000);

        var incrementer = 2001;
        _assembliesToRegister.GetTypesAssignableFrom<IConstantsExtractor>()
            .Where(
                p => p.IsClass && !p.IsAbstract && !p.IsGenericTypeDefinition && p.HasPublicParameterlessConstructor())
            .Select(p => p.AsType())
            .Where(
                (
                    p,
                    thisL1) => !thisL1._constantExtractors.ContainsKey(p),
                this)
            .ForEach(
                (
                    in Type p,
                    ref int i,
                    ExpressionParsingServiceBase thisL1) =>
                {
                    if (p.Instantiate() is not IConstantsExtractor extractor)
                    {
                        return;
                    }

                    thisL1._constantExtractors.Add(
                        p,
                        extractor,
                        p.GetAttributeDataByTypeWithoutVersionBinding<ConstantsExtractorAttribute, int>(
                            out var explicitLevel)
                            ? explicitLevel
                            : Interlocked.Increment(ref i));
                },
                ref incrementer,
                this);
    }

    private void InitializePassThroughExtractorsDictionary()
    {
        var incrementer = 2001;
        _assembliesToRegister.GetTypesAssignableFrom<IConstantPassThroughExtractor>()
            .Where(
                p => p.IsClass && !p.IsAbstract && !p.IsGenericTypeDefinition && p.HasPublicParameterlessConstructor())
            .Select(p => p.AsType())
            .Where(
                (
                    p,
                    thisL1) => !thisL1._constantPassThroughExtractors.ContainsKey(p),
                this)
            .ForEach(
                (
                    in Type p,
                    ref int i,
                    ExpressionParsingServiceBase thisL1) =>
                {
                    if (p.Instantiate() is not IConstantPassThroughExtractor extractor)
                    {
                        return;
                    }

                    thisL1._constantPassThroughExtractors.Add(
                        p,
                        extractor,
                        p.GetAttributeDataByTypeWithoutVersionBinding<ConstantsPassThroughExtractorAttribute, int>(
                            out var explicitLevel)
                            ? explicitLevel
                            : Interlocked.Increment(ref i));
                },
                ref incrementer,
                this);
    }

    private void InitializeInterpretersDictionary()
    {
        var incrementer = 2001;
        _assembliesToRegister.GetTypesAssignableFrom<IConstantInterpreter>()
            .Where(
                p => p.IsClass && !p.IsAbstract && !p.IsGenericTypeDefinition && p.HasPublicParameterlessConstructor())
            .Select(p => p.AsType())
            .Where(
                (
                    p,
                    thisL1) => !thisL1._constantInterpreters.ContainsKey(p),
                this)
            .ForEach(
                (
                    in Type p,
                    ref int i,
                    ExpressionParsingServiceBase thisL1) =>
                {
                    if (p.Instantiate() is not IConstantInterpreter interpreter)
                    {
                        return;
                    }

                    thisL1._constantInterpreters.Add(
                        p,
                        interpreter,
                        p.GetAttributeDataByTypeWithoutVersionBinding<ConstantsInterpreterAttribute, int>(
                            out var explicitLevel)
                            ? explicitLevel
                            : Interlocked.Increment(ref i));
                },
                ref incrementer,
                this);
    }
}