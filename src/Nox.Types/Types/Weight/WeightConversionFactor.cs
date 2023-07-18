using Nox.Types.Common;
using System.Collections.Generic;

namespace Nox.Types;

public sealed class WeightConversionFactor : MeasurementConversionFactor<WeightUnit>
{
    private static readonly Dictionary<(WeightUnit, WeightUnit), double> _definedWeightConversionFactors = new()
    {
        { (WeightUnit.Pound,  WeightUnit.Kilogram), 0.45359237 },
        { (WeightUnit.Kilogram,  WeightUnit.Pound), 2.20462262 },
    };

    protected override Dictionary<(WeightUnit, WeightUnit), double> DefinedConversionFactors => _definedWeightConversionFactors;

    public WeightConversionFactor(WeightUnit sourceUnit, WeightUnit targetUnit)
        : base(sourceUnit, targetUnit)
    {
    }
}
