﻿using Microsoft.Extensions.Configuration;
using Nox.Integration.Abstractions.Constants;
using Nox.Integration.Abstractions.Interfaces;

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
