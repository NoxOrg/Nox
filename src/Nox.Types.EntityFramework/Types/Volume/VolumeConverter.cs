using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class VolumeToCubicFootConverter : ValueConverter<Volume, double>
{
    public VolumeToCubicFootConverter() : base(volume => (double)volume.ToCubicFeet(), volumeValue => Volume.FromCubicFeet(volumeValue)) { }
}
public class VolumeToCubicMeterConverter : ValueConverter<Volume, double>
{
    public VolumeToCubicMeterConverter() : base(volume => (double)volume.ToCubicMeters(), volumeValue => Volume.FromCubicMeters(volumeValue)) { }
}
