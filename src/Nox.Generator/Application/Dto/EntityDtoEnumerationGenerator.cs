﻿using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Types;
using System.Linq;

namespace Nox.Generator.Application.Dto;

internal class EntityDtoEnumerationGenerator : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Domain;

    public void Generate(
      SourceProductionContext context,
      NoxCodeGenConventions noxCodeGenCodeConventions,
      GeneratorConfig config,
      System.Action<string> log,
      string? projectRootPath
      )
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (noxCodeGenCodeConventions.Solution.Domain is null)
        {
            return;
        }

        context.CancellationToken.ThrowIfCancellationRequested();
        foreach (var entity in noxCodeGenCodeConventions.Solution.Domain!.Entities)
        {
            var enumerationAttributes = 
                entity
                .Attributes
                .Where(attribute => attribute.Type == NoxType.Enumeration)
                .Select(attribute => new { 
                    Attribute = attribute, 
                    EntityNameForEnumeration = noxCodeGenCodeConventions.GetEntityNameForEnumeration(entity.Name, attribute.Name) + "Dto", 
                    EntityNameForLocalizedEnumeration = noxCodeGenCodeConventions.GetEntityNameForEnumerationLocalized(entity.Name, attribute.Name) + "Dto"
                });
            if(!enumerationAttributes.Any())
            {
                continue;
            }
            new TemplateCodeBuilder(context, noxCodeGenCodeConventions)
            .WithClassName($"{entity.Name}EnumerationsDto")
            .WithFileNamePrefix("Application.Dto")
            .WithObject("enumerationAttributes", enumerationAttributes)
            .WithObject("entity", entity)
            .GenerateSourceCodeFromResource("Application.Dto.EntityDtoEnumeration");
        }
    }
}