using System;
using Humanizer;
using Scriban;
using Scriban.Runtime;

namespace Nox.Generator.Common.TemplateScriptsBridges;

internal static class HelpersBridge
{
    public static void AddFunctions(TemplateContext context)
    {
        var scriptObject1 = new ScriptObject();
        scriptObject1.Import("Pluralize", new Func<string,
            string>(s => s.Pluralize()));

        context.PushGlobal(scriptObject1);

    }
}