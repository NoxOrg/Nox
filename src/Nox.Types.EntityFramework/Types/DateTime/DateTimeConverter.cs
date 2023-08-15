using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class DateTimeConverter : ValueConverter<DateTimeOffset, System.DateTime>
{
    public DateTimeConverter()
        : base(
            d => d.UtcDateTime,
            d => new DateTimeOffset(d, TimeSpan.Zero))
    {
    }
}