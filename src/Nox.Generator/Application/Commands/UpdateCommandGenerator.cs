using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using System.Linq;

namespace Nox.Generator.Application.Commands;

internal class UpdateCommandGenerator : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Domain;

    public void Generate(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState, GeneratorConfig config)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGeneratorState.Solution.Domain is null)
        {
            return;
        }

        var templateName = @"Application.Commands.UpdateCommand";

        foreach (var entity in codeGeneratorState.Solution.Domain.Entities.Where(x => !x.IsOwnedEntity))
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            var primaryKeys = string.Join(", ", entity.Keys.Select(k => $"{codeGeneratorState.Solution.GetSinglePrimitiveTypeForKey(k)} key{k.Name}"));
            var primaryKeysFindQuery = string.Join(", ", entity.Keys.Select(k => $"key{k.Name}"));
            var primaryKeysReturnQuery = string.Join(", ", entity.Keys.Select(k => $"entity.{k.Name}.Value"));

            new TemplateCodeBuilder(context, codeGeneratorState)
                .WithClassName($"Update{entity.Name}Command")
                .WithFileNamePrefix($"Commands")
                .WithObject("entity", entity)
                .WithObject("primaryKeys", primaryKeys)
                .WithObject("primaryKeysFindQuery", primaryKeysFindQuery)
                .WithObject("primaryKeysReturnQuery", primaryKeysReturnQuery)
                .GenerateSourceCodeFromResource(templateName);
        }
    }
}