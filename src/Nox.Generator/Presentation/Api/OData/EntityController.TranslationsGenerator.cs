using System.Linq;

using Microsoft.CodeAnalysis;

using Nox.Generator.Common;
using Nox.Solution;
using Nox.Solution.Extensions;

namespace Nox.Generator.Presentation.Api.OData;

internal class EntityControllerTranslationsGenerator : EntityControllerGeneratorBase
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

        const string templateName = @"Presentation.Api.OData.EntityController.Translations";

        foreach (var entity in codeGenConventions.Solution.Domain.Entities.Where(x => !x.IsOwnedEntity && (x.IsLocalized || x.HasLocalizedOwnedRelationships)))
        {
            context.CancellationToken.ThrowIfCancellationRequested();
            var ownedEntityKeyPrefix = "relatedKey";

            var keysForRouting = GetPrimaryKeysQuery(entity).Split(',').Select(x => x.Trim()).ToList();
            var ownedEntitiesWithLocalizedAttributes = entity.OwnedRelationships
                .Select(x => new
                {
                    IsWithMultiEntity = x.WithMultiEntity,
                    OwnedEntity = x.Related.Entity,
                    LocalizedAttributes = x.Related.Entity.GetLocalizedAttributes(),
                    OwnedEntityKeysQuery = $"{x.Related.Entity.Name.ToLowerFirstChar()}LocalizedUpsertDto.{x.Related.Entity.Keys.FirstOrDefault()?.Name}!.Value",
                    OwnedEntityKey =  $"{x.Related.Entity.Name.ToLowerFirstChar()}LocalizedUpsertDto.{x.Related.Entity.Keys.FirstOrDefault()?.Name}",
                    OwnedEntityKeysRoute = GetPrimaryKeysRoute(x.Related.Entity, codeGenConventions.Solution, ownedEntityKeyPrefix),
                    NavigationName = entity.GetNavigationPropertyName(x),
                    UpdatedKeyPrimaryKeysQuery = x.WithMultiEntity
                        ? GetPrimaryKeysQuery(x.Related.Entity, "updatedKey.key", true)
                        : GetPrimaryKeysQuery(entity),
                    KeysForRouting = GetPrimaryKeysQuery(x.Related.Entity, prefix: ownedEntityKeyPrefix).Split(',').Select(x => x.Trim()).ToList(),
                    KeysRoute = GetPrimaryKeysRoute(x.Related.Entity, codeGenConventions.Solution, keyPrefix: ownedEntityKeyPrefix),
                    KeysQuery = GetPrimaryKeysQuery(x.Related.Entity, prefix: ownedEntityKeyPrefix),
                })
                .Where(x => x.LocalizedAttributes.Any())
                .ToList();

            new TemplateCodeBuilder(context, codeGenConventions)
                .WithClassName($"{entity.PluralName}Controller")
                .WithFileNamePrefix("Presentation.Api.OData")
                .WithFileNameSuffix("Translations")
                .WithObject("primaryKeysRoute", GetPrimaryKeysRoute(entity, codeGenConventions.Solution))
                .WithObject("primaryKeysQuery", GetPrimaryKeysQuery(entity))
                .WithObject("createdKeyPrimaryKeysQuery", GetPrimaryKeysQuery(entity, "createdKey.", true))
                .WithObject("updatedKeyPrimaryKeysQuery", GetPrimaryKeysQuery(entity, "updatedKey.key", true))
                .WithObject("keysForRouting", keysForRouting)
                .WithObject("localizedAttributes", entity.GetLocalizedAttributes())
                .WithObject("ownedLocalizedRelationships", ownedEntitiesWithLocalizedAttributes)
                .WithObject("entity", entity)
                .GenerateSourceCodeFromResource(templateName);
        }
    }
}