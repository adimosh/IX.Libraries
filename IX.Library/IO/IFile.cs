using System.Text;

namespace IX.Core.IO;

/// <summary>
///     Abstracts the <see cref="File" /> class' static methods into a mock-able interface.
/// </summary>
[PublicAPI]
public interface IFile
{
    /// <summary>
    ///     Appends lines of text to a specified file path.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="contents">The contents.</param>
    /// <param name="encoding">The encoding to use. Can be <see langword="null" />.</param>
    /// <remarks>
    ///     <para>
    ///         This operation always requires an encoding to be used. If <paramref name="encoding" /> is set to
    ///         <see langword="null" />, an implementation-specific
    ///         encoding will be used.
    ///     </para>
    /// </remarks>
    void AppendAllLines(
        string path,
        IEnumerable<string> contents,
        Encoding? encoding = null);

    /// <summary>
    ///     Asynchronously appends lines of text to a specified file path.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="contents">The contents.</param>
    /// <param name="encoding">The encoding to use. Can be <see langword="null" />.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     A task representing the current operation.
    /// </returns>
    /// <remarks>
    ///     This operation always requires an encoding to be used. If <paramref name="encoding" /> is set to
    ///     <see langword="null" />, an implementation-specific
    ///     encoding will be used.
    /// </remarks>
    ValueTask AppendAllLinesAsync(
        string path,
        IEnumerable<string> contents,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Appends text to a specified file path.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="contents">The contents.</param>
    /// <param name="encoding">The encoding to use. Can be <see langword="null" />.</param>
    /// <remarks>
    ///     <para>
    ///         This operation always requires an encoding to be used. If <paramref name="encoding" /> is set to
    ///         <see langword="null" />, an implementation-specific
    ///         encoding will be used.
    ///     </para>
    /// </remarks>
    void AppendAllText(
        string path,
        string contents,
        Encoding? encoding = null);

    /// <summary>
    ///     Asynchronously appends text to a specified file path.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="contents">The contents.</param>
    /// <param name="encoding">The encoding to use. Can be <see langword="null" />.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     A task representing the current operation.
    /// </returns>
    /// <remarks>
    ///     This operation always requires an encoding to be used. If <paramref name="encoding" /> is set to
    ///     <see langword="null" />, an implementation-specific
    ///     encoding will be used.
    /// </remarks>
    ValueTask AppendAllTextAsync(
        string path,
        string contents,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Opens a <see cref="StreamWriter" /> to append text to a file.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <returns>A <see cref="StreamWriter" /> that can write to a file.</returns>
    StreamWriter AppendText(string path);

    /// <summary>
    ///     Copies a file to another.
    /// </summary>
    /// <param name="sourceFileName">The source file.</param>
    /// <param name="destinationFileName">The destination file.</param>
    /// <param name="overwrite">
    ///     If <see langword="true" />, overwrites the destination file, if one exists, otherwise throws an exception. If a
    ///     destination file doesn't
    ///     exist, this parameter is ignored.
    /// </param>
    void Copy(
        string sourceFileName,
        string destinationFileName,
        bool overwrite = false);

    /// <summary>
    ///     Asynchronously copies a file to another.
    /// </summary>
    /// <param name="sourceFileName">The source file.</param>
    /// <param name="destinationFileName">The destination file.</param>
    /// <param name="overwrite">
    ///     If <see langword="true" />, overwrites the destination file, if one exists, otherwise throws an exception. If a
    ///     destination file doesn't
    ///     exist, this parameter is ignored.
    /// </param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     A task representing the current operation.
    /// </returns>
    ValueTask CopyAsync(
        string sourceFileName,
        string destinationFileName,
        bool overwrite = false,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Creates a file.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="bufferSize">The buffer size to use. Default is 4 kilobytes.</param>
    /// <returns>A <see cref="Stream" /> that can read from and write to a file.</returns>
    Stream Create(
        string path,
        int bufferSize = 4096);

    /// <summary>
    ///     Opens a <see cref="StreamWriter" /> to write text to a file.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <returns>A <see cref="StreamWriter" /> that can write to a file.</returns>
    StreamWriter CreateText(string path);

    /// <summary>
    ///     Deletes a file.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    void Delete(string path);

    /// <summary>
    ///     Asynchronously deletes a file.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     A task representing the current operation.
    /// </returns>
    ValueTask DeleteAsync(
        string path,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Checks whether a file exists and is accessible.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <returns>
    ///     Returns <see langword="true" /> if the specified file exists and is accessible, <see langword="false" />
    ///     otherwise.
    /// </returns>
    bool Exists(string path);

    /// <summary>
    ///     Asynchronously checks whether a file exists and is accessible.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     A task representing the current operation, holding <see langword="true" /> if the specified file exists and is
    ///     accessible, <see langword="false" /> otherwise.
    /// </returns>
    ValueTask<bool> ExistsAsync(
        string path,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Gets a specific file's creation time, in UTC.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <returns>A <see cref="DateTime" /> in UTC.</returns>
    DateTime GetCreationTime(string path);

    /// <summary>
    ///     Gets a specific file's creation time, in UTC.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     A task representing the current operation, holding a <see cref="DateTime" /> in UTC.
    /// </returns>
    ValueTask<DateTime> GetCreationTimeAsync(
        string path,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Gets a specific file's last access time, in UTC.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <returns>A <see cref="DateTime" /> in UTC.</returns>
    DateTime GetLastAccessTime(string path);

    /// <summary>
    ///     Gets a specific file's last access time, in UTC.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     A task representing the current operation, holding a <see cref="DateTime" /> in UTC.
    /// </returns>
    ValueTask<DateTime> GetLastAccessTimeAsync(
        string path,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Gets a specific file's last write time, in UTC.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <returns>A <see cref="DateTime" /> in UTC.</returns>
    DateTime GetLastWriteTime(string path);

    /// <summary>
    ///     Asynchronously gets a specific file's last write time, in UTC.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     A task representing the current operation, holding a <see cref="DateTime" /> in UTC.
    /// </returns>
    ValueTask<DateTime> GetLastWriteTimeAsync(
        string path,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Moves a file.
    /// </summary>
    /// <param name="sourceFileName">The source file name.</param>
    /// <param name="destinationFileName">The destination file name.</param>
    void Move(
        string sourceFileName,
        string destinationFileName);

    /// <summary>
    ///     Asynchronously moves a file.
    /// </summary>
    /// <param name="sourceFileName">The source file name.</param>
    /// <param name="destinationFileName">The destination file name.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     A task representing the current operation.
    /// </returns>
    ValueTask MoveAsync(
        string sourceFileName,
        string destinationFileName,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Opens a <see cref="Stream" /> to read from a file.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <returns>A <see cref="Stream" /> that can read from a file.</returns>
    Stream OpenRead(string path);

    /// <summary>
    ///     Opens a <see cref="StreamReader" /> to read text from a file.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <returns>A <see cref="StreamReader" /> that can read from a file.</returns>
    StreamReader OpenText(string path);

    /// <summary>
    ///     Opens a <see cref="Stream" /> to write to a file.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <returns>A <see cref="Stream" /> that can write to a file.</returns>
    Stream OpenWrite(string path);

    /// <summary>
    ///     Reads the entire contents of a file.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <returns>The contents of a file, in binary.</returns>
    byte[] ReadAllBytes(string path);

    /// <summary>
    ///     Asynchronously reads the entire contents of a file.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     A task representing the current operation, holding the contents of a file, in binary.
    /// </returns>
    ValueTask<byte[]> ReadAllBytesAsync(
        string path,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Reads the entire contents of a file and splits them by end-of-line markers.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="encoding">The encoding to use. Can be <see langword="null" />.</param>
    /// <returns>An array of <see cref="string" />.</returns>
    /// <remarks>
    ///     <para>
    ///         This operation always requires an encoding to be used. If <paramref name="encoding" /> is set to
    ///         <see langword="null" />, an implementation-specific
    ///         encoding will be used.
    ///     </para>
    /// </remarks>
    string[] ReadAllLines(
        string path,
        Encoding? encoding = null);

    /// <summary>
    ///     Asynchronously reads the entire contents of a file and splits them by end-of-line markers.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="encoding">The encoding to use. Can be <see langword="null" />.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     A task representing the current operation, holding an array of <see cref="string" />.
    /// </returns>
    /// <remarks>
    ///     <para>
    ///         This operation always requires an encoding to be used. If <paramref name="encoding" /> is set to
    ///         <see langword="null" />, an implementation-specific
    ///         encoding will be used.
    ///     </para>
    /// </remarks>
    ValueTask<string[]> ReadAllLinesAsync(
        string path,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Reads the entire contents of a file as text.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="encoding">The encoding to use. Can be <see langword="null" />.</param>
    /// <returns>The entire file contents as a string.</returns>
    /// <remarks>
    ///     <para>
    ///         This operation always requires an encoding to be used. If <paramref name="encoding" /> is set to
    ///         <see langword="null" />, an implementation-specific
    ///         encoding will be used.
    ///     </para>
    /// </remarks>
    string ReadAllText(
        string path,
        Encoding? encoding = null);

    /// <summary>
    ///     Asynchronously reads the entire contents of a file as text.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="encoding">The encoding to use. Can be <see langword="null" />.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     A task representing the current operation, holding the entire file contents as a <see cref="string" />.
    /// </returns>
    /// <remarks>
    ///     <para>
    ///         This operation always requires an encoding to be used. If <paramref name="encoding" /> is set to
    ///         <see langword="null" />, an implementation-specific
    ///         encoding will be used.
    ///     </para>
    /// </remarks>
    ValueTask<string> ReadAllTextAsync(
        string path,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Reads file contents as text line by line.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="encoding">The encoding to use. Can be <see langword="null" />.</param>
    /// <returns>An enumerable of strings, each representing one line of text.</returns>
    /// <remarks>
    ///     <para>
    ///         This operation always requires an encoding to be used. If <paramref name="encoding" /> is set to
    ///         <see langword="null" />, an implementation-specific
    ///         encoding will be used.
    ///     </para>
    /// </remarks>
    IEnumerable<string> ReadLines(
        string path,
        Encoding? encoding = null);

    /// <summary>
    ///     Sets the file's creation time.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="creationTime">A <see cref="DateTime" /> with the file attribute to set.</param>
    void SetCreationTime(
        string path,
        DateTime creationTime);

    /// <summary>
    ///     Asynchronously sets the file's creation time.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="creationTime">A <see cref="DateTime" /> with the file attribute to set.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     A task representing the current operation.
    /// </returns>
    ValueTask SetCreationTimeAsync(
        string path,
        DateTime creationTime,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Sets the file's last access time.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="lastAccessTime">A <see cref="DateTime" /> with the file attribute to set.</param>
    void SetLastAccessTime(
        string path,
        DateTime lastAccessTime);

    /// <summary>
    ///     Asynchronously sets the file's last access time.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="lastAccessTime">A <see cref="DateTime" /> with the file attribute to set.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     A task representing the current operation.
    /// </returns>
    ValueTask SetLastAccessTimeAsync(
        string path,
        DateTime lastAccessTime,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Sets the file's last write time.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="lastWriteTime">A <see cref="DateTime" /> with the file attribute to set.</param>
    void SetLastWriteTime(
        string path,
        DateTime lastWriteTime);

    /// <summary>
    ///     Asynchronously sets the file's last write time.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="lastWriteTime">A <see cref="DateTime" /> with the file attribute to set.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     A task representing the current operation.
    /// </returns>
    ValueTask SetLastWriteTimeAsync(
        string path,
        DateTime lastWriteTime,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Writes binary contents to a file.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="bytes">The contents to write.</param>
    void WriteAllBytes(
        string path,
        byte[] bytes);

    /// <summary>
    ///     Asynchronously writes binary contents to a file.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="bytes">The contents to write.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     A task representing the current operation.
    /// </returns>
    ValueTask WriteAllBytesAsync(
        string path,
        byte[] bytes,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Writes lines of text to a file.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="contents">The contents to write.</param>
    /// <param name="encoding">The encoding to use. Can be <see langword="null" />.</param>
    /// <remarks>
    ///     <para>
    ///         This operation always requires an encoding to be used. If <paramref name="encoding" /> is set to
    ///         <see langword="null" />, an implementation-specific
    ///         encoding will be used.
    ///     </para>
    /// </remarks>
    void WriteAllLines(
        string path,
        IEnumerable<string> contents,
        Encoding? encoding = null);

    /// <summary>
    ///     Asynchronously writes lines of text to a file.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="contents">The contents to write.</param>
    /// <param name="encoding">The encoding to use. Can be <see langword="null" />.</param>
    /// <remarks>
    ///     <para>
    ///         This operation always requires an encoding to be used. If <paramref name="encoding" /> is set to
    ///         <see langword="null" />, an implementation-specific
    ///         encoding will be used.
    ///     </para>
    /// </remarks>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     A task representing the current operation.
    /// </returns>
    ValueTask WriteAllLinesAsync(
        string path,
        IEnumerable<string> contents,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Writes text to a file.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="contents">The contents to write.</param>
    /// <param name="encoding">The encoding to use. Can be <see langword="null" />.</param>
    /// <remarks>
    ///     <para>
    ///         This operation always requires an encoding to be used. If <paramref name="encoding" /> is set to
    ///         <see langword="null" />, an implementation-specific
    ///         encoding will be used.
    ///     </para>
    /// </remarks>
    void WriteAllText(
        string path,
        string contents,
        Encoding? encoding = null);

    /// <summary>
    ///     Writes text to a file.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="contents">The contents to write.</param>
    /// <param name="encoding">The encoding to use. Can be <see langword="null" />.</param>
    /// <remarks>
    ///     <para>
    ///         This operation always requires an encoding to be used. If <paramref name="encoding" /> is set to
    ///         <see langword="null" />, an implementation-specific
    ///         encoding will be used.
    ///     </para>
    /// </remarks>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     A task representing the current operation.
    /// </returns>
    ValueTask WriteAllTextAsync(
        string path,
        string contents,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default);
}