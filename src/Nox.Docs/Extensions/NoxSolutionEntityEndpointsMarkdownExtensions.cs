using Nox.Docs.Models;
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

        var entities = noxSolution.Domain?.Entities?
            .Where(ShouldCreateMarkdown).ToArray()
            ?? Array.Empty<Entity>();

        return CreateMarkdownEntityEndpoints(template, entities);
    }

    private static bool ShouldCreateMarkdown(Entity entity)
        => !entity.IsOwnedEntity && HasAtLeastOneCrudOperationEnabled(entity);

    private static bool HasAtLeastOneCrudOperationEnabled(Entity entity)
        => entity.Persistence?.Create.IsEnabled == true
        || entity.Persistence?.Read.IsEnabled == true
        || entity.Persistence?.Update.IsEnabled == true
        || entity.Persistence?.Delete.IsEnabled == true;

    private static IEnumerable<EntityMarkdownFile> CreateMarkdownEntityEndpoints(Template template, Entity[] entities)
    {
        var markdowns = new List<EntityMarkdownFile>(entities.Length);
        
        foreach (var entity in entities)
        {
            var enumerationAttributes =
                entity
                    .Attributes
                    .Where(attribute => attribute.Type == NoxType.Enumeration)
                    .Select(attribute => new {
                        Attribute = attribute,
                        EntityNameForEnumeration = $"{entity.Name}{attribute.Name}Dto",
                        EntityNameForLocalizedEnumeration =  $"{entity.Name}{attribute.Name}LocalizedDto",
                        IsLocalized = attribute.EnumerationTypeOptions?.IsLocalized == true
                    });
            var model = new Dictionary<string, object>
            {
                ["entity"] = entity,
                ["enumerationAttributes"] = enumerationAttributes,
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
}
