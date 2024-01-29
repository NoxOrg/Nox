using Nox.Generator.Common;
using Nox.Solution;
using System.Linq;

namespace Nox.Generator.Tasks.Ui.Forms;

internal class AddEntityFormRazorGenerator : INoxFileGenerator
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

        var templateName = @"Tasks.Ui.Forms.AddEntityFormRazor";
        var entities = codeGeneratorState.Solution.Domain.Entities
            .Where(e => !e.IsOwnedEntity && e.Persistence.Create.IsEnabled);

        foreach (var entity in entities)
        {
            new TaskTemplateFileBuilder(codeGeneratorState, absoluteOutputPath)
                .WithFileExtension("razor")
                .WithClassName($"Add{entity.Name}Form")
                .WithFileNamePrefix($"Ui.Forms.Add")
                .WithObject("entity", entity)
                .GenerateSourceCodeFromResource(templateName);
        }
    }
}