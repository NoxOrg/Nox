using Nox.Reference;

namespace Nox.Types.Extensions;

public static class CountryExtensions
{
    public static CountryCode2 GetCountryCode2(this Country referenceCountry) => CountryCode2.From(referenceCountry.AlphaCode2);
    public static CountryCode3 GetCountryCode3(this Country referenceCountry) => CountryCode3.From(referenceCountry.AlphaCode3);
    public static CountryNumber GetCountryNumber(this Country referenceCountry) => CountryNumber.From(ushort.Parse(referenceCountry.NumericCode));
    public static Country GetReferenceCountry(this CountryCode3 countryCode3) => World.Countries.GetByAlpha3Code(countryCode3.Value)!;
    public static Country GetReferenceCountry(this CountryCode2 countryCode2) => World.Countries.GetByAlpha2Code(countryCode2.Value)!;
    public static Country GetReferenceCountry(this CountryNumber countryNumber) => World.Countries.GetByNumericCode(countryNumber.Value.ToString())!;
}