using Nox.Types;
using Scriban.Runtime;
using Scriban;
using System;
using Nox.Solution;

namespace Nox.Generator.Common.TemplateScriptsBridges
{
    internal static class NoxSolutionCodeGeneratorStateBridge
    {
        public static void AddFunctions(TemplateContext context, NoxSolutionCodeGeneratorState codeGeneratorState)
        {
            var scriptObject1 = new ScriptObject();
            scriptObject1.Import("CodeGeneratorStateGetForeignKeyPropertyName", new Func<NoxSimpleTypeDefinition,
                string>((key) => codeGeneratorState.GetForeignKeyPropertyName(key.EntityTypeOptions!.Entity)));

            context.PushGlobal(scriptObject1);
        }
    }
}