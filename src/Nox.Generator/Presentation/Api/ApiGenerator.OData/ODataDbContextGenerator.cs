using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using System.Linq;

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

        code.AppendLine();
        code.AppendLine($"namespace {solutionNameSpace}.Presentation.Api.OData;");
        code.AppendLine();       

        // Db Context
        code.AppendLine($"public class ODataDbContext : DbContext");

        // Class
        code.StartBlock();
        code.AppendLine();

        // Constructor
        code.AppendLine($"public ODataDbContext(");

        // Constructor content
        code.Indent();
        code.AppendLine($"DbContextOptions<ODataDbContext> options");
        code.AppendLine($") : base(options)");
        code.UnIndent();
        code.AppendLine($"{{");
        code.AppendLine($"}}");
        code.AppendLine();

        foreach (var entity in solution.Domain.Entities)
        {
            code.AppendLine($"public DbSet<{entity.Name}> {entity.PluralName} {{get; set;}} = null!;");
            code.AppendLine();
        }

        code.EndBlock();

        code.GenerateSourceCode();
    }
}