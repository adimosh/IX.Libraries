using System.Collections;
using System.Diagnostics.CodeAnalysis;

using GlobalSystem = System;

namespace IX.Library;

/// <summary>
///     Concrete implementation of the abstraction over the <see cref="GlobalSystem.Environment" /> class. This class
///     cannot be inherited.
/// </summary>
/// <seealso cref="IEnvironment" />
public sealed class Environment : IEnvironment
{
    /// <summary>
    ///     Gets the processor count.
    /// </summary>
    /// <value>
    ///     The processor count.
    /// </value>
    public int ProcessorCount => GlobalSystem.Environment.ProcessorCount;

    /// <summary>
    ///     Gets a value indicating whether the current machine has only a single processor.
    /// </summary>
    public bool IsSingleProcessor => GlobalSystem.Environment.ProcessorCount == 1;

#if NET6_0_OR_GREATER
    /// <summary>
    ///     Gets the unique identifier for the current process.
    /// </summary>
    /// <value>
    ///     The process identifier.
    /// </value>
    public int ProcessId => GlobalSystem.Environment.ProcessId;
#endif

    /// <summary>
    ///     Gets a value indicating whether the current process is a 64-bit process.
    /// </summary>
    /// <value>
    ///     <c>true</c> if the current process is 64-bit; otherwise, <c>false</c>.
    /// </value>
    public bool Is64BitProcess => GlobalSystem.Environment.Is64BitProcess;

    /// <summary>
    ///     Gets a value indicating whether the operating system the current process is running on is 64-bit.
    /// </summary>
    /// <value>
    ///     <c>true</c> if the OS is 64-bit; otherwise, <c>false</c>.
    /// </value>
    public bool Is64BitOperatingSystem => GlobalSystem.Environment.Is64BitOperatingSystem;

    /// <summary>
    ///     Gets the special character(s) that represent a new line in the current environment.
    /// </summary>
    /// <value>
    ///     The new line character(s) for the current environment.
    /// </value>
    public string NewLine => GlobalSystem.Environment.NewLine;

    /// <summary>
    ///     Gets the current operating system version.
    /// </summary>
    /// <value>
    ///     The current operating system version.
    /// </value>
    [SuppressMessage(
        "Usage",
        "DE0009:API is deprecated",
        Justification = "We have no other choice, if we are to emulate the API correctly.")]
    public OperatingSystem OperatingSystemVersion => GlobalSystem.Environment.OSVersion;

    /// <summary>
    ///     Gets the executing assembly version.
    /// </summary>
    /// <value>
    ///     The executing assembly version.
    /// </value>
    public Version Version => GlobalSystem.Environment.Version;

    /// <summary>
    ///     Gets the current managed thread identifier.
    /// </summary>
    /// <value>
    ///     The current managed thread identifier.
    /// </value>
    public int CurrentManagedThreadId => GlobalSystem.Environment.CurrentManagedThreadId;

    /// <summary>
    /// Gets a value indicating whether shutdown has started.
    /// </summary>
    /// <value>
    ///   <c>true</c> if shutdown has started; otherwise, <c>false</c>.
    /// </value>
    /// <remarks>
    ///     <para>On .NET Core, unconditionally returns false since .NET Core does not support object finalization during shutdown.</para>
    /// </remarks>
    public bool HasShutdownStarted => GlobalSystem.Environment.HasShutdownStarted;

    /// <summary>
    ///     Gets the name of the user the current process is executing under.
    /// </summary>
    /// <value>
    ///     The name of the user.
    /// </value>
    public string UserName => GlobalSystem.Environment.UserName;

    /// <summary>
    ///     Gets the name of the user domain the current process is executing under.
    /// </summary>
    /// <value>
    ///     The name of the user domain.
    /// </value>
    public string UserDomainName => GlobalSystem.Environment.UserDomainName;

    /// <summary>
    ///     Gets the command line of the current process.
    /// </summary>
    /// <value>
    ///     The command line.
    /// </value>
    public string CommandLine => GlobalSystem.Environment.CommandLine;

    /// <summary>
    ///     Gets the current directory.
    /// </summary>
    /// <value>
    ///     The current directory.
    /// </value>
    public string CurrentDirectory => GlobalSystem.Environment.CurrentDirectory;

    /// <summary>
    ///     Gets the stack trace.
    /// </summary>
    /// <value>
    ///     The stack trace.
    /// </value>
    public string StackTrace => GlobalSystem.Environment.StackTrace;

    /// <summary>Gets the number of milliseconds elapsed since the system started.</summary>
    /// <value>
    ///     A 32-bit signed integer containing the amount of time in milliseconds that has passed since the last time the
    ///     computer was started.
    /// </value>
    public int TickCount => GlobalSystem.Environment.TickCount;

#if NET6_0_OR_GREATER
    /// <summary>Gets the number of milliseconds elapsed since the system started.</summary>
    /// <value>
    ///     A 64-bit signed integer containing the amount of time in milliseconds that has passed since the last time the
    ///     computer was started.
    /// </value>
    public long TickCount64 => GlobalSystem.Environment.TickCount64;
#endif

    /// <summary>
    ///     Gets or sets the exit code.
    /// </summary>
    /// <value>
    ///     The exit code.
    /// </value>
    public int ExitCode
    {
        get => GlobalSystem.Environment.ExitCode;
        set => GlobalSystem.Environment.ExitCode = value;
    }

