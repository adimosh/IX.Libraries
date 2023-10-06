using System.Security;

using FS = System.IO;

namespace IX.Library.IO;

/// <summary>
///     A class for implementing <see cref="IPath" /> with <see cref="FS.Path" />.
/// </summary>
/// <seealso cref="IPath" />
/// <seealso cref="FS.Path" />
[PublicAPI]
public class Path : IPath
{
    /// <summary>
    ///     Gets a platform-specific alternate character used to separate directory levels in a path string that reflects a
    ///     hierarchical file system organization.
    /// </summary>
    public char AltDirectorySeparatorChar => FS.Path.AltDirectorySeparatorChar;

    /// <summary>
    ///     Gets a platform-specific character used to separate directory levels in a path string that reflects a hierarchical
    ///     file system organization.
    /// </summary>
    public char DirectorySeparatorChar => FS.Path.DirectorySeparatorChar;

    /// <summary>
    ///     Gets a platform-specific separator character used to separate path strings in environment variables.
    /// </summary>
    public char PathSeparator => FS.Path.PathSeparator;

    /// <summary>
    ///     Gets a platform-specific volume separator character.
    /// </summary>
    public char VolumeSeparatorChar => FS.Path.VolumeSeparatorChar;

    /// <summary>
    ///     Changes the extension of a path string.
    /// </summary>
    /// <param name="path">
    ///     The path information to modify. The path cannot contain any of the characters defined in
    ///     <see cref="GetInvalidPathChars" />.
    /// </param>
    /// <param name="extension">
    ///     The new extension (with or without a leading period). Specify <see langword="null" /> (
    ///     <see langword="Nothing" /> in Visual Basic) to remove an existing extension from path.
    /// </param>
    /// <returns>The modified path information.</returns>
    /// <exception cref="ArgumentException">
    ///     <paramref name="path" /> contains one or more of the invalid characters
    ///     defined in <see cref="GetInvalidPathChars" />.
    /// </exception>
    /// <remarks>
    ///     <para>
    ///         On Windows-based desktop platforms, if path is <see langword="null" /> or an empty string (""), the path
    ///         information is returned unmodified.
    ///     </para>
    ///     <para>
    ///         If extension is <see langword="null" />, the returned string contains the specified path with its extension
    ///         removed. If path has no extension, and extension is not <see langword="null" />, the returned path string
    ///         contains extension appended to the end of path.
    ///     </para>
    /// </remarks>
    public string ChangeExtension(
        string path,
        string? extension) =>
        FS.Path.ChangeExtension(
            path,
            extension);

    /// <summary>
    ///     Combines an array of strings into a path.
    /// </summary>
    /// <param name="paths">An array of parts of the path.</param>
    /// <returns>The combined paths.</returns>
    /// <exception cref="ArgumentException">
    ///     One of the strings in the array contains one or more of the invalid characters
    ///     defined in <see cref="GetInvalidPathChars" />.
    /// </exception>
    /// <exception cref="ArgumentNullException">One of the strings in the array is <see langword="null" />.</exception>
    public string Combine(params string[] paths) => FS.Path.Combine(paths);

    /// <summary>
    ///     Escapes the illegal characters from the given string, by eliminating them out, in order to render a proper file
    ///     name.
    /// </summary>
    /// <param name="stringToEscape">The input string, to escape.</param>
    /// <returns>The escaped string.</returns>
    /// <exception cref="InvalidOperationException">
    ///     The string to escape is made entirely out of whitespace and illegal
    ///     characters.
    /// </exception>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="stringToEscape" /> is <c>null</c> (<c>Nothing</c> in Visual Basic).
    /// </exception>
    public string EscapeFileName(string stringToEscape)
    {
        _ = Requires.NotNullOrWhiteSpace(stringToEscape);

        var invalidChars = GetInvalidFileNameChars();
        var newString = new char[stringToEscape.Length];
        ReadOnlySpan<char> oldString = stringToEscape.AsSpan();

        int oldIndex = 0, newIndex = 0;

        while (oldIndex < oldString.Length)
        {
            var currentChar = oldString[oldIndex];
            if (!invalidChars.Contains(currentChar))
            {
                newString[newIndex] = currentChar;
                newIndex++;
            }

            oldIndex++;
        }

        string resultingString = new(
            newString,
            0,
            newIndex);

        if (string.IsNullOrWhiteSpace(resultingString))
        {
            throw new InvalidOperationException();
        }

        return resultingString;
    }

