using IX.Core.ComponentModel;

using System.Runtime.CompilerServices;
using IX.Core.Entities;
using DiagCA = System.Diagnostics.CodeAnalysis;

namespace IX.Core.Contracts;

/// <summary>
///     Methods for approximating the works of contract-oriented programming.
/// </summary>
[PublicAPI]
public static partial class Requires
{
#region Not null

    /// <summary>
    ///     Called when a contract requires that a collection argument is not null or empty.
    /// </summary>
    /// <typeparam name="TCollection">The type of the collection.</typeparam>
    /// <typeparam name="T">
    ///     The type of item in the collection.
    /// </typeparam>
    /// <param name="argument">
    ///     The collection argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <returns>
    ///     The validated argument.
    /// </returns>
    /// <exception cref="ArgumentNullOrEmptyCollectionException">
    ///     The argument is <see langword="null" /> or empty.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [ContractAnnotation("argument:null => halt")]
    [AssertionMethod]
    public static TCollection NotEmpty<TCollection, T>(
        [NoEnumeration] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
        TCollection? argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
        where TCollection : class, ICollection<T>
    {
        if ((argument?.Count ?? 0) == 0)
        {
            throw new ArgumentNullOrEmptyCollectionException(argumentName);
        }

        return argument!;
    }

    /// <summary>
    /// Called when a contract requires that a collection argument is not null or empty.
    /// </summary>
    /// <typeparam name="TCollection">The type of the collection.</typeparam>
    /// <typeparam name="T">The type of the item in the collection.</typeparam>
    /// <param name="field">The field that this argument is initializing.</param>
    /// <param name="argument">The collection argument.</param>
    /// <param name="argumentName">The argument name.</param>
    /// <exception cref="ArgumentNullOrEmptyCollectionException">The argument is <see langword="null" /> or empty.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [ContractAnnotation("argument:null => halt")]
    [AssertionMethod]
    public static void NotEmpty<TCollection, T>(
        out TCollection field,
        [NoEnumeration] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
        TCollection? argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
        where TCollection : class, ICollection<T>
    {
        if ((argument?.Count ?? 0) == 0)
        {
            throw new ArgumentNullOrEmptyCollectionException(argumentName);
        }

        field = argument!;
    }

    /// <summary>
    ///     Called when a contract requires that an array argument is not null or empty.
    /// </summary>
    /// <typeparam name="T">
    ///     The type of the array.
    /// </typeparam>
    /// <param name="argument">
    ///     The array argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <returns>
    ///     The validated argument.
    /// </returns>
    /// <exception cref="ArgumentNullOrEmptyBinaryException">
    ///     The argument is <see langword="null" /> or empty.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [ContractAnnotation("argument:null => halt")]
    [AssertionMethod]
    public static T[] NotEmpty<T>(
        [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
        T[]? argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if ((argument?.Length ?? 0) == 0)
        {
            throw new ArgumentNullOrEmptyArrayException(argumentName);
        }

        return argument!;
    }

    /// <summary>
    ///     Called when a contract requires that an array argument is not null or empty.
    /// </summary>
    /// <typeparam name="T">
    ///     The type of the array.
    /// </typeparam>
    /// <param name="field">The field that this argument is initializing.</param>
    /// <param name="argument">
    ///     The array argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNullOrEmptyBinaryException">
    ///     The argument is <see langword="null" /> or empty.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [ContractAnnotation("argument:null => halt")]
    [AssertionMethod]
    public static void NotEmpty<T>(
        out T[] field,
        [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
        T[]? argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if ((argument?.Length ?? 0) == 0)
        {
            throw new ArgumentNullOrEmptyArrayException(argumentName);
        }

        field = argument!;
    }

#endregion

#region Fixed length

    /// <summary>Called when a contract requires that an array is of a specific length.</summary>
    /// <typeparam name="T">The type of items in the array.</typeparam>
    /// <param name="array">The array for which we are validating the length.</param>
    /// <param name="length">The exact length.</param>
    /// <param name="argumentName">The argument name.</param>
    /// <param name="lengthArgumentName">The name for the length argument.</param>
    /// <returns>The validated argument.</returns>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is either negative or exceeds the bounds of the
    ///     array.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [ContractAnnotation("array:null => halt")]
    public static T[] FixedLength<T>(
        [NoEnumeration] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
        T[]? array,
        in int length,
        [CallerArgumentExpression("array")]
        string argumentName = "array",
        [CallerArgumentExpression("length")]
        string lengthArgumentName = "length")
    {
        if (array == null)
        {
            throw new ArgumentNullOrEmptyArrayException(argumentName);
        }

        if (length < 0)
        {
            throw new ArgumentNotValidLengthException(lengthArgumentName);
        }

        if (array.Length != length)
        {
            throw new ArgumentOutOfRangeException(lengthArgumentName);
        }

        return array;
    }

    /// <summary>Called when a contract requires that an array is of a specific length.</summary>
    /// <typeparam name="T">The type of items in the array.</typeparam>
    /// <param name="field">
    ///     The field that this argument is initializing.
    /// </param>
    /// <param name="array">The array for which we are validating the length.</param>
    /// <param name="length">The exact length.</param>
    /// <param name="argumentName">The argument name.</param>
    /// <param name="lengthArgumentName">The name for the length argument.</param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is either negative or exceeds the bounds of the
    ///     array.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [ContractAnnotation("array:null => halt")]
    public static void FixedLength<T>(
        out T[] field,
        [NoEnumeration] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
        T[]? array,
        in int length,
        [CallerArgumentExpression("array")]
        string argumentName = "array",
        [CallerArgumentExpression("length")]
        string lengthArgumentName = "length")
    {
        if (array == null)
        {
            throw new ArgumentNullOrEmptyArrayException(argumentName);
        }

        if (length < 0)
        {
            throw new ArgumentNotValidLengthException(lengthArgumentName);
        }

        if (array.Length != length)
        {
            throw new ArgumentOutOfRangeException(lengthArgumentName);
        }

        field = array;
    }

    /// <summary>Called when a contract requires that an array is of a specific length.</summary>
    /// <typeparam name="T">The type of items in the array.</typeparam>
    /// <param name="array">The array for which we are validating the length.</param>
    /// <param name="length">The exact length.</param>
    /// <param name="argumentName">The argument name.</param>
    /// <param name="lengthArgumentName">The name for the length argument.</param>
    /// <returns>The validated argument.</returns>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is either negative or exceeds the bounds of the
    ///     array.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [ContractAnnotation("array:null => halt")]
    public static T[] FixedLength<T>(
        [NoEnumeration] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
        T[]? array,
        in long length,
        [CallerArgumentExpression("array")]
        string argumentName = "array",
        [CallerArgumentExpression("length")]
        string lengthArgumentName = "length")
    {
        if (array == null)
        {
            throw new ArgumentNullOrEmptyArrayException(argumentName);
        }

        if (length < 0)
        {
            throw new ArgumentNotValidLengthException(lengthArgumentName);
        }

        if (array.LongLength != length)
        {
            throw new ArgumentOutOfRangeException(argumentName);
        }

        return array;
    }

    /// <summary>Called when a contract requires that an array is of a specific length.</summary>
    /// <typeparam name="T">The type of items in the array.</typeparam>
    /// <param name="field">
    ///     The field that this argument is initializing.
    /// </param>
    /// <param name="array">The array for which we are validating the length.</param>
    /// <param name="length">The exact length.</param>
    /// <param name="argumentName">The argument name.</param>
    /// <param name="lengthArgumentName">The name for the length argument.</param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is either negative or exceeds the bounds of the
    ///     array.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [ContractAnnotation("array:null => halt")]
    public static void FixedLength<T>(
        out T[] field,
        [NoEnumeration] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
        T[]? array,
        in long length,
        [CallerArgumentExpression("array")]
        string argumentName = "array",
        [CallerArgumentExpression("length")]
        string lengthArgumentName = "length")
    {
        if (array == null)
        {
            throw new ArgumentNullOrEmptyArrayException(argumentName);
        }

        if (length < 0)
        {
            throw new ArgumentNotValidLengthException(lengthArgumentName);
        }

        if (array.LongLength != length)
        {
            throw new ArgumentOutOfRangeException(argumentName);
        }

        field = array;
    }

#endregion

#region Length at least

    /// <summary>Called when a contract requires that an array's length is at least a specific value.</summary>
    /// <typeparam name="T">The type of items in the array.</typeparam>
    /// <param name="array">The array for which we are validating the length.</param>
    /// <param name="length">The exact length.</param>
    /// <param name="argumentName">The argument name.</param>
    /// <param name="lengthArgumentName">The name for the length argument.</param>
    /// <returns>The validated argument.</returns>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is either negative or exceeds the bounds of the
    ///     array.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [ContractAnnotation("array:null => halt")]
    public static T[] LengthAtLeast<T>(
        [NoEnumeration] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
        T[]? array,
        in int length,
        [CallerArgumentExpression("array")]
        string argumentName = "array",
        [CallerArgumentExpression("length")]
        string lengthArgumentName = "length")
    {
        if (array == null)
        {
            throw new ArgumentNullOrEmptyArrayException(argumentName);
        }

        if (length < 0)
        {
            throw new ArgumentNotValidLengthException(lengthArgumentName);
        }

        if (array.Length < length)
        {
            throw new ArgumentOutOfRangeException(argumentName);
        }

        return array;
    }

    /// <summary>Called when a contract requires that an array's length is at least a specific value.</summary>
    /// <typeparam name="T">The type of items in the array.</typeparam>
    /// <param name="field">
    ///     The field that this argument is initializing.
    /// </param>
    /// <param name="array">The array for which we are validating the length.</param>
    /// <param name="length">The exact length.</param>
    /// <param name="argumentName">The argument name.</param>
    /// <param name="lengthArgumentName">The name for the length argument.</param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is either negative or exceeds the bounds of the
    ///     array.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [ContractAnnotation("array:null => halt")]
    public static void LengthAtLeast<T>(
        out T[] field,
        [NoEnumeration] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
        T[]? array,
        in int length,
        [CallerArgumentExpression("array")]
        string argumentName = "array",
        [CallerArgumentExpression("length")]
        string lengthArgumentName = "length")
    {
        if (array == null)
        {
            throw new ArgumentNullOrEmptyArrayException(argumentName);
        }

        if (length < 0)
        {
            throw new ArgumentNotValidLengthException(lengthArgumentName);
        }

        if (array.Length < length)
        {
            throw new ArgumentOutOfRangeException(argumentName);
        }

        field = array;
    }

    /// <summary>Called when a contract requires that an array's length is at least a specific value.</summary>
    /// <typeparam name="T">The type of items in the array.</typeparam>
    /// <param name="array">The array for which we are validating the length.</param>
    /// <param name="length">The exact length.</param>
    /// <param name="argumentName">The argument name.</param>
    /// <param name="lengthArgumentName">The name for the length argument.</param>
    /// <returns>The validated argument.</returns>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is either negative or exceeds the bounds of the
    ///     array.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [ContractAnnotation("array:null => halt")]
    public static T[] LengthAtLeast<T>(
        [NoEnumeration] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
        T[]? array,
        in long length,
        [CallerArgumentExpression("array")]
        string argumentName = "array",
        [CallerArgumentExpression("length")]
        string lengthArgumentName = "length")
    {
        if (array == null)
        {
            throw new ArgumentNullOrEmptyArrayException(argumentName);
        }

        if (length < 0)
        {
            throw new ArgumentNotValidLengthException(lengthArgumentName);
        }

        if (array.LongLength < length)
        {
            throw new ArgumentOutOfRangeException(argumentName);
        }

        return array;
    }

    /// <summary>Called when a contract requires that an array's length is at least a specific value.</summary>
    /// <typeparam name="T">The type of items in the array.</typeparam>
    /// <param name="field">
    ///     The field that this argument is initializing.
    /// </param>
    /// <param name="array">The array for which we are validating the length.</param>
    /// <param name="length">The exact length.</param>
    /// <param name="argumentName">The argument name.</param>
    /// <param name="lengthArgumentName">The name for the length argument.</param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is either negative or exceeds the bounds of the
    ///     array.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [ContractAnnotation("array:null => halt")]
    public static void LengthAtLeast<T>(
        out T[] field,
        [NoEnumeration] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
        T[]? array,
        in long length,
        [CallerArgumentExpression("array")]
        string argumentName = "array",
        [CallerArgumentExpression("length")]
        string lengthArgumentName = "length")
    {
        if (array == null)
        {
            throw new ArgumentNullOrEmptyArrayException(argumentName);
        }

        if (length < 0)
        {
            throw new ArgumentNotValidLengthException(lengthArgumentName);
        }

        if (array.LongLength < length)
        {
            throw new ArgumentOutOfRangeException(argumentName);
        }

        field = array;
    }

#endregion

#region Length at most

    /// <summary>Called when a contract requires that an array's length is at most a specific value.</summary>
    /// <typeparam name="T">The type of items in the array.</typeparam>
    /// <param name="array">The array for which we are validating the length.</param>
    /// <param name="length">The exact length.</param>
    /// <param name="argumentName">The argument name.</param>
    /// <param name="lengthArgumentName">The name for the length argument.</param>
    /// <returns>The validated argument.</returns>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is either negative or exceeds the bounds of the
    ///     array.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [ContractAnnotation("array:null => halt")]
    public static T[] LengthAtMost<T>(
        [NoEnumeration] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
        T[]? array,
        in int length,
        [CallerArgumentExpression("array")]
        string argumentName = "array",
        [CallerArgumentExpression("length")]
        string lengthArgumentName = "length")
    {
        if (array == null)
        {
            throw new ArgumentNullOrEmptyArrayException(argumentName);
        }

        if (length < 1)
        {
            throw new ArgumentNotValidLengthException(lengthArgumentName);
        }

        if (array.Length > length)
        {
            throw new ArgumentOutOfRangeException(argumentName);
        }

        return array;
    }

    /// <summary>Called when a contract requires that an array's length is at most a specific value.</summary>
    /// <typeparam name="T">The type of items in the array.</typeparam>
    /// <param name="field">
    ///     The field that this argument is initializing.
    /// </param>
    /// <param name="array">The array for which we are validating the length.</param>
    /// <param name="length">The exact length.</param>
    /// <param name="argumentName">The argument name.</param>
    /// <param name="lengthArgumentName">The name for the length argument.</param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is either negative or exceeds the bounds of the
    ///     array.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [ContractAnnotation("array:null => halt")]
    public static void LengthAtMost<T>(
        out T[] field,
        [NoEnumeration] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
        T[]? array,
        in int length,
        [CallerArgumentExpression("array")]
        string argumentName = "array",
        [CallerArgumentExpression("length")]
        string lengthArgumentName = "length")
    {
        if (array == null)
        {
            throw new ArgumentNullOrEmptyArrayException(argumentName);
        }

        if (length > 1)
        {
            throw new ArgumentNotValidLengthException(lengthArgumentName);
        }

        if (array.Length < length)
        {
            throw new ArgumentOutOfRangeException(argumentName);
        }

        field = array;
    }

    /// <summary>Called when a contract requires that an array's length is at most a specific value.</summary>
    /// <typeparam name="T">The type of items in the array.</typeparam>
    /// <param name="array">The array for which we are validating the length.</param>
    /// <param name="length">The exact length.</param>
    /// <param name="argumentName">The argument name.</param>
    /// <param name="lengthArgumentName">The name for the length argument.</param>
    /// <returns>The validated argument.</returns>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is either negative or exceeds the bounds of the
    ///     array.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [ContractAnnotation("array:null => halt")]
    public static T[] LengthAtMost<T>(
        [NoEnumeration] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
        T[]? array,
        in long length,
        [CallerArgumentExpression("array")]
        string argumentName = "array",
        [CallerArgumentExpression("length")]
        string lengthArgumentName = "length")
    {
        if (array == null)
        {
            throw new ArgumentNullOrEmptyArrayException(argumentName);
        }

        if (length > 1)
        {
            throw new ArgumentNotValidLengthException(lengthArgumentName);
        }

        if (array.LongLength < length)
        {
            throw new ArgumentOutOfRangeException(argumentName);
        }

        return array;
    }

    /// <summary>Called when a contract requires that an array's length is at most a specific value.</summary>
    /// <typeparam name="T">The type of items in the array.</typeparam>
    /// <param name="field">
    ///     The field that this argument is initializing.
    /// </param>
    /// <param name="array">The array for which we are validating the length.</param>
    /// <param name="length">The exact length.</param>
    /// <param name="argumentName">The argument name.</param>
    /// <param name="lengthArgumentName">The name for the length argument.</param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is either negative or exceeds the bounds of the
    ///     array.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [ContractAnnotation("array:null => halt")]
    public static void LengthAtMost<T>(
        out T[] field,
        [NoEnumeration] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
        T[]? array,
        in long length,
        [CallerArgumentExpression("array")]
        string argumentName = "array",
        [CallerArgumentExpression("length")]
        string lengthArgumentName = "length")
    {
        if (array == null)
        {
            throw new ArgumentNullOrEmptyArrayException(argumentName);
        }

        if (length < 1)
        {
            throw new ArgumentNotValidLengthException(lengthArgumentName);
        }

        if (array.LongLength > length)
        {
            throw new ArgumentOutOfRangeException(argumentName);
        }

        field = array;
    }

#endregion

#region Positive

    /// <summary>
    ///     Called when a contract requires that a <see cref="TimeSpan"/> argument is positive.
    /// </summary>
    /// <param name="argument">
    ///     The time span argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <returns>
    ///     The validated argument.
    /// </returns>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is 0.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TimeSpan Positive(
        in TimeSpan argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument <= TimeSpan.Zero)
        {
            throw new ArgumentNotPositiveIntegerException(argumentName);
        }

        return argument;
    }

    /// <summary>
    ///     Called when a contract requires that a <see cref="TimeSpan"/> argument is positive.
    /// </summary>
    /// <param name="field">The field that this argument is initializing.</param>
    /// <param name="argument">
    ///     The time span argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is 0.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Positive(
        out TimeSpan field,
        in TimeSpan argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument <= TimeSpan.Zero)
        {
            throw new ArgumentNotPositiveIntegerException(argumentName);
        }

        field = argument;
    }
#endregion

#region Non-negative

