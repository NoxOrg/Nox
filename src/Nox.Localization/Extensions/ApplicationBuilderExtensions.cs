using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Localization;
using Nox.Abstractions.Localization;
using Nox.Localization.DbContext;
using Nox.Localization.Localizers;

namespace Nox.Localization.Extensions;

public static class ApplicationBuilderExtensions
{
    public static WebApplicationBuilder UseNoxLocalization(this WebApplicationBuilder builder, Action<NoxLocalizationOptionsBuilder>? localizationOptionsAction = null)
    {
        builder.Services.TryAddSingleton<INoxLocalizationDbContextFactory, NoxLocalizationDbContextFactory>();
        builder.Services.TryAddSingleton<IStringLocalizerFactory, SqlStringLocalizerFactory>();
        var localizationOptionsBuilder = new NoxLocalizationOptionsBuilder(builder.Services);
        localizationOptionsAction?.Invoke(localizationOptionsBuilder);
        return builder;
    }
}