using Microsoft.CodeAnalysis;
using Nox.Generator.Common;

namespace Nox.Generator;

internal static class AuditableEntityBaseGenerator
{
    public static void Generate(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        var code = new TemplateCodeBuilder($"AuditableEntityBase.g.cs",context);

        code.GenerateSourceCodeFromResource(@"Domain.ModelGenerator.AuditableEntityBase.template.cs",
            new { codeGeneratorState });
    }
}
