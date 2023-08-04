using System.Linq;
using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Types;
using Nox.Types.Extensions;

namespace Nox.Generator.Application.Dto;

internal static class EntityCreateDtoGenerator
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
                .WithClassName($"{entity.Name}CreateDto")
                .WithFileNamePrefix("Dto")
                .WithObject("entity", entity)
                .WithObject("keysFlattenComponentsTypeName", KeysFlattenComponentsTypeName)
                .GenerateSourceCodeFromResource("Application.Dto.EntityCreateDto");
        }
    }
}