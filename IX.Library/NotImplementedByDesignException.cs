using System.Diagnostics.CodeAnalysis;

namespace IX.Library;

/// <summary>
///     The exception that is thrown when a requested method or operation is not implemented.
/// </summary>
/// <seealso cref="NotImplementedException" />
[Serializable]
[ExcludeFromCodeCoverage]
public class NotImplementedByDesignException : NotImplementedException
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="NotImplementedByDesignException" /> class.
    /// </summary>
    public NotImplementedByDesignException()
        : base(Resources.ErrorNotImplementedByDesign) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="NotImplementedByDesignException" /> class.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    public NotImplementedByDesignException(string message)
        : base(message) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="NotImplementedByDesignException" /> class.
    /// </summary>
    /// <param name="innerException">
    ///     The exception that is the cause of the current exception. If the
    ///     <paramref name="innerException" /> parameter is not null, the current exception is raised in a catch block that
    ///     handles the inner exception.
    /// </param>
    public NotImplementedByDesignException(Exception innerException)
        : base(
            Resources.ErrorNotImplementedByDesign,
            innerException) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="NotImplementedByDesignException" /> class.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="innerException">
    ///     The exception that is the cause of the current exception. If the
    ///     <paramref name="innerException" /> parameter is not null, the current exception is raised in a catch block that
    ///     handles the inner exception.
    /// </param>
    public NotImplementedByDesignException(
        string message,
        Exception innerException)
        : base(
            message,
            innerException) { }
}