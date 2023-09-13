using System.Runtime.CompilerServices;

namespace IX.Library.Contracts;

/// <summary>
///     Methods for approximating the works of contract-oriented programming.
/// </summary>
public static partial class Requires
{
    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="byte" /> is
    ///     positive (greater than zero).
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is equal to 0.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Positive(
        in byte argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument == 0)
        {
            throw new ArgumentNotPositiveIntegerException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="byte" /> is
    ///     positive (greater than zero).
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is equal to 0.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Positive(
        out byte field,
        in byte argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument == 0)
        {
            throw new ArgumentNotPositiveIntegerException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="sbyte" /> is
    ///     positive (greater than zero).
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is less than or equal to 0.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Positive(
        in sbyte argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument <= 0)
        {
            throw new ArgumentNotPositiveIntegerException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="sbyte" /> is
    ///     non-negative (greater than or equal to zero).
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is less than 0.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void NonNegative(
        in sbyte argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument < 0)
        {
            throw new ArgumentNotPositiveIntegerException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="sbyte" /> is
    ///     positive (greater than zero).
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is less than or equal to 0.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Positive(
        out sbyte field,
        in sbyte argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument <= 0)
        {
            throw new ArgumentNotPositiveIntegerException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="sbyte" /> is
    ///     non-negative (greater than or equal to zero).
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is less than 0.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void NonNegative(
        out sbyte field,
        in sbyte argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument < 0)
        {
            throw new ArgumentNotPositiveIntegerException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="short" /> is
    ///     positive (greater than zero).
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is less than or equal to 0.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Positive(
        in short argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument <= 0)
        {
            throw new ArgumentNotPositiveIntegerException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="short" /> is
    ///     non-negative (greater than or equal to zero).
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is less than 0.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void NonNegative(
        in short argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument < 0)
        {
            throw new ArgumentNotPositiveIntegerException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="short" /> is
    ///     positive (greater than zero).
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is less than or equal to 0.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Positive(
        out short field,
        in short argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument <= 0)
        {
            throw new ArgumentNotPositiveIntegerException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="short" /> is
    ///     non-negative (greater than or equal to zero).
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is less than 0.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void NonNegative(
        out short field,
        in short argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument < 0)
        {
            throw new ArgumentNotPositiveIntegerException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="ushort" /> is
    ///     positive (greater than zero).
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is equal to 0.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Positive(
        in ushort argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument == 0)
        {
            throw new ArgumentNotPositiveIntegerException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="ushort" /> is
    ///     positive (greater than zero).
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is equal to 0.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Positive(
        out ushort field,
        in ushort argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument == 0)
        {
            throw new ArgumentNotPositiveIntegerException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="char" /> is
    ///     positive (greater than zero).
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is equal to 0.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Positive(
        in char argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument == 0)
        {
            throw new ArgumentNotPositiveIntegerException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="char" /> is
    ///     positive (greater than zero).
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is equal to 0.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Positive(
        out char field,
        in char argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument == 0)
        {
            throw new ArgumentNotPositiveIntegerException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="int" /> is
    ///     positive (greater than zero).
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is less than or equal to 0.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Positive(
        in int argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument <= 0)
        {
            throw new ArgumentNotPositiveIntegerException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="int" /> is
    ///     non-negative (greater than or equal to zero).
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is less than 0.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void NonNegative(
        in int argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument < 0)
        {
            throw new ArgumentNotPositiveIntegerException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="int" /> is
    ///     positive (greater than zero).
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is less than or equal to 0.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Positive(
        out int field,
        in int argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument <= 0)
        {
            throw new ArgumentNotPositiveIntegerException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="int" /> is
    ///     non-negative (greater than or equal to zero).
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is less than 0.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void NonNegative(
        out int field,
        in int argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument < 0)
        {
            throw new ArgumentNotPositiveIntegerException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="uint" /> is
    ///     positive (greater than zero).
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is equal to 0.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Positive(
        in uint argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument == 0)
        {
            throw new ArgumentNotPositiveIntegerException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="uint" /> is
    ///     positive (greater than zero).
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is equal to 0.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Positive(
        out uint field,
        in uint argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument == 0)
        {
            throw new ArgumentNotPositiveIntegerException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="long" /> is
    ///     positive (greater than zero).
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is less than or equal to 0.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Positive(
        in long argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument <= 0)
        {
            throw new ArgumentNotPositiveIntegerException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="long" /> is
    ///     non-negative (greater than or equal to zero).
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is less than 0.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void NonNegative(
        in long argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument < 0)
        {
            throw new ArgumentNotPositiveIntegerException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="long" /> is
    ///     positive (greater than zero).
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is less than or equal to 0.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Positive(
        out long field,
        in long argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument <= 0)
        {
            throw new ArgumentNotPositiveIntegerException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="long" /> is
    ///     non-negative (greater than or equal to zero).
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is less than 0.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void NonNegative(
        out long field,
        in long argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument < 0)
        {
            throw new ArgumentNotPositiveIntegerException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="ulong" /> is
    ///     positive (greater than zero).
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is equal to 0.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Positive(
        in ulong argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument == 0)
        {
            throw new ArgumentNotPositiveIntegerException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="ulong" /> is
    ///     positive (greater than zero).
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is equal to 0.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Positive(
        out ulong field,
        in ulong argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument == 0)
        {
            throw new ArgumentNotPositiveIntegerException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="float" /> is
    ///     positive (greater than zero).
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotPositiveException">
    ///     The argument is less than or equal to 0.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Positive(
        in float argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument <= 0)
        {
            throw new ArgumentNotPositiveException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="float" /> is
    ///     non-negative (greater than or equal to zero).
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotPositiveException">
    ///     The argument is less than 0.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void NonNegative(
        in float argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument < 0)
        {
            throw new ArgumentNotPositiveException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="float" /> is
    ///     positive (greater than zero).
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotPositiveException">
    ///     The argument is less than or equal to 0.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Positive(
        out float field,
        in float argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument <= 0)
        {
            throw new ArgumentNotPositiveException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="float" /> is
    ///     non-negative (greater than or equal to zero).
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotPositiveException">
    ///     The argument is less than 0.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void NonNegative(
        out float field,
        in float argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument < 0)
        {
            throw new ArgumentNotPositiveException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="double" /> is
    ///     positive (greater than zero).
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotPositiveException">
    ///     The argument is less than or equal to 0.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Positive(
        in double argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument <= 0)
        {
            throw new ArgumentNotPositiveException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="double" /> is
    ///     non-negative (greater than or equal to zero).
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotPositiveException">
    ///     The argument is less than 0.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void NonNegative(
        in double argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument < 0)
        {
            throw new ArgumentNotPositiveException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="double" /> is
    ///     positive (greater than zero).
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotPositiveException">
    ///     The argument is less than or equal to 0.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Positive(
        out double field,
        in double argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument <= 0)
        {
            throw new ArgumentNotPositiveException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="double" /> is
    ///     non-negative (greater than or equal to zero).
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotPositiveException">
    ///     The argument is less than 0.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void NonNegative(
        out double field,
        in double argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument < 0)
        {
            throw new ArgumentNotPositiveException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="decimal" /> is
    ///     positive (greater than zero).
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotPositiveException">
    ///     The argument is less than or equal to 0.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Positive(
        in decimal argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument <= 0)
        {
            throw new ArgumentNotPositiveException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a contract requires that a numeric argument of type <see cref="decimal" /> is
    ///     non-negative (greater than or equal to zero).
    /// </summary>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotPositiveException">
    ///     The argument is less than 0.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void NonNegative(
        in decimal argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument < 0)
        {
            throw new ArgumentNotPositiveException(argumentName);
        }
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="decimal" /> is
    ///     positive (greater than zero).
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotPositiveException">
    ///     The argument is less than or equal to 0.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Positive(
        out decimal field,
        in decimal argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument <= 0)
        {
            throw new ArgumentNotPositiveException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    ///     Called when a field initialization requires that a numeric argument of type <see cref="decimal" /> is
    ///     non-negative (greater than or equal to zero).
    /// </summary>
    /// <param name="field">
    ///     The field that the argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The numeric argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotPositiveException">
    ///     The argument is less than 0.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void NonNegative(
        out decimal field,
        in decimal argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument < 0)
        {
            throw new ArgumentNotPositiveException(argumentName);
        }

        field = argument;
    }
}