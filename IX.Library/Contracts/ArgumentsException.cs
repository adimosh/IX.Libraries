using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.Serialization;

namespace IX.Library.Contracts;

/// <summary>
///     An exception representing something wrong with a set of arguments as a whole, rather than just one.
/// </summary>
[Serializable]
[ExcludeFromCodeCoverage]
public class ArgumentsException : Exception
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ArgumentsException" /> class.
    /// </summary>
    /// <param name="argumentNames">The names of the arguments that have an invalid value.</param>
    public ArgumentsException(params string[] argumentNames)
        : base(
            string.Format(
                CultureInfo.CurrentCulture,
                Resources.AnInvalidSetOfArgumentsWasSpecifiedArgumentNames,
                string.Join(
                    ", ",
                    argumentNames ?? throw new ArgumentNullException(nameof(argumentNames))))) =>
        ArgumentNames = argumentNames;

    /// <summary>
    ///     Initializes a new instance of the <see cref="ArgumentsException" /> class.
    /// </summary>
    /// <param name="innerException">The inner exception.</param>
    /// <param name="argumentNames">The names of the arguments that have an invalid value.</param>
    public ArgumentsException(
        Exception innerException,
        params string[] argumentNames)
        : base(
            string.Format(
                CultureInfo.CurrentCulture,
                Resources.AnInvalidSetOfArgumentsWasSpecifiedArgumentNames,
                string.Join(
                    ", ",
                    argumentNames ?? throw new ArgumentNullException(nameof(argumentNames)))),
            innerException) =>
        ArgumentNames = argumentNames;

    /// <summary>
    ///     Initializes a new instance of the <see cref="ArgumentsException" /> class.
    /// </summary>
    /// <param name="message">The custom exception message.</param>
    /// <param name="innerException">The inner exception.</param>
    /// <param name="argumentNames">The names of the arguments that have an invalid value.</param>
    public ArgumentsException(
        string message,
        Exception innerException,
        params string[] argumentNames)
        : base(
            string.Format(
                CultureInfo.CurrentCulture,
                message,
                string.Join(
                    ", ",
                    argumentNames ?? throw new ArgumentNullException(nameof(argumentNames)))),
            innerException) =>
        ArgumentNames = argumentNames;

    /// <summary>
    ///     Initializes a new instance of the <see cref="ArgumentsException" /> class.
    /// </summary>
    /// <param name="message">The custom exception message.</param>
    /// <param name="argumentNames">The names of the arguments that have an invalid value.</param>
    protected ArgumentsException(
        string message,
        params string[] argumentNames)
        : base(
            string.Format(
                CultureInfo.CurrentCulture,
                message,
                string.Join(
                    ", ",
                    argumentNames ?? throw new ArgumentNullException(nameof(argumentNames))))) =>
        ArgumentNames = argumentNames;

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
                typeof(string[])),
            nameof(info));
#endif

    /// <summary>
    ///     Gets the argument names.
    /// </summary>
    public string[] ArgumentNames { get; private set; }

#if !NET9_0_OR_GREATER
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