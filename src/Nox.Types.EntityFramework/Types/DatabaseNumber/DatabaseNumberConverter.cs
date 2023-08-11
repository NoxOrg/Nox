using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class DatabaseNumberConverter : ValueConverter<DatabaseNumber, long>
{
    public DatabaseNumberConverter() : base(databaseNumber => (long)databaseNumber.Value, currentNumber => DatabaseNumber.FromDatabase((long)currentNumber)) { }
}
