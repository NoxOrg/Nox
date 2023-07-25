using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types.DayOfWeek;

public class DayOfWeekConverter : ValueConverter<Nox.Types.DayOfWeek, int>
{
    public DayOfWeekConverter() : base(dayOfWeek => dayOfWeek.Value, dayOfWeekValue => Nox.Types.DayOfWeek.FromDatabase(dayOfWeekValue)) { }
}