using ETLBox;
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

        TryApplyEtlBoxLicense(etlLicenseProvider.GetLicenseKey());

        return serviceProvider;
    }

    private static void TryApplyEtlBoxLicense(string? licenseKey)
    {
        if (string.IsNullOrWhiteSpace(licenseKey))
        {
            return;
        }

        var licenseServiceType = Type.GetType("ETLBox.Licensing.LicenseService, ETLBox.Licensing");
        if (licenseServiceType == null)
        {
            return;
        }

        var licenseKeyProperty = licenseServiceType.GetProperty(
            "LicenseKey",
            System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
        licenseKeyProperty?.SetValue(null, licenseKey);

        var checkMethod = licenseServiceType.GetMethod(
            "CheckValidLicenseOrThrow",
            System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);

        if (checkMethod == null)
        {
            return;
        }

        var parameters = checkMethod.GetParameters();
        if (parameters.Length == 1 && parameters[0].ParameterType == typeof(int))
        {
            checkMethod.Invoke(null, new object[] { 1 });
        }
        else
        {
            checkMethod.Invoke(null, null);
        }
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
