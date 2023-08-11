using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using System.Linq;

namespace Nox.Generator.Application.Commands;

internal class PartialUpdateCommandGenerator : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Domain;

    public void Generate(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState, GeneratorConfig config)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGeneratorState.Solution.Domain is null)
        {
            return;
        }

        var templateName = @"Application.Commands.PartialUpdateCommand";
        foreach (var entity in codeGeneratorState.Solution.Domain.Entities)
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            var primaryKeys = string.Join(", ", entity.Keys.Select(k => $"{entity.KeysFlattenComponentsType[k.Name]} key{k.Name}"));
            var primaryKeysQuery = string.Join(", ", entity.Keys.Select(k => $"key{k.Name}"));

            new TemplateCodeBuilder(context, codeGeneratorState)
                .WithClassName($"PartialUpdate{entity.Name}Command")
                .WithFileNamePrefix($"Commands")
                .WithObject("entity", entity)
                .WithObject("primaryKeys", primaryKeys)
                .WithObject("primaryKeysQuery", primaryKeysQuery)
                .GenerateSourceCodeFromResource(templateName);
        }
    }
}