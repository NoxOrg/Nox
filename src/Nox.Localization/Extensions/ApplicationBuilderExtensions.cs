using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Localization;
using Nox.Abstractions;

namespace Nox.Localization;

public static class ApplicationBuilderExtensions
{
    public static WebApplicationBuilder UseNoxLocalization(this WebApplicationBuilder builder, Action<NoxLocalizationOptionsBuilder>? localizationOptionsAction = null)
    {
        builder.Services.TryAddSingleton<INoxLocalizationDbContextFactory, NoxLocalizationDbContextFactory>();
        builder.Services.TryAddSingleton<IStringLocalizerFactory, SqlStringLocalizerFactory>();
        builder.Services.AddDbContext<NoxLocalizationDbContext>();
        var localizationOptionsBuilder = new NoxLocalizationOptionsBuilder(builder.Services);
        localizationOptionsAction?.Invoke(localizationOptionsBuilder);
        return builder;
    }
}