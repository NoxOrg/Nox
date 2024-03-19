using Microsoft.CodeAnalysis;
using Nox.Generator.Application.Commands;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Solution.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace Nox.Generator.Application.Queries;

internal class OwnedTranslationsByParentIdQueryGenerator : ApplicationEntityDependentGeneratorBase
{
    protected override void DoGenerate(SourceProductionContext context, NoxCodeGenConventions codeGenConventions, IEnumerable<Entity> entities)
    {
        var templateName = @"Application.Queries.OwnedTranslationsByParentIdQuery";
        foreach (var entity in entities.Where(x => x.IsOwnedEntity && x.IsLocalized))
        {
            context.CancellationToken.ThrowIfCancellationRequested();
            
            var parentPrimaryKeyProperty = string.Join(", ", entity.OwnerEntity!.GetKeys().Select(k => $"{codeGenConventions.Solution.GetSinglePrimitiveTypeForKey(k)} {entity.OwnerEntity!.Name}{k.Name}"));
            var primaryKeyProperty = string.Join(", ", entity.GetKeys().Select(k => $"{codeGenConventions.Solution.GetSinglePrimitiveTypeForKey(k)} {entity.Name}{k.Name}"));
            
            var parentKeyName = $"{entity.OwnerEntity!.Name}{entity.OwnerEntity!.Keys[0].Name}";
            var keyName = $"{entity.Name}{entity.Keys.FirstOrDefault()?.Name}";
            
            var parentEntityKeyName = entity.OwnerEntity!.Keys[0].Name;
            var entityKeyName = entity.Keys.FirstOrDefault()?.Name ?? string.Empty;
            
            var isWithMultiEntity = entity.OwnerEntity!.OwnedRelationships.FirstOrDefault(r => r.Entity == entity.Name)!.WithMultiEntity;
            new TemplateCodeBuilder(context, codeGenConventions)
                .WithClassName($"Get{entity.Name}TranslationsByParentIdQuery")
                .WithFileNamePrefix($"Application.Queries")
                .WithObject("entity", entity)
                .WithObject("parentEntity", entity.OwnerEntity!)
                .WithObject("parentPrimaryKeyProperty", parentPrimaryKeyProperty)
                .WithObject("primaryKeyProperty", primaryKeyProperty)
                .WithObject("parentKeyName", parentKeyName)
                .WithObject("keyName", keyName)
                .WithObject("parentEntityKeyName", parentEntityKeyName)
                .WithObject("entityKeyName", entityKeyName)
                .WithObject("isWithMultiEntity", isWithMultiEntity)
                .GenerateSourceCodeFromResource(templateName);
        }  
    }
}