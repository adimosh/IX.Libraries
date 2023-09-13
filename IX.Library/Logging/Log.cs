using IX.Library.Contracts;

using Microsoft.Extensions.Logging;

namespace IX.Library.Logging;

public static class Log
{
    private static ILoggerFactory? _loggerFactory;
    private static ILoggerProvider? _loggerProvider;

    public static void SetLoggerFactory(ILoggerFactory loggerFactory)
    {
        Requires.NotNull(out _loggerFactory, loggerFactory);
    }

    public static void SetLoggerProvider(ILoggerProvider loggerProvider)
    {
        Requires.NotNull(
            out _loggerProvider,
            loggerProvider);
    }

    internal static ILogger? GetLogger<T>() => GetLogger(typeof(T));

    internal static ILogger? GetLogger(Type type)
    {
        if (_loggerFactory != null)
        {
            return _loggerFactory.CreateLogger(type);
        }

        if (_loggerProvider != null)
        {
            return _loggerProvider.CreateLogger(type.Name);
        }

        return null;
    }
}