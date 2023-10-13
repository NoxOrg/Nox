using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Types;
using System.Linq;

namespace Nox.Generator.Application.Queries;

internal class ByIdQueryGenerator : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Domain;

    public void Generate(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState, GeneratorConfig config, string? projectRootPath)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGeneratorState.Solution.Domain is null)
        {
            return;
        }

        var templateName = @"Application.Queries.ByIdQuery";
        foreach (var entity in codeGeneratorState.Solution.Domain.Entities)
        {
            if (entity.IsOwnedEntity)
                continue;

            context.CancellationToken.ThrowIfCancellationRequested();

            var primaryKeys = string.Join(", ", entity.Keys.Select(k=> $"{codeGeneratorState.Solution.GetSinglePrimitiveTypeForKey(k)} key{k.Name}"));

            new TemplateCodeBuilder(context, codeGeneratorState)
                .WithClassName($"Get{entity.Name}ByIdQuery")
                .WithFileNamePrefix($"Application.Queries")
                .WithObject("entity", entity)
                .WithObject("primaryKeys", primaryKeys)
                .GenerateSourceCodeFromResource(templateName);
        }
    }
}