using System.Collections.Generic;

namespace Nox.Solution.Builders;

public abstract class RelatedEntityRoutingPathBuilderBase<T>
{
    private readonly MultipleEdgesGraph<Entity, EntityRelationship> _graph = new();

    protected RelatedEntityRoutingPathBuilderBase(IReadOnlyList<Entity> entities)
    {
        foreach (var entity in entities)
        {
            _graph.TryAddNode(entity);
            foreach (var relationship in entity.Relationships)
            {
                _graph.TryAddNode(entity);
                _graph.AddEdge(entity, relationship.Related.Entity, relationship);
            }
        }
    }

    public abstract void AddResult(List<T> result, Entity currentEntity, EntityRelationship relationship, string existingPath);

    public List<T> GetAllRelatedPathsForEntity(Entity startNode, int maxDepth)
    {
        var visited = new HashSet<Entity>();
        var result = new List<T>();
        GetAllRelatedPathsForEntity(startNode, maxDepth, visited, result);

        return result;
    }

#pragma warning disable S3776 // Cognitive Complexity of methods should not be too high
    private void GetAllRelatedPathsForEntity(Entity entity, int maxDepth, HashSet<Entity> visited, List<T> result, int currentDepth = 0, string path = "")
#pragma warning restore S3776 // Cognitive Complexity of methods should not be too high
    {
        visited.Add(entity);
        if(currentDepth == 0)
        {
            path = $"{entity.PluralName}/{{{GetKeyParameterName(entity.PluralName)}}}";
        }


        if (currentDepth >= maxDepth)
        {
            return;
        }

        if(!_graph.TryGetNodeValue(entity, out var entityValue))
        {
            return;
        }

        foreach (var relatedEntity in entityValue.Keys)
        {
            if (!visited.Contains(relatedEntity))
            {
                foreach (var relationship in _graph.GetEdges(entity, relatedEntity))
                {
                    if (!IsPairValid(currentDepth, relationship))
                        continue;

                    if (currentDepth > 0)
                        AddResult(result, entity, relationship, path);

                    var navigationName = entity.GetNavigationPropertyName(relationship);
                    var newPath = $"{path}/{navigationName}/{{{GetKeyParameterName(navigationName)}}}";

                    GetAllRelatedPathsForEntity(relatedEntity, maxDepth, visited, result, currentDepth + 1, newPath);
                }
            }
        }

        visited.Remove(entity);
    }

    protected static string GetKeyParameterName(string navigationName)
    {
        return char.ToLower(navigationName[0]) + navigationName.Substring(1) + "Key";
    }

    private static bool IsPairValid(int currentDepth, EntityRelationship relationship)
    {
        if (currentDepth == 0)
            return relationship.ApiGenerateReferenceEndpoint || relationship.ApiGenerateRelatedEndpoint;

        return true;
    }
}
