using System.Diagnostics.CodeAnalysis;

namespace IX.Math.Extensibility;

/// <summary>
/// A service contract for a string formatter of objects.
/// </summary>
public interface IStringFormatter
{
    /// <summary>
    /// Parses the input data into string.
    /// </summary>
    /// <typeparam name="T">The type of data to parse.</typeparam>
    /// <param name="data">The data to parse into string.</param>
    /// <param name="parsedData">The parsed data, if the operation was a success.</param>
    /// <returns>
    ///   <c>true</c> if the parsing was successful, along with the parsing result in the out parameter, or <c>false</c> otherwise, along
    ///   with a default value.
    /// </returns>
    /// <remarks>
    /// <para>The input data will always be one of the types supported internally by the library.</para>
    /// <para>As such, you can expect <see cref="long" />, <see cref="double" />, <see cref="bool" /> and array of <see cref="byte" />.</para>
    /// </remarks>
    bool ParseIntoString<T>(T data, [NotNullWhen(true)] out string? parsedData);
}