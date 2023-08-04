using System.Linq;
using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Types;
using Nox.Types.Extensions;

namespace Nox.Generator.Presentation.Api.OData;

internal static class ODataModelGenerator
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
                .WithFileNamePrefix("OData")
                .WithObject("entity", entity)
                .WithObject("keysFlattenComponentsTypeName", KeysFlattenComponentsTypeName)
                .WithObject("isVersioned", (entity.Persistence?.IsVersioned ?? true))
                .GenerateSourceCodeFromResource("Presentation.Api.OData.Templates.ODataModel");

            new TemplateCodeBuilder(context, codeGeneratorState)
                .WithClassName($"{entity.Name}Dto")
                .WithFileNamePrefix("OData")
                .WithObject("entity", entity)
                .WithObject("keysFlattenComponentsTypeName", KeysFlattenComponentsTypeName)
                .GenerateSourceCodeFromResource("Presentation.Api.OData.Templates.ODataDtoModel");
        }
    }
}