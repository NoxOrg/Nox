using System.Collections.Generic;
using System.Linq;
using Humanizer;
using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Types;

namespace Nox.Generator.Domain.ModelGenerator;

internal static class EntitiesGenerator
{
    public static void Generate(
        SourceProductionContext context,
        NoxSolutionCodeGeneratorState codeGeneratorState)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGeneratorState.Solution.Domain is null) return;

        foreach (var entity in codeGeneratorState.Solution.Domain.Entities)
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            new TemplateCodeBuilder(context, codeGeneratorState)
                .WithClassName(entity.Name)
                .WithObject("entity", entity)
                .WithObject("isVersioned", (entity.Persistence?.IsVersioned ?? true))
                .GenerateSourceCodeFromResource("Domain.ModelGenerator.Entity");
        }
    }
}
