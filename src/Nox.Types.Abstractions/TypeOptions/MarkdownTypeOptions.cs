namespace Nox.Types;

public class MarkdownTypeOptions : INoxTypeOptions
{
    /// <summary>
    /// Gets the min length.
    /// </summary>
    public uint MinLength { get; set; } = 0;

    /// <summary>
    /// Gets the max length.
    /// </summary>
    public uint MaxLength { get; set; } = 255;

    /// <summary>
    /// Get if value is Unicode
    /// </summary>
    public bool IsUnicode { get; set; } = true;
}