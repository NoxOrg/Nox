﻿using Microsoft.EntityFrameworkCore;
using Nox.Solution;
using Nox.Types.EntityFramework.Enums;

namespace Nox.Types.EntityFramework.Abstractions;

public interface INoxDatabaseProvider
{
    string ConnectionString { get; }
    DbContextOptionsBuilder ConfigureDbContext(DbContextOptionsBuilder optionsBuilder, string applicationName, DatabaseServer dbServer);

    /// <summary>
    /// Raw SQL to Select Sequence Next Value
    /// </summary>
    string GetSqlStatementForSequenceNextValue(string sequenceName);
}