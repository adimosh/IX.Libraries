using System.Linq.Expressions;

namespace IX.Math.Nodes;

/// <summary>
/// A service contract for a parameter node that is, in fact, a variable.
/// </summary>
[Obsolete("This interface will not be used anymore.")]
public interface IVariableNode
{
    /// <summary>
    /// Gets the reference node for this variable.
    /// </summary>
    /// <value>The reference node.</value>
    NodeBase ReferenceNode { get; }

    /// <summary>
    /// Generates the expression that represents the variable itself.
    /// </summary>
    /// <returns>A <see cref="ParameterExpression"/> representing the variable.</returns>
    ParameterExpression GenerateVariableExpression();
}