namespace Nox.Types;

/// <summary>
/// The json type options.
/// </summary>

public sealed class JsonTypeOptions
{
    /// <summary>
    /// Gets or sets a value indicating whether ignore array order.
    /// </summary>
    public bool IgnoreArrayOrder { get; set; } = false;

    /// <summary>
    /// Gets or sets a value indicating whether persist minified.
    /// </summary>
    public bool PersistMinified { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether return beautified.
    /// </summary>
    public bool ReturnPretty { get; set; } = true;

    /// <summary>
    /// Gets the max hash depth.
    /// </summary>
    public int MaxHashDepth { get; } = -1;
}
