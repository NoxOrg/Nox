using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Solution.Extensions;
using System;

namespace Nox.Generator.Application.Dto;

internal class EntityLocalizedUpsertDtoGenerator : INoxCodeGenerator
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
            

            context.CancellationToken.ThrowIfCancellationRequested();

            new TemplateCodeBuilder(context, codeGeneratorState)
                .WithClassName(NoxCodeGenConventions.GetEntityUpsertDtoNameForLocalizedType(entity.Name))
                .WithFileNamePrefix("Application.Dto")
                .WithObject("entity", entity)
                .WithObject("entityAttributesToLocalize", entity.GetLocalizedAttributes())
                .GenerateSourceCodeFromResource("Application.Dto.EntityLocalizedUpsertDto");
        }
    }
}