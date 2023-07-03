using Nox.Types.EntityFramework.vNext.TypesConfiguration;

namespace Nox.Types.EntityFramework.Postgres;

public class PostgresTextDatabaseConfiguration : TextDatabaseConfiguration
{
    public override string? GetColumnType(TextTypeOptions typeOptions)
    {
        return typeOptions.MaxLength == typeOptions.MinLength ? $"CHAR({typeOptions.MaxLength})" : $"VARCHAR({typeOptions.MaxLength})";
    }
}