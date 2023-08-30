using System;

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
    /// <summary>
    ///The related entity is a *OrMany relationship to this  
    /// </summary>
    public static bool IsManyRelationshipOnOtherSide(this EntityRelationship relationship)
    {
        return
            relationship.Related.EntityRelationship.Relationship == EntityRelationshipType.ZeroOrMany ||
            relationship.Related.EntityRelationship.Relationship == EntityRelationshipType.OneOrMany;
    }
}