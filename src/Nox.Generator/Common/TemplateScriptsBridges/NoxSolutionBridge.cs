using System;
using Nox.Solution;
using Nox.Types;
using Scriban;
using Scriban.Runtime;

namespace Nox.Generator.Common.TemplateScriptsBridges;

internal static class NoxSolutionBridge
{
    public static void AddFunctions(TemplateContext context, NoxSolution noxSolution)
    {
        var scriptObject1 = new ScriptObject();
        scriptObject1.Import("SingleKeyTypeForEntity", new Func<string,
            NoxType>(noxSolution.GetSingleKeyTypeForEntity));

        var scriptObject2 = new ScriptObject();
        scriptObject2.Import("SingleTypeForKey", new Func<NoxSimpleTypeDefinition,
            NoxType>(noxSolution.GetSingleTypeForKey));

        var scriptObject3 = new ScriptObject();
        scriptObject2.Import("SingleKeyPrimitiveTypeForEntity", new Func<string,
            string>(noxSolution.GetSingleKeyPrimitiveTypeForEntity));

        var scriptObject4 = new ScriptObject();
        scriptObject2.Import("SinglePrimitiveTypeForKey", new Func<NoxSimpleTypeDefinition,
            string>(noxSolution.GetSinglePrimitiveTypeForKey));
                
        context.PushGlobal(scriptObject1);
        context.PushGlobal(scriptObject2);
        context.PushGlobal(scriptObject3);
        context.PushGlobal(scriptObject4);
    }
}