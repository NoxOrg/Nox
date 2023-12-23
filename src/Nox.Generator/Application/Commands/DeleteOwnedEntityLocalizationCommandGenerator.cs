﻿using Microsoft.CodeAnalysis;

using Nox.Generator.Common;
using Nox.Solution;
using Nox.Solution.Extensions;

using System.Collections.Generic;
using System.Linq;

namespace Nox.Generator.Application.Commands;

internal class DeleteOwnedEntityLocalizationCommandGenerator : ApplicationEntityDependentGeneratorBase
{
    protected override void DoGenerate(SourceProductionContext context, NoxCodeGenConventions codeGeneratorState, IEnumerable<Entity> entities)
    {
        var templateName = @"Application.Commands.DeleteOwnedEntityLocalizationCommand";
        foreach (var entity in entities)
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            var parentPrimaryKeys = string.Join(", ", entity.Keys.Select(k => $"{codeGeneratorState.Solution.GetSinglePrimitiveTypeForKey(k)} key{k.Name}"));
            var parentPrimaryKeysFindQuery = string.Join(separator: ", ", entity.Keys.Select(k => $"parentKey{k.Name}"));


            foreach (var ownedRelationship in entity.OwnedRelationships.Where(x => x.Related.Entity.IsOwnedEntity && x.Related.Entity.GetLocalizedAttributes().Any()))
            {
                var ownedEntity = ownedRelationship.Related.Entity;
                var navigationName = entity.GetNavigationPropertyName(ownedRelationship);

                new TemplateCodeBuilder(context, codeGeneratorState)
                    .WithClassName($"Delete{navigationName}LocalizationsFor{entity.Name}Command")
                    .WithFileNamePrefix($"Application.Commands")
                    .WithObject("relationship", ownedRelationship)
                    .WithObject("entity", ownedEntity)
                    .WithObject("parent", entity)
                    .WithObject("parentPrimaryKeys", parentPrimaryKeys)
                    .WithObject("parentPrimaryKeysFindQuery", parentPrimaryKeysFindQuery)
                    .WithObject("navigationName", navigationName)
                    .GenerateSourceCodeFromResource(templateName);
            }
        }
    }
}
