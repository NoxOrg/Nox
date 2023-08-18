using Nox.Types;
using Nox.Types.EntityFramework.Types;

namespace Nox.EntityFramework.Postgres;

public class PostgresDatabaseGuidDatabaseConfiguration : DatabaseGuidDatabaseConfigurator
{
    public override bool IsDefault => false;

    /// <summary>
    /// Method to generate Uuid value for Postgresql.
    /// https://www.npgsql.org/efcore/modeling/generated-properties.html#guiduuid-generation
    /// </summary>
    /// <returns></returns>
    protected override string? DefaultValue()
    {
        return "gen_random_uuid()";
    }
}