using Nox.Docs.Models;
using Nox.Solution;
using Scriban;
using Scriban.Parsing;
using Scriban.Runtime;
using System.Reflection;

namespace Nox.Docs.Extensions;

public static class NoxSolutionEntityEndpointExtensions
{
    private const string ResourceName = "Nox.Docs.Templates.EntityEndpoint.template.md";

    public static EntityMarkdownFile[] ToMarkdownEntityEndpoints(this NoxSolution noxSolution)
    {
        var template = ReadScribanTemplate(ResourceName);

        var entities = noxSolution.Domain?.Entities?
            .Where(x => !x.IsOwnedEntity).ToArray() 
            ?? Array.Empty<Entity>();
        
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
                Content = RenderScribanTemplate(template, model)
            };
            markdowns.Add(markdown);
        }

        return markdowns.ToArray();
    }

    private static Template ReadScribanTemplate(string resourceName)
    {
        string template = ReadTemplate(resourceName);

        return Template.Parse(template);
    }

    private static string ReadTemplate(string resourceName)
    {
        using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName)!;
        using var reader = new StreamReader(stream);

        return reader.ReadToEnd();
    }

    private static TemplateContext CreateTemplateContext(Template strongTemplate, Dictionary<string, object> model)
    {
        var context = strongTemplate.LexerOptions.Lang == ScriptLang.Liquid
            ? new LiquidTemplateContext()
            : new TemplateContext();

        context.MemberRenamer = member => member.Name;
        context.MemberFilter = null;
        context.PushGlobal(CreateScriptObject(model));

        return context;
    }

    private static ScriptObject CreateScriptObject(Dictionary<string, object> model)
    {
        var scriptObj = new ScriptObject();
        scriptObj.Import(model, renamer: member => member.Name, filter: null);

        return scriptObj;
    }

    private static string RenderScribanTemplate(Template template, Dictionary<string, object> model)
    {
        var context = CreateTemplateContext(template, model);

        return template.Render(context);
    }
}
