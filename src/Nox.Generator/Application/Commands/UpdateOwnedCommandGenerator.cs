using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using System.Linq;

namespace Nox.Generator.Application.Commands;

internal class UpdateOwnedCommandGenerator : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Domain;

    public void Generate(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState, GeneratorConfig config)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGeneratorState.Solution.Domain is null)
        {
            return;
        }

        var templateName = @"Application.Commands.UpdateOwnedCommand";

        foreach (var entity in codeGeneratorState.Solution.Domain.Entities.Where(x => x.IsOwnedEntity))
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            var parent = codeGeneratorState.Solution.Domain.Entities.FirstOrDefault(e =>
                e.OwnedRelationships?.Any(o => o.Entity == entity.Name && !o.WithSingleEntity) == true);
            if (parent is null)
                continue;

            var primaryKeysReturnQuery = string.Join(", ", entity.Keys.Select(k => $"entity.{k.Name}.Value"));
            var parentKeysFindQuery = string.Join(", ", parent.Keys.Select(k => $"key{k.Name}"));
            var ownedKeysFindQuery = string.Join(" && ", entity.Keys.Select(k => $"x.{k.Name} == owned{k.Name}"));

            new TemplateCodeBuilder(context, codeGeneratorState)
                .WithClassName($"Update{entity.Name}Command")
                .WithFileNamePrefix($"Application.Commands")
                .WithObject("entity", entity)
                .WithObject("parent", parent)
                .WithObject("primaryKeysReturnQuery", primaryKeysReturnQuery)
                .WithObject("parentKeysFindQuery", parentKeysFindQuery)
                .WithObject("ownedKeysFindQuery", ownedKeysFindQuery)
                .GenerateSourceCodeFromResource(templateName);
        }
    }
}