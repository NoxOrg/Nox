using Microsoft.EntityFrameworkCore;
using Cryptocash.DataSeed.Seeders;
using Cryptocash.Infrastructure;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.DataSeed;

public static class DataSeedExtensions
{
    public static IServiceCollection AddDataSeeders(this IServiceCollection services)
    {
        return services
            .AddScoped<ISeedDataReader, JsonSeedDataReader>()
            .AddScoped<IDataSeeder, CryptocashPaymentProviderDataSeeder>()
            .AddScoped<IDataSeeder, CryptocashCurrencyDataSeeder>()
            .AddScoped<IDataSeeder, CryptocashCountryDataSeeder>()
            .AddScoped<IDataSeeder, CryptocashEmployeeDataSeeder>()
            .AddScoped<IDataSeeder, CryptocashLandLordDataSeeder>()
            .AddScoped<IDataSeeder, CryptocashCommissionDataSeeder>()
            .AddScoped<IDataSeeder, CryptocashCustomerDataSeeder>()
            .AddScoped<IDataSeeder, CryptocashPaymentDetailDataSeeder>()
            .AddScoped<IDataSeeder, CryptocashVendingMachineDataSeeder>()
            .AddScoped<IDataSeeder, CryptocashMinimumCashStockDataSeeder>()
            .AddScoped<IDataSeeder, CryptocashCashStockOrderDataSeeder>()
            .AddScoped<IDataSeeder, CryptocashBookingDataSeeder>()
            .AddScoped<IDataSeeder, CryptocashTransactionDataSeeder>();
    }

    public static void SeedDataIfRequired(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        // A workaround to ensure the database is created and seeded, since it could not be performed on integration test level
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        dbContext.Database.Migrate();

        var dataSeeders = scope.ServiceProvider.GetServices<IDataSeeder>();

        foreach (var dataSeeder in dataSeeders)
        {
            dataSeeder.Seed();
        }
    }
}

