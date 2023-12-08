using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Solution.Extensions;
using Nox.Types;
using Nox.Types.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace Nox.Generator.Infrastructure.Persistence;

internal class EntityDtoSqlQueryBuilderGenerator : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Infrastructure;

    public void Generate(
        SourceProductionContext context,
        NoxCodeGenConventions noxCodeGenCodeConventions,
        GeneratorConfig config,
        System.Action<string> log,
        string? projectRootPath)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (noxCodeGenCodeConventions.Solution.Domain is null)
            return;

        foreach (var entity in noxCodeGenCodeConventions.Solution.Domain.Entities.Where(e => e.IsLocalized || e.Attributes.Any(x => x.Type == NoxType.Enumeration)))
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            new TemplateCodeBuilder(context, noxCodeGenCodeConventions)
                .WithClassName($"{entity.Name}DtoSqlQueryBuilder")
                .WithFileNamePrefix("Infrastructure.Persistence")
                .WithObject("entity", entity)
                .WithObject("entityKeys", entity.GetKeys())
                .WithObject("entityAttributes", GetAttributes(entity))
                .GenerateSourceCodeFromResource("Infrastructure.Persistence.EntityDtoSqlQueryBuilder");
        }
    }

    private static IEnumerable<object> GetAttributes(Entity entity)
        => GetSimpleTypeAttributes(entity).Concat(GetEntityTypeAttributes(entity));

    private static IEnumerable<object> GetSimpleTypeAttributes(Entity entity)
        => entity.Attributes
            .Where(a => a.Type.IsSimpleType())
            .Select(a => new
            {
                a.Name,
                a.Type,
                a.IsLocalizedText,
                a.IsLocalizedEnum
            });

    private static IEnumerable<object> GetEntityTypeAttributes(Entity entity)
        => entity.Attributes
            .Where(a => a.Type.IsCompoundType())
            .SelectMany(a => a.Type.GetCompoundComponents().Select(c => new
            {
                Name = $"{a.Name}_{c.Key}",
                a.Type,
                a.IsLocalizedText,
                a.IsLocalizedEnum
            }));
}