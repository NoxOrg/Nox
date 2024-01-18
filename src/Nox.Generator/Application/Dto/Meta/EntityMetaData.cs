using System.Collections.Generic;

namespace Nox.Generator.Application.Dto.Meta;

/// <summary>
/// Represents metadata for an entity, including its name, type, input parameters, and optional output options.
/// </summary>
internal sealed class EntityMetaData
{
    /// <summary>
    /// Gets or sets the name of the entity.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Gets or sets the type of the entity.
    /// </summary>
    public string Type { get; set; } = null!;

    /// <summary>
    /// Gets or sets the input parameters for the entity.
    /// </summary>
    public string InParams { get; set; } = null!;

    /// <summary>
    /// Gets or sets the optional output options for the entity.
    /// </summary>
    public bool HasTypeOptions { get; set; }

    /// <summary>
    /// Gets or sets the properties of the Output options for the entity.
    /// </summary>
    public IReadOnlyList<string>? OptionsProperties { get; set; }
}