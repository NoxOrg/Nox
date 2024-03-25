using Nox.Types;

namespace Nox.Domain;

/// <summary>
/// Base for Nox.Type Enum
/// </summary>
public abstract partial class EnumerationBase : IEntity
{
    /// <summary>
    /// Enum Id
    /// </summary>
    public Enumeration Id { get; set; } = null!;

    /// <summary>
    /// Default Translation for the Enum Name
    /// </summary>
    public string Name { get; set; } = null!;
}