using Nox.Types;

namespace Nox.Generator;

public static class TypeExtensions
{
    public static string ToMappedType(this NoxType noxType)
    {
        return noxType switch
        {
            NoxType.LatLong => "LatLong",
            _ => noxType.ToString(),
        };
    }
}