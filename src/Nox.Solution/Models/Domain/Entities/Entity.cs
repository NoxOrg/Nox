using Humanizer;
using Nox.Solution.Events;
using Nox.Solution.Extensions;
using Nox.Types;
using Nox.Types.Extensions;
using Nox.Yaml;
using Nox.Yaml.Attributes;
using Nox.Yaml.Validation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using YamlDotNet.Serialization;
using System.Collections.Immutable;

namespace Nox.Solution;

[GenerateJsonSchema]
[Title("Defines an entity or aggregate root")]
[Description("The declaration of an entity, its attributes, commands and queries. See https://noxorg.dev for more.")]
[AdditionalProperties(false)]
[DebuggerDisplay("{Name}, plural: {PluralName}")]
public class Entity : YamlConfigNode<NoxSolution, Domain>
{
    [Required]
    [Title("The name of the entity. Contains no spaces.")]
    [Description("The name of the abstract or real-world entity. It should be a commonly used singular noun and be unique within a solution.")]
    [Pattern(Nox.Yaml.Constants.StringWithNoSpacesRegex)]
    public string Name { get; internal set; } = null!;

    [Title("A phrase describing the entity.")]
    [Description("A description of the entity and what it represents in the real world.")]
    public string? Description { get; internal set; }

    [Title("The plural name of the entity. Contains no spaces")]
    [Description("The name for a set, group or collection of the entity. NOX will guess the plural if it is not supplied.")]
    [Pattern(Nox.Yaml.Constants.StringWithNoSpacesRegex)]
    public string PluralName { get; internal set; } = null!;

    public EntityUserInterface? UserInterface { get; internal set; }

    public EntityPersistence Persistence { get; internal set; } = new();

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
    public IReadOnlyList<DomainQuery> Queries { get; internal set; } = Array.Empty<DomainQuery>();

    [Title("Domain commands for this entity.")]
    [Description("Define one or more domain command(s) that operate on this entity. Commands may have side effects and mutate the domain state.")]
    [AdditionalProperties(false)]
    public IReadOnlyList<DomainCommand> Commands { get; internal set; } = Array.Empty<DomainCommand>();

    [Title("Domain events for this entity.")]
    [Description("Define one or more event(s) that may be raised when state change occurs on this entity.")]
    [AdditionalProperties(false)]
    public IReadOnlyList<DomainEvent> Events { get; internal set; } = Array.Empty<DomainEvent>();

    [Title("Keys for this entity.")]
    [Description("Define one or more keys for this entity.")]
    [AdditionalProperties(false)]
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
        (Persistence.Create.RaiseDomainEvents || Persistence.Update.RaiseDomainEvents || Persistence.Delete.RaiseDomainEvents);

    [YamlIgnore]
    public bool HasIntegrationEvents =>
        (Persistence.Create.RaiseIntegrationEvents || Persistence.Update.RaiseIntegrationEvents || Persistence.Delete.RaiseIntegrationEvents);

    [YamlIgnore]
    public bool HasCompositeKey => Keys.Count > 1;

    [YamlIgnore]
    public bool IsLocalized 
        => !HasCompositeKey && Attributes.Any(x => x.IsLocalized);

    [YamlIgnore]
    public bool HasLocalizedOwnedRelationships
        => OwnedRelationships.Any(x => x.Related.Entity.IsLocalized);


    public override void Initialize(NoxSolution topNode, Domain parentNode, string yamlPath)
    {
        InitializeAttributesByName();
        InitializeKeyByName();
        InitializeRelationshipPropertyNames();
    }

    private Dictionary<string, NoxSimpleTypeDefinition>? _keysByName;

    private void InitializeKeyByName()
    {
        _keysByName = Keys.ToDictionary(k => k.Name, k => k);
    }

    private Dictionary<string, NoxSimpleTypeDefinition>? _attributesByName;

    private void InitializeAttributesByName()
    {
        _attributesByName = Attributes.ToDictionary(a => a.Name, a => a);
    }

    private Dictionary<EntityRelationship, string>? _relationshipNavigationPropertyName;

    private void InitializeRelationshipPropertyNames()
    {
        _relationshipNavigationPropertyName = new();

        var allRelationships = AllRelationships.ToList();

        foreach (var rel in allRelationships)
        {
            string name;
            if (allRelationships.Count(r => r.Entity == rel.Entity) == 1)
                name = rel.WithSingleEntity()
                    ? rel.Entity
                    : rel.EntityPlural;
            else
                name = rel.Name;

            _relationshipNavigationPropertyName.Add(rel, name);
        }
    }

