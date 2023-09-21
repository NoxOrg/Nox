﻿using Microsoft.EntityFrameworkCore;
using Nox.EntityFramework.Postgres;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;

namespace ClientApi.Tests;

public class PostgreSqlTestProvider : PostgresDatabaseProvider
{
    public PostgreSqlTestProvider(string connectionString, IEnumerable<INoxTypeDatabaseConfigurator> configurators) : base(configurators)
    {
        ConnectionString = connectionString;
    }

    public override DbContextOptionsBuilder ConfigureDbContext(DbContextOptionsBuilder optionsBuilder, string applicationName, DatabaseServer dbServer)
    {
        return optionsBuilder.UseNpgsql(ConnectionString, opts =>
        {
            opts.MigrationsHistoryTable("MigrationsHistory", "migrations");
        });
    }
}