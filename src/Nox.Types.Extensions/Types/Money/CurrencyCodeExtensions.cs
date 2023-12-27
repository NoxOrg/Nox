using Nox.Reference;

namespace Nox.Types.Extensions;

public static class CurrencyCodeExtensions
{
    public static Currency GetReferenceCurrency(this CurrencyCode currencyCode)
        => World.Currencies.GetByIsoCode(currencyCode.ToString())!;
}