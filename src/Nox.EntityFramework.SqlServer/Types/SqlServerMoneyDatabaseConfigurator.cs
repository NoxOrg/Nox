using Nox.Types;
using Nox.Types.EntityFramework.Types;

namespace Nox.EntityFramework.SqlServer.Types;

public class SqlServerMoneyDatabaseConfigurator : MoneyDatabaseConfigurator, ISqlServerNoxTypeDatabaseConfigurator
{
    public override bool IsDefault => false;

    public override string? GetColumnType(MoneyTypeOptions typeOptions)
    {
        return $"decimal({typeOptions.IntegerDigits + typeOptions.DecimalDigits}, {typeOptions.DecimalDigits})";
    }
}