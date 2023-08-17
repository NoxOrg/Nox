using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class DateTimeOffsetConverter : ValueConverter<DateTimeOffset, System.DateTime>
{
    public DateTimeOffsetConverter()
        : base(
            d => d.UtcDateTime,
            d => new DateTimeOffset(d, TimeSpan.Zero))
    {
    }
}