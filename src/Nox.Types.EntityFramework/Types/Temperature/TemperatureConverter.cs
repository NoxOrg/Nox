using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class TemperatureToCelsiusConverter : ValueConverter<Temperature, decimal>
{
    public TemperatureToCelsiusConverter() : base(temperature => (decimal)temperature.ToCelsius(), temperatureValue => Temperature.FromDatabase(temperatureValue, TemperatureTypeUnit.Celsius)) { }
}
public class TemperatureToFahrenheitConverter : ValueConverter<Temperature, decimal>
{
    public TemperatureToFahrenheitConverter() : base(temperature => (decimal)temperature.ToFahrenheit(), temperatureValue => Temperature.FromDatabase(temperatureValue, TemperatureTypeUnit.Fahrenheit)) { }
}