    /// <summary>
    ///     Called when a contract requires that a <see cref="TimeSpan" /> argument is not negative.
    /// </summary>
    /// <param name="argument">
    ///     The time span argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <returns>
    ///     The validated argument.
    /// </returns>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is 0.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TimeSpan NonNegative(
        in TimeSpan argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument < TimeSpan.Zero)
        {
            throw new ArgumentNotPositiveIntegerException(argumentName);
        }

        return argument;
    }

    /// <summary>
    ///     Called when a contract requires that a <see cref="TimeSpan" /> argument is not negative.
    /// </summary>
    /// <param name="field">The field that this argument is initializing.</param>
    /// <param name="argument">
    ///     The time span argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is 0.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void NonNegative(
        out TimeSpan field,
        in TimeSpan argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument < TimeSpan.Zero)
        {
            throw new ArgumentNotPositiveIntegerException(argumentName);
        }

        field = argument;
    }
#endregion

#region Generic index

    /// <summary>
    /// Called when a contract requires that a specific index is valid for any kind of collection.
    /// </summary>
    /// <param name="argument">The argument to validate.</param>
    /// <param name="argumentName">The argument name.</param>
    /// <exception cref="ArgumentNotValidIndexException">The argument is not a valid index, possibly negative.</exception>
    public static void ValidIndex(
        in int argument,
        [CallerArgumentExpression("argument")] string argumentName = "argument")
    {
        if (argument < 0)
        {
            throw new ArgumentNotValidIndexException(argumentName);
        }
    }

    /// <summary>
    /// Called when a contract requires that a specific index is valid for any kind of collection.
    /// </summary>
    /// <param name="field">
    ///     The field that this argument is initializing.
    /// </param>
    /// <param name="argument">The argument to validate.</param>
    /// <param name="argumentName">The argument name.</param>
    /// <exception cref="ArgumentNotValidIndexException">The argument is not a valid index, possibly negative.</exception>
    public static void ValidIndex(
        out int field,
        in int argument,
        [CallerArgumentExpression("argument")] string argumentName = "argument")
    {
        if (argument < 0)
        {
            throw new ArgumentNotValidIndexException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    /// Called when a contract requires that a specific index is valid for any kind of collection.
    /// </summary>
    /// <param name="argument">The argument to validate.</param>
    /// <param name="argumentName">The argument name.</param>
    /// <exception cref="ArgumentNotValidIndexException">The argument is not a valid index, possibly negative.</exception>
    public static void ValidIndex(
        in long argument,
        [CallerArgumentExpression("argument")] string argumentName = "argument")
    {
        if (argument < 0)
        {
            throw new ArgumentNotValidIndexException(argumentName);
        }
    }

    /// <summary>
    /// Called when a contract requires that a specific index is valid for any kind of collection.
    /// </summary>
    /// <param name="field">
    ///     The field that this argument is initializing.
    /// </param>
    /// <param name="argument">The argument to validate.</param>
    /// <param name="argumentName">The argument name.</param>
    /// <exception cref="ArgumentNotValidIndexException">The argument is not a valid index, possibly negative.</exception>
    public static void ValidIndex(
        out long field,
        in long argument,
        [CallerArgumentExpression("argument")] string argumentName = "argument")
    {
        if (argument < 0)
        {
            throw new ArgumentNotValidIndexException(argumentName);
        }

        field = argument;
    }

#endregion

#region Generic range

    /// <summary>Called when a contract requires that a specific index and length, constituting a range, is valid.</summary>
    /// <param name="indexArgument">The numeric index argument to validate.</param>
    /// <param name="lengthArgument">The numeric length argument to validate.</param>
    /// <param name="indexArgumentName">The index argument name.</param>
    /// <param name="lengthArgumentName">The length argument name.</param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is either negative or exceeds the bounds of the
    ///     array.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ValidRange(
        in int indexArgument,
        in int lengthArgument,
        [CallerArgumentExpression("indexArgument")]
        string indexArgumentName = "indexArgument",
        [CallerArgumentExpression("lengthArgument")]
        string lengthArgumentName = "lengthArgument")
    {
        if (indexArgument < 0)
        {
            throw new ArgumentNotValidIndexException(indexArgumentName);
        }

        if (lengthArgument <= 0)
        {
            throw new ArgumentsNotValidRangeException(
                indexArgumentName,
                lengthArgumentName);
        }
    }

    /// <summary>Called when a contract requires that a specific index and length, constituting a range, is valid.</summary>
    /// <param name="fieldIndex">The index field that this argument is initializing.</param>
    /// <param name="fieldLength">The length field that this argument is initializing.</param>
    /// <param name="indexArgument">The numeric index argument to validate.</param>
    /// <param name="lengthArgument">The numeric length argument to validate.</param>
    /// <param name="indexArgumentName">The index argument name.</param>
    /// <param name="lengthArgumentName">The length argument name.</param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is either negative or exceeds the bounds of the
    ///     array.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ValidRange(
        out int fieldIndex,
        out int fieldLength,
        in int indexArgument,
        in int lengthArgument,
        [CallerArgumentExpression("indexArgument")]
        string indexArgumentName = "indexArgument",
        [CallerArgumentExpression("lengthArgument")]
        string lengthArgumentName = "lengthArgument")
    {
        if (indexArgument < 0)
        {
            throw new ArgumentNotValidIndexException(indexArgumentName);
        }

        if (lengthArgument <= 0)
        {
            throw new ArgumentsNotValidRangeException(
                indexArgumentName,
                lengthArgumentName);
        }

        fieldIndex = indexArgument;
        fieldLength = lengthArgument;
    }

    /// <summary>Called when a contract requires that a specific index and length, constituting a range, is valid.</summary>
    /// <param name="indexArgument">The numeric index argument to validate.</param>
    /// <param name="lengthArgument">The numeric length argument to validate.</param>
    /// <param name="indexArgumentName">The index argument name.</param>
    /// <param name="lengthArgumentName">The length argument name.</param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is either negative or exceeds the bounds of the
    ///     array.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ValidRange(
        in long indexArgument,
        in long lengthArgument,
        [CallerArgumentExpression("indexArgument")]
        string indexArgumentName = "indexArgument",
        [CallerArgumentExpression("lengthArgument")]
        string lengthArgumentName = "lengthArgument")
    {
        if (indexArgument < 0)
        {
            throw new ArgumentNotValidIndexException(indexArgumentName);
        }

        if (lengthArgument <= 0)
        {
            throw new ArgumentsNotValidRangeException(
                indexArgumentName,
                lengthArgumentName);
        }
    }

    /// <summary>Called when a contract requires that a specific index and length, constituting a range, is valid.</summary>
    /// <param name="fieldIndex">The index field that this argument is initializing.</param>
    /// <param name="fieldLength">The length field that this argument is initializing.</param>
    /// <param name="indexArgument">The numeric index argument to validate.</param>
    /// <param name="lengthArgument">The numeric length argument to validate.</param>
    /// <param name="indexArgumentName">The index argument name.</param>
    /// <param name="lengthArgumentName">The length argument name.</param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is either negative or exceeds the bounds of the
    ///     array.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ValidRange(
        out long fieldIndex,
        out long fieldLength,
        in long indexArgument,
        in long lengthArgument,
        [CallerArgumentExpression("indexArgument")]
        string indexArgumentName = "indexArgument",
        [CallerArgumentExpression("lengthArgument")]
        string lengthArgumentName = "lengthArgument")
    {
        if (indexArgument < 0)
        {
            throw new ArgumentNotValidIndexException(indexArgumentName);
        }

        if (lengthArgument <= 0)
        {
            throw new ArgumentsNotValidRangeException(
                indexArgumentName,
                lengthArgumentName);
        }

        fieldIndex = indexArgument;
        fieldLength = lengthArgument;
    }

