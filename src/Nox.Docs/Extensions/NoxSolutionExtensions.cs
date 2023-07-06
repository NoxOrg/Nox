

using Nox.Solution;
using System.Text;
using YamlDotNet.Core.Tokens;

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


        foreach (var entity in noxSolution.Domain.Entities)
        {

            sb.AppendLine($"    {entity.Name} {{");

            if (entity.Attributes is not null && detail != ErdDetail.Summary)
            {
                foreach (var key in entity.Keys!)
                {
                    var required = " (Required)";
                    var description = detail == ErdDetail.Detailed ? $" \"{key.Description}{required}\"" : "";

                    sb.AppendLine($"        {key.Type.ToString()} {key.Name} PK{description}");
                }

                foreach (var attr in entity.Attributes)
                {
                    var required = attr.IsRequired ? " (Required)" : "";
                    var description = detail == ErdDetail.Detailed ? $" \"{attr.Description}{required}\"" : "";

                    sb.AppendLine($"        {attr.Type.ToString()} {attr.Name}{description}");
                }

            }

            sb.AppendLine($"    }}");

            if (entity.Relationships is not null)
            {
                foreach (var relationship in entity.Relationships)
                {
                    if (entity.Name.CompareTo(relationship.Other.Entity.Name) > 0)
                    {
                        sb.Append("    ");
                        sb.Append(entity.Name);
                        sb.Append(MermaidRelationshipSymbol(relationship.Other.EntityRelationship.Relationship, Side.Left));
                        sb.Append("--");
                        sb.Append(MermaidRelationshipSymbol(relationship.Relationship, Side.Right));
                        sb.Append(relationship.Other.Entity.Name);
                        sb.Append(" : \"");
                        sb.Append(relationship.Description);
                        sb.AppendLine("\"");
                    }
                }
            }
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
}
