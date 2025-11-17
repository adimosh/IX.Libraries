#if !NET8_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace IX.Library;

/// <summary>
/// Extensions for <see cref="ArgumentNullException"/>.
/// </summary>
public static class ArgumentNullExceptionExtensions
{
    /// <summary>
    /// Extensions for <see cref="ArgumentNullException"/>.
    /// </summary>
    /// <param name="e">The exception, if it is an instance extension method.</param>
    extension(ArgumentNullException e)
    {
        /// <summary>
        /// Throws an <see cref="NullReferenceException"/> if the argument is null.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <param name="paramName">The naming form of the argument.</param>
        /// <exception cref="ArgumentNullException">The exception, if any.</exception>
        public static void ThrowIfNull([NotNull] object? argument, [CallerArgumentExpression(nameof(argument))] string? paramName = null)
        {
            if (argument is null)
            {
                throw new ArgumentNullException(paramName);
            }
        }
    }
}
#endif