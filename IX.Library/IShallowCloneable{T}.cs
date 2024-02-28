namespace IX.Library;

/// <summary>
///     Interface for implementing shallow cloning for an object.
/// </summary>
/// <typeparam name="T">The type of object to clone.</typeparam>
public interface IShallowCloneable<out T>
    where T : notnull
{
    /// <summary>
    ///     Creates a shallow clone of the source object.
    /// </summary>
    /// <returns>A shallow clone.</returns>
    T ShallowClone();
}