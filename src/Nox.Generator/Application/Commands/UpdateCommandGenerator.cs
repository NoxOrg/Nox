using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using System.Collections.Generic;
using System.Linq;

namespace Nox.Generator.Application.Commands;

internal class UpdateCommandGenerator : ApplicationEntityDependentGeneratorBase
{
    protected override void DoGenerate(SourceProductionContext context, NoxCodeGenConventions codeGeneratorState, IEnumerable<Entity> entities)
    {
        var templateName = @"Application.Commands.UpdateCommand";

        foreach (var entity in entities.Where(x => !x.IsOwnedEntity))
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            var primaryKeys = string.Join(", ", entity.Keys.Select(k => $"{codeGeneratorState.Solution.GetSinglePrimitiveTypeForKey(k)} key{k.Name}"));
            var primaryKeysFindQuery = string.Join(", ", entity.Keys.Select(k => $"key{k.Name}"));
            var primaryKeysReturnQuery = string.Join(", ", entity.Keys.Select(k => $"entity.{k.Name}.Value"));
            var relatedEntities = entity.Relationships.GroupBy(r => r.Entity).Select(g => g.First().Entity).ToList();

            new TemplateCodeBuilder(context, codeGeneratorState)
                .WithClassName($"Update{entity.Name}Command")
                .WithFileNamePrefix($"Application.Commands")
                .WithObject("entity", entity)
                .WithObject("relatedEntities", relatedEntities)
                .WithObject("primaryKeys", primaryKeys)
                .WithObject("primaryKeysFindQuery", primaryKeysFindQuery)
                .WithObject("primaryKeysReturnQuery", primaryKeysReturnQuery)
                .GenerateSourceCodeFromResource(templateName);
        }
    }
}