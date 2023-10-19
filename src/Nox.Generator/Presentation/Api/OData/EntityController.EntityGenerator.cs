using Microsoft.CodeAnalysis;

using Nox.Generator.Common;
using Nox.Solution;

namespace Nox.Generator.Presentation.Api.OData;

internal class EntityControllerEntityGenerator : EntityControllerGeneratorBase
{
    public override void Generate(
    SourceProductionContext context,
    NoxSolutionCodeGeneratorState codeGeneratorState,
    GeneratorConfig config, System.Action<string> log,
    string? projectRootPath)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGeneratorState.Solution.Domain is null)
        {
            return;
        }

        const string templateName = @"Presentation.Api.OData.EntityController.Entity";

        foreach (var entity in codeGeneratorState.Solution.Domain.Entities)
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            if (entity.IsOwnedEntity)
            {
                continue;
            }

            new TemplateCodeBuilder(context, codeGeneratorState)
                .WithClassName($"{entity.PluralName}Controller")
                .WithFileNamePrefix("Presentation.Api.OData")
                .WithFileNameSuffix("Entity")
                .WithObject("entity", entity)
                .WithObject("primaryKeysQuery", GetPrimaryKeysQuery(entity))
                .WithObject("createdKeyPrimaryKeysQuery", GetPrimaryKeysQuery(entity, "createdKey.key", true))
                .WithObject("updatedKeyPrimaryKeysQuery", GetPrimaryKeysQuery(entity, "updatedKey.key", true))
                .WithObject("primaryKeysRoute", GetPrimaryKeysRoute(entity, codeGeneratorState.Solution))
                .GenerateSourceCodeFromResource(templateName);
        }
    }
}
