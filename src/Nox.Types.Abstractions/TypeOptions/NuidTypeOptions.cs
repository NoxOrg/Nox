using System;

namespace Nox.Types;

/// <summary>
/// Defines Nuid type construction. Nuid = Prefix{separator}{propertyName joined by separator}</code>
/// </summary>
public class NuidTypeOptions
{
    /// <summary>
    /// Prefix is involved in Nuid construction. Prefix is added before property names.
    /// In case Prefix is null or empty than Entity name will be used by default.
    /// </summary>
    public string? Prefix { get; set; }

    /// <summary>
    /// String which is used to join property names.
    /// </summary>
    public string Separator { get; set; } = string.Empty;

    /// <summary>
    /// Entity properties whose values are used in Nuid construction.
    /// </summary>
    public string[] PropertyNames { get; set; } = Array.Empty<string>();
}