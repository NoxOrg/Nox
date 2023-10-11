using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using System.Linq;

namespace Nox.Generator.Application.Commands;

internal class CreateCommandGenerator : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Domain;

    public void Generate(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState, GeneratorConfig config, string outputPath)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGeneratorState.Solution.Domain is null)
        {
            return;
        }

        var templateName = @"Application.Commands.CreateCommand";
        foreach (var entity in codeGeneratorState.Solution.Domain.Entities.Where(x => !x.IsOwnedEntity))
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            var primaryKeysQuery = string.Join(", ", entity.Keys.Select(k => $"entityToCreate.{k.Name}.Value"));

            var relatedEntities = entity.Relationships.GroupBy(r => r.Entity).Select(g => g.First().Entity).ToList();
            new TemplateCodeBuilder(context, codeGeneratorState)
                .WithClassName($"Create{entity.Name}Command")
                .WithFileNamePrefix($"Application.Commands")
                .WithObject("entity", entity)
                .WithObject("relatedEntities", relatedEntities)
                .WithObject("primaryKeysQuery", primaryKeysQuery)
                .GenerateSourceCodeFromResource(templateName);
        }
    }
}