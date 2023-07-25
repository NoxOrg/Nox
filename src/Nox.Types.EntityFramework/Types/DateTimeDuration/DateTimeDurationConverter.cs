using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class DateTimeDurationConverter : ValueConverter<DateTimeDuration, long>
{
    public DateTimeDurationConverter() : base(dateTimeDuration => dateTimeDuration.Value, dateTimeDurationValue => DateTimeDuration.FromDatabase(dateTimeDurationValue)) { }
}
