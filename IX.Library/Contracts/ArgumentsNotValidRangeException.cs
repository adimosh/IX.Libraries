using System.Diagnostics.CodeAnalysis;

namespace IX.Library.Contracts;

/// <summary>
///     An exception representing that a certain set of arguments do not form a valid range of values.
/// </summary>
[Serializable]
[ExcludeFromCodeCoverage]
public partial class ArgumentsNotValidRangeException : ArgumentsException
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ArgumentsNotValidRangeException" /> class.
    /// </summary>
    /// <param name="argumentNames">The names of the arguments that form an invalid value range.</param>
    public ArgumentsNotValidRangeException(params string[] argumentNames)
        : base(
            Resources.TheProvidedArgumentsDoNotFormAValidRangeOfValuesArguments,
            argumentNames) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ArgumentsNotValidRangeException" /> class.
    /// </summary>
    /// <param name="innerException">The inner exception.</param>
    /// <param name="argumentNames">The names of the arguments that form an invalid value range.</param>
    public ArgumentsNotValidRangeException(
        Exception innerException,
        params string[] argumentNames)
        : base(
            Resources.TheProvidedArgumentsDoNotFormAValidRangeOfValuesArguments,
            innerException,
            argumentNames) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ArgumentsNotValidRangeException" /> class.
    /// </summary>
    /// <param name="message">The custom exception message.</param>
    /// <param name="innerException">The inner exception.</param>
    /// <param name="argumentNames">The names of the arguments that form an invalid value range.</param>
    public ArgumentsNotValidRangeException(
        string message,
        Exception innerException,
        params string[] argumentNames)
        : base(
            message,
            innerException,
            argumentNames) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ArgumentsNotValidRangeException" /> class.
    /// </summary>
    /// <param name="message">The custom exception message.</param>
    /// <param name="argumentNames">The names of the arguments that form an invalid value range.</param>
    protected ArgumentsNotValidRangeException(
        string message,
        params string[] argumentNames)
        : base(
            message,
            argumentNames) { }
}