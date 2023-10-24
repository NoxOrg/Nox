using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using System;

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
            if (!entity.ShouldBeLocalized)
                continue;

            var entityAttributesToLocalize = entity.GetAttributesToLocalize();

            context.CancellationToken.ThrowIfCancellationRequested();

            new TemplateCodeBuilder(context, codeGeneratorState)
                .WithClassName(NoxCodeGenConventions.GetEntityDtoNameForLocalizedType(entity.Name))
                .WithFileNamePrefix("Application.Dto")
                .WithObject("entity", entity)
                .WithObject("entityAttributesToLocalize", entityAttributesToLocalize)
                .GenerateSourceCodeFromResource("Application.Dto.EntityLocalizedDto");
        }
    }
}
