using Nox.TypeOptions;
using Nox.Types;
using Nox.Types.Common;
using Nox.Types.EntityFramework.Types;

using System.Globalization;

namespace Nox.EntityFramework.SqlServer;

public class SqlServerWeightDatabaseConfigurator : WeightDatabaseConfigurator
{
    public override bool IsDefault => false;

    public override string? GetColumnType(WeightTypeOptions typeOptions)
    {
        var conversion = new WeightConversion(
            Enumeration.ParseFromName<WeightUnit>(typeOptions.Units.ToString()),
            Enumeration.ParseFromName<WeightUnit>(typeOptions.PersistAs.ToString()));

        var maxPersistedValue = conversion.Calculate(typeOptions.MaxValue).Round(Weight.QuantityValueDecimalPrecision);
        var maxNumberOfIntegerDigits = Math.Truncate((decimal)maxPersistedValue).ToString(CultureInfo.InvariantCulture).Length;

        return $"DECIMAL({maxNumberOfIntegerDigits + Weight.QuantityValueDecimalPrecision}, {Weight.QuantityValueDecimalPrecision})";
    }
}
