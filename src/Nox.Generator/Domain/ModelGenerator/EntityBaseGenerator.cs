using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;

namespace Nox.Generator;

internal static class EntityBaseGenerator
{
    public static void Generate(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        var code = new TemplateCodeBuilder(context, codeGeneratorState);

        code.GenerateSourceCodeFromResource(@"Domain.ModelGenerator.EntityBase");
    }
}
