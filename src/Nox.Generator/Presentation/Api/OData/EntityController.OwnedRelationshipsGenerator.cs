using Microsoft.CodeAnalysis;

using Nox.Generator.Common;
using Nox.Solution;

namespace Nox.Generator.Presentation.Api.OData;

internal class EntityControllerOwnedRelationshipsGenerator : EntityControllerGeneratorBase
{
    public override void Generate(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState, GeneratorConfig config)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGeneratorState.Solution.Domain is null)
        {
            return;
        }

        const string templateName = @"Presentation.Api.OData.EntityController.OwnedRelationships";

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
                .WithFileNameSuffix("OwnedRelationships")
                .WithObject("entity", entity)
                .GenerateSourceCodeFromResource(templateName);
        }
    }
}
