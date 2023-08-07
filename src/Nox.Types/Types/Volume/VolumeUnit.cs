using Nox.Types.Common;

namespace Nox.Types;

public sealed class VolumeUnit : MeasurementUnit
{
    public static readonly VolumeUnit CubicMeter = new VolumeUnit(1, "CubicMeter", "m³");
    public static readonly VolumeUnit CubicFoot = new VolumeUnit(2, "CubicFoot", "ft³");

    private VolumeUnit(int id, string name, string symbol) : base(id, name, symbol)
    {
    }
}