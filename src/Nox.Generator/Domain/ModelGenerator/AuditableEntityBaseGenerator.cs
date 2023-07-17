using Microsoft.CodeAnalysis;
using Nox.Generator.Common;

namespace Nox.Generator;

internal static class AuditableEntityBaseGenerator
{
    public static void Generate(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        var code = new TemplateCodeBuilder($"AuditableEntityBase.g.cs",context);

        // We can also  opt by kept in a static string
        // code.GenerateSourceCode(Template,new { domain = codeGeneratorState.DomainNameSpace });
        code.GenerateSourceCodeFromResource(@"Domain.ModelGenerator.AuditableEntityBase.g.cs",
            new { domain = codeGeneratorState.DomainNameSpace });
    }
}
