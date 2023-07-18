using Microsoft.CodeAnalysis;
using Nox.Generator.Common;

namespace Nox.Generator;

internal static class AuditableEntityBaseGenerator
{
    public static void Generate(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        var code = new TemplateCodeBuilder(context, codeGeneratorState);

        code.GenerateSourceCodeFromResource(@"Domain.ModelGenerator.AuditableEntityBase");
    }
}
