using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class BooleanConverter : ValueConverter<Boolean, System.Boolean>
{
    public BooleanConverter() : base(date => date.Value, dateValue => Boolean.From(dateValue)) { }
}
