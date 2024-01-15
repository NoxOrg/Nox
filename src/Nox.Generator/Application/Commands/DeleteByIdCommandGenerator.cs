using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using System.Collections.Generic;
using System.Linq;

namespace Nox.Generator.Application.Commands;

internal class DeleteByIdCommandGenerator : ApplicationEntityDependentGeneratorBase
{
    protected override void DoGenerate(SourceProductionContext context, NoxCodeGenConventions codeGenConventions, IEnumerable<Entity> entities)
    {
        var templateName = @"Application.Commands.DeleteByIdCommand";
        foreach (var entity in entities.Where(x => !x.IsOwnedEntity))
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            var primaryKeys = string.Join(", ", entity.Keys.Select(k => $"{codeGenConventions.Solution.GetSinglePrimitiveTypeForKey(k)} key{k.Name}"));
            var primaryKeysQuery = string.Join(", ", entity.Keys.Select(k => $"key{k.Name}"));

            new TemplateCodeBuilder(context, codeGenConventions)
                .WithClassName($"Delete{entity.Name}ByIdCommand")
                .WithFileNamePrefix($"Application.Commands")
                .WithObject("entity", entity)
                .GenerateSourceCodeFromResource(templateName);
        }
    }
}