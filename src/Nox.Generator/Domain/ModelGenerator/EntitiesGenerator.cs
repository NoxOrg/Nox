using System.Linq;
using Humanizer;
using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Types;

namespace Nox.Generator;

internal static class EntitiesGenerator
{
    public static void Generate(
        SourceProductionContext context,
        NoxSolutionCodeGeneratorState codeGeneratorState)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGeneratorState.Solution.Domain is null) return;

        foreach (var entity in codeGeneratorState.Solution.Domain.Entities)
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            GenerateEntity(context, codeGeneratorState, entity);
        }
    }

    private static void GenerateEntity(
        SourceProductionContext context,
        NoxSolutionCodeGeneratorState codeGeneratorState,
        Entity entity)
    {
        var code = new CodeBuilder($"{entity.Name}.g.cs", context);

        code.AppendLine($"using Nox.Types;");
        code.AppendLine($"using System;");
        code.AppendLine($"using System.Collections.Generic;"); 
        code.AppendLine($"using System.ComponentModel.DataAnnotations.Schema;");
        code.AppendLine();
        code.AppendLine($"namespace {codeGeneratorState.DomainNameSpace};");

        GenerateClassDocs(code, entity);

        var baseClass = (entity.Persistence?.IsVersioned ?? true) ? "AuditableEntityBase" : "EntityBase";

        code.AppendLine($"public partial class {entity.Name} : {baseClass}");
        code.StartBlock();

            GenerateKeyProperties(codeGeneratorState, context, code, entity);

            GenerateProperties(context, code, entity);

            GenerateRelationships(context, code, entity);

            GenerateOwnedRelationships(context, code, entity);

        code.EndBlock();

        code.GenerateSourceCode();
    }

    private static void GenerateKeyProperties(
        NoxSolutionCodeGeneratorState codeGeneratorState,
        SourceProductionContext context,
        CodeBuilder code,
        Entity entity)
    {
        if (entity.Keys is null)
            return;

        foreach (var key in entity.Keys)
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            GeneratePropertyDocs(code, key);

            if (key.Type == NoxType.Entity)
            {
                GenerateStrongSingleKeyEntityProperty(codeGeneratorState, code, entity, key);
            }
            else
            {
                GenerateStrongSingleKeySimpleProperty(code, entity, key);
            }
            
        }
    }
    private static void GenerateStrongSingleKeyEntityProperty(
        NoxSolutionCodeGeneratorState codeGeneratorState,
        CodeBuilder code,
        Entity entity,
        NoxSimpleTypeDefinition key)
    {
        // Generates foreign key simple type 
        var propNameId = codeGeneratorState.GetForeignKeyPropertyName(key.EntityTypeOptions!.Entity);
        var foreignKeyDefinition = GetKeyForEntity(codeGeneratorState.Solution, key.EntityTypeOptions!.Entity);
        var propTypeSimpleId = foreignKeyDefinition.Type;

        code.AppendLine($"public {propTypeSimpleId} {propNameId} {{ get; set; }} = null!;");

        // Generates the Navigation Property
        var propType = key.EntityTypeOptions!.Entity;
        var propName = key.Name;
        code.AppendLine($"public virtual {propType} {propName} {{ get; set; }} = null!;");
    }

    
    private static NoxSimpleTypeDefinition GetKeyForEntity(
        NoxSolution noxSolution,
        string foreignKeyEntityName)
    {
        
        var foreignEntity = noxSolution.Domain!.Entities.Single(entity => entity.Name.Equals(foreignKeyEntityName));

        // TODO support composite foreignKey keys
        return foreignEntity.Keys!.Single();
    }

    private static void GenerateStrongSingleKeySimpleProperty(
        CodeBuilder code,
        Entity entity,
        NoxSimpleTypeDefinition key)
    {
        var propName = key.Name;

        code.AppendLine($"public {key.Type} {propName} {{ get; set; }} = null!;");
    }

    private static void GenerateProperties(
        SourceProductionContext context,
        CodeBuilder code,
        Entity entity)
    {
        if (entity.Attributes is null)
        {
            return;
        }

        foreach (var attribute in entity.Attributes)
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            GeneratePropertyDocs(code, attribute);

            var propType = attribute.Type.ToString();
            var propName = attribute.Name;
            var nullable = attribute.IsRequired ? string.Empty : "?";

            code.AppendLine($"public {propType}{nullable} {propName} {{ get; set; }} = null!;");
        }
    }

    private static void GenerateRelationships(
        SourceProductionContext context,
        CodeBuilder code,
        Entity entity)
    {
        if (entity.Relationships is null) 
            return;

        foreach (var relationship in entity.Relationships)
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            GenerateRelationshipProperty(code, entity, relationship);
        }
    }

    private static void GenerateOwnedRelationships(
        SourceProductionContext context,
        CodeBuilder code,
        Entity entity)
    {
        if (entity.OwnedRelationships is null)
            return;

        foreach (var relationship in entity.OwnedRelationships)
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            GenerateRelationshipProperty(code, entity, relationship);
        }
    }

    private static void GenerateRelationshipProperty(
        CodeBuilder code,
        Entity entity,
        EntityRelationship relationship)
    {
        GenerateRelationshipDocs(code, entity, relationship);

        var targetEntity = relationship.Entity;

        var propType = relationship.Relationship == EntityRelationshipType.ZeroOrMany || relationship.Relationship == EntityRelationshipType.OneOrMany
                        ? $"List<{targetEntity}>"
                        : targetEntity;

        var propName = relationship.Relationship == EntityRelationshipType.ZeroOrMany || relationship.Relationship == EntityRelationshipType.OneOrMany
                        ? targetEntity.Pluralize()
                        : targetEntity;

        var nullable = relationship.Relationship == EntityRelationshipType.ZeroOrOne ? "?" : string.Empty;

        code.AppendLine($"public virtual {propType}{nullable} {propName} {{ get; set; }} = new {propType}();");
        
        if (propName != relationship.Name)
        {
            code.AppendLine();
            code.AppendLine($"public {propType}{nullable} {relationship.Name} => {propName};");
        }
    }

    private static void GeneratePropertyDocs(
        CodeBuilder code,
        NoxSimpleTypeDefinition prop)
    {
        var optionalText = prop.IsRequired ? "Required" : "Optional";

        if (string.IsNullOrWhiteSpace(prop.Description))
        {
            code.AppendLine();
            code.AppendLine($"/// <summary>");
            code.AppendLine($"/// ({optionalText})");
            code.AppendLine($"/// </summary>");
        }
        else
        {
            code.AppendLine();
            code.AppendLine($"/// <summary>");
            code.AppendLine($"/// {prop.Description!.TrimEnd('.')} ({optionalText.ToLower()}).");
            code.AppendLine($"/// </summary>"); 
        }
    }

    private static void GenerateClassDocs(
        CodeBuilder code,
        Entity entity)
    {
        if (entity.Description is not null)
        {
            code.AppendLine();
            code.AppendLine($"/// <summary>");
            code.AppendLine($"/// {entity.Description.EnsureEndsWith('.')}");
            code.AppendLine($"/// </summary>");
        }
    }
    private static void GenerateRelationshipDocs(
        CodeBuilder code,
        Entity entity,
        EntityRelationship relationship)
    {
        code.AppendLine();
        code.AppendLine($"/// <summary>");
        code.AppendLine($"/// {entity.Name} {relationship.Description} {relationship.Relationship} {relationship.Entity.Pluralize()}");
        code.AppendLine($"/// </summary>");
    }
}
