using Nox.Types.Common;

namespace Nox.Types;

public sealed class TemperatureUnit : MeasurementUnit
{
    public static readonly TemperatureUnit Celsius = new (1, "Celsius", "C");
    public static readonly TemperatureUnit Fahrenheit  = new (2, "Fahrenheit", "F");

    private TemperatureUnit(int id, string name, string symbol) : base(id, name, symbol)
    {
    }
}
