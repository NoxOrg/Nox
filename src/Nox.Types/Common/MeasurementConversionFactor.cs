using System;
using System.Collections.Generic;

namespace Nox.Common;

internal sealed class MeasurementConversionFactor
{
    private static readonly Dictionary<(MeasurementTypeUnit, MeasurementTypeUnit), double> DefinedConversionFactors = new()
    {
        { (MeasurementTypeUnit.Foot, MeasurementTypeUnit.Meter), 0.30480000033},
        { (MeasurementTypeUnit.Meter, MeasurementTypeUnit.Foot), 3.28083989142},
        { (MeasurementTypeUnit.Kilometer, MeasurementTypeUnit.Mile), 0.62137119102},
        { (MeasurementTypeUnit.Mile, MeasurementTypeUnit.Kilometer), 1.60934400315},
        { (MeasurementTypeUnit.SquareFoot, MeasurementTypeUnit.SquareMeter), 0.09290304},
        { (MeasurementTypeUnit.SquareMeter, MeasurementTypeUnit.SquareFoot), 10.76391042},
    };

    public double Value { get; }

    public MeasurementConversionFactor(MeasurementTypeUnit sourceUnit, MeasurementTypeUnit targetUnit)
    {
        Value = ResolveConversionFactor(sourceUnit, targetUnit);
    }

    private static double ResolveConversionFactor(MeasurementTypeUnit sourceUnit, MeasurementTypeUnit targetUnit)
    {
        var conversion = (sourceUnit, targetUnit);

        if (DefinedConversionFactors.ContainsKey(conversion))
            return DefinedConversionFactors[conversion];

        else if (sourceUnit == targetUnit)
            return 1;

        throw new NotImplementedException($"No conversion defined from {sourceUnit} to {targetUnit}.");
    }
}
