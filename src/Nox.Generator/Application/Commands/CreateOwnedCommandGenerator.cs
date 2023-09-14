﻿using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Solution.Extensions;
using System.Linq;

namespace Nox.Generator.Application.Commands;

internal class CreateOwnedCommandGenerator : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Domain;

    public void Generate(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState, GeneratorConfig config)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGeneratorState.Solution.Domain is null)
        {
            return;
        }

        var templateName = @"Application.Commands.CreateOwnedCommand";
        foreach (var entity in codeGeneratorState.Solution.Domain.Entities)
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            foreach(var ownedRelationship in entity.OwnedRelationships)
            {
                var ownedEntity = codeGeneratorState.Solution.Domain.Entities.Single(entity => entity.Name == ownedRelationship.Entity);

                var parentKeysFindQuery = string.Join(", ", entity.Keys.Select(k => $"key{k.Name}"));
                var primaryKeysReturnQuery = string.Join(", ", ownedEntity.Keys.Select(k => $"entity.{k.Name}.Value"));

                new TemplateCodeBuilder(context, codeGeneratorState)
                    .WithClassName($"Create{ownedEntity.Name}For{entity.Name}Command")
                    .WithFileNamePrefix($"Application.Commands")
                    .WithObject("entity", ownedEntity)
                    .WithObject("parent", entity)
                    .WithObject("isSingleRelationship", ownedRelationship.WithSingleEntity)
                    .WithObject("parentKeysFindQuery", parentKeysFindQuery)
                    .WithObject("primaryKeysReturnQuery", primaryKeysReturnQuery)
                    .GenerateSourceCodeFromResource(templateName);
            }
           
        }
    }
}