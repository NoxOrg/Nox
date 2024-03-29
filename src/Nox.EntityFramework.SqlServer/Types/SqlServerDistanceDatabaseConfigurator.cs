﻿using System.Globalization;
using Nox.Types;
using Nox.Types.Common;
using Nox.Types.EntityFramework.Types;

namespace Nox.EntityFramework.SqlServer.Types;

public class SqlServerDistanceDatabaseConfigurator : DistanceDatabaseConfigurator, ISqlServerNoxTypeDatabaseConfigurator
{
    public override bool IsDefault => false;

    public override string? GetColumnType(DistanceTypeOptions typeOptions)
    {
        var conversion = new DistanceConversion(
            SmartEnumeration.ParseFromName<DistanceUnit>(typeOptions.Units.ToString()),
            SmartEnumeration.ParseFromName<DistanceUnit>(typeOptions.PersistAs.ToString()));

        var maxPersistedValue = conversion.Calculate(typeOptions.MaxValue).Round(Distance.QuantityValueDecimalPrecision);
        var maxNumberOfIntegerDigits = Math.Truncate((decimal)maxPersistedValue).ToString(CultureInfo.InvariantCulture).Length;

        return $"DECIMAL({maxNumberOfIntegerDigits + Distance.QuantityValueDecimalPrecision}, {Distance.QuantityValueDecimalPrecision})";
    }
}