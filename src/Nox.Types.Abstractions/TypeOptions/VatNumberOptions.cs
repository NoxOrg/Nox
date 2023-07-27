namespace Nox.Types;

public class VatNumberOptions : INoxTypeOptions
{

    private static readonly string DefaultCountryCode = "GB";
    public string CountryCode { get; set; } = DefaultCountryCode;
}
