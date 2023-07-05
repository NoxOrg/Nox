using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class AreaToSquareMeterConverter : ValueConverter<Area, double>
{
    public AreaToSquareMeterConverter() : base(area => (double)area.ToSquareMeters(), areaValue => Area.FromSquareMeters(areaValue)) { }
}
public class AreaToSquareFeetConverter : ValueConverter<Area, double>
{
    public AreaToSquareFeetConverter() : base(area => (double)area.ToSquareFeet(), areaValue => Area.FromSquareFeet(areaValue)) { }
}
