using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Solution.Extensions;
using System.Linq;

namespace Nox.Generator.Application.Commands;

internal class RefToCommandGenerator : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Domain;
    public void Generate(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState, GeneratorConfig config)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGeneratorState.Solution.Domain is null)
        {
            return;
        }

        var templateName = @"Application.Commands.RefToCommand";
        foreach (var entity in codeGeneratorState.Solution.Domain.Entities.Where(x => !x.IsOwnedEntity))
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            if (entity.Relationships is null)
                continue;

            foreach (var relationship in entity.Relationships)
            {
                var entityKeysFindQuery = string.Join(", ", entity.Keys.Select(k => $"key{k.Name}"));
                var relatedEntityKeysFindQuery = string.Join(", ", 
                    relationship.Related.Entity.Keys.Select(k => $"relatedKey{k.Name}"));

                new TemplateCodeBuilder(context, codeGeneratorState)
                    .WithClassName($"Ref{entity.Name}To{relationship.Name}Command")
                    .WithFileNamePrefix($"Application.Commands")
                    .WithObject("entity", entity)
                    .WithObject("relationship", relationship)
                    .WithObject("entityKeysFindQuery", entityKeysFindQuery)
                    .WithObject("relatedEntityKeysFindQuery", relatedEntityKeysFindQuery)
                    .GenerateSourceCodeFromResource(templateName);
            }
        }

    }
}