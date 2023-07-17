using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class DateTimeDurationConverter : ValueConverter<DateTimeDuration, TimeSpan>
{
    public DateTimeDurationConverter() : base(dateTimeDuration => dateTimeDuration.Value, dateTimeDurationValue => DateTimeDuration.From(dateTimeDurationValue)) { }
}
