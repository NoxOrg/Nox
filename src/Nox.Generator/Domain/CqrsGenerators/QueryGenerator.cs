using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Nox.Generator._Common;
using Nox.Solution;

using static Nox.Generator._Common.BaseGenerator;
using static Nox.Generator._Common.NamingConstants;

namespace Nox.Generator.Domain.CqrsGenerators;

public class QueryGenerator
{
    public static void Generate(SourceProductionContext context, string solutionNameSpace, NoxSolution solution)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (solution.Domain == null) return;

        foreach (var entity in solution.Domain.Entities)
        {
            context.CancellationToken.ThrowIfCancellationRequested();
            if (entity.Queries == null || !entity.Queries.Any()) continue;
            foreach (var qry in entity.Queries)
            {
                context.CancellationToken.ThrowIfCancellationRequested();
                GenerateQuery(context, solutionNameSpace, qry);
            }
        }
    }

    private static void GenerateQuery(SourceProductionContext context, string solutionNameSpace, DomainQuery qry)
    {
        var className = qry.Name.EnsureEndsWith("Query");

        var code = new CodeBuilder($"{className}.g.cs", context);

        code.AppendLine($"using Nox.Types;");
        code.AppendLine($"using System.Collections.Generic;");
        code.AppendLine($"using System.Threading.Tasks;");
        code.AppendLine($"using {solutionNameSpace}.Domain;");
        code.AppendLine($"using {solutionNameSpace}.Application.DataTransferObjects;");
        code.AppendLine($"using {solutionNameSpace}.Infrastructure.Persistence;");
        code.AppendLine();
        code.AppendLine($"namespace {solutionNameSpace}.Application;");

        GenerateDocs(code, qry.Description!);

        code.AppendLine($"public abstract partial class {className}");
        code.StartBlock();

        var dbContextName = $"{solutionNameSpace}{DbContextName}";
        AddProperty(code, dbContextName, DbContextName, "Represents the DB context.");

        // Add constructor
        AddConstructor(code, className, new Dictionary<string, string> {
            { dbContextName, DbContextName }
        });

        // Add params (which can be DTO)
        var parameters = GetParametersString(qry.RequestInput);

        var typeDefinition = GenerateTypeDefinition(context, solutionNameSpace, qry.ResponseOutput);

        code.AppendLine($@"public abstract Task<{typeDefinition}> ExecuteAsync({parameters});");

        code.EndBlock();

        code.GenerateSourceCode();
    }

}