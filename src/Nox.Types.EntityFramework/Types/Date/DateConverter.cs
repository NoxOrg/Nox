using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class DateConverter : ValueConverter<Date, DateOnly>
{
    public DateConverter() : base(date => date.Value, dateValue => Date.From(dateValue, new())) { }
}
