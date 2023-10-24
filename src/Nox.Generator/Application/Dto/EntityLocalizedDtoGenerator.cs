using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nox.Generator.Application.Dto;

internal class EntityLocalizedDtoGenerator : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Domain;

    public void Generate(
        SourceProductionContext context,
        NoxCodeGenConventions codeGeneratorState,
        GeneratorConfig config,
        Action<string> log,
        string? projectRootPath)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGeneratorState.Solution.Domain is null)
            return;

        foreach (var entity in codeGeneratorState.Solution.Domain.Entities)
        {
            // Currently skip owned and composite key entities
            if (entity.IsOwnedEntity || entity.Keys.Count > 1)
                continue;

            var entityAttributesToLocalize = GetAttributesForLocalization(entity);

            if (entityAttributesToLocalize.Any())
            {
                context.CancellationToken.ThrowIfCancellationRequested();

                new TemplateCodeBuilder(context, codeGeneratorState)
                    .WithClassName($"{entity.Name}LocalizedDto")
                    .WithFileNamePrefix("Application.Dto")
                    .WithObject("entity", entity)
                    .WithObject("entityAttributesToLocalize", entityAttributesToLocalize)
                    .GenerateSourceCodeFromResource("Application.Dto.EntityLocalizedDto");
            }
        }
    }

    private static List<NoxSimpleTypeDefinition> GetAttributesForLocalization(Entity entity)
        => entity.Attributes.Where(x => x.Type == NoxType.Text && x.TextTypeOptions != null && x.TextTypeOptions.IsLocalized).ToList();
}
