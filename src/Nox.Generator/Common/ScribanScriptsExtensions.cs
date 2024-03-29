﻿using System;
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
        scriptObject7.Import("IsNoxTypeCreatable", new Func<NoxType,
            bool>(type => type.IsCreatableType()));

        var scriptObject8 = new ScriptObject();
        scriptObject8.Import("IsNoxTypeSimpleType", new Func<NoxType,
            bool>(type => type.IsSimpleType()));

        var scriptObject9 = new ScriptObject();
        scriptObject9.Import("IsValueType", new Func<string,
            bool>(type => Type.GetType(type)?.IsValueType ?? false));

        var scriptObject10 = new ScriptObject();
        scriptObject10.Import("Pluralize", new Func<string,
            string>(name => name.Pluralize()));

		var scriptObject11 = new ScriptObject();
        scriptObject11.Import("ToLowerFirstChar", new Func<string, string>(
            input => input.ToLowerFirstChar()));

        var scriptObject12 = new ScriptObject();
        scriptObject12.Import("GetEntityNameForLocalizedType", new Func<string, string>(
            entityName => NoxCodeGenConventions.GetEntityNameForLocalizedType(entityName)));

        var scriptObject13 = new ScriptObject();
        scriptObject13.Import("GetEntityDtoNameForLocalizedType", new Func<string, string>(
            entityName => NoxCodeGenConventions.GetEntityDtoNameForLocalizedType(entityName)));

        var scriptObject14 = new ScriptObject();
        scriptObject14.Import("GetEntityUpsertDtoNameForLocalizedType", new Func<string, string>(
            entityName => NoxCodeGenConventions.GetEntityUpsertDtoNameForLocalizedType(entityName)));

        var scriptObject15 = new ScriptObject();
        scriptObject15.Import("GetNavigationPropertyName", new Func<Entity, EntityRelationship, string>(
            (entity, relationship) => entity.GetNavigationPropertyName(relationship)));

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
        context.PushGlobal(scriptObject13);
        context.PushGlobal(scriptObject14);
        context.PushGlobal(scriptObject15);
    }
}