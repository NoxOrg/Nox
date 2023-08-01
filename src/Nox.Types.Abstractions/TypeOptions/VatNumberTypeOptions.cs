namespace Nox.Types;

public class VatNumberTypeOptions : INoxTypeOptions
{

    private static readonly string DefaultCountryCode = "GB";
    public string CountryCode { get; set; } = DefaultCountryCode;
}
