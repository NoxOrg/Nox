using Json.Schema.Generation;
using System.Collections.Generic;
using Humanizer;
using Nox.Solution.Events;

namespace Nox.Solution
{
    [Title("Defines an entity or aggregate root")]
    [Description("The declaration of an entity, its attributes, commands and queries. See https://noxorg.dev for more.")]
    [AdditionalProperties(false)]
    public class Entity : DefinitionBase
    {
        [Required]
        [Title("The name of the entity. Contains no spaces.")]
        [Description("The name of the abstract or real-world entity. It should be a commonly used singular noun and be unique within a solution.")]
        [Pattern(@"^[^\s]*$")]
        public string Name { get; internal set; } = null!;

        [Title("A phrase describing the entity.")]
        [Description("A description of the entity and what it represents in the real world.")]
        public string? Description { get; internal set; }

        [Title("The plural name of the entity. Contains no spaces")]
        [Description("The name for a set, group or collection of the entity. NOX will guess the plural if it is not supplied.")]
        [Pattern(@"^[^\s]*$")]
        public string PluralName { get; internal set; } = string.Empty;

        public EntityUserInterface? UserInterface { get; internal set; }

        public EntityPersistence? Persistence { get; internal set; }

        [Title("Defines relationships to other entities.")]
        [Description("Defines one way relationships to other entities. Remember to define the reverse relationship on the target entities.")]
        [AdditionalProperties(false)]
        public IReadOnlyList<EntityRelationship>? Relationships { get; internal set; }

        [Title("Defines owned relationships to another entity.")]
        [Description("Defines relationship to owned entities. This entity will be treated as an aggregate root.")]
        [AdditionalProperties(false)]
        public IReadOnlyList<EntityRelationship>? OwnedRelationships { get; internal set; }

        [Title("Domain queries for this entity.")]
        [Description("Define one or more domain querie(s) that operate on this entity. Queries should have no side effects and not mutate the domain state.")]
        [AdditionalProperties(false)]
        public IReadOnlyList<DomainQuery>? Queries { get; internal set; }

        [Title("Domain commands for this entity.")]
        [Description("Define one or more domain command(s) that operate on this entity. Commands may have side effects and mutate the domain state.")]
        [AdditionalProperties(false)]
        public IReadOnlyList<DomainCommand>? Commands { get; internal set; }

        [Title("Domain events for this entity.")]
        [Description("Define one or more event(s) that may be raised when state change occurs on this entity.")]
        [AdditionalProperties(false)]
        public IReadOnlyList<DomainEvent>? Events { get; internal set; }

        [Title("Keys for this entity.")]
        [Description("Define one or more keys for this entity.")]
        public IReadOnlyList<NoxSimpleTypeDefinition>? Keys { get; internal set; }

        [Title("Attributes that describe this entity.")]
        [Description("Define one or more attribute(s) that describes the composition of this domain entity.")]
        [AdditionalProperties(false)]
        public IReadOnlyList<NoxSimpleTypeDefinition>? Attributes { get; internal set; }

        internal bool ApplyDefaults()
        {
            if (string.IsNullOrWhiteSpace(PluralName)) PluralName = Name.Pluralize();
            return true;
        }
    }
}