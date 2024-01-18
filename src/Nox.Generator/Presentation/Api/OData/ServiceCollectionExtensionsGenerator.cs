using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;

namespace Nox.Generator.Presentation.Api.OData;

internal class ServiceCollectionExtensionsGenerator : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Presentation;

    public void Generate(
      SourceProductionContext context,
      NoxCodeGenConventions codeGenConventions,
      GeneratorConfig config,
      System.Action<string> log,
      string? projectRootPath
      )
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        var namePrefix = "Presentation.Api.OData";

        new TemplateCodeBuilder(context, codeGenConventions)
            .WithClassName("ServiceCollectionExtensions")
            .WithFileNamePrefix(namePrefix)
            .WithObject("solutionName", codeGenConventions.Solution.Name)
            .WithObject("configPresentation", config.Presentation)
            .GenerateSourceCodeFromResource($"{namePrefix}.ServiceCollectionExtensions");
    }
}