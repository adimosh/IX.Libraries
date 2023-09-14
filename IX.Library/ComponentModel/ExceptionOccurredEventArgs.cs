using System.Diagnostics.CodeAnalysis;

namespace IX.Library.ComponentModel;

/// <summary>
///     Event arguments for an event handler detailing exceptions occurring in different threads.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public class ExceptionOccurredEventArgs : EventArgs
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ExceptionOccurredEventArgs" /> class.
    /// </summary>
    /// <param name="exception">The exception that has occurred.</param>
    public ExceptionOccurredEventArgs(Exception exception) => Exception = exception;

    /// <summary>
    ///     Gets the exception that has occurred.
    /// </summary>
    public Exception Exception { get; }
}