#endregion

#region Generic non-negative numeric range

    /// <summary>Called when a contract requires that a specific numeric range is valid and non-negative.</summary>
    /// <param name="minimumArgument">The numeric minimum argument to validate.</param>
    /// <param name="maximumArgument">The numeric length argument to validate.</param>
    /// <param name="minimumArgumentName">The minimum argument name.</param>
    /// <param name="maximumArgumentName">The maximum argument name.</param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     At least one of the arguments is negative.
    /// </exception>
    /// <exception cref="ArgumentsNotValidRangeException">
    ///     The maximum argument is smaller than the minimum argument.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ValidNumericNonNegativeRange(
        in short minimumArgument,
        in short maximumArgument,
        [CallerArgumentExpression("minimumArgument")]
        string minimumArgumentName = "minimumArgument",
        [CallerArgumentExpression("maximumArgument")]
        string maximumArgumentName = "maximumArgument")
    {
        if (minimumArgument < 0 || maximumArgument < 0)
        {
            throw new ArgumentNotPositiveIntegerException(minimumArgumentName);
        }

        if (maximumArgument < minimumArgument)
        {
            throw new ArgumentsNotValidRangeException(
                minimumArgumentName,
                maximumArgumentName);
        }
    }

    /// <summary>Called when a contract requires that a specific numeric range is valid and non-negative.</summary>
    /// <param name="fieldMinimum">The index field that this argument is initializing.</param>
    /// <param name="fieldMaximum">The length field that this argument is initializing.</param>
    /// <param name="minimumArgument">The numeric index argument to validate.</param>
    /// <param name="maximumArgument">The numeric length argument to validate.</param>
    /// <param name="minimumArgumentName">The index argument name.</param>
    /// <param name="maximumArgumentName">The length argument name.</param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     At least one of the arguments is negative.
    /// </exception>
    /// <exception cref="ArgumentsNotValidRangeException">
    ///     The maximum argument is smaller than the minimum argument.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ValidNumericNonNegativeRange(
        out short fieldMinimum,
        out short fieldMaximum,
        in short minimumArgument,
        in short maximumArgument,
        [CallerArgumentExpression("minimumArgument")]
        string minimumArgumentName = "minimumArgument",
        [CallerArgumentExpression("maximumArgument")]
        string maximumArgumentName = "maximumArgument")
    {
        if (minimumArgument < 0 || maximumArgument < 0)
        {
            throw new ArgumentNotPositiveIntegerException(minimumArgumentName);
        }

        if (maximumArgument < minimumArgument)
        {
            throw new ArgumentsNotValidRangeException(
                minimumArgumentName,
                maximumArgumentName);
        }

        fieldMinimum = minimumArgument;
        fieldMaximum = maximumArgument;
    }

    /// <summary>Called when a contract requires that a specific numeric range is valid and non-negative.</summary>
    /// <param name="minimumArgument">The numeric minimum argument to validate.</param>
    /// <param name="maximumArgument">The numeric length argument to validate.</param>
    /// <param name="minimumArgumentName">The minimum argument name.</param>
    /// <param name="maximumArgumentName">The maximum argument name.</param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     At least one of the arguments is negative.
    /// </exception>
    /// <exception cref="ArgumentsNotValidRangeException">
    ///     The maximum argument is smaller than the minimum argument.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ValidNumericNonNegativeRange(
        in int minimumArgument,
        in int maximumArgument,
        [CallerArgumentExpression("minimumArgument")]
        string minimumArgumentName = "minimumArgument",
        [CallerArgumentExpression("maximumArgument")]
        string maximumArgumentName = "maximumArgument")
    {
        if (minimumArgument < 0 || maximumArgument < 0)
        {
            throw new ArgumentNotPositiveIntegerException(minimumArgumentName);
        }

        if (maximumArgument < minimumArgument)
        {
            throw new ArgumentsNotValidRangeException(
                minimumArgumentName,
                maximumArgumentName);
        }
    }

    /// <summary>Called when a contract requires that a specific numeric range is valid and non-negative.</summary>
    /// <param name="fieldMinimum">The index field that this argument is initializing.</param>
    /// <param name="fieldMaximum">The length field that this argument is initializing.</param>
    /// <param name="minimumArgument">The numeric index argument to validate.</param>
    /// <param name="maximumArgument">The numeric length argument to validate.</param>
    /// <param name="minimumArgumentName">The index argument name.</param>
    /// <param name="maximumArgumentName">The length argument name.</param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     At least one of the arguments is negative.
    /// </exception>
    /// <exception cref="ArgumentsNotValidRangeException">
    ///     The maximum argument is smaller than the minimum argument.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ValidNumericNonNegativeRange(
        out int fieldMinimum,
        out int fieldMaximum,
        in int minimumArgument,
        in int maximumArgument,
        [CallerArgumentExpression("minimumArgument")]
        string minimumArgumentName = "minimumArgument",
        [CallerArgumentExpression("maximumArgument")]
        string maximumArgumentName = "maximumArgument")
    {
        if (minimumArgument < 0 || maximumArgument < 0)
        {
            throw new ArgumentNotPositiveIntegerException(minimumArgumentName);
        }

        if (maximumArgument < minimumArgument)
        {
            throw new ArgumentsNotValidRangeException(
                minimumArgumentName,
                maximumArgumentName);
        }

        fieldMinimum = minimumArgument;
        fieldMaximum = maximumArgument;
    }

    /// <summary>Called when a contract requires that a specific numeric range is valid and non-negative.</summary>
    /// <param name="minimumArgument">The numeric index argument to validate.</param>
    /// <param name="maximumArgument">The numeric length argument to validate.</param>
    /// <param name="minimumArgumentName">The index argument name.</param>
    /// <param name="maximumArgumentName">The length argument name.</param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     At least one of the arguments is negative.
    /// </exception>
    /// <exception cref="ArgumentsNotValidRangeException">
    ///     The maximum argument is smaller than the minimum argument.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ValidNumericNonNegativeRange(
        in long minimumArgument,
        in long maximumArgument,
        [CallerArgumentExpression("minimumArgument")]
        string minimumArgumentName = "minimumArgument",
        [CallerArgumentExpression("maximumArgument")]
        string maximumArgumentName = "maximumArgument")
    {
        if (minimumArgument < 0 || maximumArgument < 0)
        {
            throw new ArgumentNotPositiveIntegerException(minimumArgumentName);
        }

        if (maximumArgument < minimumArgument)
        {
            throw new ArgumentsNotValidRangeException(
                minimumArgumentName,
                maximumArgumentName);
        }
    }

    /// <summary>Called when a contract requires that a specific numeric range is valid and non-negative.</summary>
    /// <param name="fieldMinimum">The index field that this argument is initializing.</param>
    /// <param name="fieldMaximum">The length field that this argument is initializing.</param>
    /// <param name="minimumArgument">The numeric index argument to validate.</param>
    /// <param name="maximumArgument">The numeric length argument to validate.</param>
    /// <param name="minimumArgumentName">The index argument name.</param>
    /// <param name="maximumArgumentName">The length argument name.</param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     At least one of the arguments is negative.
    /// </exception>
    /// <exception cref="ArgumentsNotValidRangeException">
    ///     The maximum argument is smaller than the minimum argument.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ValidNumericNonNegativeRange(
        out long fieldMinimum,
        out long fieldMaximum,
        in long minimumArgument,
        in long maximumArgument,
        [CallerArgumentExpression("minimumArgument")]
        string minimumArgumentName = "minimumArgument",
        [CallerArgumentExpression("maximumArgument")]
        string maximumArgumentName = "maximumArgument")
    {
        if (minimumArgument < 0 || maximumArgument < 0)
        {
            throw new ArgumentNotPositiveIntegerException(minimumArgumentName);
        }

        if (maximumArgument < minimumArgument)
        {
            throw new ArgumentsNotValidRangeException(
                minimumArgumentName,
                maximumArgumentName);
        }

        fieldMinimum = minimumArgument;
        fieldMaximum = maximumArgument;
    }

    /// <summary>Called when a contract requires that a specific numeric range is valid and non-negative.</summary>
    /// <param name="minimumArgument">The numeric minimum argument to validate.</param>
    /// <param name="maximumArgument">The numeric length argument to validate.</param>
    /// <param name="minimumArgumentName">The minimum argument name.</param>
    /// <param name="maximumArgumentName">The maximum argument name.</param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     At least one of the arguments is negative.
    /// </exception>
    /// <exception cref="ArgumentsNotValidRangeException">
    ///     The maximum argument is smaller than the minimum argument.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ValidNumericNonNegativeRange(
        in float minimumArgument,
        in float maximumArgument,
        [CallerArgumentExpression("minimumArgument")]
        string minimumArgumentName = "minimumArgument",
        [CallerArgumentExpression("maximumArgument")]
        string maximumArgumentName = "maximumArgument")
    {
        if (minimumArgument < 0 || maximumArgument < 0)
        {
            throw new ArgumentNotPositiveIntegerException(minimumArgumentName);
        }

        if (maximumArgument < minimumArgument)
        {
            throw new ArgumentsNotValidRangeException(
                minimumArgumentName,
                maximumArgumentName);
        }
    }

    /// <summary>Called when a contract requires that a specific numeric range is valid and non-negative.</summary>
    /// <param name="fieldMinimum">The index field that this argument is initializing.</param>
    /// <param name="fieldMaximum">The length field that this argument is initializing.</param>
    /// <param name="minimumArgument">The numeric index argument to validate.</param>
    /// <param name="maximumArgument">The numeric length argument to validate.</param>
    /// <param name="minimumArgumentName">The index argument name.</param>
    /// <param name="maximumArgumentName">The length argument name.</param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     At least one of the arguments is negative.
    /// </exception>
    /// <exception cref="ArgumentsNotValidRangeException">
    ///     The maximum argument is smaller than the minimum argument.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ValidNumericNonNegativeRange(
        out float fieldMinimum,
        out float fieldMaximum,
        in float minimumArgument,
        in float maximumArgument,
        [CallerArgumentExpression("minimumArgument")]
        string minimumArgumentName = "minimumArgument",
        [CallerArgumentExpression("maximumArgument")]
        string maximumArgumentName = "maximumArgument")
    {
        if (minimumArgument < 0 || maximumArgument < 0)
        {
            throw new ArgumentNotPositiveIntegerException(minimumArgumentName);
        }

        if (maximumArgument < minimumArgument)
        {
            throw new ArgumentsNotValidRangeException(
                minimumArgumentName,
                maximumArgumentName);
        }

        fieldMinimum = minimumArgument;
        fieldMaximum = maximumArgument;
    }

    /// <summary>Called when a contract requires that a specific numeric range is valid and non-negative.</summary>
    /// <param name="minimumArgument">The numeric minimum argument to validate.</param>
    /// <param name="maximumArgument">The numeric length argument to validate.</param>
    /// <param name="minimumArgumentName">The minimum argument name.</param>
    /// <param name="maximumArgumentName">The maximum argument name.</param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     At least one of the arguments is negative.
    /// </exception>
    /// <exception cref="ArgumentsNotValidRangeException">
    ///     The maximum argument is smaller than the minimum argument.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ValidNumericNonNegativeRange(
        in double minimumArgument,
        in double maximumArgument,
        [CallerArgumentExpression("minimumArgument")]
        string minimumArgumentName = "minimumArgument",
        [CallerArgumentExpression("maximumArgument")]
        string maximumArgumentName = "maximumArgument")
    {
        if (minimumArgument < 0 || maximumArgument < 0)
        {
            throw new ArgumentNotPositiveIntegerException(minimumArgumentName);
        }

        if (maximumArgument < minimumArgument)
        {
            throw new ArgumentsNotValidRangeException(
                minimumArgumentName,
                maximumArgumentName);
        }
    }

    /// <summary>Called when a contract requires that a specific numeric range is valid and non-negative.</summary>
    /// <param name="fieldMinimum">The index field that this argument is initializing.</param>
    /// <param name="fieldMaximum">The length field that this argument is initializing.</param>
    /// <param name="minimumArgument">The numeric index argument to validate.</param>
    /// <param name="maximumArgument">The numeric length argument to validate.</param>
    /// <param name="minimumArgumentName">The index argument name.</param>
    /// <param name="maximumArgumentName">The length argument name.</param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     At least one of the arguments is negative.
    /// </exception>
    /// <exception cref="ArgumentsNotValidRangeException">
    ///     The maximum argument is smaller than the minimum argument.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ValidNumericNonNegativeRange(
        out double fieldMinimum,
        out double fieldMaximum,
        in double minimumArgument,
        in double maximumArgument,
        [CallerArgumentExpression("minimumArgument")]
        string minimumArgumentName = "minimumArgument",
        [CallerArgumentExpression("maximumArgument")]
        string maximumArgumentName = "maximumArgument")
    {
        if (minimumArgument < 0 || maximumArgument < 0)
        {
            throw new ArgumentNotPositiveIntegerException(minimumArgumentName);
        }

        if (maximumArgument < minimumArgument)
        {
            throw new ArgumentsNotValidRangeException(
                minimumArgumentName,
                maximumArgumentName);
        }

        fieldMinimum = minimumArgument;
        fieldMaximum = maximumArgument;
    }

