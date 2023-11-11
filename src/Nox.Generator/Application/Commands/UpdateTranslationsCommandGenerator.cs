using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using System.Collections.Generic;
using System.Linq;

namespace Nox.Generator.Application.Commands;

internal class UpdateTranslationsCommandGenerator : ApplicationEntityDependentGeneratorBase
{
    protected override void DoGenerate(SourceProductionContext context, NoxCodeGenConventions codeGeneratorState, IEnumerable<Entity> entities)
    {
        var templateName = @"Application.Commands.UpdateTranslationsCommand";
        foreach (var entity in entities.Where(x => !x.IsOwnedEntity))
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            if (!entity.IsLocalized)
            {
                continue;
            }
            

            var primaryKeysFindQuery = string.Join(", ", entity.Keys.Select(k => $"key{k.Name}"));
            var primaryKeysQuery = string.Join(", ", entity.Keys.Select(k => $"entityLocalizedToUpdate.{k.Name}.Value"));

            new TemplateCodeBuilder(context, codeGeneratorState)
                .WithClassName($"Update{entity.Name}TranslationsCommand")
                .WithFileNamePrefix($"Application.Commands")
                .WithObject("entity", entity)
                .WithObject("primaryKeysQuery", primaryKeysQuery)
                .WithObject("primaryKeysFindQuery", primaryKeysFindQuery)
                .GenerateSourceCodeFromResource(templateName);
        }
    }
}