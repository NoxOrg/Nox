using Microsoft.CodeAnalysis;
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
      NoxCodeGenConventions codeGeneratorState,
      GeneratorConfig config,
      System.Action<string> log,
      string? projectRootPath
      )
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGeneratorState.Solution.Domain is null)
        {
            return;
        }

        context.CancellationToken.ThrowIfCancellationRequested();
        foreach (var entity in codeGeneratorState.Solution.Domain!.Entities)
        {
            var enumerationAttributes = entity.Attributes.Where(attribute => attribute.Type == NoxType.Enumeration);
            if(!enumerationAttributes.Any())
            {
                continue;
            }
            new TemplateCodeBuilder(context, codeGeneratorState)
            .WithClassName($"{entity.Name}Enumerations")
            .WithFileNamePrefix($"Domain")
            .WithObject("enumerationAttributes", enumerationAttributes)
            .WithObject("entity", entity)
            .GenerateSourceCodeFromResource("Domain.EntityEnumeration");
        }
    }
}