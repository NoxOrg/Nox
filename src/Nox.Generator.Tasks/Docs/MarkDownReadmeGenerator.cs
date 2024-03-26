using Nox.Generator.Common;
using Nox.Solution;
using Nox.Docs.Extensions;
using System.IO;

namespace Nox.Generator.Tasks.Ui.Pages;

internal class MarkDownReadmeGenerator : INoxFileGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Presentation;

    public void Generate(
      NoxCodeGenConventions codeGeneratorState,
      GeneratorConfig config,
      System.Action<string> log,
      string absoluteOutputPath
      )
    {
       var docsDirectory = Path.Combine(Directory.GetParent(codeGeneratorState.SolutionPath).Parent.FullName, "docs");
       codeGeneratorState.Solution.GenerateMarkdownReadme(docsDirectory, ErdDetail.Normal);
    }
}