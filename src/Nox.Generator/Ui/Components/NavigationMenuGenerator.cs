using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using System.Linq;

namespace Nox.Generator.Application.Commands;

internal class NavigationMenuGenerator : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Ui;

    public void Generate(
      SourceProductionContext context,
      NoxCodeGenConventions codeGeneratorState,
      GeneratorConfig config,
      System.Action<string> log,
      string? projectRootPath
      )
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGeneratorState.Solution.Domain is null)
        {
            return;
        }

        var templateName = @"Ui.Components.NavigationMenu";
        var entities = codeGeneratorState.Solution.Domain.Entities.Where(x => !x.IsOwnedEntity);

        context.CancellationToken.ThrowIfCancellationRequested();

        new TemplateCodeBuilder(context, codeGeneratorState)
            .WithClassName($"NavigationMenu")
            .WithFileNamePrefix($"Ui.Components")
            .WithObject("entities", entities)
            .GenerateSourceCodeFromResource(templateName);
    }
}