    public override void SetDefaults(NoxSolution topNode, Domain parentNode, string yamlPath)
    {
        PluralName ??= Name.Pluralize();

        foreach (var key in Keys) key.IsRequired = true;

        SetDefaultOtherEntityOnRelationships(parentNode);
        SetDefaultOtherEntityOnOwnedRelationships(parentNode);
    }

    public void SetDefaultOtherEntityOnRelationships(Domain parentNode)
    {
        var relationships = Relationships
            .GroupBy(r => parentNode.GetEntityByName(r.Entity))
            .Where(g => g.Key is not null);

        foreach (var grouping in relationships)
        {
            var otherEntity = grouping.Key;
            var relatedRelationships = otherEntity.Relationships.Where(r => r.Entity.Equals(Name)).ToList();
            var count = Math.Min(grouping.Count(), relatedRelationships.Count);
            for (var i = 0; i < count; i++)
            {
                var relationship = grouping.ElementAt(i);
                relationship.Related.Entity = otherEntity;
                relationship.Related.EntityRelationship = relatedRelationships[i];
            }
        }
    }

    public void SetDefaultOtherEntityOnOwnedRelationships(Domain parentNode)
    {
        OwnedRelationships
        .ToList()
        .ForEach(
            r => r.Related.Entity = parentNode.GetEntityByName(r.Entity)
        );
    }

    public override ValidationResult Validate(NoxSolution topNode, Domain parentNode, string yamlPath)
    {
        var result = base.Validate(topNode, parentNode, yamlPath);

        ValidateThatMemberNamesAreNotDuplicated(result, topNode);
        ValidateThatKeysExistWhenNeeded(result);
        ValidateThatKeysAreAppropriateType(result);
        ValidateThatNuidMembersReferToExistingAttributes(result);
        ValidateOtherEntityOnAllRelationships(result);
        ValidateThatOwnedEntitiesHaveOneParent(result, parentNode);
        ValidateThatOwnedEntitiesAreNotAuditable(result);
        ValidateThatOwnedEntitiesHaveNoRelationships(result);
        ValidateThatOwnedEntitiesDontHaveAttributeNamesWithOwnerEntityKeyNames(result);
        ValidateThatAllOwnerEntitiesHaveSimpleKeys(result);
        ValidateThatAllRelatedEntitiesHaveSimpleKeys(result);
        ValidateUniqueAttributeConstraints(result);
        ValidateThatReferenceNumberPrefix(result);

        return result;
    }

    #region Validation Methods
    private void ValidateThatReferenceNumberPrefix(ValidationResult result)
    {
        var attributesWithInvalidOptions = KeysAndAttributes
            .Where(n => n.Type == NoxType.ReferenceNumber)
            .Where(n => string.IsNullOrEmpty(n.ReferenceNumberTypeOptions?.Prefix) || n.ReferenceNumberTypeOptions?.Prefix.Length > 10);

        foreach (var invalid in attributesWithInvalidOptions)
        {
            result.Errors.Add(new ValidationFailure(invalid.Name, $"ReferenceNumber [{invalid.Name}] on entity [{Name}] Prefix invalid. Prefix is required with a max length of 10."));
        }
    }
    private void ValidateThatMemberNamesAreNotDuplicated(ValidationResult result, NoxSolution topNode)
    {
        // Check that all names are unique
        var entityName = (new string[] { Name })
            .Select(s => new { Name, MemberType = EntityMemberType.Entity });

        var names = entityName
            .Concat(Keys.Select(a => new { a.Name, MemberType = EntityMemberType.Key }))
            .Concat(Attributes.Select(r => new { r.Name, MemberType = EntityMemberType.Attribute }))
            .Concat(Relationships.Select(r => new { r.Name, MemberType = EntityMemberType.Relationship }))
            .Concat(OwnedRelationships.Select(r => new { r.Name, MemberType = EntityMemberType.OwnedRelationship }))
            .Concat(Queries.Select(q => new { q.Name, MemberType = EntityMemberType.Query }))
            .Concat(Commands.Select(c => new { c.Name, MemberType = EntityMemberType.Command }))
            .Concat(Events.Select(e => new { e.Name, MemberType = EntityMemberType.DomainEvent }))
            .Concat(UniqueAttributeConstraints.Select(u => new { u.Name, MemberType = EntityMemberType.UniqueConstraint }));

        if (topNode.Application is not null)
        {
            names = names.Concat(topNode.Application.IntegrationEvents.Select(e => new { e.Name, MemberType = EntityMemberType.IntegrationEvent }));
        }

        var messages = names
            .GroupBy(a => a.Name)
            .Where(g => g.Count() > 1)
            .Select(g => $"Duplicate name [{g.Key}] on entity [{Name}] found in [{string.Join(",", g.Select(a => a.MemberType.ToString()).ToArray())}]");

        foreach (var message in messages)
        {
            result.Errors.Add(new ValidationFailure(nameof(Name), message));
        }
    }

