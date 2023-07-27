using IX.Math.Nodes;
using IX.Math.Registration;

namespace IX.Math.Computation;

internal readonly struct ComputationBody
{
    internal static readonly ComputationBody Empty = new(
        null,
        null);

    internal readonly NodeBase? BodyNode;

    internal readonly IParameterRegistry? ParameterRegistry;

    internal ComputationBody(
        NodeBase? bodyNode,
        IParameterRegistry? parameterRegistry)
    {
        BodyNode = bodyNode;
        ParameterRegistry = parameterRegistry;
    }

    internal void Deconstruct(
        out NodeBase? bodyNode,
        out IParameterRegistry? parameterRegistry)
    {
        bodyNode = BodyNode;
        parameterRegistry = ParameterRegistry;
    }
}