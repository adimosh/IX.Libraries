namespace IX.Library;

/// <summary>
///     Interface for implementing context-aware deep cloning for an object.
/// </summary>
/// <typeparam name="TContext">The type of the cloning context.</typeparam>
/// <typeparam name="TResult">The type of object to clone.</typeparam>
[PublicAPI]
public interface IContextAwareDeepCloneable<in TContext, out TResult>
    where TContext : notnull
    where TResult : notnull
{
    /// <summary>
    ///     Creates a deep clone of the source object based on an existing context.
    /// </summary>
    /// <param name="context">The deep cloning context.</param>
    /// <returns>A deep clone.</returns>
    TResult DeepClone(TContext context);
}