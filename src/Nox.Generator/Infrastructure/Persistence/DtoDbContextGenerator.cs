using System.Linq;
using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using static Nox.Generator.Common.BaseGenerator;

namespace Nox.Generator.Infrastructure.Persistence;

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

        var code = new CodeBuilder($"Infrastructure.Persistence.DtoDbContext.g.cs", context);

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
        AddField(code, "INoxDtoDatabaseConfigurator", "noxDtoDatabaseConfigurator", "");


        // Constructor content

        // Add constructor
        code.Indent();
        code.AppendLine($"public {dbContextName}(");
        code.AppendLine($"    DbContextOptions<{dbContextName}> options,");
        code.AppendLine("    NoxSolution noxSolution,");
        code.AppendLine("    INoxDatabaseProvider databaseProvider,");
        code.AppendLine("    INoxClientAssemblyProvider clientAssemblyProvider,");
        code.AppendLine("    INoxDtoDatabaseConfigurator noxDtoDatabaseConfigurator");
        code.AppendLine(") : base(options)");
        code.StartBlock();
        code.AppendLine("_noxSolution = noxSolution;");
        code.AppendLine("_dbProvider = databaseProvider;");
        code.AppendLine("_clientAssemblyProvider = clientAssemblyProvider;");
        code.AppendLine("_noxDtoDatabaseConfigurator = noxDtoDatabaseConfigurator;");
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
        code.AppendLine(@$"
            if (_noxSolution.Domain != null)
            {{
                var codeGeneratorState = new NoxSolutionCodeGeneratorState(_noxSolution, _clientAssemblyProvider.ClientAssembly);
                foreach (var entity in codeGeneratorState.Solution.Domain!.Entities)
                {{
                    // Ignore owned entities configuration as they are configured inside entity constructor
                    if (entity.IsOwnedEntity)
                    {{
                        continue;
                    }}

                    var type = codeGeneratorState.GetEntityDtoType(entity.Name + ""Dto"");
                    if (type != null)
                    {{
                       _noxDtoDatabaseConfigurator.ConfigureDto(codeGeneratorState, new Nox.Types.EntityFramework.EntityBuilderAdapter.EntityBuilderAdapter(modelBuilder.Entity(type)), entity);
                    }}
                    else
                    {{
                        throw new Exception($""Could not resolve type for {{entity.Name}}Dto"");
                    }}
                }}
            }}            
        ");
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
