using Nox.Generator.Common;
using Nox.Solution;

namespace Nox.Generator.Tasks.Ui.Components;

internal class DefaultMainLayoutGenerator : INoxFileGenerator
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

        var templateName = @"Tasks.Ui.DefaultMainLayout";

        new TaskTemplateFileBuilder(codeGeneratorState, absoluteOutputPath)
            .WithFileExtension("razor")
            .WithClassName($"DefaultMainLayout")
            .GenerateSourceCodeFromResource(templateName);
    }
}