#endregion

#region Generic numeric range

    /// <summary>Called when a contract requires that a specific numeric range is valid.</summary>
    /// <param name="minimumArgument">The numeric minimum argument to validate.</param>
    /// <param name="maximumArgument">The numeric length argument to validate.</param>
    /// <param name="minimumArgumentName">The minimum argument name.</param>
    /// <param name="maximumArgumentName">The maximum argument name.</param>
    /// <exception cref="ArgumentsNotValidRangeException">
    ///     The maximum argument is smaller than the minimum argument.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ValidNumericRange(
        in short minimumArgument,
        in short maximumArgument,
        [CallerArgumentExpression("minimumArgument")]
        string minimumArgumentName = "minimumArgument",
        [CallerArgumentExpression("maximumArgument")]
        string maximumArgumentName = "maximumArgument")
    {
        if (maximumArgument < minimumArgument)
        {
            throw new ArgumentsNotValidRangeException(
                minimumArgumentName,
                maximumArgumentName);
        }
    }

    /// <summary>Called when a contract requires that a specific numeric range is valid.</summary>
    /// <param name="fieldMinimum">The index field that this argument is initializing.</param>
    /// <param name="fieldMaximum">The length field that this argument is initializing.</param>
    /// <param name="minimumArgument">The numeric index argument to validate.</param>
    /// <param name="maximumArgument">The numeric length argument to validate.</param>
    /// <param name="minimumArgumentName">The index argument name.</param>
    /// <param name="maximumArgumentName">The length argument name.</param>
    /// <exception cref="ArgumentsNotValidRangeException">
    ///     The maximum argument is smaller than the minimum argument.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ValidNumericRange(
        out short fieldMinimum,
        out short fieldMaximum,
        in short minimumArgument,
        in short maximumArgument,
        [CallerArgumentExpression("minimumArgument")]
        string minimumArgumentName = "minimumArgument",
        [CallerArgumentExpression("maximumArgument")]
        string maximumArgumentName = "maximumArgument")
    {
        if (maximumArgument < minimumArgument)
        {
            throw new ArgumentsNotValidRangeException(
                minimumArgumentName,
                maximumArgumentName);
        }

        fieldMinimum = minimumArgument;
        fieldMaximum = maximumArgument;
    }

    /// <summary>Called when a contract requires that a specific numeric range is valid.</summary>
    /// <param name="minimumArgument">The numeric minimum argument to validate.</param>
    /// <param name="maximumArgument">The numeric length argument to validate.</param>
    /// <param name="minimumArgumentName">The minimum argument name.</param>
    /// <param name="maximumArgumentName">The maximum argument name.</param>
    /// <exception cref="ArgumentsNotValidRangeException">
    ///     The maximum argument is smaller than the minimum argument.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ValidNumericRange(
        in int minimumArgument,
        in int maximumArgument,
        [CallerArgumentExpression("minimumArgument")]
        string minimumArgumentName = "minimumArgument",
        [CallerArgumentExpression("maximumArgument")]
        string maximumArgumentName = "maximumArgument")
    {
        if (maximumArgument < minimumArgument)
        {
            throw new ArgumentsNotValidRangeException(
                minimumArgumentName,
                maximumArgumentName);
        }
    }

    /// <summary>Called when a contract requires that a specific numeric range is valid.</summary>
    /// <param name="fieldMinimum">The index field that this argument is initializing.</param>
    /// <param name="fieldMaximum">The length field that this argument is initializing.</param>
    /// <param name="minimumArgument">The numeric index argument to validate.</param>
    /// <param name="maximumArgument">The numeric length argument to validate.</param>
    /// <param name="minimumArgumentName">The index argument name.</param>
    /// <param name="maximumArgumentName">The length argument name.</param>
    /// <exception cref="ArgumentsNotValidRangeException">
    ///     The maximum argument is smaller than the minimum argument.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ValidNumericRange(
        out int fieldMinimum,
        out int fieldMaximum,
        in int minimumArgument,
        in int maximumArgument,
        [CallerArgumentExpression("minimumArgument")]
        string minimumArgumentName = "minimumArgument",
        [CallerArgumentExpression("maximumArgument")]
        string maximumArgumentName = "maximumArgument")
    {
        if (maximumArgument < minimumArgument)
        {
            throw new ArgumentsNotValidRangeException(
                minimumArgumentName,
                maximumArgumentName);
        }

        fieldMinimum = minimumArgument;
        fieldMaximum = maximumArgument;
    }

    /// <summary>Called when a contract requires that a specific numeric range is valid.</summary>
    /// <param name="minimumArgument">The numeric index argument to validate.</param>
    /// <param name="maximumArgument">The numeric length argument to validate.</param>
    /// <param name="minimumArgumentName">The index argument name.</param>
    /// <param name="maximumArgumentName">The length argument name.</param>
    /// <exception cref="ArgumentsNotValidRangeException">
    ///     The maximum argument is smaller than the minimum argument.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ValidNumericRange(
        in long minimumArgument,
        in long maximumArgument,
        [CallerArgumentExpression("minimumArgument")]
        string minimumArgumentName = "minimumArgument",
        [CallerArgumentExpression("maximumArgument")]
        string maximumArgumentName = "maximumArgument")
    {
        if (maximumArgument < minimumArgument)
        {
            throw new ArgumentsNotValidRangeException(
                minimumArgumentName,
                maximumArgumentName);
        }
    }

    /// <summary>Called when a contract requires that a specific numeric range is valid.</summary>
    /// <param name="fieldMinimum">The index field that this argument is initializing.</param>
    /// <param name="fieldMaximum">The length field that this argument is initializing.</param>
    /// <param name="minimumArgument">The numeric index argument to validate.</param>
    /// <param name="maximumArgument">The numeric length argument to validate.</param>
    /// <param name="minimumArgumentName">The index argument name.</param>
    /// <param name="maximumArgumentName">The length argument name.</param>
    /// <exception cref="ArgumentsNotValidRangeException">
    ///     The maximum argument is smaller than the minimum argument.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ValidNumericRange(
        out long fieldMinimum,
        out long fieldMaximum,
        in long minimumArgument,
        in long maximumArgument,
        [CallerArgumentExpression("minimumArgument")]
        string minimumArgumentName = "minimumArgument",
        [CallerArgumentExpression("maximumArgument")]
        string maximumArgumentName = "maximumArgument")
    {
        if (maximumArgument < minimumArgument)
        {
            throw new ArgumentsNotValidRangeException(
                minimumArgumentName,
                maximumArgumentName);
        }

        fieldMinimum = minimumArgument;
        fieldMaximum = maximumArgument;
    }

    /// <summary>Called when a contract requires that a specific numeric range is valid.</summary>
    /// <param name="minimumArgument">The numeric minimum argument to validate.</param>
    /// <param name="maximumArgument">The numeric length argument to validate.</param>
    /// <param name="minimumArgumentName">The minimum argument name.</param>
    /// <param name="maximumArgumentName">The maximum argument name.</param>
    /// <exception cref="ArgumentsNotValidRangeException">
    ///     The maximum argument is smaller than the minimum argument.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ValidNumericRange(
        in float minimumArgument,
        in float maximumArgument,
        [CallerArgumentExpression("minimumArgument")]
        string minimumArgumentName = "minimumArgument",
        [CallerArgumentExpression("maximumArgument")]
        string maximumArgumentName = "maximumArgument")
    {
        if (maximumArgument < minimumArgument)
        {
            throw new ArgumentsNotValidRangeException(
                minimumArgumentName,
                maximumArgumentName);
        }
    }

    /// <summary>Called when a contract requires that a specific numeric range is valid.</summary>
    /// <param name="fieldMinimum">The index field that this argument is initializing.</param>
    /// <param name="fieldMaximum">The length field that this argument is initializing.</param>
    /// <param name="minimumArgument">The numeric index argument to validate.</param>
    /// <param name="maximumArgument">The numeric length argument to validate.</param>
    /// <param name="minimumArgumentName">The index argument name.</param>
    /// <param name="maximumArgumentName">The length argument name.</param>
    /// <exception cref="ArgumentsNotValidRangeException">
    ///     The maximum argument is smaller than the minimum argument.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ValidNumericRange(
        out float fieldMinimum,
        out float fieldMaximum,
        in float minimumArgument,
        in float maximumArgument,
        [CallerArgumentExpression("minimumArgument")]
        string minimumArgumentName = "minimumArgument",
        [CallerArgumentExpression("maximumArgument")]
        string maximumArgumentName = "maximumArgument")
    {
        if (maximumArgument < minimumArgument)
        {
            throw new ArgumentsNotValidRangeException(
                minimumArgumentName,
                maximumArgumentName);
        }

        fieldMinimum = minimumArgument;
        fieldMaximum = maximumArgument;
    }

    /// <summary>Called when a contract requires that a specific numeric range is valid.</summary>
    /// <param name="minimumArgument">The numeric minimum argument to validate.</param>
    /// <param name="maximumArgument">The numeric length argument to validate.</param>
    /// <param name="minimumArgumentName">The minimum argument name.</param>
    /// <param name="maximumArgumentName">The maximum argument name.</param>
    /// <exception cref="ArgumentsNotValidRangeException">
    ///     The maximum argument is smaller than the minimum argument.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ValidNumericRange(
        in double minimumArgument,
        in double maximumArgument,
        [CallerArgumentExpression("minimumArgument")]
        string minimumArgumentName = "minimumArgument",
        [CallerArgumentExpression("maximumArgument")]
        string maximumArgumentName = "maximumArgument")
    {
        if (maximumArgument < minimumArgument)
        {
            throw new ArgumentsNotValidRangeException(
                minimumArgumentName,
                maximumArgumentName);
        }
    }

    /// <summary>Called when a contract requires that a specific numeric range is valid.</summary>
    /// <param name="fieldMinimum">The index field that this argument is initializing.</param>
    /// <param name="fieldMaximum">The length field that this argument is initializing.</param>
    /// <param name="minimumArgument">The numeric index argument to validate.</param>
    /// <param name="maximumArgument">The numeric length argument to validate.</param>
    /// <param name="minimumArgumentName">The index argument name.</param>
    /// <param name="maximumArgumentName">The length argument name.</param>
    /// <exception cref="ArgumentsNotValidRangeException">
    ///     The maximum argument is smaller than the minimum argument.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ValidNumericRange(
        out double fieldMinimum,
        out double fieldMaximum,
        in double minimumArgument,
        in double maximumArgument,
        [CallerArgumentExpression("minimumArgument")]
        string minimumArgumentName = "minimumArgument",
        [CallerArgumentExpression("maximumArgument")]
        string maximumArgumentName = "maximumArgument")
    {
        if (maximumArgument < minimumArgument)
        {
            throw new ArgumentsNotValidRangeException(
                minimumArgumentName,
                maximumArgumentName);
        }

        fieldMinimum = minimumArgument;
        fieldMaximum = maximumArgument;
    }

