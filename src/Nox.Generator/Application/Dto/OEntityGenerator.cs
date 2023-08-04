using System.Linq;
using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Types;
using Nox.Types.Extensions;

namespace Nox.Generator.Presentation.Api.OData;

internal static class OEntityGenerator
{
    public static void Generate(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState)
    {
        NoxSolution solution = codeGeneratorState.Solution;
        context.CancellationToken.ThrowIfCancellationRequested();

        if (solution.Domain is null ||
            !solution.Domain.Entities.Any())
        {
            return;
        }
        foreach (var entity in codeGeneratorState.Solution.Domain!.Entities)
        {
            var KeysFlattenComponentsTypeName = entity
                .Keys
                .Concat(entity.Attributes ?? Enumerable.Empty<NoxSimpleTypeDefinition>())
                .ToDictionary(x => x.Name, key1 => key1.Type.GetComponents(key1).First().Value.Name);

            context.CancellationToken.ThrowIfCancellationRequested();

            new TemplateCodeBuilder(context, codeGeneratorState)
                .WithClassName($"O{entity.Name}")
                .WithFileNamePrefix("Dto")
                .WithObject("entity", entity)
                .WithObject("keysFlattenComponentsTypeName", KeysFlattenComponentsTypeName)
                .WithObject("isVersioned", (entity.Persistence?.IsVersioned ?? true))
                .GenerateSourceCodeFromResource("Application.Dto.OEntity");         
        }
    }
}