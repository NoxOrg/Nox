using System.Globalization;
using Nox.Types;
using Nox.Types.EntityFramework.Types;

namespace Nox.EntityFramework.SqlServer.Types;

public class SqlServerAreaDatabaseConfigurator : AreaDatabaseConfigurator, ISqlServerNoxTypeDatabaseConfigurator
{
    public override bool IsDefault => false;

    public override string? GetColumnType(AreaTypeOptions typeOptions)
    {
        var maxNumberOfIntegerDigits = Math.Truncate(typeOptions.MaxValue).ToString(CultureInfo.InvariantCulture).Length;

        return $"DECIMAL({maxNumberOfIntegerDigits + Area.QuantityValueDecimalPrecision}, {Area.QuantityValueDecimalPrecision})";
    }
}
