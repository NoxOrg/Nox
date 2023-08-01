using System.Globalization;
using Nox.Types;
using Nox.Types.EntityFramework.Types;

namespace Nox.EntityFramework.SqlServer;

public class SqlServerDistanceDatabaseConfigurator : DistanceDatabaseConfigurator, ISqlServerNoxTypeDatabaseConfigurator
{
    public override bool IsDefault => false;

    public override string? GetColumnType(DistanceTypeOptions typeOptions)
    {
        var maxNumberOfIntegerDigits = Math.Truncate(typeOptions.MaxValue).ToString(CultureInfo.InvariantCulture).Length;

        return $"DECIMAL({maxNumberOfIntegerDigits + Distance.QuantityValueDecimalPrecision}, {Distance.QuantityValueDecimalPrecision})";
    }
}