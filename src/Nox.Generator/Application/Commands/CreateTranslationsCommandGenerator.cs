using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using System.Collections.Generic;
using System.Linq;

namespace Nox.Generator.Application.Commands;

internal class CreateTranslationsCommandGenerator : ApplicationEntityDependentGeneratorBase
{
    protected override void DoGenerate(SourceProductionContext context, NoxCodeGenConventions codeGeneratorState, IEnumerable<Entity> entities)
    {
        var templateName = @"Application.Commands.CreateTranslationsCommand";
        foreach (var entity in entities.Where(x => !x.IsOwnedEntity))
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            if (!entity.IsLocalized)
            {
                continue;
            }
            
            var primaryKeysQuery = string.Join(", ", entity.Keys.Select(k => $"entityLocalizedToCreate.{k.Name}.Value"));

            var relatedEntities = entity.Relationships.GroupBy(r => r.Entity).Select(g => g.First().Entity).ToList();
            new TemplateCodeBuilder(context, codeGeneratorState)
                .WithClassName($"Create{entity.Name}TranslationsCommand")
                .WithFileNamePrefix($"Application.Commands")
                .WithObject("entity", entity)
                .WithObject("relatedEntities", relatedEntities)
                .WithObject("primaryKeysQuery", primaryKeysQuery)
                .GenerateSourceCodeFromResource(templateName);
        }
    }
}