    private void ValidateThatKeysExistWhenNeeded(ValidationResult result)
    {
        if (!IsOwnedEntity)
        {
            if (Keys.Count() == 0)
                result.Errors.Add(new ValidationFailure(nameof(Keys), $"Keys are mandatory for entity [{Name}]."));

            return;
        }

        // Owned entities
        var ownerRelationships = OwnerEntity!.OwnedRelationships.Where(r => r.Entity.Equals(Name));

        if (ownerRelationships.Count() > 1)
        {
            result.Errors.Add(new ValidationFailure(nameof(Keys), $"Multiple ownerships of entity [{Name}] exists on entity [{OwnerEntity!.Name}]."));
            return;
        }

        var ownerRelationship = ownerRelationships.First();

        if (ownerRelationship.Relationship is EntityRelationshipType.ZeroOrMany or EntityRelationshipType.OneOrMany)
        {
            if (Keys.Count() == 0)
                result.Errors.Add(new ValidationFailure(nameof(Keys), $"Keys are mandatory for owned entity [{Name}] with ZeroOrMany/OneOrMany relationship from [{OwnerEntity!.Name}]."));

        }

        else if (ownerRelationship.Relationship is EntityRelationshipType.ZeroOrOne or EntityRelationshipType.ExactlyOne)
        {
            if (Keys.Count() > 0)
                result.Errors.Add(new ValidationFailure(nameof(Keys), $"Keys are invalid for owned entity [{Name}] with ZeroOrOne/ExactlyOne relationship from [{OwnerEntity!.Name}]."));

        }
    }

    private void ValidateThatKeysAreAppropriateType(ValidationResult result)
    {
        foreach (var key in Keys)
        {
            if (key.Type != NoxType.EntityId && key.Type.IsCompoundType())
            {
                result.Errors.Add(new ValidationFailure(key.Name, $"Key [{key.Name}] on entity [{Name}] can not be a compound type."));
            }
        }
    }

    private void ValidateThatNuidMembersReferToExistingAttributes(ValidationResult result)
    {
        var nuids = KeysAndAttributes
            .Where(n => n.Type == NoxType.Nuid)
            .Where(n => n.NuidTypeOptions?.PropertyNames is not null)
            .SelectMany(n => n.NuidTypeOptions!.PropertyNames, (n, s) => new { NuidName = n.Name, AttributeName = s });

        var keyAndAttrNames = KeysAndAttributes
            .Where(n => n.Type != NoxType.Nuid)
            .Select(n => n.Name)
            .ToImmutableHashSet(StringComparer.OrdinalIgnoreCase);

        foreach (var o in nuids)
        {
            if (!keyAndAttrNames.Contains(o.AttributeName))
            {
                result.Errors.Add(
                    new ValidationFailure(o.AttributeName, $"Nuid [{o.NuidName}] on entity [{Name}] refers to [{o.AttributeName}] that does not exist as a key or attribute.")
                );
            }
        }
    }

    private void ValidateOtherEntityOnAllRelationships(ValidationResult result)
    {
        // For all relationships, owned and normal
        // this should be caught by schema validation and probably redundant, i.e. can't occur
        foreach (var rel in AllRelationships.Where(r => r.Related.Entity is null))
        {
            result.Errors.Add(
                new ValidationFailure(rel.Name, $"Relationship [{rel.Name}] on entity [{Name}] refers to related entity [{rel.Entity}] that does not exist.")
            );
        }

        // Only for non-owning relationships
        // This could happen, espicially if all reverse relationships don't exist
        foreach (var rel in Relationships.Where(r => r.Related.EntityRelationship is null))
        {
            result.Errors.Add(
                new ValidationFailure(rel.Name, $"Relationship [{rel.Name}] on entity [{Name}] does not have a corresponding reverse relationship on entity [{rel.Entity}].")
            );
        }
    }

