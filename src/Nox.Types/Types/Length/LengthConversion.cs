using Nox.Types.Common;
using System;
using System.Collections.Generic;

namespace Nox.Types;

public class LengthConversion : MeasurementConversion<LengthUnit>
{
    private static readonly Dictionary<(LengthUnit, LengthUnit), Func<QuantityValue, QuantityValue>> _definedLengthConversionFormulas = new()
    {
        { (LengthUnit.Foot,  LengthUnit.Meter), (val) => val * 0.30480000033 },
        { (LengthUnit.Meter,  LengthUnit.Foot), (val) => val * 3.28083989142 },
    };

    protected override Dictionary<(LengthUnit, LengthUnit), Func<QuantityValue, QuantityValue>> DefinedConversionFormulas => _definedLengthConversionFormulas;

    public LengthConversion(LengthUnit sourceUnit, LengthUnit targetUnit)
        : base(sourceUnit, targetUnit)
    {
    }
}