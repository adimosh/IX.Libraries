using System.Runtime.Serialization;

// ReSharper disable once CheckNamespace
namespace IX.Library.Contracts;

public partial class ArgumentsException
{
#if !NET9_0_OR_GREATER
    /// <summary>
    ///     Initializes a new instance of the <see cref="ArgumentsException" /> class.
    /// </summary>
    /// <param name="info">
    ///     The <see cref="SerializationInfo" /> that holds the serialized object data about the exception being
    ///     thrown.
    /// </param>
    /// <param name="context">
    ///     The <see cref="StreamingContext" /> that contains contextual information about the source or
    ///     destination.
    /// </param>
#if NET8_0
    [Obsolete("This will be removed for .NET 8.0 onwards in the next version with breaking changes.")]
#endif
    protected ArgumentsException(
        SerializationInfo info,
        StreamingContext context)
        : base(
            info,
            context) =>
        ArgumentNames = Requires.ArgumentOfType<string[]>(
            info.GetValue(
                nameof(ArgumentNames),
                typeof(string[])), nameof(info));

    /// <summary>
    ///     Sets the <see cref="SerializationInfo" /> with information about the exception.
    /// </summary>
    /// <param name="info">
    ///     The <see cref="SerializationInfo" /> that holds the serialized object data about the exception being
    ///     thrown.
    /// </param>
    /// <param name="context">
    ///     The <see cref="StreamingContext" /> that contains contextual information about the source or
    ///     destination.
    /// </param>
#if NET8_0
    [Obsolete("This will be removed for .NET 8.0 onwards in the next version with breaking changes.")]
#endif
    public override void GetObjectData(
        SerializationInfo info,
        StreamingContext context)
    {
        base.GetObjectData(
            info,
            context);

        info.AddValue(
            nameof(ArgumentNames),
            ArgumentNames,
            typeof(string[]));
    }
#endif
}