using Nox.Types;
using Nox.Yaml;
using Nox.Yaml.Attributes;
using Nox.Yaml.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nox.Solution;

[GenerateJsonSchema]
[Title("Information about the domain including entities and their relationships")]
[Description("Contains definitions of entities, their attributes, events, commands and queries.")]
[AdditionalProperties(false)]
public class Domain : YamlConfigNode<NoxSolution, NoxSolution>
{
    [Required]
    [Title("The entities that describe the domain.")]
    [Description("The collection of entities and their relationships with each other.")]
    [UniqueItemProperties(nameof(Entity.Name))]
    [AdditionalProperties(false)]
    public IReadOnlyList<Entity> Entities { get; internal set; } = Array.Empty<Entity>();

    public Entity GetEntityByName(string entityName) => _entitiesByName![entityName];

    private Dictionary<string, Entity>? _entitiesByName;

    public override void Initialize(NoxSolution topNode, NoxSolution parentNode, string yamlPath)
    {
        _entitiesByName = Entities.ToDictionary(e => e.Name, e => e);
    }

    public override ValidationResult Validate(NoxSolution topNode, NoxSolution parentNode, string yamlPath)
    {
        var result = base.Validate(topNode, parentNode, yamlPath);

        ValidateOnlyOneAutoNumberPerEntityForSqlLite(topNode, result);

        return result;
    }

    private void ValidateOnlyOneAutoNumberPerEntityForSqlLite(NoxSolution topNode, ValidationResult result)
    {
        if (topNode.Infrastructure.Persistence?.DatabaseServer.Provider != DatabaseServerProvider.SqLite)
            return;

        foreach (var e in Entities)
        {
            if (e.Attributes.Union(e.Keys).Count(a => a.Type == NoxType.AutoNumber) > 1)
            {
                result.Errors.Add(new ValidationFailure(
                    e.Name,
                    $"SQLite only supports one AutoNumber per entity. Please check attributes/keys in entity [{e.Name}]."
                ));
            }
        }
    }
}