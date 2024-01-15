using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using System.Collections.Generic;
using System.Linq;

namespace Nox.Generator.Application.Commands;

internal class RefToCommandGenerator : ApplicationEntityDependentGeneratorBase
{
    protected override void DoGenerate(SourceProductionContext context, NoxCodeGenConventions codeGenConventions, IEnumerable<Entity> entities)
    {
        var templateName = @"Application.Commands.RefToCommand";
        foreach (var entity in entities.Where(x => !x.IsOwnedEntity))
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            if (entity.Relationships is null)
                continue;

            foreach (var relationship in entity.Relationships)
            {
                var entityKeysFindQuery = string.Join(", ", entity.Keys.Select(k => $"key{k.Name}"));
                var relatedEntityKeysFindQuery = string.Join(", ",
                    relationship.Related.Entity.Keys.Select(k => $"relatedKey{k.Name}"));

                new TemplateCodeBuilder(context, codeGenConventions)
                    .WithClassName($"Ref{entity.Name}To{entity.GetNavigationPropertyName(relationship)}Command")
                    .WithFileNamePrefix($"Application.Commands")
                    .WithObject("entity", entity)
                    .WithObject("relationship", relationship)
                    .WithObject("entityKeysFindQuery", entityKeysFindQuery)
                    .WithObject("relatedEntityKeysFindQuery", relatedEntityKeysFindQuery)
                    .GenerateSourceCodeFromResource(templateName);
            }
        }
    }
}