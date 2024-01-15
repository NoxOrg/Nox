using Nox.Reference;

namespace Nox.Types.Extensions;

public static partial class CountryExtensions
{
    public static CountryCode2 GetCountryCode2(this Country country)
        => CountryCode2.From(country.AlphaCode2);
}