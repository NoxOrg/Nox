using Microsoft.CodeAnalysis;
using Nox.Solution;

namespace Nox.Generator;

internal class DbContextGenerator
{
    public static void Generate(SourceProductionContext context, string solutionNameSpace, NoxSolution solution)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (solution.Domain is null)
        {
            return;
        }
        
        var dbContextName = $"{solution.Name}DbContext";

        var code = new CodeBuilder($"Infrastructure/Persistence/{dbContextName}.g.cs",context);

        // Namespace
        code.AppendLine(@"using Microsoft.EntityFrameworkCore;");
        code.AppendLine(@"using SampleService.Domain;");
        code.AppendLine(@"using System.Reflection;");
        code.AppendLine();
        code.AppendLine($"namespace {solutionNameSpace}.Infrastructure.Persistence;");
        code.AppendLine();

        code.AppendLine($"public partial class {dbContextName} : DbContext");

        // Class
        code.StartBlock();
            // Constructor
            code.AppendLine("#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.");
            code.AppendLine($"public {dbContextName}(");

            // Constructor content
            code.Indent();
                code.AppendLine($"DbContextOptions<{dbContextName}> options");
                code.AppendLine($") : base(options) {{ }}");
            code.UnIndent();
            code.AppendLine("#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.");
            code.AppendLine();

            foreach (var entity in solution.Domain.Entities)
            {
                code.AppendLine($"public DbSet<{entity.Name}> {entity.PluralName};");
                code.AppendLine();
            }

            // Method RegisterDbContext
            code.AppendLine($"public static void RegisterDbContext(IServiceCollection services)");

            // Method content
            code.StartBlock();
                code.AppendLine($"services.AddDbContext<{dbContextName}>();");

            // End method
            code.EndBlock();
            code.AppendLine();

            // Method OnModelCreating
            code.AppendLine($"protected override void OnModelCreating(ModelBuilder modelBuilder)");

            // Method content
            code.StartBlock();
                code.AppendLine($"var configurations = Assembly.GetExecutingAssembly();");
                code.AppendLine($"modelBuilder.ApplyConfigurationsFromAssembly(configurations);");
                code.AppendLine();
                code.AppendLine($"base.OnModelCreating(modelBuilder);");

            // End method
            code.EndBlock();

            // End class
        code.EndBlock();
        code.AppendLine();

        code.GenerateSourceCode();

    }
}
