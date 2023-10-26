﻿using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Types;
using Nox.Types.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Nox.Generator.Application.Dto;

internal class EntityEnumerationGenerator : INoxCodeGenerator
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
                    EntityNameForEnumeration = noxCodeGenCodeConventions.GetEntityNameForEnumType(entity.Name, attribute.Name), 
                    EntityNameForLocalizedEnumeration = noxCodeGenCodeConventions.GetEntityNameForLocalizedEnumType(entity.Name, attribute.Name)
                });
            if(!enumerationAttributes.Any())
            {
                continue;
            }
            new TemplateCodeBuilder(context, noxCodeGenCodeConventions)
            .WithClassName($"{entity.Name}Enumerations")
            .WithFileNamePrefix($"Domain")
            .WithObject("enumerationAttributes", enumerationAttributes)
            .WithObject("entity", entity)
            .GenerateSourceCodeFromResource("Domain.EntityEnumeration");
        }
    }
}