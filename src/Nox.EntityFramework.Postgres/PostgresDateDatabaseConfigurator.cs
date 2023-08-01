using Nox.Types.EntityFramework.Types;

namespace Nox.EntityFramework.Postgres;

public class PostgresDateDatabaseConfigurator : DateDatabaseConfigurator, IPostgresNoxTypeDatabaseConfigurator
{
    public override bool IsDefault => false;

    public override string? GetColumnType() => "date";
}
