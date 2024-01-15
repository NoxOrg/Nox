using System;
using System.Linq;
using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Types;
using Nox.Types.Extensions;

namespace Nox.Generator.Application.Dto;

internal class EntityCreateDtoGenerator : INoxCodeGenerator
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
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGenConventions.Solution.Domain is null)
        {
            return;
        }
        foreach (var entity in codeGenConventions.Solution.Domain!.Entities.Where(entity => !entity.IsOwnedEntity))
        {
            var componentsInfo = entity.Attributes
               .ToDictionary(r => r.Name, key => new { 
                   IsSimpleType = key.Type.IsSimpleType(),
                   ComponentType = GetSingleComponentSimpleType(key)
               });

            context.CancellationToken.ThrowIfCancellationRequested();

            new TemplateCodeBuilder(context, codeGenConventions)
                .WithClassName($"{entity.Name}CreateDto")
                .WithFileNamePrefix("Application.Dto")
                .WithObject("entity", entity)
                .WithObject("componentsInfo", componentsInfo)
                .GenerateSourceCodeFromResource("Application.Dto.EntityCreateDto");
        }
    }

    private static Type? GetSingleComponentSimpleType(NoxSimpleTypeDefinition attribute)
    {
        if (!attribute.Type.IsSimpleType())
            return null;

        return attribute.Type.GetComponents(attribute).FirstOrDefault().Value;
    }
}