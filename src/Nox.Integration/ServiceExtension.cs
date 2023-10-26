using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Nox.Integration.Abstractions;
using Nox.Solution;

namespace Nox.Integration;

public static class ServiceExtension
{
    public static IServiceCollection AddNoxIntegrations(this IServiceCollection services, Solution.Solution solution)
    {
        //Create a new integrationContext and add to serviceProvider. as a singleton
        services.TryAddSingleton<INoxIntegrationContext>(p =>
        {
            var context = new NoxIntegrationContext(p.GetRequiredService<NoxSolution>());
            context.Initialize();
            return context;
        });
        //go through integrations in nox solution definition and add them to integrationContext
        
        return services;
    }
}