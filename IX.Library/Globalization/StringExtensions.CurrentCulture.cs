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
        ///     Compares the source string with a selected value in a case-sensitive manner using the comparison rules of the UI
        ///     thread culture.
        /// </summary>
        /// <param name="value">The string value to do the evaluation.</param>
        /// <returns>
        ///     The comparison of the two strings, with 0 meaning equality.
        /// </returns>
        public int CurrentCultureCompareTo(string value) =>
            CultureInfo.CurrentCulture.CompareInfo.Compare(
                source,
                value,
                CompareOptions.None);

        /// <summary>
        ///     Compares the source string with a selected value in a case-insensitive manner using the comparison rules of the UI
        ///     thread culture.
        /// </summary>
        /// <param name="value">The string value to do the evaluation.</param>
        /// <returns>
        ///     The comparison of the two strings, with 0 meaning equality.
        /// </returns>
        public int CurrentCultureCompareToInsensitive(string value) =>
            CultureInfo.CurrentCulture.CompareInfo.Compare(
                source,
                value,
                CompareOptions.IgnoreCase);

        /// <summary>
        ///     Determines whether a source string contains the specified value string in a case-sensitive manner using the
        ///     comparison rules of the UI thread culture.
        /// </summary>
        /// <param name="value">The string value to do the evaluation.</param>
        /// <returns>
        ///     <see langword="true" /> if the source string contains the specified value string; otherwise,
        ///     <see langword="false" />.
        /// </returns>
        public bool CurrentCultureContains(string value) =>
            source.CurrentCultureIndexOf(value) >= 0;

        /// <summary>
        ///     Determines whether a source string contains the specified value string in a case-insensitive manner using the
        ///     comparison rules of the UI thread culture.
        /// </summary>
        /// <param name="value">The string value to do the evaluation.</param>
        /// <returns>
        ///     <see langword="true" /> if the source string contains the specified value string; otherwise,
        ///     <see langword="false" />.
        /// </returns>
        public bool CurrentCultureContainsInsensitive(string value) =>
            source.CurrentCultureIndexOfInsensitive(value) >= 0;

        /// <summary>
        ///     Checks whether or not the source string ends with a selected value in a case-sensitive manner using the comparison
        ///     rules of the UI thread culture.
        /// </summary>
        /// <param name="value">The string value to do the evaluation.</param>
        /// <returns>
        ///     <see langword="true" /> if the source string is equal to the value; otherwise, <see langword="false" />.
        /// </returns>
        public bool CurrentCultureEndsWith(string value) =>
            CultureInfo.CurrentCulture.CompareInfo.IsSuffix(
                source,
                value,
                CompareOptions.None);

        /// <summary>
        ///     Checks whether or not the source string ends with a selected value in a case-insensitive manner using the
        ///     comparison rules of the UI thread culture.
        /// </summary>
        /// <param name="value">The string value to do the evaluation.</param>
        /// <returns>
        ///     <see langword="true" /> if the source string is equal to the value; otherwise, <see langword="false" />.
        /// </returns>
        public bool CurrentCultureEndsWithInsensitive(string value) =>
            CultureInfo.CurrentCulture.CompareInfo.IsSuffix(
                source,
                value,
                CompareOptions.IgnoreCase);

        /// <summary>
        ///     Equates the source string with a selected value in a case-sensitive manner using the comparison rules of the UI
        ///     thread culture.
        /// </summary>
        /// <param name="value">The string value to do the evaluation.</param>
        /// <returns>
        ///     <see langword="true" /> if the source string is equal to the value; otherwise, <see langword="false" />.
        /// </returns>
        public bool CurrentCultureEquals(string value) =>
            source.CurrentCultureCompareTo(value) == 0;

        /// <summary>
        ///     Equates the source string with a selected value in a case-insensitive manner using the comparison rules of the UI
        ///     thread culture.
        /// </summary>
        /// <param name="value">The string value to do the evaluation.</param>
        /// <returns>
        ///     <see langword="true" /> if the source string is equal to the value; otherwise, <see langword="false" />.
        /// </returns>
        public bool CurrentCultureEqualsInsensitive(string value) =>
            source.CurrentCultureCompareToInsensitive(value) == 0;

        /// <summary>
        ///     Finds the index of the specified value string in a source string in a case-sensitive manner using the comparison
        ///     rules of the UI thread culture.
        /// </summary>
        /// <param name="value">The string value to do the evaluation.</param>
        /// <returns>
        ///     The index where the string is found, otherwise -1.
        /// </returns>
        public int CurrentCultureIndexOf(string value) =>
            CultureInfo.CurrentCulture.CompareInfo.IndexOf(
                source,
                value,
                CompareOptions.None);

        /// <summary>
        ///     Finds the index of the specified value string in a source string in a case-sensitive manner using the comparison
        ///     rules of the UI thread culture.
        /// </summary>
        /// <param name="value">The string value to do the evaluation.</param>
        /// <param name="startIndex">The index in the source string to start searching at.</param>
        /// <returns>The index where the string is found, otherwise -1.</returns>
        public int CurrentCultureIndexOf(
            string value,
            int startIndex) =>
            CultureInfo.CurrentCulture.CompareInfo.IndexOf(
                source,
                value,
                startIndex,
                CompareOptions.None);

        /// <summary>
        ///     Finds the index of the specified value string in a source string in a case-sensitive manner using the comparison
        ///     rules of the UI thread culture.
        /// </summary>
        /// <param name="value">The string value to do the evaluation.</param>
        /// <param name="startIndex">The index in the source string to start searching at.</param>
        /// <param name="count">The number of characters to search.</param>
        /// <returns>The index where the string is found, otherwise -1.</returns>
        public int CurrentCultureIndexOf(
            string value,
            int startIndex,
            int count) =>
            CultureInfo.CurrentCulture.CompareInfo.IndexOf(
                source,
                value,
                startIndex,
                count,
                CompareOptions.None);

        /// <summary>
        ///     Finds the index of the specified value string in a source string in a case-insensitive manner using the comparison
        ///     rules of the UI thread culture.
        /// </summary>
        /// <param name="value">The string value to do the evaluation.</param>
        /// <returns>
        ///     The index where the string is found, otherwise -1.
        /// </returns>
        public int CurrentCultureIndexOfInsensitive(string value) =>
            CultureInfo.CurrentCulture.CompareInfo.IndexOf(
                source,
                value,
                CompareOptions.IgnoreCase);

        /// <summary>
        ///     Finds the index of the specified value string in a source string in a case-insensitive manner using the comparison
        ///     rules of the UI thread culture.
        /// </summary>
        /// <param name="value">The string value to do the evaluation.</param>
        /// <param name="startIndex">The index in the source string to start searching at.</param>
        /// <returns>The index where the string is found, otherwise -1.</returns>
        public int CurrentCultureIndexOfInsensitive(
            string value,
            int startIndex) =>
            CultureInfo.CurrentCulture.CompareInfo.IndexOf(
                source,
                value,
                startIndex,
                CompareOptions.IgnoreCase);

        /// <summary>
        ///     Finds the index of the specified value string in a source string in a case-insensitive manner using the comparison
        ///     rules of the UI thread culture.
        /// </summary>
        /// <param name="value">The string value to do the evaluation.</param>
        /// <param name="startIndex">The index in the source string to start searching at.</param>
        /// <param name="count">The number of characters to search.</param>
        /// <returns>The index where the string is found, otherwise -1.</returns>
        public int CurrentCultureIndexOfInsensitive(
            string value,
            int startIndex,
            int count) =>
            CultureInfo.CurrentCulture.CompareInfo.IndexOf(
                source,
                value,
                startIndex,
                count,
                CompareOptions.IgnoreCase);

        /// <summary>
        ///     Checks whether or not the source string starts with a selected value in a case-sensitive manner using the
        ///     comparison rules of the UI thread culture.
        /// </summary>
        /// <param name="value">The string value to do the evaluation.</param>
        /// <returns>
        ///     <see langword="true" /> if the source string is equal to the value; otherwise, <see langword="false" />.
        /// </returns>
        public bool CurrentCultureStartsWith(string value) =>
            CultureInfo.CurrentCulture.CompareInfo.IsPrefix(
                source,
                value,
                CompareOptions.None);

        /// <summary>
        ///     Checks whether or not the source string starts with a selected value in a case-insensitive manner using the
        ///     comparison rules of the UI thread culture.
        /// </summary>
        /// <param name="value">The string value to do the evaluation.</param>
        /// <returns>
        ///     <see langword="true" /> if the source string is equal to the value; otherwise, <see langword="false" />.
        /// </returns>
        public bool CurrentCultureStartsWithInsensitive(string value) =>
            CultureInfo.CurrentCulture.CompareInfo.IsPrefix(
                source,
                value,
                CompareOptions.IgnoreCase);
    }
}