    private void ValidateThatOwnedEntitiesHaveOneParent(ValidationResult result, Domain parentNode)
    {
        if (!IsOwnedEntity) return;

        var owningEntities = parentNode
            .Entities
            .SelectMany(e => e.AllRelationships, (e, r) => new { e.Name, r.Entity })
            .Where(o => o.Entity.Equals(Name))
            .Select(o => o.Name);

        if (owningEntities.Count() == 1) return;

        result.Errors.Add(
            new ValidationFailure(Name, $"Entity [{Name}] owned multiple times or by multiple entities [{string.Join(",", owningEntities)}].")
        );
    }

    private void ValidateThatOwnedEntitiesAreNotAuditable(ValidationResult result)
    {
        if (!IsOwnedEntity || !Persistence.IsAudited) return;

        result.Errors.Add(
            new ValidationFailure(Name, $"Entity [{Name}] is owned and can't therefore be auditable. [Persistence.IsAudited=true]")
        );
    }

    private void ValidateThatOwnedEntitiesHaveNoRelationships(ValidationResult result)
    {
        if (!IsOwnedEntity) return;

        if (Relationships.Count() == 0) return;

        result.Errors.Add(
            new ValidationFailure(nameof(Relationships), $"Entity [{Name}] is owned and can't have relationships.")
        );
    }

    private void ValidateThatOwnedEntitiesDontHaveAttributeNamesWithOwnerEntityKeyNames(ValidationResult result)
    {
        if (!IsOwnedEntity) return;
        if (OwnerEntity!.OwnedRelationships.All(rel => rel.Entity == Name && rel.WithMultiEntity)) return;

        var ownerEntityKeys = OwnerEntity!.Keys.Select(key => key.Name);
        var attributeNames = Attributes!.Where(attr => ownerEntityKeys!.Contains(attr.Name)).Select(attr => attr.Name);

        foreach (var attrName in attributeNames)
        {
            result.Errors.Add(
                new ValidationFailure(attrName, $"Attribute [{attrName}] on owned entity [{Name}] has conflicting name with owner entity [{OwnerEntity.Name}] key."));
        }
    }

    private void ValidateThatAllOwnerEntitiesHaveSimpleKeys(ValidationResult result)
    {
        if (OwnedRelationships.Any() && HasCompositeKey)
        {
            result.Errors.Add(
                new ValidationFailure(Name, $"Entity [{Name}] is an owner entity and can't have composite key.")
            );
        }
    }

    private void ValidateThatAllRelatedEntitiesHaveSimpleKeys(ValidationResult result)
    {
        // this should be caught by schema validation and probably redundant, i.e. can't occur
        foreach (var rel in AllRelationships
            .Where(r => r.Related.Entity is not null && r.Related.Entity.HasCompositeKey))
        {
            result.Errors.Add(
                new ValidationFailure(rel.Name, $"Relationship [{rel.Name}] on entity [{Name}] refers to related entity [{rel.Entity}] with composite key. Must be simple key on {rel.Entity}.")
            );
        }

    }

