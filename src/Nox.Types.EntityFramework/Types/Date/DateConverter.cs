using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class DateConverter : ValueConverter<Date, System.DateTime>
{
    // Nox.Types.Date is mapped to System.DateTime instead of System.DateOnly because EF Core support for DateOnly comes in version 8.0
    public DateConverter() : base(date => date.Value.ToDateTime(System.TimeOnly.MinValue), dateValue => Date.FromDatabase(DateOnly.FromDateTime(dateValue))) { }
}
