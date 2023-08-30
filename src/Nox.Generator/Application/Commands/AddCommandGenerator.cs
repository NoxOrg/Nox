using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Solution.Extensions;
using System.Linq;

namespace Nox.Generator.Application.Commands;

internal class AddCommandGenerator : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Domain;
    public void Generate(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState, GeneratorConfig config)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGeneratorState.Solution.Domain is null)
        {
            return;
        }

        var templateName = @"Application.Commands.AddCommand";
        foreach (var entity in codeGeneratorState.Solution.Domain.Entities.Where(x => x.IsOwnedEntity))
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            var parent = entity.TryGetParent(codeGeneratorState.Solution.Domain.Entities);
            if (parent is null)
                continue;

            var parentKeysFindQuery = string.Join(", ", parent.Keys.Select(k => $"key{k.Name}"));
            var primaryKeysReturnQuery = string.Join(", ", entity.Keys.Select(k => $"entity.{k.Name}.Value"));

            new TemplateCodeBuilder(context, codeGeneratorState)
                .WithClassName($"Add{entity.Name}Command")
                .WithFileNamePrefix($"Application.Commands")
                .WithObject("entity", entity)
                .WithObject("parent", parent)
                .WithObject("parentKeysFindQuery", parentKeysFindQuery)
                .WithObject("primaryKeysReturnQuery", primaryKeysReturnQuery)
                .GenerateSourceCodeFromResource(templateName);
        }

    }
}
