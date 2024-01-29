using MudBlazor.Services;
using Nox.Ui.Blazor.Lib.Services;
using Cryptocash.Ui.Services;

namespace Cryptocash.Ui.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddNoxUi(this IServiceCollection services)
    {
        services.AddSingleton<GlobalDataService>();
        services.AddMudServices();
        services.AddHttpClient();
        services.AddScoped<EndpointsProvider>();
        services.AddScoped<BookingsService>();
        services.AddScoped<CashStockOrdersService>();
        services.AddScoped<CommissionsService>();
        services.AddScoped<CountriesService>();
        services.AddScoped<CurrenciesService>();
        services.AddScoped<CustomersService>();
        services.AddScoped<EmployeesService>();
        services.AddScoped<LandLordsService>();
        services.AddScoped<MinimumCashStocksService>();
        services.AddScoped<PaymentDetailsService>();
        services.AddScoped<PaymentProvidersService>();
        services.AddScoped<TransactionsService>();
        services.AddScoped<VendingMachinesService>();
        
        return services;
    }
}