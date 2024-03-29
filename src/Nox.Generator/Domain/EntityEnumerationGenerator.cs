﻿using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Types;
using System.Linq;

namespace Nox.Generator.Application.Dto;

internal class EntityEnumerationGenerator : INoxCodeGenerator
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

        context.CancellationToken.ThrowIfCancellationRequested();
        foreach (var entity in codeGenConventions.Solution.Domain!.Entities)
        {
            var enumerationAttributes = 
                entity
                .Attributes
                .Where(attribute => attribute.Type == NoxType.Enumeration)
                .Select(attribute => new { 
                    Attribute = attribute, 
                    EntityNameForEnumeration = codeGenConventions.GetEntityNameForEnumeration(entity.Name, attribute.Name), 
                    EntityNameForLocalizedEnumeration = codeGenConventions.GetEntityNameForEnumerationLocalized(entity.Name, attribute.Name)
                });
            if(!enumerationAttributes.Any())
            {
                continue;
            }
            new TemplateCodeBuilder(context, codeGenConventions)
            .WithClassName($"{entity.Name}Enumerations")
            .WithFileNamePrefix($"Domain")
            .WithObject("enumerationAttributes", enumerationAttributes)
            .WithObject("entity", entity)
            .GenerateSourceCodeFromResource("Domain.EntityEnumeration");
        }
    }
}