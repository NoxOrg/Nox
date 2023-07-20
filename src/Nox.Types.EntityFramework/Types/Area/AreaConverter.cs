using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class AreaConverter : ValueConverter<Area, double>
{
    /// <summary>
    ///  For Area we always persist in double, no need to use a decimal for this type and that way we save some database storage.
    /// </summary>
    public AreaConverter() : base(area => (double)area.ToSquareMeters(), areaValue => Area.FromDatabase(areaValue)) { }
}
