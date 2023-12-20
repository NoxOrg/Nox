using Nox.Types;

namespace Nox.Domain;

/// <summary>
/// Enumeration Translated name
/// </summary>
public abstract class EnumerationLocalizedBase: IEntity
{
    /// <summary>
    /// Enumeration Id
    /// </summary>
    public Enumeration Id { get; set; } = null!;

    /// <summary>
    /// Culture Code for the translated name
    /// </summary>
    public CultureCode CultureCode { get; set; } = null!;
    /// <summary>
    /// Translation for the Enumeration Name
    /// </summary>
    public string Name { get; set; } = null!;
}
