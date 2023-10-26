using Nox.Generator.Common;
using Nox.Solution;
using Scriban;
using Scriban.Parsing;
using Scriban.Runtime;
using System.Reflection;

namespace Nox.Docs.Extensions;

public static class ScribanTemplateExtensions
{
    public static Template ReadScribanTemplate(this string resourceName)
    {
        string template = ReadTemplate(resourceName);

        return Template.Parse(template);
    }

    public static string RenderScribanTemplate(this Template template, Dictionary<string, object> model)
    {
        var context = CreateTemplateContext(template, model);

        return template.Render(context);
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

        // Add custom functions
        ScribanScriptsExtensions.AddFunctions(context, new NoxSolution());

        return context;
    }

    private static ScriptObject CreateScriptObject(Dictionary<string, object> model)
    {
        var scriptObj = new ScriptObject();
        scriptObj.Import(model, renamer: member => member.Name, filter: null);

        return scriptObj;
    }
}