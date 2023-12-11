using Nox.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nox.Solution.Extensions;

public static class EntityExtensions
{

    public static bool TryGetRelationshipByName(this Entity entity, NoxSolution solution, string relationshipName, out NoxSimpleTypeDefinition? result)
    {
        result = null;
        if (entity.Relationships == null)
        {
            return false;
        }

        EntityRelationship rel = entity.Relationships!.Single(x => x.Name.Equals(relationshipName));
        // TODO: possibly extend for other types
        if (!EntityRelationshipExtensions.IsForeignKeyOnThisSide(rel) ||
            rel.WithMultiEntity)
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

    public static IEnumerable<KeyValuePair<EntityMemberType, EntityRelationship>> GetAllRelationships(this Entity entity)
    {
        if (entity.OwnedRelationships is not null)
        {
            foreach (var relationship in entity.OwnedRelationships)
            {
                yield return new(EntityMemberType.OwnedRelationship, relationship);
            }
        }

        if (entity.Relationships is not null)
        {
            foreach (var relationship in entity.Relationships)
            {
                yield return new(EntityMemberType.Relationship, relationship);
            }
        }
    }

    public static IEnumerable<NoxSimpleTypeDefinition> GetLocalizedAttributes(this Entity entity) => entity.Attributes.Where(x => x.IsLocalized);

    public static IReadOnlyList<NoxSimpleTypeDefinition> GetKeys(this Entity entity)
    {
        if (entity.IsOwnedEntity && entity.OwnerEntity!.OwnedRelationships.Any(rel => rel.Entity == entity.Name && rel.WithSingleEntity))
            return entity.OwnerEntity!.Keys
                .Select(key =>
                {
                    var newKey = key.ShallowCopy();
                    newKey.Name = entity.OwnerEntity.Name + key.Name;
                    return newKey;
                })
                .ToList();

        return entity.Keys;
    }

    public static bool RequiresCustomSqlStatement(this Entity entity)
        => entity.IsLocalized || entity.Attributes.Any(x => x.Type == NoxType.Enumeration);
}