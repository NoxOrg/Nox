using Nox.Reference;

namespace Nox.Types.Extensions;

public static class CountryNumberExtensions
{
    public static Country GetReferenceCountry(this CountryNumber countryNumber)
        => World.Countries.GetByNumericCode(countryNumber.Value.ToString())!;
}