#endregion

#region Array index and range

    /// <summary>Called when a contract requires that a specific index is valid for an array.</summary>
    /// <typeparam name="T">The type of items in the array.</typeparam>
    /// <param name="argument">The numeric argument to validate.</param>
    /// <param name="array">The array for which we are validating the index.</param>
    /// <param name="argumentName">The argument name.</param>
    /// <param name="arrayName">The array argument name.</param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is either negative or exceeds the bounds of the
    ///     array.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ValidArrayIndex<T>(
        in int argument,
        T[] array,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument",
        [CallerArgumentExpression("array")]
        string arrayName = "array")
    {
        if (array == null)
        {
            throw new ArgumentNullException(arrayName);
        }

        if (argument < 0 || argument >= array.Length)
        {
            throw new ArgumentNotValidIndexException(argumentName);
        }
    }

    /// <summary>Called when a contract requires that a specific index is valid for an array.</summary>
    /// <typeparam name="T">The type of items in the array.</typeparam>
    /// <param name="field">The field that this argument is initializing.</param>
    /// <param name="argument">The numeric argument to validate.</param>
    /// <param name="array">The array for which we are validating the index.</param>
    /// <param name="argumentName">The argument name.</param>
    /// <param name="arrayName">The array argument name.</param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is either negative or exceeds the bounds of the
    ///     array.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ValidArrayIndex<T>(
        out int field,
        in int argument,
        T[] array,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument",
        [CallerArgumentExpression("array")]
        string arrayName = "array")
    {
        if (array == null)
        {
            throw new ArgumentNullException(arrayName);
        }

        if (argument < 0 || argument >= array.Length)
        {
            throw new ArgumentNotValidIndexException(argumentName);
        }

        field = argument;
    }

    /// <summary>Called when a contract requires that a specific index is valid for an array.</summary>
    /// <typeparam name="T">The type of items in the array.</typeparam>
    /// <param name="argument">The numeric argument to validate.</param>
    /// <param name="array">The array for which we are validating the index.</param>
    /// <param name="argumentName">The argument name.</param>
    /// <param name="arrayName">The array argument name.</param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is either negative or exceeds the bounds of the
    ///     array.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ValidArrayIndex<T>(
        in long argument,
        T[] array,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument",
        [CallerArgumentExpression("array")]
        string arrayName = "array")
    {
        if (array == null)
        {
            throw new ArgumentNullException(arrayName);
        }

        if (argument < 0 || argument >= array.LongLength)
        {
            throw new ArgumentNotValidIndexException(argumentName);
        }
    }

    /// <summary>Called when a contract requires that a specific index is valid for an array.</summary>
    /// <typeparam name="T">The type of items in the array.</typeparam>
    /// <param name="field">The field that this argument is initializing.</param>
    /// <param name="argument">The numeric argument to validate.</param>
    /// <param name="array">The array for which we are validating the index.</param>
    /// <param name="argumentName">The argument name.</param>
    /// <param name="arrayName">The array argument name.</param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is either negative or exceeds the bounds of the
    ///     array.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ValidArrayIndex<T>(
        out long field,
        in long argument,
        T[] array,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument",
        [CallerArgumentExpression("array")]
        string arrayName = "array")
    {
        if (array == null)
        {
            throw new ArgumentNullException(arrayName);
        }

        if (argument < 0 || argument >= array.LongLength)
        {
            throw new ArgumentNotValidIndexException(argumentName);
        }

        field = argument;
    }

    /// <summary>Called when a contract requires that a specific index and length, constituting a range, is valid for an array.</summary>
    /// <typeparam name="T">The type of items in the array.</typeparam>
    /// <param name="indexArgument">The numeric index argument to validate.</param>
    /// <param name="lengthArgument">The numeric length argument to validate.</param>
    /// <param name="array">The array for which we are validating the range.</param>
    /// <param name="indexArgumentName">The index argument name.</param>
    /// <param name="lengthArgumentName">The length argument name.</param>
    /// <param name="arrayArgumentName">The array argument name.</param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is either negative or exceeds the bounds of the
    ///     array.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ValidArrayRange<T>(
        in int indexArgument,
        in int lengthArgument,
        T[] array,
        [CallerArgumentExpression("indexArgument")]
        string indexArgumentName = "indexArgument",
        [CallerArgumentExpression("lengthArgument")]
        string lengthArgumentName = "lengthArgument",
        [CallerArgumentExpression("array")]
        string arrayArgumentName = "array")
    {
        if (array == null)
        {
            throw new ArgumentNullException(arrayArgumentName);
        }

        if (indexArgument < 0 || indexArgument >= array.Length)
        {
            throw new ArgumentNotValidIndexException(indexArgumentName);
        }

        if (lengthArgument <= 0 || indexArgument + lengthArgument > array.Length)
        {
            throw new ArgumentsNotValidRangeException(
                indexArgumentName,
                lengthArgumentName);
        }
    }

    /// <summary>Called when a contract requires that a specific index and length, constituting a range, is valid for an array.</summary>
    /// <typeparam name="T">The type of items in the array.</typeparam>
    /// <param name="fieldIndex">The index field that this argument is initializing.</param>
    /// <param name="fieldLength">The length field that this argument is initializing.</param>
    /// <param name="indexArgument">The numeric index argument to validate.</param>
    /// <param name="lengthArgument">The numeric length argument to validate.</param>
    /// <param name="array">The array for which we are validating the range.</param>
    /// <param name="indexArgumentName">The index argument name.</param>
    /// <param name="lengthArgumentName">The length argument name.</param>
    /// <param name="arrayArgumentName">The array argument name.</param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is either negative or exceeds the bounds of the
    ///     array.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ValidArrayRange<T>(
        out int fieldIndex,
        out int fieldLength,
        in int indexArgument,
        in int lengthArgument,
        T[] array,
        [CallerArgumentExpression("indexArgument")]
        string indexArgumentName = "indexArgument",
        [CallerArgumentExpression("lengthArgument")]
        string lengthArgumentName = "lengthArgument",
        [CallerArgumentExpression("array")]
        string arrayArgumentName = "array")
    {
        if (array == null)
        {
            throw new ArgumentNullException(arrayArgumentName);
        }

        if (indexArgument < 0 || indexArgument >= array.Length)
        {
            throw new ArgumentNotValidIndexException(indexArgumentName);
        }

        if (lengthArgument <= 0 || indexArgument + lengthArgument > array.Length)
        {
            throw new ArgumentsNotValidRangeException(
                indexArgumentName,
                lengthArgumentName);
        }

        fieldIndex = indexArgument;
        fieldLength = lengthArgument;
    }

    /// <summary>Called when a contract requires that a specific index and length, constituting a range, is valid for an array.</summary>
    /// <typeparam name="T">The type of items in the array.</typeparam>
    /// <param name="indexArgument">The numeric index argument to validate.</param>
    /// <param name="lengthArgument">The numeric length argument to validate.</param>
    /// <param name="array">The array for which we are validating the range.</param>
    /// <param name="indexArgumentName">The index argument name.</param>
    /// <param name="lengthArgumentName">The length argument name.</param>
    /// <param name="arrayArgumentName">The array argument name.</param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is either negative or exceeds the bounds of the
    ///     array.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ValidArrayRange<T>(
        in long indexArgument,
        in long lengthArgument,
        T[] array,
        [CallerArgumentExpression("indexArgument")]
        string indexArgumentName = "indexArgument",
        [CallerArgumentExpression("lengthArgument")]
        string lengthArgumentName = "lengthArgument",
        [CallerArgumentExpression("array")]
        string arrayArgumentName = "array")
    {
        if (array == null)
        {
            throw new ArgumentNullException(arrayArgumentName);
        }

        if (indexArgument < 0 || indexArgument >= array.LongLength)
        {
            throw new ArgumentNotValidIndexException(indexArgumentName);
        }

        if (lengthArgument <= 0 || indexArgument + lengthArgument > array.LongLength)
        {
            throw new ArgumentsNotValidRangeException(
                indexArgumentName,
                lengthArgumentName);
        }
    }

    /// <summary>Called when a contract requires that a specific index and length, constituting a range, is valid for an array.</summary>
    /// <typeparam name="T">The type of items in the array.</typeparam>
    /// <param name="fieldIndex">The index field that this argument is initializing.</param>
    /// <param name="fieldLength">The length field that this argument is initializing.</param>
    /// <param name="indexArgument">The numeric index argument to validate.</param>
    /// <param name="lengthArgument">The numeric length argument to validate.</param>
    /// <param name="array">The array for which we are validating the range.</param>
    /// <param name="indexArgumentName">The index argument name.</param>
    /// <param name="lengthArgumentName">The length argument name.</param>
    /// <param name="arrayArgumentName">The array argument name.</param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is either negative or exceeds the bounds of the
    ///     array.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ValidArrayRange<T>(
        out long fieldIndex,
        out long fieldLength,
        in long indexArgument,
        in long lengthArgument,
        T[] array,
        [CallerArgumentExpression("indexArgument")]
        string indexArgumentName = "indexArgument",
        [CallerArgumentExpression("lengthArgument")]
        string lengthArgumentName = "lengthArgument",
        [CallerArgumentExpression("array")]
        string arrayArgumentName = "array")
    {
        if (array == null)
        {
            throw new ArgumentNullException(arrayArgumentName);
        }

        if (indexArgument < 0 || indexArgument >= array.LongLength)
        {
            throw new ArgumentNotValidIndexException(indexArgumentName);
        }

        if (lengthArgument <= 0 || indexArgument + lengthArgument > array.LongLength)
        {
            throw new ArgumentsNotValidRangeException(
                indexArgumentName,
                lengthArgumentName);
        }

        fieldIndex = indexArgument;
        fieldLength = lengthArgument;
    }

    /// <summary>Called when a contract requires that a specific length is valid for an array.</summary>
    /// <typeparam name="T">The type of items in the array.</typeparam>
    /// <param name="argument">The numeric argument to validate.</param>
    /// <param name="array">The array for which we are validating the length.</param>
    /// <param name="argumentName">The argument name.</param>
    /// <param name="arrayArgumentName">The array argument name.</param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is either negative or exceeds the bounds of the
    ///     array.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ValidArrayLength<T>(
        in int argument,
        T[] array,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument",
        [CallerArgumentExpression("array")]
        string arrayArgumentName = "array")
    {
        if (array == null)
        {
            throw new ArgumentNullException(arrayArgumentName);
        }

        if (argument <= 0 || argument > array.Length)
        {
            throw new ArgumentNotValidLengthException(argumentName);
        }
    }

    /// <summary>Called when a contract requires that a specific length is valid for an array.</summary>
    /// <typeparam name="T">The type of items in the array.</typeparam>
    /// <param name="field">The field that this argument is initializing.</param>
    /// <param name="argument">The numeric argument to validate.</param>
    /// <param name="array">The array for which we are validating the length.</param>
    /// <param name="argumentName">The argument name.</param>
    /// <param name="arrayArgumentName">The array argument name.</param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is either negative or exceeds the bounds of the
    ///     array.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ValidArrayLength<T>(
        out int field,
        in int argument,
        T[] array,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument",
        [CallerArgumentExpression("array")]
        string arrayArgumentName = "array")
    {
        if (array == null)
        {
            throw new ArgumentNullException(arrayArgumentName);
        }

        if (argument <= 0 || argument > array.Length)
        {
            throw new ArgumentNotValidLengthException(argumentName);
        }

        field = argument;
    }

    /// <summary>Called when a contract requires that a specific length is valid for an array.</summary>
    /// <typeparam name="T">The type of items in the array.</typeparam>
    /// <param name="argument">The numeric argument to validate.</param>
    /// <param name="array">The array for which we are validating the length.</param>
    /// <param name="argumentName">The argument name.</param>
    /// <param name="arrayArgumentName">The array argument name.</param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is either negative or exceeds the bounds of the
    ///     array.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ValidArrayLength<T>(
        in long argument,
        in T[] array,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument",
        [CallerArgumentExpression("array")]
        string arrayArgumentName = "array")
    {
        if (array == null)
        {
            throw new ArgumentNullException(arrayArgumentName);
        }

        if (argument <= 0 || argument > array.LongLength)
        {
            throw new ArgumentNotValidLengthException(argumentName);
        }
    }

    /// <summary>Called when a contract requires that a specific length is valid for an array.</summary>
    /// <typeparam name="T">The type of items in the array.</typeparam>
    /// <param name="field">The field that this argument is initializing.</param>
    /// <param name="argument">The numeric argument to validate.</param>
    /// <param name="array">The array for which we are validating the length.</param>
    /// <param name="argumentName">The argument name.</param>
    /// <param name="arrayArgumentName">The array argument name.</param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is either negative or exceeds the bounds of the
    ///     array.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ValidArrayLength<T>(
        out long field,
        in long argument,
        in T[] array,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument",
        [CallerArgumentExpression("array")]
        string arrayArgumentName = "array")
    {
        if (array == null)
        {
            throw new ArgumentNullException(arrayArgumentName);
        }

        if (argument <= 0 || argument > array.LongLength)
        {
            throw new ArgumentNotValidLengthException(argumentName);
        }

        field = argument;
    }

