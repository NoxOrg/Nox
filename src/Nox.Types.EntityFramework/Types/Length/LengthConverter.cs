using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class LengthToFootConverter : ValueConverter<Length, double>
{
    public LengthToFootConverter() : base(length => (double)length.ToFeet(), lengthValue => Length.FromFeet(lengthValue)) { }
}
public class LengthToMeterConverter : ValueConverter<Length, double>
{
    public LengthToMeterConverter() : base(length => (double)length.ToMeters(), lengthValue => Length.FromMeters(lengthValue)) { }
}
