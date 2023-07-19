using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class DateConverter : ValueConverter<Date, System.DateTime>
{
    public DateConverter() : base(date => date.Value, dateValue => Date.From(dateValue, new())) { }
}
