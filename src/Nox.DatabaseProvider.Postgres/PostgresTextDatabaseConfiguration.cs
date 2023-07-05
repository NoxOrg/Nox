using Nox.Types;
using Nox.Types.EntityFramework.Configurators;

namespace Nox.DatabaseProvider.Postgres;

public class PostgresTextDatabaseConfiguration : TextDatabaseConfigurator
{
    public override string? GetColumnType(TextTypeOptions typeOptions)
    {
        return typeOptions.MaxLength == typeOptions.MinLength ? $"CHAR({typeOptions.MaxLength})" : $"VARCHAR({typeOptions.MaxLength})";
    }
}