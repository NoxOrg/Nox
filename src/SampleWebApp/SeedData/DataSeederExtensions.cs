using Nox;

namespace SampleWebApp.SeedData;

public static class DataSeederExtensions
{
    public static IServiceCollection AddSeedData(this WebApplicationBuilder appBuilder)
    {
        appBuilder.Services.AddScoped<INoxDataSeeder, CountryDataSeeder>();
        appBuilder.Services.AddScoped<INoxDataSeeder, CurrencyDataSeeder>();
        appBuilder.Services.AddScoped<INoxDataSeeder, VendingMachineDataSeeder>();
        appBuilder.Services.AddScoped<INoxDataSeeder, AllNoxTypesDataSeeder>();

        return appBuilder.Services;
    }

    public static void SeedDataIfNeed(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            using var scope = app.Services.CreateScope();
            var dataSeeders = scope.ServiceProvider.GetServices<INoxDataSeeder>();

            foreach (var dataSeeder in dataSeeders)
            {
                dataSeeder.Seed();
            }
        }
    }
}