using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class ReferenceNumberConverter : ValueConverter<ReferenceNumber, string>
{
    public ReferenceNumberConverter() : base(referenceNumber => referenceNumber.Value, currentNumber => ReferenceNumber.FromDatabase(currentNumber)) { }
}