    /// <summary>
    ///     Gets an environment variable.
    /// </summary>
    /// <param name="variableName">The variable name.</param>
    /// <returns>The value of the environment variable, or <c>null</c> (<c>Nothing</c> in Visual Basic) if one is not found.</returns>
    public string? GetEnvironmentVariable(string variableName) =>
        GlobalSystem.Environment.GetEnvironmentVariable(variableName);

    /// <summary>
    ///     Gets an environment variable.
    /// </summary>
    /// <param name="variableName">Name of the variable.</param>
    /// <param name="target">The target.</param>
    /// <returns>The value of the environment variable, or <c>null</c> (<c>Nothing</c> in Visual Basic) if one is not found.</returns>
    public string? GetEnvironmentVariable(
        string variableName,
        EnvironmentVariableTarget target) =>
        GlobalSystem.Environment.GetEnvironmentVariable(
            variableName,
            target);

    /// <summary>
    ///     Gets all available environment variables.
    /// </summary>
    /// <returns>A dictionary of available environment variables.</returns>
    [SuppressMessage(
        "Usage",
        "DE0006:API is deprecated",
        Justification = "We have no other choice, if we are to emulate the API correctly.")]
    public IDictionary<string, string> GetEnvironmentVariables() =>
        GlobalSystem.Environment.GetEnvironmentVariables()
            .OfType<DictionaryEntry>()
            .ToDictionary(
                p => Convert.ToString(p.Key) ?? string.Empty,
                q => q.Value == null ? string.Empty : Convert.ToString(q.Value) ?? string.Empty);

    /// <summary>
    ///     Gets all available environment variables.
    /// </summary>
    /// <param name="target">The target.</param>
    /// <returns>A dictionary of available environment variables.</returns>
    [SuppressMessage(
        "Usage",
        "DE0006:API is deprecated",
        Justification = "We have no other choice, if we are to emulate the API correctly.")]
    public IDictionary<string, string> GetEnvironmentVariables(EnvironmentVariableTarget target) =>
        GlobalSystem.Environment.GetEnvironmentVariables(target)
            .OfType<DictionaryEntry>()
            .ToDictionary(
                p => Convert.ToString(p.Key) ?? string.Empty,
                q => q.Value == null ? string.Empty : Convert.ToString(q.Value) ?? string.Empty);

    /// <summary>
    ///     Sets the value of an environment variable.
    /// </summary>
    /// <param name="variableName">Name of the variable.</param>
    /// <param name="value">The value.</param>
    public void SetEnvironmentVariable(
        string variableName,
        string? value) =>
        GlobalSystem.Environment.SetEnvironmentVariable(
            variableName,
            value);

    /// <summary>
    ///     Sets the value of an environment variable.
    /// </summary>
    /// <param name="variableName">Name of the variable.</param>
    /// <param name="value">The value.</param>
    /// <param name="target">The target.</param>
    public void SetEnvironmentVariable(
        string variableName,
        string? value,
        EnvironmentVariableTarget target) =>
        GlobalSystem.Environment.SetEnvironmentVariable(
            variableName,
            value,
            target);

    /// <summary>
    ///     Expands the environment variables.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <returns>The expanded version of the environment variables.</returns>
    public string ExpandEnvironmentVariables(string name) => GlobalSystem.Environment.ExpandEnvironmentVariables(name);

    /// <summary>
    ///     Gets a special folder path.
    /// </summary>
    /// <param name="folder">The folder.</param>
    /// <returns>The folder path.</returns>
    public string GetFolderPath(GlobalSystem.Environment.SpecialFolder folder) =>
        GlobalSystem.Environment.GetFolderPath(folder);

    /// <summary>
    ///     Gets a special folder path.
    /// </summary>
    /// <param name="folder">The folder.</param>
    /// <param name="option">The special folder option.</param>
    /// <returns>The folder path.</returns>
    public string GetFolderPath(
        GlobalSystem.Environment.SpecialFolder folder,
        GlobalSystem.Environment.SpecialFolderOption option) =>
        GlobalSystem.Environment.GetFolderPath(
            folder,
            option);

    /// <summary>
    ///     Exits using the specified exit code.
    /// </summary>
    /// <param name="exitCode">The exit code.</param>
    [DoesNotReturn]
    public void Exit(int exitCode)
    {
        GlobalSystem.Environment.Exit(exitCode);

#if !FRAMEWORK_ADVANCED
        throw new InvalidOperationException();
#endif
    }

    /// <summary>
    ///     Fails the current process fast.
    /// </summary>
    /// <param name="message">The message to fail with.</param>
    [DoesNotReturn]
    public void FailFast(string? message)
    {
        GlobalSystem.Environment.FailFast(message);

#if !FRAMEWORK_ADVANCED
        throw new InvalidOperationException();
#endif
    }

    /// <summary>
    ///     Fails the current process fast.
    /// </summary>
    /// <param name="message">The message to fail with.</param>
    /// <param name="exception">The exception to fail with.</param>
    [DoesNotReturn]
    public void FailFast(
        string? message,
        Exception? exception)
    {
        GlobalSystem.Environment.FailFast(
            message,
            exception);

#if !FRAMEWORK_ADVANCED
        throw new InvalidOperationException();
#endif
    }

    /// <summary>
    ///     Gets the command line arguments.
    /// </summary>
    /// <returns>The command line arguments.</returns>
    public string[] GetCommandLineArgs() => GlobalSystem.Environment.GetCommandLineArgs();
}