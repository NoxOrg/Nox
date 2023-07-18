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
        code.AppendLine($"using AutoMapper;");

        code.AppendLine();
        code.AppendLine($"namespace {codeGeneratorState.ODataNameSpace};");
        code.AppendLine();

        GenerateModels(codeGeneratorState, solution, code, false);

        GenerateModels(codeGeneratorState, solution, code, true);

        code.GenerateSourceCode();
    }

    private static void GenerateModels(NoxSolutionCodeGeneratorState codeGeneratorState, NoxSolution solution, CodeBuilder code, bool isDto)
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
                code.AppendLine($"public class {entity.Name} : {codeGeneratorState.DomainNameSpace}.{baseClass}");
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

        if (!isDto)
        {
            code.AppendLine($"[AutoExpand]");
        }

        code.AppendLine($"public {propType}{nullable} {propName} {{ get; set; }} = null!;");
    }

    private static void GenerateProperty(CodeBuilder code, NoxSimpleTypeDefinition attribute, bool forceRequired = false)
    {
        var fields = GetNoxTypeInformation(attribute.Type);

        foreach (var (FieldName, FieldType) in fields)
        {
            GenerateDocs(code, attribute.Description);

            var propType = FieldType;
            var propName = string.IsNullOrEmpty(FieldName) ? attribute.Name : $"{attribute.Name}_{FieldName}";
            var nullable = (attribute.IsRequired || forceRequired) ? string.Empty : "?";

            code.AppendLine($"public {propType}{nullable} {propName} {{ get; set; }} = default!;");
        }
    }

    private static (string FieldName, string FieldType)[] GetNoxTypeInformation(NoxType noxType)
    {
        return noxType.GetComponents()
            .Select(kv => new Tuple<string, string>(kv.Key, kv.Value.Name))
            .Select(kv => (FieldName: kv.Item1, FieldType: kv.Item2))
            .ToArray();
    }
}