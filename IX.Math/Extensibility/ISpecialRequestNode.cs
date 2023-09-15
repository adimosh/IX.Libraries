namespace IX.Math.Extensibility;

/// <summary>
/// A supplementary interface allowing nodes to request special objects when needed.
/// </summary>
[PublicAPI]
public interface ISpecialRequestNode
{
    /// <summary>
    /// Sets the request special object function.
    /// </summary>
    /// <param name="func">The function to set.</param>
    void SetRequestSpecialObjectFunction(Func<Type, object> func);
}