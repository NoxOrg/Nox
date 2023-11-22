using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using System.Collections.Generic;
using System.Linq;

namespace Nox.Generator.Application.Commands;

internal class DeleteRelatedCommandGenerator : ApplicationEntityDependentGeneratorBase
{
    protected override void DoGenerate(SourceProductionContext context, NoxCodeGenConventions codeGeneratorState, IEnumerable<Entity> entities)
    {
        var templateName = @"Application.Commands.DeleteRelatedCommand";
        foreach (var entity in entities.Where(x => !x.IsOwnedEntity))
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            foreach (var relation in entity.Relationships.Where(x => x.WithMultiEntity))
            {
                var ownedEntity = entities.Single(entity => entity.Name == relation.Entity);
                var parentKeysFindQuery = string.Join(", ", entity.Keys.Select(k => $"key{k.Name}"));

                new TemplateCodeBuilder(context, codeGeneratorState)
                    .WithClassName($"DeleteAll{relation.Name}For{entity.Name}Command")
                    .WithFileNamePrefix($"Application.Commands")
                    .WithObject("relationship", relation)
                    .WithObject("entity", ownedEntity)
                    .WithObject("parent", entity)
                    .WithObject("parentKeysFindQuery", parentKeysFindQuery)
                    .GenerateSourceCodeFromResource(templateName);
            }
        }
    }
}