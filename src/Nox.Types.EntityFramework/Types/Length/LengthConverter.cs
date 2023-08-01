using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class LengthToFootConverter : ValueConverter<Length, decimal>
{
    public LengthToFootConverter() : base(length => (decimal)length.ToFeet(), lengthValue => Length.FromDatabase(lengthValue, LengthTypeUnit.Foot)) { }
}
public class LengthToMeterConverter : ValueConverter<Length, decimal>
{
    public LengthToMeterConverter() : base(length => (decimal)length.ToMeters(), lengthValue => Length.FromDatabase(lengthValue, LengthTypeUnit.Meter)) { }
}
