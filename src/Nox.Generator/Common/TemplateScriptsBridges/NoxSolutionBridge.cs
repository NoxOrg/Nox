using System;
using System.Linq;

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

        var scriptObject8 = new ScriptObject();
        scriptObject8.Import("IsValueType", new Func<string,
            bool>(type => Type.GetType(type)?.IsValueType ?? false));

        var scriptObject9 = new ScriptObject();
        scriptObject9.Import("ToLowerFirstChar", new Func<string, string>(
            input => input.ToLowerFirstChar()));

        var scriptObject10 = new ScriptObject();
        scriptObject10.Import("GetPrimaryKeys", PrimaryKeysQuery);

        var scriptObject11 = new ScriptObject();
        scriptObject11.Import("GetPrimaryKeysRoute", new Func<Entity, string>(
            input => PrimaryKeysFromRoute(input, noxSolution)));

        var scriptObject12 = new ScriptObject();
        scriptObject12.Import("EnsureEndsWith", new Func<string, string, string>(
            (input, suffix) => input.EnsureEndsWith(suffix)));

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
        context.PushGlobal(scriptObject12);
    }

    private static string PrimaryKeysQuery(Entity entity, string prefix = "key", bool withKeyName = false)
    {
        if (entity?.Keys?.Count() > 1)
        {
            return string.Join(", ", entity.Keys.Select(k => $"{prefix}{k.Name}"));
        }
        else if (entity?.Keys is not null)
        {
            return withKeyName ? $"{prefix}{entity.Keys[0].Name}" : prefix;
        }

        return string.Empty;
    }

    private static string PrimaryKeysFromRoute(Entity entity, NoxSolution solution)
    {
        if (entity?.Keys?.Count() > 1)
        {
            return string.Join(", ", entity.Keys.Select(k => $"[FromRoute] {solution.GetSinglePrimitiveTypeForKey(k)} key{k.Name}"))
                .Trim();
        }
            
        else if (entity?.Keys is not null)
        {
            return $"[FromRoute] {solution.GetSinglePrimitiveTypeForKey(entity.Keys[0])} key"
                .Trim();
        }

        return string.Empty;
    }
}