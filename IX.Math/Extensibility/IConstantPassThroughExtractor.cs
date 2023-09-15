namespace IX.Math.Extensibility;

/// <summary>
///     A service contract for extracting pass-through constants.
/// </summary>
[PublicAPI]
public interface IConstantPassThroughExtractor
{
    /// <summary>
    ///     Evaluates an expression and decides whether or not it should be a pass-through constant.
    /// </summary>
    /// <param name="expression">The expression to evaluate.</param>
    /// <returns><c>true</c> if the expression is a pass-through constant, <c>false</c> otherwise.</returns>
    bool Evaluate(string expression);
}