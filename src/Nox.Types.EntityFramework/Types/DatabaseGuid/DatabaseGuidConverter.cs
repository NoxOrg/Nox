using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class DatabaseGuidConverter : ValueConverter<DatabaseGuid, System.Guid>
{
    public DatabaseGuidConverter() : base(databaseGuid => databaseGuid.Value, currentGuid => DatabaseGuid.FromDatabase(currentGuid)) { }
}
