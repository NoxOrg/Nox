using Microsoft.Extensions.Configuration;
using Nox.Integration.Abstractions;
using Nox.Integration.Constants;

namespace Nox.Integration.Services;

internal class EtlBoxLicenseValueProvider : IEtlBoxLicenseProvider
{
    private readonly IConfiguration _configuration;

    public EtlBoxLicenseValueProvider(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GetLicenseKey()
    {
        var licenseKey = _configuration.GetValue<string>(NoxEtlConfigurationConstants.EtlBoxLicenseKey)!;

        return licenseKey;
    }
}
