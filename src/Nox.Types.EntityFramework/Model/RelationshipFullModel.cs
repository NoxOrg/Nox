using Nox.Solution;

namespace Nox.Types.EntityFramework.Model
{
    public class RelationshipFullModel
    {
        public Entity Entity { get; set; } = null!;
        public EntityRelationship Relationship { get; set; } = null!; 
        public Type RelationshipEntityType { get; set; } = null!;
    }
}
