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
        code.AppendLine($"using AutoMapper;");

        code.AppendLine();
        code.AppendLine($"namespace {solutionNameSpace}.Presentation.Api.OData;");
        code.AppendLine();

        GenerateModels(solutionNameSpace, solution, code, false);

        GenerateModels(solutionNameSpace, solution, code, true);

        code.GenerateSourceCode();
    }

    private static void GenerateModels(string solutionNameSpace, NoxSolution solution, CodeBuilder code, bool isDto)
    {
        foreach (var entity in solution!.Domain!.Entities)
        {
            GenerateDocs(code, entity.Description);

            if (isDto)
            {
                code.AppendLine($"public class {entity.Name}Dto");
            }
            else
            {
                var baseClass = (entity.Persistence?.IsVersioned ?? true) ? "AuditableEntityBase" : "EntityBase";

                code.AppendLine($"[AutoMap(typeof({entity.Name}Dto))]");
                code.AppendLine($"public class {entity.Name} : {solutionNameSpace}.Domain.{baseClass}");
            }

            code.StartBlock();

            if (entity.Keys != null)
            {
                foreach (var key in entity.Keys)
                {
                    // TODO: check auto generated keys
                    if (!isDto)
                    {
                        GenerateProperty(code, key, forceRequired: true);
                    }
                }
            }

            if (entity.Attributes != null)
            {
                foreach (var attribute in entity.Attributes)
                {
                    GenerateProperty(code, attribute);
                }
            }

            // TBD - logic for DTO
            if (!isDto)
            {
                if (entity.Relationships != null)
                {
                    foreach (var relationship in entity.Relationships)
                    {
                        GenerateRelationshipProperty(code, relationship, isDto);
                    }
                }

                if (entity.OwnedRelationships != null)
                {
                    foreach (var relationship in entity.OwnedRelationships)
                    {
                        GenerateRelationshipProperty(code, relationship, isDto);
                    }
                }
            }

            code.EndBlock();
        }
    }

    private static void GenerateRelationshipProperty(CodeBuilder code, EntityRelationship relationship, bool isDto)
    {
        GenerateDocs(code, relationship.Description);

        var targetEntity = isDto ? $"{relationship.Entity}Dto" : relationship.Entity;

        bool isMany = relationship.Relationship == EntityRelationshipType.ZeroOrMany || relationship.Relationship == EntityRelationshipType.OneOrMany;

        var propType = isMany ? $"List<{targetEntity}>" : targetEntity;
        var propName = relationship.Name;

        var nullable = relationship.Relationship == EntityRelationshipType.ZeroOrOne ? "?" : string.Empty;

        if (isDto)
        {
            code.AppendLine($"[AutoExpand]");
        }

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
        // Assume objects and collections are represented as strings - TBD
        if (type == NoxType.Object || type == NoxType.Collection || type == NoxType.Array)
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