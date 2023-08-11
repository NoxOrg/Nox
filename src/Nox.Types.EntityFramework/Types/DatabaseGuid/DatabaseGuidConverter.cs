using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class DatabaseGuidConverter : ValueConverter<DatabaseGuid, Guid>
{
    public DatabaseGuidConverter() : base(databaseGuid => databaseGuid.Value, currentGuid => DatabaseGuid.FromDatabase(currentGuid)) { }
}
