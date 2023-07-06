

using Nox.Solution;
using System.Text;

namespace Nox.Docs.Extensions;

public static class NoxSolutionExtensions
{
    public static string ToMermaidErd(this NoxSolution noxSolution)
    {
        var sb = new StringBuilder();

        if (noxSolution.Domain is null)
        {
            return sb.ToString();
        }

        sb.AppendLine("erDiagram");

        var relationshipPairs = new Dictionary<string, RelationshipPair>();

        foreach (var entity in noxSolution.Domain.Entities)
        {

            if (entity.Relationships is not null)
            {
                foreach(var relationship in entity.Relationships) 
                {
                    var key = string.Join(',',(new [] { entity.Name, relationship.Entity }).Order().ToArray());

                    if (relationshipPairs.ContainsKey(key))
                    {
                        relationshipPairs[key].Right = relationship;
                    }
                    else
                    {
                        relationshipPairs[key] = new RelationshipPair { Left = relationship };
                    }
                }
            }

            if (entity.Attributes is null)
            {
                continue;
            }

            sb.AppendLine($"    {entity.Name} {{");
            foreach (var attr in entity.Attributes)
            {
                sb.AppendLine($"        {attr.Type.ToString()} {attr.Name}");
            }
            sb.AppendLine($"    }}");
        }

        foreach(var (key,value) in relationshipPairs)
        {
            if (value.Right is null)
            {
                throw new Exception($"The solution definition is invalid. {key} relationship is not defined in entity {value.Left!.Entity}");
            }

            sb.Append($"    {value.Right.Entity}{RelationshipSymbol(value.Left!.Relationship, Side.Left)}--{RelationshipSymbol(value.Right.Relationship, Side.Right)}{value.Left.Entity} : {value.Left!.Name}");
        }

        return sb.ToString();
    }

    private enum Side
    {
        Left,
        Right,
    }

    private static string RelationshipSymbol(EntityRelationshipType type, Side side)
    {
        return type switch
        {
            EntityRelationshipType.ZeroOrOne => side == Side.Left ? "|o" : "o|",
            EntityRelationshipType.ExactlyOne => "||",
            EntityRelationshipType.ZeroOrMany => side == Side.Left ? "}o" : "o{",
            EntityRelationshipType.OneOrMany => side == Side.Left ? "}|" : "|{",
            _ => throw new NotImplementedException(),
        };
    }

    private class RelationshipPair
    {
        public EntityRelationship? Left;
        public EntityRelationship? Right;
    }
}
