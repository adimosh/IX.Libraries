namespace IX.Math.Extensibility;

/// <summary>
///     An attribute that will signal a specific class as containing a type formatter.
/// </summary>
/// <seealso cref="Attribute" />
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public class TypeFormatterAttribute : Attribute
{
    /// <summary>
    ///     Gets or sets the level.
    /// </summary>
    /// <value>The level.</value>
    public int Level { get; set; }

    /// <summary>
    /// Gets or sets type from which conversion occurs.
    /// </summary>
    /// <value>
    /// The source type.
    /// </value>
    public SupportedValueType FromType { get; set; }
}