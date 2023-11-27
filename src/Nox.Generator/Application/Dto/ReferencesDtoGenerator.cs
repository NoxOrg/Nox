using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;

namespace Nox.Generator.Application.Dto;

internal class ReferencesDtoGenerator : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Application;

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

        var templateName = @"Application.Dto.ReferencesDto";

        context.CancellationToken.ThrowIfCancellationRequested();

        new TemplateCodeBuilder(context, codeGeneratorState)
            .WithClassName($"ReferencesDto")
            .WithFileNamePrefix("Application.Dto")
            .GenerateSourceCodeFromResource(templateName);
    }
}