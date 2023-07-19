using Nox.Types.Common;

namespace Nox.Types;

public sealed class AreaUnit : MeasurementUnit
{
    public static AreaUnit SquareMeter { get; } = new AreaUnit(1, "SquareMeter", "m²");
    public static AreaUnit SquareFoot { get; } = new AreaUnit(2, "SquareFoot", "ft²");

    private AreaUnit(int id, string name, string symbol) : base(id, name, symbol)
    {
    }
}
