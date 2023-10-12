using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Solution.Extensions;
using System.Linq;

namespace Nox.Generator.Application.Commands;

internal class DeleteOwnedCommandGenerator : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Domain;

    public void Generate(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState, GeneratorConfig config, string? projectRootPath)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGeneratorState.Solution.Domain is null)
        {
            return;
        }

        var templateName = @"Application.Commands.DeleteOwnedCommand";
        foreach (var entity in codeGeneratorState.Solution.Domain.Entities)
        {
            context.CancellationToken.ThrowIfCancellationRequested();
            foreach (var ownedRelationship in entity.OwnedRelationships)
            {
                var ownedEntity = codeGeneratorState.Solution.Domain.Entities.Single(entity => entity.Name == ownedRelationship.Entity);

                var parentKeysFindQuery = string.Join(", ", entity.Keys.Select(k => $"key{k.Name}"));
                var ownedKeysFindQuery = string.Join(" && ", ownedEntity.Keys.Select(k => $"x.{k.Name} == owned{k.Name}"));

                new TemplateCodeBuilder(context, codeGeneratorState)
                    .WithClassName($"Delete{ownedEntity.Name}For{entity.Name}Command")
                    .WithFileNamePrefix($"Application.Commands")
                    .WithObject("relationship", ownedRelationship)
                    .WithObject("entity", ownedEntity)
                    .WithObject("parent", entity)
                    .WithObject("isSingleRelationship", ownedRelationship.WithSingleEntity)
                    .WithObject("parentKeysFindQuery", parentKeysFindQuery)
                    .WithObject("ownedKeysFindQuery", ownedKeysFindQuery)
                    .GenerateSourceCodeFromResource(templateName);
            }
        }
    }
}