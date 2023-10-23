using Microsoft.CodeAnalysis;
using Nox.Generator.Tasks.Common;
using Nox.Solution;
using System.Linq;

namespace Nox.Generator.Tasks.Ui.Components;

internal class NavigationMenuGenerator : INoxFileGenerator
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

        var templateName = @"Ui.Components.NavigationMenu";
        var entities = codeGeneratorState.Solution.Domain.Entities.Where(x => !x.IsOwnedEntity);

        new TemplateFileBuilder(codeGeneratorState, absoluteOutputPath)
            .WithFileExtension("razor.cs")
            .WithClassName($"NavigationMenu")
            .WithFileNamePrefix($"Ui.Components")
            .WithObject("entities", entities)
            .GenerateSourceCodeFromResource(templateName);
    }
}