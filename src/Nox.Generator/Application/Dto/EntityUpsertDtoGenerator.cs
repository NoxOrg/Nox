﻿using System;
using System.Linq;
using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Types;
using Nox.Types.Extensions;

namespace Nox.Generator.Application.Dto;

internal class EntityUpsertDtoGenerator : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Application;

    public void Generate(
      SourceProductionContext context,
      NoxCodeGenConventions codeGeneratorState,
      GeneratorConfig config,
      Action<string> log,
      string? projectRootPath
      )
    {
        NoxSolution solution = codeGeneratorState.Solution;
        context.CancellationToken.ThrowIfCancellationRequested();

        if (solution.Domain is null || !solution.Domain.Entities.Any())
            return;

        foreach (var entity in solution.Domain!.Entities.Where(entity => entity.IsOwnedEntity))
        {
            var componentsInfo = entity.Attributes
               .ToDictionary(r => r.Name, key => new { 
                   IsSimpleType = key.Type.IsSimpleType(), 
                   ComponentType = GetSingleComponentSimpleType(key),
                   IsUpdatable = key.Type.IsUpdatableType(),
                   IsCreatable = key.Type.IsCreatableType()
               });

            context.CancellationToken.ThrowIfCancellationRequested();

            new TemplateCodeBuilder(context, codeGeneratorState)
                .WithClassName($"{entity.Name}UpsertDto")
                .WithFileNamePrefix("Application.Dto")
                .WithObject("entity", entity)
                .WithObject("componentsInfo", componentsInfo)
                .GenerateSourceCodeFromResource("Application.Dto.EntityUpsertDto");
        }
    }

    private static Type? GetSingleComponentSimpleType(NoxSimpleTypeDefinition attribute)
    {
        if (!attribute.Type.IsSimpleType())
            return null;

        return attribute.Type.GetComponents(attribute).FirstOrDefault().Value;
    }
}