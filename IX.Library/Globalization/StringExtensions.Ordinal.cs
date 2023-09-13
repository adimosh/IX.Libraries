using IX.Library.Contracts;

namespace IX.Library.Globalization;

/// <summary>
///     Extensions to strings to help with globalization.
/// </summary>
public static partial class StringExtensions
{
    /// <summary>
    ///     Compares the source string with a selected value in a case-sensitive manner using the comparison rules of the UI
    ///     thread culture.
    /// </summary>
    /// <param name="source">The source to search in.</param>
    /// <param name="value">The string value to do the evaluation.</param>
    /// <returns>
    ///     The comparison of the two strings, with 0 meaning equality.
    /// </returns>
    public static int OrdinalCompareTo(
        this string source,
        string value) =>
        string.Compare(
            source,
            value,
            StringComparison.Ordinal);

    /// <summary>
    ///     Compares the source string with a selected value in a case-insensitive manner using the comparison rules of the UI
    ///     thread culture.
    /// </summary>
    /// <param name="source">The source to search in.</param>
    /// <param name="value">The string value to do the evaluation.</param>
    /// <returns>
    ///     The comparison of the two strings, with 0 meaning equality.
    /// </returns>
    public static int OrdinalCompareToInsensitive(
        this string source,
        string value) =>
        string.Compare(
            source,
            value,
            StringComparison.OrdinalIgnoreCase);

