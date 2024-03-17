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
            
            var primaryKeys = string.Join(", ", entity.OwnerEntity!.GetKeys().Select(k => $"{codeGenConventions.Solution.GetSinglePrimitiveTypeForKey(k)} key{k.Name}"));
            
            var isWithMultiEntity = entity.OwnerEntity!.OwnedRelationships.FirstOrDefault(r => r.Entity == entity.Name)!.WithMultiEntity;
            var parentEntityKeyName = entity.OwnerEntity!.Keys[0].Name;
            var entityKeyName = entity.Keys.FirstOrDefault()?.Name ?? string.Empty;
            new TemplateCodeBuilder(context, codeGenConventions)
                .WithClassName($"Get{entity.Name}TranslationsByParentIdQuery")
                .WithFileNamePrefix($"Application.Queries")
                .WithObject("entity", entity)
                .WithObject("parentEntity", entity.OwnerEntity!)
                .WithObject("entityKeys", entity.GetKeys())
                .WithObject("primaryKeys", primaryKeys)
                .WithObject("isWithMultiEntity", isWithMultiEntity)
                .WithObject("parentEntityKeyName", parentEntityKeyName)
                .WithObject("entityKeyName", entityKeyName)
                .GenerateSourceCodeFromResource(templateName);
        }  
    }
}