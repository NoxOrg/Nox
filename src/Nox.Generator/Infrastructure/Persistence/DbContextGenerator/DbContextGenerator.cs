using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;

namespace Nox.Generator.Infrastructure.Persistence.DbContextGenerator;

internal class DbContextGenerator : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Infrastructure;

    public void Generate(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState, GeneratorConfig config)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGeneratorState.Solution.Domain is null)
        {
            return;
        }

        var className = $"{codeGeneratorState.Solution.Name}DbContext";
        var templateName = @"Infrastructure.Persistence.DbContextGenerator.DbContext";

        new TemplateCodeBuilder(context, codeGeneratorState)
            .WithClassName(className)
            .GenerateSourceCodeFromResource(templateName);
    }
}