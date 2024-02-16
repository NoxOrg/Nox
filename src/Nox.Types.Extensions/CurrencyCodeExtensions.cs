using Nox.Reference;
using Nox.Reference.Data.World;

namespace Nox.Types.Extensions;

public static class CurrencyCodeExtensions
{
    public static CurrencyCode GetCurrencyCode(this Currency referenceCurrency)
        => Enum.Parse<CurrencyCode>(referenceCurrency.IsoCode)!;

    public static CurrencyCode3 GetCurrencyCode3(this Currency referenceCurrency)
        => CurrencyCode3.From(referenceCurrency.IsoCode)!;
      
    public static Currency GetReferenceCurrency(this Money money)
    {
        using var worldContext = new WorldContext();
        return worldContext.GetCurrenciesQuery().GetByIsoCode(money.CurrencyCode.ToString())!;
    }
    public static Currency GetReferenceCurrency(this CurrencyCode currencyCode)
    {
        using var worldContext = new WorldContext();
        return worldContext.GetCurrenciesQuery().GetByIsoCode(currencyCode.ToString())!; 
    }
    public static Currency GetReferenceCurrency(this CurrencyCode3 currencyCode)
    {
        using var worldContext = new WorldContext();
        return worldContext.GetCurrenciesQuery().GetByIsoCode(currencyCode.Value)!;
    }
}