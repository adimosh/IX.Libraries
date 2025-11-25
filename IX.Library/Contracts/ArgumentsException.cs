using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace IX.Library.Contracts;

/// <summary>
///     An exception representing something wrong with a set of arguments as a whole, rather than just one.
/// </summary>
[Serializable]
[ExcludeFromCodeCoverage]
public partial class ArgumentsException : Exception
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

    /// <summary>
    ///     Gets the argument names.
    /// </summary>
    public string[] ArgumentNames { get; private set; }
}