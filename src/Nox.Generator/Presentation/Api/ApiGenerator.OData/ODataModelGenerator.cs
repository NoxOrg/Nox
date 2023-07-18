using Humanizer;
using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Types;
using Nox.Types.Extensions;
using System;
using System.Diagnostics;
using System.Linq;

using static Nox.Generator.Common.BaseGenerator;

namespace Nox.Generator;

internal static class ODataModelGenerator
{
    public static void Generate(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState)
    {
        NoxSolution solution = codeGeneratorState.Solution;
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
        code.AppendLine($"namespace {codeGeneratorState.ODataNameSpace};");
        code.AppendLine();

        foreach (var entity in solution.Domain.Entities)
        {
            GenerateDocs(code, entity.Description);

            var baseClass = (entity.Persistence?.IsVersioned ?? true) ? "AuditableEntityBase" : "EntityBase";

            code.AppendLine($"public class {entity.Name} : {codeGeneratorState.DomainNameSpace}.{baseClass}");
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

        var fields = GetNoxTypeInformation(attribute.Type);

        foreach (var field in fields)
        {
            GenerateDocs(code, attribute.Description);

            var propType = field.Item2;
            var propName = string.IsNullOrEmpty(field.Item1) ? attribute.Name : $"{attribute.Name}_{field.Item1}";
            var nullable = (attribute.IsRequired || forceRequired) ? string.Empty : "?";

            code.AppendLine($"public {propType}{nullable} {propName} {{ get; set; }} = default!;");
        }
    }

    private static Tuple<string, string>[] GetNoxTypeInformation(NoxType noxType)
    {
        return noxType.GetComponents()
            .Select( kv => new Tuple<string,string>(kv.Key, kv.Value.Name))
            .ToArray();
        
    }
}