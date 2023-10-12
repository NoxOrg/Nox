using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;

namespace Nox.Generator.Infrastructure.Persistence;

internal class DbContextGenerator : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Infrastructure;

    public void Generate(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState, GeneratorConfig config, string? projectRootPath)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGeneratorState.Solution.Domain is null)
        {
            return;
        }
        
        var className = $"{codeGeneratorState.Solution.Name}DbContext";
        var templateName = @"Infrastructure.Persistence.DbContext";

        new TemplateCodeBuilder(context, codeGeneratorState)
            .WithClassName(className)
            .WithFileNamePrefix("Infrastructure.Persistence")
            .GenerateSourceCodeFromResource(templateName);
    }
}