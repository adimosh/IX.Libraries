using Microsoft.Extensions.Logging;

namespace IX.Library.Logging;

/// <summary>
/// Provides a basic logger and logging mechanism for the IX libraries.
/// </summary>
public static class Log
{
    private static ILoggerFactory? _loggerFactory;
    private static ILoggerProvider? _loggerProvider;

    /// <summary>
    /// Sets a logger factory as a default logging provider.
    /// </summary>
    /// <param name="loggerFactory">The logger factory.</param>
    public static void SetLoggerFactory(ILoggerFactory loggerFactory) => Requires.NotNull(
        out _loggerFactory,
        loggerFactory);

    /// <summary>
    /// Sets a logger provider as a default logging provider.
    /// </summary>
    /// <param name="loggerProvider">The logger provider.</param>
    public static void SetLoggerProvider(ILoggerProvider loggerProvider) =>
        Requires.NotNull(
            out _loggerProvider,
            loggerProvider);

    internal static ILogger? GetLogger<T>() => GetLogger(typeof(T));

    internal static ILogger? GetLogger(Type type) =>
        _loggerFactory != null ? _loggerFactory.CreateLogger(type) : _loggerProvider?.CreateLogger(type.Name);
}