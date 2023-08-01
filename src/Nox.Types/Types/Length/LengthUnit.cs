using Nox.Types.Common;

namespace Nox.Types;

internal sealed class LengthUnit : MeasurementUnit
{
    public static readonly LengthUnit Meter = new(1, "Meter", "m");
    public static readonly LengthUnit Foot = new(2, "Foot", "ft");

    private LengthUnit(int id, string name, string symbol) : base(id, name, symbol)
    {
    }
}
