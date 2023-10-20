using ETLBoxOffice.LicenseManager;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Nox.Integration.Abstractions;

namespace Nox.Integration.Extensions;

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
}