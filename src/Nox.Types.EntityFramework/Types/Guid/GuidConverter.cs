using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class GuidConverter : ValueConverter<Guid, System.Guid>
{
    public GuidConverter() : base(guid => guid.Value, guidValue => Guid.FromDatabase(guidValue))
    {
    }
}