using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using System.Linq;

namespace Nox.Generator.Application.Commands;

internal class NavigationMenuRazorGenerator : INoxFileGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Ui;

    public void Generate(NoxSolutionCodeGeneratorState codeGeneratorState, string? projectRootPath)
    {
        if (codeGeneratorState.Solution.Domain is null)
        {
            return;
        }

        var templateName = @"Ui.Components.NavigationMenuRazor";
        var entities = codeGeneratorState.Solution.Domain.Entities.Where(x => !x.IsOwnedEntity);

        new TemplateFileBuilder(codeGeneratorState, projectRootPath)
            .WithFileExtension("razor")
            .WithClassName($"NavigationMenu")
            .WithFileNamePrefix($"Ui.Components")
            .WithObject("entities", entities)
            .GenerateSourceCodeFromResource(templateName);
    }
}