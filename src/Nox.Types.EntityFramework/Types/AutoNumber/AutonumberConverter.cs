using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class AutoNumberConverter : ValueConverter<AutoNumber, uint>
{
    public AutoNumberConverter() : base(autonumber => autonumber.Value, currentNumber => AutoNumber.From(currentNumber)) { }
}
