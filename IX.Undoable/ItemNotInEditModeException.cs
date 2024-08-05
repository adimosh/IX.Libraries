using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace IX.Undoable;

/// <summary>
///     An exception thrown when the item is not in edit mode and it should be.
/// </summary>
/// <seealso cref="InvalidOperationException" />
/// <seealso cref="ITransactionEditableItem" />
[Serializable]
[ExcludeFromCodeCoverage]
public class ItemNotInEditModeException : InvalidOperationException
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ItemNotInEditModeException" /> class.
    /// </summary>
    public ItemNotInEditModeException()
        : base(Resources.ItemNotInEditModeExceptionDefaultMessage) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ItemNotInEditModeException" /> class.
    /// </summary>
    /// <param name="message">The custom message to display.</param>
    public ItemNotInEditModeException(string message)
        : base(message) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ItemNotInEditModeException" /> class.
    /// </summary>
    /// <param name="innerException">The inner exception that caused this exception.</param>
    public ItemNotInEditModeException(Exception innerException)
        : base(
            Resources.ItemNotInEditModeExceptionDefaultMessage,
            innerException) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ItemNotInEditModeException" /> class.
    /// </summary>
    /// <param name="message">The custom message to display.</param>
    /// <param name="innerException">The inner exception that caused this exception.</param>
    public ItemNotInEditModeException(
        string message,
        Exception innerException)
        : base(
            message,
            innerException) { }

#if !NET9_0_OR_GREATER
    /// <summary>
    ///     Initializes a new instance of the <see cref="ItemNotInEditModeException" /> class.
    /// </summary>
    /// <param name="info">
    ///     The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object
    ///     data about the exception being thrown.
    /// </param>
    /// <param name="context">
    ///     The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual
    ///     information about the source or destination.
    /// </param>
#if NET8_0
    [Obsolete("This will be removed for .NET 8.0 onwards in the next version with breaking changes.")]
#endif
    protected ItemNotInEditModeException(
        SerializationInfo info,
        StreamingContext context)
        : base(
            info,
            context) { }
#endif
}