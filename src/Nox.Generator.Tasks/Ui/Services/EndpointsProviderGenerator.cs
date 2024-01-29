using Nox.Generator.Common;
using Nox.Solution;
using System.Linq;

namespace Nox.Generator.Tasks.Ui.Components;

internal class EndpointsProviderGenerator : INoxFileGenerator
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

        var templateName = @"Tasks.Ui.Services.EndpointsProvider";
        var entities = codeGeneratorState.Solution.Domain.Entities
            .Where(e => !e.IsOwnedEntity)
            .OrderBy(e => e.PluralName);

        new TaskTemplateFileBuilder(codeGeneratorState, absoluteOutputPath)
            .WithClassName($"EndpointsProvider")
            .WithFileNamePrefix($"Ui.Services")
            .WithObject("entities", entities)
            .GenerateSourceCodeFromResource(templateName);
    }
}