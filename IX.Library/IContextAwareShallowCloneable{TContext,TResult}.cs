namespace IX.Library;

/// <summary>
///     Interface for implementing context-aware shallow cloning for an object.
/// </summary>
/// <typeparam name="TContext">The type of the cloning context.</typeparam>
/// <typeparam name="TResult">The type of object to clone.</typeparam>
public interface IContextAwareShallowCloneable<in TContext, out TResult>
    where TContext : notnull
    where TResult : notnull
{
    /// <summary>
    ///     Creates a shallow clone of the source object based on an existing context.
    /// </summary>
    /// <param name="context">The shallow cloning context.</param>
    /// <returns>A shallow clone.</returns>
    TResult ShallowClone(TContext context);
}