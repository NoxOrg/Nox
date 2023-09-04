using Nox.Solution;
using Nox.Types;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace Nox.Docs.Extensions;



public enum MarkdownDetail
{
    Summary,
    Normal,
    Detailed,
}

public static class NoxSolutionMarkdownExtensions
{
    public static string ToMarkdownReadme(this NoxSolution noxSolution, MarkdownDetail detail = MarkdownDetail.Normal)
    {
        var mermaidText = noxSolution.ToMermaidErd(ErdDetail.Summary);

        var docs = $"""
        # {noxSolution.Name}
        ## Decription

        {noxSolution.Description}

        ## Overview
        {noxSolution.Overview}

        ## High-Level Domain Model

        ``` mermaid
        {mermaidText}
        ```

        ## Definitions for Domain Entities

        {DomainDecription(noxSolution)}
        
        """;

        return docs;
    }

    private static string DomainDecription(NoxSolution noxSolution)
    {
        var sb = new StringBuilder();

        if (noxSolution?.Domain?.Entities is null)
            return sb.ToString();

        foreach (var entity in noxSolution.Domain.Entities.OrderBy(e => e.Name))
        {
            var isOwned = entity.IsOwnedEntity ? $" (Owned by {entity.OwnerEntity?.Name})" : string.Empty;

            sb.AppendLine($"""
                ### {entity.Name}{isOwned}

                {entity.Description}

                {AttributeTable(entity, noxSolution)}

                {RelationshipsTable(entity, noxSolution)}

                """);
        }

        return sb.ToString();
    }


    private static string AttributeTable(Entity entity, NoxSolution noxSolution)
    {

        var members = entity.GetAllMembers();

        if (members.Count() == 0)
            return string.Empty;

        var sb = new StringBuilder();

        sb.AppendLine("#### <u>Members (Keys, Attributes & Relationships)</u>");
        sb.AppendLine("");

        sb.AppendLine("Member|Type|Decription|Info");
        sb.AppendLine("---------|----|----------|-------");

        foreach (var (type, def) in members)
        {
            var isRequired = def.IsRequired ? "Required" : string.Empty;
            var isReadonly = def.IsReadonly ? "Readonly" : string.Empty;

            var fkKind = type switch
            {
                EntityMemberType.Relationship => "Foreign Key",
                EntityMemberType.Key => "Primary Key",
                EntityMemberType.OwnedRelationship => "Owned Entity",
                _ => string.Empty
            };
            var typeOptions = GetTypeOptions(def, noxSolution);

            var info = string.Join(", ", (new string[] { isRequired, isReadonly, fkKind, typeOptions }).Where(e => !string.IsNullOrWhiteSpace(e)));

            sb.AppendLine($"{def.Name}|{def.Type}|{def.Description}|{info}");
        }
        return sb.ToString();
    }

    private static string GetTypeOptions(NoxSimpleTypeDefinition def, NoxSolution noxSolution)
    {
        // noxSolution.GetSingleKeyTypeForEntity(def.EntityTypeOptions!.Entity) 
        if (def.Type == NoxType.Entity)
            return string.Empty;

        var type = def.Type;

        var typeOptions = $"{type}TypeOptions";

        var options = typeof(NoxSimpleTypeDefinition).GetProperty(typeOptions);

        if (options is null)
            return string.Empty;

        var optionsValue = options.GetValue(def, null);

        if (optionsValue is null)
            return string.Empty;

        var optionsType = optionsValue.GetType();

        var defaultOptionsValue = Activator.CreateInstance(optionsType);

        var sb = new StringBuilder();

        var properties = optionsType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => p.CanWrite)
            .Where(p => !Attribute.IsDefined(p, typeof(YamlIgnoreAttribute)));

        var changedProps = new List<string>();

        foreach (var property in properties)
        {
            var value = property.GetValue(optionsValue, null);
            var defaultValue = property.GetValue(defaultOptionsValue, null);
            if (value != null && defaultValue != null && !value.Equals(defaultValue))
            {
                changedProps.Add($"{property.Name}: {GetValueAsString(value)}");
            }
        }

        sb.Append(string.Join(", ", changedProps));

        return sb.ToString();

    }

    private static string RelationshipsTable(Entity entity, NoxSolution noxSolution)
    {

        var relationships = entity.Relationships;

        if (relationships is null || relationships.Count == 0)
            return string.Empty;

        var sb = new StringBuilder();

        sb.AppendLine("#### <u>Relationships</u>");
        sb.AppendLine("");
        sb.AppendLine("Description|Cardinality|Related Entity|Name|Can Navigate?");
        sb.AppendLine("-----------|-----------|--------------|----|-------------");

        foreach (var relationship in relationships)
        {
            var canNavigate = relationship.CanNavigate ? "Yes" : "No";
            sb.AppendLine($"{relationship.Description}|{relationship.Relationship}|{relationship.Related.Entity.Name}|{relationship.Name}|{canNavigate}");
        }
        return sb.ToString();
    }


    private static string GetValueAsString(object value)
    {
        if (value is bool boolValue)
        {
            return boolValue ? "true" : "false";
        }
        else if (value is decimal decValue)
        {
            return $"{decValue.ToString(CultureInfo.InvariantCulture)}";
        }
        else if (value is float floatValue)
        {
            return $"{floatValue.ToString(CultureInfo.InvariantCulture)}";
        }
        else if (value is double doubleValue)
        {
            return $"{doubleValue.ToString(CultureInfo.InvariantCulture)}";
        }
        else if (value is DateTime dateTimeValue)
        {
            return $"{dateTimeValue:s}";
        }
        else
        {
            return value.ToString()!;
        }
    }

}
