using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class MonthConverter: ValueConverter<Month, byte>
{
    public MonthConverter() : base(month => month.Value, monthValue => Month.FromDatabase(monthValue)) { }
}