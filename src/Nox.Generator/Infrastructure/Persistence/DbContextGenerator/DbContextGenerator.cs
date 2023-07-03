using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
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

        var code = new CodeBuilder($"{dbContextName}.g.cs",context);

        // Namespace
        code.AppendLine(@"using Microsoft.EntityFrameworkCore;");
        code.AppendLine(@"using Nox.Solution;");
        code.AppendLine(@"using Nox.Types.EntityFramework.vNext;");
        code.AppendLine(@"using SampleWebApp.Domain;");
        code.AppendLine();
        code.AppendLine($"namespace {solutionNameSpace}.Infrastructure.Persistence;");
        code.AppendLine();

        code.AppendLine($"public partial class {dbContextName} : DbContext");

        // Class
        code.StartBlock();

            code.AppendLine($"private NoxSolution _noxSolution {{ get; set; }}");
            code.AppendLine($"private INoxDatabaseConfigurator _databaseConfigurator {{ get; set; }}");
            code.AppendLine();
            
            // Constructor
            code.AppendLine("#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.");
            code.AppendLine($"public {dbContextName}(");

            // Constructor content
            code.Indent();
                code.AppendLine($"DbContextOptions<{dbContextName}> options,");
                code.AppendLine($"NoxSolution noxSolution,");
                code.AppendLine($"INoxDatabaseConfigurator databaseConfigurator");
                code.AppendLine($") : base(options)");
            code.UnIndent();
            code.AppendLine("#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.");
            code.AppendLine($"{{");
            code.Indent();
                code.AppendLine($"_noxSolution = noxSolution;");
                code.AppendLine($"_databaseConfigurator = databaseConfigurator;");
            code.UnIndent();
            code.AppendLine($"}}");
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
                code.AppendLine($"foreach (var entity in _noxSolution.Domain.Entities)");
                code.StartBlock();
                    code.AppendLine($"_databaseConfigurator.ConfigureEntity(modelBuilder.Entity(Type.GetType(\"SampleWebApp.Domain.\" + entity.Name)), entity);");
                code.EndBlock();
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
