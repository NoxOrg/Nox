using Nox.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nox.Solution.Extensions;

public static class EntityExtensions
{
    public static Entity? TryGetParent(this Entity ownedEntity, IEnumerable<Entity> allEntities)
    {
        if (!ownedEntity.IsOwnedEntity) 
        {
            return null;
        }

        return allEntities.FirstOrDefault(e => 
            e.OwnedRelationships?.Any(o => o.Entity == ownedEntity.Name) == true);
    }

    public static bool TryGetRelationshipByName(this Entity entity, NoxSolution solution, string relationshipName, out NoxSimpleTypeDefinition? result)
    {
        result = null;
        if (entity.Relationships == null)
        {
            return false;
        }

        var rel = entity.Relationships!.First(x => x.Name.Equals(relationshipName));
        // TODO: possibly extend for other types
        if (!rel.ShouldGenerateForeignOnThisSide ||
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
}