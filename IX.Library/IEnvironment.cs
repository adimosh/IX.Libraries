using System.Diagnostics.CodeAnalysis;

namespace IX.Library;

/// <summary>
///     Represents an abstraction over the <see cref="T:System.Environment" /> class.
/// </summary>
public interface IEnvironment
{
    /// <summary>
    ///     Gets the processor count.
    /// </summary>
    /// <value>
    ///     The processor count.
    /// </value>
    int ProcessorCount { get; }

    /// <summary>
    ///     Gets a value indicating whether the current machine has only a single processor.
    /// </summary>
    bool IsSingleProcessor { get; }

#if NET6_0_OR_GREATER
    /// <summary>
    ///     Gets the unique identifier for the current process.
    /// </summary>
    /// <value>
    ///     The process identifier.
    /// </value>
    public int ProcessId { get; }
#endif

    /// <summary>
    ///     Gets a value indicating whether the current process is a 64-bit process.
    /// </summary>
    /// <value>
    ///     <c>true</c> if the current process is 64-bit; otherwise, <c>false</c>.
    /// </value>
    bool Is64BitProcess { get; }

    /// <summary>
    ///     Gets a value indicating whether the operating system the current process is running on is 64-bit.
    /// </summary>
    /// <value>
    ///     <c>true</c> if the OS is 64-bit; otherwise, <c>false</c>.
    /// </value>
    bool Is64BitOperatingSystem { get; }

    /// <summary>
    ///     Gets the special character(s) that represent a new line in the current environment.
    /// </summary>
    /// <value>
    ///     The new line character(s) for the current environment.
    /// </value>
    string NewLine { get; }

    /// <summary>
    ///     Gets the current operating system version.
    /// </summary>
    /// <value>
    ///     The current operating system version.
    /// </value>
    OperatingSystem OperatingSystemVersion { get; }

    /// <summary>
    ///     Gets the executing assembly version.
    /// </summary>
    /// <value>
    ///     The executing assembly version.
    /// </value>
    Version Version { get; }

    /// <summary>
    ///     Gets the current managed thread identifier.
    /// </summary>
    /// <value>
    ///     The current managed thread identifier.
    /// </value>
    int CurrentManagedThreadId { get; }

    /// <summary>
    /// Gets a value indicating whether shutdown has started.
    /// </summary>
    /// <value>
    ///   <c>true</c> if shutdown has started; otherwise, <c>false</c>.
    /// </value>
    /// <remarks>
    ///     <para>On .NET Core, unconditionally returns false since .NET Core does not support object finalization during shutdown.</para>
    /// </remarks>
    bool HasShutdownStarted { get; }

    /// <summary>
    ///     Gets the name of the user the current process is executing under.
    /// </summary>
    /// <value>
    ///     The name of the user.
    /// </value>
    string UserName { get; }

    /// <summary>
    ///     Gets the name of the user domain the current process is executing under.
    /// </summary>
    /// <value>
    ///     The name of the user domain.
    /// </value>
    string UserDomainName { get; }

    /// <summary>
    ///     Gets the command line of the current process.
    /// </summary>
    /// <value>
    ///     The command line.
    /// </value>
    string CommandLine { get; }

    /// <summary>
    ///     Gets the current directory.
    /// </summary>
    /// <value>
    ///     The current directory.
    /// </value>
    string CurrentDirectory { get; }

    /// <summary>
    ///     Gets the stack trace.
    /// </summary>
    /// <value>
    ///     The stack trace.
    /// </value>
    string StackTrace { get; }

    /// <summary>Gets the number of milliseconds elapsed since the system started.</summary>
    /// <value>
    ///     A 32-bit signed integer containing the amount of time in milliseconds that has passed since the last time the
    ///     computer was started.
    /// </value>
    int TickCount { get; }

#if NET6_0_OR_GREATER
    /// <summary>Gets the number of milliseconds elapsed since the system started.</summary>
    /// <value>
    ///     A 64-bit signed integer containing the amount of time in milliseconds that has passed since the last time the
    ///     computer was started.
    /// </value>
    public long TickCount64 { get; }
#endif

    /// <summary>
    ///     Gets or sets the exit code.
    /// </summary>
    /// <value>
    ///     The exit code.
    /// </value>
    int ExitCode { get; set; }

    /// <summary>
    ///     Gets an environment variable.
    /// </summary>
    /// <param name="variableName">The variable name.</param>
    /// <returns>The value of the environment variable, or <c>null</c> (<c>Nothing</c> in Visual Basic) if one is not found.</returns>
    string? GetEnvironmentVariable(string variableName);

    /// <summary>
    ///     Gets an environment variable.
    /// </summary>
    /// <param name="variableName">Name of the variable.</param>
    /// <param name="target">The target.</param>
    /// <returns>The value of the environment variable, or <c>null</c> (<c>Nothing</c> in Visual Basic) if one is not found.</returns>
    string? GetEnvironmentVariable(
        string variableName,
        EnvironmentVariableTarget target);

    /// <summary>
    ///     Gets all available environment variables.
    /// </summary>
    /// <returns>A dictionary of available environment variables.</returns>
    IDictionary<string, string> GetEnvironmentVariables();

    /// <summary>
    ///     Gets all available environment variables.
    /// </summary>
    /// <param name="target">The target.</param>
    /// <returns>A dictionary of available environment variables.</returns>
    IDictionary<string, string> GetEnvironmentVariables(EnvironmentVariableTarget target);

    /// <summary>
    ///     Sets the value of an environment variable.
    /// </summary>
    /// <param name="variableName">Name of the variable.</param>
    /// <param name="value">The value.</param>
    void SetEnvironmentVariable(
        string variableName,
        string? value);

    /// <summary>
    ///     Sets the value of an environment variable.
    /// </summary>
    /// <param name="variableName">Name of the variable.</param>
    /// <param name="value">The value.</param>
    /// <param name="target">The target.</param>
    void SetEnvironmentVariable(
        string variableName,
        string? value,
        EnvironmentVariableTarget target);

    /// <summary>
    ///     Expands the environment variables.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <returns>The expanded version of the environment variables.</returns>
    string ExpandEnvironmentVariables(string name);

    /// <summary>
    ///     Gets a special folder path.
    /// </summary>
    /// <param name="folder">The folder.</param>
    /// <returns>The folder path.</returns>
    string GetFolderPath(global::System.Environment.SpecialFolder folder);

    /// <summary>
    ///     Gets a special folder path.
    /// </summary>
    /// <param name="folder">The folder.</param>
    /// <param name="option">The special folder option.</param>
    /// <returns>The folder path.</returns>
    string GetFolderPath(
        global::System.Environment.SpecialFolder folder,
        global::System.Environment.SpecialFolderOption option);

    /// <summary>
    ///     Exits using the specified exit code.
    /// </summary>
    /// <param name="exitCode">The exit code.</param>
    [DoesNotReturn]
    void Exit(int exitCode);

    /// <summary>
    ///     Fails the current process fast.
    /// </summary>
    /// <param name="message">The message to fail with.</param>
    [DoesNotReturn]
    void FailFast(string? message);

    /// <summary>
    ///     Fails the current process fast.
    /// </summary>
    /// <param name="message">The message to fail with.</param>
    /// <param name="exception">The exception to fail with.</param>
    [DoesNotReturn]
    void FailFast(
        string? message,
        Exception? exception);

    /// <summary>
    ///     Gets the command line arguments.
    /// </summary>
    /// <returns>The command line arguments.</returns>
    string[] GetCommandLineArgs();
}