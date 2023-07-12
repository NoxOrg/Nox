using Nox.Common;

namespace Nox.Types;

public class VolumeUnit : MeasurementUnit
{
    public static VolumeUnit CubicMeter { get; } = new VolumeUnit(1, "CubicMeter", "m³");
    public static VolumeUnit CubicFoot { get; } = new VolumeUnit(2, "CubicFoot", "ft³");

    private VolumeUnit(int id, string name, string symbol) : base(id, name, symbol)
    {
    }
}