using Microsoft.CodeAnalysis;

using Nox.Generator.Common;
using Nox.Solution;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nox.Generator.Presentation.Api.OData;

internal class EntityControllerCustomQueriesGenerator : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Presentation;

    public void Generate(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState, GeneratorConfig config, string? projectRootPath)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGeneratorState.Solution.Domain is null)
        {
            return;
        }

        const string templateName = @"Presentation.Api.OData.EntityController.CustomQueries";

        foreach (var entity in codeGeneratorState.Solution.Domain.Entities)
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            if (entity.IsOwnedEntity)
            {
                continue;
            }

            new TemplateCodeBuilder(context, codeGeneratorState)
                .WithClassName($"{entity.PluralName}Controller")
                .WithFileNamePrefix("Presentation.Api.OData")
                .WithFileNameSuffix("CustomQueries")
                .WithObject("entity", entity)
                .GenerateSourceCodeFromResource(templateName);
        }
    }
}
