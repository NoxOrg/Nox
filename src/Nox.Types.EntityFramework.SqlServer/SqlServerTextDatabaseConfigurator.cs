using Nox.Types.EntityFramework.vNext.Types;

namespace Nox.Types.EntityFramework.SqlServer;

public class SqlServerTextDatabaseConfigurator : TextDatabaseConfigurator
{
    public override string? GetColumnType(TextTypeOptions typeOptions)
    {
        return $"VARCHAR({typeOptions.MaxLength})";
    }
}