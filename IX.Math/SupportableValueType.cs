using System.Diagnostics.CodeAnalysis;

namespace IX.Math;

/// <summary>
///     An enumeration of supported value types.
/// </summary>
[PublicAPI]
[Flags]
[SuppressMessage(
    "Naming",
    "CA1720:Identifier contains type name",
    Justification = "This is OK, we're actually referring to string.")]
public enum SupportableValueType
{
    /// <summary>
    ///     No type supported.
    /// </summary>
    None = 0,

    /// <summary>
    ///     Numeric (depends on the numeric type).
    /// </summary>
    Numeric = 1,

    /// <summary>
    ///     Boolean (pass as <see cref="bool" />).
    /// </summary>
    Boolean = 2,

    /// <summary>
    ///     String (pass as <see cref="string" />).
    /// </summary>
    String = 4,

    /// <summary>
    ///     Byte array (pass as array of <see cref="byte" />).
    /// </summary>
    ByteArray = 8,

    /// <summary>
    ///     All possible types.
    /// </summary>
    All = 15
}