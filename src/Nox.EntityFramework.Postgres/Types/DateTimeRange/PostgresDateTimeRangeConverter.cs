using Microsoft.EntityFrameworkCore.Storage.ValueConversion;


namespace Nox.EntityFramework.Postgres.Types.DateTimeRange;

public class PostgresDateTimeRangeConverter : ValueConverter<Nox.Types.DateTime, System.DateTime>
{
    public PostgresDateTimeRangeConverter()
        : base(
            dateTime => dateTime.Value.UtcDateTime,
            dateTimeValue => Nox.Types.DateTime.FromDatabase(new DateTimeOffset(dateTimeValue, TimeSpan.Zero)))
    { }
}