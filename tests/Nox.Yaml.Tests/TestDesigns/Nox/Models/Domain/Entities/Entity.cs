﻿using Humanizer;
using Nox.Yaml.Attributes;
using Nox.Yaml.Tests.TestDesigns.Nox.Enums;
using Nox.Yaml.Tests.TestDesigns.Nox.Extensions;
using Nox.Yaml.Tests.TestDesigns.Nox.Types.Enums;
using Nox.Yaml.Tests.TestDesigns.Nox.Types.TypeDefinitions;
using System.Collections.Concurrent;
using System.Diagnostics;
using YamlDotNet.Serialization;

namespace Nox.Yaml.Tests.TestDesigns.Nox.Models;

[GenerateJsonSchema]
[Title("Defines an entity or aggregate root")]
[Description("The declaration of an entity, its attributes, commands and queries. See https://noxorg.dev for more.")]
[AdditionalProperties(false)]
[DebuggerDisplay("{Name}, plural: {PluralName}")]
public class Entity : YamlConfigNode<NoxSolution,Domain>
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
    public string PluralName { get; internal set; } = default!;

    public EntityUserInterface? UserInterface { get; internal set; }

    public EntityPersistence? Persistence { get; internal set; }

    [Title("Defines relationships to other entities.")]
    [Description("Defines one way relationships to other entities. Remember to define the reverse relationship on the target entities.")]
    [AdditionalProperties(false)]
    public IReadOnlyList<EntityRelationship> Relationships { get; internal set; } = Array.Empty<EntityRelationship>();

    [Title("Defines owned relationships to another entity.")]
    [Description("Defines relationship to owned entities. This entity will be treated as an aggregate root.")]
    [AdditionalProperties(false)]
    public IReadOnlyList<EntityRelationship> OwnedRelationships { get; internal set; } = Array.Empty<EntityRelationship>();

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
    [UniqueItemProperties(nameof(DomainEvent.Name))]
    public IReadOnlyList<DomainEvent>? Events { get; internal set; }

    [Title("Keys for this entity.")]
    [Description("Define one or more keys for this entity.")]
    public IReadOnlyList<NoxSimpleTypeDefinition> Keys { get; internal set; } = Array.Empty<NoxSimpleTypeDefinition>();

    [Title("Attributes that describe this entity.")]
    [Description("Define one or more attribute(s) that describes the composition of this domain entity.")]
    [AdditionalProperties(false)]
    public virtual IReadOnlyList<NoxSimpleTypeDefinition> Attributes { get; internal set; } = Array.Empty<NoxSimpleTypeDefinition>();

    [Title("Unique constraints for this entity.")]
    [Description("Define one or more unique constraints for this entity.")]
    [AdditionalProperties(false)]
    public IReadOnlyList<UniqueAttributeConstraint> UniqueAttributeConstraints { get; internal set; } = Array.Empty<UniqueAttributeConstraint>();

    [YamlIgnore]
    public bool IsOwnedEntity { get; internal set; }

    [YamlIgnore]
    public Entity? OwnerEntity { get; internal set; }

    [YamlIgnore]
    public bool HasDomainEvents =>
        Persistence is not null &&
        (Persistence!.Create.RaiseDomainEvents || Persistence.Update.RaiseDomainEvents || Persistence.Delete.RaiseDomainEvents);

    [YamlIgnore]
    public bool HasIntegrationEvents =>
        Persistence is not null &&
        (Persistence.Create.RaiseIntegrationEvents || Persistence.Update.RaiseIntegrationEvents || Persistence.Delete.RaiseIntegrationEvents);

    [YamlIgnore]
    public bool HasCompositeKey => Keys.Count > 1;

    [YamlIgnore]
    public bool IsLocalized =>
        !HasCompositeKey &&
        !IsOwnedEntity &&
        this.GetAttributesToLocalize().Any();

    public Entity ShallowCopy(string? newName = null)
    {
        var copy = (Entity)MemberwiseClone();

        if (!string.IsNullOrWhiteSpace(newName))
        {
            copy.Name = newName!;
        }

        return copy;
    }

    public override void Initialize(NoxSolution topNode, Domain parent, string yamlPath)
    {
        EnsureAttributesByName();
        EnsureKeyByName();
    }

    public override void SetDefaults(NoxSolution topNode, Domain parent, string yamlPath)
    {
        PluralName ??= Name.Pluralize();

        Persistence ??= new EntityPersistence();
    }

    public virtual NoxSimpleTypeDefinition? GetAttributeByName(string entityName)
    {
        return _attributesByName![entityName];
    }

    public virtual bool TryGetAttributeByName(string entityName, out NoxSimpleTypeDefinition? result)
    {
        return _attributesByName!.TryGetValue(entityName, out result);
    }

    public virtual bool TryGetKeyByName(string entityName, out NoxSimpleTypeDefinition? result)
    {
        return _keysByName!.TryGetValue(entityName, out result);
    }

    public virtual bool IsKey(string keyName)
    {
        return _keysByName!.ContainsKey(keyName);
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
                .Where(x => x.Related.EntityRelationship.WithMultiEntity)
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

    private void EnsureKeyByName()
    {
        if (_keysByName is not null)
            return;

        _keysByName = new();
        for (int i = 0; i < Keys!.Count; i++)
        {
            _keysByName.TryAdd(Keys[i].Name, Keys[i]);
        }
    }

    private void EnsureAttributesByName()
    {
        if (_attributesByName is not null)
            return;

        _attributesByName = new();
        for (int i = 0; i < Attributes!.Count; i++)
        {
            _attributesByName.TryAdd(Attributes[i].Name, Attributes[i]);
        }
    }

    private static NoxSimpleTypeDefinition CreateForeignKeyDefinition(string foreignKeyName,
        EntityRelationship relationship)
    {
        var foreignKey = new NoxSimpleTypeDefinition()
        {
            Name = foreignKeyName,
            Description = $"A unique identifier for a {relationship.Related.Entity!.Name}.",
            Type = NoxType.AutoNumber,
            IsRequired = true,
            IsReadonly = true,
        };
        return foreignKey;
    }
}