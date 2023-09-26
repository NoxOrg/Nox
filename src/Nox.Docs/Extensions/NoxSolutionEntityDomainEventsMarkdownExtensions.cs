using Nox.Docs.Models;
using Nox.Solution;
using Scriban;

namespace Nox.Docs.Extensions;

public static class NoxSolutionEntityDomainEventsMarkdownExtensions
{
    private const string ResourceName = "Nox.Docs.Templates.EntityDomainEvents.template.md";
    private static readonly IEnumerable<RaiseEventsType> Events = new[] 
    { 
        RaiseEventsType.DomainEventsOnly,
        RaiseEventsType.DomainAndIntegrationEvents 
    };

    public static IEnumerable<EntityMarkdownFile> ToMarkdownEntityDomainEvents(this NoxSolution noxSolution)
    {
        var template = ResourceName.ReadScribanTemplate();

        var entities = noxSolution.Domain?.Entities?
            .Where(ShouldCreateMarkdown).ToArray()
            ?? Array.Empty<Entity>();

        return CreateMarkdownEntityEndpoints(template, entities);
    }

    private static bool ShouldCreateMarkdown(Entity entity)
        => Events.Contains(entity.Persistence!.Create!.RaiseEvents)
        || Events.Contains(entity.Persistence!.Update!.RaiseEvents)
        || Events.Contains(entity.Persistence!.Delete!.RaiseEvents);

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
