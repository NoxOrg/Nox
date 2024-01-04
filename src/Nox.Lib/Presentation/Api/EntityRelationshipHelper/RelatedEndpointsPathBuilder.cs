using Microsoft.OpenApi.Models;
using Nox.Solution;

namespace Nox.Presentation.Api;

internal class RelatedEndpointsPathBuilder
{
    private readonly MultipleEdgesGraph<Entity, EntityRelationship> _graph = new();

    public RelatedEndpointsPathBuilder(IReadOnlyList<Entity> entities)
    {
        foreach (var entity in entities)
        {
            _graph.AddNode(entity);
            foreach (var relationship in entity.Relationships)
            {
                _graph.AddEdge(entity, relationship.Related.Entity, relationship);
            }
        }
    }

    public List<(string, OpenApiPathItem)> GetAllRelatedPathesForEntity(Entity startNode, int maxDepth)
    {
        var visited = new HashSet<Entity>();
        var result = new List<(string, OpenApiPathItem)>();
        GetAllRelatedPathesForEntity(startNode, maxDepth, visited, result);

        return result;
    }

    private void GetAllRelatedPathesForEntity(Entity currentNode, int maxDepth, HashSet<Entity> visited, List<(string, OpenApiPathItem)> result, int currentDepth = 0, string path = "")
    {
        visited.Add(currentNode);
        if(currentDepth == 0)
        {
            path = $"{currentNode.PluralName}/{{key}}";
        }


        if (currentDepth >= maxDepth)
        {
            return;
        }

        if (!_graph.Edges.ContainsKey(currentNode))
        {
            return;
        }

        foreach (var neighbor in _graph.Edges[currentNode].Keys)
        {
            if (!visited.Contains(neighbor))
            {
                foreach (var edge in _graph.Edges[currentNode][neighbor])
                {
                    //Validate first pair
                    if (currentDepth == 0 && !edge.ApiGenerateReferenceEndpoint && !edge.ApiGenerateRelatedEndpoint)
                        continue;

                    if (currentDepth > 0)
                        AddResult(result, currentNode, edge, path);

                    var navigationName = currentNode.GetNavigationPropertyName(edge);
                    var newPath = $"{path}/{navigationName}/{{key}}";

                    GetAllRelatedPathesForEntity(neighbor, maxDepth, visited, result, currentDepth + 1, newPath);
                }
            }
        }

        visited.Remove(currentNode);
    }

    private void AddResult(List<(string, OpenApiPathItem)> result, Entity currentEntity, EntityRelationship relationship, string existingPath)
    {
        var navigationName = currentEntity.GetNavigationPropertyName(relationship);

        if (relationship.WithSingleEntity)
        {
            var path = $"{existingPath}/{navigationName}";
            var pathItem = new OpenApiPathItem { Operations = new Dictionary<OperationType, OpenApiOperation>() };
            AddOperation(pathItem, OperationType.Get);
            AddOperation(pathItem, OperationType.Post);
            AddOperation(pathItem, OperationType.Put);
            AddOperation(pathItem, OperationType.Patch);
            if(relationship.Relationship == EntityRelationshipType.ZeroOrOne)
                AddOperation(pathItem, OperationType.Delete);
            result.Add((path, pathItem));

            var refPath = $"{existingPath}/{navigationName}/$ref";
            var refPathItem = new OpenApiPathItem { Operations = new Dictionary<OperationType, OpenApiOperation>() };
            AddOperation(refPathItem, OperationType.Get);
            if (relationship.Relationship == EntityRelationshipType.ZeroOrOne)
                AddOperation(refPathItem, OperationType.Delete);
            result.Add((refPath, refPathItem));

            var refPathWithKey = $"{existingPath}/{navigationName}/{{key}}/$ref";
            var refPathWithKeyItem = new OpenApiPathItem { Operations = new Dictionary<OperationType, OpenApiOperation>() };
            AddOperation(refPathWithKeyItem, OperationType.Post);
            AddOperation(refPathWithKeyItem, OperationType.Put);
            if (relationship.Relationship == EntityRelationshipType.ZeroOrOne)
                AddOperation(refPathWithKeyItem, OperationType.Delete);
            result.Add((refPathWithKey, refPathWithKeyItem));
        }
        else
        {
            var path = $"{existingPath}/{navigationName}";
            var pathItem = new OpenApiPathItem { Operations = new Dictionary<OperationType, OpenApiOperation>() };
            AddOperation(pathItem, OperationType.Get);
            AddOperation(pathItem, OperationType.Post);
            AddOperation(pathItem, OperationType.Delete);
            result.Add((path, pathItem));

            var pathWithKey = $"{existingPath}/{navigationName}/{{key}}";
            var pathWithKeyItem = new OpenApiPathItem { Operations = new Dictionary<OperationType, OpenApiOperation>() };
            AddOperation(pathWithKeyItem, OperationType.Get);
            AddOperation(pathWithKeyItem, OperationType.Put);
            AddOperation(pathWithKeyItem, OperationType.Patch);
            AddOperation(pathWithKeyItem, OperationType.Delete);
            result.Add((pathWithKey, pathWithKeyItem));

            var refPath = $"{existingPath}/{navigationName}/$ref";
            var refPathItem = new OpenApiPathItem { Operations = new Dictionary<OperationType, OpenApiOperation>() };
            AddOperation(refPathItem, OperationType.Get);
            AddOperation(refPathItem, OperationType.Put);
            AddOperation(refPathItem, OperationType.Delete);
            result.Add((refPath, refPathItem));

            var refPathWithKey = $"{existingPath}/{navigationName}/{{key}}/$ref";
            var refPathWithKeyItem = new OpenApiPathItem { Operations = new Dictionary<OperationType, OpenApiOperation>() };
            AddOperation(refPathWithKeyItem, OperationType.Post);
            AddOperation(refPathWithKeyItem, OperationType.Put);
            AddOperation(refPathWithKeyItem, OperationType.Delete);
            result.Add((refPathWithKey, refPathWithKeyItem));
        }
    }

    private void AddOperation(OpenApiPathItem pathItem, OperationType operationType)
    {
        pathItem.Operations.Add(operationType,
            new OpenApiOperation
            {
                Summary = string.Empty,
                Description = string.Empty,
                Responses = new OpenApiResponses
                {
                    ["200"] = new OpenApiResponse
                    {
                        Description = "Success"
                    }
                }
            });
    }
}
