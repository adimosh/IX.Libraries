using IX.Math.Registration;

namespace IX.Math.Nodes;

/// <summary>
///     A context for cloning nodes.
/// </summary>
[PublicAPI]
public class NodeCloningContext
{
    /// <summary>
    ///     Gets or sets the parameter registry.
    /// </summary>
    /// <value>The parameter registry.</value>
    public IParameterRegistry ParameterRegistry { get; set; }

    /// <summary>
    ///     Gets or sets the special request function.
    /// </summary>
    /// <value>
    ///     The special request function.
    /// </value>
    public Func<Type, object>? SpecialRequestFunction { get; set; }
}