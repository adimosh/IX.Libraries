using System.Diagnostics.CodeAnalysis;
using System.Text;

using FSFile = System.IO.File;

namespace IX.Library.IO;

/// <summary>
///     A class for implementing <see cref="IFile" /> with <see cref="FSFile" />.
/// </summary>
/// <seealso cref="IFile" />
/// <seealso cref="T:System.IO.File" />
[PublicAPI]
[SuppressMessage(
    "Performance",
    "HAA0603:Delegate allocation from a method group",
    Justification = "We're doing multithreaded, so this can't really be done in any other way.")]
public class File : IFile
{

    /// <summary>
    ///     Appends lines of text to a specified file path.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="contents">The contents.</param>
    /// <param name="encoding">The encoding to use.</param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> or <paramref name="contents" /> is <see langword="null" /> (<see langword="Nothing" /> in
    ///     Visual Basic).
    /// </exception>
    /// <remarks>
    ///     This operation always requires an encoding to be used. If <paramref name="encoding" /> is set to
    ///     <see langword="null" />, an implementation-specific
    ///     encoding will be used.
    /// </remarks>
    public void AppendAllLines(
        string path,
        IEnumerable<string> contents,
        Encoding? encoding = null)
    {
        _ = Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));
        _ = Requires.NotNull(
            contents,
            nameof(contents));

        if (encoding == null)
        {
            FSFile.AppendAllLines(
                path,
                contents);
        }
        else
        {
            FSFile.AppendAllLines(
                path,
                contents,
                encoding);
        }
    }

    /// <summary>
    ///     Asynchronously appends lines of text to a specified file path.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="contents">The contents.</param>
    /// <param name="encoding">The encoding to use.</param>
    /// <param name="cancellationToken">The cancellation token to stop this operation.</param>
    /// <returns>A task representing the current operation.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> or <paramref name="contents" /> is
    ///     <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    /// <remarks>
    ///     This operation always requires an encoding to be used. If <paramref name="encoding" /> is set to
    ///     <see langword="null" />, an implementation-specific
    ///     encoding will be used.
    /// </remarks>
    public ValueTask AppendAllLinesAsync(
        string path,
        IEnumerable<string> contents,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default)
    {
        _ = Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));
        _ = Requires.NotNull(
            contents,
            nameof(contents));

        return new(encoding == null
            ? Work.OnThreadPoolAsync(
                state => FSFile.AppendAllLines(
                    state.Path,
                    state.Contents),
                (Path: path, Contents: contents),
                cancellationToken)
            : Work.OnThreadPoolAsync(
                state => FSFile.AppendAllLines(
                    state.Path,
                    state.Contents,
                    state.Encoding),
                (Path: path, Contents: contents, Encoding: encoding),
                cancellationToken));
    }

    /// <summary>
    ///     Appends text to a specified file path.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="contents">The contents.</param>
    /// <param name="encoding">The encoding to use.</param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> or <paramref name="contents" /> is <see langword="null" /> (<see langword="Nothing" /> in
    ///     Visual Basic).
    /// </exception>
    /// <remarks>
    ///     This operation always requires an encoding to be used. If <paramref name="encoding" /> is set to
    ///     <see langword="null" />, an implementation-specific
    ///     encoding will be used.
    /// </remarks>
    public void AppendAllText(
        string path,
        string contents,
        Encoding? encoding = null)
    {
        _ = Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));
        _ = Requires.NotNullOrWhiteSpace(
            contents,
            nameof(contents));

        if (encoding == null)
        {
            FSFile.AppendAllText(
                path,
                contents);
        }
        else
        {
            FSFile.AppendAllText(
                path,
                contents,
                encoding);
        }
    }

    /// <summary>
    ///     Asynchronously appends text to a specified file path.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="contents">The contents.</param>
    /// <param name="encoding">The encoding to use.</param>
    /// <param name="cancellationToken">The cancellation token to stop this operation.</param>
    /// <returns>A task representing the current operation.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> or <paramref name="contents" /> is <see langword="null" /> (<see langword="Nothing" /> in
    ///     Visual Basic).
    /// </exception>
    /// <remarks>
    ///     This operation always requires an encoding to be used. If <paramref name="encoding" /> is set to
    ///     <see langword="null" />, an implementation-specific
    ///     encoding will be used.
    /// </remarks>
    public ValueTask AppendAllTextAsync(
        string path,
        string contents,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default)
    {
        _ = Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));
        _ = Requires.NotNullOrWhiteSpace(
            contents,
            nameof(contents));

        return new(encoding == null
            ? Work.OnThreadPoolAsync(
                state => FSFile.AppendAllText(
                    state.Path,
                    state.Contents),
                (Path: path, Contents: contents),
                cancellationToken)
            : Work.OnThreadPoolAsync(
                state => FSFile.AppendAllText(
                    state.Path,
                    state.Contents,
                    state.Encoding),
                (Path: path, Contents: contents, Encoding: encoding),
                cancellationToken));
    }

    /// <summary>
    ///     Opens a <see cref="StreamWriter" /> to append text to a file.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <returns>
    ///     A <see cref="StreamWriter" /> that can write to a file.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> is <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public StreamWriter AppendText(string path)
    {
        _ = Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));

        return FSFile.AppendText(path);
    }

    /// <summary>
    ///     Copies a file to another.
    /// </summary>
    /// <param name="sourceFileName">The source file.</param>
    /// <param name="destFileName">The destination file.</param>
    /// <param name="overwrite">
    ///     If <see langword="true" />, overwrites the destination file, if one exists, otherwise throws an exception. If a
    ///     destination file doesn't
    ///     exist, this parameter is ignored.
    /// </param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="sourceFileName" /> or <paramref name="destFileName" /> is <see langword="null" /> (
    ///     <see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public void Copy(
        string sourceFileName,
        string destFileName,
        bool overwrite = false)
    {
        _ = Requires.NotNullOrWhiteSpace(
            sourceFileName,
            nameof(sourceFileName));
        _ = Requires.NotNullOrWhiteSpace(
            destFileName,
            nameof(destFileName));

        FSFile.Copy(
            sourceFileName,
            destFileName,
            overwrite);
    }

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
    /// <param name="cancellationToken">The cancellation token to stop this operation.</param>
    /// <returns>A task representing the current operation.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="sourceFileName" /> or <paramref name="destinationFileName" /> is <see langword="null" /> (
    ///     <see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public ValueTask CopyAsync(
        string sourceFileName,
        string destinationFileName,
        bool overwrite = false,
        CancellationToken cancellationToken = default)
    {
        _ = Requires.NotNullOrWhiteSpace(
            sourceFileName,
            nameof(sourceFileName));
        _ = Requires.NotNullOrWhiteSpace(
            destinationFileName,
            nameof(destinationFileName));

        return new(Work.OnThreadPoolAsync(
            state => FSFile.Copy(
                state.Source,
                state.Destination,
                state.Overwrite),
            (Source: sourceFileName, Destination: destinationFileName, Overwrite: overwrite),
            cancellationToken));
    }

    /// <summary>
    ///     Creates a file.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="bufferSize">The buffer size to use. Default is 4 kilobytes.</param>
    /// <returns>
    ///     A <see cref="Stream" /> that can read from and write to a file.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> is <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="bufferSize" /> is less than or equal to 0.
    /// </exception>
    public Stream Create(
        string path,
        int bufferSize = 4096)
    {
        _ = Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));
        Requires.Positive(
            in bufferSize,
            nameof(bufferSize));

        return FSFile.Create(
            path,
            bufferSize);
    }

    /// <summary>
    ///     Opens a <see cref="StreamWriter" /> to write text to a file.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <returns>
    ///     A <see cref="StreamWriter" /> that can write to a file.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> is <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public StreamWriter CreateText(string path)
    {
        _ = Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));

        return FSFile.CreateText(path);
    }

    /// <summary>
    ///     Deletes a file.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> is <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public void Delete(string path)
    {
        _ = Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));

        FSFile.Delete(path);
    }

    /// <summary>
    ///     Asynchronously deletes a file.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="cancellationToken">The cancellation token to stop this operation.</param>
    /// <returns>A task representing the current operation.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> is <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public ValueTask DeleteAsync(
        string path,
        CancellationToken cancellationToken = default)
    {
        _ = Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));

        return new(Work.OnThreadPoolAsync(
            FSFile.Delete,
            path,
            cancellationToken));
    }

    /// <summary>
    ///     Checks whether a file exists and is accessible.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <returns>
    ///     Returns <see langword="true" /> if the specified file exists and is accessible, <see langword="false" /> otherwise.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> is <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public bool Exists(string path)
    {
        _ = Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));

        return FSFile.Exists(path);
    }

    /// <summary>
    ///     Asynchronously checks whether a file exists and is accessible.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="cancellationToken">The cancellation token to stop this operation.</param>
    /// <returns>
    ///     Returns <see langword="true" /> if the specified file exists and is accessible, <see langword="false" /> otherwise.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> is <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public ValueTask<bool> ExistsAsync(
        string path,
        CancellationToken cancellationToken = default)
    {
        _ = Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));

        return new(Work.OnThreadPoolAsync(FSFile.Exists, path, cancellationToken));
    }

    /// <summary>
    ///     Gets a specific file's creation time, in UTC.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <returns>
    ///     A <see cref="DateTime" /> in UTC.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> is <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public DateTime GetCreationTime(string path)
    {
        _ = Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));

        return FSFile.GetCreationTimeUtc(path);
    }

    /// <summary>
    ///     Asynchronously gets a specific file's creation time, in UTC.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="cancellationToken">The cancellation token to stop this operation.</param>
    /// <returns>
    ///     A <see cref="DateTime" /> in UTC.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> is <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public ValueTask<DateTime> GetCreationTimeAsync(
        string path,
        CancellationToken cancellationToken = default)
    {
        _ = Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));

        return new(Work.OnThreadPoolAsync(FSFile.GetCreationTimeUtc, path, cancellationToken));
    }

    /// <summary>
    ///     Gets a specific file's last access time, in UTC.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <returns>
    ///     A <see cref="DateTime" /> in UTC.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> is <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public DateTime GetLastAccessTime(string path)
    {
        _ = Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));

        return FSFile.GetLastAccessTimeUtc(path);
    }

    /// <summary>
    ///     Asynchronously gets a specific file's last access time, in UTC.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="cancellationToken">The cancellation token to stop this operation.</param>
    /// <returns>
    ///     A <see cref="DateTime" /> in UTC.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> is <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public ValueTask<DateTime> GetLastAccessTimeAsync(
        string path,
        CancellationToken cancellationToken = default)
    {
        _ = Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));

        return new(Work.OnThreadPoolAsync(FSFile.GetLastAccessTimeUtc, path, cancellationToken));
    }

    /// <summary>
    ///     Gets a specific file's last write time, in UTC.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <returns>
    ///     A <see cref="DateTime" /> in UTC.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> is <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public DateTime GetLastWriteTime(string path)
    {
        _ = Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));

        return FSFile.GetLastWriteTimeUtc(path);
    }

    /// <summary>
    ///     Asynchronously gets a specific file's last write time, in UTC.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="cancellationToken">The cancellation token to stop this operation.</param>
    /// <returns>
    ///     A <see cref="DateTime" /> in UTC.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> is <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public ValueTask<DateTime> GetLastWriteTimeAsync(
        string path,
        CancellationToken cancellationToken = default)
    {
        _ = Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));

        return new(Work.OnThreadPoolAsync(FSFile.GetLastWriteTimeUtc, path, cancellationToken));
    }

    /// <summary>
    ///     Move a file.
    /// </summary>
    /// <param name="sourceFileName">The source file name.</param>
    /// <param name="destFileName">The destination file name.</param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="sourceFileName" /> or <paramref name="destFileName" /> is <see langword="null" /> (
    ///     <see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public void Move(
        string sourceFileName,
        string destFileName)
    {
        _ = Requires.NotNullOrWhiteSpace(
            sourceFileName,
            nameof(sourceFileName));
        _ = Requires.NotNullOrWhiteSpace(
            destFileName,
            nameof(destFileName));

        FSFile.Move(
            sourceFileName,
            destFileName);
    }

    /// <summary>
    ///     Asynchronously move a file.
    /// </summary>
    /// <param name="sourceFileName">The source file name.</param>
    /// <param name="destinationFileName">The destination file name.</param>
    /// <param name="cancellationToken">The cancellation token to stop this operation.</param>
    /// <returns>A task representing the current operation.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="sourceFileName" /> or <paramref name="destinationFileName" /> is <see langword="null" /> (
    ///     <see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public ValueTask MoveAsync(
        string sourceFileName,
        string destinationFileName,
        CancellationToken cancellationToken = default)
    {
        _ = Requires.NotNullOrWhiteSpace(
            sourceFileName,
            nameof(sourceFileName));
        _ = Requires.NotNullOrWhiteSpace(
            destinationFileName,
            nameof(destinationFileName));

        return new(Work.OnThreadPoolAsync(state => FSFile.Move(state.Source, state.Destination), (Source: sourceFileName, Destination: destinationFileName), cancellationToken));
    }

    /// <summary>
    ///     Opens a <see cref="Stream" /> to read from a file.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <returns>
    ///     A <see cref="Stream" /> that can read from a file.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> is <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public Stream OpenRead(string path)
    {
        _ = Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));

        return FSFile.OpenRead(path);
    }

    /// <summary>
    ///     Opens a <see cref="StreamReader" /> to read text from a file.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <returns>
    ///     A <see cref="StreamReader" /> that can read from a file.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> is <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public StreamReader OpenText(string path)
    {
        _ = Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));

        return FSFile.OpenText(path);
    }

    /// <summary>
    ///     Opens a <see cref="Stream" /> to write to a file.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <returns>
    ///     A <see cref="Stream" /> that can write to a file.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> is <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public Stream OpenWrite(string path)
    {
        _ = Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));

        return FSFile.OpenWrite(path);
    }

    /// <summary>
    ///     Reads the entire contents of a file.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <returns>
    ///     The contents of a file, in binary.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> is <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public byte[] ReadAllBytes(string path)
    {
        _ = Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));

        return FSFile.ReadAllBytes(path);
    }

    /// <summary>
    ///     Asynchronously reads the entire contents of a file.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="cancellationToken">The cancellation token to stop this operation.</param>
    /// <returns>
    ///     The contents of a file, in binary.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> is <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public ValueTask<byte[]> ReadAllBytesAsync(
        string path,
        CancellationToken cancellationToken = default)
    {
        _ = Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));

        return new(Work.OnThreadPoolAsync(FSFile.ReadAllBytes, path, cancellationToken));
    }

    /// <summary>
    ///     Reads the entire contents of a file and splits them by end-of-line markers.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="encoding">The encoding to use.</param>
    /// <returns>
    ///     An array of <see cref="string" />.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> is <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    /// <remarks>
    ///     This operation always requires an encoding to be used. If <paramref name="encoding" /> is set to
    ///     <see langword="null" />, an implementation-specific
    ///     encoding will be used.
    /// </remarks>
    public string[] ReadAllLines(
        string path,
        Encoding? encoding = null)
    {
        _ = Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));

        return encoding == null
            ? FSFile.ReadAllLines(path)
            : FSFile.ReadAllLines(
                path,
                encoding);
    }

    /// <summary>
    ///     Asynchronously reads the entire contents of a file and splits them by end-of-line markers.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="encoding">The encoding to use.</param>
    /// <param name="cancellationToken">The cancellation token to stop this operation.</param>
    /// <returns>
    ///     An array of <see cref="string" />.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> is <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    /// <remarks>
    ///     This operation always requires an encoding to be used. If <paramref name="encoding" /> is set to
    ///     <see langword="null" />, an implementation-specific
    ///     encoding will be used.
    /// </remarks>
    public ValueTask<string[]> ReadAllLinesAsync(
        string path,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default)
    {
        _ = Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));

        return new(encoding == null
                       ? Work.OnThreadPoolAsync(
                           FSFile.ReadAllLines,
                           path,
                           cancellationToken)
                       : Work.OnThreadPoolAsync(
                           state => FSFile.ReadAllLines(
                               state.Path,
                               state.Encoding),
                           (Path: path, Encoding: encoding),
                           cancellationToken));
    }

    /// <summary>
    ///     Reads the entire contents of a file as text.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="encoding">The encoding to use.</param>
    /// <returns>
    ///     The entire file contents as a string.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> is <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    /// <remarks>
    ///     This operation always requires an encoding to be used. If <paramref name="encoding" /> is set to
    ///     <see langword="null" />, an implementation-specific
    ///     encoding will be used.
    /// </remarks>
    public string ReadAllText(
        string path,
        Encoding? encoding = null)
    {
        _ = Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));

        return encoding == null
            ? FSFile.ReadAllText(path)
            : FSFile.ReadAllText(
                path,
                encoding);
    }

    /// <summary>
    ///     Asynchronously reads the entire contents of a file as text.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="encoding">The encoding to use.</param>
    /// <param name="cancellationToken">The cancellation token to stop this operation.</param>
    /// <returns>
    ///     The entire file contents as a string.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> is <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    /// <remarks>
    ///     This operation always requires an encoding to be used. If <paramref name="encoding" /> is set to
    ///     <see langword="null" />, an implementation-specific
    ///     encoding will be used.
    /// </remarks>
    public ValueTask<string> ReadAllTextAsync(
        string path,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default)
    {
        _ = Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));

        return new(
            encoding == null
                ? Work.OnThreadPoolAsync(
                    FSFile.ReadAllText,
                    path,
                    cancellationToken)
                : Work.OnThreadPoolAsync(
                    state => FSFile.ReadAllText(
                        state.Path,
                        state.Encoding),
                    (Path: path, Encoding: encoding),
                    cancellationToken));
    }

    /// <summary>
    ///     Reads file contents as text line by line.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="encoding">The encoding to use.</param>
    /// <returns>
    ///     An enumerable of strings, each representing one line of text.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> is <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    /// <remarks>
    ///     This operation always requires an encoding to be used. If <paramref name="encoding" /> is set to
    ///     <see langword="null" />, an implementation-specific
    ///     encoding will be used.
    /// </remarks>
    public IEnumerable<string> ReadLines(
        string path,
        Encoding? encoding = null)
    {
        _ = Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));

        return encoding == null
            ? FSFile.ReadLines(path)
            : FSFile.ReadLines(
                path,
                encoding);
    }

    /// <summary>
    ///     Sets the file's creation time.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="creationTime">A <see cref="DateTime" /> with the file attribute to set.</param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> is <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public void SetCreationTime(
        string path,
        DateTime creationTime)
    {
        _ = Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));

        FSFile.SetCreationTimeUtc(
            path,
            creationTime);
    }

    /// <summary>
    ///     Asynchronously sets the file's creation time.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="creationTime">A <see cref="DateTime" /> with the file attribute to set.</param>
    /// <param name="cancellationToken">The cancellation token to stop this operation.</param>
    /// <returns>A task representing the current operation.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> is <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public ValueTask SetCreationTimeAsync(
        string path,
        DateTime creationTime,
        CancellationToken cancellationToken = default)
    {
        _ = Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));

        return new(Work.OnThreadPoolAsync(
            state => FSFile.SetCreationTimeUtc(
                state.Path,
                state.CreationTime),
            (Path: path, CreationTime: creationTime),
            cancellationToken));
    }

    /// <summary>
    ///     Sets the file's last access time.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="lastAccessTime">A <see cref="DateTime" /> with the file attribute to set.</param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> is <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public void SetLastAccessTime(
        string path,
        DateTime lastAccessTime)
    {
        _ = Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));

        FSFile.SetLastAccessTimeUtc(
            path,
            lastAccessTime);
    }

    /// <summary>
    ///     Asynchronously sets the file's last access time.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="lastAccessTime">A <see cref="DateTime" /> with the file attribute to set.</param>
    /// <param name="cancellationToken">The cancellation token to stop this operation.</param>
    /// <returns>A task representing the current operation.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> is <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public ValueTask SetLastAccessTimeAsync(
        string path,
        DateTime lastAccessTime,
        CancellationToken cancellationToken = default)
    {
        _ = Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));

        return new(
            Work.OnThreadPoolAsync(
                state => FSFile.SetLastAccessTimeUtc(
                    state.Path,
                    state.LastAccessTime),
                (Path: path, LastAccessTime: lastAccessTime),
                cancellationToken));
    }

    /// <summary>
    ///     Sets the file's last write time.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="lastWriteTime">A <see cref="DateTime" /> with the file attribute to set.</param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> is <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public void SetLastWriteTime(
        string path,
        DateTime lastWriteTime)
    {
        _ = Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));

        FSFile.SetLastWriteTimeUtc(
            path,
            lastWriteTime);
    }

    /// <summary>
    ///     Asynchronously sets the file's last write time.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="lastWriteTime">A <see cref="DateTime" /> with the file attribute to set.</param>
    /// <param name="cancellationToken">The cancellation token to stop this operation.</param>
    /// <returns>A task representing the current operation.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> is <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public ValueTask SetLastWriteTimeAsync(
        string path,
        DateTime lastWriteTime,
        CancellationToken cancellationToken = default)
    {
        _ = Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));

        return new(
            Work.OnThreadPoolAsync(
                state => FSFile.SetLastWriteTimeUtc(
                    state.Path,
                    state.LastWriteTime),
                (Path: path, LastWriteTime: lastWriteTime),
                cancellationToken));
    }

    /// <summary>
    ///     Writes binary contents to a file.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="bytes">The contents to write.</param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> or <paramref name="bytes" /> is <see langword="null" /> (<see langword="Nothing" /> in
    ///     Visual Basic).
    /// </exception>
    public void WriteAllBytes(
        string path,
        byte[] bytes)
    {
        _ = Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));
        _ = Requires.NotEmpty(
            bytes,
            nameof(bytes));

        FSFile.WriteAllBytes(
            path,
            bytes);
    }

    /// <summary>
    ///     Asynchronously writes binary contents to a file.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="bytes">The contents to write.</param>
    /// <param name="cancellationToken">The cancellation token to stop this operation.</param>
    /// <returns>A task representing the current operation.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> or <paramref name="bytes" /> is <see langword="null" /> (<see langword="Nothing" /> in
    ///     Visual Basic).
    /// </exception>
    public ValueTask WriteAllBytesAsync(
        string path,
        byte[] bytes,
        CancellationToken cancellationToken = default)
    {
        _ = Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));
        _ = Requires.NotEmpty(
            bytes,
            nameof(bytes));

        return new(Work.OnThreadPoolAsync(
            state => FSFile.WriteAllBytes(
                state.Path,
                state.Bytes),
            (Path: path, Bytes: bytes),
            cancellationToken));
    }

    /// <summary>
    ///     Writes lines of text to a file.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="contents">The contents to write.</param>
    /// <param name="encoding">The encoding to use.</param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> or <paramref name="contents" /> is <see langword="null" /> (<see langword="Nothing" /> in
    ///     Visual Basic).
    /// </exception>
    /// <remarks>
    ///     This operation always requires an encoding to be used. If <paramref name="encoding" /> is set to
    ///     <see langword="null" />, an implementation-specific
    ///     encoding will be used.
    /// </remarks>
    public void WriteAllLines(
        string path,
        IEnumerable<string> contents,
        Encoding? encoding = null)
    {
        _ = Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));
        _ = Requires.NotNull(
            contents,
            nameof(contents));

        if (encoding == null)
        {
            FSFile.WriteAllLines(
                path,
                contents);
        }
        else
        {
            FSFile.WriteAllLines(
                path,
                contents,
                encoding);
        }
    }

    /// <summary>
    ///     Asynchronously writes lines of text to a file.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="contents">The contents to write.</param>
    /// <param name="encoding">The encoding to use.</param>
    /// <param name="cancellationToken">The cancellation token to stop this operation.</param>
    /// <returns>A task representing the current operation.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> or <paramref name="contents" /> is <see langword="null" /> (<see langword="Nothing" /> in
    ///     Visual Basic).
    /// </exception>
    /// <remarks>
    ///     This operation always requires an encoding to be used. If <paramref name="encoding" /> is set to
    ///     <see langword="null" />, an implementation-specific
    ///     encoding will be used.
    /// </remarks>
    public ValueTask WriteAllLinesAsync(
        string path,
        IEnumerable<string> contents,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default)
    {
        _ = Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));
        _ = Requires.NotNull(
            contents,
            nameof(contents));

        return new(
            encoding == null
                ? Work.OnThreadPoolAsync(
                    state => FSFile.WriteAllLines(
                        state.Path,
                        state.Contents), (Path: path, Contents: contents),
                    cancellationToken)
                : Work.OnThreadPoolAsync(
                    state => FSFile.WriteAllLines(
                        state.Path,
                        state.Contents,
                        state.Encoding),
                    (Path: path, Contents: contents, Encoding: encoding),
                    cancellationToken));
    }

    /// <summary>
    ///     Writes text to a file.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="contents">The contents to write.</param>
    /// <param name="encoding">The encoding to use.</param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> or <paramref name="contents" /> is <see langword="null" /> (<see langword="Nothing" /> in
    ///     Visual Basic).
    /// </exception>
    /// <remarks>
    ///     This operation always requires an encoding to be used. If <paramref name="encoding" /> is set to
    ///     <see langword="null" />, an implementation-specific
    ///     encoding will be used.
    /// </remarks>
    public void WriteAllText(
        string path,
        string contents,
        Encoding? encoding = null)
    {
        _ = Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));
        _ = Requires.NotNullOrWhiteSpace(
            contents,
            nameof(contents));

        if (encoding == null)
        {
            FSFile.WriteAllText(
                path,
                contents);
        }
        else
        {
            FSFile.WriteAllText(
                path,
                contents,
                encoding);
        }
    }

    /// <summary>
    ///     Asynchronously writes text to a file.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="contents">The contents to write.</param>
    /// <param name="encoding">The encoding to use.</param>
    /// <param name="cancellationToken">The cancellation token to stop this operation.</param>
    /// <returns>A task representing the current operation.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> or <paramref name="contents" /> is <see langword="null" /> (<see langword="Nothing" /> in
    ///     Visual Basic).
    /// </exception>
    /// <remarks>
    ///     This operation always requires an encoding to be used. If <paramref name="encoding" /> is set to
    ///     <see langword="null" />, an implementation-specific
    ///     encoding will be used.
    /// </remarks>
    public ValueTask WriteAllTextAsync(
        string path,
        string contents,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default)
    {
        _ = Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));
        _ = Requires.NotNullOrWhiteSpace(
            contents,
            nameof(contents));

        return new(
            encoding == null
                ? Work.OnThreadPoolAsync(
                    state => FSFile.WriteAllText(
                        state.Path,
                        state.Contents), (Path: path, Contents: contents),
                    cancellationToken)
                : Work.OnThreadPoolAsync(
                    state => FSFile.WriteAllText(
                        state.Path,
                        state.Contents,
                        state.Encoding),
                    (Path: path, Contents: contents, Encoding: encoding),
                    cancellationToken));
    }
}