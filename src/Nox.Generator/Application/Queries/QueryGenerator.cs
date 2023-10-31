using Microsoft.CodeAnalysis;
using Nox.Generator.Application.Commands;
using Nox.Generator.Common;
using Nox.Solution;
using System.Collections.Generic;
using System.Linq;

namespace Nox.Generator.Application.Queries;

internal class QueryGenerator : ApplicationEntityDependentGeneratorBase
{
    protected override void DoGenerate(SourceProductionContext context, NoxCodeGenConventions codeGeneratorState, IEnumerable<Entity> entities)
    {
        var templateName = @"Application.Queries.Query";

        foreach (var entity in entities.Where(x => !x.IsLocalized))
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