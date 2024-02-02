using Nox.Generator.Common;
using Nox.Solution;
using Nox.Types;
using Nox.Types.Extensions;
using System;
using System.Linq;

namespace Nox.Generator.Tasks.Ui.Components;

internal class AutoMapperProfileGenerator : INoxFileGenerator
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

        var templateName = @"Tasks.Ui.Profiles.AutoMapperProfile";

        var entities = codeGeneratorState.Solution.Domain.Entities
            .Where(e => !e.IsOwnedEntity);

        var compoundTypes = Enum.GetValues(typeof(NoxType))
           .Cast<NoxType>()
           .Where(noxType => noxType.IsCompoundType())
           .ToArray();

        foreach (var entity in entities)
        {
            new TaskTemplateFileBuilder(codeGeneratorState, absoluteOutputPath)
                .WithClassName($"AutoMapperProfile")
                .WithFileNamePrefix($"Ui.Profiles")
                .WithObject("entities", entities)
                .WithObject("compoundTypes", compoundTypes)
                .GenerateSourceCodeFromResource(templateName);
        }
    }
}