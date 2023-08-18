using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Localization;

namespace Nox.Localization;

public static class ServiceExtension
{
    public static IServiceCollection AddNoxLocalization(this IServiceCollection services)
    {
        services.AddSingleton<DbContextOptions<NoxLocalizationDbContext>>();
        services.TryAddSingleton<INoxLocalizationDbContextFactory, NoxLocalizationDbContextFactory>();
        services.TryAddSingleton<IStringLocalizerFactory, SqlStringLocalizerFactory>();
        services.AddDbContext<NoxLocalizationDbContext>();
        return services;
    }
}