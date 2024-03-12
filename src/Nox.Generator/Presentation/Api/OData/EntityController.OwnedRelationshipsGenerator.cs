using System.Linq;
using Microsoft.CodeAnalysis;

using Nox.Generator.Common;
using Nox.Solution;

namespace Nox.Generator.Presentation.Api.OData;

internal class EntityControllerOwnedRelationshipsGenerator : EntityControllerGeneratorBase
{
    public override void Generate(
    SourceProductionContext context,
    NoxCodeGenConventions codeGenConventions,
    GeneratorConfig config, System.Action<string> log,
    string? projectRootPath)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGenConventions.Solution.Domain is null)
        {
            return;
        }

        const string templateName = @"Presentation.Api.OData.EntityController.OwnedRelationships";

        foreach (var entity in codeGenConventions.Solution.Domain.Entities)
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            if (entity.IsOwnedEntity)
            {
                continue;
            }

            var ownedRelationships = entity.OwnedRelationships
                .Where(o => o.ApiGenerateRelatedEndpoint)
                .Select(o => new
            {
                o.Entity,
                o.EntityPlural,
                o.Relationship,
                Definition = o,
                OwnedRelationshipName = entity.GetNavigationPropertyName(o),
                Deletable = CanDelete(o.Related.Entity) && CanDelete(entity),
                primaryKeysRoute = GetPrimaryKeysRoute(o.Related.Entity, codeGenConventions.Solution, "relatedKey"),
                primaryKeysQuery = GetPrimaryKeysQuery(o.Related.Entity, "relatedKey")
                
            });
            new TemplateCodeBuilder(context, codeGenConventions)
                .WithClassName($"{entity.PluralName}Controller")
                .WithFileNamePrefix("Presentation.Api.OData")
                .WithFileNameSuffix("OwnedRelationships")
                .WithObject("entity", entity)
                .WithObject("primaryKeysRoute", GetPrimaryKeysRoute(entity, codeGenConventions.Solution))
                .WithObject("primaryKeysQuery", GetPrimaryKeysQuery(entity))
                .WithObject("ownedRelationships", ownedRelationships)
                .GenerateSourceCodeFromResource(templateName);
        }
    }
}
