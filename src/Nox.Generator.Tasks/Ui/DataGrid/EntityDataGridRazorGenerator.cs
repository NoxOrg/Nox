using Nox.Generator.Common;
using Nox.Solution;
using System.Linq;

namespace Nox.Generator.Tasks.Ui.DataGrid;

internal class EntityDataGridRazorGenerator : INoxFileGenerator
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

        var templateName = @"Tasks.Ui.DataGrid.EntityDataGridRazor";
        var entities = codeGeneratorState.Solution.Domain.Entities
            .Where(e => !e.IsOwnedEntity && e.Persistence.Read.IsEnabled);

        foreach (var entity in entities)
        {
            var attributesToShowInSearch = entity.Attributes
                .Where(a => a.UserInterface?.ShowInSearchResults == ShowInSearchResultsOption.Always 
                    || a.UserInterface?.ShowInSearchResults == ShowInSearchResultsOption.OptionalAndOnByDefault
                    || a.UserInterface?.ShowInSearchResults == ShowInSearchResultsOption.OptionalAndOffByDefault)
                .Select(a => a.Name);

            new TaskTemplateFileBuilder(codeGeneratorState, absoluteOutputPath)
                .WithFileExtension("razor")
                .WithClassName($"{entity.PluralName}DataGrid")
                .WithFileNamePrefix($"Ui.DataGrid")
                .WithObject("entity", entity)
                .WithObject("attributesToShowInSearch", attributesToShowInSearch)
                .GenerateSourceCodeFromResource(templateName);
        }
    }
}