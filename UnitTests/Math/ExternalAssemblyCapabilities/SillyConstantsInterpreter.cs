using IX.Library.Globalization;
using IX.Math.Extensibility;
using IX.Math.Nodes;
using IX.Math.Nodes.Constants;

namespace UnitTests.Math.ExternalAssemblyCapabilities;

/// <summary>
///     A constants interpreter used for testing purposes.
/// </summary>
/// <seealso cref="IConstantInterpreter" />
[ConstantsInterpreter]
public class SillyConstantsInterpreter : IConstantInterpreter
{
    /// <summary>
    ///     Evaluates part of an expression, determining whether it is a constant.
    /// </summary>
    /// <param name="expressionPart">The expression part.</param>
    /// <returns>
    ///     <c>true</c>, along with the evaluated node, if the expression part correctly evaluates to a constant, <c>false</c>
    ///     otherwise.
    /// </returns>
    /// <remarks>
    ///     <para>
    ///         The part evaluation phase happens after constants extraction and after the expression has been split into
    ///         component parts. If you require the whole expression to be evaluated (which might include symbols otherwise
    ///         recognizable as operators), you should use the <see cref="T:IX.Math.Extensibility.IConstantsExtractor" />
    ///         interface instead.
    ///     </para>
    ///     <para>
    ///         A correctly-recognized constant will only be asked for once. Any subsequent discoveries of the same constant
    ///         will result in the same value used.
    ///     </para>
    ///     <para>
    ///         An expression part that is not recognized will flow down to other interpreters, and, ultimately, to the
    ///         standard formatters.
    ///     </para>
    /// </remarks>
    public (bool Success, ConstantNodeBase Value) EvaluateIsConstant(string expressionPart) =>
        expressionPart.CurrentCultureEqualsInsensitive("bumblydumb") ? (true, new NumericNode(2L)) : (false, default);
}