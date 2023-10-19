using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using System.Linq;

namespace Nox.Generator.Application.Commands;

internal class NavigationMenuRazor : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Ui;

    public void Generate(
      SourceProductionContext context,
      NoxSolutionCodeGeneratorState codeGeneratorState,
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

        var templateName = @"Ui.Components.NavigationMenuRazor";
        var entities = codeGeneratorState.Solution.Domain.Entities.Where(x => !x.IsOwnedEntity);

        context.CancellationToken.ThrowIfCancellationRequested();

        new TemplateFileBuilder(codeGeneratorState, projectRootPath)
            .WithFileExtension("razor")
            .WithClassName($"NavigationMenu")
            .WithFileNamePrefix($"Ui.Components")
            .WithObject("entities", entities)
            .GenerateSourceCodeFromResource(templateName);
    }
}