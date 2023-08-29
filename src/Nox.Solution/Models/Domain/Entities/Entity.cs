using Humanizer;
using Nox.Solution.Events;
using Nox.Types;
using Nox.Types.Schema;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using YamlDotNet.Serialization;

namespace Nox.Solution;

[GenerateJsonSchema]
[Title("Defines an entity or aggregate root")]
[Description("The declaration of an entity, its attributes, commands and queries. See https://noxorg.dev for more.")]
[AdditionalProperties(false)]
[DebuggerDisplay("{Name}, plural: {PluralName}")]
public class Entity : DefinitionBase
{
    [YamlIgnore]
    private ConcurrentDictionary<string, NoxSimpleTypeDefinition>? _attributesByName;

    [YamlIgnore]
    private ConcurrentDictionary<string, NoxSimpleTypeDefinition>? _keysByName;

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
    public IReadOnlyList<NoxSimpleTypeDefinition> Keys { get; internal set; } = Array.Empty<NoxSimpleTypeDefinition>(); 

    [Title("Attributes that describe this entity.")]
    [Description("Define one or more attribute(s) that describes the composition of this domain entity.")]
    [AdditionalProperties(false)]
    public virtual IReadOnlyList<NoxSimpleTypeDefinition>? Attributes { get; internal set; }

    [YamlIgnore]
    public bool IsOwnedEntity { get; set; }

    internal bool ApplyDefaults()
    {
        if (string.IsNullOrWhiteSpace(PluralName))
            PluralName = Name.Pluralize();

        if (Persistence != null)
            return true;

        Persistence = new EntityPersistence();

        return Persistence.ApplyDefaults(Name);
    }

    public virtual NoxSimpleTypeDefinition? GetAttributeByName(string entityName)
    {
        EnsureAttributesByName();
        return _attributesByName![entityName];
    }

    public virtual bool TryGetAttributeByName(string entityName, out NoxSimpleTypeDefinition? result)
    {
        EnsureAttributesByName();
        return _attributesByName!.TryGetValue(entityName, out result);
    }

    public virtual bool TryGetKeyByName(string entityName, out NoxSimpleTypeDefinition? result)
    {
        EnsureKeyByName();
        return _keysByName!.TryGetValue(entityName, out result);
    }

    public virtual bool IsKey(string keyName)
    {
        EnsureKeyByName();
        return _keysByName!.ContainsKey(keyName);
    }

    public virtual bool TryGetRelationshipByName(NoxSolution solution, string relationshipName, out NoxSimpleTypeDefinition? result)
    {
        result = null;
        if (Relationships == null)
        {
            return false;
        }
        var rel = Relationships!.First(x => x.Name.Equals(relationshipName));
        if (!rel.ShouldGenerateForeignOnThisSide ||
            (rel.Relationship == EntityRelationshipType.ZeroOrMany ||
             rel.Relationship == EntityRelationshipType.OneOrMany))
        {
            return false;
        }

        var foreignEntityKeyDefinition = rel.Related.Entity.Keys![0].ShallowCopy();
        foreignEntityKeyDefinition.Name = rel.Related.Entity.Name + "Id";
        foreignEntityKeyDefinition.Description = "-";
        foreignEntityKeyDefinition.IsRequired = false;
        foreignEntityKeyDefinition.IsReadonly = false;

        result = foreignEntityKeyDefinition;
        return true;
    }

    public IEnumerable<KeyValuePair<EntityMemberType, NoxSimpleTypeDefinition>> GetAllMembers()
    {
        foreach (var key in Keys!)
        {
            yield return new(EntityMemberType.Key, key);
        }

        if (Attributes is not null)
        {
            foreach (var attribute in Attributes)
            {
                yield return new(EntityMemberType.Attribute, attribute);
            }
        }

        if (OwnedRelationships is not null)
        {
            foreach (var relationship in OwnedRelationships)
            {
                NoxSimpleTypeDefinition foreignKeyDefinition;

                if (relationship.Related.Entity?.Keys is null)
                {
                    string foreignKeyName;
                    if (relationship.Relationship is EntityRelationshipType.OneOrMany or EntityRelationshipType.ZeroOrMany)
                    {
                        foreignKeyName = $"{relationship.Related.Entity!.PluralName}";
                    }
                    else
                    {
                        foreignKeyName = $"{relationship.Related.Entity!.Name}Id";
                    }
                    foreignKeyDefinition = CreateForeignKeyDefinition(foreignKeyName, relationship);
                    yield return new(EntityMemberType.OwnedRelationship, foreignKeyDefinition);
                }
                else
                {
                    foreach (var key in relationship.Related.Entity.Keys)
                    {
                        foreignKeyDefinition = key.ShallowCopy();
                        foreignKeyDefinition.Name = $"{relationship.Entity}{key.Name}";
                        yield return new(EntityMemberType.OwnedRelationship, foreignKeyDefinition);
                    }
                }
            }
        }

        if (Relationships is not null)
        {
            var relationships = Relationships
                .Where(x => x.Related.Entity?.Keys is not null)
                .Select(x => (x.Entity, Keys: x.Related.Entity.Keys!));

            foreach (var relationship in relationships)
            {
                foreach (var key in relationship.Keys)
                {
                    var foreignKey = key.ShallowCopy();
                    foreignKey.Name = $"{relationship.Entity}{key.Name}";
                    yield return new(EntityMemberType.Relationship, foreignKey);
                }
            }
        }
    }

    public IEnumerable<KeyValuePair<EntityMemberType, EntityRelationship>> GetAllRelationships()
    {
        if (OwnedRelationships is not null)
        {
            foreach (var relationship in OwnedRelationships)
            {
                yield return new(EntityMemberType.OwnedRelationship, relationship);
            }
        }

        if (Relationships is not null)
        {
            foreach (var relationship in Relationships)
            {
                yield return new(EntityMemberType.Relationship, relationship);
            }
        }
    }

    private readonly object _lockEnsureByKeyObject = new object();
    private void EnsureKeyByName()
    {
        if (_keysByName is not null)
            return;

        lock (_lockEnsureByKeyObject)
        {
            if (_keysByName is null)
            {
                _keysByName = new();
                for (int i = 0; i < Keys!.Count; i++)
                {
                    _keysByName.TryAdd(Keys[i].Name, Keys[i]);
                }
            }
        }
    }
    private void EnsureAttributesByName()
    {
        if (_attributesByName is not null)
            return;

        lock (_lockEnsureByKeyObject)
        {
            if (_attributesByName is null)
            {
                _attributesByName = new();
                for (int i = 0; i < Attributes!.Count; i++)
                {
                    _attributesByName.TryAdd(Attributes[i].Name, Attributes[i]);
                }
            }
        }
    }

    private static NoxSimpleTypeDefinition CreateForeignKeyDefinition(string foreignKeyName,
        EntityRelationship relationship)
    {
        var foreignKey = new NoxSimpleTypeDefinition()
        {
            Name = foreignKeyName,
            Description = $"A unique identifier for a {relationship.Related.Entity!.Name}.",
            Type = Types.NoxType.DatabaseNumber,
            IsRequired = true,
            IsReadonly = true,
        };
        return foreignKey;
    }
}