using System.Globalization;
using Nox.Types;
using Nox.Types.EntityFramework.Types;

namespace Nox.EntityFramework.SqlServer.Types;

public class SqlServerLengthDatabaseConfigurator : LengthDatabaseConfigurator, ISqlServerNoxTypeDatabaseConfigurator
{
    public override bool IsDefault => false;

    public override string? GetColumnType(LengthTypeOptions typeOptions)
    {
        var maxNumberOfIntegerDigits = Math.Truncate(typeOptions.MaxValue).ToString(CultureInfo.InvariantCulture).Length;

        return $"DECIMAL({maxNumberOfIntegerDigits + Length.QuantityValueDecimalPrecision}, {Length.QuantityValueDecimalPrecision})";
    }
}
