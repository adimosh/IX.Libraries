using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace IX.Library.Contracts;

/// <summary>
///     Methods for approximating the works of contract-oriented programming.
/// </summary>
public static partial class Requires
{
    #region Not Null or Empty / Whitespace-only

    /// <summary>
    ///     Called when a contract requires that a string argument is not null or empty.
    /// </summary>
    /// <param name="argument">
    ///     The string argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <returns>
    ///     The validated argument.
    /// </returns>
    /// <exception cref="ArgumentNullOrEmptyStringException">
    ///     The argument is <see langword="null" /> or empty.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string NotNullOrEmpty(
        string? argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (string.IsNullOrEmpty(argument))
        {
            throw new ArgumentNullOrEmptyStringException(argumentName);
        }

        return argument!;
    }

    /// <summary>
    ///     Called when a contract requires that a string argument is not null or empty.
    /// </summary>
    /// <param name="field">
    ///     The field that this argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The string argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNullOrEmptyStringException">
    ///     The argument is <see langword="null" /> or empty.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void NotNullOrEmpty(
        out string field,
        string? argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (string.IsNullOrEmpty(argument))
        {
            throw new ArgumentNullOrEmptyStringException(argumentName);
        }

        field = argument!;
    }

    /// <summary>
    ///     Called when a contract requires that a string argument is not null empty or whitespace-only.
    /// </summary>
    /// <param name="argument">
    ///     The string argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <returns>
    ///     The validated argument.
    /// </returns>
    /// <exception cref="ArgumentNullOrWhiteSpaceStringException">
    ///     The argument is <see langword="null" /> or empty.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string NotNullOrWhiteSpace(
        string? argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (string.IsNullOrWhiteSpace(argument))
        {
            throw new ArgumentNullOrWhiteSpaceStringException(argumentName);
        }

        return argument!;
    }

    /// <summary>
    ///     Called when a contract requires that a string argument is not null empty or whitespace-only.
    /// </summary>
    /// <param name="field">
    ///     The field that this argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The string argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNullOrWhiteSpaceStringException">
    ///     The argument is <see langword="null" /> or empty.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void NotNullOrWhiteSpace(
        out string field,
        string? argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (string.IsNullOrWhiteSpace(argument))
        {
            throw new ArgumentNullOrWhiteSpaceStringException(argumentName);
        }

        field = argument!;
    }

    #endregion

    #region Length

    /// <summary>Called when a contract requires that an string is of a specific length.</summary>
    /// <param name="stringToTest">The string for which we are validating the length.</param>
    /// <param name="length">The exact length.</param>
    /// <param name="argumentName">The argument name.</param>
    /// <param name="lengthArgumentName">The name for the length argument.</param>
    /// <returns>The validated argument.</returns>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is either negative or exceeds the bounds of the
    ///     string.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string FixedLength(
        string? stringToTest,
        in int length,
        [CallerArgumentExpression("stringToTest")]
        string argumentName = "stringToTest",
        [CallerArgumentExpression("length")]
        string lengthArgumentName = "length")
    {
        if (stringToTest == null)
        {
            throw new ArgumentNullOrEmptyArrayException(argumentName);
        }

        if (length < 0)
        {
            throw new ArgumentNotValidLengthException(lengthArgumentName);
        }

        if (stringToTest.Length != length)
        {
            throw new ArgumentOutOfRangeException(lengthArgumentName);
        }

        return stringToTest;
    }

    /// <summary>Called when a contract requires that an string is of a specific length.</summary>
    /// <param name="field">
    ///     The field that this argument is initializing.
    /// </param>
    /// <param name="stringToTest">The string for which we are validating the length.</param>
    /// <param name="length">The exact length.</param>
    /// <param name="argumentName">The argument name.</param>
    /// <param name="lengthArgumentName">The name for the length argument.</param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is either negative or exceeds the bounds of the
    ///     string.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void FixedLength(
        out string field,
        string? stringToTest,
        in int length,
        [CallerArgumentExpression("stringToTest")]
        string argumentName = "stringToTest",
        [CallerArgumentExpression("length")]
        string lengthArgumentName = "length")
    {
        if (stringToTest == null)
        {
            throw new ArgumentNullOrEmptyArrayException(argumentName);
        }

        if (length < 0)
        {
            throw new ArgumentNotValidLengthException(lengthArgumentName);
        }

        if (stringToTest.Length != length)
        {
            throw new ArgumentOutOfRangeException(lengthArgumentName);
        }

        field = stringToTest;
    }

    /// <summary>Called when a contract requires that an string's length is at least a specific value.</summary>
    /// <param name="stringToTest">The string for which we are validating the length.</param>
    /// <param name="length">The exact length.</param>
    /// <param name="argumentName">The argument name.</param>
    /// <param name="lengthArgumentName">The name for the length argument.</param>
    /// <returns>The validated argument.</returns>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is either negative or exceeds the bounds of the
    ///     string.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string LengthAtLeast(
        string? stringToTest,
        in int length,
        [CallerArgumentExpression("stringToTest")]
        string argumentName = "stringToTest",
        [CallerArgumentExpression("length")]
        string lengthArgumentName = "length")
    {
        if (stringToTest == null)
        {
            throw new ArgumentNullOrEmptyArrayException(argumentName);
        }

        if (length < 0)
        {
            throw new ArgumentNotValidLengthException(lengthArgumentName);
        }

        if (stringToTest.Length < length)
        {
            throw new ArgumentOutOfRangeException(argumentName);
        }

        return stringToTest;
    }

    /// <summary>Called when a contract requires that an string's length is at least a specific value.</summary>
    /// <param name="field">
    ///     The field that this argument is initializing.
    /// </param>
    /// <param name="stringToTest">The string for which we are validating the length.</param>
    /// <param name="length">The exact length.</param>
    /// <param name="argumentName">The argument name.</param>
    /// <param name="lengthArgumentName">The name for the length argument.</param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is either negative or exceeds the bounds of the
    ///     string.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LengthAtLeast(
        out string field,
        string? stringToTest,
        in int length,
        [CallerArgumentExpression("stringToTest")]
        string argumentName = "stringToTest",
        [CallerArgumentExpression("length")]
        string lengthArgumentName = "length")
    {
        if (stringToTest == null)
        {
            throw new ArgumentNullOrEmptyArrayException(argumentName);
        }

        if (length < 0)
        {
            throw new ArgumentNotValidLengthException(lengthArgumentName);
        }

        if (stringToTest.Length < length)
        {
            throw new ArgumentOutOfRangeException(argumentName);
        }

        field = stringToTest;
    }

    /// <summary>Called when a contract requires that an string's length is at most a specific value.</summary>
    /// <param name="stringToTest">The string for which we are validating the length.</param>
    /// <param name="length">The exact length.</param>
    /// <param name="argumentName">The argument name.</param>
    /// <param name="lengthArgumentName">The name for the length argument.</param>
    /// <returns>The validated argument.</returns>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is either negative or exceeds the bounds of the
    ///     string.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string LengthAtMost(
        string? stringToTest,
        in int length,
        [CallerArgumentExpression("stringToTest")]
        string argumentName = "stringToTest",
        [CallerArgumentExpression("length")]
        string lengthArgumentName = "length")
    {
        if (stringToTest == null)
        {
            throw new ArgumentNullOrEmptyArrayException(argumentName);
        }

        if (length < 1)
        {
            throw new ArgumentNotValidLengthException(lengthArgumentName);
        }

        if (stringToTest.Length > length)
        {
            throw new ArgumentOutOfRangeException(argumentName);
        }

        return stringToTest;
    }

    /// <summary>Called when a contract requires that an string's length is at most a specific value.</summary>
    /// <param name="field">
    ///     The field that this argument is initializing.
    /// </param>
    /// <param name="stringToTest">The string for which we are validating the length.</param>
    /// <param name="length">The exact length.</param>
    /// <param name="argumentName">The argument name.</param>
    /// <param name="lengthArgumentName">The name for the length argument.</param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is either negative or exceeds the bounds of the
    ///     string.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LengthAtMost(
        out string field,
        string? stringToTest,
        in int length,
        [CallerArgumentExpression("stringToTest")]
        string argumentName = "stringToTest",
        [CallerArgumentExpression("length")]
        string lengthArgumentName = "length")
    {
        if (stringToTest == null)
        {
            throw new ArgumentNullOrEmptyArrayException(argumentName);
        }

        if (length > 1)
        {
            throw new ArgumentNotValidLengthException(lengthArgumentName);
        }

        if (stringToTest.Length < length)
        {
            throw new ArgumentOutOfRangeException(argumentName);
        }

        field = stringToTest;
    }

    #endregion

    #region Matches

    [SuppressMessage(
        "StyleCop.CSharp.OrderingRules",
        "SA1201:Elements should appear in the correct order",
        Justification = "Better code readability this way.")]
    private static readonly Lazy<Collections.ConcurrentDictionary<string, Regex>> Regexes = new(() => new());

    /// <summary>
    /// Called when a contract requires that a string matches a specific pattern.
    /// </summary>
    /// <param name="argument">The string to validate.</param>
    /// <param name="pattern">The pattern to match.</param>
    /// <param name="argumentName">The argument name.</param>
    /// <param name="patternArgumentName">The argument name for the pattern argument.</param>
    /// <returns>The validated argument.</returns>
    /// <exception cref="ArgumentNullOrEmptyStringException">The pattern is <c>null</c> (<c>Nothing in Visual Basic</c>) or empty.</exception>
    /// <exception cref="ArgumentNullException">The argument is <c>null</c> (<c>Nothing in Visual Basic</c>).</exception>
    /// <exception cref="ArgumentDoesNotMatchException">The argument does not match the pattern.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Matches(
        string? argument,
        string pattern,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument",
        [CallerArgumentExpression("pattern")]
        string patternArgumentName = "pattern")
    {
        if (string.IsNullOrEmpty(pattern))
        {
            throw new ArgumentNullOrEmptyStringException(patternArgumentName);
        }

        if (argument == null)
        {
            throw new ArgumentNullException(argumentName);
        }

        var patternRegex = Regexes.Value.GetOrAdd(
            pattern,
            p => new(p));

        if (!patternRegex.IsMatch(argument))
        {
            throw new ArgumentDoesNotMatchException(argumentName);
        }

        return argument;
    }

    /// <summary>
    /// Called when a contract requires that a string matches a specific pattern.
    /// </summary>
    /// <param name="field">
    ///     The field that this argument is initializing.
    /// </param>
    /// <param name="argument">The string to validate.</param>
    /// <param name="pattern">The pattern to match.</param>
    /// <param name="argumentName">The argument name.</param>
    /// <param name="patternArgumentName">The argument name for the pattern argument.</param>
    /// <exception cref="ArgumentNullOrEmptyStringException">The pattern is <c>null</c> (<c>Nothing in Visual Basic</c>) or empty.</exception>
    /// <exception cref="ArgumentNullException">The argument is <c>null</c> (<c>Nothing in Visual Basic</c>).</exception>
    /// <exception cref="ArgumentDoesNotMatchException">The argument does not match the pattern.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Matches(
        out string field,
        string? argument,
        string pattern,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument",
        [CallerArgumentExpression("pattern")]
        string patternArgumentName = "pattern")
    {
        if (string.IsNullOrEmpty(pattern))
        {
            throw new ArgumentNullOrEmptyStringException(patternArgumentName);
        }

        if (argument == null)
        {
            throw new ArgumentNullException(argumentName);
        }

        var patternRegex = Regexes.Value.GetOrAdd(
            pattern,
            p => new(p));

        if (!patternRegex.IsMatch(argument))
        {
            throw new ArgumentDoesNotMatchException(argumentName);
        }

        field = argument;
    }

    #endregion

    #region Web validation

    /// <summary>
    /// Called when a contract requires that a string is a valid email address.
    /// </summary>
    /// <param name="argument">The argument to validate.</param>
    /// <param name="argumentName">The name of the argument.</param>
    /// <returns>The validated argument.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ValidEmailAddress(
        string argument,
        [CallerArgumentExpression("argument")] string argumentName = "argument")
    {
        if (argument == null)
        {
            throw new ArgumentNullException(argumentName);
        }

        if (!EmailValidationHelper.IsAddressValid(argument))
        {
            throw new ArgumentDoesNotMatchException(argumentName);
        }

        return argument;
    }

    /// <summary>
    /// Called when a contract requires that a string is a valid email address.
    /// </summary>
    /// <param name="field">
    ///     The field that this argument is initializing.
    /// </param>
    /// <param name="argument">The argument to validate.</param>
    /// <param name="argumentName">The name of the argument.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ValidEmailAddress(
        out string field,
        string argument,
        [CallerArgumentExpression("argument")] string argumentName = "argument")
    {
        if (argument == null)
        {
            throw new ArgumentNullException(argumentName);
        }

        if (!EmailValidationHelper.IsAddressValid(argument))
        {
            throw new ArgumentDoesNotMatchException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    /// Called when a contract requires that a string is a valid email address, including IANA TLDs.
    /// </summary>
    /// <param name="argument">The argument to validate.</param>
    /// <param name="argumentName">The name of the argument.</param>
    /// <returns>The validated argument.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ValidEmailAddressStrict(
        string argument,
        [CallerArgumentExpression("argument")] string argumentName = "argument")
    {
        if (argument == null)
        {
            throw new ArgumentNullException(argumentName);
        }

        if (!EmailValidationHelper.IsAddressValid(argument, true))
        {
            throw new ArgumentDoesNotMatchException(argumentName);
        }

        return argument;
    }

    /// <summary>
    /// Called when a contract requires that a string is a valid email address, including IANA TLDs.
    /// </summary>
    /// <param name="field">
    ///     The field that this argument is initializing.
    /// </param>
    /// <param name="argument">The argument to validate.</param>
    /// <param name="argumentName">The name of the argument.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ValidEmailAddressStrict(
        out string field,
        string argument,
        [CallerArgumentExpression("argument")] string argumentName = "argument")
    {
        if (argument == null)
        {
            throw new ArgumentNullException(argumentName);
        }

        if (!EmailValidationHelper.IsAddressValid(argument, true))
        {
            throw new ArgumentDoesNotMatchException(argumentName);
        }

        field = argument;
    }

    #endregion
}