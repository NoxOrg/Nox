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
            ["integrationEvents"] = ResolveAllIntegrationEvents(noxSolution)
                .ToDictionary(e => e.Topic),
        };

        return new MarkdownFile
        {
            Name = $"./IntegrationEvents.md",
            Content = template.RenderScribanTemplate(model)
        };
    }

    private static IEnumerable<IntegrationEventMarkdownEntry> ResolveAllIntegrationEvents(NoxSolution noxSolution)
    {
        var defaultIntegrationEvents = noxSolution.Domain?.Entities?
            .Where(ShouldCreateMarkdown)
            .Select(ToIntegrationEvent)
            ?? Array.Empty<IntegrationEventMarkdownEntry>();

        var customIntegrationEvents = noxSolution.Application?.IntegrationEvents?
            .Select(ToIntegrationEvent)
            ?? Array.Empty<IntegrationEventMarkdownEntry>();

        return defaultIntegrationEvents.Concat(customIntegrationEvents);
    }

    private static bool ShouldCreateMarkdown(Entity entity)
        => entity.Persistence!.Create!.RaiseIntegrationEvents
        || entity.Persistence!.Update!.RaiseIntegrationEvents
        || entity.Persistence!.Delete!.RaiseIntegrationEvents;

    private static IntegrationEventMarkdownEntry ToIntegrationEvent(Entity entity)
    {
        return new()
        {
            Topic = "Default",
            Name = entity.Name,
            Attributes = entity.Attributes
        };
    }

    private static IntegrationEventMarkdownEntry ToIntegrationEvent(IntegrationEvent integrationEvent)
    {
        return new()
        {
            Topic = "Custom",
            Name = integrationEvent.Name,
            Attributes = integrationEvent.ObjectTypeOptions?.Attributes 
                ?? Array.Empty<Types.NoxSimpleTypeDefinition>(),
        };
    }

    class IntegrationEventMarkdownEntry
    {
        public string? Topic { get; init; }
        public string? Name { get; init; }
        public IEnumerable<Types.NoxSimpleTypeDefinition> Attributes { get; init; } = Array.Empty<Types.NoxSimpleTypeDefinition>();
    }
}
