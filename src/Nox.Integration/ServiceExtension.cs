using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Nox.Integration.Abstractions;
using Nox.Integration.Services;
using Microsoft.Extensions.Logging;
using Nox.Solution;

namespace Nox.Integration;

public static class ServiceExtension
{
    public static IServiceCollection AddNoxIntegrations(this IServiceCollection services, Solution.NoxSolution solution)
    {
        if (solution.Application is { Integrations: not null } && solution.Application.Integrations.Any())
        {
            services.TryAddSingleton<INoxIntegrationContext>(p =>
            {
                var logger = p.GetRequiredService<ILogger<INoxIntegrationContext>>();
                var context = new NoxIntegrationContext(logger, solution);
                context.Initialize();
                return context;
            });
        }
        
        return services;
    }
}