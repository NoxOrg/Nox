using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;

namespace Nox.Generator.Infrastructure.Persistence.DbContextGenerator;

internal static class DbContextGenerator
{
    public static void Generate(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState)
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