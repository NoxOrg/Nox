using System;
using System.Linq;
using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Types;
using Nox.Types.Extensions;

namespace Nox.Generator.Application.Dto;

internal class EntityPartialUpdateDtoGenerator : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Domain;

    public void Generate(
      SourceProductionContext context,
      NoxCodeGenConventions codeGenConventions,
      GeneratorConfig config,
      System.Action<string> log,
      string? projectRootPath
      )
    {
        NoxSolution solution = codeGenConventions.Solution;
        context.CancellationToken.ThrowIfCancellationRequested();

        if (solution.Domain is null ||
            !solution.Domain.Entities.Any())
        {
            return;
        }
        foreach (var entity in solution.Domain!.Entities.Where(entity => !entity.IsOwnedEntity))
        {
            var componentsInfo = entity.Attributes
               .ToDictionary(r => r.Name, key => new { 
                   IsSimpleType = key.Type.IsSimpleType(), 
                   ComponentType = GetSingleComponentSimpleType(key),
                   IsUpdatable = key.Type.IsUpdatableType()
               });

            context.CancellationToken.ThrowIfCancellationRequested();

            new TemplateCodeBuilder(context, codeGenConventions)
                .WithClassName($"{entity.Name}PartialUpdateDto")
                .WithFileNamePrefix("Application.Dto")
                .WithObject("entity", entity)
                .WithObject("componentsInfo", componentsInfo)
                .GenerateSourceCodeFromResource("Application.Dto.EntityPartialUpdateDto");
        }
    }

    private static Type? GetSingleComponentSimpleType(NoxSimpleTypeDefinition attribute)
    {
        if (!attribute.Type.IsSimpleType())
            return null;

        return attribute.Type.GetComponents(attribute).FirstOrDefault().Value;
    }
}