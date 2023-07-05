namespace Nox.Types;

public class VolumeUnit : MeasurementUnit
{
    public static VolumeUnit CubicMeter { get; } = new VolumeUnit(1, "CubicMeter", "m³");
    public static VolumeUnit CubicFoot { get; } = new VolumeUnit(2, "CubicFoot", "ft³");

    private VolumeUnit(int id, string name, string symbol) : base(id, name, symbol)
    {
    }
}


public class LengthUnit : MeasurementUnit
{
    public static LengthUnit Meter { get; } = new LengthUnit(1, "Meter", "m");
    public static LengthUnit Foot { get; } = new LengthUnit(2, "Foot", "ft");

    protected LengthUnit(int id, string name, string symbol) : base(id, name, symbol)
    {
    }
}

public class DistanceUnit : LengthUnit
{
    protected DistanceUnit(int id, string name, string symbol) : base(id, name, symbol)
    {
    }
}    