    private void ValidateUniqueAttributeConstraints(ValidationResult result)
    {
        var memberNames = Attributes.Select(m => m.Name).ToImmutableHashSet();
        var relationshipNames = Relationships.Select(r => r.Name).ToImmutableHashSet();

        // Validate that referenced attributes exist
        var messages = UniqueAttributeConstraints
            .SelectMany(c => c.AttributeNames, (c, a) => new { c.Name, AttributeName = a })
            .Where(o => !memberNames.Contains(o.AttributeName))
            .Select(o => $"Unique constraint [{o.Name}] refers to non-existing attribute [{o.AttributeName}] on entity [{Name}]");

        foreach (var message in messages)
        {
            result.Errors.Add(new ValidationFailure(nameof(Name), message));
        }

        // Validate that there are no duplicate unique constraints in entity
        var messages2 = UniqueAttributeConstraints
            .Select(c => new { c.Name, Keys = string.Join(",", c.AttributeNames.Concat(c.RelationshipNames).OrderBy(e => e)) })
            .GroupBy(o => o.Keys)
            .Where(g => g.Count() > 1)
            .Select(g => $"Unique constraints [{string.Join(",", g.Select(g => g.Name))}] refers to non-unique keys [{g.Key}] on entity [{Name}]");

        foreach (var message in messages2)
        {
            result.Errors.Add(new ValidationFailure(nameof(Name), message));
        }

        // Validate that referenced relationships exist
        var messages3 = UniqueAttributeConstraints
            .SelectMany(c => c.RelationshipNames, (c, r) => new { c.Name, RelationshipName = r })
            .Where(o => !relationshipNames.Contains(o.RelationshipName))
            .Select(o => $"Unique constraint [{o.Name}] refers to non-existing relationship [{o.RelationshipName}] on entity [{Name}]");

        foreach (var message in messages3)
        {
            result.Errors.Add(new ValidationFailure(nameof(Name), message));
        }

        // Validates that only zero/one to many relationships are used
        var messages4 = UniqueAttributeConstraints
            .SelectMany(c =>
                c.RelationshipNames
                    .Where(relationshipName =>
                        Relationships.Any(relationship =>
                            relationship.Name == relationshipName
                            && !(relationship.WithSingleEntity && relationship.Related.EntityRelationship.WithMultiEntity()))
                    )
                    .Select(relationshipName => new { ConstraintName = c.Name, RelationshipName = relationshipName })
                )
            .Select(o => $"Unique constraint [{o.ConstraintName}] refers to a relationship [{o.RelationshipName}] which isn't zero/one to many from single side");

        foreach (var message in messages4)
        {
            result.Errors.Add(new ValidationFailure(nameof(Name), message));
        }

        // Validate that attribute names are unique within constraint
        var messages5 = UniqueAttributeConstraints
            .SelectMany(constraint => constraint.AttributeNames
                .GroupBy(name => name)
                .Where(group => group.Count() > 1)
                .Select(group => $"Unique constraint [{constraint.Name}] has duplicate attribute name: [{group.Key}]"));

        foreach (var message in messages5)
        {
            result.Errors.Add(new ValidationFailure(nameof(Name), message));
        }

        // Validate that relationship names are unique within constraint
        var messages6 = UniqueAttributeConstraints
            .SelectMany(constraint => constraint.RelationshipNames
                .GroupBy(name => name)
                .Where(group => group.Count() > 1)
                .Select(group => $"Unique constraint [{constraint.Name}] has duplicate relationship name: [{group.Key}]"));

        foreach (var message in messages6)
        {
            result.Errors.Add(new ValidationFailure(nameof(Name), message));
        }
    }
    #endregion

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

    [YamlIgnore]
    public IEnumerable<NoxSimpleTypeDefinition> KeysAndAttributes => Keys.Concat(Attributes);

    [YamlIgnore]
    public IEnumerable<EntityRelationship> AllRelationships => Relationships.Concat(OwnedRelationships);

    public IEnumerable<KeyValuePair<EntityMemberType, NoxSimpleTypeDefinition>> GetAllMembers()
    {
        foreach (var key in Keys!)
        {
            yield return new(EntityMemberType.Key, key);
        }

        foreach (var attribute in Attributes)
        {
            yield return new(EntityMemberType.Attribute, attribute);
        }

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

    /// <summary>
    /// Get the Navigation property name for a relationship
    /// Considers ToSingle and to ToMany relationships
    /// Considers the case where there are multiple relationships to the same entity
    /// </summary>
    /// <param name="relationship"></param>
    /// <returns></returns>
    public virtual string GetNavigationPropertyName(EntityRelationship relationship)
    {
        return _relationshipNavigationPropertyName![relationship];
    }


    private static NoxSimpleTypeDefinition CreateForeignKeyDefinition(string foreignKeyName,
        EntityRelationship relationship)
    {
        var foreignKey = new NoxSimpleTypeDefinition()
        {
            Name = foreignKeyName,
            Description = $"A unique identifier for a {relationship.Related.Entity!.Name}.",
            Type = Types.NoxType.AutoNumber,
            IsRequired = true,
            IsReadonly = true,
        };
        return foreignKey;
    }

    public Entity ShallowCopy(string? newName = null)
    {
        var copy = (Entity)MemberwiseClone();

        if (!string.IsNullOrWhiteSpace(newName))
        {
            copy.Name = newName!;
        }

        return copy;
    }


}