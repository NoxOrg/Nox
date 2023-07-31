using System;

namespace Nox.Solution;

public class EntityRelationshipWithType
{
    public EntityRelationship Relationship { get; set; } = null!; 
    public Type RelationshipEntityType { get; set; } = null!;
    public bool ShouldGenerateSpecialRelationshipLogicOnThisSide { get; set; } = false;
}
