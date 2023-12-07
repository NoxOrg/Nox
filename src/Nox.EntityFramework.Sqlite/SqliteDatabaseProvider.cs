﻿using Humanizer.Configuration;
using Microsoft.EntityFrameworkCore;
using Nox.Infrastructure;
using Nox.Solution;

using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.Configurations;
using Nox.Types.EntityFramework.Enums;

namespace Nox.EntityFramework.Sqlite;

public class SqliteDatabaseProvider : NoxDatabaseConfigurator, INoxDatabaseProvider
{
    public string ConnectionString { get; protected set; } = string.Empty;
    
    public SqliteDatabaseProvider(
        IEnumerable<INoxTypeDatabaseConfigurator> configurators,
        NoxCodeGenConventions noxSolutionCodeGeneratorState,
        INoxClientAssemblyProvider clientAssemblyProvider
        ) : base(configurators, noxSolutionCodeGeneratorState, clientAssemblyProvider, typeof(ISqliteNoxTypeDatabaseConfigurator))
    {
    }

    public virtual DbContextOptionsBuilder ConfigureDbContext(DbContextOptionsBuilder optionsBuilder, string applicationName, DatabaseServer dbServer)
    {
        return optionsBuilder
            .UseSqlite(dbServer.Options,
                opts => { opts.MigrationsHistoryTable("MigrationsHistory", "migrations"); });
    }

    public string GetSqlStatementForSequenceNextValue(string sequenceName)
    {
        throw new NotSupportedException();
    }
}