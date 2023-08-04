using AspNetCoreLocalization;
using Microsoft.Extensions.Localization;
using SampleWebApp.Infrastructure.Persistence;
using System.Globalization;

namespace SampleWebApp.SeedData;

public static class DataSeederExtensions
{
    public static IServiceCollection AddSeedData(this WebApplicationBuilder appBuilder)
    {
        appBuilder.Services.AddScoped<INoxDataSeeder, CountryDataSeeder>();
        appBuilder.Services.AddScoped<INoxDataSeeder, CurrencyDataSeeder>();
        appBuilder.Services.AddScoped<INoxDataSeeder, StoreDataSeeder>();

        return appBuilder.Services;
    }

    public static void SeedDataIfNeed(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;

            var dataSeeders = services.GetServices<INoxDataSeeder>();
            var dbContext = services.GetService<SampleWebAppDbContext>();

            dbContext!.Database.EnsureDeleted();
            dbContext!.Database.EnsureCreated();

            foreach (var dataSeeder in dataSeeders)
            {
                dataSeeder.Seed();
            }

            // Seed localization
            var factory = services.GetService<IStringLocalizerFactory>();

            if ( factory is not null ) 
            {
                var currentCulture = CultureInfo.CurrentCulture;

                CultureInfo.CurrentCulture = new CultureInfo("en");

                var l = factory.Create(typeof(SharedResource)); ;

                foreach (var c in dbContext.Countries)
                {
                    _ = l![$"Countries/{c.Id.Value}/Name"];
                }

                CultureInfo.CurrentCulture = currentCulture;
            }
        }
    }
}