using Nox.Reference;

namespace Nox.Types.Extensions;

public static class CurrencyCodeExtensions
{
    public static CurrencyCode GetCurrencyCode(this Currency referenceCurrency)
        => Enum.Parse<CurrencyCode>(referenceCurrency.IsoCode)!;

    public static CurrencyCode3 GetCurrencyCode3(this Currency referenceCurrency)
        => CurrencyCode3.From(referenceCurrency.IsoCode)!;

    public static Currency GetReferenceCurrency(this Money money)
        => World.Currencies.GetByIsoCode(money.CurrencyCode.ToString())!;

    public static Currency GetReferenceCurrency(this CurrencyCode currencyCode)
       => World.Currencies.GetByIsoCode(currencyCode.ToString())!;

    public static Currency GetReferenceCurrency(this CurrencyCode3 currencyCode)
        => World.Currencies.GetByIsoCode(currencyCode.Value)!;
}