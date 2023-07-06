

using Nox.Solution;
using System.Text;

namespace Nox.Docs.Extensions;

public enum ErdDetail
{
    Summary,
    Normal,
    Detailed,
}

public static class NoxSolutionExtensions
{

    public static string ToMermaidErd(this NoxSolution noxSolution, ErdDetail detail = ErdDetail.Normal)
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
                        relationshipPairs[key] = new RelationshipPair(left: relationship);
                    }
                }
            }

            if (entity.Attributes is null || detail == ErdDetail.Summary)
            {
                sb.AppendLine($"    {entity.Name} {{");
                sb.AppendLine($"    }}");
                continue;
            }

            sb.AppendLine($"    {entity.Name} {{");
            foreach (var attr in entity.Attributes)
            {
                var required = attr.IsRequired ? "(Required)" : "";
                var description = detail == ErdDetail.Detailed ? $" \"{attr.Description} {required}\"": "";

                sb.AppendLine($"        {attr.Type.ToString()} {attr.Name}{description}");
            }
            sb.AppendLine($"    }}");
        }

        foreach(var (key,value) in relationshipPairs)
        {
            if (value.Right is null)
            {
                throw new Exception($"The solution definition is invalid. {key} relationship is not defined in entity {value.Left!.Entity}");
            }

            sb.Append("    ");
            sb.Append(value.Right.Entity);
            sb.Append(MermaidRelationshipSymbol(value.Right.Relationship, Side.Left));
            sb.Append("--");
            sb.Append(MermaidRelationshipSymbol(value.Left!.Relationship, Side.Right));
            sb.Append(value.Left.Entity);
            sb.Append(" : \"");
            sb.Append(value.Left.Description);
            sb.AppendLine("\"");
        }

        return sb.ToString();
    }

    private enum Side
    {
        Left,
        Right,
    }

    private static string MermaidRelationshipSymbol(EntityRelationshipType type, Side side)
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
        public EntityRelationship Left;

        public EntityRelationship? Right;
        public RelationshipPair(EntityRelationship left)
        {
            Left = left;
        }
    }
}
