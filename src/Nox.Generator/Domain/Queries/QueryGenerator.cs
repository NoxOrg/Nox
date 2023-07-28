﻿using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;

namespace Nox.Generator.Domain.Queries;

internal static class QueryGenerator
{
    public static void Generate(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGeneratorState.Solution.Domain is null)
        {
            return;
        }

        var templateName = @"Domain.Queries.Query";

        foreach (var entity in codeGeneratorState.Solution.Domain.Entities)
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            new TemplateCodeBuilder(context, codeGeneratorState)
                .WithClassName($"Get{entity.PluralName}Query")
                .WithObject("entity", entity)                
                .GenerateSourceCodeFromResource(templateName);
        }
    }
}