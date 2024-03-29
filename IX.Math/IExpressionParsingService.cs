using System.Reflection;
using IX.Math.Extensibility;

namespace IX.Math;

/// <summary>
///     A contract for a service that is able to parse strings containing mathematical expressions and solve them.
/// </summary>
/// <seealso cref="IDisposable" />
public interface IExpressionParsingService : IDisposable
{
    /// <summary>
    ///     Interprets the mathematical expression and returns a container that can be invoked for solving using specific
    ///     mathematical types.
    /// </summary>
    /// <param name="expression">The expression to interpret.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ComputedExpression" /> that represents the interpreted expression.</returns>
    ComputedExpression Interpret(
        string expression,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Registers type formatters.
    /// </summary>
    /// <param name="formatter">The formatter to register.</param>
    /// <exception cref="InvalidOperationException">
    ///     This method was called after having called <see cref="Interpret" />
    ///     successfully for the first time.
    /// </exception>
    void RegisterTypeFormatter(IStringFormatter formatter);

    /// <summary>
    ///     Registers an assembly to extract compatible functions from.
    /// </summary>
    /// <param name="assembly">The assembly to register.</param>
    void RegisterFunctionsAssembly(Assembly assembly);

    /// <summary>
    ///     Returns the prototypes of all registered functions.
    /// </summary>
    /// <returns>All function names, with all possible combinations of input and output data.</returns>
    string[] GetRegisteredFunctions();
}