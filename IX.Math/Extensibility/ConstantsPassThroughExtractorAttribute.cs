namespace IX.Math.Extensibility;

/// <summary>
///     An attribute that will signal a specific class as containing a constants extraction.
/// </summary>
/// <seealso cref="Attribute" />
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
public class ConstantsPassThroughExtractorAttribute : Attribute
{
    /// <summary>
    ///     Gets or sets the level.
    /// </summary>
    /// <value>The level.</value>
    public int Level { get; set; }
}