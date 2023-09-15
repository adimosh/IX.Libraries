using IX.Library.Contracts;
using IX.Math.Extensibility;

namespace IX.Math.Nodes;

/// <summary>
///     A base class for a function that takes three parameters.
/// </summary>
/// <seealso cref="FunctionNodeBase" />
public abstract class TernaryFunctionNodeBase : FunctionNodeBase
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="TernaryFunctionNodeBase" /> class.
    /// </summary>
    /// <param name="firstParameter">The first parameter.</param>
    /// <param name="secondParameter">The second parameter.</param>
    /// <param name="thirdParameter">The third parameter.</param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="firstParameter" />
    ///     or
    ///     <paramref name="secondParameter" />
    ///     or
    ///     <paramref name="thirdParameter" />
    ///     is <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    protected TernaryFunctionNodeBase(
        NodeBase firstParameter,
        NodeBase secondParameter,
        NodeBase thirdParameter)
    {
        NodeBase firstParameterTemp = Requires.NotNull(firstParameter);
        NodeBase secondParameterTemp = Requires.NotNull(secondParameter);
        NodeBase thirdParameterTemp = Requires.NotNull(thirdParameter);

        // ReSharper disable once VirtualMemberCallInConstructor
        EnsureCompatibleParameters(
            firstParameter,
            secondParameter,
            thirdParameter);

        FirstParameter = firstParameterTemp.Simplify();
        SecondParameter = secondParameterTemp.Simplify();
        ThirdParameter = thirdParameterTemp.Simplify();
    }

    /// <summary>
    ///     Gets the first parameter.
    /// </summary>
    /// <value>The first parameter.</value>
    public NodeBase FirstParameter { get; }

    /// <summary>
    ///     Gets the second parameter.
    /// </summary>
    /// <value>The second parameter.</value>
    public NodeBase SecondParameter { get; }

    /// <summary>
    ///     Gets the third parameter.
    /// </summary>
    /// <value>The third parameter.</value>
    public NodeBase ThirdParameter { get; }

    /// <summary>
    ///     Gets a value indicating whether this node supports tolerance.
    /// </summary>
    /// <value>
    ///     <c>true</c> if this instance is tolerant; otherwise, <c>false</c>.
    /// </value>
    public override bool IsTolerant =>
        FirstParameter.IsTolerant || SecondParameter.IsTolerant || ThirdParameter.IsTolerant;

    /// <summary>
    ///     Sets the special object request function for sub objects.
    /// </summary>
    /// <param name="func">The function.</param>
    protected override void SetSpecialObjectRequestFunctionForSubObjects(Func<Type, object> func)
    {
        if (FirstParameter is ISpecialRequestNode srnl)
        {
            srnl.SetRequestSpecialObjectFunction(func);
        }

        if (SecondParameter is ISpecialRequestNode srnr)
        {
            srnr.SetRequestSpecialObjectFunction(func);
        }

        if (ThirdParameter is ISpecialRequestNode trnr)
        {
            trnr.SetRequestSpecialObjectFunction(func);
        }
    }

    /// <summary>
    ///     Ensures the parameters are compatible for this node.
    /// </summary>
    /// <param name="first">The first.</param>
    /// <param name="second">The second.</param>
    /// <param name="third">The third.</param>
    protected abstract void EnsureCompatibleParameters(
        NodeBase first,
        NodeBase second,
        NodeBase third);
}