using Microsoft.CodeAnalysis;
using Nox.Generator.Application.Commands;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Solution.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace Nox.Generator.Application.Queries;

internal class TranslationsByIdQueryGenerator : ApplicationEntityDependentGeneratorBase
{
    protected override void DoGenerate(SourceProductionContext context, NoxCodeGenConventions codeGenConventions, IEnumerable<Entity> entities)
    {
        var templateName = @"Application.Queries.TranslationsByIdQuery";
        foreach (var entity in entities.Where(x => x.IsLocalized))
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            var primaryKeys = string.Join(", ", entity.GetKeys().Select(k => $"{codeGenConventions.Solution.GetSinglePrimitiveTypeForKey(k)} key{k.Name}"));
            
            new TemplateCodeBuilder(context, codeGenConventions)
                .WithClassName($"Get{entity.Name}TranslationsByIdQuery")
                .WithFileNamePrefix($"Application.Queries")
                .WithObject("entity", entity)
                .WithObject("entityKeys", entity.GetKeys())
                .WithObject("primaryKeys", primaryKeys)
                .GenerateSourceCodeFromResource(templateName);
        }  
    }
}