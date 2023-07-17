using Nox;
using SampleWebApp.SeedData;

namespace SampleWebApp.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddSeedData(this WebApplicationBuilder appBuilder)
    {
        appBuilder.Services.AddScoped<INoxDataSeeder, CountryDataSeeder>();

        return appBuilder.Services;
    }
}