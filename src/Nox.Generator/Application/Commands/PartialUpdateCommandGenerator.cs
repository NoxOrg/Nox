using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using System.Collections.Generic;
using System.Linq;

namespace Nox.Generator.Application.Commands;

internal class PartialUpdateCommandGenerator : ApplicationEntityDependentGeneratorBase
{
    protected override void DoGenerate(SourceProductionContext context, NoxCodeGenConventions codeGeneratorState, IEnumerable<Entity> entities)
    {
        var templateName = @"Application.Commands.PartialUpdateCommand";
        foreach (var entity in entities.Where(x => !x.IsOwnedEntity))
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            var primaryKeys = string.Join(", ", entity.Keys.Select(k => $"{codeGeneratorState.Solution.GetSinglePrimitiveTypeForKey(k)} key{k.Name}"));
            var primaryKeysFindQuery = string.Join(", ", entity.Keys.Select(k => $"key{k.Name}"));
            var primaryKeysReturnQuery = string.Join(", ", entity.Keys.Select(k => $"entity.{k.Name}.Value"));

            new TemplateCodeBuilder(context, codeGeneratorState)
                .WithClassName($"PartialUpdate{entity.Name}Command")
                .WithFileNamePrefix($"Application.Commands")
                .WithObject("entity", entity)
                .WithObject("primaryKeys", primaryKeys)
                .WithObject("primaryKeysFindQuery", primaryKeysFindQuery)
                .WithObject("primaryKeysReturnQuery", primaryKeysReturnQuery)
                .GenerateSourceCodeFromResource(templateName);
        }
    }
}