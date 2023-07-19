using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;

using static Nox.Generator.Common.BaseGenerator;

namespace Nox.Generator.Infrastructure.Persistence.DbContextGenerator;

internal static class DbContextGenerator
{
    public static void Generate(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGeneratorState.Solution.Domain is null)
        {
            return;
        }
        
        var dbContextName = $"{codeGeneratorState.Solution.Name}DbContext";

        var code = new CodeBuilder($"{dbContextName}.g.cs",context);

        AddUsing(code, codeGeneratorState);
        AddClass(code, codeGeneratorState, dbContextName);

        code.GenerateSourceCode();

    }

    private static void AddUsing(CodeBuilder code, NoxSolutionCodeGeneratorState codeGeneratorState)
    {
        code.AppendLine(@"using Microsoft.EntityFrameworkCore;");
        code.AppendLine(@"using Nox.Solution;");
        code.AppendLine(@"using Nox.Generator.Common;");
        code.AppendLine(@"using Nox.Types.EntityFramework.Abstractions;");
        code.AppendLine(@$"using {codeGeneratorState.DomainNameSpace};");
        code.AppendLine();
        code.AppendLine($"namespace {codeGeneratorState.PersistenceNameSpace};");
        code.AppendLine();
    }

    private static void AddClass(CodeBuilder code, NoxSolutionCodeGeneratorState codeGeneratorState, string dbContextName)
    {
        code.AppendLine($"public partial class {dbContextName} : DbContext");

        // Class
        code.StartBlock();

        code.AppendLine("private readonly NoxSolution _noxSolution;");
        code.AppendLine("private readonly INoxDatabaseProvider _dbProvider;");
        code.AppendLine();

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

        AddDbSets(code, codeGeneratorState.Solution);

        AddDbContextOnConfiguring(code, codeGeneratorState);
        
        AddOnModelCreating(code);

        // End class
        code.EndBlock();
        code.AppendLine();
    }

    private static void AddDbSets(CodeBuilder code, NoxSolution solution)
    {
        foreach (var entity in solution.Domain!.Entities)
        {
            AddDbSet(code, entity);
        }
    }

    private static void AddDbSet(CodeBuilder code, Entity entity)
    {
        code.AppendLine($"public DbSet<{entity.Name}> {entity.PluralName} {{ get; set; }} = null!;");
        code.AppendLine();
    }

    private static void AddOnModelCreating(CodeBuilder code)
    {
        code.AppendLine("protected override void OnModelCreating(ModelBuilder modelBuilder)");
        code.StartBlock();
            code.AppendLine("base.OnModelCreating(modelBuilder);");
            code.AppendLine("if (_noxSolution.Domain != null)");
            code.StartBlock();
                code.AppendLine("var codeGeneratorState = new NoxSolutionCodeGeneratorState(_noxSolution);");
                code.AppendLine("foreach (var entity in _noxSolution.Domain.Entities)");
                code.StartBlock();
                    code.AppendLine($"var type = codeGeneratorState.GetEntityType(entity.Name);");
                    code.AppendLine("if (type != null)");
                    code.StartBlock();
                        code.AppendLine("((INoxDatabaseConfigurator)_dbProvider).ConfigureEntity(codeGeneratorState, modelBuilder.Entity(type), entity, _noxSolution.GetRelationshipsToCreate(codeGeneratorState.GetEntityType));");
                    code.EndBlock();
                code.EndBlock();
            code.EndBlock();
        code.EndBlock();
    }
}

