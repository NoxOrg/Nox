using System;

namespace Nox.Solution.Extensions;

public static class EntityRelationshipExtensions
{
    public static bool ShouldGenerateForeignOnThisSide(this EntityRelationship relationship)
    {
        var isIgnored = false;

        var pairRelationship = relationship.Related.EntityRelationship;
        if (pairRelationship != null)
        {
            // ManyToMany does not need to be handled as it doesn't have special logic
            // Will be always ignored by default
            if (relationship.Relationship == EntityRelationshipType.OneOrMany ||
                relationship.Relationship == EntityRelationshipType.ZeroOrMany)
            {
                isIgnored = true;
            }
            // If ZeroOrOne vs ExactlyOne handle on ExactlyOne side
            else if (pairRelationship.Relationship == EntityRelationshipType.ExactlyOne &&
                relationship.Relationship == EntityRelationshipType.ZeroOrOne)
            {
                isIgnored = true;
            }
            // If same type on both sides cover on first by ascending alphabetical sort
            else if (pairRelationship.Relationship == relationship.Relationship &&
                     // Ascending alphabetical sort
                     string.Compare(relationship.Entity, pairRelationship.Entity,
                         StringComparison.InvariantCulture) > 0)
            {
                isIgnored = true;
            }
        }

        return !isIgnored;
    }

    public static bool HasRelationshipWithSingularEntity(this EntityRelationship relationship)
    {
        return
            relationship.Relationship == EntityRelationshipType.ExactlyOne ||
            relationship.Relationship == EntityRelationshipType.ZeroOrOne;
    }

    public static bool ShouldUseRelationshipNameAsNavigation(this EntityRelationship relationship)
    {
        var hasReferenceToSingularEntity = HasRelationshipWithSingularEntity(relationship);
        var hasReferenceToManyEntities = !hasReferenceToSingularEntity;
        var relationshipNameIsEqualToSingularName = relationship.Name == relationship.Entity;
        var relationshipNameIsEqualToPluralName = relationship.Name == relationship.EntityPlural;

        return
            (hasReferenceToSingularEntity && relationshipNameIsEqualToSingularName) ||
            (hasReferenceToManyEntities && relationshipNameIsEqualToPluralName);

    }

    public static bool IsManyRelationshipOnOtherSide(this EntityRelationship relationship)
    {
        return
            relationship.Related.EntityRelationship.Relationship == EntityRelationshipType.ZeroOrMany ||
            relationship.Related.EntityRelationship.Relationship == EntityRelationshipType.OneOrMany;
    }
}