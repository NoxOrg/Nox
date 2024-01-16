using Nox.Reference;

namespace Nox.Types.Extensions;

public static class MoneyExtensions
{
    public static Currency GetReferenceCurrency(this Money money)
        => World.Currencies.GetByIsoCode(money.CurrencyCode.ToString())!;

    public static Currency GetReferenceCurrency(this CurrencyCode currencyCode)
       => World.Currencies.GetByIsoCode(currencyCode.ToString())!;
}