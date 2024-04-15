using ETLBox;
using ETLBoxOffice.LicenseManager;
using Microsoft.Extensions.DependencyInjection;
using Nox.Integration.Abstractions.Interfaces;
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

    public static MergeMode ToEtlBoxMergeMode(this IntegrationMergeType mergeType)
    {
        switch (mergeType)
        {
            case IntegrationMergeType.MergeNew:
                return MergeMode.InsertsAndUpdates;
            case IntegrationMergeType.AddNew:
                return MergeMode.InsertsOnly;
        }

        throw new NotImplementedException($"Merge Type: {mergeType.ToString()} has not been implemented!");
    }
}