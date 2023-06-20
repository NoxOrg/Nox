using Nox.Solution;
using Nox.Types;
using System.Collections.Generic;
using System.Linq;

namespace Nox.Generator._Common
{
    internal class BaseGenerator
    {
        internal static void GenerateDocs(CodeBuilder code, string description)
        {
            if (!string.IsNullOrWhiteSpace(description))
            {
                code.AppendLine();
                code.AppendLine($"/// <summary>");
                code.AppendLine($"/// {description.EnsureEndsWith('.')}");
                code.AppendLine($"/// </summary>");
            }
        }       

        internal static void AddProperty(CodeBuilder code, string type, string name, string description)
        {
            code.AppendLine();
            GenerateDocs(code, description);
            code.AppendLine($"protected {type} {name} {{ get; set; }} = null!;");
        }

        internal static string GetParametersString(IEnumerable<DomainQueryRequestInput> input, bool withDefaults = true)
        {
            // TODO: switch to a general type resolver and error processing
            // TODO: implement default values
            return string.Join(", ", input
                .Select(parameter => $"{(parameter.Type != NoxType.Entity ? MapType(parameter.Type) : parameter.EntityTypeOptions.Entity)} {parameter.Name}"));
        }

        internal static string MapType(NoxType noxType)
        {
            return noxType switch
            {
                NoxType.Latlong => "LatLong",
                _ => noxType.ToString(),
            };
        }

        internal static void AddConstructor(CodeBuilder code, string className, Dictionary<string, string> parameters)
        {
            code.AppendLine();
            code.AppendLine($@"public {className}(");
            code.Indent();
            for (int i = 0; i < parameters.Count; i++)
            {
                var parameter = parameters.ElementAt(i);
                code.AppendLine($@"{parameter.Key} {parameter.Value.ToLowerFirstChar()}{(i < parameters.Count - 1 ? "," : string.Empty)}");
            }
            code.UnIndent();
            code.AppendLine($@")");
            code.AppendLine($@"{{");

            code.Indent();
            foreach (var value in parameters.Select(p => p.Value))
            {
                code.AppendLine($@"{value} = {value.ToLowerFirstChar()};");
            }
            code.UnIndent();
            code.AppendLine($@"}}");
            code.AppendLine($@"");
        }
    }
}