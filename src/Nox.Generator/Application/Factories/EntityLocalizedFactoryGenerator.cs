﻿using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using System.Linq;

namespace Nox.Generator.Application.Factories;

internal class EntityLocalizedFactoryGenerator : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Domain;

    public void Generate(
      SourceProductionContext context,
      NoxCodeGenConventions codeGeneratorState,
      GeneratorConfig config,
      System.Action<string> log,
      string? projectRootPath)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGeneratorState.Solution.Domain is null)
        {
            return;
        }

        foreach (var entity in codeGeneratorState.Solution.Domain.Entities.Where(e => e.ShouldBeLocalized))
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            new TemplateCodeBuilder(context, codeGeneratorState)
                .WithFileNamePrefix("Application.Factories")
                .WithClassName($"{entity.Name}LocalizedFactory")
                .WithObject("entity", entity)
                .WithObject("localizedEntityName", $"{entity.Name}Localized")
                .WithObject("localizedEntityAttributes", entity.GetAttributesToLocalize())
                .GenerateSourceCodeFromResource("Application.Factories.EntityLocalizedFactory");
        }
    }
}