#endregion

#region True and false

    /// <summary>
    ///     Called when a contract requires that a condition is true.
    /// </summary>
    /// <param name="condition">
    ///     The condition that should be evaluated.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <returns>
    ///     The validated argument.
    /// </returns>
    /// <exception cref="ArgumentException">
    ///     The condition is not being met.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [AssertionMethod]
    public static bool True(
        [AssertionCondition(AssertionConditionType.IS_TRUE)]
        bool condition,
        [CallerArgumentExpression("condition")]
        string argumentName = "condition")
    {
        if (!condition)
        {
            throw new ArgumentException(
                Resources.AContractConditionIsNotBeingMet,
                argumentName);
        }

        return condition;
    }

    /// <summary>
    ///     Called when a contract requires that a condition is true.
    /// </summary>
    /// <param name="field">The field that this argument is initializing.</param>
    /// <param name="condition">
    ///     The condition that should be evaluated.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentException">
    ///     The condition is not being met.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [AssertionMethod]
    public static void True(
        out bool field,
        [AssertionCondition(AssertionConditionType.IS_TRUE)]
        bool condition,
        [CallerArgumentExpression("condition")]
        string argumentName = "condition")
    {
        if (!condition)
        {
            throw new ArgumentException(
                Resources.AContractConditionIsNotBeingMet,
                argumentName);
        }

        field = condition;
    }

    /// <summary>
    ///     Called when a contract requires that a condition is false.
    /// </summary>
    /// <param name="condition">
    ///     The condition that should be evaluated.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <returns>
    ///     The validated argument.
    /// </returns>
    /// <exception cref="ArgumentException">
    ///     The condition is not being met.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [AssertionMethod]
    public static bool False(
        [AssertionCondition(AssertionConditionType.IS_FALSE)]
        bool condition,
        [CallerArgumentExpression("condition")]
        string argumentName = "condition")
    {
        if (condition)
        {
            throw new ArgumentException(
                Resources.AContractConditionIsNotBeingMet,
                argumentName);
        }

        return condition;
    }

    /// <summary>
    ///     Called when a contract requires that a condition is false.
    /// </summary>
    /// <param name="field">The field that this argument is initializing.</param>
    /// <param name="condition">
    ///     The condition that should be evaluated.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentException">
    ///     The condition is not being met.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [AssertionMethod]
    public static void False(
        out bool field,
        [AssertionCondition(AssertionConditionType.IS_FALSE)]
        bool condition,
        [CallerArgumentExpression("condition")]
        string argumentName = "condition")
    {
        if (condition)
        {
            throw new ArgumentException(
                Resources.AContractConditionIsNotBeingMet,
                argumentName);
        }

        field = condition;
    }
