using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace - Because we're removing it completely in the future
namespace IX.Library.Contracts;

public partial class Requires
{
    #region Not Null

    /// <summary>
    ///     Called when a contract requires that an argument is not null.
    /// </summary>
    /// <typeparam name="T">The type of argument to validate.</typeparam>
    /// <param name="argument">
    ///     The argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <returns>
    ///     The validated argument.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     The argument is <see langword="null" />.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [Obsolete("No longer needed because of the latest C# features, as well as the latest IDE improvements.")]
    public static T NotNull<T>(
        T? argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument is null)
        {
            throw new ArgumentNullException(argumentName);
        }

        return argument;
    }

    /// <summary>
    ///     Called when a contract requires that an argument is not null.
    /// </summary>
    /// <typeparam name="T">The type of argument to validate.</typeparam>
    /// <param name="field">
    ///     The field that this argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNullException">
    ///     The argument is <see langword="null" />.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [Obsolete("No longer needed because of the latest C# features, as well as the latest IDE improvements.")]
    public static void NotNull<T>(
        out T field,
        T? argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument is null)
        {
            throw new ArgumentNullException(argumentName);
        }

        field = argument;
    }

    #endregion

}
