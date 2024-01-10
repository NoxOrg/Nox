using Nox.Generator.Common;
using Nox.Solution;
using System.Linq;

namespace Nox.Generator.Tasks.Ui.Components;

internal class NavigationMenuRazor : INoxFileGenerator
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

        var templateName = @"Ui.Components.NavigationMenuRazor";
        var entities = codeGeneratorState.Solution.Domain.Entities.Where(x => !x.IsOwnedEntity);

        new TaskTemplateFileBuilder(codeGeneratorState, absoluteOutputPath)
            .WithFileExtension("razor")
            .WithClassName($"NavigationMenu")
            .WithFileNamePrefix($"Ui.Components")
            .WithObject("entities", entities)
            .GenerateSourceCodeFromResource(templateName);
    }
}