using ETLBoxOffice.LicenseManager;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Nox.Integration.Abstractions;

namespace Nox.Integration.Extensions;

public static class NoxEtlBoxExtensions
{
    public static void UseEtlBox(this IApplicationBuilder applicationBuilder)
    {
        var etlLicenseProvider = applicationBuilder.ApplicationServices.GetRequiredService<IEtlBoxLicenseProvider>();

        LicenseCheck.LicenseKey = etlLicenseProvider.GetLicenseKey();

        LicenseCheck.CheckValidLicenseOrThrow(progressCount: 1);
    }
}