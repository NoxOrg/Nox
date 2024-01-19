using Microsoft.OpenApi.Models;
using Nox.Extensions;
using Nox.Solution;
using Nox.Solution.Builders;
using System.Text.RegularExpressions;
using Nox.Types.Extensions;

namespace Nox.Presentation.Api;

internal record OperationInfo(OperationType? OperationType = null, string? RequestReferenceId = null, string? ResponseReferenceId = null, string? ResponseType = null);

internal sealed partial class RelatedEntityRoutingPathBuilder : RelatedEntityRoutingPathBuilderBase<(string, OpenApiPathItem)>
{
    public RelatedEntityRoutingPathBuilder(IReadOnlyList<Entity> entities) : base(entities)
    {
    }

    public override void AddResult(List<(string, OpenApiPathItem)> result, Entity currentEntity, EntityRelationship relationship, string existingPath)
    {
        var navigationName = currentEntity.GetNavigationPropertyName(relationship);
        var tagName = GetTagName(existingPath);
        var relatedEntityName = relationship.Related.Entity.Name;
        var relatedKeyType = relationship.Related.Entity.Keys[0].Type.GetComponents(relationship.Related.Entity.Keys[0]).Single().Value.ToString();
        if (relatedKeyType.StartsWith("System."))
            relatedKeyType = relatedKeyType[7..];

        if (relationship.WithSingleEntity)
        {
            AddOperationItemsToResult(result, $"{existingPath}/{navigationName}", tagName, new List<OperationInfo>
            {
                new() { OperationType = OperationType.Get, ResponseReferenceId = $"{relatedEntityName}DtoSingleResult" },
                new() { OperationType = OperationType.Post, RequestReferenceId = $"{relatedEntityName}CreateDto" },
                new() { OperationType = OperationType.Put, RequestReferenceId = $"{relatedEntityName}UpdateDto", ResponseReferenceId = $"{relatedEntityName}Dto" },
                new() { OperationType = OperationType.Patch, RequestReferenceId = $"{relatedEntityName}PartialUpdateDtoDelta", ResponseReferenceId = $"{relatedEntityName}Dto" },
                new() { OperationType = (relationship.Relationship == EntityRelationshipType.ZeroOrOne ? OperationType.Delete : null), }
            });
            AddOperationItemsToResult(result, $"{existingPath}/{navigationName}/$ref", tagName, new List<OperationInfo>
            {
                new() { OperationType = OperationType.Get },
                new() { OperationType = (relationship.Relationship == EntityRelationshipType.ZeroOrOne ? OperationType.Delete : null) }
            });
            AddOperationItemsToResult(result, $"{existingPath}/{navigationName}/{{{GetKeyParameterName(navigationName)}}}/$ref", tagName, new List<OperationInfo>
            {
                new() { OperationType = OperationType.Post },
                new() { OperationType = OperationType.Put },
                new() { OperationType = (relationship.Relationship == EntityRelationshipType.ZeroOrOne ? OperationType.Delete : null) }
            });
        }
        else
        {
            AddOperationItemsToResult(result, $"{existingPath}/{navigationName}", tagName, new List<OperationInfo>
            {
                new() { OperationType = OperationType.Get, ResponseReferenceId = $"{relatedEntityName}Dto", ResponseType = "array" },
                new() { OperationType = OperationType.Post, RequestReferenceId = $"{relatedEntityName}CreateDto" },
                new() { OperationType = OperationType.Delete }
            });
            AddOperationItemsToResult(result, $"{existingPath}/{navigationName}/{{{GetKeyParameterName(navigationName)}}}", tagName, new List<OperationInfo>
            {
                new() { OperationType =  OperationType.Get, RequestReferenceId = $"{relatedEntityName}DtoSingleResult" },
                new() { OperationType = OperationType.Put, RequestReferenceId = $"{relatedEntityName}UpdateDto", ResponseReferenceId = $"{relatedEntityName}Dto" },
                new() { OperationType = OperationType.Patch, RequestReferenceId = $"{relatedEntityName}PartialUpdateDtoDelta", ResponseReferenceId = $"{relatedEntityName}Dto" },
                new() { OperationType = OperationType.Delete }
            });
            AddOperationItemsToResult(result, $"{existingPath}/{navigationName}/$ref", tagName, new List<OperationInfo>
            {
                new() { OperationType = OperationType.Get },
                new() { OperationType = OperationType.Put, RequestReferenceId = relatedKeyType + "ReferencesDto" },
                new() { OperationType = OperationType.Delete }
            });
            AddOperationItemsToResult(result, $"{existingPath}/{navigationName}/{{{GetKeyParameterName(navigationName)}}}/$ref", tagName, new List<OperationInfo>
            {
                new() { OperationType = OperationType.Post },
                new() { OperationType = OperationType.Put },
                new() { OperationType = OperationType.Delete }
            });
        }
    }

    private static string GetTagName(string path)
    {
        return path[..path.IndexOf('/')];
    }

    [GeneratedRegex("{([^{}]*)}")]
    private static partial Regex KeysRegex();

    private static List<string> GetKeyNames(string path)
    {
        List<string> matches = new();
        Regex regex = KeysRegex();

        MatchCollection collection = regex.Matches(path);
        foreach (Match match in collection.Cast<Match>())
        {
            matches.Add(match.Groups[1].Value);
        }

        return matches;
    }

    private static void AddOperationItemsToResult(List<(string, OpenApiPathItem)> result, string path, string tagName, List<OperationInfo> operationsInfo)
    {
        var pathItem = new OpenApiPathItem { Operations = new Dictionary<OperationType, OpenApiOperation>() };
        var keyNames = GetKeyNames(path);
        foreach (var info in operationsInfo.Where(info => info.OperationType is not null))
        {
            pathItem.AddOperation(info.OperationType!.Value,
                OpenApiExtensions.CreateOperation(tagName)
                .WithPathParameters(keyNames)
                .WithRequestBody(info.RequestReferenceId)
                .WithResponseBody(info.ResponseReferenceId, info.ResponseType));
        }

        result.Add((path, pathItem));
    }

}
