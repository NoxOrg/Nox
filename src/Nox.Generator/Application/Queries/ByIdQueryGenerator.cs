using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using System.Linq;

namespace Nox.Generator.Application.Queries;

internal static class ByIdQueryGenerator
{
    public static void Generate(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGeneratorState.Solution.Domain is null)
        {
            return;
        }

        var templateName = @"Application.Queries.ByIdQuery";        
        foreach (var entity in codeGeneratorState.Solution.Domain.Entities)
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            var primaryKeys = string.Join(", ", entity.Keys.Select(k=> $"{entity.KeysFlattenComponentsType[k.Name]} {k.Name}"));

            new TemplateCodeBuilder(context, codeGeneratorState)
                .WithClassName($"Get{entity.Name}ByIdQuery")
                .WithFileNamePrefix($"Queries")
                .WithObject("entity", entity)
                .WithObject("primaryKeys", primaryKeys)
                .GenerateSourceCodeFromResource(templateName);

        }
    }
}