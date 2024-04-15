using Nox.Docs.Builders;
using Nox.Docs.Models;
using Nox.Solution;
using Nox.Solution.Extensions;
using Nox.Types;
using Scriban;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nox.Docs.Extensions;

public static class NoxSolutionEntityEndpointsMarkdownExtensions
{
    private const string ResourceName = "Nox.Docs.Templates.EntityEndpoints.template.md";

    public static IEnumerable<EntityMarkdownFile> ToMarkdownEntityEndpoints(this NoxSolution noxSolution)
    {
        var template = ResourceName.ReadScribanTemplate();

        return CreateMarkdownEntityEndpoints(template, noxSolution);
    }

    private static IEnumerable<EntityMarkdownFile> CreateMarkdownEntityEndpoints(Template template, NoxSolution noxSolution)
    {
        var apiRoutePrefix = noxSolution.Presentation.ApiConfiguration.ApiRoutePrefix;
        var entities = noxSolution.GetEntitiesForEndpointsMarkdown();

        var markdowns = new List<EntityMarkdownFile>(entities.Count());

        var pathBuilder = new RelatedEntityRoutingPathBuilder(entities.ToList());
        var maxDepth = noxSolution.Presentation.ApiConfiguration.ApiGenerateRelatedEndpointsMaxDepth;

        foreach (var entity in entities)
        {
            var relatedEndpoints = pathBuilder.GetAllRelatedPathsForEntity(entity, maxDepth);
            var ownedEntitiesWithLocalizedAttributes = entity.OwnedRelationships
                .Select(x => new
                {
                    IsWithMultiEntity = x.WithMultiEntity,
                    OwnedEntity = x.Related.Entity,
                    LocalizedAttributes = x.Related.Entity.GetLocalizedAttributes(),
                });

            var ownedRelationshipsWithEnumerationAttributes = entity.OwnedRelationships.Select(x => new
            {
                IsWithMultiEntity = x.WithMultiEntity,
                OwnedEntity = x.Related.Entity,
                EnumerationAttributes = x.Related.Entity.GetEnumerationAttributes()
            });

            var model = new Dictionary<string, object>
            {
                ["apiRoutePrefix"] = apiRoutePrefix,
                ["entity"] = entity,
                ["enumerationAttributes"] = entity.GetEnumerationAttributes(),
                ["ownedRelationshipsWithEnumerationAttributes"] = ownedRelationshipsWithEnumerationAttributes,
                ["ownedLocalizedRelationships"] = ownedEntitiesWithLocalizedAttributes,
                ["relatedEndpoints"] = relatedEndpoints
            };

            var markdown = new EntityMarkdownFile
            {
                EntityName = entity.Name,
                Name = $"./endpoints/{entity.Name}Endpoints.md",
                Content = template.RenderScribanTemplate(model)
            };

            markdowns.Add(markdown);
        }

        return markdowns;
    }

    private static IEnumerable<Entity> GetEntitiesForEndpointsMarkdown(this NoxSolution noxSolution)
        => noxSolution.Domain?.Entities?.Where(ShouldCreateMarkdown) ?? Array.Empty<Entity>();

    private static bool ShouldCreateMarkdown(Entity entity)
        => !entity.IsOwnedEntity && HasAtLeastOneCrudOperationEnabled(entity);

    private static bool HasAtLeastOneCrudOperationEnabled(Entity entity)
        => entity.Persistence?.Create.IsEnabled == true
        || entity.Persistence?.Read.IsEnabled == true
        || entity.Persistence?.Update.IsEnabled == true
        || entity.Persistence?.Delete.IsEnabled == true;

    private static IEnumerable<object> GetEnumerationAttributes(this Entity entity)
        => entity.Attributes
        .Where(attribute => attribute.Type == NoxType.Enumeration)
        .Select(attribute => new
        {
            Attribute = attribute,
            EntityNameForEnumeration = $"{entity.Name}{attribute.Name}Dto",
            EntityNameForLocalizedEnumeration = $"{entity.Name}{attribute.Name}LocalizedDto",
            IsLocalized = attribute.EnumerationTypeOptions?.IsLocalized == true,
            EntityDtoNameForUpsertLocalizedEnumeration = $"{entity.Name}{attribute.Name}UpsertLocalizedDto"
        });
}
