using Nox.Types;
using Nox.Types.EntityFramework.Configurators;

namespace Nox.EntityFramework.SqlServer;

public class SqlServerTextDatabaseConfigurator : TextDatabaseConfigurator
{
    public override string? GetColumnType(TextTypeOptions typeOptions)
    {
        return $"VARCHAR({typeOptions.MaxLength})";
    }
}