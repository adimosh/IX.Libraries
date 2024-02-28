using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace IX.Undoable;

/// <summary>
///     An exception thrown when the item has not been captured by an undo context.
/// </summary>
/// <seealso cref="InvalidOperationException" />
/// <seealso cref="IUndoableItem" />
[Serializable]
[ExcludeFromCodeCoverage]
public class ItemNotCapturedIntoUndoContextException : InvalidOperationException
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ItemNotCapturedIntoUndoContextException" /> class.
    /// </summary>
    public ItemNotCapturedIntoUndoContextException()
        : base(Resources.ItemNotCapturedIntoUndoContextException) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ItemNotCapturedIntoUndoContextException" /> class.
    /// </summary>
    /// <param name="message">The custom message to display.</param>
    public ItemNotCapturedIntoUndoContextException(string message)
        : base(message) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ItemNotCapturedIntoUndoContextException" /> class.
    /// </summary>
    /// <param name="innerException">The inner exception that caused this exception.</param>
    public ItemNotCapturedIntoUndoContextException(Exception innerException)
        : base(
            Resources.ItemNotCapturedIntoUndoContextException,
            innerException) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ItemNotCapturedIntoUndoContextException" /> class.
    /// </summary>
    /// <param name="message">The custom message to display.</param>
    /// <param name="innerException">The inner exception that caused this exception.</param>
    public ItemNotCapturedIntoUndoContextException(
        string message,
        Exception innerException)
        : base(
            message,
            innerException) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ItemNotCapturedIntoUndoContextException" /> class.
    /// </summary>
    /// <param name="info">
    ///     The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object
    ///     data about the exception being thrown.
    /// </param>
    /// <param name="context">
    ///     The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual
    ///     information about the source or destination.
    /// </param>
    protected ItemNotCapturedIntoUndoContextException(
        SerializationInfo info,
        StreamingContext context)
        : base(
            info,
            context) { }
}