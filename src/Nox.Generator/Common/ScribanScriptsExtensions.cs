using System;
using System.Linq;

using Humanizer;

using Nox.Solution;
using Nox.Types;
using Nox.Types.Extensions;
using Scriban;
using Scriban.Runtime;

namespace Nox.Generator.Common;

internal static class ScribanScriptsExtensions
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

        var scriptObject8 = new ScriptObject();
        scriptObject8.Import("IsValueType", new Func<string,
            bool>(type => Type.GetType(type)?.IsValueType ?? false));

        var scriptObject9 = new ScriptObject();
        scriptObject9.Import("Pluralize", new Func<string,
            string>(name => name.Pluralize()));

		var scriptObject10 = new ScriptObject();
        scriptObject10.Import("ToLowerFirstChar", new Func<string, string>(
            input => input.ToLowerFirstChar()));

        var scriptObject11 = new ScriptObject();
        scriptObject11.Import("GetEntityNameForLocalizedType", new Func<string, string>(
            entityName => NoxCodeGenConventions.GetEntityNameForLocalizedType(entityName)));


        context.PushGlobal(scriptObject1);
        context.PushGlobal(scriptObject2);
        context.PushGlobal(scriptObject3);
        context.PushGlobal(scriptObject4);
        context.PushGlobal(scriptObject5);
        context.PushGlobal(scriptObject6);
        context.PushGlobal(scriptObject7);
        context.PushGlobal(scriptObject8);
        context.PushGlobal(scriptObject9);
        context.PushGlobal(scriptObject10);
        context.PushGlobal(scriptObject11);
    }
}