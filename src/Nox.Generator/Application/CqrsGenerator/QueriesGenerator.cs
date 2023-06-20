using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Nox.Solution;
using Nox.Types;
using System;
using System.Collections.Generic;
using System.Text;

using static Nox.Generator._Common.BaseGenerator;
using static Nox.Generator._Common.NamingConstants;

namespace Nox.Generator;

internal class QueriesGenerator
{
    public static void Generate(SourceProductionContext context, string solutionNameSpace, DomainQuery query)
    {
        if (query is null)
        {
            throw new ArgumentNullException(nameof(query));
        }

        var code = new CodeBuilder();

        var className = $"{query.Name}Query";

        code.AppendLine($"// Generated");
        code.AppendLine();
        code.AppendLine($"using Nox.Types;");
        code.AppendLine($"using System.Collections.Generic;");
        code.AppendLine($"using System.Threading.Tasks;");
        code.AppendLine($"using {solutionNameSpace}.Domain;");
        code.AppendLine();
        code.AppendLine($"namespace {solutionNameSpace}.Application;");

        GenerateDocs(code, query.Description);

        code.AppendLine($"public abstract partial class {className}");
        code.AppendLine($"{{");

        code.Indent();

        var dbContextName = $"{solutionNameSpace}{DbContextName}";
        AddProperty(code, dbContextName, DbContextName, "Represents the DB context.");

        // Add constructor
        AddConstructor(code, className, new Dictionary<string, string> {
                { dbContextName, DbContextName }
            });

        // Add params (which can be DTO)
        string parameters = GetParametersString(query.RequestInput);

        bool isMany = query.ResponseOutput.Type == NoxType.Array || query.ResponseOutput.Type == NoxType.Collection;
        var dto = query.ResponseOutput.Name;

        var typeDefinition = isMany ? $"IEnumerable<{dto}>" : $"{dto}";

        code.AppendLine($@"public abstract Task<{typeDefinition}> ExecuteAsync({parameters});");

        code.UnIndent();

        code.AppendLine($"}}");

        context.AddSource($"{className}.cs", SourceText.From(code.ToString(), Encoding.UTF8));
    }
}
