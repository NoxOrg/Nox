using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Solution.Extensions;
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

        foreach (var entity in noxCodeGenCodeConventions.Solution.Domain.Entities.Where(e => e.IsLocalized))
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            new TemplateCodeBuilder(context, noxCodeGenCodeConventions)
                .WithClassName($"{entity.Name}DtoSqlQueryBuilder")
                .WithFileNamePrefix("Infrastructure.Persistence")
                .WithObject("entity", entity)
                .WithObject("entityKeys", entity.GetKeys())
                .GenerateSourceCodeFromResource("Infrastructure.Persistence.EntityDtoSqlQueryBuilder");
        }
    }
}