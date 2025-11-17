using System.Globalization;

namespace IX.Library.Globalization;

/// <summary>
///     Extensions to strings to help with globalization.
/// </summary>
public static partial class StringExtensions
{
    /// <param name="source">The source to search in.</param>
    extension(string source)
    {
        /// <summary>
        ///     Compares the source string with a selected value in a case-sensitive manner using the comparison rules of the
        ///     invariant culture.
        /// </summary>
        /// <param name="value">The string value to do the evaluation.</param>
        /// <returns>
        ///     The comparison of the two strings, with 0 meaning equality.
        /// </returns>
        public int InvariantCultureCompareTo(string value) =>
            CultureInfo.InvariantCulture.CompareInfo.Compare(
                source,
                value,
                CompareOptions.None);

        /// <summary>
        ///     Compares the source string with a selected value in a case-insensitive manner using the comparison rules of the
        ///     invariant culture.
        /// </summary>
        /// <param name="value">The string value to do the evaluation.</param>
        /// <returns>
        ///     The comparison of the two strings, with 0 meaning equality.
        /// </returns>
        public int InvariantCultureCompareToInsensitive(string value) =>
            CultureInfo.InvariantCulture.CompareInfo.Compare(
                source,
                value,
                CompareOptions.IgnoreCase);

        /// <summary>
        ///     Determines whether a source string contains the specified value string in a case-sensitive manner using the
        ///     comparison rules of the invariant culture.
        /// </summary>
        /// <param name="value">The string value to do the evaluation.</param>
        /// <returns>
        ///     <see langword="true" /> if the source string contains the specified value string; otherwise,
        ///     <see langword="false" />.
        /// </returns>
        public bool InvariantCultureContains(string value) =>
            source.InvariantCultureIndexOf(value) >= 0;

        /// <summary>
        ///     Determines whether a source string contains the specified value string in a case-insensitive manner using the
        ///     comparison rules of the invariant culture.
        /// </summary>
        /// <param name="value">The string value to do the evaluation.</param>
        /// <returns>
        ///     <see langword="true" /> if the source string contains the specified value string; otherwise,
        ///     <see langword="false" />.
        /// </returns>
        public bool InvariantCultureContainsInsensitive(string value) =>
            source.InvariantCultureIndexOfInsensitive(value) >= 0;

        /// <summary>
        ///     Checks whether or not the source string ends with a selected value in a case-sensitive manner using the comparison
        ///     rules of the invariant culture.
        /// </summary>
        /// <param name="value">The string value to do the evaluation.</param>
        /// <returns>
        ///     <see langword="true" /> if the source string is equal to the value; otherwise, <see langword="false" />.
        /// </returns>
        public bool InvariantCultureEndsWith(string value) =>
            CultureInfo.InvariantCulture.CompareInfo.IsSuffix(
                source,
                value,
                CompareOptions.None);

        /// <summary>
        ///     Checks whether or not the source string ends with a selected value in a case-insensitive manner using the
        ///     comparison rules of the invariant culture.
        /// </summary>
        /// <param name="value">The string value to do the evaluation.</param>
        /// <returns>
        ///     <see langword="true" /> if the source string is equal to the value; otherwise, <see langword="false" />.
        /// </returns>
        public bool InvariantCultureEndsWithInsensitive(string value) =>
            CultureInfo.InvariantCulture.CompareInfo.IsSuffix(
                source,
                value,
                CompareOptions.IgnoreCase);

        /// <summary>
        ///     Equates the source string with a selected value in a case-sensitive manner using the comparison rules of the
        ///     invariant culture.
        /// </summary>
        /// <param name="value">The string value to do the evaluation.</param>
        /// <returns>
        ///     <see langword="true" /> if the source string is equal to the value; otherwise, <see langword="false" />.
        /// </returns>
        public bool InvariantCultureEquals(string value) =>
            source.InvariantCultureCompareTo(value) == 0;

        /// <summary>
        ///     Equates the source string with a selected value in a case-insensitive manner using the comparison rules of the
        ///     invariant culture.
        /// </summary>
        /// <param name="value">The string value to do the evaluation.</param>
        /// <returns>
        ///     <see langword="true" /> if the source string is equal to the value; otherwise, <see langword="false" />.
        /// </returns>
        public bool InvariantCultureEqualsInsensitive(string value) =>
            source.InvariantCultureCompareToInsensitive(value) == 0;

