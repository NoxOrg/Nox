using Nox.Types;
using Nox.Types.Common;
using Nox.Types.EntityFramework.Types;

using System.Globalization;

namespace Nox.EntityFramework.SqlServer;

public class SqlServerVolumeDatabaseConfigurator : VolumeDatabaseConfigurator, ISqlServerNoxTypeDatabaseConfigurator
{
    public override bool IsDefault => false;

    public override string? GetColumnType(VolumeTypeOptions typeOptions)
    {
        var conversion = new VolumeConversion(
            SmartEnumeration.ParseFromName<VolumeUnit>(typeOptions.Unit.ToString()),
            SmartEnumeration.ParseFromName<VolumeUnit>(typeOptions.PersistAs.ToString()));

        var maxPersistedValue = conversion.Calculate(typeOptions.MaxValue).Round(Volume.QuantityValueDecimalPrecision);
        var maxNumberOfIntegerDigits = Math.Truncate((double)maxPersistedValue).ToString(CultureInfo.InvariantCulture).Length;

        return $"DECIMAL({maxNumberOfIntegerDigits + Volume.QuantityValueDecimalPrecision}, {Volume.QuantityValueDecimalPrecision})";
    }
}
