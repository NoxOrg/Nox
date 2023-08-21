using System;
using Nox.Solution;
using Nox.Types;
using Nox.Types.Extensions;
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

        var scriptObject5 = new ScriptObject();
        scriptObject5.Import("IsNoxTypeReadable", new Func<NoxType,
            bool>(type => type.IsReadableType()));

        var scriptObject6 = new ScriptObject();
        scriptObject6.Import("IsNoxTypeUpdatable", new Func<NoxType,
            bool>(type => type.IsUpdatableType()));

        var scriptObject7 = new ScriptObject();
        scriptObject7.Import("IsNoxTypeSimpleType", new Func<NoxType,
            bool>(type => type.IsSimpleType()));

        context.PushGlobal(scriptObject1);
        context.PushGlobal(scriptObject2);
        context.PushGlobal(scriptObject3);
        context.PushGlobal(scriptObject4);
        context.PushGlobal(scriptObject5);
        context.PushGlobal(scriptObject6);
        context.PushGlobal(scriptObject7);
    }
}