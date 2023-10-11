using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;

namespace Nox.Generator.Application;

internal class ServiceCollectionExtensionsGenerator : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Application;

    public void Generate(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState, GeneratorConfig config, string outputPath)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        var namePrefix = "Application";

        new TemplateCodeBuilder(context, codeGeneratorState)
            .WithClassName("ServiceCollectionExtensions")
            .WithFileNamePrefix(namePrefix)
            .WithObject("solutionName", codeGeneratorState.Solution.Name)
            .WithObject("configPresentation", config.Presentation)
            .GenerateSourceCodeFromResource($"{namePrefix}.ServiceCollectionExtensions");
    }
}