#endregion

#region Argument of type

    /// <summary>
    ///     Called when a contract requires that an argument is of a specific type.
    /// </summary>
    /// <typeparam name="T">
    ///     The type to check the argument for.
    /// </typeparam>
    /// <param name="argument">
    ///     The argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <returns>
    ///     The converted argument.
    /// </returns>
    /// <exception cref="ArgumentInvalidTypeException">
    ///     The condition is not being met.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [ContractAnnotation("argument:null => halt")]
    [AssertionMethod]
    public static T ArgumentOfType<T>(
        [NoEnumeration][AssertionCondition(AssertionConditionType.IS_NOT_NULL)] object? argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument is not T convertedValue)
        {
            throw new ArgumentInvalidTypeException(argumentName);
        }

        return convertedValue;
    }

    /// <summary>
    ///     Called when a contract requires that an argument is of a specific type.
    /// </summary>
    /// <typeparam name="T">
    ///     The type to check the argument for.
    /// </typeparam>
    /// <param name="field">The field that this argument is initializing.</param>
    /// <param name="argument">
    ///     The argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentInvalidTypeException">
    ///     The condition is not being met.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [ContractAnnotation("argument:null => halt")]
    [AssertionMethod]
    public static void ArgumentOfType<T>(
        out T field,
        [NoEnumeration, AssertionCondition(AssertionConditionType.IS_NOT_NULL)] object? argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument is not T convertedValue)
        {
            throw new ArgumentInvalidTypeException(argumentName);
        }

        field = convertedValue;
    }
