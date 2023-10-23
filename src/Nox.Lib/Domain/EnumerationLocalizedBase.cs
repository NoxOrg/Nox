
using Nox.Types;

namespace Nox.Domain;

/// <summary>
/// Base for localize Nox.Type Enum
/// </summary>
public abstract class EnumerationLocalizedBase
{
    /// <summary>
    /// Enum value
    /// </summary>
    public Enumeration Id { get; set; } = null!;

    public CultureCode CultureCode { get; set; } = null!;
    /// <summary>
    /// Translation for the Enum Name
    /// </summary>
    public string Name { get; set; } = null!;
}
