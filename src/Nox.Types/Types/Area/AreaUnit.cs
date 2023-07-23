using Nox.Types.Common;

namespace Nox.Types;

public sealed class AreaUnit : MeasurementUnit
{
    public static readonly AreaUnit SquareMeter = new(1, "SquareMeter", "m²");
    public static readonly AreaUnit SquareFoot = new(2, "SquareFoot", "ft²");

    private AreaUnit(int id, string name, string symbol) : base(id, name, symbol)
    {
    }
}
