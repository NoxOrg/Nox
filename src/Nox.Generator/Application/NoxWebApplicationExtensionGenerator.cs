using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;

namespace Nox.Generator.Application;

internal class NoxWebApplicationExtensionGenerator : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.None;

    public void Generate(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState, GeneratorConfig config)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        var namePrefix = "Application";

        new TemplateCodeBuilder(context, codeGeneratorState)
            .WithClassName("NoxWebApplicationExtensions")
            .WithFileNamePrefix(namePrefix)
            .WithObject("solutionName", codeGeneratorState.Solution.Name)
            .WithObject("configPresentation", config.Presentation)
            .GenerateSourceCodeFromResource($"{namePrefix}.NoxWebApplicationBuilderExtension");
    }
}