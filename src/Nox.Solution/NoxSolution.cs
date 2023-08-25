using FluentValidation;
using Nox.Solution.Validation;
using Nox.Types;
using Nox.Types.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace Nox.Solution;

public class NoxSolution : Solution
{
    public string? RootYamlFile { get; internal set; }
    private HashSet<string>? _ownedEntitiesNames { get; set; }

    internal void Validate()
    {
        var validator = new SolutionValidator();
        validator.ValidateAndThrow(this);
    }

    public List<EntityRelationshipWithType> GetRelationshipsToCreate(
        NoxSolutionCodeGeneratorState codeGeneratorState,
        Entity entity)
    {
        var fullRelationshipModels = new List<EntityRelationshipWithType>();

        if (entity?.Relationships != null)
        {
            foreach (var relationship in entity.Relationships)
            {
                fullRelationshipModels.Add(new EntityRelationshipWithType
                {
                    Relationship = relationship,
                    RelationshipEntityType = codeGeneratorState.GetEntityType(relationship.Entity)!
                });
            }
        }

        return fullRelationshipModels;
    }

    public List<EntityRelationshipWithType> GetOwnedRelationshipsToCreate(
        NoxSolutionCodeGeneratorState codeGeneratorState,
        Entity entity)
    {
        var fullRelationshipModels = new List<EntityRelationshipWithType>();

        if (entity?.OwnedRelationships != null)
        {
            foreach (var relationship in entity.OwnedRelationships)
            {
                fullRelationshipModels.Add(new EntityRelationshipWithType
                {
                    Relationship = relationship,
                    RelationshipEntityType = codeGeneratorState.GetEntityType(relationship.Entity)!
                });
            }
        }

        return fullRelationshipModels;
    }

    internal bool IsOwnedEntity(Entity entity)
    {
        // Cannot rely on constructor in this scenario as
        // constructor execution during deserialization doesn't contain a Domain set
        if (_ownedEntitiesNames == null)
        {
            InitOwnedEntitiesList();
        }

        return _ownedEntitiesNames!.Contains(entity.Name);
    }

    private void InitOwnedEntitiesList()
    {
        if (Domain == null)
        {
            return;
        }

        var ownedEntities = Domain.Entities
            .Where(x => x?.OwnedRelationships != null)
            .SelectMany(x => x.OwnedRelationships!.Select(x => x.Entity));
        _ownedEntitiesNames = new HashSet<string>(ownedEntities);
    }

    /// <summary>
    /// Key Nox.Type for and Entity with single key . If NoxType is Entity again, then we recursively get the entity primary key type!
    /// </summary>
    /// <param name="entityName"></param>
    /// <returns></returns>
    public NoxType GetSingleKeyTypeForEntity(string entityName)
    {
        var entity = Domain!.Entities.Single(entity => entity.Name.Equals(entityName));

        return entity.Keys!.Single().Type;
    }

    /// <summary>
    /// Key Nox.Type for a key definition, If type is Entity again, then we recursively get the entity primary key type!
    /// </summary>
    /// <param name="keyDefinition"></param>
    /// <returns></returns>
    public NoxType GetSingleTypeForKey(NoxSimpleTypeDefinition keyDefinition)
    {
        if(keyDefinition.Type != NoxType.Entity)
        {
            return keyDefinition.Type;
        }
        // Obtain the reference entity
        var entity = Domain!.Entities.Single(entity => entity.Name.Equals(keyDefinition.EntityTypeOptions!.Entity));

        return GetSingleTypeForKey(entity.Keys![0]);
    }

    /// <summary>
    /// Key Primitive for a key definition, If type is Entity again, then we recursively get the entity primary key type!
    /// </summary>
    /// <param name="keyDefinition"></param>
    /// <returns></returns>
    public string GetSinglePrimitiveTypeForKey(NoxSimpleTypeDefinition keyDefinition)
    {
        if (keyDefinition.Type != NoxType.Entity)
        {
            return keyDefinition.Type.GetComponents(keyDefinition).Single().Value.ToString();
        }
        // Obtain the reference entity
        var entity = Domain!.Entities.Single(entity => entity.Name.Equals(keyDefinition.EntityTypeOptions!.Entity));

        return GetSinglePrimitiveTypeForKey(entity.Keys![0]);
    }


    /// <summary>
    /// Key Primitive type for and Entity with single key 
    /// </summary>
    /// <param name="entityName"></param>
    /// <returns></returns>
    public string GetSingleKeyPrimitiveTypeForEntity(string entityName)
    {
        var entity = Domain!.Entities.Single(entity => entity.Name.Equals(entityName));
        var key = entity.Keys!.Single();
        // Single, because keys cannot be compound type
        return key.Type.GetComponents(key).Single().Value.ToString();
    }
}