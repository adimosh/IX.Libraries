using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace IX.Library.Collections;

/// <summary>
///     An exception thrown when a limit argument is a negative number.
/// </summary>
/// <seealso cref="ArgumentException" />
[Serializable]
[ExcludeFromCodeCoverage]
public class LimitArgumentNegativeException : ArgumentException
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="IX.Library.Collections.LimitArgumentNegativeException" /> class.
    /// </summary>
    public LimitArgumentNegativeException()
        : base(Resources.LimitArgumentNegativeExceptionDefaultTextNoArgument) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="IX.Library.Collections.LimitArgumentNegativeException" /> class.
    /// </summary>
    /// <param name="argumentName">Name of the argument.</param>
    public LimitArgumentNegativeException(string argumentName)
        : base(
            string.Format(
                CultureInfo.CurrentCulture,
                Resources.LimitArgumentNegativeExceptionDefaultTextWithArgument,
                argumentName)) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="IX.Library.Collections.LimitArgumentNegativeException" /> class.
    /// </summary>
    /// <param name="innerException">
    ///     The exception that is the cause of the current exception. If the <paramref name="innerException" /> parameter
    ///     is not a <see langword="null" /> reference, the current exception is raised in a catch block that handles the inner
    ///     exception.
    /// </param>
    public LimitArgumentNegativeException(Exception innerException)
        : base(
            Resources.LimitArgumentNegativeExceptionDefaultTextNoArgument,
            innerException) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="IX.Library.Collections.LimitArgumentNegativeException" /> class.
    /// </summary>
    /// <param name="innerException">
    ///     The exception that is the cause of the current exception. If the <paramref name="innerException" /> parameter
    ///     is not a <see langword="null" /> reference, the current exception is raised in a catch block that handles the inner
    ///     exception.
    /// </param>
    /// <param name="argumentName">Name of the argument.</param>
    public LimitArgumentNegativeException(
        Exception innerException,
        string argumentName)
        : base(
            string.Format(
                CultureInfo.CurrentCulture,
                Resources.LimitArgumentNegativeExceptionDefaultTextWithArgument,
                argumentName),
            argumentName,
            innerException) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="IX.Library.Collections.LimitArgumentNegativeException" /> class.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="innerException">
    ///     The exception that is the cause of the current exception. If the <paramref name="innerException" /> parameter
    ///     is not a <see langword="null" /> reference, the current exception is raised in a catch block that handles the inner
    ///     exception.
    /// </param>
    public LimitArgumentNegativeException(
        string message,
        Exception innerException)
        : base(
            message,
            innerException) { }
}