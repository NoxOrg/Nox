using System.Linq;
using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using static Nox.Generator.Common.BaseGenerator;

namespace Nox.Generator.Infrastructure.Persistence.DbContextGenerator;

internal class DtoDbContextGenerator : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Infrastructure;

    public void Generate(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState, GeneratorConfig config)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        NoxSolution solution = codeGeneratorState.Solution;

        if (solution.Domain is null ||
            !solution.Domain.Entities.Any())
        {
            return;
        }

        var code = new CodeBuilder($"DtoDbContext.g.cs", context);

        // Namespace
        code.AppendLine(@"using Microsoft.EntityFrameworkCore;");
        code.AppendLine(@"using Nox;");
        code.AppendLine(@"using Nox.Solution;");
        code.AppendLine(@"using Nox.Types.EntityFramework.Abstractions;");
        code.AppendLine(@$"using {codeGeneratorState.ApplicationNameSpace}.Dto;");

        code.AppendLine();
        code.AppendLine($"namespace {codeGeneratorState.PersistenceNameSpace};");
        code.AppendLine();

        string dbContextName = "DtoDbContext";

        // Db Context
        code.AppendLine($"public class {dbContextName} : DbContext");

        // Class
        code.StartBlock();
        code.AppendLine();

        AddField(code, "NoxSolution", "noxSolution", "The Nox solution configuration");
        AddField(code, "INoxDatabaseProvider", "dbProvider", "The database provider");
        AddField(code, "INoxClientAssemblyProvider", "clientAssemblyProvider", "");

        // Constructor content

        // Add constructor
        code.Indent();
        code.AppendLine($"public {dbContextName}(");
        code.AppendLine($"    DbContextOptions<{dbContextName}> options,");
        code.AppendLine("    NoxSolution noxSolution,");
        code.AppendLine("    INoxDatabaseProvider databaseProvider,");
        code.AppendLine("    INoxClientAssemblyProvider clientAssemblyProvider");
        code.AppendLine(") : base(options)");
        code.StartBlock();
        code.AppendLine("_noxSolution = noxSolution;");
        code.AppendLine("_dbProvider = databaseProvider;");
        code.AppendLine("_clientAssemblyProvider = clientAssemblyProvider;");
        code.EndBlock();
        code.AppendLine();

        foreach (var entity in solution.Domain.Entities)
        {
            if (!entity.IsOwnedEntity)
            {
                code.AppendLine($"public DbSet<{entity.Name}Dto> {entity.PluralName} {{ get; set; }} = null!;");
                code.AppendLine();
            }
        }

        AddDbContextOnConfiguring(code, codeGeneratorState);

        AddOnModelCreating(solution, code);

        code.EndBlock();

        code.GenerateSourceCode();
    }

    private static void AddOnModelCreating(NoxSolution solution, CodeBuilder code)
    {
        code.AppendLine(@$" protected override void OnModelCreating(ModelBuilder modelBuilder)");
        code.StartBlock();
        code.AppendLine(@$"base.OnModelCreating(modelBuilder);");

        foreach (var entity in solution.Domain!.Entities)
        {
            if (entity.IsOwnedEntity)
            {
                continue;
            }

            code.StartBlock();
            code.AppendLine($"var type = typeof({entity.Name}Dto);");
            code.AppendLine($"var builder = modelBuilder.Entity(type!);");
            code.AppendLine();

            foreach (var key in entity.Keys!)
            {
                code.AppendLine($"builder.HasKey(\"{key.Name}\");");
            }

            var keyNames = entity.Keys.Select(x => x.Name);
            var databaseTypeKeysConfiguration = entity.Keys
                .Where(x =>
                    x.Type == Types.NoxType.DatabaseGuid ||
                    x.Type == Types.NoxType.DatabaseNumber)
                .Select(x => $"owned.Property(\"{x.Name}\").ValueGeneratedOnAdd();");
            if (entity.OwnedRelationships != null)
            {
#pragma warning disable S3267 // Loops should be simplified with "LINQ" expressions
                foreach (var ownedRelationship in entity.OwnedRelationships)
#pragma warning restore S3267 // Loops should be simplified with "LINQ" expressions
                {
                    code.AppendLine(@$"builder.OwnsMany(typeof({ownedRelationship.Related.Entity.Name}Dto), ""{ownedRelationship.Related.Entity.PluralName}"", owned =>
                    {{
                         
                        owned.WithOwner().HasForeignKey(""{entity.Name}Id"");
                        owned.HasKey(""{string.Join(@""",""", keyNames)}"");
                        owned.ToTable(""{ownedRelationship.Related.Entity.Name}"");");

                    code.Indent();
                    code.Indent();
                    foreach (var databaseTypeConfiguration in databaseTypeKeysConfiguration)
                    {
                        code.AppendLine(databaseTypeConfiguration);
                    }
                    code.UnIndent();
                    code.AppendLine(@$"}}");
                    code.UnIndent();
                    code.AppendLine(@$");");
                }
            }

            code.EndBlock();
        }

        code.EndBlock();
    }

    internal static void AddDbContextOnConfiguring(CodeBuilder code, NoxSolutionCodeGeneratorState codeGeneratorState)
    {
        code.AppendLine("protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)");
        code.StartBlock();
        code.AppendLine("base.OnConfiguring(optionsBuilder);");
        code.AppendLine("if (_noxSolution.Infrastructure is { Persistence.DatabaseServer: not null })");
        code.StartBlock();
        code.AppendLine($"_dbProvider.ConfigureDbContext(optionsBuilder, \"{codeGeneratorState.Solution.Name}\", _noxSolution.Infrastructure!.Persistence.DatabaseServer); ");
        code.EndBlock();
        code.EndBlock();
        code.AppendLine();
    }


}
