using Humanizer;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Nox.Solution;
using Nox.Types;
using System.Text;

namespace Nox.Generator;

internal class EntitiesGenerator
{

    public static void Generate(SourceProductionContext context, string solutionNameSpace, NoxSolution solution)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (solution.Domain is null) return;

        foreach (var entity in solution.Domain.Entities)
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            GenerateEntity(context, solutionNameSpace, entity);
        }
    }

    private static void GenerateEntity(SourceProductionContext context, string solutionNameSpace, Entity entity)
    {
        var code = new CodeBuilder($"{entity.Name}.g.cs", context);

        code.AppendLine($"using Nox.Types;");
        code.AppendLine($"using System.Collections.Generic;");
        code.AppendLine();
        code.AppendLine($"namespace {solutionNameSpace}.Domain;");

        GenerateStrongIdClassIfRequired(context, code, entity);

        GenerateClassDocs(context, code, entity);

        var baseClass = (entity.Persistence?.IsVersioned ?? true) ? "AuditableEntityBase" : "EntityBase";

        code.AppendLine($"public partial class {entity.Name} : {baseClass}");
        code.StartBlock();

            GenerateKeyProperties(context, code, entity);

            GenerateProperties(context, code, entity);

            GenerateRelationships(context, code, entity);

            GenerateOwnedRelationships(context, code, entity);

        code.EndBlock();

        code.GenerateSourceCode();
    }

    private static void GenerateStrongIdClassIfRequired(SourceProductionContext context, CodeBuilder code, Entity entity)
    {
        if (entity.Keys is null)
            return;

        // Only for single key entities

        if (entity.Keys.Count == 1)
        {
            GenerateStrongSingleKeyClass(context, code, entity, entity.Keys[0]);
        }
    }

    private static void GenerateStrongSingleKeyClass(SourceProductionContext context, CodeBuilder code, Entity entity, NoxSimpleTypeDefinition key)
    {
        var className = $"{entity.Name}{key.Name}";
        var underlyingType = MapType(key.Type);

        code.AppendLine();
        code.AppendLine($"/// <summary>");
        code.AppendLine($"/// The identifier (primary key) for a {entity.Name}.");
        code.AppendLine($"/// </summary>");
        code.AppendLine($"public class {className} : ValueObject<{underlyingType},{className}> {{}}");
    }

    private static void GenerateKeyProperties(SourceProductionContext context, CodeBuilder code, Entity entity)
    {
        if (entity.Keys is null)
            return;

        // Only for single key entities

        if (entity.Keys.Count == 1)
        {
            GenerateStrongSingleKeyProperty(context, code, entity, entity.Keys[0]);
        }
    }

    private static void GenerateStrongSingleKeyProperty(SourceProductionContext context, CodeBuilder code, Entity entity, NoxSimpleTypeDefinition key)
    {
        GeneratePropertyDocs(context, code, key);

        var propType = $"{entity.Name}{key.Name}";
        var propName = key.Name;

        code.AppendLine($"public {propType} {propName} {{ get; set; }} = null!;");
    }

    private static void GenerateProperties(SourceProductionContext context, CodeBuilder code, Entity entity)
    {

        if (entity.Attributes is null)
            return;

        foreach (var attribute in entity.Attributes)
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            GeneratePropertyDocs(context, code, attribute);

            var propType = MapType(attribute.Type);
            var propName = attribute.Name;
            var nullable = attribute.IsRequired ? string.Empty : "?";

            code.AppendLine($"public {propType}{nullable} {propName} {{ get; set; }} = null!;");
        }
    }

    private static void GenerateRelationships(SourceProductionContext context, CodeBuilder code, Entity entity)
    {
        if(entity.Relationships is null) 
            return;

        foreach(var relationship in entity.Relationships)
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            GenerateRelationshipProperty(context, code, entity, relationship);
        }
    }

    private static void GenerateOwnedRelationships(SourceProductionContext context, CodeBuilder code, Entity entity)
    {
        if (entity.OwnedRelationships is null)
            return;

        foreach (var relationship in entity.OwnedRelationships)
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            GenerateRelationshipProperty(context, code, entity, relationship);
        }
    }

    private static void GenerateRelationshipProperty(SourceProductionContext context, CodeBuilder code, Entity entity, EntityRelationship relationship)
    {
        GenerateRelationshipDocs(context, code, entity, relationship);

        var targetEntity = relationship.Entity;

        var propType = relationship.Relationship == EntityRelationshipType.ZeroOrMany || relationship.Relationship == EntityRelationshipType.ZeroOrMany
                        ? $"List<{targetEntity}>"
                        : targetEntity;

        var propName = targetEntity.Pluralize();

        var nullable = relationship.Relationship == EntityRelationshipType.ZeroOrOne ? "?" : string.Empty;

        code.AppendLine($"public {propType}{nullable} {propName} {{ get; set; }} = null!;");
    }

    private static void GeneratePropertyDocs(SourceProductionContext context, CodeBuilder code, NoxSimpleTypeDefinition prop)
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

    private static void GenerateClassDocs(SourceProductionContext context, CodeBuilder code, Entity entity)
    {
        if (entity.Description is not null)
        {
            code.AppendLine();
            code.AppendLine($"/// <summary>");
            code.AppendLine($"/// {entity.Description.EnsureEndsWith('.')}");
            code.AppendLine($"/// </summary>");
        }
    }
    private static void GenerateRelationshipDocs(SourceProductionContext context, CodeBuilder code, Entity entity, EntityRelationship relationship)
    {
        code.AppendLine();
        code.AppendLine($"/// <summary>");
        code.AppendLine($"/// {entity.Name} {relationship.Description} {relationship.Relationship} {relationship.Entity.Pluralize()}");
        code.AppendLine($"/// </summary>");
    }

    private static string MapType(NoxType noxType)
    {
        return noxType switch
        {
            _ => noxType.ToString(),
        };
    }
}
