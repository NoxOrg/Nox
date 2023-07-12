using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using System.Linq;

using static Nox.Generator.Common.BaseGenerator;

namespace Nox.Generator;

internal static class ODataDbContextGenerator
{
    public static void Generate(SourceProductionContext context, string solutionNameSpace, NoxSolution solution)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (solution.Domain is null ||
            !solution.Domain.Entities.Any())
        {
            return;
        }

        var code = new CodeBuilder($"ODataDbContext.g.cs", context);

        // Namespace
        code.AppendLine(@"using Microsoft.EntityFrameworkCore;");
        code.AppendLine(@"using Nox.Solution;");
        code.AppendLine(@"using Nox.Types.EntityFramework.Abstractions;");

        code.AppendLine();
        code.AppendLine($"namespace {solutionNameSpace}.Presentation.Api.OData;");
        code.AppendLine();

        string dbContextName = "ODataDbContext";

        // Db Context
        code.AppendLine($"public class {dbContextName} : DbContext");

        // Class
        code.StartBlock();
        code.AppendLine();

        AddField(code, "NoxSolution", "noxSolution", "The Nox sulution configuration");
        AddField(code, "INoxDatabaseProvider", "dbProvider", "The database provider");

        // Constructor content

        // Add constructor
        code.Indent();
        code.AppendLine($"public {dbContextName}(");
        code.AppendLine($"    DbContextOptions<{dbContextName}> options,");
        code.AppendLine("    NoxSolution noxSolution,");
        code.AppendLine("    INoxDatabaseProvider databaseProvider");
        code.AppendLine(") : base(options)");
        code.StartBlock();
        code.AppendLine("_noxSolution = noxSolution;");
        code.AppendLine("_dbProvider = databaseProvider;");
        code.EndBlock();
        code.AppendLine();

        foreach (var entity in solution.Domain.Entities)
        {
            code.AppendLine($"public DbSet<{entity.Name}> {entity.PluralName} {{ get; set; }} = null!;");
            code.AppendLine();
        }

        AddDbContextOnConfiguring(code, solutionNameSpace);

        code.EndBlock();

        code.GenerateSourceCode();
    }
}