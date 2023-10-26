using Nox.Types;
using Nox.Types.Extensions;
using System;
using System.Linq;

namespace Nox.Solution.Extensions;

public static class EntityRelationshipExtensions
{
    public static bool ShouldGenerateForeignKeyOnThisSide(this EntityRelationship relationship)
    {
        var generate = true;

        var pairRelationship = relationship.Related.EntityRelationship;
        if (pairRelationship != null)
        {
            // ManyToMany does not need to be handled as it doesn't have special logic
            // Will be always ignored by default
            if (relationship.Relationship == EntityRelationshipType.OneOrMany ||
                relationship.Relationship == EntityRelationshipType.ZeroOrMany)
            {
                generate = false;
            }
            // OneToMany should be handled on one side
            else if (relationship.WithMultiEntity &&
                pairRelationship.WithSingleEntity)
            {
                generate = true;
            }
            // If ZeroOrOne vs ExactlyOne handle on ExactlyOne side
            else if (pairRelationship.Relationship == EntityRelationshipType.ExactlyOne &&
                relationship.Relationship == EntityRelationshipType.ZeroOrOne)
            {
                generate = false;
            }
            // If same type on both sides cover on first by ascending alphabetical sort
            else if (pairRelationship.Relationship == relationship.Relationship &&
                     // Ascending alphabetical sort
                     string.Compare(relationship.Entity, pairRelationship.Entity,
                         StringComparison.InvariantCulture) > 0)
            {
                generate = false;
            }
        }

        return generate;
    }


    public static bool IsRequired(this EntityRelationship relationship)
    {
        return
            relationship.Relationship == EntityRelationshipType.ExactlyOne ||
            relationship.Relationship == EntityRelationshipType.OneOrMany;
    }

    /// <summary>
    /// This relationship is a zero or one relation to the other entity
    /// </summary>
    public static bool WithSingleEntity(this EntityRelationship relationship)
    {
        return
            relationship.Relationship == EntityRelationshipType.ExactlyOne ||
            relationship.Relationship == EntityRelationshipType.ZeroOrOne;
    }

    /// <summary>
    /// Entity has a relationship to a collection of the other entity
    /// </summary>
    public static bool WithMultiEntity(this EntityRelationship relationship)
    {
        return
            relationship.Relationship == EntityRelationshipType.ZeroOrMany ||
            relationship.Relationship == EntityRelationshipType.OneOrMany;
    }

    public static bool ShouldUseRelationshipNameAsNavigation(this EntityRelationship relationship)
    {
        var hasReferenceToSingularEntity = relationship.WithSingleEntity();
        var hasReferenceToManyEntities = !hasReferenceToSingularEntity;
        var relationshipNameIsEqualToSingularName = relationship.Name == relationship.Entity;
        var relationshipNameIsEqualToPluralName = relationship.Name == relationship.EntityPlural;

        return
            (hasReferenceToSingularEntity && relationshipNameIsEqualToSingularName) ||
            (hasReferenceToManyEntities && relationshipNameIsEqualToPluralName);

    }

    public static string GetPrimitiveForeignKeyType(this EntityRelationship relationship)
    {
        if (relationship.Related.Entity.HasCompositeKey)
        {
            return $"{relationship.Related.Entity.Name}KeyDto";
        }
        else
        {
            var keyType = relationship.Related.Entity.Keys[0].Type;
            var typeDefinition = new NoxSimpleTypeDefinition()
            {
                Name = $"{relationship.Related.Entity.Name}Id",
                Type = keyType
            };
            var componentType = keyType.GetComponents(typeDefinition).FirstOrDefault().Value;

            return $"System.{componentType.Name}";
        }
    }
}