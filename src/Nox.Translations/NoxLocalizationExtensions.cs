
using Localization.SqlLocalizer.DbStringLocalizer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

namespace Nox.Localization.Extensions;

public static class NoxLocalizationExtensions 
{
    public static IServiceCollection AddNoxLocalization(this IServiceCollection services)
    {
        var sqlConnectionString = "Data Source=localization.db;";

        services.AddDbContext<LocalizationModelContext>(options =>
            options.UseSqlite(
                sqlConnectionString,
                b => b.MigrationsAssembly("ImportExportLocalization")
            ),
            ServiceLifetime.Singleton,
            ServiceLifetime.Singleton
        );

        // Requires that LocalizationModelContext is defined
        services.AddSqlLocalization(options => {
            options.UseTypeFullNames = true;
            options.CreateNewRecordWhenLocalisedStringDoesNotExist = true;
        });

        services.Configure<RequestLocalizationOptions>(
            options =>
            {
                var supportedCultures = new List<CultureInfo>
                    {
                            new CultureInfo("en-US"),
                            new CultureInfo("en-GB"),
                            new CultureInfo("de-CH"),
                            new CultureInfo("fr-CH"),
                            new CultureInfo("it-CH"),
                            new CultureInfo("fr-FR")
                    };
        
                options.DefaultRequestCulture = new RequestCulture(culture: "en-US", uiCulture: "en-US");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });

        return services;

    }
}