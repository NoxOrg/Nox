using Nox.Types.Common;
using System;
using System.Collections.Generic;

namespace Nox.Types;

public sealed class WeightConversion : MeasurementConversion<WeightUnit>
{
    private static readonly Dictionary<(WeightUnit, WeightUnit), Func<QuantityValue, QuantityValue>> _definedWeightConversionFormulas = new()
    {
        { (WeightUnit.Pound,  WeightUnit.Kilogram), (val) => val * 0.45359237m },
        { (WeightUnit.Kilogram,  WeightUnit.Pound), (val) => val / 0.45359237m },
    };

    protected override Dictionary<(WeightUnit, WeightUnit), Func<QuantityValue, QuantityValue>> DefinedConversionFormulas => _definedWeightConversionFormulas;

    public WeightConversion(WeightUnit sourceUnit, WeightUnit targetUnit)
        : base(sourceUnit, targetUnit)
    {
    }
}
