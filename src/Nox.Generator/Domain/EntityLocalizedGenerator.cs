using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Solution.Extensions;

namespace Nox.Generator.Domain;

internal class EntityLocalizedGenerator : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Domain;

    public void Generate(
        SourceProductionContext context,
        NoxCodeGenConventions codeGenConventions,
        GeneratorConfig config,
        System.Action<string> log,
        string? projectRootPath)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGenConventions.Solution.Domain is null)
            return;

        foreach (var entity in codeGenConventions.Solution.Domain.GetLocalizedEntities())
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            new TemplateCodeBuilder(context, codeGenConventions)
                .WithClassName(NoxCodeGenConventions.GetEntityNameForLocalizedType(entity.Name))
                .WithFileNamePrefix($"Domain")
                .WithObject("entity", entity)
                .WithObject("entityKeys", entity.GetKeys())
                .WithObject("entityLocalizedAttributes", entity.GetLocalizedAttributes())
                .GenerateSourceCodeFromResource("Domain.EntityLocalized");
        }
    }
}