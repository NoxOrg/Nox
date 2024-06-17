using Nox.Generator.Common;
using Nox.Solution;
using System.Linq;

namespace Nox.Generator.Tasks.Ui.Pages;

internal class EntityPageGenerator : INoxFileGenerator
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

        var templateName = @"Tasks.Ui.Pages.EntityPage";
        var entities = codeGeneratorState.Solution.Domain.Entities
            .Where(e => !e.IsOwnedEntity && e.Persistence.Read.IsEnabled)
            .OrderBy(e => e.PluralName);

        foreach (var entity in entities)
        {
            new TaskTemplateFileBuilder(codeGeneratorState, absoluteOutputPath)
                .WithFileExtension("razor.cs")
                .WithClassName($"{entity.PluralName}")
                .WithFileNamePrefix($"Ui.Pages")
                .WithObject("entity", entity)
                .GenerateSourceCodeFromResource(templateName);
        }
    }
}