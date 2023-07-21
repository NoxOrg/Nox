using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class AreaToSquareMeterConverter : ValueConverter<Area, double>
{
    public AreaToSquareMeterConverter() : base(area => (double)area.ToSquareMeters(), areaValue => Area.FromDatabase(areaValue, AreaTypeUnit.SquareMeter)) { }
}
public class AreaToSquareFootConverter : ValueConverter<Area, double>
{
    public AreaToSquareFootConverter() : base(area => (double)area.ToSquareFeet(), areaValue => Area.FromDatabase(areaValue, AreaTypeUnit.SquareFoot)) { }
}