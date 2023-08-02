using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;

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

            new TemplateCodeBuilder(context, codeGeneratorState)
                .WithClassName($"Get{entity.Name}ByIdQuery")
                .WithFileNamePrefix($"Queries")
                .WithObject("entity", entity)
                .WithObject("isVersioned", (entity.Persistence?.IsVersioned ?? true))
                .GenerateSourceCodeFromResource(templateName);

        }
    }
}