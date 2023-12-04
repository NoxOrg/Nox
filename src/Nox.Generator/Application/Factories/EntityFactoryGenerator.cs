using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Types;
using Nox.Types.Extensions;
using System;
using System.Linq;

namespace Nox.Generator.Application.Factories;

internal class EntityFactoryGenerator : INoxCodeGenerator
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

        var templateName = @"Application.Factories.EntityFactory";
        foreach (var entity in codeGeneratorState.Solution.Domain.Entities)
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            var componentsInfo = entity.Attributes
               .ToDictionary(r => r.Name, key => new {
                   IsSimpleType = key.Type.IsSimpleType(),
                   ComponentType = GetSingleComponentSimpleType(key)
               });

            new TemplateCodeBuilder(context, codeGeneratorState)
                .WithClassName($"{entity.Name}Factory")
                .WithFileNamePrefix($"Application.Factories")
                .WithObject("entity", entity)
                .WithObject("componentsInfo", componentsInfo)
                .GenerateSourceCodeFromResource(templateName);
        }
    }

    private static Type? GetSingleComponentSimpleType(NoxSimpleTypeDefinition attribute)
    {
        if (!attribute.Type.IsSimpleType())
            return null;

        return attribute.Type.GetComponents(attribute).FirstOrDefault().Value;
    }
}