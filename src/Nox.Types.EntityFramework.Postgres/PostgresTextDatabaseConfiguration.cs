using Nox.Types.EntityFramework.vNext.Types;

namespace Nox.Types.EntityFramework.Postgres;

public class PostgresTextDatabaseConfiguration : TextDatabaseConfigurator
{
    public override string? GetColumnType(TextTypeOptions typeOptions)
    {
        return typeOptions.MaxLength == typeOptions.MinLength ? $"CHAR({typeOptions.MaxLength})" : $"VARCHAR({typeOptions.MaxLength})";
    }
}