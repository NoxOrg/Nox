﻿using Microsoft.EntityFrameworkCore;
using Nox.Solution;

namespace Nox.Types.EntityFramework.Abstractions;

public interface INoxDatabaseProvider
{
    string ConnectionString { get; }
    DbContextOptionsBuilder ConfigureDbContext(DbContextOptionsBuilder optionsBuilder, string applicationName, DatabaseServer dbServer);
    string ToTableNameForSql(string table, string schema);
    string ToTableNameForSqlRaw(string table, string schema);
}