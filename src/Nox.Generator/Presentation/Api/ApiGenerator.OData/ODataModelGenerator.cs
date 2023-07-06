using Humanizer;
using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Types;
using System.Linq;

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

            code.AppendLine($"public class {entity.Name}");
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
        GenerateDocs(code, attribute.Description);

        var propType = GetType(attribute.Type);
        var propName = attribute.Name;
        var nullable = (attribute.IsRequired || forceRequired) ? string.Empty : "?";

        code.AppendLine($"public {propType}{nullable} {propName} {{ get; set; }} = default!;");
    }

    private static string GetType(NoxType type)
    {
        // TODO: add other types
        return type switch
        {
            NoxType.Text => new Text().GetUnderlyingType().ToString(),
            NoxType.Number => new Number().GetUnderlyingType().ToString(),
            _ => "string",
        };
    }
}