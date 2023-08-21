namespace Nox.Types;

public class VatNumberTypeOptions : INoxTypeOptions
{

    private static readonly CountryCode DefaultCountryCode = CountryCode.GB;
    public CountryCode CountryCode { get; set; } = DefaultCountryCode;
}
