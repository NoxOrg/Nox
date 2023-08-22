using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using System.Linq;

namespace Nox.Generator.Presentation.Api.OData;

internal class ODataServiceCollectionExtensions : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Presentation;

    public void Generate(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState, GeneratorConfig config)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGeneratorState.Solution.Domain is null)
        {
            return;
        }

        var hasKeyForCompoundKeys = "";
        foreach (var entity in codeGeneratorState.Solution.Domain.Entities)
        {           
            hasKeyForCompoundKeys += $"builder.EntityType<{entity.Name}Dto>().HasKey(e => new {{{string.Join(",", entity.Keys.Select(k => $" e.{k.Name}"))} }});\n";
        }

        var templateName = @"Presentation.Api.OData.ODataServiceCollectionExtensions";

        new TemplateCodeBuilder(context, codeGeneratorState)
            .WithObject("hasKeyForCompoundKeys", hasKeyForCompoundKeys)
            .GenerateSourceCodeFromResource(templateName);

    }
}