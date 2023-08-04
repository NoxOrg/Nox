using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.OData;
using Microsoft.Extensions.DependencyInjection;
using Nox.Solution;
using System.Globalization;

namespace Nox;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseNox(this IApplicationBuilder builder)
    {
#if DEBUG
        builder.UseODataRouteDebug();
#endif

        UseNoxLocalization(builder);

        return builder;

    }

    private static IApplicationBuilder UseNoxLocalization(this IApplicationBuilder builder) 
    {
        var solution = builder.ApplicationServices.GetRequiredService<NoxSolution>();
        
        var supportedCultures = solution?.Application?.Localization?.SupportedCultures
            .Select(s => new CultureInfo(s)).ToList(); 

        if (supportedCultures is null) return builder;

        var defaultCulture = solution?.Application?.Localization?.DefaultCulture;

        if (defaultCulture is null) return builder;

        builder.UseRequestLocalization(options => {
            options.DefaultRequestCulture = new RequestCulture(culture: defaultCulture, uiCulture: defaultCulture);
            options.SupportedCultures = supportedCultures;
            options.SupportedUICultures = supportedCultures;
        });

        return builder;
    }
}