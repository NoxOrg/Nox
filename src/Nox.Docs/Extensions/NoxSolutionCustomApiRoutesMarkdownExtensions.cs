using Nox.Docs.Models;
using Nox.Solution;
using Scriban;

namespace Nox.Docs.Extensions;

public static class NoxSolutionCustomApiRoutesMarkdownExtensions
{
    private const string ResourceName = "Nox.Docs.Templates.CustomApiRoutes.template.md";

    public static MarkdownFile ToMarkdownCustomApiRoutes(this NoxSolution noxSolution)
    {
        var template = ResourceName.ReadScribanTemplate();

        return CreateCustomApiRoutes(template, noxSolution);
    }

    private static MarkdownFile CreateCustomApiRoutes(Template template, NoxSolution noxSolution)
    {
        var model = new Dictionary<string, object>
        {
            ["apiRoutePrefix"] = noxSolution.Presentation.ApiConfiguration.ApiRoutePrefix,
            ["apiRoutes"] = noxSolution.Presentation.ApiConfiguration.ApiRouteMappings,
        };

        return new MarkdownFile
        {
            Name = $"./CustomApiRoutes.md",
            Content = template.RenderScribanTemplate(model)
        };
    }
}
