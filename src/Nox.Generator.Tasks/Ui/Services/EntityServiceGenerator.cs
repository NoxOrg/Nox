﻿using Nox.Generator.Common;
using Nox.Solution;
using System.Linq;

namespace Nox.Generator.Tasks.Ui.Components;

internal class EntityServiceGenerator : INoxFileGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Ui;

    public void Generate(
      NoxCodeGenConventions codeGeneratorState,
      GeneratorConfig config,
      System.Action<string> log,
      string absoluteOutputPath
      )
    {
        if (codeGeneratorState.Solution.Domain is null)
        {
            return;
        }

        var templateName = @"Tasks.Ui.Services.EntityService";
        var entities = codeGeneratorState.Solution.Domain.Entities
            .Where(e => !e.IsOwnedEntity)
            .OrderBy(e => e.PluralName);

        foreach (var entity in entities)
        {
            new TaskTemplateFileBuilder(codeGeneratorState, absoluteOutputPath)
                .WithClassName($"{entity.PluralName}Service")
                .WithFileNamePrefix($"Ui.Services")
                .WithObject("entity", entity)
                .GenerateSourceCodeFromResource(templateName);
        }
    }
}