using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class YearToUShortConverter : ValueConverter<Year, ushort>
{
    public YearToUShortConverter() : base(year => year.Value, n => Year.From(n)) { }
}
