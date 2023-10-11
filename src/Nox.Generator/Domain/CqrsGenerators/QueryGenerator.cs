using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;

using static Nox.Generator.Common.BaseGenerator;
using static Nox.Generator.Common.NamingConstants;

namespace Nox.Generator.Domain.CqrsGenerators;

internal class QueryGenerator : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Domain;

    public void Generate(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState, GeneratorConfig config, string outputPath)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGeneratorState.Solution.Domain == null) return;

        foreach (var entity in codeGeneratorState.Solution.Domain.Entities)
        {
            context.CancellationToken.ThrowIfCancellationRequested();
            if (entity.Queries == null || !entity.Queries.Any()) continue;
            foreach (var qry in entity.Queries)
            {
                context.CancellationToken.ThrowIfCancellationRequested();
                GenerateQuery(context, codeGeneratorState, qry);
            }
        }
    }

    private static void GenerateQuery(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState, DomainQuery qry)
    {
        var className = qry.Name.EnsureEndsWith("QueryBase");

        var code = new CodeBuilder($"{className}.g.cs", context);

        code.AppendLine($"using Nox.Types;");
        code.AppendLine($"using System.Collections.Generic;");
        code.AppendLine($"using System.Threading.Tasks;");
        code.AppendLine($"using {codeGeneratorState.DomainNameSpace};");
        code.AppendLine($"using {codeGeneratorState.DataTransferObjectsNameSpace};");
        code.AppendLine($"using {codeGeneratorState.PersistenceNameSpace};");
        code.AppendLine();
        code.AppendLine($"namespace {codeGeneratorState.ApplicationNameSpace};");

        GenerateDocs(code, qry.Description!);

        code.AppendLine($"public abstract partial class {className}");
        code.StartBlock();

        var dbContextName = $"{codeGeneratorState.RootNameSpace}{DbContextName}";
        AddField(code, dbContextName, DbContextName, "Represents the DB context.");

        // Add constructor
        AddConstructor(code, className, new Dictionary<string, string> {
            { dbContextName, DbContextName }
        });

        // Add params (which can be DTO)
        var parameters = GetParametersString(qry.RequestInput);

        var typeDefinition = GenerateTypeDefinition(context, codeGeneratorState, qry.ResponseOutput, generateDto: true);

        code.AppendLine($@"public abstract Task<{typeDefinition}> ExecuteAsync({parameters});");

        code.EndBlock();

        code.GenerateSourceCode();
    }
}