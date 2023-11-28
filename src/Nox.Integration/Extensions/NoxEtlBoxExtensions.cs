using System;
using ETLBoxOffice.LicenseManager;
using Microsoft.Extensions.DependencyInjection;
using Nox.Integration.Abstractions;
using Nox.Integration.Services;

namespace Nox.Integration.Extensions;

public static class NoxEtlBoxExtensions
{
    public static IServiceProvider UseEtlBox(this IServiceProvider serviceProvider, bool checkLicense)
    {
        if (!checkLicense)
        {
            return serviceProvider;
        }

        var etlLicenseProvider = serviceProvider.GetRequiredService<IEtlBoxLicenseProvider>();

        LicenseCheck.LicenseKey = etlLicenseProvider.GetLicenseKey();
        LicenseCheck.CheckValidLicenseOrThrow(progressCount: 1);

        return serviceProvider;
    }

    public static IServiceCollection AddEtlBox(this IServiceCollection services)
    {
        services.AddScoped<IEtlBoxLicenseProvider, EtlBoxLicenseValueProvider>();
        return services;
    }
}