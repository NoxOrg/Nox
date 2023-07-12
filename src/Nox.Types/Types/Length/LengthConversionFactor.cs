using Nox.Common;
using System.Collections.Generic;

namespace Nox.Types;

public class LengthConversionFactor : MeasurementConversionFactor<LengthUnit>
{
    private static readonly Dictionary<(LengthUnit, LengthUnit), double> _definedLengthConversionFactors = new()
    {
        { (LengthUnit.Foot,  LengthUnit.Meter), 0.30480000033 },
        { (LengthUnit.Meter,  LengthUnit.Foot), 3.28083989142 },
    };

    protected override Dictionary<(LengthUnit, LengthUnit), double> DefinedConversionFactors => _definedLengthConversionFactors;

    public LengthConversionFactor(LengthUnit sourceUnit, LengthUnit targetUnit)
        : base(sourceUnit, targetUnit)
    {
    }
}
