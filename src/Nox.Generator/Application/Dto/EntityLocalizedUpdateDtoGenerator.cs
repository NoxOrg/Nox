using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Solution.Extensions;
using System;

namespace Nox.Generator.Application.Dto;

internal class EntityLocalizedUpdateDtoGenerator : INoxCodeGenerator
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
            if (!entity.IsLocalized)
                continue;

            var entityAttributesToLocalize = entity.GetAttributesToLocalize();

            context.CancellationToken.ThrowIfCancellationRequested();

            new TemplateCodeBuilder(context, codeGeneratorState)
                .WithClassName(NoxCodeGenConventions.GetEntityUpdateDtoNameForLocalizedType(entity.Name))
                .WithFileNamePrefix("Application.Dto")
                .WithObject("entity", entity)
                .WithObject("entityAttributesToLocalize", entityAttributesToLocalize)
                .GenerateSourceCodeFromResource("Application.Dto.EntityLocalizedUpdateDto");
        }
    }
}
