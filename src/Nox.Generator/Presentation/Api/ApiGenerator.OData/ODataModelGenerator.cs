using Humanizer;
using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Types;
using System;
using System.Linq;
using System.Reflection;
using static Nox.Generator.Common.BaseGenerator;

namespace Nox.Generator;

internal static class ODataModelGenerator
{
    public static void Generate(SourceProductionContext context, string solutionNameSpace, NoxSolution solution)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (solution.Domain is null ||
            !solution.Domain.Entities.Any())
        {
            return;
        }

        var code = new CodeBuilder($"ODataModel.g.cs", context);

        // Namespace
        code.AppendLine($"using Microsoft.AspNetCore.Http;");
        code.AppendLine($"using Microsoft.AspNetCore.OData;");
        code.AppendLine($"using Microsoft.OData.ModelBuilder;");

        code.AppendLine();
        code.AppendLine($"namespace {solutionNameSpace}.Presentation.Api.OData;");
        code.AppendLine();

        foreach (var entity in solution.Domain.Entities)
        {
            GenerateDocs(code, entity.Description);

            var baseClass = (entity.Persistence?.IsVersioned ?? true) ? "AuditableEntityBase" : "EntityBase";

            code.AppendLine($"public class {entity.Name} : {solutionNameSpace}.Domain.{baseClass}");
            code.StartBlock();

            if (entity.Keys != null)
            {
                foreach (var key in entity.Keys)
                {
                    GenerateProperty(code, key, forceRequired: true);
                }
            }

            if (entity.Attributes != null)
            {
                foreach (var attribute in entity.Attributes)
                {
                    GenerateProperty(code, attribute);
                }
            }

            if (entity.Relationships != null)
            {
                foreach (var relationship in entity.Relationships)
                {
                    GenerateRelationshipProperty(code, relationship);
                }
            }

            if (entity.OwnedRelationships != null)
            {
                foreach (var relationship in entity.OwnedRelationships)
                {
                    GenerateRelationshipProperty(code, relationship);
                }
            }

            code.EndBlock();
        }

        code.GenerateSourceCode();
    }

    private static void GenerateRelationshipProperty(CodeBuilder code, EntityRelationship relationship)
    {
        GenerateDocs(code, relationship.Description);

        var targetEntity = relationship.Entity;

        bool isMany = relationship.Relationship == EntityRelationshipType.ZeroOrMany || relationship.Relationship == EntityRelationshipType.OneOrMany;

        var propType = isMany ? $"List<{targetEntity}>" : targetEntity;
        var propName = isMany ? targetEntity.Pluralize() : targetEntity;

        var nullable = relationship.Relationship == EntityRelationshipType.ZeroOrOne ? "?" : string.Empty;

        code.AppendLine($"public {propType}{nullable} {propName} {{ get; set; }} = null!;");
    }

    private static void GenerateProperty(CodeBuilder code, NoxSimpleTypeDefinition attribute, bool forceRequired = false)
    {
        var fields = GetType(attribute.Type);

        foreach (var field in fields)
        {
            GenerateDocs(code, attribute.Description);

            var propType = field.Type;
            var propName = string.IsNullOrEmpty(field.FieldName) ? attribute.Name : $"{attribute.Name}_{field.FieldName}";
            var nullable = (attribute.IsRequired || forceRequired) ? string.Empty : "?";

            code.AppendLine($"public {propType}{nullable} {propName} {{ get; set; }} = default!;");
        }
    }

    private static (string FieldName, string Type)[] GetType(NoxType type)
    {
        // Assume objects and collections are represented as strings
        if (type == NoxType.Object || type == NoxType.Array || type == NoxType.Collection)
        {
            return new[] { (string.Empty, "string") };
        }

        var typeName = type.ToString(); // Assume that Enum member name can be used as type name
        var typeImplementation = Type.GetType($"Nox.Types.{typeName}, Nox.Types");

        // Check compound attribute
        var compoundType = typeof(NoxType)
            .GetField(typeName)
            .GetCustomAttribute<CompoundTypeAttribute>(false);

        if (typeImplementation != null)
        {
            if (compoundType != null)
            {
                // Return all compound properties
                return typeImplementation
                    .GetProperties()
                    .Where(p => p.Name != "Value")
                    .Select(p => (p.Name, p.PropertyType.ToString()))
                    .ToArray();
            }
            else
            {
                // Try to create an instance and retrieve the underlying type
                if (Activator.CreateInstance(typeImplementation) is INoxType instance)
                {
                    return new[] { (string.Empty, instance.GetUnderlyingType().ToString()) };
                }
            }
        }

        // Use string by default
        return new[] { (string.Empty, "string") };
    }
}