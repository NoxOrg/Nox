using System.Collections.Generic;
using Nox.Yaml.Attributes;

namespace Nox.Solution;

/// <summary>
/// Defines a unique constraint based on specific attributes.
/// </summary>
[GenerateJsonSchema]
[Title("Unique Attribute Constraint Definition")]
[Description("Defines a unique constraint based on specific attributes.")]
[AdditionalProperties(false)]
public class UniqueAttributeConstraint : DefinitionBase
{
    /// <summary>
    /// Gets or sets the unique name for the attribute constraint.
    /// </summary>
    [Required]
    [Title("Constraint Name")]
    [Description("A unique name for the attribute constraint. Use PascalCase and choose a singular noun.")]
    [Pattern(@"^[^\s]*$")]
    public string Name { get; internal set; } = null!;
    
    /// <summary>
    /// Gets or sets a detailed explanation of the purpose and behavior of this unique attribute constraint.
    /// </summary>
    [Title("Constraint Description")]
    [Description("A detailed explanation of the purpose and behavior of this unique attribute constraint.")]
    public string? Description { get; internal set; }
    
    /// <summary>
    /// Gets or sets the list of attribute names that together form the unique constraint.
    /// </summary>
    [Title("Attribute Names")]
    [Description("List of attribute names that together form the unique constraint.")]
    public IReadOnlyList<string> AttributeNames { get; internal set; } = new List<string>();

    /// <summary>
    /// Gets or sets the list of relationship names that together form the unique constraint.
    /// </summary>
    [Title("Relationship Names")]
    [Description("List of relationship names that together form the unique constraint.")]
    public IReadOnlyList<string> RelationshipNames { get; internal set; } = new List<string>();
}
