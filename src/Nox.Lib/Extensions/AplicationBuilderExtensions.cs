using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.OData;
using Microsoft.Extensions.DependencyInjection;
using Nox.Lib;
using Nox.Solution;

namespace Nox
{
    public static class ApplicationBuilderBuilderExtensions
    {
        public static void UseNox(this IApplicationBuilder builder)
        {
#if DEBUG
            builder.UseODataRouteDebug();
#endif
            builder.UseMiddleware<NoxExceptionHanderMiddleware>();

            builder.UseRequestLocalization();
        }
        
        private static IApplicationBuilder UseNoxLocalization(this IApplicationBuilder builder) 
        {
            var solution = builder.ApplicationServices.GetRequiredService<NoxSolution>();

            var supportedCultures = solution.Application?.Localization?.SupportedCultures
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
}