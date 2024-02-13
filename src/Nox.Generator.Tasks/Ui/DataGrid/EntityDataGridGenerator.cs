using Nox.Generator.Common;
using Nox.Solution;
using System.Linq;

namespace Nox.Generator.Tasks.Ui.Forms;

internal class EntityDataGridGenerator : INoxFileGenerator
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

        var templateName = @"Tasks.Ui.DataGrid.EntityDataGrid";
        var entities = codeGeneratorState.Solution.Domain.Entities
            .Where(e => !e.IsOwnedEntity && e.Persistence.Read.IsEnabled);

        foreach (var entity in entities)
        {
            new TaskTemplateFileBuilder(codeGeneratorState, absoluteOutputPath)
                .WithFileExtension("razor.cs")
                .WithClassName($"{entity.PluralName}DataGrid")
                .WithFileNamePrefix($"Ui.DataGrid")
                .WithObject("entity", entity)
                .GenerateSourceCodeFromResource(templateName);
        }
    }
}