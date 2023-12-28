using Nox.Reference;

namespace Nox.Types.Extensions;

public static class CountryCode3Extensions
{
    public static Country GetReferenceCountry(this CountryCode3 countryCode3)
        => World.Countries.GetByAlpha3Code(countryCode3.Value)!;
}