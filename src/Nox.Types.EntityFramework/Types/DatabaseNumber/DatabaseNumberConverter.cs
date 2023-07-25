using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class DatabaseNumberConverter : ValueConverter<DatabaseNumber, uint>
{
    public DatabaseNumberConverter() : base(databaseNumber => databaseNumber.Value, currentNumber => DatabaseNumber.FromDatabase(currentNumber)) { }
}
