using System.Linq;
using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;

namespace Nox.Generator.Presentation.Api.OData;

internal static class ODataServiceCollectionExtensions
{
    public static void Generate(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGeneratorState.Solution.Domain is null)
        {
            return;
        }

        var templateName = @"Presentation.Api.OData.ODataServiceCollectionExtensions";

        new TemplateCodeBuilder(context, codeGeneratorState)
            .GenerateSourceCodeFromResource(templateName);
    }
}