#endregion

#region Not disposed

    /// <summary>
    ///     Called when a contract requires that an argument is not disposed.
    /// </summary>
    /// <param name="reference">
    ///     The object reference to check for disposed.
    /// </param>
    /// <exception cref="ObjectDisposedException">If the reference object is disposed, this exception will be thrown.</exception>
    public static void NotDisposed(DisposableBase reference) =>
        NotNull(
                reference,
                nameof(reference))
            .ThrowIfCurrentObjectDisposed();

    /// <summary>
    ///     Called when a contract requires that an argument is not disposed.
    /// </summary>
    /// <param name="reference">
    ///     The object reference to check for disposed.
    /// </param>
    /// <exception cref="ObjectDisposedException">If the reference object is disposed, this exception will be thrown.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void RequiresNotDisposed(this DisposableBase reference) =>
        NotNull(
                reference,
                nameof(reference))
            .ThrowIfCurrentObjectDisposed();

#endregion

#region Found by ID

    /// <summary>
    ///     Called when a contract requires that an item is found by its identifier.
    /// </summary>
    /// <param name="source">The items source.</param>
    /// <param name="id">The identifier to seek.</param>
    /// <param name="sourceName">The name of the source collection to seek in.</param>
    /// <param name="idName">The name of the identifier parameter.</param>
    /// <typeparam name="TItem">The type of keyed item in the collection.</typeparam>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <returns>The item that was found.</returns>
    /// <exception cref="ArgumentNullException">Either the source collection or the identifier are <c>null</c> (<c>Nothing</c> in Visual Basic).</exception>
    /// <exception cref="IdCorrespondsToNoItemException">There is no usable item in the source collection that can be fetched by the supplied identifier.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [ContractAnnotation("source:null => halt; id:null => halt")]
    [AssertionMethod]
    [DiagCA.SuppressMessage(
        "Performance",
        "HAA0301:Closure Allocation Source",
        Justification = "LINQ used, unavoidable.")]
    [DiagCA.SuppressMessage(
        "Performance",
        "HAA0303:Lambda or anonymous method in a generic method allocates a delegate instance",
        Justification = "LINQ used, unavoidable.")]
    [DiagCA.SuppressMessage(
        "Performance",
        "HAA0302:Display class allocation to capture closure",
        Justification = "LINQ used, unavoidable.")]
    public static TItem ItemFoundById<TItem, TKey>(
        IEnumerable<TItem> source,
        TKey id,
        [CallerArgumentExpression("source")]
        string sourceName = "source",
        [CallerArgumentExpression("id")]
        string idName = "id")
        where TItem : IKeyedEntity<TKey>
    {
        if (source == null)
        {
            throw new ArgumentNullException(sourceName);
        }

        if (id == null)
        {
            throw new ArgumentNullException(idName);
        }

        var item = source.FirstOrDefault(p => EqualityComparer<TKey>.Default.Equals(p.Id, id));

        if (item is null || EqualityComparer<TItem>.Default.Equals(item, default!))
        {
            throw new IdCorrespondsToNoItemException(idName);
        }

        return item;
    }

#endregion

#region Valid entity ID

    /// <summary>
    ///     Called when a contract requires that a value is a valid identifier for an entity.
    /// </summary>
    /// <param name="argument">
    ///     The argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <returns>The value given as input.</returns>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is not a valid entity identifier.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int ValidEntityId(
        in int argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument <= 0)
        {
            throw new ArgumentNotPositiveIntegerException(argumentName);
        }

        return argument;
    }

    /// <summary>
    ///     Called when a contract requires that a value is a valid identifier for an entity.
    /// </summary>
    /// <param name="field">
    ///     The field value to set to the correct identifier.
    /// </param>
    /// <param name="argument">
    ///     The argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is not a valid entity identifier.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ValidEntityId(
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
    ///     Called when a contract requires that a value is a valid identifier for an entity.
    /// </summary>
    /// <param name="argument">
    ///     The argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <returns>The value given as input.</returns>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is not a valid entity identifier.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long ValidEntityId(
        in long argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument <= 0L)
        {
            throw new ArgumentNotPositiveIntegerException(argumentName);
        }

        return argument;
    }

    /// <summary>
    ///     Called when a contract requires that a value is a valid identifier for an entity.
    /// </summary>
    /// <param name="field">
    ///     The field value to set to the correct identifier.
    /// </param>
    /// <param name="argument">
    ///     The argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is not a valid entity identifier.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ValidEntityId(
        out long field,
        in long argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument <= 0L)
        {
            throw new ArgumentNotPositiveIntegerException(argumentName);
        }

        field = argument;
    }

#endregion
}