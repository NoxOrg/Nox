using Nox.Solution.Builders;

namespace Nox.Solution.Tests.RelatedEntityRoutingTests;

internal class RelatedEntityRoutingPathBuilder : RelatedEntityRoutingPathBuilderBase<string>
{
    public RelatedEntityRoutingPathBuilder(IReadOnlyList<Entity> entities) : base(entities)
    {
    }

    public override void AddResult(List<string> result, Entity currentEntity, EntityRelationship relationship, string existingPath)
    {
        var navigationName = currentEntity.GetNavigationPropertyName(relationship);
        var pathWithKey = $"{existingPath}/{navigationName}/{{{GetKeyParameterName(navigationName)}}}";
        result.Add(pathWithKey);
    }
}
