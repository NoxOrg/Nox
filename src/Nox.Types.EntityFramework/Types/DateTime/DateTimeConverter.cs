using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class DateTimeConverter : ValueConverter<DateTime, DateTimeOffset>
{
    public DateTimeConverter() : base(dt => dt.Value, dtValue => DateTime.FromDatabase(dtValue)) { }

}