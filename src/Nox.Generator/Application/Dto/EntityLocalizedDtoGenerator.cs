using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Solution.Extensions;
using System;

namespace Nox.Generator.Application.Dto;

internal class EntityLocalizedDtoGenerator : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.ApplicationDto;

    public void Generate(
        SourceProductionContext context,
        NoxCodeGenConventions codeGenConventions,
        GeneratorConfig config,
        Action<string> log,
        string? projectRootPath)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGenConventions.Solution.Domain is null)
            return;

        foreach (var entity in codeGenConventions.Solution.Domain.GetLocalizedEntities())
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            new TemplateCodeBuilder(context, codeGenConventions)
                .WithClassName(NoxCodeGenConventions.GetEntityDtoNameForLocalizedType(entity.Name))
                .WithFileNamePrefix("Application.Dto")
                .WithObject("entity", entity)
                .WithObject("entityKeys", entity.GetKeys())
                .WithObject("entityLocalizedAttributes", entity.GetLocalizedAttributes())
                .GenerateSourceCodeFromResource("Application.Dto.EntityLocalizedDto");
        }
    }
}
