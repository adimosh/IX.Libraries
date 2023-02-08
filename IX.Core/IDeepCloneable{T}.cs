namespace IX.Core;

/// <summary>
///     Interface for implementing deep cloning for an object.
/// </summary>
/// <typeparam name="T">The type of object to clone.</typeparam>
[PublicAPI]
public interface IDeepCloneable<out T>
    where T : notnull
{
    /// <summary>
    ///     Creates a deep clone of the source object.
    /// </summary>
    /// <returns>A deep clone.</returns>
    T DeepClone();
}