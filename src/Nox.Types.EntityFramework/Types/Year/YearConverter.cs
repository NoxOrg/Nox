using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class YearConverter : ValueConverter<Year, ushort>
{
    public YearConverter() : base(year => year.Value, yearValue => Year.FromDatabase(yearValue)) { }
}
