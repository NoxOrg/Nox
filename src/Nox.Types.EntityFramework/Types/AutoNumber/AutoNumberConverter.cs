using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class AutoNumberConverter : ValueConverter<AutoNumber, long>
{
    public AutoNumberConverter() : base(autoNumber => autoNumber.Value, currentNumber => AutoNumber.FromDatabase(currentNumber)) { }
}
