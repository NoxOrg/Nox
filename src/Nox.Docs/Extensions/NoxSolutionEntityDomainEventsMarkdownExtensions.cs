using Nox.Docs.Models;
using Nox.Solution;
using Scriban;

namespace Nox.Docs.Extensions;

public static class NoxSolutionEntityDomainEventsMarkdownExtensions
{
    private const string ResourceName = "Nox.Docs.Templates.EntityDomainEvents.template.md";

    public static IEnumerable<EntityMarkdownFile> ToMarkdownEntityDomainEvents(this NoxSolution noxSolution)
    {
        var template = ResourceName.ReadScribanTemplate();

        var entities = noxSolution.Domain?.Entities?
            .Where(ShouldCreateMarkdown).ToArray()
            ?? Array.Empty<Entity>();

        return CreateMarkdownEntityEndpoints(template, entities);
    }

    private static bool ShouldCreateMarkdown(Entity entity)
        => entity.Persistence!.Create!.RaiseDomainEvents
        || entity.Persistence!.Update!.RaiseDomainEvents
        || entity.Persistence!.Delete!.RaiseDomainEvents;

    private static IEnumerable<EntityMarkdownFile> CreateMarkdownEntityEndpoints(Template template, Entity[] entities)
    {
        var markdowns = new List<EntityMarkdownFile>(entities.Length);

        foreach (var entity in entities)
        {
            var model = new Dictionary<string, object>
            {
                ["entity"] = entity,
                ["entityMembers"] = entity.GetAllMembers().Select(x => x.Value),
            };

            var markdown = new EntityMarkdownFile
            {
                EntityName = entity.Name,
                Name = $"./domainEvents/{entity.Name}DomainEvents.md",
                Content = template.RenderScribanTemplate(model)
            };

            markdowns.Add(markdown);
        }

        return markdowns;
    }
}
