using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class NuidConverter : ValueConverter<Nuid, uint>
{
    public NuidConverter() : base(nuid => nuid.Value, nuidValue => Nuid.FromDatabase(nuidValue))
    {
    }
}