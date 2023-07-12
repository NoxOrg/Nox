using Nox.Types.Common;
using System.Collections.Generic;

namespace Nox.Types;

public class DistanceConversionFactor : MeasurementConversionFactor<DistanceUnit>
{
    private static readonly Dictionary<(DistanceUnit, DistanceUnit), double> _definedDistanceConversionFactors = new()
    {
        { (DistanceUnit.Mile,  DistanceUnit.Kilometer), 1.60934400315 },
        { (DistanceUnit.Kilometer,  DistanceUnit.Mile), 0.62137119102 },
    };

    protected override Dictionary<(DistanceUnit, DistanceUnit), double> DefinedConversionFactors => _definedDistanceConversionFactors;

    public DistanceConversionFactor(DistanceUnit sourceUnit, DistanceUnit targetUnit)
        : base(sourceUnit, targetUnit)
    {
    }
}
