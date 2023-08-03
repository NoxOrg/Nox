using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class VolumeToCubicFeetConverter : ValueConverter<Volume, decimal>
{
    public VolumeToCubicFeetConverter() :
        base(volume => (decimal)volume.ToCubicFeet(), volumeValue => Volume.FromDatabase(volumeValue, VolumeTypeUnit.CubicFoot))
    {
    }
}

public class VolumeToCubicMetersConverter : ValueConverter<Volume, decimal>
{
    public VolumeToCubicMetersConverter() :
        base(volume => (decimal)volume.ToCubicMeters(), volumeValue => Volume.FromDatabase(volumeValue, VolumeTypeUnit.CubicMeter))
    {
    }
}