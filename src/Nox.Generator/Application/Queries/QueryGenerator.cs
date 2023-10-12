using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Nox.Generator.Application.Commands;
using Nox.Generator.Common;
using Nox.Solution;

namespace Nox.Generator.Application.Queries;

internal class QueryGenerator : ApplicationGeneratorBase
{
    protected override void DoGenerate(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState, IEnumerable<Entity> entities)
    {
        var templateName = @"Application.Queries.Query";

        foreach (var entity in entities)
        {
            if (entity.IsOwnedEntity)
                continue;

            context.CancellationToken.ThrowIfCancellationRequested();

            new TemplateCodeBuilder(context, codeGeneratorState)
                .WithClassName($"Get{entity.PluralName}Query")
                .WithFileNamePrefix($"Application.Queries")
                .WithObject("entity", entity)
                .GenerateSourceCodeFromResource(templateName);
        }
    }
}