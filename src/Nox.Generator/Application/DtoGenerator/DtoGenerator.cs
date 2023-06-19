using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Nox.Solution;

namespace Nox.Generator.Application.DtoGenerator;

public class DtoGenerator
{
    public static void Generate(SourceProductionContext context, string solutionNameSpace, DataTransferObject dto)
    {
        var code = new CodeBuilder();

        code.AppendLine($"// Generated");
        code.AppendLine();
        code.AppendLine($"using Nox.Core.Interfaces.Entity;");
        code.AppendLine($"using Nox.Types;");
        code.AppendLine($"using System.Collections.Generic;");
        code.AppendLine();
        code.AppendLine($"namespace {solutionNameSpace}.Application.DataTransferObjects;");

        GenerateClassDocs(context, code, dto);

        code.AppendLine($"public partial class {dto.Name} : IDynamicDto");
        code.StartBlock();

        GenerateProperties(context, code, dto);

        code.EndBlock();
        
        context.AddSource($"{dto.Name}.cs", SourceText.From(code.ToString(), Encoding.UTF8));
    }
    
    private static void GenerateClassDocs(SourceProductionContext context, CodeBuilder code, DataTransferObject dto)
    {
        if (dto.Description is not null)
        {
            code.AppendLine();
            code.AppendLine($"/// <summary>");
            code.AppendLine($"/// {dto.Description.EnsureEndsWith('.')}");
            code.AppendLine($"/// </summary>");
        }
    }
    
    private static void GenerateProperties(SourceProductionContext context, CodeBuilder code, DataTransferObject dto)
    {
        foreach (var attribute in dto.Attributes)
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            GeneratePropertyDocs(context, code, attribute);

            var propType = attribute.Type.ToMappedType();
            var propName = attribute.Name;
            var nullable = attribute.IsRequired ? string.Empty : "?";

            code.AppendLine($"public {propType}{nullable} {propName} {{ get; set; }} = null!;");
        }
    }
    
    private static void GeneratePropertyDocs(SourceProductionContext context, CodeBuilder code, NoxSimpleTypeDefinition prop)
    {
        if (!string.IsNullOrWhiteSpace(prop.Description))
        {
            code.AppendLine();
            code.AppendLine($"/// <summary>");
            code.AppendLine($"/// {prop.Description!.TrimEnd('.')}.");
            code.AppendLine($"/// </summary>"); 
        }
    }
}