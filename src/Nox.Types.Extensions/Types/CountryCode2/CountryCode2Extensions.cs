using Nox.Reference;

namespace Nox.Types.Extensions;

public static class CountryCode2Extensions
{
    public static Country GetReferenceCountry(this CountryCode2 countryCode2)
        => World.Countries.GetByAlpha2Code(countryCode2.Value)!;
}