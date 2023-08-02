using Nox.Types.Common;
using System;
using System.Collections.Generic;

namespace Nox.Types;

internal class DistanceConversion : MeasurementConversion<DistanceUnit>
{
    private static readonly Dictionary<(DistanceUnit, DistanceUnit), Func<QuantityValue, QuantityValue>> _definedDistanceConversionFormulas = new()
    {
        { (DistanceUnit.Mile,  DistanceUnit.Kilometer), (val) => val * 1.60934400315m },
        { (DistanceUnit.Kilometer,  DistanceUnit.Mile), (val) => val / 1.60934400315m },
    };

    protected override Dictionary<(DistanceUnit, DistanceUnit), Func<QuantityValue, QuantityValue>> DefinedConversionFormulas => _definedDistanceConversionFormulas;

    public DistanceConversion(DistanceUnit sourceUnit, DistanceUnit targetUnit)
        : base(sourceUnit, targetUnit)
    {
    }
}
