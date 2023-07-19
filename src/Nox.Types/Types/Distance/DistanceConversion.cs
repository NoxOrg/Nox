using Nox.Types.Common;
using System;
using System.Collections.Generic;

namespace Nox.Types;

public class DistanceConversion : MeasurementConversion<DistanceUnit>
{
    private static readonly Dictionary<(DistanceUnit, DistanceUnit), Func<QuantityValue, QuantityValue>> _definedDistanceConversionFormulas = new()
    {
        { (DistanceUnit.Mile,  DistanceUnit.Kilometer), (val) => val * 1.60934400315 },
        { (DistanceUnit.Kilometer,  DistanceUnit.Mile), (val) => val * 0.62137119102 },
    };

    protected override Dictionary<(DistanceUnit, DistanceUnit), Func<QuantityValue, QuantityValue>> DefinedConversionFormulas => _definedDistanceConversionFormulas;

    public DistanceConversion(DistanceUnit sourceUnit, DistanceUnit targetUnit)
        : base(sourceUnit, targetUnit)
    {
    }
}
