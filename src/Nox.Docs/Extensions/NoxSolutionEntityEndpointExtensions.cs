using Nox.Docs.Models;
using Nox.Solution;
using Scriban;

namespace Nox.Docs.Extensions;

public static class NoxSolutionEntityEndpointExtensions
{
    private const string ResourceName = "Nox.Docs.Templates.EntityEndpoint.template.md";

    public static IEnumerable<EntityMarkdownFile> ToMarkdownEntityEndpoints(this NoxSolution noxSolution)
    {
        var template = ResourceName.ReadScribanTemplate();

        var entities = noxSolution.Domain?.Entities?
            .Where(x => !x.IsOwnedEntity).ToArray()
            ?? Array.Empty<Entity>();

        return CreateMarkdownEntityEndpoints(template, entities);
    }

    private static IEnumerable<EntityMarkdownFile> CreateMarkdownEntityEndpoints(Template template, Entity[] entities)
    {
        var markdowns = new List<EntityMarkdownFile>(entities.Length);
        
        foreach (var entity in entities)
        {
            var model = new Dictionary<string, object>
            {
                ["entity"] = entity
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
