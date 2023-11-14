using Nox.Yaml.Tests.TestDesigns.Nox.Types.Enums;
using Nox.Yaml.Tests.TestDesigns.Nox.Types.Interfaces;

namespace Nox.Yaml.Tests.TestDesigns.Nox.Types.TypeOptions;

public class VatNumberTypeOptions : INoxTypeOptions
{

    private static readonly CountryCode DefaultCountryCode = CountryCode.GB;
    public CountryCode CountryCode { get; set; } = DefaultCountryCode;
}
