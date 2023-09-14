using GlobalIO = System.IO;

namespace IX.Library.IO;

/// <summary>
///     Abstracts the <see cref="GlobalIO.Directory" /> class' static methods into a mock-able interface.
/// </summary>
[PublicAPI]
public interface IDirectory
{
    /// <summary>
    ///     Creates a new directory.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    void CreateDirectory(string path);

    /// <summary>
    ///     Asynchronously creates a new directory.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     A task representing the current operation.
    /// </returns>
    ValueTask CreateDirectoryAsync(
        string path,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Deletes a directory.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="recursive"><see langword="true" /> if deletion should be recursive to all subdirectories.</param>
    void Delete(
        string path,
        bool recursive = false);

    /// <summary>
    ///     Asynchronously deletes a directory.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="recursive"><see langword="true" /> if deletion should be recursive to all subdirectories.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the current operation.</returns>
    ValueTask DeleteAsync(
        string path,
        bool recursive = false,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Enumerates all the directories contained at a certain directory.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <returns>An enumerable of directory paths.</returns>
    IEnumerable<string> EnumerateDirectories(string path);

    /// <summary>
    ///     Asynchronously enumerates all the directories contained at a certain directory.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     A task representing the current operation that has an enumerable of directory paths as result.
    /// </returns>
    ValueTask<IEnumerable<string>> EnumerateDirectoriesAsync(
        string path,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Enumerates the directories contained at a certain directory with a specific search pattern.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="searchPattern">The search pattern to use.</param>
    /// <returns>An enumerable of directory paths.</returns>
    IEnumerable<string> EnumerateDirectories(
        string path,
        string searchPattern);

    /// <summary>
    ///     Asynchronously enumerates the directories contained at a certain directory with a specific search pattern.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="searchPattern">The search pattern to use.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     A task representing the current operation that has an enumerable of directory paths as result.
    /// </returns>
    ValueTask<IEnumerable<string>> EnumerateDirectoriesAsync(
        string path,
        string searchPattern,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Enumerates all the directories contained at a certain directory and all the subdirectories.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <returns>An enumerable of directory paths.</returns>
    IEnumerable<string> EnumerateDirectoriesRecursively(string path);

    /// <summary>
    ///     Enumerates all the directories contained at a certain directory and all the subdirectories.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     A task representing the current operation that has an enumerable of directory paths as result.
    /// </returns>
    ValueTask<IEnumerable<string>> EnumerateDirectoriesRecursivelyAsync(
        string path,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Enumerates the directories contained at a certain directory and all the subdirectories with a specific search
    ///     pattern.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="searchPattern">The search pattern to use.</param>
    /// <returns>An enumerable of directory paths.</returns>
    IEnumerable<string> EnumerateDirectoriesRecursively(
        string path,
        string searchPattern);

    /// <summary>
    ///     Asynchronously enumerates the directories contained at a certain directory and all the subdirectories with a
    ///     specific search pattern.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="searchPattern">The search pattern to use.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     A task representing the current operation that has an enumerable of directory paths as result.
    /// </returns>
    ValueTask<IEnumerable<string>> EnumerateDirectoriesRecursivelyAsync(
        string path,
        string searchPattern,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Enumerates all the files contained at a certain directory.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <returns>An enumerable of file paths.</returns>
    IEnumerable<string> EnumerateFiles(string path);

    /// <summary>
    ///     Asynchronously enumerates all the files contained at a certain directory.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     A task representing the current operation that has an enumerable of file paths as result.
    /// </returns>
    ValueTask<IEnumerable<string>> EnumerateFilesAsync(
        string path,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Enumerates the files contained at a certain directory with a specific search pattern.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="searchPattern">The search pattern to use.</param>
    /// <returns>An enumerable of file paths.</returns>
    IEnumerable<string> EnumerateFiles(
        string path,
        string searchPattern);

    /// <summary>
    ///     Asynchronously enumerates the files contained at a certain directory with a specific search pattern.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="searchPattern">The search pattern to use.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     A task representing the current operation that has an enumerable of file paths as result.
    /// </returns>
    ValueTask<IEnumerable<string>> EnumerateFilesAsync(
        string path,
        string searchPattern,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Enumerates all the files contained at a certain directory and all the subdirectories.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <returns>An enumerable of file paths.</returns>
    IEnumerable<string> EnumerateFilesRecursively(string path);

    /// <summary>
    ///     Asynchronously enumerates all the files contained at a certain directory and all the subdirectories.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     A task representing the current operation that has an enumerable of file paths as result.
    /// </returns>
    ValueTask<IEnumerable<string>> EnumerateFilesRecursivelyAsync(
        string path,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Enumerates the files contained at a certain directory and all the subdirectories with a specific search pattern.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="searchPattern">The search pattern to use.</param>
    /// <returns>An enumerable of file paths.</returns>
    IEnumerable<string> EnumerateFilesRecursively(
        string path,
        string searchPattern);

    /// <summary>
    ///     Asynchronously enumerates the files contained at a certain directory and all the subdirectories with a specific
    ///     search pattern.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="searchPattern">The search pattern to use.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     A task representing the current operation that has an enumerable of file paths as result.
    /// </returns>
    ValueTask<IEnumerable<string>> EnumerateFilesRecursivelyAsync(
        string path,
        string searchPattern,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Enumerates all the file system entries contained at a certain directory.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <returns>An enumerable of file system entry paths.</returns>
    IEnumerable<string> EnumerateFileSystemEntries(string path);

    /// <summary>
    ///     Asynchronously enumerates all the file system entries contained at a certain directory.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     A task representing the current operation that has an enumerable of file system entry paths as result.
    /// </returns>
    ValueTask<IEnumerable<string>> EnumerateFileSystemEntriesAsync(
        string path,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Enumerates the file system entries contained at a certain directory with a specific search pattern.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="searchPattern">The search pattern to use.</param>
    /// <returns>An enumerable of file system entry paths.</returns>
    IEnumerable<string> EnumerateFileSystemEntries(
        string path,
        string searchPattern);

    /// <summary>
    ///     Asynchronously enumerates the file system entries contained at a certain directory with a specific search pattern.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="searchPattern">The search pattern to use.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     A task representing the current operation that has an enumerable of file system entry paths as result.
    /// </returns>
    ValueTask<IEnumerable<string>> EnumerateFileSystemEntriesAsync(
        string path,
        string searchPattern,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Enumerates all the file system entries contained at a certain directory and all the subdirectories.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <returns>An enumerable of file system entry paths.</returns>
    IEnumerable<string> EnumerateFileSystemEntriesRecursively(string path);

    /// <summary>
    ///     Asynchronously enumerates all the file system entries contained at a certain directory and all the subdirectories.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     A task representing the current operation that has an enumerable of file system entry paths as result.
    /// </returns>
    ValueTask<IEnumerable<string>> EnumerateFileSystemEntriesRecursivelyAsync(
        string path,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Enumerates the file system entries contained at a certain directory and all the subdirectories with a specific
    ///     search pattern.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="searchPattern">The search pattern to use.</param>
    /// <returns>An enumerable of file system entry paths.</returns>
    IEnumerable<string> EnumerateFileSystemEntriesRecursively(
        string path,
        string searchPattern);

    /// <summary>
    ///     EAsynchronously enumerates the file system entries contained at a certain directory and all the subdirectories with
    ///     a specific search pattern.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="searchPattern">The search pattern to use.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     A task representing the current operation that has an enumerable of file system entry paths as result.
    /// </returns>
    ValueTask<IEnumerable<string>> EnumerateFileSystemEntriesRecursivelyAsync(
        string path,
        string searchPattern,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Checks whether a directory exists and is accessible.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <returns>
    ///     Returns <see langword="true" /> if the specified directory exists and is accessible, <see langword="false" />
    ///     otherwise.
    /// </returns>
    bool Exists(string path);

    /// <summary>
    ///     Asynchronously checks whether a directory exists and is accessible.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     A task representing the current operation that has the result of a boolean of value <see langword="true" /> if the
    ///     specified directory exists
    ///     and is accessible, <see langword="false" /> otherwise.
    /// </returns>
    ValueTask<bool> ExistsAsync(
        string path,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Gets a specific directory's creation time, in UTC.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <returns>A <see cref="DateTime" /> in UTC.</returns>
    DateTime GetCreationTime(string path);

    /// <summary>
    ///     Asynchronously gets a specific directory's creation time, in UTC.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     A task representing the current operation that has a <see cref="DateTime" /> in UTC.
    /// </returns>
    ValueTask<DateTime> GetCreationTimeAsync(
        string path,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Gets the current directory.
    /// </summary>
    /// <returns>The current directory.</returns>
    string GetCurrentDirectory();

    /// <summary>
    ///     Gets a specific directory's last access time, in UTC.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <returns>A <see cref="DateTime" /> in UTC.</returns>
    DateTime GetLastAccessTime(string path);

    /// <summary>
    ///     GAsynchronously gets a specific directory's last access time, in UTC.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     A task representing the current operation that has a <see cref="DateTime" /> in UTC.
    /// </returns>
    ValueTask<DateTime> GetLastAccessTimeAsync(
        string path,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Gets a specific directory's last write time, in UTC.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <returns>A <see cref="DateTime" /> in UTC.</returns>
    DateTime GetLastWriteTime(string path);

    /// <summary>
    ///     Asynchronously gets a specific directory's last write time, in UTC.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     A task representing the current operation that has a <see cref="DateTime" /> in UTC.
    /// </returns>
    ValueTask<DateTime> GetLastWriteTimeAsync(
        string path,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Moves a directory to another location.
    /// </summary>
    /// <param name="sourceDirectoryName">The source directory name.</param>
    /// <param name="destinationDirectoryName">The destination directory name.</param>
    void Move(
        string sourceDirectoryName,
        string destinationDirectoryName);

    /// <summary>
    ///     Asynchronously moves a directory to another location.
    /// </summary>
    /// <param name="sourceDirectoryName">The source directory name.</param>
    /// <param name="destinationDirectoryName">The destination directory name.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the current operation.</returns>
    ValueTask MoveAsync(
        string sourceDirectoryName,
        string destinationDirectoryName,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Sets the directory's creation time.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="creationTime">A <see cref="DateTime" /> with the directory attribute to set.</param>
    void SetCreationTime(
        string path,
        DateTime creationTime);

    /// <summary>
    ///     Asynchronously sets the directory's creation time.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="creationTime">A <see cref="DateTime" /> with the directory attribute to set.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the current operation.</returns>
    ValueTask SetCreationTimeAsync(
        string path,
        DateTime creationTime,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Sets the directory's last access time.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="lastAccessTime">A <see cref="DateTime" /> with the directory attribute to set.</param>
    void SetLastAccessTime(
        string path,
        DateTime lastAccessTime);

    /// <summary>
    ///     Asynchronously sets the directory's last access time.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="lastAccessTime">A <see cref="DateTime" /> with the directory attribute to set.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the current operation.</returns>
    ValueTask SetLastAccessTimeAsync(
        string path,
        DateTime lastAccessTime,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Sets the directory's last write time.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="lastWriteTime">A <see cref="DateTime" /> with the directory attribute to set.</param>
    void SetLastWriteTime(
        string path,
        DateTime lastWriteTime);

    /// <summary>
    ///     Asynchronously sets the directory's last write time.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="lastWriteTime">A <see cref="DateTime" /> with the directory attribute to set.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the current operation.</returns>
    ValueTask SetLastWriteTimeAsync(
        string path,
        DateTime lastWriteTime,
        CancellationToken cancellationToken = default);
}