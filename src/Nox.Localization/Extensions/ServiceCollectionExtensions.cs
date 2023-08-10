using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Nox.Localization.Localizers;

namespace Nox.Localization.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddNoxLocalization(this IServiceCollection services)
    {

        services.AddSingleton<IStringLocalizerFactory, SqlStringLocalizerFactory>();
        return services;
    }
}