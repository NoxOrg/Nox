using System;
using System.Linq;
using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Types;
using Nox.Types.Extensions;

namespace Nox.Generator.Presentation.Api.OData;

internal class EntityDtoGenerator : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Domain;

    public void Generate(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState, GeneratorConfig config)
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
               .ToDictionary(r => r.Name, key => new { 
                   IsSimpleType = key.Type.IsSimpleType(), 
                   ComponentType = GetSingleComponentSimpleType(key),
                   IsReadable = key.Type.IsReadableType()
               });
            var primaryKeys = string.Join(", ", entity.Keys.Select(k => $"{codeGeneratorState.Solution.GetSinglePrimitiveTypeForKey(k)} key{k.Name}"));

            context.CancellationToken.ThrowIfCancellationRequested();

            new TemplateCodeBuilder(context, codeGeneratorState)
                .WithClassName($"{entity.Name}Dto")
                .WithFileNamePrefix("Dto")
                .WithObject("entity", entity)
                .WithObject("componentsInfo", componentsInfo)
                .WithObject("primaryKeys", primaryKeys)
                .WithObject("isVersioned", (entity.Persistence?.IsVersioned ?? true))
                .GenerateSourceCodeFromResource("Application.Dto.EntityDto");         
        }
    }

    private static Type? GetSingleComponentSimpleType(NoxSimpleTypeDefinition attribute)
    {
        if (!attribute.Type.IsSimpleType())
            return null;

        return attribute.Type.GetComponents(attribute).FirstOrDefault().Value;
    }
}