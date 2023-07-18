using Microsoft.CodeAnalysis;
using Nox.Generator.Common;

namespace Nox.Generator;

internal static class EntityBaseGenerator
{
    public static void Generate(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        var code = new TemplateCodeBuilder($"EntityBase.g.cs", context);

        code.GenerateSourceCodeFromResource(@"Domain.ModelGenerator.EntityBase.template.cs",
            new { codeGeneratorState });
    }
}
