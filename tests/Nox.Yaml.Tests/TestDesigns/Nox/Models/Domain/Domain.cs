using Nox.Yaml.Attributes;
using System.Collections.Immutable;
using YamlDotNet.Serialization;

namespace Nox.Yaml.Tests.TestDesigns.Nox.Models;

[GenerateJsonSchema]
[Title("Information about the domain including entities and their relationships")]
[Description("Contains definitions of entities, their attributes, events, commands and queries.")]
[AdditionalProperties(false)]
public class Domain : YamlConfigNode<NoxSolution,NoxSolution>
{
    [Required]
    [Title("The entities that describe the domain.")]
    [Description("The collection of entities and their relationships with each other.")]
    [UniqueItemProperties(nameof(Entity.Name))]
    [AdditionalProperties(false)]
    public IReadOnlyList<Entity> Entities { get; internal set; } = Array.Empty<Entity>();

    public Entity GetEntityByName(string entityName)
    {
        return _entitiesByName![entityName];
    }

    [YamlIgnore]
    private ImmutableDictionary<string, Entity>? _entitiesByName;

    public override void SetDefaults(NoxSolution topNode, NoxSolution parent, string yamlPath)
    {
        // Initialise 

        _entitiesByName = Entities.ToImmutableDictionary(e => e.Name, e => e);

        // Set basic defaults
    }
}