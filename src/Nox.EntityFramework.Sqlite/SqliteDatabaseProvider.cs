using Microsoft.EntityFrameworkCore;
using Nox.Solution;
using Nox.Types;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.Types;

namespace Nox.EntityFramework.Sqlite;

public sealed class SqliteDatabaseProvider : NoxDatabaseConfigurator, INoxDatabaseProvider
{
    private static readonly Dictionary<NoxType, INoxTypeDatabaseConfigurator> TypesConfiguration = new()
    {
        // Use default implementation for all types
        { NoxType.Text, new TextDatabaseConfigurator() },
        { NoxType.Number, new NumberDatabaseConfigurator() },
        { NoxType.Money, new MoneyDatabaseConfigurator() },
        { NoxType.CountryCode2, new CountryCode2Configurator() }
    };

    public SqliteDatabaseProvider() : base(TypesConfiguration)
    {
    }

    public string ConnectionString { get; set; } = string.Empty;
    public DbContextOptionsBuilder ConfigureDbContext(DbContextOptionsBuilder optionsBuilder, string applicationName, DatabaseServer dbServer)
    {
        throw new NotImplementedException();
    }

    public string ToTableNameForSql(string table, string schema)
    {
        throw new NotImplementedException();
    }

    public string ToTableNameForSqlRaw(string table, string schema)
    {
        throw new NotImplementedException();
    }
}