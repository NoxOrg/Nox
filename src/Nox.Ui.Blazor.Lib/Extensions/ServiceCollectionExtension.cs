using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using Nox.Ui.Blazor.Lib.Services;

namespace Nox.Ui.Blazor.Lib.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddNoxUi(this IServiceCollection services)
    {
        services.AddSingleton<GlobalDataService>();
        services.AddMudServices();
        return services;
    }
}