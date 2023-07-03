using Nox.Types.EntityFramework.vNext.TypesConfiguration;

namespace Nox.Types.EntityFramework.SqlServer;

public class SqlServerTextDatabaseConfiguration : TextDatabaseConfiguration
{
    public override string? GetColumnType(TextTypeOptions typeOptions)
    {
        return $"VARCHAR({typeOptions.MaxLength})";
    }
}