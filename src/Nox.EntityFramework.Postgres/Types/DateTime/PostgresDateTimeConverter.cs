using Microsoft.EntityFrameworkCore.Storage.ValueConversion;


namespace Nox.EntityFramework.Postgres.Types.DateTime;

public class PostgresDateTimeConverter : ValueConverter<Nox.Types.DateTime, System.DateTime>
{
    public PostgresDateTimeConverter()
        : base(
            dateTime => dateTime.Value.UtcDateTime,
            dateTimeValue => Nox.Types.DateTime.FromDatabase(new DateTimeOffset(dateTimeValue, TimeSpan.Zero)))
    { }
}