using System.Runtime.Serialization;

// ReSharper disable once CheckNamespace
namespace IX.Math;

public partial class ExpressionNotValidLogicallyException
{
#if !NET9_0_OR_GREATER
    /// <summary>
    /// Initializes a new instance of the <see cref="ExpressionNotValidLogicallyException"/> class.
    /// </summary>
    /// <param name="info">The <see cref="SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
    /// <param name="context">The <see cref="StreamingContext" /> that contains contextual information about the source or destination.</param>
#if NET8_0
    [Obsolete("This will be removed for .NET 8.0 onwards in the next version with breaking changes.")]
#endif
    protected ExpressionNotValidLogicallyException(
        SerializationInfo info,
        StreamingContext context)
        : base(
            info,
            context) { }
#endif
}