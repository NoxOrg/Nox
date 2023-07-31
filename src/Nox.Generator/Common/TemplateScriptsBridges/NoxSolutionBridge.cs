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
        scriptObject1.Import("SimpleKeyTypeForEntity", new Func<string,
            NoxType>(noxSolution.GetSimpleKeyTypeForEntity));

        context.PushGlobal(scriptObject1);

        var scriptObject2 = new ScriptObject();
        scriptObject2.Import("ShouldGenerateSpecialRelationshipLogicOnThisSide", new Func<EntityRelationship, bool>(
            noxSolution.ShouldGenerateSpecialRelationshipLogicOnThisSide));

        context.PushGlobal(scriptObject2);
    }
}