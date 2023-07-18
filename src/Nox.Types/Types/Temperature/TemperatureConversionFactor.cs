using Nox.Types.Common;
using System.Collections.Generic;

namespace Nox.Types;

public class TemperatureConversionFactor : MeasurementConversionFactor<TemperatureUnit>
{
    private static readonly Dictionary<(TemperatureUnit, TemperatureUnit), double> _definedLengthConversionFactors = new()
    {
        { (TemperatureUnit.Celsius,  TemperatureUnit.Fahrenheit), 1.8 },
        { (TemperatureUnit.Fahrenheit,  TemperatureUnit.Celsius), 0.555556 },
    };

    protected override Dictionary<(TemperatureUnit, TemperatureUnit), double> DefinedConversionFactors => _definedLengthConversionFactors;

    public TemperatureConversionFactor(TemperatureUnit sourceUnit, TemperatureUnit targetUnit)
        : base(sourceUnit, targetUnit)
    {
    }
}
