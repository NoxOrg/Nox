using System;
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
            var attributes = entity.Attributes ?? Enumerable.Empty<NoxSimpleTypeDefinition>();
            var componentsInfo = attributes
               .ToDictionary(r => r.Name, key => new { IsSimpleType = key.Type.IsSimpleType(), ComponentType = GetSingleComponentSimpleType(key) });
           
            context.CancellationToken.ThrowIfCancellationRequested();

            new TemplateCodeBuilder(context, codeGeneratorState)
                .WithClassName($"O{entity.Name}")
                .WithFileNamePrefix("Dto")
                .WithObject("entity", entity)
                .WithObject("componentsInfo", componentsInfo)
                .WithObject("isVersioned", (entity.Persistence?.IsVersioned ?? true))
                .GenerateSourceCodeFromResource("Application.Dto.OEntity");         
        }
    }

    private static Type? GetSingleComponentSimpleType(NoxSimpleTypeDefinition attribute)
    {
        if (!attribute.Type.IsSimpleType())
            return null;

        return attribute.Type.GetComponents(attribute).FirstOrDefault().Value;
    }
}