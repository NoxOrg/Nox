using Nox.Reference;

namespace Nox.Types.Extensions;

public static partial class CountryExtensions
{
    public static CountryCode3 GetCountryCode3(this Country country)
        => CountryCode3.From(country.AlphaCode3);
}