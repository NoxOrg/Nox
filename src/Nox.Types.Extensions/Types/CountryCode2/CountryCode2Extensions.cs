using Nox.Reference;

namespace Nox.Types.Extensions;

public static class CountryCode2Extensions
{
    public static Country GetReferenceCountry(this CountryCode2 countryCode2)
        => World.Countries.Get(countryCode2.Value)!; // TODO: should we throw an exception here?
}