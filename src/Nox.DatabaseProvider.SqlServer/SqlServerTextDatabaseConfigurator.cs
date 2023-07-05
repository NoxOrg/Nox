using Nox.Types;
using Nox.Types.EntityFramework.Configurators;

namespace Nox.DatabaseProvider.SqlServer;

public class SqlServerTextDatabaseConfigurator : TextDatabaseConfigurator
{
    public override string? GetColumnType(TextTypeOptions typeOptions)
    {
        return $"VARCHAR({typeOptions.MaxLength})";
    }
}