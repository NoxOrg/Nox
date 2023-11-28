using Nox.Types;
using Nox.Types.EntityFramework.Types;

namespace Nox.EntityFramework.Postgres.Types;

public class PostgresMarkdownDatabaseConfiguration : MarkdownDatabaseConfigurator, IPostgresNoxTypeDatabaseConfigurator
{
    public override bool IsDefault => false;

    public override string? GetColumnType(MarkdownTypeOptions typeOptions)
    {
        return typeOptions.MaxLength == typeOptions.MinLength ? $"CHAR({typeOptions.MaxLength})" : $"VARCHAR({typeOptions.MaxLength})";
    }
}