using Json.Schema.Generation;
using System.Collections.Generic;

namespace Nox.Solution
{

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
        
    }
}