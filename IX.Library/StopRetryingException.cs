using System.Diagnostics.CodeAnalysis;

namespace IX.Library;

/// <summary>
///     An exception that, when thrown, signals the thread it's on to stop retrying an operation.
/// </summary>
/// <seealso cref="Exception" />
[Serializable]
[ExcludeFromCodeCoverage]
public class StopRetryingException : Exception
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="StopRetryingException" /> class.
    /// </summary>
    public StopRetryingException()
        : base(Resources.ErrorStopRetrying) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="StopRetryingException" /> class.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public StopRetryingException(string message)
        : base(message) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="StopRetryingException" /> class.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="innerException">
    ///     The exception that is the cause of the current exception, or a null reference (
    ///     <see langword="Nothing" /> in Visual Basic) if no inner exception is specified.
    /// </param>
    public StopRetryingException(
        string message,
        Exception innerException)
        : base(
            message,
            innerException) { }
}