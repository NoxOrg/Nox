using Nox.Solution;
using System;
using System.Text;

namespace Nox.Docs.Extensions;

public enum ErdDetail
{
    Summary,
    Normal,
    Detailed,
}

public static class NoxSolutionMermaidExtensions
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

            if (detail != ErdDetail.Summary)
            {
                foreach (var iMember in entity.GetAllMembers())
                {
                    var type = iMember.Key;
                    var member = iMember.Value;

                    if (type == EntityMemberType.OwnedRelationship)
                        continue;

                    var memberType = member.Type.ToString();
                    var memberName = member.Name;
                    var required = member.IsRequired ? " (Required)" : string.Empty;
                    var description = detail == ErdDetail.Detailed ? $" \"{member.Description}{required}\"" : string.Empty;

                    var kind = type switch
                    {
                        EntityMemberType.Key => " PK",
                        EntityMemberType.Relationship => " FK",
                        EntityMemberType.OwnedRelationship => " Owned",
                        _ => string.Empty
                    };

                    sb.AppendLine($"        {memberType} {memberName}{kind}{description}");
                }
            }

            sb.AppendLine($"    }}");

            if (entity.Relationships is not null)
            {
                foreach (var relationship in entity.Relationships)
                {
                    // Just pick one of the two sides arbritarily - using sort order here
                    if (entity.Name.CompareTo(relationship.Related.Entity.Name) > 0)
                    {
                        sb.Append("    ");
                        sb.Append(entity.Name);
                        sb.Append(MermaidRelationshipSymbol(relationship.Related.EntityRelationship.Relationship, Side.Left));
                        sb.Append("..");
                        sb.Append(MermaidRelationshipSymbol(relationship.Relationship, Side.Right));
                        sb.Append(relationship.Related.Entity.Name);
                        sb.Append(" : \"");
                        sb.Append(relationship.Description);
                        sb.AppendLine("\"");
                    }
                }
            }

            if (entity.OwnedRelationships is not null)
            {
                foreach (var relationship in entity.OwnedRelationships)
                {
                    sb.Append("    ");
                    sb.Append(entity.Name);
                    sb.Append(MermaidRelationshipSymbol(EntityRelationshipType.ExactlyOne, Side.Left));
                    sb.Append("--");
                    sb.Append(MermaidRelationshipSymbol(relationship.Relationship, Side.Right));
                    sb.Append(relationship.Related.Entity.Name);
                    sb.Append(" : \"");
                    sb.Append(relationship.Description);
                    sb.AppendLine("\"");
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