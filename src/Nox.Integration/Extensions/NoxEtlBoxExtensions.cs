using ETLBoxOffice.LicenseManager;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Nox.Integration.Abstractions;
using Nox.Integration.Services;

namespace Nox.Integration;

public static class NoxEtlBoxExtensions
{
    public static IApplicationBuilder UseEtlBox(this IApplicationBuilder appBuilder, bool checkLicense)
    {
        if (!checkLicense)
        {
            return appBuilder;
        }

        var etlLicenseProvider = appBuilder.ApplicationServices.GetRequiredService<IEtlBoxLicenseProvider>();

        LicenseCheck.LicenseKey = etlLicenseProvider.GetLicenseKey();
        LicenseCheck.CheckValidLicenseOrThrow(progressCount: 1);

        return appBuilder;
    }

    public static IServiceCollection AddEtlBox(this IServiceCollection services)
    {
        services.AddScoped<IEtlBoxLicenseProvider, EtlBoxLicenseValueProvider>();
        return services;
    }
}