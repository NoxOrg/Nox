using System.Collections.Generic;

namespace Nox.Generator.Infrastructure.Persistence.DatabaseConfiguration;

internal static class DatabaseAttributeConfigurationInstances
{
    public static readonly Dictionary<string, IDatabaseAttributeConfiguration> Map =
        new()
        {
            { "sqLite", new SqLiteDatabaseAttributeConfiguration() },
            { "mySql", new MySqlDatabaseAttributeConfiguration() }
        };
}