    /// <summary>
    ///     Determines whether a source string contains the specified value string in a case-sensitive manner using the
    ///     comparison rules of the UI thread culture.
    /// </summary>
    /// <param name="source">The source to search in.</param>
    /// <param name="value">The string value to do the evaluation.</param>
    /// <returns>
    ///     <see langword="true" /> if the source string contains the specified value string; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    public static bool OrdinalContains(
        this string source,
        string value) =>
        source.OrdinalIndexOf(value) >= 0;

    /// <summary>
    ///     Determines whether a source string contains the specified value string in a case-insensitive manner using the
    ///     comparison rules of the UI thread culture.
    /// </summary>
    /// <param name="source">The source to search in.</param>
    /// <param name="value">The string value to do the evaluation.</param>
    /// <returns>
    ///     <see langword="true" /> if the source string contains the specified value string; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    public static bool OrdinalContainsInsensitive(
        this string source,
        string value) =>
        source.OrdinalIndexOfInsensitive(value) >= 0;

    /// <summary>
    ///     Checks whether or not the source string ends with a selected value in a case-sensitive manner using the comparison
    ///     rules of the UI thread culture.
    /// </summary>
    /// <param name="source">The source to search in.</param>
    /// <param name="value">The string value to do the evaluation.</param>
    /// <returns>
    ///     <see langword="true" /> if the source string is equal to the value; otherwise, <see langword="false" />.
    /// </returns>
    public static bool OrdinalEndsWith(
        this string source,
        string value) =>
        Requires.NotNull(source)
            .EndsWith(
                value,
                StringComparison.Ordinal);

    /// <summary>
    ///     Checks whether or not the source string ends with a selected value in a case-insensitive manner using the
    ///     comparison rules of the UI thread culture.
    /// </summary>
    /// <param name="source">The source to search in.</param>
    /// <param name="value">The string value to do the evaluation.</param>
    /// <returns>
    ///     <see langword="true" /> if the source string is equal to the value; otherwise, <see langword="false" />.
    /// </returns>
    public static bool OrdinalEndsWithInsensitive(
        this string source,
        string value) =>
        Requires.NotNull(source)
            .EndsWith(
                value,
                StringComparison.OrdinalIgnoreCase);

    /// <summary>
    ///     Equates the source string with a selected value in a case-sensitive manner using the comparison rules of the UI
    ///     thread culture.
    /// </summary>
    /// <param name="source">The source to search in.</param>
    /// <param name="value">The string value to do the evaluation.</param>
    /// <returns>
    ///     <see langword="true" /> if the source string is equal to the value; otherwise, <see langword="false" />.
    /// </returns>
    public static bool OrdinalEquals(
        this string source,
        string value) =>
        source.OrdinalCompareTo(value) == 0;

    /// <summary>
    ///     Equates the source string with a selected value in a case-insensitive manner using the comparison rules of the UI
    ///     thread culture.
    /// </summary>
    /// <param name="source">The source to search in.</param>
    /// <param name="value">The string value to do the evaluation.</param>
    /// <returns>
    ///     <see langword="true" /> if the source string is equal to the value; otherwise, <see langword="false" />.
    /// </returns>
    public static bool OrdinalEqualsInsensitive(
        this string source,
        string value) =>
        source.OrdinalCompareToInsensitive(value) == 0;

    /// <summary>
    ///     Finds the index of the specified value string in a source string in a case-sensitive manner using the comparison
    ///     rules of the UI thread culture.
    /// </summary>
    /// <param name="source">The source to search in.</param>
    /// <param name="value">The string value to do the evaluation.</param>
    /// <returns>
    ///     The index where the string is found, otherwise -1.
    /// </returns>
    public static int OrdinalIndexOf(
        this string source,
        string value) =>
        Requires.NotNull(source)
            .IndexOf(
                value,
                StringComparison.Ordinal);

    /// <summary>
    ///     Finds the index of the specified value string in a source string in a case-sensitive manner using the comparison
    ///     rules of the UI thread culture.
    /// </summary>
    /// <param name="source">The source to search in.</param>
    /// <param name="value">The string value to do the evaluation.</param>
    /// <param name="startIndex">The index in the source string to start searching at.</param>
    /// <returns>The index where the string is found, otherwise -1.</returns>
    public static int OrdinalIndexOf(
        this string source,
        string value,
        int startIndex) =>
        Requires.NotNull(source)
            .IndexOf(
                value,
                startIndex,
                StringComparison.Ordinal);

    /// <summary>
    ///     Finds the index of the specified value string in a source string in a case-sensitive manner using the comparison
    ///     rules of the UI thread culture.
    /// </summary>
    /// <param name="source">The source to search in.</param>
    /// <param name="value">The string value to do the evaluation.</param>
    /// <param name="startIndex">The index in the source string to start searching at.</param>
    /// <param name="count">The number of characters to search.</param>
    /// <returns>The index where the string is found, otherwise -1.</returns>
    public static int OrdinalIndexOf(
        this string source,
        string value,
        int startIndex,
        int count) =>
        Requires.NotNull(source)
            .IndexOf(
                value,
                startIndex,
                count,
                StringComparison.Ordinal);

    /// <summary>
    ///     Finds the index of the specified value string in a source string in a case-insensitive manner using the comparison
    ///     rules of the UI thread culture.
    /// </summary>
    /// <param name="source">The source to search in.</param>
    /// <param name="value">The string value to do the evaluation.</param>
    /// <returns>
    ///     The index where the string is found, otherwise -1.
    /// </returns>
    public static int OrdinalIndexOfInsensitive(
        this string source,
        string value) =>
        Requires.NotNull(source)
            .IndexOf(
                value,
                StringComparison.OrdinalIgnoreCase);

    /// <summary>
    ///     Finds the index of the specified value string in a source string in a case-insensitive manner using the comparison
    ///     rules of the UI thread culture.
    /// </summary>
    /// <param name="source">The source to search in.</param>
    /// <param name="value">The string value to do the evaluation.</param>
    /// <param name="startIndex">The index in the source string to start searching at.</param>
    /// <returns>The index where the string is found, otherwise -1.</returns>
    public static int OrdinalIndexOfInsensitive(
        this string source,
        string value,
        int startIndex) =>
        Requires.NotNull(source)
            .IndexOf(
                value,
                startIndex,
                StringComparison.OrdinalIgnoreCase);

    /// <summary>
    ///     Finds the index of the specified value string in a source string in a case-insensitive manner using the comparison
    ///     rules of the UI thread culture.
    /// </summary>
    /// <param name="source">The source to search in.</param>
    /// <param name="value">The string value to do the evaluation.</param>
    /// <param name="startIndex">The index in the source string to start searching at.</param>
    /// <param name="count">The number of characters to search.</param>
    /// <returns>The index where the string is found, otherwise -1.</returns>
    public static int OrdinalIndexOfInsensitive(
        this string source,
        string value,
        int startIndex,
        int count) =>
        Requires.NotNull(source)
            .IndexOf(
                value,
                startIndex,
                count,
                StringComparison.OrdinalIgnoreCase);

    /// <summary>
    ///     Checks whether or not the source string starts with a selected value in a case-sensitive manner using the
    ///     comparison rules of the UI thread culture.
    /// </summary>
    /// <param name="source">The source to search in.</param>
    /// <param name="value">The string value to do the evaluation.</param>
    /// <returns>
    ///     <see langword="true" /> if the source string is equal to the value; otherwise, <see langword="false" />.
    /// </returns>
    public static bool OrdinalStartsWith(
        this string source,
        string value) =>
        Requires.NotNull(source)
            .StartsWith(
                value,
                StringComparison.Ordinal);

    /// <summary>
    ///     Checks whether or not the source string starts with a selected value in a case-insensitive manner using the
    ///     comparison rules of the UI thread culture.
    /// </summary>
    /// <param name="source">The source to search in.</param>
    /// <param name="value">The string value to do the evaluation.</param>
    /// <returns>
    ///     <see langword="true" /> if the source string is equal to the value; otherwise, <see langword="false" />.
    /// </returns>
    public static bool OrdinalStartsWithInsensitive(
        this string source,
        string value) =>
        Requires.NotNull(source)
            .StartsWith(
                value,
                StringComparison.OrdinalIgnoreCase);
}