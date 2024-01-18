using Microsoft.CodeAnalysis;

using Nox.Generator.Common;
using Nox.Solution;

namespace Nox.Generator.Presentation.Api.OData;

internal class EntityControllerCustomCommandsGenerator : EntityControllerGeneratorBase
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

        const string templateName = @"Presentation.Api.OData.EntityController.CustomCommands";

        foreach (var entity in codeGenConventions.Solution.Domain.Entities)
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            if (entity.IsOwnedEntity)
            {
                continue;
            }

            new TemplateCodeBuilder(context, codeGenConventions)
                .WithClassName($"{entity.PluralName}Controller")
                .WithFileNamePrefix("Presentation.Api.OData")
                .WithFileNameSuffix("CustomCommands")
                .WithObject("entity", entity)
                .GenerateSourceCodeFromResource(templateName);
        }
    }
}
