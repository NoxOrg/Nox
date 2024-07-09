using Nox.Generator.Common;
using Nox.Solution;
using System.Linq;

namespace Nox.Generator.Tasks.Ui.Pages;

internal class EntityPageRazorGenerator : INoxFileGenerator
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

        var templateName = @"Tasks.Ui.Pages.EntityPageRazor";
        var entities = codeGeneratorState.Solution.Domain.Entities
            .Where(e => !e.IsOwnedEntity && e.Persistence.Read.IsEnabled)
            .OrderBy(e => e.PluralName);

        foreach (var entity in entities)
        {
            var getSearchEnabled = entity.Attributes
                .Any(a => a.UserInterface?.CanSearch == true);

            var getSearchFilterEnabled = entity.Attributes
                .Any(a => a.UserInterface?.CanFilter == true);

            var getViewDrawerEnabled = entity.Attributes
                .Any(a => a.UserInterface?.ShowInSearchResults == ShowInSearchResultsOption.OptionalAndOffByDefault
                    || a.UserInterface?.ShowInSearchResults == ShowInSearchResultsOption.OptionalAndOnByDefault);

            new TaskTemplateFileBuilder(codeGeneratorState, absoluteOutputPath)
                .WithFileExtension("razor")
                .WithClassName($"{entity.PluralName}")
                .WithFileNamePrefix($"Ui.Pages")
                .WithObject("entity", entity)
                .WithObject("getSearchEnabled", getSearchEnabled)
                .WithObject("getSearchFilterEnabled", getSearchFilterEnabled)
                .WithObject("getViewDrawerEnabled", getViewDrawerEnabled)
                .GenerateSourceCodeFromResource(templateName);
        }
    }
}