﻿using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;

namespace Nox.Generator.Infrastructure.Persistence.DbContextGenerator;

internal static class DbContextGenerator
{
    public static void Generate(SourceProductionContext context, NoxSolution solution)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (solution.Domain is null)
        {
            return;
        }
        
        var dbContextName = $"{solution.Name}DbContext";

        var code = new CodeBuilder($"{dbContextName}.g.cs",context);

        // Namespace
        AddUsing(code, solution.Name);
        AddClass(code, solution, dbContextName);

        code.GenerateSourceCode();

    }

    private static void AddUsing(CodeBuilder code, string solutionNameSpace)
    {
        code.AppendLine(@"using Microsoft.EntityFrameworkCore;");
        code.AppendLine(@"using Nox.DatabaseProvider;");
        code.AppendLine(@"using Nox.Solution;");
        code.AppendLine(@"using Nox.Types.EntityFramework.vNext;");
        code.AppendLine(@"using SampleWebApp.Domain;");
        code.AppendLine();
        code.AppendLine($"namespace {solutionNameSpace}.Infrastructure.Persistence;");
        code.AppendLine();
    }

    private static void AddClass(CodeBuilder code, NoxSolution solution, string dbContextName)
    {
        code.AppendLine($"public partial class {dbContextName} : DbContext");

        // Class
        code.StartBlock();

        code.AppendLine("private readonly NoxSolution _noxSolution;");
        code.AppendLine("private readonly INoxDatabaseConfigurator _databaseConfigurator;");
        code.AppendLine("private readonly INoxDatabaseProvider _dbProvider;");
        code.AppendLine();

        code.AppendLine($"public {dbContextName}(");
        code.AppendLine($"    DbContextOptions<{dbContextName}> options,");
        code.AppendLine("    NoxSolution noxSolution,");
        code.AppendLine("    INoxDatabaseConfigurator databaseConfigurator,");
        code.AppendLine("    INoxDatabaseProvider databaseProvider");
        code.AppendLine(") : base(options)");
        code.StartBlock();
        code.AppendLine("    _noxSolution = noxSolution;");
        code.AppendLine("    _databaseConfigurator = databaseConfigurator;");
        code.AppendLine("    _dbProvider = databaseProvider;");
        code.EndBlock();
        code.AppendLine();

        AddDbSets(code, solution);

        AddOnConfiguring(code, solution.Name);
        
        AddOnModelCreating(code, solution.Name);

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
        code.AppendLine($"public DbSet<{entity.Name}> {entity.PluralName} {{get; set;}} = null!;");
        code.AppendLine();
    }

    private static void AddOnConfiguring(CodeBuilder code, string solutionName)
    {
        code.AppendLine("protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)");
        code.StartBlock();
        code.AppendLine("base.OnConfiguring(optionsBuilder);");
        code.AppendLine("if (_noxSolution.Infrastructure is { Persistence.DatabaseServer: not null })");
        code.StartBlock();
        code.AppendLine($"_dbProvider.ConfigureDbContext(optionsBuilder, \"{solutionName}\", _noxSolution.Infrastructure!.Persistence.DatabaseServer); ");
        code.EndBlock();
        code.EndBlock();
        code.AppendLine();
    }

    private static void AddOnModelCreating(CodeBuilder code, string solutionName)
    {
        code.AppendLine("protected override void OnModelCreating(ModelBuilder modelBuilder)");
        code.StartBlock();
        code.AppendLine("base.OnModelCreating(modelBuilder);");
        code.AppendLine("if (_noxSolution.Domain != null)");
        code.StartBlock();
        code.AppendLine("foreach (var entity in _noxSolution.Domain.Entities)");
        code.StartBlock();
        code.AppendLine($"var type = Type.GetType(\"{solutionName}.Domain.\" + entity.Name);");
        code.AppendLine();
        code.AppendLine("if (type != null)");
        code.StartBlock();
        code.AppendLine("_databaseConfigurator.ConfigureEntity(modelBuilder.Entity(type), entity);");
        code.EndBlock();
        code.EndBlock();
        code.AppendLine();
        code.EndBlock();
        code.EndBlock();
    }
}

