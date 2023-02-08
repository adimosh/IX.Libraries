using System.Runtime.CompilerServices;

namespace IX.Core.Contracts;

/// <summary>
///     Methods for approximating the works of contract-oriented programming.
/// </summary>
public static partial class Requires
{
    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="byte" /> is
    ///     less than a desired value.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotLessThanException">
    ///     The argument is not less than to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LessThan(
        in byte argument,
        in byte desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument >= desiredComparisonValue)
        {
            throw new ArgumentNotLessThanException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="byte" /> is
    ///     less than or equal to a desired value.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotLessThanOrEqualToException">
    ///     The argument is not less than or equal to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LessThanOrEqualTo(
        in byte argument,
        in byte desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument > desiredComparisonValue)
        {
            throw new ArgumentNotLessThanOrEqualToException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="byte" /> is
    ///     greater than a desired value.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotGreaterThanException">
    ///     The argument is not greater than to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void GreaterThan(
        in byte argument,
        in byte desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument <= desiredComparisonValue)
        {
            throw new ArgumentNotGreaterThanException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="byte" /> is
    ///     greater than or equal to a desired value.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotGreaterThanOrEqualToException">
    ///     The argument is not greater than or equal to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void GreaterThanOrEqualTo(
        in byte argument,
        in byte desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument < desiredComparisonValue)
        {
            throw new ArgumentNotGreaterThanOrEqualToException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="byte" /> is
    ///     less than a desired value.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotLessThanException">
    ///     The argument is not less than to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LessThan(
        out byte field,
        in byte argument,
        in byte desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument >= desiredComparisonValue)
        {
            throw new ArgumentNotLessThanException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="byte" /> is
    ///     less than or equal to a desired value.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotLessThanOrEqualToException">
    ///     The argument is not less than or equal to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LessThanOrEqualTo(
        out byte field,
        in byte argument,
        in byte desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument > desiredComparisonValue)
        {
            throw new ArgumentNotLessThanOrEqualToException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="byte" /> is
    ///     greater than a desired value.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotGreaterThanException">
    ///     The argument is not greater than to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void GreaterThan(
        out byte field,
        in byte argument,
        in byte desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument <= desiredComparisonValue)
        {
            throw new ArgumentNotGreaterThanException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="byte" /> is
    ///     greater than or equal to a desired value.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotGreaterThanOrEqualToException">
    ///     The argument is not greater than or equal to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void GreaterThanOrEqualTo(
        out byte field,
        in byte argument,
        in byte desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument < desiredComparisonValue)
        {
            throw new ArgumentNotGreaterThanOrEqualToException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="sbyte" /> is
    ///     less than a desired value.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotLessThanException">
    ///     The argument is not less than to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LessThan(
        in sbyte argument,
        in sbyte desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument >= desiredComparisonValue)
        {
            throw new ArgumentNotLessThanException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="sbyte" /> is
    ///     less than or equal to a desired value.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotLessThanOrEqualToException">
    ///     The argument is not less than or equal to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LessThanOrEqualTo(
        in sbyte argument,
        in sbyte desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument > desiredComparisonValue)
        {
            throw new ArgumentNotLessThanOrEqualToException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="sbyte" /> is
    ///     greater than a desired value.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotGreaterThanException">
    ///     The argument is not greater than to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void GreaterThan(
        in sbyte argument,
        in sbyte desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument <= desiredComparisonValue)
        {
            throw new ArgumentNotGreaterThanException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="sbyte" /> is
    ///     greater than or equal to a desired value.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotGreaterThanOrEqualToException">
    ///     The argument is not greater than or equal to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void GreaterThanOrEqualTo(
        in sbyte argument,
        in sbyte desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument < desiredComparisonValue)
        {
            throw new ArgumentNotGreaterThanOrEqualToException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="sbyte" /> is
    ///     less than a desired value.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotLessThanException">
    ///     The argument is not less than to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LessThan(
        out sbyte field,
        in sbyte argument,
        in sbyte desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument >= desiredComparisonValue)
        {
            throw new ArgumentNotLessThanException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="sbyte" /> is
    ///     less than or equal to a desired value.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotLessThanOrEqualToException">
    ///     The argument is not less than or equal to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LessThanOrEqualTo(
        out sbyte field,
        in sbyte argument,
        in sbyte desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument > desiredComparisonValue)
        {
            throw new ArgumentNotLessThanOrEqualToException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="sbyte" /> is
    ///     greater than a desired value.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotGreaterThanException">
    ///     The argument is not greater than to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void GreaterThan(
        out sbyte field,
        in sbyte argument,
        in sbyte desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument <= desiredComparisonValue)
        {
            throw new ArgumentNotGreaterThanException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="sbyte" /> is
    ///     greater than or equal to a desired value.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotGreaterThanOrEqualToException">
    ///     The argument is not greater than or equal to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void GreaterThanOrEqualTo(
        out sbyte field,
        in sbyte argument,
        in sbyte desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument < desiredComparisonValue)
        {
            throw new ArgumentNotGreaterThanOrEqualToException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="short" /> is
    ///     less than a desired value.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotLessThanException">
    ///     The argument is not less than to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LessThan(
        in short argument,
        in short desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument >= desiredComparisonValue)
        {
            throw new ArgumentNotLessThanException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="short" /> is
    ///     less than or equal to a desired value.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotLessThanOrEqualToException">
    ///     The argument is not less than or equal to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LessThanOrEqualTo(
        in short argument,
        in short desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument > desiredComparisonValue)
        {
            throw new ArgumentNotLessThanOrEqualToException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="short" /> is
    ///     greater than a desired value.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotGreaterThanException">
    ///     The argument is not greater than to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void GreaterThan(
        in short argument,
        in short desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument <= desiredComparisonValue)
        {
            throw new ArgumentNotGreaterThanException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="short" /> is
    ///     greater than or equal to a desired value.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotGreaterThanOrEqualToException">
    ///     The argument is not greater than or equal to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void GreaterThanOrEqualTo(
        in short argument,
        in short desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument < desiredComparisonValue)
        {
            throw new ArgumentNotGreaterThanOrEqualToException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="short" /> is
    ///     less than a desired value.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotLessThanException">
    ///     The argument is not less than to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LessThan(
        out short field,
        in short argument,
        in short desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument >= desiredComparisonValue)
        {
            throw new ArgumentNotLessThanException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="short" /> is
    ///     less than or equal to a desired value.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotLessThanOrEqualToException">
    ///     The argument is not less than or equal to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LessThanOrEqualTo(
        out short field,
        in short argument,
        in short desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument > desiredComparisonValue)
        {
            throw new ArgumentNotLessThanOrEqualToException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="short" /> is
    ///     greater than a desired value.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotGreaterThanException">
    ///     The argument is not greater than to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void GreaterThan(
        out short field,
        in short argument,
        in short desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument <= desiredComparisonValue)
        {
            throw new ArgumentNotGreaterThanException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="short" /> is
    ///     greater than or equal to a desired value.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotGreaterThanOrEqualToException">
    ///     The argument is not greater than or equal to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void GreaterThanOrEqualTo(
        out short field,
        in short argument,
        in short desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument < desiredComparisonValue)
        {
            throw new ArgumentNotGreaterThanOrEqualToException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="ushort" /> is
    ///     less than a desired value.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotLessThanException">
    ///     The argument is not less than to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LessThan(
        in ushort argument,
        in ushort desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument >= desiredComparisonValue)
        {
            throw new ArgumentNotLessThanException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="ushort" /> is
    ///     less than or equal to a desired value.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotLessThanOrEqualToException">
    ///     The argument is not less than or equal to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LessThanOrEqualTo(
        in ushort argument,
        in ushort desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument > desiredComparisonValue)
        {
            throw new ArgumentNotLessThanOrEqualToException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="ushort" /> is
    ///     greater than a desired value.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotGreaterThanException">
    ///     The argument is not greater than to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void GreaterThan(
        in ushort argument,
        in ushort desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument <= desiredComparisonValue)
        {
            throw new ArgumentNotGreaterThanException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="ushort" /> is
    ///     greater than or equal to a desired value.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotGreaterThanOrEqualToException">
    ///     The argument is not greater than or equal to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void GreaterThanOrEqualTo(
        in ushort argument,
        in ushort desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument < desiredComparisonValue)
        {
            throw new ArgumentNotGreaterThanOrEqualToException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="ushort" /> is
    ///     less than a desired value.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotLessThanException">
    ///     The argument is not less than to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LessThan(
        out ushort field,
        in ushort argument,
        in ushort desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument >= desiredComparisonValue)
        {
            throw new ArgumentNotLessThanException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="ushort" /> is
    ///     less than or equal to a desired value.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotLessThanOrEqualToException">
    ///     The argument is not less than or equal to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LessThanOrEqualTo(
        out ushort field,
        in ushort argument,
        in ushort desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument > desiredComparisonValue)
        {
            throw new ArgumentNotLessThanOrEqualToException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="ushort" /> is
    ///     greater than a desired value.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotGreaterThanException">
    ///     The argument is not greater than to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void GreaterThan(
        out ushort field,
        in ushort argument,
        in ushort desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument <= desiredComparisonValue)
        {
            throw new ArgumentNotGreaterThanException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="ushort" /> is
    ///     greater than or equal to a desired value.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotGreaterThanOrEqualToException">
    ///     The argument is not greater than or equal to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void GreaterThanOrEqualTo(
        out ushort field,
        in ushort argument,
        in ushort desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument < desiredComparisonValue)
        {
            throw new ArgumentNotGreaterThanOrEqualToException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="char" /> is
    ///     less than a desired value.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotLessThanException">
    ///     The argument is not less than to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LessThan(
        in char argument,
        in char desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument >= desiredComparisonValue)
        {
            throw new ArgumentNotLessThanException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="char" /> is
    ///     less than or equal to a desired value.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotLessThanOrEqualToException">
    ///     The argument is not less than or equal to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LessThanOrEqualTo(
        in char argument,
        in char desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument > desiredComparisonValue)
        {
            throw new ArgumentNotLessThanOrEqualToException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="char" /> is
    ///     greater than a desired value.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotGreaterThanException">
    ///     The argument is not greater than to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void GreaterThan(
        in char argument,
        in char desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument <= desiredComparisonValue)
        {
            throw new ArgumentNotGreaterThanException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="char" /> is
    ///     greater than or equal to a desired value.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotGreaterThanOrEqualToException">
    ///     The argument is not greater than or equal to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void GreaterThanOrEqualTo(
        in char argument,
        in char desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument < desiredComparisonValue)
        {
            throw new ArgumentNotGreaterThanOrEqualToException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="char" /> is
    ///     less than a desired value.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotLessThanException">
    ///     The argument is not less than to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LessThan(
        out char field,
        in char argument,
        in char desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument >= desiredComparisonValue)
        {
            throw new ArgumentNotLessThanException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="char" /> is
    ///     less than or equal to a desired value.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotLessThanOrEqualToException">
    ///     The argument is not less than or equal to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LessThanOrEqualTo(
        out char field,
        in char argument,
        in char desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument > desiredComparisonValue)
        {
            throw new ArgumentNotLessThanOrEqualToException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="char" /> is
    ///     greater than a desired value.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotGreaterThanException">
    ///     The argument is not greater than to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void GreaterThan(
        out char field,
        in char argument,
        in char desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument <= desiredComparisonValue)
        {
            throw new ArgumentNotGreaterThanException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="char" /> is
    ///     greater than or equal to a desired value.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotGreaterThanOrEqualToException">
    ///     The argument is not greater than or equal to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void GreaterThanOrEqualTo(
        out char field,
        in char argument,
        in char desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument < desiredComparisonValue)
        {
            throw new ArgumentNotGreaterThanOrEqualToException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="int" /> is
    ///     less than a desired value.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotLessThanException">
    ///     The argument is not less than to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LessThan(
        in int argument,
        in int desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument >= desiredComparisonValue)
        {
            throw new ArgumentNotLessThanException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="int" /> is
    ///     less than or equal to a desired value.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotLessThanOrEqualToException">
    ///     The argument is not less than or equal to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LessThanOrEqualTo(
        in int argument,
        in int desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument > desiredComparisonValue)
        {
            throw new ArgumentNotLessThanOrEqualToException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="int" /> is
    ///     greater than a desired value.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotGreaterThanException">
    ///     The argument is not greater than to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void GreaterThan(
        in int argument,
        in int desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument <= desiredComparisonValue)
        {
            throw new ArgumentNotGreaterThanException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="int" /> is
    ///     greater than or equal to a desired value.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotGreaterThanOrEqualToException">
    ///     The argument is not greater than or equal to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void GreaterThanOrEqualTo(
        in int argument,
        in int desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument < desiredComparisonValue)
        {
            throw new ArgumentNotGreaterThanOrEqualToException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="int" /> is
    ///     less than a desired value.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotLessThanException">
    ///     The argument is not less than to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LessThan(
        out int field,
        in int argument,
        in int desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument >= desiredComparisonValue)
        {
            throw new ArgumentNotLessThanException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="int" /> is
    ///     less than or equal to a desired value.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotLessThanOrEqualToException">
    ///     The argument is not less than or equal to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LessThanOrEqualTo(
        out int field,
        in int argument,
        in int desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument > desiredComparisonValue)
        {
            throw new ArgumentNotLessThanOrEqualToException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="int" /> is
    ///     greater than a desired value.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotGreaterThanException">
    ///     The argument is not greater than to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void GreaterThan(
        out int field,
        in int argument,
        in int desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument <= desiredComparisonValue)
        {
            throw new ArgumentNotGreaterThanException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="int" /> is
    ///     greater than or equal to a desired value.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotGreaterThanOrEqualToException">
    ///     The argument is not greater than or equal to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void GreaterThanOrEqualTo(
        out int field,
        in int argument,
        in int desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument < desiredComparisonValue)
        {
            throw new ArgumentNotGreaterThanOrEqualToException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="uint" /> is
    ///     less than a desired value.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotLessThanException">
    ///     The argument is not less than to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LessThan(
        in uint argument,
        in uint desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument >= desiredComparisonValue)
        {
            throw new ArgumentNotLessThanException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="uint" /> is
    ///     less than or equal to a desired value.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotLessThanOrEqualToException">
    ///     The argument is not less than or equal to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LessThanOrEqualTo(
        in uint argument,
        in uint desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument > desiredComparisonValue)
        {
            throw new ArgumentNotLessThanOrEqualToException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="uint" /> is
    ///     greater than a desired value.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotGreaterThanException">
    ///     The argument is not greater than to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void GreaterThan(
        in uint argument,
        in uint desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument <= desiredComparisonValue)
        {
            throw new ArgumentNotGreaterThanException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="uint" /> is
    ///     greater than or equal to a desired value.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotGreaterThanOrEqualToException">
    ///     The argument is not greater than or equal to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void GreaterThanOrEqualTo(
        in uint argument,
        in uint desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument < desiredComparisonValue)
        {
            throw new ArgumentNotGreaterThanOrEqualToException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="uint" /> is
    ///     less than a desired value.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotLessThanException">
    ///     The argument is not less than to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LessThan(
        out uint field,
        in uint argument,
        in uint desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument >= desiredComparisonValue)
        {
            throw new ArgumentNotLessThanException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="uint" /> is
    ///     less than or equal to a desired value.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotLessThanOrEqualToException">
    ///     The argument is not less than or equal to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LessThanOrEqualTo(
        out uint field,
        in uint argument,
        in uint desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument > desiredComparisonValue)
        {
            throw new ArgumentNotLessThanOrEqualToException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="uint" /> is
    ///     greater than a desired value.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotGreaterThanException">
    ///     The argument is not greater than to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void GreaterThan(
        out uint field,
        in uint argument,
        in uint desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument <= desiredComparisonValue)
        {
            throw new ArgumentNotGreaterThanException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="uint" /> is
    ///     greater than or equal to a desired value.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotGreaterThanOrEqualToException">
    ///     The argument is not greater than or equal to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void GreaterThanOrEqualTo(
        out uint field,
        in uint argument,
        in uint desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument < desiredComparisonValue)
        {
            throw new ArgumentNotGreaterThanOrEqualToException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="long" /> is
    ///     less than a desired value.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotLessThanException">
    ///     The argument is not less than to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LessThan(
        in long argument,
        in long desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument >= desiredComparisonValue)
        {
            throw new ArgumentNotLessThanException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="long" /> is
    ///     less than or equal to a desired value.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotLessThanOrEqualToException">
    ///     The argument is not less than or equal to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LessThanOrEqualTo(
        in long argument,
        in long desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument > desiredComparisonValue)
        {
            throw new ArgumentNotLessThanOrEqualToException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="long" /> is
    ///     greater than a desired value.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotGreaterThanException">
    ///     The argument is not greater than to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void GreaterThan(
        in long argument,
        in long desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument <= desiredComparisonValue)
        {
            throw new ArgumentNotGreaterThanException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="long" /> is
    ///     greater than or equal to a desired value.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotGreaterThanOrEqualToException">
    ///     The argument is not greater than or equal to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void GreaterThanOrEqualTo(
        in long argument,
        in long desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument < desiredComparisonValue)
        {
            throw new ArgumentNotGreaterThanOrEqualToException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="long" /> is
    ///     less than a desired value.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotLessThanException">
    ///     The argument is not less than to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LessThan(
        out long field,
        in long argument,
        in long desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument >= desiredComparisonValue)
        {
            throw new ArgumentNotLessThanException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="long" /> is
    ///     less than or equal to a desired value.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotLessThanOrEqualToException">
    ///     The argument is not less than or equal to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LessThanOrEqualTo(
        out long field,
        in long argument,
        in long desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument > desiredComparisonValue)
        {
            throw new ArgumentNotLessThanOrEqualToException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="long" /> is
    ///     greater than a desired value.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotGreaterThanException">
    ///     The argument is not greater than to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void GreaterThan(
        out long field,
        in long argument,
        in long desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument <= desiredComparisonValue)
        {
            throw new ArgumentNotGreaterThanException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="long" /> is
    ///     greater than or equal to a desired value.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotGreaterThanOrEqualToException">
    ///     The argument is not greater than or equal to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void GreaterThanOrEqualTo(
        out long field,
        in long argument,
        in long desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument < desiredComparisonValue)
        {
            throw new ArgumentNotGreaterThanOrEqualToException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="ulong" /> is
    ///     less than a desired value.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotLessThanException">
    ///     The argument is not less than to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LessThan(
        in ulong argument,
        in ulong desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument >= desiredComparisonValue)
        {
            throw new ArgumentNotLessThanException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="ulong" /> is
    ///     less than or equal to a desired value.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotLessThanOrEqualToException">
    ///     The argument is not less than or equal to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LessThanOrEqualTo(
        in ulong argument,
        in ulong desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument > desiredComparisonValue)
        {
            throw new ArgumentNotLessThanOrEqualToException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="ulong" /> is
    ///     greater than a desired value.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotGreaterThanException">
    ///     The argument is not greater than to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void GreaterThan(
        in ulong argument,
        in ulong desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument <= desiredComparisonValue)
        {
            throw new ArgumentNotGreaterThanException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="ulong" /> is
    ///     greater than or equal to a desired value.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotGreaterThanOrEqualToException">
    ///     The argument is not greater than or equal to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void GreaterThanOrEqualTo(
        in ulong argument,
        in ulong desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument < desiredComparisonValue)
        {
            throw new ArgumentNotGreaterThanOrEqualToException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="ulong" /> is
    ///     less than a desired value.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotLessThanException">
    ///     The argument is not less than to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LessThan(
        out ulong field,
        in ulong argument,
        in ulong desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument >= desiredComparisonValue)
        {
            throw new ArgumentNotLessThanException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="ulong" /> is
    ///     less than or equal to a desired value.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotLessThanOrEqualToException">
    ///     The argument is not less than or equal to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LessThanOrEqualTo(
        out ulong field,
        in ulong argument,
        in ulong desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument > desiredComparisonValue)
        {
            throw new ArgumentNotLessThanOrEqualToException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="ulong" /> is
    ///     greater than a desired value.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotGreaterThanException">
    ///     The argument is not greater than to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void GreaterThan(
        out ulong field,
        in ulong argument,
        in ulong desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument <= desiredComparisonValue)
        {
            throw new ArgumentNotGreaterThanException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="ulong" /> is
    ///     greater than or equal to a desired value.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotGreaterThanOrEqualToException">
    ///     The argument is not greater than or equal to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void GreaterThanOrEqualTo(
        out ulong field,
        in ulong argument,
        in ulong desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument < desiredComparisonValue)
        {
            throw new ArgumentNotGreaterThanOrEqualToException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="float" /> is
    ///     less than a desired value.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotLessThanException">
    ///     The argument is not less than to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LessThan(
        in float argument,
        in float desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument >= desiredComparisonValue)
        {
            throw new ArgumentNotLessThanException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="float" /> is
    ///     less than or equal to a desired value.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotLessThanOrEqualToException">
    ///     The argument is not less than or equal to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LessThanOrEqualTo(
        in float argument,
        in float desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument > desiredComparisonValue)
        {
            throw new ArgumentNotLessThanOrEqualToException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="float" /> is
    ///     greater than a desired value.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotGreaterThanException">
    ///     The argument is not greater than to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void GreaterThan(
        in float argument,
        in float desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument <= desiredComparisonValue)
        {
            throw new ArgumentNotGreaterThanException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="float" /> is
    ///     greater than or equal to a desired value.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotGreaterThanOrEqualToException">
    ///     The argument is not greater than or equal to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void GreaterThanOrEqualTo(
        in float argument,
        in float desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument < desiredComparisonValue)
        {
            throw new ArgumentNotGreaterThanOrEqualToException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="float" /> is
    ///     less than a desired value.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotLessThanException">
    ///     The argument is not less than to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LessThan(
        out float field,
        in float argument,
        in float desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument >= desiredComparisonValue)
        {
            throw new ArgumentNotLessThanException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="float" /> is
    ///     less than or equal to a desired value.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotLessThanOrEqualToException">
    ///     The argument is not less than or equal to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LessThanOrEqualTo(
        out float field,
        in float argument,
        in float desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument > desiredComparisonValue)
        {
            throw new ArgumentNotLessThanOrEqualToException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="float" /> is
    ///     greater than a desired value.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotGreaterThanException">
    ///     The argument is not greater than to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void GreaterThan(
        out float field,
        in float argument,
        in float desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument <= desiredComparisonValue)
        {
            throw new ArgumentNotGreaterThanException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="float" /> is
    ///     greater than or equal to a desired value.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotGreaterThanOrEqualToException">
    ///     The argument is not greater than or equal to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void GreaterThanOrEqualTo(
        out float field,
        in float argument,
        in float desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument < desiredComparisonValue)
        {
            throw new ArgumentNotGreaterThanOrEqualToException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="double" /> is
    ///     less than a desired value.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotLessThanException">
    ///     The argument is not less than to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LessThan(
        in double argument,
        in double desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument >= desiredComparisonValue)
        {
            throw new ArgumentNotLessThanException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="double" /> is
    ///     less than or equal to a desired value.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotLessThanOrEqualToException">
    ///     The argument is not less than or equal to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LessThanOrEqualTo(
        in double argument,
        in double desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument > desiredComparisonValue)
        {
            throw new ArgumentNotLessThanOrEqualToException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="double" /> is
    ///     greater than a desired value.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotGreaterThanException">
    ///     The argument is not greater than to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void GreaterThan(
        in double argument,
        in double desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument <= desiredComparisonValue)
        {
            throw new ArgumentNotGreaterThanException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="double" /> is
    ///     greater than or equal to a desired value.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotGreaterThanOrEqualToException">
    ///     The argument is not greater than or equal to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void GreaterThanOrEqualTo(
        in double argument,
        in double desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument < desiredComparisonValue)
        {
            throw new ArgumentNotGreaterThanOrEqualToException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="double" /> is
    ///     less than a desired value.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotLessThanException">
    ///     The argument is not less than to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LessThan(
        out double field,
        in double argument,
        in double desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument >= desiredComparisonValue)
        {
            throw new ArgumentNotLessThanException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="double" /> is
    ///     less than or equal to a desired value.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotLessThanOrEqualToException">
    ///     The argument is not less than or equal to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LessThanOrEqualTo(
        out double field,
        in double argument,
        in double desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument > desiredComparisonValue)
        {
            throw new ArgumentNotLessThanOrEqualToException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="double" /> is
    ///     greater than a desired value.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotGreaterThanException">
    ///     The argument is not greater than to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void GreaterThan(
        out double field,
        in double argument,
        in double desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument <= desiredComparisonValue)
        {
            throw new ArgumentNotGreaterThanException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="double" /> is
    ///     greater than or equal to a desired value.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotGreaterThanOrEqualToException">
    ///     The argument is not greater than or equal to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void GreaterThanOrEqualTo(
        out double field,
        in double argument,
        in double desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument < desiredComparisonValue)
        {
            throw new ArgumentNotGreaterThanOrEqualToException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="decimal" /> is
    ///     less than a desired value.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotLessThanException">
    ///     The argument is not less than to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LessThan(
        in decimal argument,
        in decimal desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument >= desiredComparisonValue)
        {
            throw new ArgumentNotLessThanException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="decimal" /> is
    ///     less than or equal to a desired value.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotLessThanOrEqualToException">
    ///     The argument is not less than or equal to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LessThanOrEqualTo(
        in decimal argument,
        in decimal desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument > desiredComparisonValue)
        {
            throw new ArgumentNotLessThanOrEqualToException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="decimal" /> is
    ///     greater than a desired value.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotGreaterThanException">
    ///     The argument is not greater than to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void GreaterThan(
        in decimal argument,
        in decimal desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument <= desiredComparisonValue)
        {
            throw new ArgumentNotGreaterThanException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="decimal" /> is
    ///     greater than or equal to a desired value.
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotGreaterThanOrEqualToException">
    ///     The argument is not greater than or equal to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void GreaterThanOrEqualTo(
        in decimal argument,
        in decimal desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument < desiredComparisonValue)
        {
            throw new ArgumentNotGreaterThanOrEqualToException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="decimal" /> is
    ///     less than a desired value.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotLessThanException">
    ///     The argument is not less than to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LessThan(
        out decimal field,
        in decimal argument,
        in decimal desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument >= desiredComparisonValue)
        {
            throw new ArgumentNotLessThanException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="decimal" /> is
    ///     less than or equal to a desired value.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotLessThanOrEqualToException">
    ///     The argument is not less than or equal to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LessThanOrEqualTo(
        out decimal field,
        in decimal argument,
        in decimal desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument > desiredComparisonValue)
        {
            throw new ArgumentNotLessThanOrEqualToException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="decimal" /> is
    ///     greater than a desired value.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotGreaterThanException">
    ///     The argument is not greater than to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void GreaterThan(
        out decimal field,
        in decimal argument,
        in decimal desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument <= desiredComparisonValue)
        {
            throw new ArgumentNotGreaterThanException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="decimal" /> is
    ///     greater than or equal to a desired value.
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="desiredComparisonValue">
    ///     The desired comparison value.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotGreaterThanOrEqualToException">
    ///     The argument is not greater than or equal to the desired comparison value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void GreaterThanOrEqualTo(
        out decimal field,
        in decimal argument,
        in decimal desiredComparisonValue,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument < desiredComparisonValue)
        {
            throw new ArgumentNotGreaterThanOrEqualToException(argumentName);
        }

        field = argument;
    }
}