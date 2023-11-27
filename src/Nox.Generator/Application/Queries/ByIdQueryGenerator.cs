using Microsoft.CodeAnalysis;
using Nox.Generator.Application.Commands;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Types;
using System.Collections.Generic;
using System.Linq;

namespace Nox.Generator.Application.Queries;

internal class ByIdQueryGenerator : ApplicationEntityDependentGeneratorBase
{
    protected override void DoGenerate(SourceProductionContext context, NoxCodeGenConventions codeGeneratorState, IEnumerable<Entity> entities)
    {
        var templateName = @"Application.Queries.ByIdQuery";
        foreach (var entity in entities.Where(e => !e.IsLocalized && !e.HasLocalizedOwnedRelationships && !e.IsOwnedEntity))
        {
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