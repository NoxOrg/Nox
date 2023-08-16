using System.Linq;
using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using static Nox.Generator.Common.BaseGenerator;

namespace Nox.Generator.Presentation.Api.OData;

internal class ODataDbContextGenerator : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Presentation;

    public void Generate(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState, GeneratorConfig config)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        NoxSolution solution = codeGeneratorState.Solution;

        if (solution.Domain is null ||
            !solution.Domain.Entities.Any())
        {
            return;
        }

        var code = new CodeBuilder($"ODataDbContext.g.cs", context);

        // Namespace
        code.AppendLine(@"using Microsoft.EntityFrameworkCore;");
        code.AppendLine(@"using Nox;");
        code.AppendLine(@"using Nox.Abstractions;");
        code.AppendLine(@"using Nox.Solution;");
        code.AppendLine(@"using Nox.Types.EntityFramework.Abstractions;");
        code.AppendLine(@"using Nox.Types.EntityFramework.Enums;");
        code.AppendLine(@$"using {codeGeneratorState.ApplicationNameSpace}.Dto;");

        code.AppendLine();
        code.AppendLine($"namespace {codeGeneratorState.ODataNameSpace};");
        code.AppendLine();

        string dbContextName = "ODataDbContext";

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
        code.AppendLine($"public {dbContextName}(");
        code.Indent();
        code.AppendLine($"DbContextOptions<{dbContextName}> options,");
        code.AppendLine("NoxSolution noxSolution,");
        code.AppendLine("IEnumerable<INoxDatabaseProvider> databaseProviders,");
        code.AppendLine("INoxClientAssemblyProvider clientAssemblyProvider");
        code.UnIndent();
        code.AppendLine(") : base(options)");
        code.StartBlock();
        code.AppendLine("_noxSolution = noxSolution;");
        code.AppendLine("_dbProvider = databaseProviders.Single(p => p.StoreType == NoxDataStoreType.EntityStore);");
        code.AppendLine("_clientAssemblyProvider = clientAssemblyProvider;");
        code.EndBlock();
        code.AppendLine();

        foreach (var entity in solution.Domain.Entities)
        {
            code.AppendLine($"public DbSet<{entity.Name}Dto> {entity.PluralName} {{ get; set; }} = null!;");
            code.AppendLine();
        }

        AddDbContextOnConfiguring(code, codeGeneratorState);

        AddOnModelCreating(solution, code);

        code.EndBlock();

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
            code.StartBlock();
            code.AppendLine($"var type = typeof({entity.Name}Dto);");
            code.AppendLine($"var builder = modelBuilder.Entity(type!);");
            code.AppendLine();
            foreach (var key in entity.Keys!)
            {
                {
                    code.AppendLine($"builder.HasKey(\"{key.Name}\");");

                }
            }
            code.EndBlock();
        }
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