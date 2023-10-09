using Nox.Docs.Models;
using Nox.Solution;
using Scriban;

namespace Nox.Docs.Extensions;

public static class NoxSolutionEntityIntegrationEventsMarkdownExtensions
{
    private const string ResourceName = "Nox.Docs.Templates.IntegrationEvents.template.md";

    public static MarkdownFile ToMarkdownIntegrationEvents(this NoxSolution noxSolution)
    {
        var template = ResourceName.ReadScribanTemplate();

        return CreateIntegrationEvents(template, noxSolution);
    }

    private static MarkdownFile CreateIntegrationEvents(Template template, NoxSolution noxSolution)
    {
        var model = new Dictionary<string, object>
        {
            ["solution"] = new { noxSolution.Name, noxSolution.PlatformId, noxSolution.Version },
            ["entities"] = ResolveEntities(noxSolution),
            ["customIntegrationEvents"] = ResolveCustomIntegrationEvents(noxSolution),
        };

        return new MarkdownFile
        {
            Name = $"./IntegrationEvents.md",
            Content = template.RenderScribanTemplate(model)
        };
    }

    private static IEnumerable<Entity> ResolveEntities(NoxSolution noxSolution)
        => noxSolution.Domain?.Entities?.Where(e => e.HasIntegrationEvents) ?? Array.Empty<Entity>();

    private static IEnumerable<IntegrationEvent> ResolveCustomIntegrationEvents(NoxSolution noxSolution)
        => noxSolution.Application?.IntegrationEvents ?? Array.Empty<IntegrationEvent>();
}
