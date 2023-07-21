using Nox.Types.Common;

namespace Nox.Types;

public class TemperatureUnit : MeasurementUnit
{
    public static TemperatureUnit Celsius { get; } = new TemperatureUnit(1, "Celsius", "C");
    public static TemperatureUnit Fahrenheit { get; } = new TemperatureUnit(2, "Fahrenheit", "F");

    protected TemperatureUnit(int id, string name, string symbol) : base(id, name, symbol)
    {
    }
}
