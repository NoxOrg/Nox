using Nox.Reference;

namespace Nox.Types.Extensions;

public static partial class CountryExtensions
{
    public static CountryNumber GetCountryNumber(this Country country)
        => CountryNumber.From(ushort.Parse(country.NumericCode));
}