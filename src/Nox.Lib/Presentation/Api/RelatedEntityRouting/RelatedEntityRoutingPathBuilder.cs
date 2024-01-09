using Microsoft.OpenApi.Models;
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

        if (relationship.WithSingleEntity)
        {
            var path = $"{existingPath}/{navigationName}";
            var pathItem = new OpenApiPathItem { Operations = new Dictionary<OperationType, OpenApiOperation>() };
            AddOperations(pathItem, tagName, path, 
                OperationType.Get, OperationType.Post, OperationType.Put, OperationType.Patch);
            if(relationship.Relationship == EntityRelationshipType.ZeroOrOne)
                AddOperations(pathItem, tagName, path, OperationType.Delete);
            result.Add((path, pathItem));

            var refPath = $"{existingPath}/{navigationName}/$ref";
            var refPathItem = new OpenApiPathItem { Operations = new Dictionary<OperationType, OpenApiOperation>() };
            AddOperations(refPathItem, tagName, refPath, OperationType.Get);
            if (relationship.Relationship == EntityRelationshipType.ZeroOrOne)
                AddOperations(refPathItem, tagName, refPath, OperationType.Delete);
            result.Add((refPath, refPathItem));

            var refPathWithKey = $"{existingPath}/{navigationName}/{{{GetKeyParameterName(navigationName)}}}/$ref";
            var refPathWithKeyItem = new OpenApiPathItem { Operations = new Dictionary<OperationType, OpenApiOperation>() };
            AddOperations(refPathWithKeyItem, tagName, refPathWithKey, OperationType.Post, OperationType.Put);
            if (relationship.Relationship == EntityRelationshipType.ZeroOrOne)
                AddOperations(refPathWithKeyItem, tagName, refPathWithKey, OperationType.Delete);
            result.Add((refPathWithKey, refPathWithKeyItem));
        }
        else
        {
            var path = $"{existingPath}/{navigationName}";
            var pathItem = new OpenApiPathItem { Operations = new Dictionary<OperationType, OpenApiOperation>() };
            AddOperations(pathItem, tagName, path, OperationType.Get, OperationType.Post, OperationType.Delete);
            result.Add((path, pathItem));

            var pathWithKey = $"{existingPath}/{navigationName}/{{{GetKeyParameterName(navigationName)}}}";
            var pathWithKeyItem = new OpenApiPathItem { Operations = new Dictionary<OperationType, OpenApiOperation>() };
            AddOperations(pathWithKeyItem, tagName, pathWithKey, OperationType.Get, OperationType.Put, OperationType.Patch, OperationType.Delete);
            result.Add((pathWithKey, pathWithKeyItem));

            var refPath = $"{existingPath}/{navigationName}/$ref";
            var refPathItem = new OpenApiPathItem { Operations = new Dictionary<OperationType, OpenApiOperation>() };
            AddOperations(refPathItem, tagName, refPath, OperationType.Get, OperationType.Put, OperationType.Delete);
            result.Add((refPath, refPathItem));

            var refPathWithKey = $"{existingPath}/{navigationName}/{{{GetKeyParameterName(navigationName)}}}/$ref";
            var refPathWithKeyItem = new OpenApiPathItem { Operations = new Dictionary<OperationType, OpenApiOperation>() };
            AddOperations(refPathWithKeyItem, tagName, refPathWithKey, OperationType.Post, OperationType.Put, OperationType.Delete);
            result.Add((refPathWithKey, refPathWithKeyItem));
        }
    }

    private static string GetTagName(string path)
    {
        return path[..path.IndexOf('/')];
    }

    private static void AddOperations(OpenApiPathItem pathItem, string tagName, string path, params OperationType[] operationTypes)
    {

        var operation = new OpenApiOperation
        {
            Summary = string.Empty,
            Description = string.Empty,
            Responses = new OpenApiResponses
            {
                ["200"] = new OpenApiResponse
                {
                    Description = "Success"
                }
            },
            Tags = new List<OpenApiTag>
                {
                    new OpenApiTag { Name = tagName }
                }
        };

        foreach (var keyName in GetKeysName(path))
        {
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = keyName,
                AllowEmptyValue = false,
                In = ParameterLocation.Path,
                Schema = new OpenApiSchema()
                {
                    Type = "string",
                }
            });
        }

        foreach(var type in  operationTypes)
        {
            pathItem.Operations.Add(type, operation);
        }

    }

    [GeneratedRegex("{([^{}]*)}")]
    private static partial Regex KeysRegex();

    private static List<string> GetKeysName(string path)
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
