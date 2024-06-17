using Nox.Generator.Common;
using Nox.Solution;

namespace Nox.Generator.Tasks.Ui.Components;

internal class SortOrderDirectionGenerator : INoxFileGenerator
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

        var templateName = @"Tasks.Ui.Enums.SortOrderDirection";

        new TaskTemplateFileBuilder(codeGeneratorState, absoluteOutputPath)
            .WithClassName($"SortOrderDirection")
            .WithFileNamePrefix($"Ui.Enums")
            .GenerateSourceCodeFromResource(templateName);
    }
}