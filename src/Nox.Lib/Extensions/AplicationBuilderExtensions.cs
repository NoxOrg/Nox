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
        public static INoxBuilder UseNox(this IApplicationBuilder builder)
        {

            builder.UseMiddleware<NoxExceptionHanderMiddleware>();

            builder.UseRequestLocalization();

            var noxBuilder = new NoxBuilder(builder);
#if DEBUG
            noxBuilder.UseODataRouteDebug();
#endif
            return noxBuilder;
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
}