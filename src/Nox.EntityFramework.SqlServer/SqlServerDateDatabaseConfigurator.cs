using Nox.Types.EntityFramework.Types;

namespace Nox.EntityFramework.SqlServer;

public class SqlServerDateDatabaseConfigurator : DateDatabaseConfigurator, ISqlServerNoxTypeDatabaseConfigurator
{
    public override bool IsDefault => false;

    public override string? GetColumnType() => "date";
}
