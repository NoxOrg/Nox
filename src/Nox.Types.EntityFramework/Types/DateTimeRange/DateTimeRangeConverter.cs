using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class DateTimeRangeConverter : ValueConverter<DateTimeOffset, System.DateTime>
{
    public DateTimeRangeConverter()
        : base(
            d => d.UtcDateTime,
            d => new DateTimeOffset(d, TimeSpan.Zero))
    {
    }
}