    /// <summary>
    ///     Returns the directory information for the specified path string.
    /// </summary>
    /// <param name="path">The path of a file or directory.</param>
    /// <returns>
    ///     Directory information for path, or <see langword="null" /> if path denotes a root directory or is
    ///     <see langword="null" />. Returns <see cref="string.Empty" /> if path does not contain directory information.
    /// </returns>
    /// <exception cref="ArgumentException">
    ///     The <paramref name="path" /> contains invalid characters, is empty, or contains
    ///     only white spaces.
    /// </exception>
    /// <exception cref="FS.PathTooLongException">
    ///     In the .NET for Windows Store apps or the Portable Class Library, catch the
    ///     base class exception, <see cref="FS.IOException" />, instead.The path parameter is longer than the system-defined
    ///     maximum length.
    /// </exception>
    public string GetDirectoryName(string? path) => FS.Path.GetDirectoryName(path)!;

    /// <summary>
    ///     Returns the extension of the specified path string.
    /// </summary>
    /// <param name="path">The path string from which to get the extension.</param>
    /// <returns>
    ///     The extension of the specified path (including the period &quot;.&quot;), or <see langword="null" />, or
    ///     <see cref="string.Empty" />. If path is <see langword="null" />, the method returns <see langword="null" />. If
    ///     path does not have extension information, the method returns <see cref="string.Empty" />.
    /// </returns>
    public string GetExtension(string path) => FS.Path.GetExtension(path);

    /// <summary>
    ///     Returns the file name and extension of the specified path string.
    /// </summary>
    /// <param name="path">The path string from which to obtain the file name and extension.</param>
    /// <returns>
    ///     The characters after the last directory character in path. If the last character of path is a directory or
    ///     volume separator character, this method returns <see cref="string.Empty" />. If path is <see langword="null" />,
    ///     this method returns <see langword="null" />.
    /// </returns>
    /// <exception cref="ArgumentException">
    ///     <paramref name="path" /> contains one or more of the invalid characters defined in
    ///     <see cref="GetInvalidPathChars" />.
    /// </exception>
    public string GetFileName(string path) => FS.Path.GetFileName(path);

    /// <summary>
    ///     Returns the file name of the specified path string without the extension.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <returns>
    ///     The string returned by <see cref="GetFileName(string)" /> , minus the last period (.) and all characters
    ///     following it.
    /// </returns>
    /// <exception cref="ArgumentException">
    ///     <paramref name="path" /> contains one or more of the invalid characters defined in
    ///     <see cref="GetInvalidPathChars" />.
    /// </exception>
    public string GetFileNameWithoutExtension(string path) => FS.Path.GetFileNameWithoutExtension(path);

    /// <summary>
    ///     Returns the absolute path for the specified path string.
    /// </summary>
    /// <param name="path">The file or directory for which to obtain absolute path information.</param>
    /// <returns>The fully qualified location of path, such as &quot;C:\MyFile.txt&quot;.</returns>
    /// <exception cref="ArgumentException">
    ///     <paramref name="path" /> is a zero-length string, contains only white space, or
    ///     contains one or more of the invalid characters defined in <see cref="GetInvalidPathChars" />. -or- The system could
    ///     not retrieve the absolute path.
    /// </exception>
    /// <exception cref="SecurityException">The caller does not have the required permissions.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="path" /> is <see langword="null" />.</exception>
    /// <exception cref="NotSupportedException">
    ///     <paramref name="path" /> contains a colon (&quot;:&quot;) that is not part of a
    ///     volume identifier (for example, &quot;c:\&quot;).
    /// </exception>
    /// <exception cref="FS.PathTooLongException">
    ///     The specified path, file name, or both exceed the system-defined maximum
    ///     length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be
    ///     less than 260 characters.
    /// </exception>
    public string GetFullPath(string path) => FS.Path.GetFullPath(path);

