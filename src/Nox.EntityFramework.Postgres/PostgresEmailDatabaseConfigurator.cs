using Nox.Types.EntityFramework.Types;

namespace Nox.EntityFramework.Postgres;

internal class PostgresEmailDatabaseConfigurator : EmailDatabaseConfigurator
{
    public override bool IsDefault => false;

    public override string? GetColumnType()
    {
        return "VARCHAR(255)";
    }
}