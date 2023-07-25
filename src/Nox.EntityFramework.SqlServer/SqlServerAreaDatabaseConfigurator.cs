using Nox.Types;
using Nox.Types.EntityFramework.Types;

namespace Nox.EntityFramework.SqlServer;

public class SqlServerAreaDatabaseConfigurator : AreaDatabaseConfigurator, ISqlServerNoxTypeDatabaseConfigurator
{
    public override bool IsDefault => false;

    public override string? GetColumnType(AreaTypeOptions typeOptions)
    {
        var maxNumberOfDigits = Math.Floor(typeOptions.MaxValue).ToString().Length;

        return $"DECIMAL({maxNumberOfDigits},{Area.QuantityValueDecimalPrecision})";
    }
}
