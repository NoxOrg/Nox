using Microsoft.OpenApi.Models;
using Nox.Extensions;
using Nox.Solution;
using Nox.Solution.Builders;
using System.Text.RegularExpressions;
using System.Linq;

namespace Nox.Presentation.Api;

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

        if (relationship.WithSingleEntity)
        {
            AddOperationItemsToResult(result, $"{existingPath}/{navigationName}", tagName, new List<(OperationType?, string?, string?)>
            {
                (OperationType.Get, null, $"{relatedEntityName}DtoSingleResult"),
                (OperationType.Post, $"{relatedEntityName}CreateDto", null),
                (OperationType.Put, $"{relatedEntityName}UpdateDto", $"{relatedEntityName}Dto"),
                (OperationType.Patch, $"{relatedEntityName}PartialUpdateDtoDelta", $"{relatedEntityName}Dto"),
                ((relationship.Relationship == EntityRelationshipType.ZeroOrOne ? OperationType.Delete : null), null, null),
            });
            AddOperationItemsToResult(result, $"{existingPath}/{navigationName}/$ref", tagName, new List<(OperationType?, string?, string?)>
            {
                (OperationType.Get, null, null),
                ((relationship.Relationship == EntityRelationshipType.ZeroOrOne ? OperationType.Delete : null), null, null),
            });
            AddOperationItemsToResult(result, $"{existingPath}/{navigationName}/{{{GetKeyParameterName(navigationName)}}}/$ref", tagName, new List<(OperationType?, string?, string?)>
            {
                (OperationType.Post, null, null),
                (OperationType.Put, null, null),
                ((relationship.Relationship == EntityRelationshipType.ZeroOrOne ? OperationType.Delete : null), null, null),
            });
        }
        else
        {
            AddOperationItemsToResult(result, $"{existingPath}/{navigationName}", tagName, new List<(OperationType?, string?, string?)>
            {
                (OperationType.Get, null, $"{relatedEntityName}Dto"),
                (OperationType.Post, $"{relatedEntityName}CreateDto", null),
                (OperationType.Delete, null, null)
            });
            AddOperationItemsToResult(result, $"{existingPath}/{navigationName}/{{{GetKeyParameterName(navigationName)}}}", tagName, new List<(OperationType?, string?, string?)>
            {
                (OperationType.Get, null, $"{relatedEntityName}DtoSingleResult"),
                (OperationType.Put, $"{relatedEntityName}UpdateDto", $"{relatedEntityName}Dto"),
                (OperationType.Patch, $"{relatedEntityName}PartialUpdateDtoDelta", $"{relatedEntityName}Dto"),
                (OperationType.Delete, null, null)
            });
            AddOperationItemsToResult(result, $"{existingPath}/{navigationName}/$ref", tagName, new List<(OperationType?, string?, string?)>
            {
                (OperationType.Get, null, null),
                (OperationType.Put, "StringReferencesDto", null),
                (OperationType.Delete, null, null)
            });
            AddOperationItemsToResult(result, $"{existingPath}/{navigationName}/{{{GetKeyParameterName(navigationName)}}}/$ref", tagName, new List<(OperationType?, string?, string?)>
            {
                (OperationType.Post, null, null),
                (OperationType.Put, null, null),
                (OperationType.Delete, null, null)
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

    private static void AddOperationItemsToResult(List<(string, OpenApiPathItem)> result, string path, string tagName, List<(OperationType? OperationType, string? RequestReferenceId, string? ResponseReferenceId)> operationsInfo)
    {
        var pathItem = new OpenApiPathItem { Operations = new Dictionary<OperationType, OpenApiOperation>() };
        var keyNames = GetKeyNames(path);
        foreach (var info in operationsInfo.Where(info => info.OperationType is not null))
        {
            pathItem.AddOperation(info.OperationType!.Value,
                OpenApiExtensions.CreateOperation(tagName)
                .WithPathParameters(keyNames)
                .WithRequestBody(info.RequestReferenceId)
                .WithResponseBody(info.ResponseReferenceId));
        }

        result.Add((path, pathItem));
    }
}
