namespace Nox.Generator.Domain;

/// <summary>
/// Type options property 
/// </summary>
public class OptionProperty
{
    /// <summary>
    /// Gets or sets the type of the property.
    /// </summary>
    public string Type { get; set; } = default!;
    /// <summary>
    /// Gets or sets the name of the property.
    /// </summary>
    public string Name { get; set; } = default!;
    /// <summary>
    /// Gets or sets the value of the property.
    /// </summary>
    public dynamic? Value { get; set; }
}
