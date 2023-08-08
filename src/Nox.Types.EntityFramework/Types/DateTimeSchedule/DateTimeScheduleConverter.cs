using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class DateTimeScheduleConverter : ValueConverter<DateTimeSchedule, string>
{
    public DateTimeScheduleConverter() : base(dts => dts.Value, dtsValue => DateTimeSchedule.FromDatabase(dtsValue)) { }

}