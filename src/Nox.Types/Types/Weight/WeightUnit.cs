using Nox.Types.Common;

namespace Nox.Types;

public sealed class WeightUnit : MeasurementUnit
{
    public static readonly WeightUnit Kilogram = new(1, "Kilogram", "kg");
    public static readonly WeightUnit Pound = new(2, "Pound", "lb");

    private WeightUnit(int id, string name, string symbol) : base(id, name, symbol)
    {
    }
}
