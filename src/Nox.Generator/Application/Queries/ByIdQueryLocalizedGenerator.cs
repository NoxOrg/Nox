using Microsoft.CodeAnalysis;
using Nox.Generator.Application.Commands;
using Nox.Generator.Common;
using Nox.Solution;
using System.Collections.Generic;
using System.Linq;

namespace Nox.Generator.Application.Queries;

internal class ByIdQueryLocalizedGenerator : ApplicationEntityDependentGeneratorBase
{
    protected override void DoGenerate(SourceProductionContext context, NoxCodeGenConventions codeGeneratorState, IEnumerable<Entity> entities)
    {
        var templateName = @"Application.Queries.ByIdQueryLocalized";
        foreach (var entity in entities.Where(x => x.IsLocalized))
        {
            if (entity.IsOwnedEntity)
                continue;

            context.CancellationToken.ThrowIfCancellationRequested();

            var primaryKeys = string.Join(", ", entity.Keys.Select(k => $"{codeGeneratorState.Solution.GetSinglePrimitiveTypeForKey(k)} key{k.Name}"));

            new TemplateCodeBuilder(context, codeGeneratorState)
                .WithClassName($"Get{entity.Name}ByIdQuery")
                .WithFileNamePrefix($"Application.Queries")
                .WithObject("entity", entity)
                .WithObject("primaryKeys", primaryKeys)
                .GenerateSourceCodeFromResource(templateName);
        }
    }
}