namespace Nox.Types;

/// <summary>
/// The json type options.
/// </summary>

public sealed class JsonTypeOptions : INoxTypeOptions
{
    /// <summary>
    /// Gets or sets a value indicating whether persist minified.
    /// </summary>
    public bool PersistMinified { get; set; } = true;

    /// <summary>
    /// Gets the max hash depth.
    /// </summary>
    public int MaxHashDepth { get; } = -1;
}
