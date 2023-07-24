using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class AreaToSquareMeterConverter : ValueConverter<Area, decimal>
{
    public AreaToSquareMeterConverter() : base(area =>
        (decimal)area.ToSquareMeters(), areaValue => Area.FromDatabase(areaValue, AreaTypeUnit.SquareMeter)) { }
}
public class AreaToSquareFootConverter : ValueConverter<Area, decimal>
{
    public AreaToSquareFootConverter() : base(area => 
        (decimal)area.ToSquareFeet(), areaValue => Area.FromDatabase(areaValue, AreaTypeUnit.SquareFoot)) { }
}