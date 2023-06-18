using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Nox.Solution;
using Nox.Types;
using System;
using System.Text;

namespace NoxSourceGenerator;

internal class EntityGenerator
{
    public static void Generate(SourceProductionContext context, string solutionNameSpace, Entity entity)
    {
        var code = new CodeBuilder();

        code.AppendLine($"// Generated");
        code.AppendLine();
        code.AppendLine($"using Nox.Types;");
        code.AppendLine();
        code.AppendLine($"namespace {solutionNameSpace}.Domain;");
        code.AppendLine();

        GenerateStrongIdClassIfRequired(code, entity);

        GenerateClassDocs(code, entity);

        code.AppendLine($"public partial class {entity.Name}");
        code.AppendLine($"{{");

        code.Indent();

        GenerateKeyProperties(code, entity);

        GenerateProperties(code, entity);

        code.UnIndent();

        code.AppendLine($"}}");

        context.AddSource($"{entity.Name}.cs", SourceText.From(code.ToString(), Encoding.UTF8));
    }

    private static void GenerateStrongIdClassIfRequired(CodeBuilder code, Entity entity)
    {
        if (entity.Keys is null)
            return;

        // Only for single key entities

        if (entity.Keys.Count == 1)
        {
            GenerateStrongSingleKeyClass(code, entity, entity.Keys[0]);
        }
    }

    private static void GenerateStrongSingleKeyClass(CodeBuilder code, Entity entity, NoxSimpleTypeDefinition key)
    {
        var className = $"{entity.Name}{key.Name}";
        var underlyingType = MapType(key.Type);

        code.AppendLine($"/// <summary>");
        code.AppendLine($"/// The identifier (primary key) for a {entity.Name}.");
        code.AppendLine($"/// <summary>");
        code.AppendLine($"public class {className} : ValueObject<{underlyingType},{className}> {{}}");
        code.AppendLine();
    }

    private static void GenerateKeyProperties(CodeBuilder code, Entity entity)
    {
        if (entity.Keys is null)
            return;

        // Only for single key entities

        if (entity.Keys.Count == 1)
        {
            GenerateStrongSingleKeyProperty(code, entity, entity.Keys[0]);
        }
    }

    private static void GenerateStrongSingleKeyProperty(CodeBuilder code, Entity entity, NoxSimpleTypeDefinition key)
    {
        GeneratePropertyDocs(code, key);

        var propType = $"{entity.Name}{key.Name}";
        var propName = MapType(key.Type);

        code.AppendLine($"public {propType} {propName} {{ get; set; }} = null!;");
    }

    private static void GenerateProperties(CodeBuilder code, Entity entity)
    {

        if (entity.Attributes is null)
            return;

        foreach (var attribute in entity.Attributes)
        {
            GeneratePropertyDocs(code, attribute);

            var propType = MapType(attribute.Type);
            var propName = attribute.Name;
            var nullable = attribute.IsRequired ? string.Empty : "?";

            code.AppendLine($"public {propType}{nullable} {propName} {{ get; set; }} = null!;");
        }
    }

    private static void GeneratePropertyDocs(CodeBuilder code, NoxSimpleTypeDefinition prop)
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

    private static void GenerateClassDocs(CodeBuilder code, Entity entity)
    {
        if (entity.Description is not null)
        {
            code.AppendLine();
            code.AppendLine($"/// <summary>");
            code.AppendLine($"/// {entity.Description.EnsureEndsWith('.')}");
            code.AppendLine($"/// </summary>");
        }
    }

    private static string MapType(NoxType noxType)
    {
        return noxType switch
        {
            NoxType.Latlong => "LatLong",
            _ => noxType.ToString(),
        };
    }
}
