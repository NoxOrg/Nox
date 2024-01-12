using Microsoft.OpenApi.Models;
using Nox.Extensions;
using Nox.Solution;
using Nox.Solution.Builders;
using System.Text.RegularExpressions;

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
            {
                var path = $"{existingPath}/{navigationName}";
                var pathItem = new OpenApiPathItem { Operations = new Dictionary<OperationType, OpenApiOperation>() };
                var keyNames = GetKeyNames(path);
                pathItem.AddOperation(OperationType.Get,
                    OpenApiExtensions.CreateOperation(tagName).WithPathParameters(keyNames).WithResponseBody($"{relatedEntityName}DtoSingleResult"));
                pathItem.AddOperation(OperationType.Post,
                    OpenApiExtensions.CreateOperation(tagName).WithPathParameters(keyNames).WithRequestBody($"{relatedEntityName}CreateDto"));
                pathItem.AddOperation(OperationType.Put,
                    OpenApiExtensions.CreateOperation(tagName).WithPathParameters(keyNames).WithRequestBody($"{relatedEntityName}UpdateDto").WithResponseBody($"{relatedEntityName}Dto"));
                pathItem.AddOperation(OperationType.Patch,
                    OpenApiExtensions.CreateOperation(tagName).WithPathParameters(keyNames).WithRequestBody($"{relatedEntityName}PartialUpdateDtoDelta").WithResponseBody($"{relatedEntityName}Dto"));
                if (relationship.Relationship == EntityRelationshipType.ZeroOrOne)
                    pathItem.AddOperation(OperationType.Delete, OpenApiExtensions.CreateOperation(tagName).WithPathParameters(keyNames));
                result.Add((path, pathItem));
            }
            {
                var path = $"{existingPath}/{navigationName}/$ref";
                var pathItem = new OpenApiPathItem { Operations = new Dictionary<OperationType, OpenApiOperation>() };
                var operation = OpenApiExtensions.CreateOperation(tagName).WithPathParameters(GetKeyNames(path));
                pathItem.AddOperation(OperationType.Get, operation);
                if (relationship.Relationship == EntityRelationshipType.ZeroOrOne)
                    pathItem.AddOperation(OperationType.Delete, operation);
                result.Add((path, pathItem));
            }
            {
                var path = $"{existingPath}/{navigationName}/{{{GetKeyParameterName(navigationName)}}}/$ref";
                var pathItem = new OpenApiPathItem { Operations = new Dictionary<OperationType, OpenApiOperation>() };
                var operation = OpenApiExtensions.CreateOperation(tagName).WithPathParameters(GetKeyNames(path));
                pathItem.AddOperation(new List<OperationType> { OperationType.Post, OperationType.Put }, operation);
                if (relationship.Relationship == EntityRelationshipType.ZeroOrOne)
                    pathItem.AddOperation(OperationType.Delete, operation);
                result.Add((path, pathItem));
            }
        }
        else
        {
            {
                var path = $"{existingPath}/{navigationName}";
                var pathItem = new OpenApiPathItem { Operations = new Dictionary<OperationType, OpenApiOperation>() };
                var keyNames = GetKeyNames(path);
                pathItem.AddOperation(OperationType.Get,
                    OpenApiExtensions.CreateOperation(tagName).WithPathParameters(keyNames).WithResponseBody($"{relatedEntityName}Dto"));
                pathItem.AddOperation(OperationType.Post,
                    OpenApiExtensions.CreateOperation(tagName).WithPathParameters(keyNames).WithRequestBody($"{relatedEntityName}CreateDto"));
                pathItem.AddOperation(OperationType.Delete,
                    OpenApiExtensions.CreateOperation(tagName).WithPathParameters(keyNames));
                result.Add((path, pathItem));
            }
            {
                var path = $"{existingPath}/{navigationName}/{{{GetKeyParameterName(navigationName)}}}";
                var pathItem = new OpenApiPathItem { Operations = new Dictionary<OperationType, OpenApiOperation>() };
                var keyNames = GetKeyNames(path);
                pathItem.AddOperation(OperationType.Get,
                    OpenApiExtensions.CreateOperation(tagName).WithPathParameters(keyNames).WithResponseBody($"{relatedEntityName}DtoSingleResult"));
                pathItem.AddOperation(OperationType.Put,
                    OpenApiExtensions.CreateOperation(tagName).WithPathParameters(keyNames).WithRequestBody($"{relatedEntityName}UpdateDto").WithResponseBody($"{relatedEntityName}Dto"));
                pathItem.AddOperation(OperationType.Patch,
                    OpenApiExtensions.CreateOperation(tagName).WithPathParameters(keyNames).WithRequestBody($"{relatedEntityName}PartialUpdateDtoDelta").WithResponseBody($"{relatedEntityName}Dto"));
                pathItem.AddOperation(OperationType.Delete,
                    OpenApiExtensions.CreateOperation(tagName).WithPathParameters(keyNames));
                result.Add((path, pathItem));
            }
            {
                var path = $"{existingPath}/{navigationName}/$ref";
                var pathItem = new OpenApiPathItem { Operations = new Dictionary<OperationType, OpenApiOperation>() };
                var keyNames = GetKeyNames(path);
                pathItem.AddOperation(OperationType.Get,
                    OpenApiExtensions.CreateOperation(tagName).WithPathParameters(keyNames));
                pathItem.AddOperation(OperationType.Put,
                    OpenApiExtensions.CreateOperation(tagName).WithPathParameters(keyNames).WithRequestBody("StringReferencesDto"));
                pathItem.AddOperation(OperationType.Delete,
                    OpenApiExtensions.CreateOperation(tagName).WithPathParameters(keyNames));
                result.Add((path, pathItem));
            }
            {
                var path = $"{existingPath}/{navigationName}/{{{GetKeyParameterName(navigationName)}}}/$ref";
                var pathItem = new OpenApiPathItem { Operations = new Dictionary<OperationType, OpenApiOperation>() };
                pathItem.AddOperation(new List<OperationType> { OperationType.Post, OperationType.Put, OperationType.Delete }, 
                    OpenApiExtensions.CreateOperation(tagName).WithPathParameters(GetKeyNames(path)));
                result.Add((path, pathItem));
            }
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
}
