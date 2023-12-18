﻿using Nox.Docs.Models;
using Nox.Solution;
using Nox.Types;
using Scriban;

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

        foreach (var entity in entities)
        {
            var model = new Dictionary<string, object>
            {
                ["apiRoutePrefix"] = apiRoutePrefix,
                ["entity"] = entity,
                ["enumerationAttributes"] = entity.GetEnumerationAttributes(),
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
            IsLocalized = attribute.EnumerationTypeOptions?.IsLocalized == true
        });
}
