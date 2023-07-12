using Nox.Common;

namespace Nox.Types;

public class LengthUnit : MeasurementUnit
{
    public static LengthUnit Meter { get; } = new LengthUnit(1, "Meter", "m");
    public static LengthUnit Foot { get; } = new LengthUnit(2, "Foot", "ft");

    protected LengthUnit(int id, string name, string symbol) : base(id, name, symbol)
    {
    }
}