        /// <summary>
        ///     Finds the index of the specified value string in a source string in a case-sensitive manner using the comparison
        ///     rules of the invariant culture.
        /// </summary>
        /// <param name="value">The string value to do the evaluation.</param>
        /// <returns>
        ///     The index where the string is found, otherwise -1.
        /// </returns>
        public int InvariantCultureIndexOf(string value) =>
            CultureInfo.InvariantCulture.CompareInfo.IndexOf(
                source,
                value,
                CompareOptions.None);

        /// <summary>
        ///     Finds the index of the specified value string in a source string in a case-sensitive manner using the comparison
        ///     rules of the invariant culture.
        /// </summary>
        /// <param name="value">The string value to do the evaluation.</param>
        /// <param name="startIndex">The index in the source string to start searching at.</param>
        /// <returns>The index where the string is found, otherwise -1.</returns>
        public int InvariantCultureIndexOf(
            string value,
            int startIndex) =>
            CultureInfo.InvariantCulture.CompareInfo.IndexOf(
                source,
                value,
                startIndex,
                CompareOptions.None);

        /// <summary>
        ///     Finds the index of the specified value string in a source string in a case-sensitive manner using the comparison
        ///     rules of the invariant culture.
        /// </summary>
        /// <param name="value">The string value to do the evaluation.</param>
        /// <param name="startIndex">The index in the source string to start searching at.</param>
        /// <param name="count">The number of characters to search.</param>
        /// <returns>The index where the string is found, otherwise -1.</returns>
        public int InvariantCultureIndexOf(
            string value,
            int startIndex,
            int count) =>
            CultureInfo.InvariantCulture.CompareInfo.IndexOf(
                source,
                value,
                startIndex,
                count,
                CompareOptions.None);

        /// <summary>
        ///     Finds the index of the specified value string in a source string in a case-insensitive manner using the comparison
        ///     rules of the invariant culture.
        /// </summary>
        /// <param name="value">The string value to do the evaluation.</param>
        /// <returns>
        ///     The index where the string is found, otherwise -1.
        /// </returns>
        public int InvariantCultureIndexOfInsensitive(string value) =>
            CultureInfo.InvariantCulture.CompareInfo.IndexOf(
                source,
                value,
                CompareOptions.IgnoreCase);

        /// <summary>
        ///     Finds the index of the specified value string in a source string in a case-insensitive manner using the comparison
        ///     rules of the invariant culture.
        /// </summary>
        /// <param name="value">The string value to do the evaluation.</param>
        /// <param name="startIndex">The index in the source string to start searching at.</param>
        /// <returns>The index where the string is found, otherwise -1.</returns>
        public int InvariantCultureIndexOfInsensitive(
            string value,
            int startIndex) =>
            CultureInfo.InvariantCulture.CompareInfo.IndexOf(
                source,
                value,
                startIndex,
                CompareOptions.IgnoreCase);

        /// <summary>
        ///     Finds the index of the specified value string in a source string in a case-insensitive manner using the comparison
        ///     rules of the invariant culture.
        /// </summary>
        /// <param name="value">The string value to do the evaluation.</param>
        /// <param name="startIndex">The index in the source string to start searching at.</param>
        /// <param name="count">The number of characters to search.</param>
        /// <returns>The index where the string is found, otherwise -1.</returns>
        public int InvariantCultureIndexOfInsensitive(
            string value,
            int startIndex,
            int count) =>
            CultureInfo.InvariantCulture.CompareInfo.IndexOf(
                source,
                value,
                startIndex,
                count,
                CompareOptions.IgnoreCase);

        /// <summary>
        ///     Checks whether or not the source string starts with a selected value in a case-sensitive manner using the
        ///     comparison rules of the invariant culture.
        /// </summary>
        /// <param name="value">The string value to do the evaluation.</param>
        /// <returns>
        ///     <see langword="true" /> if the source string is equal to the value; otherwise, <see langword="false" />.
        /// </returns>
        public bool InvariantCultureStartsWith(string value) =>
            CultureInfo.InvariantCulture.CompareInfo.IsPrefix(
                source,
                value,
                CompareOptions.None);

        /// <summary>
        ///     Checks whether or not the source string starts with a selected value in a case-insensitive manner using the
        ///     comparison rules of the invariant culture.
        /// </summary>
        /// <param name="value">The string value to do the evaluation.</param>
        /// <returns>
        ///     <see langword="true" /> if the source string is equal to the value; otherwise, <see langword="false" />.
        /// </returns>
        public bool InvariantCultureStartsWithInsensitive(string value) =>
            CultureInfo.InvariantCulture.CompareInfo.IsPrefix(
                source,
                value,
                CompareOptions.IgnoreCase);
    }
}