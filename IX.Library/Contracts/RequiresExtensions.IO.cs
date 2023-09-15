using IX.Library.IO;

using System.Runtime.CompilerServices;

namespace IX.Library.Contracts;

/// <summary>
/// Extensions for various objects that might aid with contract-based validation.
/// </summary>
public static partial class RequiresExtensions
{
    /// <summary>
    /// Called when a contract requires that a specific directory path is valid, exists and is accessible.
    /// </summary>
    /// <param name="directoryShim">The directory shim to extend.</param>
    /// <param name="directoryPath">The path to check.</param>
    /// <param name="argumentName">The name of the argument.</param>
    /// <returns>The validated path argument.</returns>
    /// <exception cref="ArgumentNullOrWhiteSpaceStringException">The path is null, empty or whitespace-only.</exception>
    /// <exception cref="ArgumentInvalidPathException">The path is invalid, non-existent or inaccessible.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [ContractAnnotation("directoryPath:null => halt")]
    [AssertionMethod]
    public static string RequiresExists(
        this IDirectory directoryShim,
        string directoryPath,
        [CallerArgumentExpression("directoryPath")]
        string argumentName = "directoryPath")
    {
        if (string.IsNullOrWhiteSpace(directoryPath))
        {
            throw new ArgumentNullOrWhiteSpaceStringException(argumentName);
        }

        if (!directoryShim.Exists(directoryPath))
        {
            throw new ArgumentInvalidPathException(argumentName);
        }

        return directoryPath;
    }

    /// <summary>
    /// Called when a contract requires that a specific directory path is valid, exists and is accessible.
    /// </summary>
    /// <param name="directoryShim">The directory shim to extend.</param>
    /// <param name="field">
    ///     The field that this argument is initializing.
    /// </param>
    /// <param name="directoryPath">The path to check.</param>
    /// <param name="argumentName">The name of the argument.</param>
    /// <exception cref="ArgumentNullOrWhiteSpaceStringException">The path is null, empty or whitespace-only.</exception>
    /// <exception cref="ArgumentInvalidPathException">The path is invalid, non-existent or inaccessible.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [ContractAnnotation("directoryPath:null => halt")]
    [AssertionMethod]
    public static void RequiresExists(
        this IDirectory directoryShim,
        out string field,
        string directoryPath,
        [CallerArgumentExpression("directoryPath")]
        string argumentName = "directoryPath")
    {
        if (string.IsNullOrWhiteSpace(directoryPath))
        {
            throw new ArgumentNullOrWhiteSpaceStringException(argumentName);
        }

        if (!directoryShim.Exists(directoryPath))
        {
            throw new ArgumentInvalidPathException(argumentName);
        }

        field = directoryPath;
    }

    /// <summary>
    /// Called when a contract requires that a specific file path is valid, exists and is accessible.
    /// </summary>
    /// <param name="fileShim">The file shim to extend.</param>
    /// <param name="filePath">The path to check.</param>
    /// <param name="argumentName">The name of the argument.</param>
    /// <returns>The validated path argument.</returns>
    /// <exception cref="ArgumentNullOrWhiteSpaceStringException">The path is null, empty or whitespace-only.</exception>
    /// <exception cref="ArgumentInvalidPathException">The path is invalid, non-existent or inaccessible.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [ContractAnnotation("filePath:null => halt")]
    [AssertionMethod]
    public static string RequiresExists(
        this IFile fileShim,
        string filePath,
        [CallerArgumentExpression("filePath")]
        string argumentName = "filePath")
    {
        if (string.IsNullOrWhiteSpace(filePath))
        {
            throw new ArgumentNullOrWhiteSpaceStringException(argumentName);
        }

        if (!fileShim.Exists(filePath))
        {
            throw new ArgumentInvalidPathException(argumentName);
        }

        return filePath;
    }

    /// <summary>
    /// Called when a contract requires that a specific file path is valid, exists and is accessible.
    /// </summary>
    /// <param name="fileShim">The file shim to extend.</param>
    /// <param name="field">
    ///     The field that this argument is initializing.
    /// </param>
    /// <param name="filePath">The path to check.</param>
    /// <param name="argumentName">The name of the argument.</param>
    /// <exception cref="ArgumentNullOrWhiteSpaceStringException">The path is null, empty or whitespace-only.</exception>
    /// <exception cref="ArgumentInvalidPathException">The path is invalid, non-existent or inaccessible.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [ContractAnnotation("filePath:null => halt")]
    [AssertionMethod]
    public static void RequiresExists(
        this IFile fileShim,
        out string field,
        string filePath,
        [CallerArgumentExpression("filePath")]
        string argumentName = "filePath")
    {
        if (string.IsNullOrWhiteSpace(filePath))
        {
            throw new ArgumentNullOrWhiteSpaceStringException(argumentName);
        }

        if (!fileShim.Exists(filePath))
        {
            throw new ArgumentInvalidPathException(argumentName);
        }

        field = filePath;
    }

    /// <summary>
    /// Called when a contract requires that a specific path is valid.
    /// </summary>
    /// <param name="pathShim">The path shim to extend.</param>
    /// <param name="testPath">The path to check.</param>
    /// <param name="argumentName">The name of the argument.</param>
    /// <returns>The validated path argument.</returns>
    /// <exception cref="ArgumentNullOrWhiteSpaceStringException">The path is null, empty or whitespace-only.</exception>
    /// <exception cref="ArgumentInvalidPathException">The path is invalid, non-existent or inaccessible.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [ContractAnnotation("testPath:null => halt")]
    [AssertionMethod]
    public static string RequiresValid(
        this IPath pathShim,
        string testPath,
        [CallerArgumentExpression("testPath")]
        string argumentName = "testPath")
    {
        if (string.IsNullOrWhiteSpace(testPath))
        {
            throw new ArgumentNullOrWhiteSpaceStringException(argumentName);
        }

        ReadOnlySpan<char> chr = testPath.AsSpan();
        var invalidChars = pathShim.GetInvalidPathChars();

        for (int i = 0; i < chr.Length; i++)
        {
            if (invalidChars.Contains(chr[i]))
            {
                throw new ArgumentInvalidPathException(argumentName);
            }
        }

        return testPath;
    }

    /// <summary>
    /// Called when a contract requires that a specific path is valid.
    /// </summary>
    /// <param name="pathShim">The path shim to extend.</param>
    /// <param name="field">
    ///     The field that this argument is initializing.
    /// </param>
    /// <param name="testPath">The path to check.</param>
    /// <param name="argumentName">The name of the argument.</param>
    /// <exception cref="ArgumentNullOrWhiteSpaceStringException">The path is null, empty or whitespace-only.</exception>
    /// <exception cref="ArgumentInvalidPathException">The path is invalid, non-existent or inaccessible.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [ContractAnnotation("testPath:null => halt")]
    [AssertionMethod]
    public static void RequiresValid(
        this IPath pathShim,
        out string field,
        string testPath,
        [CallerArgumentExpression("testPath")]
        string argumentName = "testPath")
    {
        if (string.IsNullOrWhiteSpace(testPath))
        {
            throw new ArgumentNullOrWhiteSpaceStringException(argumentName);
        }

        ReadOnlySpan<char> chr = testPath.AsSpan();
        var invalidChars = pathShim.GetInvalidPathChars();

        for (int i = 0; i < chr.Length; i++)
        {
            if (invalidChars.Contains(chr[i]))
            {
                throw new ArgumentInvalidPathException(argumentName);
            }
        }

        field = testPath;
    }
}