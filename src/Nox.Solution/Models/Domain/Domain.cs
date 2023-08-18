using Nox.Types.Schema;
using System.Collections.Generic;
using System.Linq;
using YamlDotNet.Serialization;

namespace Nox.Solution;

[GenerateJsonSchema]
[Title("Information about the domain including entities and their relationships")]
[Description("Contains definitions of entities, their attributes, events, commands and queries.")]
[AdditionalProperties(false)]
public class Domain : DefinitionBase
{
    [Required]
    [Title("The entities that describe the domain.")]
    [Description("The collection of entities and their relationships with each other.")]
    [AdditionalProperties(false)]
    public IReadOnlyList<Entity> Entities { get; internal set; } = new List<Entity>();

    public Entity GetEntityByName(string entityName)
    {
        lock (this)
        {
            if (_entitiesByName == null)
            {
                _entitiesByName = new();
                for (int i = 0; i < Entities.Count; i++)
                {
                    _entitiesByName.Add(Entities[i].Name, Entities[i]);
                }
            }
        }
        return _entitiesByName[entityName];
    }

    [YamlIgnore]
    private Dictionary<string, Entity>? _entitiesByName;
}