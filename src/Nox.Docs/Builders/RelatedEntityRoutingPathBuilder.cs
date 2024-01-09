using Nox.Solution;
using Nox.Solution.Builders;

namespace Nox.Docs.Builders;

internal class RelatedEntityRoutingPathBuilder : RelatedEntityRoutingPathBuilderBase<(string Path, List<HttpVerb> Verbs)>
{
    public RelatedEntityRoutingPathBuilder(IReadOnlyList<Entity> entities) : base(entities)
    {
    }

    public override void AddResult(List<(string Path, List<HttpVerb> Verbs)> result, Entity currentEntity, EntityRelationship relationship, string existingPath)
    {
        var navigationName = currentEntity.GetNavigationPropertyName(relationship);

        if (relationship.WithSingleEntity)
        {
            var path = $"{existingPath}/{navigationName}";
            var verbs = new List<HttpVerb> { HttpVerb.Get, HttpVerb.Post, HttpVerb.Put, HttpVerb.Patch };
            if (relationship.Relationship == EntityRelationshipType.ZeroOrOne)
                verbs.Add(HttpVerb.Delete);
            result.Add((path, verbs));

            var refPath = $"{existingPath}/{navigationName}/$ref";
            var refVerbs = new List<HttpVerb> { HttpVerb.Get };
            if (relationship.Relationship == EntityRelationshipType.ZeroOrOne)
                refVerbs.Add(HttpVerb.Delete);
            result.Add((refPath, refVerbs));

            var refPathWithKey = $"{existingPath}/{navigationName}/{{{GetKeyParameterName(navigationName)}}}/$ref";
            var refPathWithKeyVerbs = new List<HttpVerb> { HttpVerb.Post, HttpVerb.Put };
            if (relationship.Relationship == EntityRelationshipType.ZeroOrOne)
                refPathWithKeyVerbs.Add(HttpVerb.Delete);
            result.Add((refPathWithKey, refPathWithKeyVerbs));
        }
        else
        {
            var path = $"{existingPath}/{navigationName}";
            var verbs = new List<HttpVerb> { HttpVerb.Get, HttpVerb.Post, HttpVerb.Delete };
            result.Add((path, verbs));

            var pathWithKey = $"{existingPath}/{navigationName}/{{{GetKeyParameterName(navigationName)}}}";
            var pathWithKeyVerbs = new List<HttpVerb> { HttpVerb.Get, HttpVerb.Put, HttpVerb.Patch, HttpVerb.Delete };
            result.Add((pathWithKey, pathWithKeyVerbs));

            var refPath = $"{existingPath}/{navigationName}/$ref";
            var refPathVerbs = new List<HttpVerb> { HttpVerb.Get, HttpVerb.Put, HttpVerb.Delete };
            result.Add((refPath, refPathVerbs));

            var refPathWithKey = $"{existingPath}/{navigationName}/{{{GetKeyParameterName(navigationName)}}}/$ref";
            var refPathWithKeyVerbs = new List<HttpVerb> { HttpVerb.Post, HttpVerb.Put, HttpVerb.Delete };
            result.Add((refPathWithKey, refPathWithKeyVerbs));
        }
    }
}
