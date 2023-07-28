using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class TemperatureToCelsiusConverter : ValueConverter<Temperature, double>
{
    public TemperatureToCelsiusConverter() : base(temperature => (double)temperature.ToCelsius(), temperatureValue => Temperature.FromCelsius(temperatureValue)) { }
}
public class TemperatureToFahrenheitConverter : ValueConverter<Temperature, double>
{
    public TemperatureToFahrenheitConverter() : base(temperature => (double)temperature.ToFahrenheit(), temperatureValue => Temperature.FromFahrenheit(temperatureValue)) { }
}