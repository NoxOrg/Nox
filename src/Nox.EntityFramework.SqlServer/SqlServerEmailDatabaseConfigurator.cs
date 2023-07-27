using Nox.Types.EntityFramework.Types;
using Nox.Types;

namespace Nox.EntityFramework.SqlServer;

public class SqlServerEmailDatabaseConfigurator : EmailDatabaseConfigurator, ISqlServerNoxTypeDatabaseConfigurator
{
    public override bool IsDefault => false;

    public override string? GetColumnType()
    {
        return "NVARCHAR(255)";
    }
}
