using Microsoft.Extensions.Configuration;
using Nox.Integration.Abstractions.Constants;
using Nox.Integration.Abstractions.Interfaces;

namespace Nox.Integration.Services;

internal class EtlBoxLicenseFileProvider : IEtlBoxLicenseProvider
{
    private readonly IConfiguration _configuration;

    public EtlBoxLicenseFileProvider(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GetLicenseKey()
    {
        var licenseFileName = _configuration.GetValue<string>(NoxEtlConfigurationConstants.EtlBoxLicenseFileName)!;

        using var reader = new StreamReader(licenseFileName);
        var licenseKey = reader.ReadToEnd();

        return licenseKey;
    }
}
