using System.Runtime.CompilerServices;

namespace IX.Core.Contracts;

/// <summary>
///     Methods for approximating the works of contract-oriented programming.
/// </summary>
public static partial class Requires
{
    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="byte" /> is
    ///     located within a desired range.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="lowerBound">
    ///     The lower bound of the range to validate against. Must be less than or equal to <paramref name="upperBound" />.
    /// </param>
    /// <param name="upperBound">
    ///     The upper bound of the range to validate against. Must be greater than or equal to <paramref name="lowerBound" />.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotInRangeException">
    ///     The argument is within the undesired range.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void InRange(
        in byte argument,
        in byte lowerBound,
        in byte upperBound,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (lowerBound > upperBound)
        {
            throw new ArgumentNotLessThanOrEqualToException(nameof(lowerBound));
        }

        if (argument < lowerBound || argument > upperBound)
        {
            throw new ArgumentNotInRangeException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="byte" /> is
    ///     not located within an undesired range.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="lowerBound">
    ///     The lower bound of the range to validate against. Must be less than or equal to <paramref name="upperBound" />.
    /// </param>
    /// <param name="upperBound">
    ///     The upper bound of the range to validate against. Must be greater than or equal to <paramref name="lowerBound" />.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentInRangeException">
    ///     The argument is not within the desired range.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void NotInRange(
        in byte argument,
        in byte lowerBound,
        in byte upperBound,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (lowerBound > upperBound)
        {
            throw new ArgumentNotLessThanOrEqualToException(nameof(lowerBound));
        }

        if (argument >= lowerBound || argument <= upperBound)
        {
            throw new ArgumentInRangeException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="byte" /> is
    ///     located within a desired range.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="lowerBound">
    ///     The lower bound of the range to validate against. Must be less than or equal to <paramref name="upperBound" />.
    /// </param>
    /// <param name="upperBound">
    ///     The upper bound of the range to validate against. Must be greater than or equal to <paramref name="lowerBound" />.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotInRangeException">
    ///     The argument is within the undesired range.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void InRange(
        out byte field,
        in byte argument,
        in byte lowerBound,
        in byte upperBound,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (lowerBound > upperBound)
        {
            throw new ArgumentNotLessThanOrEqualToException(nameof(lowerBound));
        }

        if (argument < lowerBound || argument > upperBound)
        {
            throw new ArgumentNotInRangeException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="byte" /> is
    ///     not located within an undesired range.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="lowerBound">
    ///     The lower bound of the range to validate against. Must be less than or equal to <paramref name="upperBound" />.
    /// </param>
    /// <param name="upperBound">
    ///     The upper bound of the range to validate against. Must be greater than or equal to <paramref name="lowerBound" />.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentInRangeException">
    ///     The argument is not within the desired range.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void NotInRange(
        out byte field,
        in byte argument,
        in byte lowerBound,
        in byte upperBound,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (lowerBound > upperBound)
        {
            throw new ArgumentNotLessThanOrEqualToException(nameof(lowerBound));
        }

        if (argument >= lowerBound || argument <= upperBound)
        {
            throw new ArgumentInRangeException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="sbyte" /> is
    ///     located within a desired range.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="lowerBound">
    ///     The lower bound of the range to validate against. Must be less than or equal to <paramref name="upperBound" />.
    /// </param>
    /// <param name="upperBound">
    ///     The upper bound of the range to validate against. Must be greater than or equal to <paramref name="lowerBound" />.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotInRangeException">
    ///     The argument is within the undesired range.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void InRange(
        in sbyte argument,
        in sbyte lowerBound,
        in sbyte upperBound,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (lowerBound > upperBound)
        {
            throw new ArgumentNotLessThanOrEqualToException(nameof(lowerBound));
        }

        if (argument < lowerBound || argument > upperBound)
        {
            throw new ArgumentNotInRangeException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="sbyte" /> is
    ///     not located within an undesired range.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="lowerBound">
    ///     The lower bound of the range to validate against. Must be less than or equal to <paramref name="upperBound" />.
    /// </param>
    /// <param name="upperBound">
    ///     The upper bound of the range to validate against. Must be greater than or equal to <paramref name="lowerBound" />.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentInRangeException">
    ///     The argument is not within the desired range.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void NotInRange(
        in sbyte argument,
        in sbyte lowerBound,
        in sbyte upperBound,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (lowerBound > upperBound)
        {
            throw new ArgumentNotLessThanOrEqualToException(nameof(lowerBound));
        }

        if (argument >= lowerBound || argument <= upperBound)
        {
            throw new ArgumentInRangeException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="sbyte" /> is
    ///     located within a desired range.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="lowerBound">
    ///     The lower bound of the range to validate against. Must be less than or equal to <paramref name="upperBound" />.
    /// </param>
    /// <param name="upperBound">
    ///     The upper bound of the range to validate against. Must be greater than or equal to <paramref name="lowerBound" />.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotInRangeException">
    ///     The argument is within the undesired range.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void InRange(
        out sbyte field,
        in sbyte argument,
        in sbyte lowerBound,
        in sbyte upperBound,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (lowerBound > upperBound)
        {
            throw new ArgumentNotLessThanOrEqualToException(nameof(lowerBound));
        }

        if (argument < lowerBound || argument > upperBound)
        {
            throw new ArgumentNotInRangeException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="sbyte" /> is
    ///     not located within an undesired range.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="lowerBound">
    ///     The lower bound of the range to validate against. Must be less than or equal to <paramref name="upperBound" />.
    /// </param>
    /// <param name="upperBound">
    ///     The upper bound of the range to validate against. Must be greater than or equal to <paramref name="lowerBound" />.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentInRangeException">
    ///     The argument is not within the desired range.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void NotInRange(
        out sbyte field,
        in sbyte argument,
        in sbyte lowerBound,
        in sbyte upperBound,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (lowerBound > upperBound)
        {
            throw new ArgumentNotLessThanOrEqualToException(nameof(lowerBound));
        }

        if (argument >= lowerBound || argument <= upperBound)
        {
            throw new ArgumentInRangeException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="short" /> is
    ///     located within a desired range.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="lowerBound">
    ///     The lower bound of the range to validate against. Must be less than or equal to <paramref name="upperBound" />.
    /// </param>
    /// <param name="upperBound">
    ///     The upper bound of the range to validate against. Must be greater than or equal to <paramref name="lowerBound" />.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotInRangeException">
    ///     The argument is within the undesired range.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void InRange(
        in short argument,
        in short lowerBound,
        in short upperBound,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (lowerBound > upperBound)
        {
            throw new ArgumentNotLessThanOrEqualToException(nameof(lowerBound));
        }

        if (argument < lowerBound || argument > upperBound)
        {
            throw new ArgumentNotInRangeException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="short" /> is
    ///     not located within an undesired range.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="lowerBound">
    ///     The lower bound of the range to validate against. Must be less than or equal to <paramref name="upperBound" />.
    /// </param>
    /// <param name="upperBound">
    ///     The upper bound of the range to validate against. Must be greater than or equal to <paramref name="lowerBound" />.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentInRangeException">
    ///     The argument is not within the desired range.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void NotInRange(
        in short argument,
        in short lowerBound,
        in short upperBound,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (lowerBound > upperBound)
        {
            throw new ArgumentNotLessThanOrEqualToException(nameof(lowerBound));
        }

        if (argument >= lowerBound || argument <= upperBound)
        {
            throw new ArgumentInRangeException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="short" /> is
    ///     located within a desired range.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="lowerBound">
    ///     The lower bound of the range to validate against. Must be less than or equal to <paramref name="upperBound" />.
    /// </param>
    /// <param name="upperBound">
    ///     The upper bound of the range to validate against. Must be greater than or equal to <paramref name="lowerBound" />.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotInRangeException">
    ///     The argument is within the undesired range.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void InRange(
        out short field,
        in short argument,
        in short lowerBound,
        in short upperBound,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (lowerBound > upperBound)
        {
            throw new ArgumentNotLessThanOrEqualToException(nameof(lowerBound));
        }

        if (argument < lowerBound || argument > upperBound)
        {
            throw new ArgumentNotInRangeException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="short" /> is
    ///     not located within an undesired range.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="lowerBound">
    ///     The lower bound of the range to validate against. Must be less than or equal to <paramref name="upperBound" />.
    /// </param>
    /// <param name="upperBound">
    ///     The upper bound of the range to validate against. Must be greater than or equal to <paramref name="lowerBound" />.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentInRangeException">
    ///     The argument is not within the desired range.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void NotInRange(
        out short field,
        in short argument,
        in short lowerBound,
        in short upperBound,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (lowerBound > upperBound)
        {
            throw new ArgumentNotLessThanOrEqualToException(nameof(lowerBound));
        }

        if (argument >= lowerBound || argument <= upperBound)
        {
            throw new ArgumentInRangeException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="ushort" /> is
    ///     located within a desired range.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="lowerBound">
    ///     The lower bound of the range to validate against. Must be less than or equal to <paramref name="upperBound" />.
    /// </param>
    /// <param name="upperBound">
    ///     The upper bound of the range to validate against. Must be greater than or equal to <paramref name="lowerBound" />.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotInRangeException">
    ///     The argument is within the undesired range.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void InRange(
        in ushort argument,
        in ushort lowerBound,
        in ushort upperBound,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (lowerBound > upperBound)
        {
            throw new ArgumentNotLessThanOrEqualToException(nameof(lowerBound));
        }

        if (argument < lowerBound || argument > upperBound)
        {
            throw new ArgumentNotInRangeException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="ushort" /> is
    ///     not located within an undesired range.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="lowerBound">
    ///     The lower bound of the range to validate against. Must be less than or equal to <paramref name="upperBound" />.
    /// </param>
    /// <param name="upperBound">
    ///     The upper bound of the range to validate against. Must be greater than or equal to <paramref name="lowerBound" />.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentInRangeException">
    ///     The argument is not within the desired range.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void NotInRange(
        in ushort argument,
        in ushort lowerBound,
        in ushort upperBound,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (lowerBound > upperBound)
        {
            throw new ArgumentNotLessThanOrEqualToException(nameof(lowerBound));
        }

        if (argument >= lowerBound || argument <= upperBound)
        {
            throw new ArgumentInRangeException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="ushort" /> is
    ///     located within a desired range.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="lowerBound">
    ///     The lower bound of the range to validate against. Must be less than or equal to <paramref name="upperBound" />.
    /// </param>
    /// <param name="upperBound">
    ///     The upper bound of the range to validate against. Must be greater than or equal to <paramref name="lowerBound" />.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotInRangeException">
    ///     The argument is within the undesired range.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void InRange(
        out ushort field,
        in ushort argument,
        in ushort lowerBound,
        in ushort upperBound,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (lowerBound > upperBound)
        {
            throw new ArgumentNotLessThanOrEqualToException(nameof(lowerBound));
        }

        if (argument < lowerBound || argument > upperBound)
        {
            throw new ArgumentNotInRangeException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="ushort" /> is
    ///     not located within an undesired range.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="lowerBound">
    ///     The lower bound of the range to validate against. Must be less than or equal to <paramref name="upperBound" />.
    /// </param>
    /// <param name="upperBound">
    ///     The upper bound of the range to validate against. Must be greater than or equal to <paramref name="lowerBound" />.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentInRangeException">
    ///     The argument is not within the desired range.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void NotInRange(
        out ushort field,
        in ushort argument,
        in ushort lowerBound,
        in ushort upperBound,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (lowerBound > upperBound)
        {
            throw new ArgumentNotLessThanOrEqualToException(nameof(lowerBound));
        }

        if (argument >= lowerBound || argument <= upperBound)
        {
            throw new ArgumentInRangeException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="char" /> is
    ///     located within a desired range.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="lowerBound">
    ///     The lower bound of the range to validate against. Must be less than or equal to <paramref name="upperBound" />.
    /// </param>
    /// <param name="upperBound">
    ///     The upper bound of the range to validate against. Must be greater than or equal to <paramref name="lowerBound" />.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotInRangeException">
    ///     The argument is within the undesired range.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void InRange(
        in char argument,
        in char lowerBound,
        in char upperBound,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (lowerBound > upperBound)
        {
            throw new ArgumentNotLessThanOrEqualToException(nameof(lowerBound));
        }

        if (argument < lowerBound || argument > upperBound)
        {
            throw new ArgumentNotInRangeException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="char" /> is
    ///     not located within an undesired range.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="lowerBound">
    ///     The lower bound of the range to validate against. Must be less than or equal to <paramref name="upperBound" />.
    /// </param>
    /// <param name="upperBound">
    ///     The upper bound of the range to validate against. Must be greater than or equal to <paramref name="lowerBound" />.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentInRangeException">
    ///     The argument is not within the desired range.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void NotInRange(
        in char argument,
        in char lowerBound,
        in char upperBound,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (lowerBound > upperBound)
        {
            throw new ArgumentNotLessThanOrEqualToException(nameof(lowerBound));
        }

        if (argument >= lowerBound || argument <= upperBound)
        {
            throw new ArgumentInRangeException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="char" /> is
    ///     located within a desired range.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="lowerBound">
    ///     The lower bound of the range to validate against. Must be less than or equal to <paramref name="upperBound" />.
    /// </param>
    /// <param name="upperBound">
    ///     The upper bound of the range to validate against. Must be greater than or equal to <paramref name="lowerBound" />.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotInRangeException">
    ///     The argument is within the undesired range.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void InRange(
        out char field,
        in char argument,
        in char lowerBound,
        in char upperBound,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (lowerBound > upperBound)
        {
            throw new ArgumentNotLessThanOrEqualToException(nameof(lowerBound));
        }

        if (argument < lowerBound || argument > upperBound)
        {
            throw new ArgumentNotInRangeException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="char" /> is
    ///     not located within an undesired range.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="lowerBound">
    ///     The lower bound of the range to validate against. Must be less than or equal to <paramref name="upperBound" />.
    /// </param>
    /// <param name="upperBound">
    ///     The upper bound of the range to validate against. Must be greater than or equal to <paramref name="lowerBound" />.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentInRangeException">
    ///     The argument is not within the desired range.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void NotInRange(
        out char field,
        in char argument,
        in char lowerBound,
        in char upperBound,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (lowerBound > upperBound)
        {
            throw new ArgumentNotLessThanOrEqualToException(nameof(lowerBound));
        }

        if (argument >= lowerBound || argument <= upperBound)
        {
            throw new ArgumentInRangeException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="int" /> is
    ///     located within a desired range.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="lowerBound">
    ///     The lower bound of the range to validate against. Must be less than or equal to <paramref name="upperBound" />.
    /// </param>
    /// <param name="upperBound">
    ///     The upper bound of the range to validate against. Must be greater than or equal to <paramref name="lowerBound" />.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotInRangeException">
    ///     The argument is within the undesired range.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void InRange(
        in int argument,
        in int lowerBound,
        in int upperBound,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (lowerBound > upperBound)
        {
            throw new ArgumentNotLessThanOrEqualToException(nameof(lowerBound));
        }

        if (argument < lowerBound || argument > upperBound)
        {
            throw new ArgumentNotInRangeException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="int" /> is
    ///     not located within an undesired range.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="lowerBound">
    ///     The lower bound of the range to validate against. Must be less than or equal to <paramref name="upperBound" />.
    /// </param>
    /// <param name="upperBound">
    ///     The upper bound of the range to validate against. Must be greater than or equal to <paramref name="lowerBound" />.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentInRangeException">
    ///     The argument is not within the desired range.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void NotInRange(
        in int argument,
        in int lowerBound,
        in int upperBound,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (lowerBound > upperBound)
        {
            throw new ArgumentNotLessThanOrEqualToException(nameof(lowerBound));
        }

        if (argument >= lowerBound || argument <= upperBound)
        {
            throw new ArgumentInRangeException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="int" /> is
    ///     located within a desired range.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="lowerBound">
    ///     The lower bound of the range to validate against. Must be less than or equal to <paramref name="upperBound" />.
    /// </param>
    /// <param name="upperBound">
    ///     The upper bound of the range to validate against. Must be greater than or equal to <paramref name="lowerBound" />.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotInRangeException">
    ///     The argument is within the undesired range.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void InRange(
        out int field,
        in int argument,
        in int lowerBound,
        in int upperBound,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (lowerBound > upperBound)
        {
            throw new ArgumentNotLessThanOrEqualToException(nameof(lowerBound));
        }

        if (argument < lowerBound || argument > upperBound)
        {
            throw new ArgumentNotInRangeException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="int" /> is
    ///     not located within an undesired range.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="lowerBound">
    ///     The lower bound of the range to validate against. Must be less than or equal to <paramref name="upperBound" />.
    /// </param>
    /// <param name="upperBound">
    ///     The upper bound of the range to validate against. Must be greater than or equal to <paramref name="lowerBound" />.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentInRangeException">
    ///     The argument is not within the desired range.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void NotInRange(
        out int field,
        in int argument,
        in int lowerBound,
        in int upperBound,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (lowerBound > upperBound)
        {
            throw new ArgumentNotLessThanOrEqualToException(nameof(lowerBound));
        }

        if (argument >= lowerBound || argument <= upperBound)
        {
            throw new ArgumentInRangeException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="uint" /> is
    ///     located within a desired range.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="lowerBound">
    ///     The lower bound of the range to validate against. Must be less than or equal to <paramref name="upperBound" />.
    /// </param>
    /// <param name="upperBound">
    ///     The upper bound of the range to validate against. Must be greater than or equal to <paramref name="lowerBound" />.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotInRangeException">
    ///     The argument is within the undesired range.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void InRange(
        in uint argument,
        in uint lowerBound,
        in uint upperBound,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (lowerBound > upperBound)
        {
            throw new ArgumentNotLessThanOrEqualToException(nameof(lowerBound));
        }

        if (argument < lowerBound || argument > upperBound)
        {
            throw new ArgumentNotInRangeException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="uint" /> is
    ///     not located within an undesired range.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="lowerBound">
    ///     The lower bound of the range to validate against. Must be less than or equal to <paramref name="upperBound" />.
    /// </param>
    /// <param name="upperBound">
    ///     The upper bound of the range to validate against. Must be greater than or equal to <paramref name="lowerBound" />.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentInRangeException">
    ///     The argument is not within the desired range.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void NotInRange(
        in uint argument,
        in uint lowerBound,
        in uint upperBound,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (lowerBound > upperBound)
        {
            throw new ArgumentNotLessThanOrEqualToException(nameof(lowerBound));
        }

        if (argument >= lowerBound || argument <= upperBound)
        {
            throw new ArgumentInRangeException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="uint" /> is
    ///     located within a desired range.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="lowerBound">
    ///     The lower bound of the range to validate against. Must be less than or equal to <paramref name="upperBound" />.
    /// </param>
    /// <param name="upperBound">
    ///     The upper bound of the range to validate against. Must be greater than or equal to <paramref name="lowerBound" />.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotInRangeException">
    ///     The argument is within the undesired range.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void InRange(
        out uint field,
        in uint argument,
        in uint lowerBound,
        in uint upperBound,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (lowerBound > upperBound)
        {
            throw new ArgumentNotLessThanOrEqualToException(nameof(lowerBound));
        }

        if (argument < lowerBound || argument > upperBound)
        {
            throw new ArgumentNotInRangeException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="uint" /> is
    ///     not located within an undesired range.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="lowerBound">
    ///     The lower bound of the range to validate against. Must be less than or equal to <paramref name="upperBound" />.
    /// </param>
    /// <param name="upperBound">
    ///     The upper bound of the range to validate against. Must be greater than or equal to <paramref name="lowerBound" />.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentInRangeException">
    ///     The argument is not within the desired range.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void NotInRange(
        out uint field,
        in uint argument,
        in uint lowerBound,
        in uint upperBound,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (lowerBound > upperBound)
        {
            throw new ArgumentNotLessThanOrEqualToException(nameof(lowerBound));
        }

        if (argument >= lowerBound || argument <= upperBound)
        {
            throw new ArgumentInRangeException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="long" /> is
    ///     located within a desired range.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="lowerBound">
    ///     The lower bound of the range to validate against. Must be less than or equal to <paramref name="upperBound" />.
    /// </param>
    /// <param name="upperBound">
    ///     The upper bound of the range to validate against. Must be greater than or equal to <paramref name="lowerBound" />.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotInRangeException">
    ///     The argument is within the undesired range.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void InRange(
        in long argument,
        in long lowerBound,
        in long upperBound,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (lowerBound > upperBound)
        {
            throw new ArgumentNotLessThanOrEqualToException(nameof(lowerBound));
        }

        if (argument < lowerBound || argument > upperBound)
        {
            throw new ArgumentNotInRangeException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="long" /> is
    ///     not located within an undesired range.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="lowerBound">
    ///     The lower bound of the range to validate against. Must be less than or equal to <paramref name="upperBound" />.
    /// </param>
    /// <param name="upperBound">
    ///     The upper bound of the range to validate against. Must be greater than or equal to <paramref name="lowerBound" />.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentInRangeException">
    ///     The argument is not within the desired range.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void NotInRange(
        in long argument,
        in long lowerBound,
        in long upperBound,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (lowerBound > upperBound)
        {
            throw new ArgumentNotLessThanOrEqualToException(nameof(lowerBound));
        }

        if (argument >= lowerBound || argument <= upperBound)
        {
            throw new ArgumentInRangeException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="long" /> is
    ///     located within a desired range.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="lowerBound">
    ///     The lower bound of the range to validate against. Must be less than or equal to <paramref name="upperBound" />.
    /// </param>
    /// <param name="upperBound">
    ///     The upper bound of the range to validate against. Must be greater than or equal to <paramref name="lowerBound" />.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotInRangeException">
    ///     The argument is within the undesired range.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void InRange(
        out long field,
        in long argument,
        in long lowerBound,
        in long upperBound,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (lowerBound > upperBound)
        {
            throw new ArgumentNotLessThanOrEqualToException(nameof(lowerBound));
        }

        if (argument < lowerBound || argument > upperBound)
        {
            throw new ArgumentNotInRangeException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="long" /> is
    ///     not located within an undesired range.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="lowerBound">
    ///     The lower bound of the range to validate against. Must be less than or equal to <paramref name="upperBound" />.
    /// </param>
    /// <param name="upperBound">
    ///     The upper bound of the range to validate against. Must be greater than or equal to <paramref name="lowerBound" />.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentInRangeException">
    ///     The argument is not within the desired range.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void NotInRange(
        out long field,
        in long argument,
        in long lowerBound,
        in long upperBound,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (lowerBound > upperBound)
        {
            throw new ArgumentNotLessThanOrEqualToException(nameof(lowerBound));
        }

        if (argument >= lowerBound || argument <= upperBound)
        {
            throw new ArgumentInRangeException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="ulong" /> is
    ///     located within a desired range.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="lowerBound">
    ///     The lower bound of the range to validate against. Must be less than or equal to <paramref name="upperBound" />.
    /// </param>
    /// <param name="upperBound">
    ///     The upper bound of the range to validate against. Must be greater than or equal to <paramref name="lowerBound" />.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotInRangeException">
    ///     The argument is within the undesired range.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void InRange(
        in ulong argument,
        in ulong lowerBound,
        in ulong upperBound,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (lowerBound > upperBound)
        {
            throw new ArgumentNotLessThanOrEqualToException(nameof(lowerBound));
        }

        if (argument < lowerBound || argument > upperBound)
        {
            throw new ArgumentNotInRangeException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="ulong" /> is
    ///     not located within an undesired range.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="lowerBound">
    ///     The lower bound of the range to validate against. Must be less than or equal to <paramref name="upperBound" />.
    /// </param>
    /// <param name="upperBound">
    ///     The upper bound of the range to validate against. Must be greater than or equal to <paramref name="lowerBound" />.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentInRangeException">
    ///     The argument is not within the desired range.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void NotInRange(
        in ulong argument,
        in ulong lowerBound,
        in ulong upperBound,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (lowerBound > upperBound)
        {
            throw new ArgumentNotLessThanOrEqualToException(nameof(lowerBound));
        }

        if (argument >= lowerBound || argument <= upperBound)
        {
            throw new ArgumentInRangeException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="ulong" /> is
    ///     located within a desired range.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="lowerBound">
    ///     The lower bound of the range to validate against. Must be less than or equal to <paramref name="upperBound" />.
    /// </param>
    /// <param name="upperBound">
    ///     The upper bound of the range to validate against. Must be greater than or equal to <paramref name="lowerBound" />.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotInRangeException">
    ///     The argument is within the undesired range.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void InRange(
        out ulong field,
        in ulong argument,
        in ulong lowerBound,
        in ulong upperBound,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (lowerBound > upperBound)
        {
            throw new ArgumentNotLessThanOrEqualToException(nameof(lowerBound));
        }

        if (argument < lowerBound || argument > upperBound)
        {
            throw new ArgumentNotInRangeException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="ulong" /> is
    ///     not located within an undesired range.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="lowerBound">
    ///     The lower bound of the range to validate against. Must be less than or equal to <paramref name="upperBound" />.
    /// </param>
    /// <param name="upperBound">
    ///     The upper bound of the range to validate against. Must be greater than or equal to <paramref name="lowerBound" />.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentInRangeException">
    ///     The argument is not within the desired range.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void NotInRange(
        out ulong field,
        in ulong argument,
        in ulong lowerBound,
        in ulong upperBound,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (lowerBound > upperBound)
        {
            throw new ArgumentNotLessThanOrEqualToException(nameof(lowerBound));
        }

        if (argument >= lowerBound || argument <= upperBound)
        {
            throw new ArgumentInRangeException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="float" /> is
    ///     located within a desired range.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="lowerBound">
    ///     The lower bound of the range to validate against. Must be less than or equal to <paramref name="upperBound" />.
    /// </param>
    /// <param name="upperBound">
    ///     The upper bound of the range to validate against. Must be greater than or equal to <paramref name="lowerBound" />.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotInRangeException">
    ///     The argument is within the undesired range.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void InRange(
        in float argument,
        in float lowerBound,
        in float upperBound,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (lowerBound > upperBound)
        {
            throw new ArgumentNotLessThanOrEqualToException(nameof(lowerBound));
        }

        if (argument < lowerBound || argument > upperBound)
        {
            throw new ArgumentNotInRangeException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="float" /> is
    ///     not located within an undesired range.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="lowerBound">
    ///     The lower bound of the range to validate against. Must be less than or equal to <paramref name="upperBound" />.
    /// </param>
    /// <param name="upperBound">
    ///     The upper bound of the range to validate against. Must be greater than or equal to <paramref name="lowerBound" />.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentInRangeException">
    ///     The argument is not within the desired range.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void NotInRange(
        in float argument,
        in float lowerBound,
        in float upperBound,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (lowerBound > upperBound)
        {
            throw new ArgumentNotLessThanOrEqualToException(nameof(lowerBound));
        }

        if (argument >= lowerBound || argument <= upperBound)
        {
            throw new ArgumentInRangeException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="float" /> is
    ///     located within a desired range.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="lowerBound">
    ///     The lower bound of the range to validate against. Must be less than or equal to <paramref name="upperBound" />.
    /// </param>
    /// <param name="upperBound">
    ///     The upper bound of the range to validate against. Must be greater than or equal to <paramref name="lowerBound" />.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotInRangeException">
    ///     The argument is within the undesired range.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void InRange(
        out float field,
        in float argument,
        in float lowerBound,
        in float upperBound,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (lowerBound > upperBound)
        {
            throw new ArgumentNotLessThanOrEqualToException(nameof(lowerBound));
        }

        if (argument < lowerBound || argument > upperBound)
        {
            throw new ArgumentNotInRangeException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="float" /> is
    ///     not located within an undesired range.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="lowerBound">
    ///     The lower bound of the range to validate against. Must be less than or equal to <paramref name="upperBound" />.
    /// </param>
    /// <param name="upperBound">
    ///     The upper bound of the range to validate against. Must be greater than or equal to <paramref name="lowerBound" />.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentInRangeException">
    ///     The argument is not within the desired range.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void NotInRange(
        out float field,
        in float argument,
        in float lowerBound,
        in float upperBound,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (lowerBound > upperBound)
        {
            throw new ArgumentNotLessThanOrEqualToException(nameof(lowerBound));
        }

        if (argument >= lowerBound || argument <= upperBound)
        {
            throw new ArgumentInRangeException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="double" /> is
    ///     located within a desired range.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="lowerBound">
    ///     The lower bound of the range to validate against. Must be less than or equal to <paramref name="upperBound" />.
    /// </param>
    /// <param name="upperBound">
    ///     The upper bound of the range to validate against. Must be greater than or equal to <paramref name="lowerBound" />.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotInRangeException">
    ///     The argument is within the undesired range.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void InRange(
        in double argument,
        in double lowerBound,
        in double upperBound,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (lowerBound > upperBound)
        {
            throw new ArgumentNotLessThanOrEqualToException(nameof(lowerBound));
        }

        if (argument < lowerBound || argument > upperBound)
        {
            throw new ArgumentNotInRangeException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="double" /> is
    ///     not located within an undesired range.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="lowerBound">
    ///     The lower bound of the range to validate against. Must be less than or equal to <paramref name="upperBound" />.
    /// </param>
    /// <param name="upperBound">
    ///     The upper bound of the range to validate against. Must be greater than or equal to <paramref name="lowerBound" />.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentInRangeException">
    ///     The argument is not within the desired range.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void NotInRange(
        in double argument,
        in double lowerBound,
        in double upperBound,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (lowerBound > upperBound)
        {
            throw new ArgumentNotLessThanOrEqualToException(nameof(lowerBound));
        }

        if (argument >= lowerBound || argument <= upperBound)
        {
            throw new ArgumentInRangeException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="double" /> is
    ///     located within a desired range.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="lowerBound">
    ///     The lower bound of the range to validate against. Must be less than or equal to <paramref name="upperBound" />.
    /// </param>
    /// <param name="upperBound">
    ///     The upper bound of the range to validate against. Must be greater than or equal to <paramref name="lowerBound" />.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotInRangeException">
    ///     The argument is within the undesired range.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void InRange(
        out double field,
        in double argument,
        in double lowerBound,
        in double upperBound,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (lowerBound > upperBound)
        {
            throw new ArgumentNotLessThanOrEqualToException(nameof(lowerBound));
        }

        if (argument < lowerBound || argument > upperBound)
        {
            throw new ArgumentNotInRangeException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="double" /> is
    ///     not located within an undesired range.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="lowerBound">
    ///     The lower bound of the range to validate against. Must be less than or equal to <paramref name="upperBound" />.
    /// </param>
    /// <param name="upperBound">
    ///     The upper bound of the range to validate against. Must be greater than or equal to <paramref name="lowerBound" />.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentInRangeException">
    ///     The argument is not within the desired range.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void NotInRange(
        out double field,
        in double argument,
        in double lowerBound,
        in double upperBound,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (lowerBound > upperBound)
        {
            throw new ArgumentNotLessThanOrEqualToException(nameof(lowerBound));
        }

        if (argument >= lowerBound || argument <= upperBound)
        {
            throw new ArgumentInRangeException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="decimal" /> is
    ///     located within a desired range.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="lowerBound">
    ///     The lower bound of the range to validate against. Must be less than or equal to <paramref name="upperBound" />.
    /// </param>
    /// <param name="upperBound">
    ///     The upper bound of the range to validate against. Must be greater than or equal to <paramref name="lowerBound" />.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotInRangeException">
    ///     The argument is within the undesired range.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void InRange(
        in decimal argument,
        in decimal lowerBound,
        in decimal upperBound,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (lowerBound > upperBound)
        {
            throw new ArgumentNotLessThanOrEqualToException(nameof(lowerBound));
        }

        if (argument < lowerBound || argument > upperBound)
        {
            throw new ArgumentNotInRangeException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="decimal" /> is
    ///     not located within an undesired range.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="lowerBound">
    ///     The lower bound of the range to validate against. Must be less than or equal to <paramref name="upperBound" />.
    /// </param>
    /// <param name="upperBound">
    ///     The upper bound of the range to validate against. Must be greater than or equal to <paramref name="lowerBound" />.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentInRangeException">
    ///     The argument is not within the desired range.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void NotInRange(
        in decimal argument,
        in decimal lowerBound,
        in decimal upperBound,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (lowerBound > upperBound)
        {
            throw new ArgumentNotLessThanOrEqualToException(nameof(lowerBound));
        }

        if (argument >= lowerBound || argument <= upperBound)
        {
            throw new ArgumentInRangeException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="decimal" /> is
    ///     located within a desired range.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="lowerBound">
    ///     The lower bound of the range to validate against. Must be less than or equal to <paramref name="upperBound" />.
    /// </param>
    /// <param name="upperBound">
    ///     The upper bound of the range to validate against. Must be greater than or equal to <paramref name="lowerBound" />.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotInRangeException">
    ///     The argument is within the undesired range.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void InRange(
        out decimal field,
        in decimal argument,
        in decimal lowerBound,
        in decimal upperBound,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (lowerBound > upperBound)
        {
            throw new ArgumentNotLessThanOrEqualToException(nameof(lowerBound));
        }

        if (argument < lowerBound || argument > upperBound)
        {
            throw new ArgumentNotInRangeException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="decimal" /> is
    ///     not located within an undesired range.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="lowerBound">
    ///     The lower bound of the range to validate against. Must be less than or equal to <paramref name="upperBound" />.
    /// </param>
    /// <param name="upperBound">
    ///     The upper bound of the range to validate against. Must be greater than or equal to <paramref name="lowerBound" />.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentInRangeException">
    ///     The argument is not within the desired range.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void NotInRange(
        out decimal field,
        in decimal argument,
        in decimal lowerBound,
        in decimal upperBound,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (lowerBound > upperBound)
        {
            throw new ArgumentNotLessThanOrEqualToException(nameof(lowerBound));
        }

        if (argument >= lowerBound || argument <= upperBound)
        {
            throw new ArgumentInRangeException(argumentName);
        }

        field = argument;
    }
}