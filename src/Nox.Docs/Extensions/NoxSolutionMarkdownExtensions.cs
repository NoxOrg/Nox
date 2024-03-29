﻿using Nox.Docs.Models;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Types;
using System.Globalization;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using YamlDotNet.Serialization;
using System.Security.Cryptography;

namespace Nox.Docs.Extensions;



public enum MarkdownDetail
{
    Summary,
    Normal,
    Detailed,
}

public static class NoxSolutionMarkdownExtensions
{
    public static MarkdownFile ToMarkdownReadme(this NoxSolution noxSolution, ErdDetail mermaidErdDetail = ErdDetail.Summary)
    {
        var mermaidText = noxSolution.ToMermaidErd(ErdDetail.Summary);
        var entityEndpoints = noxSolution.ToMarkdownEntityEndpoints();
        var entityDomainEvents = noxSolution.ToMarkdownEntityDomainEvents();
        var integrationEvents = noxSolution.ToMarkdownIntegrationEvents();
        var customApiRoutes = noxSolution.ToMarkdownCustomApiRoutes();

        var docs = $"""
        # {noxSolution.Name}
        ## Description

        {noxSolution.Description}

        ## Overview
        {noxSolution.Overview}

        ## High-Level Domain Model

        ``` mermaid
        {mermaidText}
        ```

        ## Integration Events
        [IntegrationEvents]({integrationEvents.Name})

        ## Custom API Routes
        [CustomApiRoutes]({customApiRoutes.Name})

        ## Definitions for Domain Entities

        {DomainDecription(noxSolution, entityEndpoints!, entityDomainEvents!)}
        
        """;

        return new MarkdownFile
        {
            Name = "README.md",
            Content = docs,
            ReferencedFiles = entityEndpoints.Concat(entityDomainEvents).Select(x => (MarkdownFile)x).Concat(new[] { integrationEvents, customApiRoutes }),
        };
    }

    private static string DomainDecription(
        NoxSolution noxSolution,
        IEnumerable<EntityMarkdownFile> entityEndpoints,
        IEnumerable<EntityMarkdownFile> entityDomainEvents)
    {
        var sb = new StringBuilder();

        if (noxSolution?.Domain?.Entities is null)
            return sb.ToString();

        var entities = noxSolution.Domain.Entities
            .OrderBy(e => e.IsOwnedEntity
                ? $"{e.OwnerEntity?.Name}.{e.Name}"
                : e.Name
            );

        foreach (var entity in entities)
        {
            var owner = entity.IsOwnedEntity
                ? $"{entity.OwnerEntity?.Name}."
                : string.Empty;

            var ownedInfo = entity.IsOwnedEntity
                ? $" (Owned by {owner.TrimEnd('.')})"
                : string.Empty;

            var isAudited = !entity.IsOwnedEntity &&
                (entity.Persistence?.IsAudited ?? false);

            var auditInfo = isAudited
                ? " *This entity is auditable and tracks info about who, which system and when state changes (create/update/delete) were effected.*"
                : string.Empty;

            var endpointsInfo = entity.IsOwnedEntity || !entityEndpoints.Any(x => x.EntityName == entity.Name)
                ? string.Empty
                : $"\n\n[Endpoints]({entityEndpoints.First(x => x.EntityName == entity.Name).Name})";

            var domainEventsInfo = !entityDomainEvents.Any(x => x.EntityName == entity.Name)
                ? string.Empty
                : $"\n\n[Domain Events]({entityDomainEvents.First(x => x.EntityName == entity.Name).Name})";

            sb.AppendLine($"""
                ### {owner}{entity.Name}{ownedInfo}

                {entity.Description?.EnsureEndsWith('.')}{auditInfo}{endpointsInfo}{domainEventsInfo}

                {AttributeTable(entity, isAudited)}

                {RelationshipsTable(entity)}

                """);
        }

        return sb.ToString();
    }


    private static string AttributeTable(Entity entity, bool isAudited)
    {

        var members = entity.GetAllMembers();

        if (!members.Any())
            return string.Empty;

        var sb = new StringBuilder();

        sb.AppendLine("#### <u>Members (Keys, Attributes & Relationships)</u>");
        sb.AppendLine("");

        sb.AppendLine("Member|Type|Description|Info");
        sb.AppendLine("---------|----|----------|-------");

        foreach (var member in members)
        {
            var type = member.Key;
            var def = member.Value;
            var isRequired = def.IsRequired ? "Required" : string.Empty;
            var isReadonly = def.IsReadonly ? "Readonly" : string.Empty;

            var fkKind = type switch
            {
                EntityMemberType.Relationship => "Foreign Key",
                EntityMemberType.Key => "Primary Key",
                EntityMemberType.OwnedRelationship => "Owned Entity",
                _ => string.Empty
            };
            var typeOptions = GetTypeOptions(def);

            var info = string.Join(", ", (new string[] { isRequired, isReadonly, fkKind, typeOptions }).Where(e => !string.IsNullOrWhiteSpace(e)));

            sb.AppendLine($"{def.Name}|{def.Type}|{def.Description?.EnsureEndsWith('.')}|{info}");
        }
        if (isAudited)
        {
            sb.AppendLine($"*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*");
        }

        return sb.ToString();
    }

    private static string GetTypeOptions(NoxSimpleTypeDefinition def)
    {
        if (def.Type == NoxType.EntityId)
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

    private static string RelationshipsTable(Entity entity)
    {

        var relationships = entity.Relationships;

        if (relationships is null || relationships.Count == 0)
            return string.Empty;

        var sb = new StringBuilder();

        sb.AppendLine("#### <u>Relationships</u>");
        sb.AppendLine("");
        sb.AppendLine("Description|Cardinality|Related Entity|Name|Can Manage Ref?|Can Manage Entity?");
        sb.AppendLine("-----------|-----------|--------------|----|---------------|------------------");

        foreach (var relationship in relationships)
        {
            var canManageRef = relationship.ApiGenerateReferenceEndpoint? "Yes" : "No";
            var canManageEntity = relationship.ApiGenerateRelatedEndpoint? "Yes" : "No";
            sb.AppendLine($"{relationship.Description}|{relationship.Relationship}|{relationship.Related.Entity.Name}|{relationship.Name}|{canManageRef}|{canManageEntity}");
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
