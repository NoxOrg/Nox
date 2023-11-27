using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Nox.Integration.Abstractions;
using Nox.Lib;
using Nox.Solution;
using Serilog;

namespace Nox
{
    public static class ApplicationBuilderBuilderExtensions
    {
        /// <summary>
        /// Add Nox to the application builder, with optional Serilog request logging
        /// </summary>
        public static INoxBuilder UseNox(this IApplicationBuilder builder,
            bool useSerilogRequestLogging = true)
        {
            // Enabling http requests logging
            if (useSerilogRequestLogging)
                builder.UseSerilogRequestLogging();

            builder.UseMiddleware<NoxExceptionHanderMiddleware>();

            builder.UseRequestLocalization();

            var noxBuilder = new NoxBuilder(builder);
#if DEBUG
            noxBuilder.UseODataRouteDebug();
#endif

            var hostingEnvironment = builder
                .ApplicationServices
                .GetRequiredService<IHostEnvironment>();

            var isDevelopment = hostingEnvironment.IsDevelopment();
            if (isDevelopment)
            {
                builder.UseSwagger();
                builder.UseSwaggerUI();
            }

            noxBuilder.UseEtlBox(checkLicense: !isDevelopment);

            var integrationContext = builder
                .ApplicationServices
                .GetService<INoxIntegrationContext>();

            integrationContext?.ExecuteStartupIntegrations();

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

            builder.UseRequestLocalization(options =>
            {
                options.DefaultRequestCulture = new RequestCulture(culture: defaultCulture, uiCulture: defaultCulture);
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });

            return builder;
        }
    }
}