    /// <summary>
    ///     Gets an array containing the characters that are not allowed in file names.
    /// </summary>
    /// <returns>An array containing the characters that are not allowed in file names.</returns>
    public char[] GetInvalidFileNameChars() => FS.Path.GetInvalidFileNameChars();

    /// <summary>
    ///     Gets an array containing the characters that are not allowed in path names.
    /// </summary>
    /// <returns>An array containing the characters that are not allowed in path names.</returns>
    public char[] GetInvalidPathChars() => FS.Path.GetInvalidPathChars();

    /// <summary>
    ///     Gets the root directory information of the specified path.
    /// </summary>
    /// <param name="path">The path from which to obtain root directory information.</param>
    /// <returns>
    ///     The root directory of path, such as &quot;C:\&quot;, or <see langword="null" /> if <paramref name="path" /> is
    ///     <see langword="null" />, or an empty string if <paramref name="path" /> does not contain root directory
    ///     information.
    /// </returns>
    /// <exception cref="ArgumentException">
    ///     <paramref name="path" /> contains one or more of the invalid characters defined in
    ///     <see cref="GetInvalidPathChars" />. -or- <see cref="string.Empty" /> was passed to <paramref name="path" />.
    /// </exception>
    public string? GetPathRoot(string path) => FS.Path.GetPathRoot(path);

    /// <summary>
    ///     Returns a random folder name or file name.
    /// </summary>
    /// <returns>A random folder name or file name.</returns>
    public string GetRandomFileName() => FS.Path.GetRandomFileName();

    /// <summary>
    ///     Creates a uniquely named, zero-byte temporary file on disk and returns the full path of that file.
    /// </summary>
    /// <returns>The full path of the temporary file.</returns>
    /// <exception cref="FS.IOException">
    ///     An I/O error occurs, such as no unique temporary file name is available. -or- This
    ///     method was unable to create a temporary file.
    /// </exception>
    public string GetTempFileName() => FS.Path.GetTempFileName();

    /// <summary>
    ///     Returns the path of the current user's temporary folder.
    /// </summary>
    /// <returns>The path to the temporary folder, ending with a backslash.</returns>
    /// <exception cref="SecurityException">The caller does not have the required permissions.</exception>
    public string GetTempPath() => FS.Path.GetTempPath();

    /// <summary>
    ///     Determines whether a path includes a file name extension.
    /// </summary>
    /// <param name="path">The path to search for an extension.</param>
    /// <returns>
    ///     <see langword="true" /> if the characters that follow the last directory separator (\\ or /) or volume
    ///     separator (:) in the path include a period (.) followed by one or more characters; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    /// <exception cref="ArgumentException">
    ///     <paramref name="path" /> contains one or more of the invalid characters defined in
    ///     <see cref="GetInvalidPathChars" />.
    /// </exception>
    public bool HasExtension(string path) => FS.Path.HasExtension(path);

    /// <summary>
    ///     Gets a value indicating whether the specified path string contains a root.
    /// </summary>
    /// <param name="path">The path to test.</param>
    /// <returns><see langword="true" /> if path contains a root; otherwise, <see langword="false" />.</returns>
    /// <exception cref="ArgumentException">
    ///     <paramref name="path" /> contains one or more of the invalid characters defined in
    ///     <see cref="GetInvalidPathChars" />.
    /// </exception>
    public bool IsPathRooted(string path) => FS.Path.IsPathRooted(path);
}